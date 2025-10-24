using AMartinezTech.Application.Client;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.WinForms.Location.Controllers;
using AMartinezTech.WinForms.Location.Views;
using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;

namespace AMartinezTech.WinForms.Client;

public partial class FrmClientView : Form
{
    #region "Fields"
    private readonly IFormFactory _formFactory;
    private CancellationTokenSource? _cts;
    private readonly ClientController _clientController;
    private readonly StreetController _streetController;
    public Guid ClientId = Guid.Empty;
    private bool _isLoadingClient = false;
    public ClientDto? Client { get; private set; }
    #endregion
    #region "Constructor"
    public FrmClientView(ClientController clientController, IFormFactory formFactory, StreetController streetController)
    {
        InitializeComponent();
        _clientController = clientController;
        _formFactory = formFactory;
        _streetController = streetController;
        SetColorUI();
    }
    #endregion
    #region "Form Events"
    private void FrmClientView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        FillComboBox();
        FillComboBoxCity();

        if (ClientId != Guid.Empty)
            InvokeGetByIdAsync(ClientId);
         
    }
    #endregion
    #region "Methods"
    private async void FillComboBoxStreetAsync(Guid cityId)
    {
        var filters = new Dictionary<string, object?>
        {
            ["city_id"] = cityId, 
        }; 
        var streetList = await _streetController.FilterAsync(filters, null);
        if (streetList.Count > 0)
        {
            ComboBoxStreet.DataSource = streetList;
            ComboBoxStreet.DisplayMember = "name";
            ComboBoxStreet.ValueMember = "id";
        }
    }
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
        else if (fieldName.Contains("Street"))
        {
            ComboBoxStreet.Focus();
            errorProvider1.SetError(ComboBoxStreet, "Aquí");
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
        _isLoadingClient = true;
        var data = await _clientController.GetByIdAsync(clientId);

        // 1️⃣ Asigna primero la ciudad
        ComboBoxCity.SelectedValue = data.CityId;

        // 2️⃣ Carga las calles correspondientes (esperando el método async)
        FillComboBoxStreetAsync(data.CityId);

        // 3️⃣ Luego asigna la calle
        ComboBoxStreet.SelectedValue = data.StreetId;

        // 4️⃣ Asigna los demás campos
        ClientId = data.Id;
        ComboBoxDocIdentityType.Text = data.DocIdentityType;
        TextBoxDocIdentity.Text = data.DocIdentity;
        ComboBoxClientType.Text = data.ClientType;
        TextBoxFirstName.Text = data.FirstName;
        TextBoxLastName.Text = data.LastName;
        TextBoxPhone.Text = data.Phone;
        TextBoxEmail.Text = data.Email;
        TextBoxLocationNo.Text = data.LocationNo;
        TextBoxAddressRef.Text = data.AddressRef;
        TextBoxContactName.Text = data.ContactName;
        TextBoxContactPhone.Text = data.ContactPhone;
        TextBoxObservation.Text = data.Observation;
        CheckBoxIsActive.Checked = data.IsActive;

        _isLoadingClient = false;
    }
    private void FillComboBox()
    {

        var docIdentityType = Enum.GetValues<DocIdentityTypes>()
            .Cast<DocIdentityTypes>()
            .Select(e => new
            {
                Value = e,
                Text = e.GetDisplayName()
            })
            .ToList();

        ComboBoxDocIdentityType.DataSource = docIdentityType;
        ComboBoxDocIdentityType.DisplayMember = "Text";
        ComboBoxDocIdentityType.ValueMember = "Value";

        var clientType = Enum.GetValues<ClientTypes>()
            .Cast<ClientTypes>()
            .Select(e => new
            {
                Value = e,
                Text = e.GetDisplayName()
            })
            .ToList();

        ComboBoxClientType.DataSource = clientType;
        ComboBoxClientType.DisplayMember = "Text";
        ComboBoxClientType.ValueMember = "Value";

 

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
        BtnStreet.IconColor = AppColors.Primary;

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
        if (_isLoadingClient) return; // Evita ejecución mientras cargas datos del cliente

        if (ComboBoxCity.SelectedValue == null || ComboBoxCity.SelectedValue == DBNull.Value)
            return;

        // Convertir el valor a Guid
        if (Guid.TryParse(ComboBoxCity.SelectedValue.ToString(), out Guid cityId))
        {
            FillComboBoxStreetAsync(cityId);
        }
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

            Client = new ClientDto
            {
                Id = ClientId,
                DocIdentityType = ComboBoxDocIdentityType.SelectedValue!.ToString()!,
                DocIdentity = TextBoxDocIdentity.Text.Trim(),
                ClientType = ComboBoxClientType.SelectedValue!.ToString()!,
                FirstName = TextBoxFirstName.Text,
                LastName = TextBoxLastName.Text,
                Email = TextBoxEmail.Text.Trim(),
                Phone = TextBoxPhone.Text.Trim(),
                CityId = ComboBoxCity.SelectedValue == null ? Guid.Empty : Guid.Parse(ComboBoxCity.SelectedValue!.ToString()!),
                StreetId = ComboBoxStreet.SelectedValue == null ? Guid.Empty : Guid.Parse(ComboBoxStreet.SelectedValue.ToString()!),
                LocationNo = TextBoxLocationNo.Text.Trim(),
                AddressRef = TextBoxAddressRef.Text.Trim(),
                ContactName = TextBoxContactName.Text.Trim(),
                ContactPhone = TextBoxContactPhone.Text.Trim(),
                Observation = TextBoxObservation.Text.Trim(),
                IsActive = CheckBoxIsActive.Checked
            };
            ClientId = await _clientController.PersistenceAsync(Client);
            Client.Id = ClientId;


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
    private async void BtnStreet_Click(object sender, EventArgs e)
    {
        if (ComboBoxCity.SelectedValue == null)
        {
            SetMessage("Cerrar - " + "Debe seleccionar una ciudad ", MessageType.Warning);
            errorProvider1.SetError(ComboBoxCity, "Aquí");
            // Set to 3 secons for alert
            await SetInitialMessage(4, LabelAlertMessage);
            BtnPersistence.Enabled = true;

            return;
        }
        var frmStreetView = _formFactory.CreateFormFactory<FrmStreetView>();
        frmStreetView.CityId = Guid.Parse(ComboBoxCity.SelectedValue!.ToString()!);
        frmStreetView.LabelCityName.Text = $"Ciudad: {ComboBoxCity.Text}";
        frmStreetView.ShowDialog();
        // Convertir el valor a Guid
        if (Guid.TryParse(ComboBoxCity.SelectedValue.ToString(), out Guid cityId))
        {
            FillComboBoxStreetAsync(cityId);
        }
    }

    #endregion
}
