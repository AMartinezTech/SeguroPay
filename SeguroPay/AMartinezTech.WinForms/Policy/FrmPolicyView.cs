using AMartinezTech.Application.Client;
using AMartinezTech.Application.Insurance;
using AMartinezTech.Application.Policy;
using AMartinezTech.Application.Policy.Type;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.WinForms.Client;
using AMartinezTech.WinForms.Policy.Type;
using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;

namespace AMartinezTech.WinForms.Policy;

public partial class FrmPolicyView : Form
{
    #region "Fields"
    private readonly IFormFactory _formFactory;
    private CancellationTokenSource? _cts;
    private bool _isLoadingPolicy = false;
    private readonly PolicyApplicationService _policyApplicationService;
    private readonly InsuranceApplicationServices _insuranceApplicationServices;
    private readonly PolicyTypeApplicationServices _policyTypeApplicationServices;
    public Guid ClientId = Guid.Empty;
    public Guid PolicyId = Guid.Empty;
    public PolicyDto? Policy { get; private set; }
    #endregion
    public FrmPolicyView(PolicyApplicationService policyApplicationService, InsuranceApplicationServices insuranceApplicationServices, PolicyTypeApplicationServices policyTypeApplicationServices, IFormFactory formFactory)
    {
        InitializeComponent();
        SetColorUI();
        _policyApplicationService = policyApplicationService;
        _insuranceApplicationServices = insuranceApplicationServices;
        _policyTypeApplicationServices = policyTypeApplicationServices;
        _formFactory = formFactory;
    }

    private void FrmPolicyView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        FillComboBoxInsurance();
        FillComboBoxPayFrencuency();
        _isLoadingPolicy = true;
    }

    #region "Methods"
    private async void FillComboBoxInsurance()
    {
        var result = await _insuranceApplicationServices.FilterAsync();
        ComboBoxInsurance.DataSource = result;
        ComboBoxInsurance.DisplayMember = "Name";
        ComboBoxInsurance.ValueMember = "Id";
        ComboBoxInsurance.SelectedIndex = -1;
    }
    private void FillComboBoxPayFrencuency()
    {
        var statuses = Enum.GetValues<PolicyPayFrencuency>()
            .Cast<PolicyPayFrencuency>()
            .Select(e => new
            {
                Value = e,
                Text = e.GetDisplayName()
            })
            .ToList();

        ComboBoxPayFrecuency.DataSource = statuses;
        ComboBoxPayFrecuency.DisplayMember = "Text";
        ComboBoxPayFrecuency.ValueMember = "Value";
    }
    private async void FillComoBoxPolicyType()
    {
        if (!_isLoadingPolicy) return;

        bool flowControl = InsuranceValidate(out Guid insuranceId);
        if (!flowControl)
        {
            return;
        }
        var filter = new Dictionary<string, object?>
        {
            ["insurance_id"] = insuranceId
        };
        var result = await _policyTypeApplicationServices.FilterAsync(filter, null, true);
        ComboBoxPolicyTypeId.DataSource = result;
        ComboBoxPolicyTypeId.DisplayMember = "Name";
        ComboBoxPolicyTypeId.ValueMember = "Id";

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
        BtnNewPolicyType.IconColor = AppColors.Primary;
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
        if (ComboBoxInsurance.SelectedValue == null || !Guid.TryParse(ComboBoxInsurance.SelectedValue.ToString(), out insuranceId))
        {
            SetMessage("Seleccione una aseguradora", MessageType.Warning);
            ComboBoxInsurance.Focus();
            insuranceId = default;
            return false;
        }

        return true;
    }
    private void ClearFields()
    {
        TextBoxPolicyNo.Text = string.Empty;
        ComboBoxInsurance.SelectedIndex = -1;
        ComboBoxPayFrecuency.SelectedIndex = -1;
        NumericUpDownPayDay.Value = 0;
        TextBoxAmount.Text = "0.00";
        TextBoxNote.Text = string.Empty;
        ComboBoxPolicyTypeId.DataSource = null;
        BtnPersistence.Enabled = true;
        TextBoxPolicyNo.Focus();
    }
    private void ValidationFields(string fieldName)
    {
        if (fieldName.Contains("PolicyNo"))
        {
            TextBoxPolicyNo.Focus();
            errorProvider1.SetError(TextBoxPolicyNo, "Aquí!");
        }
        else if (fieldName.Contains("Insurance"))
        {
            ComboBoxInsurance.Focus();
            errorProvider1.SetError(ComboBoxInsurance, "Aquí!");
        }
        else if (fieldName.Contains("PolicyType"))
        {
            ComboBoxPolicyTypeId.Focus();
            errorProvider1.SetError(ComboBoxPolicyTypeId, "Aquí!");
        }
        else if (fieldName.Contains("Client"))
        {
            TextBoxClient.Focus();
            errorProvider1.SetError(TextBoxClient, "Aquí");
        }
        else if (fieldName.Contains("PayDay"))
        {
            NumericUpDownPayDay.Focus();
            errorProvider1.SetError(NumericUpDownPayDay, "Aquí");
        }
        else if (fieldName.Contains("Amount"))
        {
            TextBoxAmount.Focus();
            errorProvider1.SetError(TextBoxAmount, "Aquí");
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
        FillComoBoxPolicyType();
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

    private void TextBoxAmount_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void ComboBoxPolicyTypeId_KeyPress(object sender, KeyPressEventArgs e)
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

            bool flowControl = InsuranceValidate(out Guid insuranceId);
            if (!flowControl)
            {
                return;
            }

            if (ComboBoxPolicyTypeId.SelectedValue == null || !Guid.TryParse(ComboBoxPolicyTypeId.SelectedValue.ToString(), out Guid policyTypeId))
            {
                SetMessage("Seleccione el tipo de poliza", MessageType.Warning);
                ComboBoxPolicyTypeId.Focus();
                return;
            }

            Policy = new PolicyDto
            {
                Id = PolicyId,
                PolicyNo = TextBoxPolicyNo.Text.Trim(),
                InsuranceId = insuranceId,
                PolicyTypeId = policyTypeId,
                ClientId = ClientId,
                PayFrencuency = ComboBoxPayFrecuency.Text.Trim(),
                PayDay = int.Parse(NumericUpDownPayDay.Value.ToString()),
                Amount = decimal.Parse(TextBoxAmount.Text),
                Note = TextBoxNote.Text.Trim(),

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
    private void BtnNewPolicyType_Click(object sender, EventArgs e)
    {

        bool flowControl = InsuranceValidate(out Guid insuranceId);
        if (!flowControl)
        {
            return;
        }

        var frmPolicyTypeView = _formFactory.CreateFormFactory<FrmPolicyTypeView>();
        frmPolicyTypeView.InsuranceId = insuranceId;
        frmPolicyTypeView.LabelInsuranceName.Text = ComboBoxInsurance.Text;
        this.Hide();
        frmPolicyTypeView.ShowDialog();
        FillComoBoxPolicyType();
        this.Show();
    }
    private void BtnSelectClient_Click(object sender, EventArgs e)
    {
        using var frmSelectClientView = _formFactory.CreateFormFactory<FrmSelectClientView>();
        if (frmSelectClientView.ShowDialog() == DialogResult.OK)
        {
            var client = frmSelectClientView.SelectedClient;
            if (client != null)
            {
                ClientId = client.Id;
                TextBoxClient.Text = $"{client.FirstName} {client.LastName}{Environment.NewLine}{client.DocIdentity}{Environment.NewLine}{client.Phone}";
            }
        }
    }
    #endregion
}
