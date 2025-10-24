using AMartinezTech.Application.Client;
using AMartinezTech.Application.Insurance;
using AMartinezTech.Application.Policy;
using AMartinezTech.Application.Policy.DTOs;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.WinForms.Client;
using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;

namespace AMartinezTech.WinForms.Policy;

public partial class FrmPolicyView : Form
{
    #region "Fields"
    private readonly IFormFactory _formFactory;
    private CancellationTokenSource? _cts;
    private bool _isLoadingPolicy = false;
    private readonly PolicyAppService _policyApplicationService;
    private readonly InsuranceAppServices _insuranceApplicationServices;
    private readonly ClientAppServices _clientApplicationService;
    public Guid ClientId = Guid.Empty;
    public Guid PolicyId = Guid.Empty;
    public PolicyDto? Policy { get; private set; }
    public PolicyDto? PolicyCurrentData { get; private set; }
    #endregion
    public FrmPolicyView(PolicyAppService policyApplicationService, InsuranceAppServices insuranceApplicationServices, IFormFactory formFactory, ClientAppServices clientApplicationServices)
    {
        InitializeComponent();
        SetColorUI();
        _policyApplicationService = policyApplicationService;
        _insuranceApplicationServices = insuranceApplicationServices;
        _formFactory = formFactory;
        _clientApplicationService = clientApplicationServices;
    }

    private void FrmPolicyView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        FillInsurance();
        FillPolicyType();
        FillPaymentFrequency();
        FillPaymentMethod();
        Amount.AllowDecimalNumbers();
        PaymentInstallments.AllowDecimalNumbers();
        if (PolicyId != Guid.Empty)
            InvokeGetByIdAsync(PolicyId);

        _isLoadingPolicy = true;
    }

    #region "Methods"
    private async void InvokeGetByIdAsync(Guid policyId)
    {

        PolicyCurrentData = await _policyApplicationService.GetByIdAsync(policyId);

        PolicyNo.Text = PolicyCurrentData.PolicyNo;
        Insurance.SelectedValue = PolicyCurrentData.InsuranceId;

        ClientId = PolicyCurrentData.ClientId;
        var _client = await _clientApplicationService.GetByIdAsync(ClientId);
        ClientDetail.Text = $"{_client.FirstName} {_client.LastName}{Environment.NewLine}{_client.DocIdentity}{Environment.NewLine}{_client.Phone}";
        PaymentFrequency.SelectedValue = Enum.Parse<PolicyPaymentFrequencies>(PolicyCurrentData.PaymentFrequency); ;
        PaymentMethod.SelectedValue = Enum.Parse<PaymentMethods>(PolicyCurrentData.PaymentMethod);
        PolicyType.SelectedValue = Enum.Parse<PolicyTypes>(PolicyCurrentData.PolicyType);
        NumericUpDownPayDay.Value = PolicyCurrentData.PaymentDay;
        PaymentInstallments.Text = PolicyCurrentData.PaymentInstallment.ToString();
        Amount.Text = PolicyCurrentData.Amount.ToString("##,##0.00");


        if (PolicyCurrentData.Status == "Canceled")
        {
            LabelAlert.Visible = true;
            var msg = new HandlerMessages("Poliza cancelada.!", MessageType.Warning);
            LabelAlert.Text = $"{msg.Icon} {msg.Message}";
            LabelAlert.ForeColor = msg.MessageColor;

            BtnPersistence.Enabled = false;
            BtnClear.Enabled = false;
            BtnSelectClient.Enabled = false;

        }

    }
    private async void FillInsurance()
    {
        var result = await _insuranceApplicationServices.FilterAsync();
        Insurance.DataSource = result;
        Insurance.DisplayMember = "Name";
        Insurance.ValueMember = "Id";
        Insurance.SelectedIndex = -1;
    }
    private void FillPaymentFrequency()
    {
        var statuses = Enum.GetValues<PolicyPaymentFrequencies>()
            .Cast<PolicyPaymentFrequencies>()
            .Select(e => new
            {
                Value = e,
                Text = e.GetDisplayName()
            })
            .ToList();

        PaymentFrequency.DataSource = statuses;
        PaymentFrequency.DisplayMember = "Text";
        PaymentFrequency.ValueMember = "Value"; 
        PaymentFrequency.SelectedIndex = -1;
    }
    private void FillPaymentMethod()
    {
        var statuses = Enum.GetValues<PaymentMethods>()
            .Cast<PaymentMethods>()
            .Select(e => new
            {
                Value = e,
                Text = e.GetDisplayName()
            })
            .ToList();

        PaymentMethod.DataSource = statuses;
        PaymentMethod.DisplayMember = "Text";
        PaymentMethod.ValueMember = "Value";
        PaymentMethod.SelectedIndex = -1;
    }
    private void FillPolicyType()
    {
        var statuses = Enum.GetValues<PolicyTypes>()
            .Cast<PolicyTypes>()
            .Select(e => new
            {
                Value = e,
                Text = e.GetDisplayName()
            })
            .ToList();

        PolicyType.DataSource = statuses;
        PolicyType.DisplayMember = "Text";
        PolicyType.ValueMember = "Value";
        PolicyType.SelectedIndex = -1;
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
        BtnClear.IconColor = AppColors.Primary;
        BtnSelectClient.IconColor = AppColors.Primary;
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
    private bool InsuranceValidate(out Guid insuranceId)
    {
        if (Insurance.SelectedValue == null || !Guid.TryParse(Insurance.SelectedValue.ToString(), out insuranceId))
        {
            SetMessage("Seleccione una aseguradora", MessageType.Warning);
            Insurance.Focus();
            insuranceId = default;
            return false;
        }

        return true;
    }
    private void ClearFields()
    {
        PolicyNo.Text = string.Empty;
        Insurance.SelectedIndex = -1;
        PaymentFrequency.SelectedIndex = -1;
        NumericUpDownPayDay.Value = 0;
        Amount.Text = "0.00";
        Note.Text = string.Empty;
        PolicyType.DataSource = null;
        BtnPersistence.Enabled = true;
        PolicyNo.Focus();
    }
    private void ValidationFields(string fieldName)
    {
        if (fieldName.Contains("PolicyNo"))
        {
            PolicyNo.Focus();
            errorProvider1.SetError(PolicyNo, "Aquí!");
        }
        else if (fieldName.Contains("Insurance"))
        {
            Insurance.Focus();
            errorProvider1.SetError(Insurance, "Aquí!");
        }
        else if (fieldName.Contains("PolicyType"))
        {
            PolicyType.Focus();
            errorProvider1.SetError(PolicyType, "Aquí!");
        }
        else if (fieldName.Contains("Client"))
        {
            ClientDetail.Focus();
            errorProvider1.SetError(ClientDetail, "Aquí");
        }
        else if (fieldName.Contains("PayDay"))
        {
            NumericUpDownPayDay.Focus();
            errorProvider1.SetError(NumericUpDownPayDay, "Aquí");
        }
        else if (fieldName.Contains("Amount"))
        {
            Amount.Focus();
            errorProvider1.SetError(Amount, "Aquí");
        }
        else if (fieldName.Contains("PaymentFrequency"))
        {
            PaymentFrequency.Focus();
            errorProvider1.SetError(PaymentFrequency, "Aquí");
        }
        else if (fieldName.Contains("PaymentInstallments"))
        {
            PaymentInstallments.Focus();
            errorProvider1.SetError(PaymentInstallments, "Aquí");
        }
    }
    #endregion

    #region "Field Events"
    private void ComboBoxInsurance_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    private void TextBoxPolicyNo_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void ComboBoxInsurance_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void ComboBoxPolicyTypeId_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxClient_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void ComboBoxPayFrecuency_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void NumericUpDownPayDay_ValueChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }
    private void NumericUpDownPayDay_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
    private void TextBoxAmount_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void ComboBoxPolicyTypeId_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
    private void PaymentMethod_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
    private void ComboBoxPayFrecuency_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
    #endregion
    #region "Btn Events"
    private void BtnClear_Click(object sender, EventArgs e)
    {
        ClearFields();
    }
    private async void BtnPersistence_Click(object sender, EventArgs e)
    {
        ClearMessageErr();
        _cts = new CancellationTokenSource();
        try
        {
            BtnPersistence.Enabled = false;
            if (PaymentInstallments.Text == string.Empty) PaymentInstallments.Text = "0";
            
            bool flowControl = InsuranceValidate(out Guid insuranceId);
            if (!flowControl)
            {
                return;
            }


            Policy = new PolicyDto
            {
                Id = PolicyId,
                PolicyNo = PolicyNo.Text.Trim(),
                InsuranceId = insuranceId,
                PolicyType = PolicyType.SelectedValue!.ToString()!,
                ClientId = ClientId,
                PaymentFrequency = PaymentFrequency.SelectedValue!.ToString()!,
                PaymentMethod = PaymentMethod.SelectedValue!.ToString()!,
                PaymentDay = int.Parse(NumericUpDownPayDay.Value.ToString()),
                PaymentInstallment = int.Parse(PaymentInstallments.Text.Trim()),
                Amount = decimal.Parse(Amount.Text),
                Note = Note.Text.Trim(),

            };
            PolicyId = await _policyApplicationService.PersistenceAsync(Policy);
            Policy.Id = PolicyId;


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

    private async void BtnSelectClient_Click(object sender, EventArgs e)
    {
        using var frmSelectClientView = _formFactory.CreateFormFactory<FrmSelectClientView>();
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
    #endregion



    
}
