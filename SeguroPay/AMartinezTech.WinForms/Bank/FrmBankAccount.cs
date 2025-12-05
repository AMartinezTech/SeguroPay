using AMartinezTech.Application.Bank;
using AMartinezTech.Application.Setting.User;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.WinForms.Bank.Utils;
using AMartinezTech.WinForms.Settings.User;
using AMartinezTech.WinForms.Utils;
using System.ComponentModel; 

namespace AMartinezTech.WinForms.Bank;

public partial class FrmBankAccount : Form
{
    private CancellationTokenSource? _cts;
    private readonly BankAccountAppService _bankAccountAppService;
    private BindingList<BankAccountDto> _bankAccountsList = [];
    private Guid _bankAccountId = Guid.Empty;
    public FrmBankAccount(BankAccountAppService bankAccountAppService)
    {
        InitializeComponent();
        _bankAccountAppService = bankAccountAppService;
        SetColorUI();
    }

    private void FrmBankAccount_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        InvokeDataViewSetting();
        InvokeFilterAsync(true);
        FillComboBox();
    }

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
    private void FillComboBox()
    {

        var bankAccountTypes = Enum.GetValues<BankAccountTypes>()
            .Cast<BankAccountTypes>()
            .Select(e => new
            {
                Value = e,
                Text = e.GetDisplayName()
            })
            .ToList();

        ComboBoxType.DataSource = bankAccountTypes;
        ComboBoxType.DisplayMember = "Text";
        ComboBoxType.ValueMember = "Value";

        


    }
    private void ValidationFields(string fieldName)
    {

        if (fieldName.Contains("Name"))
        {
            TextBoxName.Focus();
            errorProvider1.SetError(TextBoxName, "Aquí!");
        }

        else if (fieldName.Contains("Number"))
        {
            TextBoxNumber.Focus();
            errorProvider1.SetError(TextBoxNumber, "Aquí!");
        }
        else if (fieldName.Contains("type"))
        {
            ComboBoxType.Focus();
            errorProvider1.SetError(ComboBoxType, "Aquí");
        }

    }
    private void ClearFields()
    {
        ClearMessageErr();
        _bankAccountId = Guid.Empty;
        TextBoxName.Text = string.Empty;
        TextBoxNumber.Text = string.Empty;
        TextBoxContactName.Text = string.Empty;
        TextBoxContactPhone.Text = string.Empty;

        BtnPersistence.Enabled = true;
        CheckBoxIsActive.Checked = false;
        DataGridView.Refresh();
    }
    private async void InvokeGetByIdAsync()
    {
        var data = await _bankAccountAppService.GetByIdAsync(_bankAccountId);

        _bankAccountId = data.Id;
        TextBoxName.Text = data.Name;
        TextBoxNumber.Text = data.Number;
        TextBoxContactName.Text = data.ContactName;
        TextBoxContactPhone.Text = data.ContactPhone;

        CheckBoxIsActive.Checked = data.IsActive;
    }
    private async void InvokeFilterAsync(bool? IsActive)
    {
        var filter = new Dictionary<string, object?>
        {
            ["is_active"] = IsActive
        };
        var result = await _bankAccountAppService.FilterAsync(filter);
        _bankAccountsList = new BindingList<BankAccountDto>(result);
        if (_bankAccountsList.Count > 0)
        {
            DataGridView.DataSource = _bankAccountsList;
        }

    }

    #endregion

    private void TextBoxName_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxNumber_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxContactName_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxContactPhone_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void ComboBoxType_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }

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
            var newDto = new BankAccountDto
            {
                Id = _bankAccountId,
                Name = TextBoxName.Text.Trim(),
                Number = TextBoxNumber.Text.Trim(),
                Type = ComboBoxType.SelectedValue.ToString(),
                ContactName = TextBoxContactName.Text.Trim(),
                ContactPhone = TextBoxContactPhone.Text.Trim(),
                IsActive = CheckBoxIsActive.Checked
            };
            _bankAccountId = await _bankAccountAppService.PersistenceAsync(newDto);
            newDto.Id = _bankAccountId;

            UpdatingMemoryData.Excecute(newDto, _bankAccountsList);
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

    private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Clic Only on valid cell and column

        if (DataGridView.Columns[e.ColumnIndex].Name == "editCol")
        {
            _bankAccountId = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);

            InvokeGetByIdAsync();
        }
    }
}
