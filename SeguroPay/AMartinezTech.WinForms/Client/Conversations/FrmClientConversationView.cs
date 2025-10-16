using AMartinezTech.Application.Client.Conversation; 
using AMartinezTech.Application.Setting.User.Interfaces;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.WinForms.Client.Conversations.Utils; 
using AMartinezTech.WinForms.Utils;
using System.ComponentModel; 

namespace AMartinezTech.WinForms.Client.Conversations;

public partial class FrmClientConversationView : Form
{
    #region "Fields"
    private CancellationTokenSource? _cts;
    public Guid Id = Guid.Empty;
    public Guid ClientId = Guid.Empty;
    private readonly ClientConversationApplicationService _clientConversationApplicationService;
    private BindingList<ClientConversationDto> _clientConversationList = [];
    private readonly ICurrectUser _currentUser; 
    #endregion
    #region "Constructor" 
    public FrmClientConversationView(ClientConversationApplicationService clientConversationApplicationService, ICurrectUser currentUser)
    {
        InitializeComponent();
        _clientConversationApplicationService = clientConversationApplicationService;
        _currentUser = currentUser; 
        SetColorUI();
    }
    #endregion
    #region "Form Events"
    private void FrmClientConversationView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        InvokeDataViewSetting();
        FillChannelComboBox();
        InvokeFilterAsync();
        DataGridView.EnableDoubleBuffering();
    }
    #endregion
    #region "Methods"
    private void ValidationFields(string fieldName)
    {

        if (fieldName.Contains("Subjec"))
        {
            TextBoxSubject.Focus();
            errorProvider1.SetError(TextBoxSubject, "Aquí!");
        }

        else if (fieldName.Contains("Message"))
        {
            TextBoxMessage.Focus();
            errorProvider1.SetError(TextBoxMessage, "Aquí!");
        }
        else if (fieldName.Contains("ContactNumber"))
        {
            TextBoxContactNumber.Focus();
            errorProvider1.SetError(TextBoxContactNumber, "Aquí");
        }

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
        LabelClientFullName.ForeColor = AppColors.Primary;
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
    private void ClearFields()
    {
        TextBoxContactNumber.Text = string.Empty;
        TextBoxSubject.Text = string.Empty;
        TextBoxMessage.Text = string.Empty;
        LabelAsistenceBy.Text = "Asistido por : ";
        BtnPersistence.Enabled = true;
    }
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
    private void FillChannelComboBox()
    {
        ComboBoxChannel.DataSource = Enum.GetValues<ChannelConvertationType>();
    }
    private async void InvokeFilterAsync()
    {
        var filter = new Dictionary<string, object?>
        {
            ["client_id"] = ClientId,
        };
        var result = await _clientConversationApplicationService.FilterAsync(filter: filter);
        _clientConversationList = new BindingList<ClientConversationDto>(result);
        DataGridView.DataSource = result;
    }
    #endregion
    #region "Field Events"
    private void TextBoxContactPhone_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxSubject_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void ComboBoxChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }
    private void ComboBoxChannel_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
    private void TextBoxMessage_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
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

            var clientConversation = new ClientConversationDto
            {
                Id = Id,
                ClientId = ClientId,
                ContactNumber = TextBoxContactNumber.Text.Trim(),
                Subject = TextBoxSubject.Text.Trim(),
                Message = TextBoxMessage.Text.Trim(),
                Channel = ComboBoxChannel.Text.Trim(),
                CreatedBy = _currentUser.User!.Id
            };
            Id = await _clientConversationApplicationService.PersistenceAsync(clientConversation);
            clientConversation.Id = Id;


            UpdatingMemoryData.Excecute(clientConversation, _clientConversationList);
            ClearFields();

            SetMessage("Cerrar - Registro guardado con exito.!", MessageType.Success);
            await SetInitialMessage(2, LabelAlertMessage);


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
    #region "DataGridView Evenst"
    

    private async void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Clic Only on valid cell and column

        if (DataGridView.Columns[e.ColumnIndex].Name == "editCol")
        {
            Id = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);
            var result = await _clientConversationApplicationService.GetByIdAsync(Id);
            TextBoxContactNumber.Text = result.ContactNumber;
            TextBoxSubject.Text = result.Subject;
            TextBoxMessage.Text = result.Message;
            ComboBoxChannel.Text = result.Channel;
            LabelAsistenceBy.Text += result.CreatedByName;
        }
    }
    #endregion
}
