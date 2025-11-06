using AMartinezTech.Application.Cash.Income; 
using AMartinezTech.Application.Policy;
using AMartinezTech.Application.Policy.DTOs;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.WinForms.Utils;

namespace AMartinezTech.WinForms.Cash.Income;

public partial class FrmIncomeView : Form
{

    #region "Fields"
    private CancellationTokenSource? _cts;
    private readonly IncomeAppServices _appServices;
    private readonly PolicyAppService _policyAppService;
    public Guid IncomeId = Guid.Empty;
    public Guid PolicyId = Guid.Empty;
    public PolicyDto? Policy { get; private set; }
    public IncomeDto? Income { get; private set; }
    #endregion
    #region "Constructor"
    public FrmIncomeView(IncomeAppServices incomeAppServices, PolicyAppService policyAppService)
    {
        InitializeComponent();
        _appServices = incomeAppServices;
        _policyAppService = policyAppService;
        SetColorUI();
    }
    #endregion
    #region "Form events"
    private void FrmIncomeView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        FillComboBoxs();
        LoadPolicyById();
    }
    #endregion
    #region "Methods"
    private void FillComboBoxs()
    {
        var paymentMethods = Enum.GetValues<PaymentMethods>()
            .Cast<PaymentMethods>()
            .Select(e => new
            {
                Value = e,
                Text = e.GetDisplayName()
            })
            .ToList();

        PaymentMethod.DataSource = paymentMethods;
        PaymentMethod.DisplayMember = "Text";
        PaymentMethod.ValueMember = "Value";
        PaymentMethod.SelectedIndex = -1;

        var incomeMadeIn = Enum.GetValues<IncomeMadeIn>()
            .Cast<IncomeMadeIn>()
            .Select(e => new
            {
                Value = e,
                Text = e.GetDisplayName()
            })
            .ToList();

        MadeIn.DataSource = incomeMadeIn;
        MadeIn.DisplayMember = "Text";
        MadeIn.ValueMember = "Value";
        MadeIn.SelectedIndex = -1;
    }
    private async void LoadPolicyById()
    {

        Policy = await _policyAppService.GetByIdAsync(PolicyId);
        PolicyNo.Text = Policy.PolicyNo;
        InsuranceName.Text = Policy.InsuranceName;
        ClientName.Text = Policy.ClientName;
        Amount.Text = Policy.Amount.ToString("N2");

    }
    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;
        PanelButtom.BackColor = AppColors.Primary;
        PanelLineTop.BackColor = AppColors.Outline;
        PanelLineButtom.BackColor = AppColors.Outline;
        PanelAlertMessage.BackColor = AppColors.SurfaceMessage;


        // Btn
        BtnPersistence.IconColor = AppColors.Primary;

        // Label
        LabelTitle.ForeColor = AppColors.OnPrimary;
    }
    private void ClearMessageErr()
    {
        errorProvider1.Clear();

        if (LabelAlertMessage.Text.Contains("Formulario"))
        {
            return;
        }

        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
    }
    private async Task SetInitialMessage(int seconds, Label messageLabel)
    {
        messageLabel.Click += (sender, e) =>
        {
            _cts?.Cancel();

        };
        try
        {
            // Cambiar a mensaje inicial
            var countdown = new CountdownTimer(seconds,
                onCountdownFinished: () => SetMessage("Formulario preparado para recibir datos.", MessageType.Information));

            // Inicia la cuenta establecida en CountdownTimer y espera
            await countdown.StartAsync(_cts!.Token);
        }
        catch (OperationCanceledException)
        {
            // Captura la cancelación del temporizador
            SetMessage("Formulario preparado para recibir datos.", MessageType.Information);

        }
        finally
        {
            if (_cts != null)
            {
                _cts.Dispose();
                _cts = null;
            }
        }
    }
    private void SetMessage(string message, MessageType type)
    {
        var msg = new HandlerMessages(message, type);
        LabelAlertMessage.Text = $"{msg.Icon} {msg.Message}";
        LabelAlertMessage.ForeColor = msg.MessageColor;
    }
    private void ValidationFields(string fieldName)
    {
        if (fieldName.Contains("PaymentMethod"))
        {
            PaymentMethod.Focus();
            errorProvider1.SetError(PaymentMethod, "Aquí!");
        }
        else if (fieldName.Contains("MadeIn"))
        {
            MadeIn.Focus();
            errorProvider1.SetError(MadeIn, "Aquí!");
        }
    }
    
    #endregion
    #region "Field events"
    private void PaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void MadeIn_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void Note_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void PaymentMethod_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    private void MadeIn_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
    #endregion
    #region "Btn events"
    private async void BtnPersistence_Click(object sender, EventArgs e)
    {
        ClearMessageErr();
        _cts = new CancellationTokenSource();
        try
        {

            if (PaymentMethod.SelectedIndex == -1)
            {
                SetMessage("Seleccione un método de pago", MessageType.Warning);
                errorProvider1.SetError(PaymentMethod, "Aquí");
                BtnPersistence.Enabled = true;
                return;
            }

            if (MadeIn.SelectedIndex == -1)
            {
                SetMessage("Seleccione el medio de pago", MessageType.Warning);
                errorProvider1.SetError(MadeIn, "Aquí");
                BtnPersistence.Enabled = true;
                return;
            }

            BtnPersistence.Enabled = false;

            Income = new IncomeDto
            {
                Id = IncomeId,
                PolicyId = Policy!.Id,
                ClientId = Policy.ClientId,
                IncomeType = "Insured",
                PaymentMethod = PaymentMethod.SelectedValue!.ToString()!,
                MadeIn = MadeIn.SelectedValue!.ToString()!,
                Amount = Policy.Amount,
                Note = Note.Text,

            };
            IncomeId = await _appServices.PersistenceAsync(Income);
            Income.Id = IncomeId;


            SetMessage("Cerrar - Operación realizada con exito.!", MessageType.Success);


            // Set to 2 secons for alert
            await SetInitialMessage(2, LabelAlertMessage);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (OperationCanceledException ex)
        {
            SetMessage(ex.Message, MessageType.Warning);
            // Set to 3 secons for alert
            await SetInitialMessage(3, LabelAlertMessage);
            BtnPersistence.Enabled = true;
        }
        catch (Exception ex)
        {
            var message = DomainMessageSplit.SplitMessage(ex.Message);
            ValidationFields(message.FieldName);

            SetMessage("Cerrar - " + message.Message, MessageType.Warning);

            // Set to 3 secons for alert
            await SetInitialMessage(4, LabelAlertMessage);
            BtnPersistence.Enabled = true;
        }
        finally
        {
            if (_cts != null)
            {
                _cts.Dispose();
                _cts = null;
            }

        }
    }
    #endregion




}
