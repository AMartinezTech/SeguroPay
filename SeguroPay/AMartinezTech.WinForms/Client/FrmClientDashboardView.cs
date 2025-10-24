using AMartinezTech.Application.Reports.Clients.Interfaces;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.WinForms.Client.Conversations;
using AMartinezTech.WinForms.Client.Utils;
using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;
using System.ComponentModel; 


namespace AMartinezTech.WinForms.Client;

public partial class FrmClientDashboardView : Form
{
    #region "Fields"
    private readonly ClientController _controller;
    private BindingList<ClientViewModel> _clientList = [];
    private readonly IFormFactory _formFactory;
    private readonly IClientReportService _clientReportService;
    private bool _isChangeValueControl = false;
    #endregion
    #region "Constructor"
    public FrmClientDashboardView(IFormFactory formFactory, ClientController clientController, IClientReportService clientReportService)
    {
        InitializeComponent();
        _formFactory = formFactory;
        _controller = clientController;
        _clientReportService = clientReportService;
        SetColorUI();
    }
    #endregion
    #region "Form Events"
    private void FrmClientDashboardView_Load(object sender, EventArgs e)
    {
        FillComboBox();
        InvokeDataViewSetting();
        InvokeFilterAsync();
        DataGridView.EnableDoubleBuffering();
        LoadClientTypeChart();

    }
    #endregion
    #region "Methods"
    private async void LoadClientTypeChart()
    {
        var summaries = await _clientReportService.TypeSummaryAsync();
        int yOffset = 10; // posición inicial
        int cardWidth = 300;
        int cardHeight = 80; // ajusta según necesidad
        int spacing = 10; // espacio entre cards
        int totalClients = 0;
        foreach (var summary in summaries)
        {
            totalClients += summary.ActiveCount + summary.InactiveCount;
            // Crear la tarjeta (Panel)
            Panel card = new()
            {
                Width = cardWidth,
                Height = cardHeight,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(10, yOffset)
            };

            // Label para tipo de cliente
            Label lblType = new()
            {
                Text = $"Tipo: {summary.ClientType}",
                Location = new Point(10, 10),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            card.Controls.Add(lblType);

            // Label para activos
            Label lblActive = new()
            {
                Text = $"Activos: {summary.ActiveCount}",
                Location = new Point(10, 35),
                AutoSize = true
            };
            card.Controls.Add(lblActive);

            // Label para inactivos
            Label lblInactive = new()
            {
                Text = $"Inactivos: {summary.InactiveCount}",
                Location = new Point(150, 35),
                AutoSize = true
            };
            card.Controls.Add(lblInactive);

            // Agregar la card al contenedor
            PanelLeyenda.Controls.Add(card);

            // Actualizar el offset para la siguiente card
            yOffset += cardHeight + spacing;
        }
        LabelTotalClients.Text = $"Total General: {totalClients}";


    }
    private void FillComboBox()
    {

        var statuses = Enum.GetValues<ClientTypes>()
          .Cast<ClientTypes>()
          .Select(e => new
          {
              Value = e,
              Text = e.GetDisplayName()
          })
          .ToList();

        ComboBoxClientType.DataSource = statuses;
        ComboBoxClientType.DisplayMember = "Text";
        ComboBoxClientType.ValueMember = "Value"; 
    }
    private void InvokeDataViewSetting()
    {
        try
        {
            DataGridView.SetCustomDesign(new CustomDataGridViewParams
            {
                EditColumnView = true,
                EditColumnName = "EDITAR",
                PhoneColumnView = true,
                PhoneColumnName = "LLAMADA",
            });
            // Set custom columns
            FormatingDGColumns.Apply(DataGridView);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private async void InvokeFilterAsync()
    {
        try
        {
             
            // Detiene el repintado del DataGridView temporalmente
            DataGridView.SuspendLayout();
            DataGridView.DataSource = null;

            var filters = new Dictionary<string, object?>
            {
                ["client_type"] = string.IsNullOrWhiteSpace(ComboBoxClientType.SelectedValue!.ToString()) ? null : ComboBoxClientType.SelectedValue!.ToString()

            };

            var globalSearch = new Dictionary<string, object?>
            {
                ["first_name"] = TextBoxSearch.Text.Trim(),
                ["last_name"] = TextBoxSearch.Text.Trim(),
                ["doc_identity"] = TextBoxSearch.Text.Trim()
            };


            // Ejecuta el filtro en un hilo separado para no bloquear la UI
            var result = await Task.Run(() => _controller.FilterAsync(filters, globalSearch));

            // Reactiva el repintado y asigna el resultado
            DataGridView.DataSource = result;
            _clientList = result;

        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al filtrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            // Reanuda el pintado del DataGridView
            DataGridView.ResumeLayout();
        }
    }
    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;
        PanelLineTop.BackColor = AppColors.Outline;
        LabelTitle.ForeColor = AppColors.OnSurface;

        //Buttons icon color
        IconPictureBoxSearch.IconColor = AppColors.Primary;
        IconPictureBox.IconColor = AppColors.Primary;
        BtnClient.IconColor = AppColors.Primary;
        BtnPrintList.IconColor = AppColors.Primary;
    }

    private void OpenFrmClient(Guid clientId)
    {
        var frmClientView = _formFactory.CreateFormFactory<FrmClientView>();
        frmClientView.ClientId = clientId;
        if (frmClientView.ShowDialog() == DialogResult.OK)
        {
            var newClient = frmClientView.Client;

            if (newClient != null)
            {
                UpdatingMemoryData.Excecute(ClientViewModel.ToModel(newClient), _clientList);
                DataGridView.Refresh();
            }
            LoadClientTypeChart();
        }
    }
    private void OpemFrmClientConversation(Guid clientId, string clientName)
    {
        var frmClientConversationView = _formFactory.CreateFormFactory<FrmClientConversationView>();
        frmClientConversationView.ClientId = clientId;

        frmClientConversationView.LabelClientFullName.Text = clientName;
        frmClientConversationView.ShowDialog();
    }
    #endregion
    #region "Btn Events"
    private void BtnNuevo_Click(object sender, EventArgs e)
    {
        OpenFrmClient(Guid.Empty);
    }
    #endregion
    #region "Field Events"
    private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
            InvokeFilterAsync();

    }
    private void TextBoxSearch_Enter(object sender, EventArgs e)
    {
        if (_isChangeValueControl)
        {
            _isChangeValueControl = false;
            InvokeFilterAsync();
        }
    }
    private void CheckBoxIsActive_CheckedChanged(object sender, EventArgs e)
    {
        _isChangeValueControl = true;
        TextBoxSearch.Focus();
    }
    private void ComboBoxClientType_SelectedIndexChanged(object sender, EventArgs e)
    {
        _isChangeValueControl = true;
        TextBoxSearch.Focus();
    }
    #endregion
    #region "DataGridView Events"
    private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Clic Only on valid cell and column
        Guid clientId = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);

        if (DataGridView.Columns[e.ColumnIndex].Name == "editCol")
        {
            OpenFrmClient(clientId);
        }
        else if (DataGridView.Columns[e.ColumnIndex].Name == "phoneCol")
        {
            var clientName = DataGridView.Rows[e.RowIndex].Cells["FullName"].Value!.ToString()!;
            OpemFrmClientConversation(clientId, clientName);
        }
    }
    #endregion


}
