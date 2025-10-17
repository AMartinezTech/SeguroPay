using AMartinezTech.Application.Insurance;
using AMartinezTech.Application.Setting.User;
using AMartinezTech.WinForms.Insurance.Utils;
using AMartinezTech.WinForms.Settings.User;
using AMartinezTech.WinForms.Utils;
using System.ComponentModel;


namespace AMartinezTech.WinForms.Insurance;

public partial class FrmInsuranceDashboardView : Form
{
    #region "Fields"
    private Guid InsuranceId { get; set; } = Guid.Empty;
    private readonly InsuranceApplicationServices _services;
    private CancellationTokenSource? _cts;
    private BindingList<InsuranceDto> _insuranceList = [];
    #endregion
    #region "Constructor"
    public FrmInsuranceDashboardView(InsuranceApplicationServices services)
    {
        InitializeComponent();
        SetColorUI();
        _services = services;
    }
    #endregion
    #region "Form Events"
    private void FrmInsuranceDashboardView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        InvokeDataViewSetting();
        InvokeFilterAsync(true);
    }
    #endregion
    #region "Methods"
    private void InvokeDataViewSetting()
    {
        try
        {
            DataGridView.SetCustomDesign(new CustomDataGridViewParams
            {
                EditColumnView = true,
                EditColumnName = "EDITAR",
            });
            // Set custom columns
            FormatingDGColumns.Apply(DataGridView);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
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
    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;
        PanelLineTop.BackColor = AppColors.Outline;
        LabelTitle.ForeColor = AppColors.OnSurface;

        //Buttons icon color
        IconPictureBox.IconColor = AppColors.Primary;
        IconPictureBoxSearch.IconColor = AppColors.Primary;
        BtnClear.IconColor = AppColors.Primary;
        BtnPersistence.IconColor = AppColors.Primary;
        BtnPrintList.IconColor = AppColors.Primary;

    }
    private void ValidationFields(string fieldName)
    {

        if (fieldName.Contains("Name"))
        {
            TextBoxName.Focus();
            errorProvider1.SetError(TextBoxName, "Aquí!");
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

    }
    private void ClearFields()
    {
        ClearMessageErr();
        InsuranceId = Guid.Empty;
        TextBoxName.Text = string.Empty;
        TextBoxEmail.Text = string.Empty;
        TextBoxPhone.Text = string.Empty;
        TextBoxContactName.Text = string.Empty;
        TextBoxContactPhone.Text = string.Empty;
        TextBoxAddress.Text = string.Empty;
        BtnPersistence.Enabled = true;
        CheckBoxIsActive.Checked = true;
        DataGridView.Refresh();
    }
    private async void InvokeGetByIdAsync()
    {
        var data = await _services.GetByIdAsync(InsuranceId);
        InsuranceId = data.Id;
        TextBoxName.Text = data.Name;
        TextBoxEmail.Text = data.Email;
        TextBoxPhone.Text = data.Phone;
        TextBoxContactName.Text = data.ContactName;
        TextBoxContactPhone.Text = data.ContactPhone;
        TextBoxAddress.Text = data.Address;
    }
    private async void InvokeFilterAsync(bool? IsActive)
    {
        var result = await _services.FilterAsync(null, null, IsActive);
        _insuranceList = new BindingList<InsuranceDto>(result);

        if (_insuranceList.Count > 0)
        {
            DataGridView.DataSource = _insuranceList;
        }

    }
    #endregion
    #region "Field Events" 
    private void TextBoxName_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxEmail_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxPhone_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }
    private void CheckBoxIsActiveFilter_CheckedChanged(object sender, EventArgs e)
    {
        InvokeFilterAsync(CheckBoxIsActiveFilter.Checked);
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
            var newDto = new InsuranceDto
            {
                Id = InsuranceId,
                Name = TextBoxName.Text.Trim(),
                Address = TextBoxAddress.Text.Trim(),
                Email = TextBoxEmail.Text.Trim(),
                Phone = TextBoxPhone.Text.Trim(),
                ContactName = TextBoxContactName.Text.Trim(),
                ContactPhone = TextBoxContactPhone.Text.Trim(),
                IsActive = CheckBoxIsActive.Checked
            };
            InsuranceId = await _services.PersistenceAsync(newDto);
            newDto.Id = InsuranceId;

            UpdatingMemoryData.Excecute(newDto, _insuranceList);
            ClearFields();
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

    private void BtnPrintList_Click(object sender, EventArgs e)
    {

    }
    #endregion
    #region "DataGridView Events"
    private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Clic Only on valid cell and column

        if (DataGridView.Columns[e.ColumnIndex].Name == "editCol")
        {
            InsuranceId = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);
            InvokeGetByIdAsync();
        }
    }
    #endregion


}
