using AMartinezTech.Application.Policy;
using AMartinezTech.Application.Policy.Type;
using AMartinezTech.WinForms.Utils;
using System.ComponentModel;

namespace AMartinezTech.WinForms.Policy.Type;

public partial class FrmPolicyTypeView : Form
{
    #region "Fields"
    private CancellationTokenSource? _cts;
    private Guid Id { get; set; } = Guid.Empty;
    public Guid InsuranceId = Guid.Empty;
    private readonly PolicyTypeApplicationServices _services;
    private BindingList<PolicyTypeDto> _list = [];
    private bool _isLoadingPolicy = false;

    #endregion
    #region "Constructor"
    public FrmPolicyTypeView(PolicyTypeApplicationServices service)
    {
        InitializeComponent();
        _services = service;
        SetColorUI();
    }
    #endregion

    #region "Form Events"
    private void FrmPolicyTypeView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        InvokeDataViewSetting();
        InvokeFilterAsync(true);
        _isLoadingPolicy = true;
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
    private void ValidationFields(string fieldName)
    {

        if (fieldName.Contains("Name"))
        {
            TextBoxName.Focus();
            errorProvider1.SetError(TextBoxName, "Aquí!");
        }

    }
    private void ClearFields()
    {
        ClearMessageErr();
        Id = Guid.Empty;
        TextBoxName.Text = string.Empty;
        BtnPersistence.Enabled = true;
        CheckBoxIsActive.Checked = true;
        CheckBoxIsActive.Enabled = false;
        CheckBoxFilterByIsActive.Checked = true;
        DataGridView.Refresh();
    }
    private async void InvokeGetByIdAsync()
    {
        var data = await _services.GetByIdAsync(Id);

        Id = data.Id;
        TextBoxName.Text = data.Name;
        CheckBoxIsActive.Checked = data.IsActive;
        CheckBoxIsActive.Enabled = true;

    }
    private async void InvokeFilterAsync(bool? isActive)
    {
        DataGridView.DataSource = null;

        var filter = new Dictionary<string, object?>
        {
            ["insurance_id"] = InsuranceId
        };

        var result = await _services.FilterAsync(filter, null, isActive);
        _list = new BindingList<PolicyTypeDto>(result);
        if (_list.Count > 0)
        {
            DataGridView.DataSource = _list;
        }

    }
    #endregion
    #region "Field Events"


    private void TextBoxName_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void ComboBoxInsuranceId_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void ComboBoxInsuranceId_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
    private void CheckBoxFilterByIsActive_CheckedChanged(object sender, EventArgs e)
    {
        if (!_isLoadingPolicy) return;
        InvokeFilterAsync(CheckBoxFilterByIsActive.Checked);
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
            var newDto = new PolicyTypeDto
            {
                Id = Id,
                Name = TextBoxName.Text.Trim(),
                InsuranceId = InsuranceId,
                IsActive = CheckBoxIsActive.Checked
            };
            Id = await _services.PersistenceAsync(newDto);
            newDto.Id = Id;

            UpdatingMemoryData.Excecute(newDto, _list);
            DataGridView.DataSource = _list;
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
    #endregion
    #region "DataGridView Events"

    private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Clic Only on valid cell and column

        if (DataGridView.Columns[e.ColumnIndex].Name == "editCol")
        {
            Id = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);

            InvokeGetByIdAsync();
        }
    }

    #endregion


}
