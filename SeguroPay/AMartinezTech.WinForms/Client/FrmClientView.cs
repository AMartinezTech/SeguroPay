using AMartinezTech.Application.Client; 
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.WinForms.Utils;

namespace AMartinezTech.WinForms.Client;

public partial class FrmClientView : Form
{
    #region "Fields"
    private CancellationTokenSource? _cts;
    private readonly ClientController _clientController;
    private Guid ClientId { get; set; } = Guid.Empty;
  
    #endregion
    #region "Constructor"
    public FrmClientView(ClientController clientController)
    {
        InitializeComponent();
        _clientController = clientController;
        SetColorUI();
    }
    #endregion
    #region "Form Events"
    private void FrmClientView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        FillComboBox();
        FillComboBoxCity();
    }
    #endregion
    #region "Methods"
    private async void FillComboBoxCity()
    {
        var cities = await _clientController.CityPaginationAsync();

        if (cities == null || cities.TotalRecords == 0)
        {
            ComboBoxCity.DataSource = null;
            ComboBoxCity.Items.Clear();
            return;
        }

        ComboBoxCity.DataSource = cities.Data;
        ComboBoxCity.DisplayMember = "name";  
        ComboBoxCity.ValueMember = "id";     
    }

    private void ClearFields()
    {
        ClientId = Guid.Empty;
        ComboBoxDocIdentityType.SelectedIndex = 0;
        TextBoxDocIdentity.Text = string.Empty;
        ComboBoxClientType.SelectedIndex = 0;
        TextBoxFirstName.Text = string.Empty;
        TextBoxLastName.Text = string.Empty;
        TextBoxPhone.Text = string.Empty;
        TextBoxEmail.Text = string.Empty;
        ComboBoxCity.SelectedIndex = 0;
        ComboBoxStreet.SelectedIndex = 0;
        TextBoxLocationNo.Text = string.Empty;
        TextBoxAddressRef.Text = string.Empty;
        TextBoxContactName.Text = string.Empty;
        TextBoxContactPhone.Text = string.Empty;
        TextBoxObservation.Text = string.Empty;
        BtnPersistence.Enabled = true;

    }
    private void ValidationFields(string fieldName)
    {

        if (fieldName.Contains("FirstName"))
        {
            TextBoxFirstName.Focus();
            errorProvider1.SetError(TextBoxFirstName, "Aquí!");
        }
        else if (fieldName.Contains("LastName"))
        {
            TextBoxLastName.Focus();
            errorProvider1.SetError(TextBoxLastName, "Aquí!");
        }
        else if (fieldName.Contains("Email"))
        {
            TextBoxEmail.Focus();
            errorProvider1.SetError(TextBoxEmail, "Aquí!");
        }
        else if (fieldName.Contains("Phone"))
        {
            TextBoxPhone.Focus();
            errorProvider1.SetError(TextBoxPhone, "Aquí");
        }
        else if (fieldName.Contains("City"))
        {
            ComboBoxCity.Focus();
            errorProvider1.SetError(ComboBoxCity, "Aquí");
        }

        else if (fieldName.Contains("DocIdentityType"))
        {
            ComboBoxDocIdentityType.Focus();
            errorProvider1.SetError(ComboBoxDocIdentityType, "Aquí");
        }
        else if (fieldName.Contains("ClientType"))
        {
            ComboBoxClientType.Focus();
            errorProvider1.SetError(ComboBoxClientType, "Aquí");
        }

    }
    private async void InvokeGetByIdAsync(Guid clientId)
    {
        var data = await _clientController.GetByIdAsync(clientId);

        ClientId = data.Id;
        ComboBoxDocIdentityType.Text = data.DocIdentityType;
        TextBoxDocIdentity.Text = data.DocIdentity;
        ComboBoxClientType.Text = data.ClientType;
        TextBoxFirstName.Text = data.FirstName;
        TextBoxLastName.Text = data.LastName;
        TextBoxPhone.Text = data.Phone;
        TextBoxEmail.Text = data.Email;
        ComboBoxCity.SelectedValue = data.CityId;
        ComboBoxStreet.SelectedValue = data.StreetId;
        TextBoxLocationNo.Text = data.LocationNo;
        TextBoxAddressRef.Text = data.AddressRef;
        TextBoxContactName.Text = data.ContactName;
        TextBoxContactPhone.Text = data.ContactPhone;
        TextBoxObservation.Text = data.Observation;
        CheckBoxIsActived.Checked = data.IsActived;
    }
    private void FillComboBox()
    {
        ComboBoxDocIdentityType.DataSource = Enum.GetValues<DocIdentityType>();
        ComboBoxClientType.DataSource = Enum.GetValues<ClientType>();

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
    #endregion
    #region "Fields Events"
    private void ComboBoxDocIdentityType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxDocIdentity_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void ComboBoxClientType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxFirtName_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxLastName_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxPhone_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxEmail_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void ComboBoxCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void ComboBoxStreet_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }
    private void ComboBoxDocIdentityType_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    private void ComboBoxClientType_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    private void ComboBoxCity_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

    private void ComboBoxStreet_KeyPress(object sender, KeyPressEventArgs e)
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
            if (ComboBoxCity.SelectedValue == null )
            {
                SetMessage("Cerrar - " + "Debe seleccionar una ciudad ", MessageType.Warning);
                errorProvider1.SetError(ComboBoxCity, "Aquí");
                // Set to 3 secons for alert
                await SetInitialMessage(4, LabelAlertMessage);
                BtnPersistence.Enabled = true;
               
                return;
            }
            if (   ComboBoxStreet.SelectedValue == null)
            {
                SetMessage("Cerrar - " + "Debe seleccionar una calle antes de continuar.", MessageType.Warning);
                errorProvider1.SetError(ComboBoxStreet, "Aquí");
                // Set to 3 secons for alert
                await SetInitialMessage(4, LabelAlertMessage);
                BtnPersistence.Enabled = true;

                return;
            }

            var newClient = new ClientDto
            {
                Id = ClientId,
                DocIdentityType = ComboBoxDocIdentityType.Text,
                DocIdentity = TextBoxDocIdentity.Text.Trim(),
                ClientType = ComboBoxClientType.Text,
                FirstName = TextBoxFirstName.Text,
                LastName = TextBoxLastName.Text, 
                Email = TextBoxEmail.Text.Trim(),
                Phone = TextBoxPhone.Text.Trim(),
                CityId = Guid.Parse(ComboBoxCity.SelectedValue!.ToString()!),
                StreetId = Guid.Parse(ComboBoxStreet.SelectedValue!.ToString()!),
                LocationNo = TextBoxLocationNo.Text.Trim(),
                AddressRef = TextBoxAddressRef.Text.Trim(),
                ContactName = TextBoxContactName.Text.Trim(),
                ContactPhone = TextBoxContactPhone.Text.Trim(),
                Observation = TextBoxObservation.Text.Trim(),
                IsActived = CheckBoxIsActived.Checked
            };
            ClientId = await _clientController.PersistenceAsync(newClient);
            newClient.Id = ClientId;

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
