using AMartinezTech.Application.Cash.Income;
using AMartinezTech.Application.Client;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.WinForms.Client;
using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;

namespace AMartinezTech.WinForms.Cash.Income;

public partial class FrmOtherIncomeView : Form
{
    #region "Fields"
    private readonly IFormFactory _formFactory;

    private CancellationTokenSource? _cts;
    private readonly OtherIncomeAppService _otherIncomeAppService;
    private readonly ClientAppServices _clientApplicationService;

    public Guid IncomeId = Guid.Empty;
    public Guid ClientId = Guid.Empty;
    public IncomeDto? Income { get; private set; }
    #endregion
    #region "Constructor"
    public FrmOtherIncomeView(IFormFactory formFactory, OtherIncomeAppService otherIncomeAppService, ClientAppServices clientApplicationService)
    {
        InitializeComponent();
        _formFactory = formFactory;
         _otherIncomeAppService = otherIncomeAppService;
        SetColorUI();
        _clientApplicationService = clientApplicationService;
    }
    #endregion
    #region "Form events"
    private void FrmOtherIncomeView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        FillComboBoxs();
        Amount.AllowDecimalNumbers();
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
        else if (fieldName.Contains("Amount"))
        {
            Amount.Focus();
            errorProvider1.SetError(Amount, "Aquí!");
        }
    }

    #endregion
    #region "Field events"

    private void PaymentMethod_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    private void MadeIn_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
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

    private void Amount_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }
    #endregion
    #region "Btn events"


    private async void BtnPersistence_Click(object sender, EventArgs e)
    {
        ClearMessageErr();
        _cts = new CancellationTokenSource();
        try
        {
            if (string.IsNullOrEmpty(Amount.Text)) Amount.Text = "0.00";

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

                ClientId = ClientId,
                IncomeType = "Accessory",
                PaymentMethod = PaymentMethod.SelectedValue!.ToString()!,
                MadeIn = MadeIn.SelectedValue!.ToString()!,
                Amount = Decimal.Parse(Amount.Text),

            };
            IncomeId = await _otherIncomeAppService.CreateAsync(Income);
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


    private async void BtnSelectClient_Click(object sender, EventArgs e)
    {
        using var frmSelectClientView = _formFactory.CreateFormFactory<FrmSelectClientView>();
        frmSelectClientView.ClientTypes = ClientTypes.Accessory;
        if (frmSelectClientView.ShowDialog() == DialogResult.OK)
        {
            var client = frmSelectClientView.SelectedClient;
            if (client != null)
            {
                ClientId = client.Id;
                var _client = await _clientApplicationService.GetByIdAsync(client.Id);
                ClientDetail.Text = $"{_client.FirstName} {_client.LastName}{Environment.NewLine}{_client.DocIdentity}{Environment.NewLine}{_client.Phone}";
            }
        }
    }
}
