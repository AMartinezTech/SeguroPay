using AMartinezTech.Application.Location.Street;
using AMartinezTech.WinForms.Location.Controllers;
using AMartinezTech.WinForms.Location.Utils;
using AMartinezTech.WinForms.Utils;
using System.ComponentModel;

namespace AMartinezTech.WinForms.Location.Views;

public partial class FrmStreetView : Form
{
    #region "Fields"
    private CancellationTokenSource? _cts;
    private Guid StreetId { get; set; } = Guid.Empty;
    //private Guid CityId { get; set; } = Guid.Empty;
    private readonly StreetController _streetController;
    private BindingList<StreetDto> _streetList = [];
    public Guid CityId = Guid.Empty;
    #endregion
    #region "Constructor"
    public FrmStreetView(StreetController streetController)
    {
        InitializeComponent();
        _streetController = streetController;
        SetColorUI();
    }
    #endregion
    #region "Form Events"
    private void FrmStreetView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        InvokeDataViewSetting();
        InvokeFilterAsync();
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
            StreetFormatingDGColumns.Apply(DataGridView);
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

        if (fieldName.Contains("StreetName"))
        {
            TextBoxName.Focus();
            errorProvider1.SetError(TextBoxName, "Aquí!");
        }
        else if (fieldName.Contains("City"))
        {
            errorProvider1.SetError(LabelCityName, "Aquí!");
        }


    }
    private void ClearFields()
    {
        ClearMessageErr();
        StreetId = Guid.Empty;
        TextBoxName.Text = string.Empty;

        BtnPersistence.Enabled = true;
        DataGridView.Refresh();
    }
    private async void InvokeGetByIdAsync()
    {
        var data = await _streetController.GetByIdAsync(StreetId);

        StreetId = data.Id;
        TextBoxName.Text = data.Name;

    }
    private async void InvokeFilterAsync()
    {
        var filters = new Dictionary<string, object?>
        {
            ["city_id"] = CityId,

        };

        var search = new Dictionary<string, object?>
        {
            ["street"] = TextBoxSearch.Text.Trim()
        };
        _streetList = await _streetController.FilterAsync(filters, search);
        if (_streetList.Count > 0)
        {
            DataGridView.DataSource = _streetList;
        }

    }

    #endregion
    #region "Field Events"
    private void TextBoxName_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }
    #endregion

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
            var newDto = new StreetDto
            {
                Id = StreetId,
                Name = TextBoxName.Text.Trim(),
                CityId = CityId,
            };
            StreetId = await _streetController.PersistenceAsync(newDto);
            newDto.Id = StreetId;

            StreetUpdatingMemoryData.Excecute(newDto, _streetList);
            DataGridView.DataSource = _streetList; 
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
        StreetId = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);

        if (DataGridView.Columns[e.ColumnIndex].Name == "editCol")
        {
            InvokeGetByIdAsync();
        }
    }
}
