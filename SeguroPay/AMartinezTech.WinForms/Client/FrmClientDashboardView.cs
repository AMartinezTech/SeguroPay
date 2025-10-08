using AMartinezTech.Application.Reports.Clients;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.WinForms.Client.Utils;
using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;


namespace AMartinezTech.WinForms.Client;

public partial class FrmClientDashboardView : Form
{
    #region "Fields"
    private readonly ClientController _controller;
    private BindingList<ClientViewModel> _clientList = [];
    private readonly IFormFactory _formFactory;
    private readonly ClientReportService _clientReportService;
    #endregion
    #region "Constructor"
    public FrmClientDashboardView(IFormFactory formFactory, ClientController clientController, ClientReportService clientReportService)
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

        foreach (var summary in summaries)
        {
            // Crear la tarjeta (Panel)
            Panel card = new Panel
            {
                Width = cardWidth,
                Height = cardHeight,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(10, yOffset)
            };

            // Label para tipo de cliente
            Label lblType = new Label
            {
                Text = $"Tipo: {summary.ClientType}",
                Location = new Point(10, 10),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            card.Controls.Add(lblType);

            // Label para activos
            Label lblActive = new Label
            {
                Text = $"Activos: {summary.ActiveCount}",
                Location = new Point(10, 35),
                AutoSize = true
            };
            card.Controls.Add(lblActive);

            // Label para inactivos
            Label lblInactive = new Label
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

        //int yOffset = 10; // espacio inicial desde arriba
        //int labelHeight = 25; // altura de cada label

        //foreach (var summary in report)
        //{
        //    Label label = new Label();
        //    label.Text = $"Tipo: {summary.ClientType} | Activos: {summary.ActiveCount} | Inactivos: {summary.InactiveCount}";
        //    label.Location = new Point(10, yOffset);
        //    label.AutoSize = true;

        //    PanelLeyenda.Controls.Add(label);
        //    yOffset += labelHeight; // mueve la posición para el siguiente label
        //}
    }
    private void FillComboBox()
    {
        ComboBoxClientType.DataSource = Enum.GetValues<ClientType>();
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
    private async void InvokeFilterAsync()
    {
        try
        {


            // Detiene el repintado del DataGridView temporalmente
            DataGridView.SuspendLayout();
            DataGridView.DataSource = null;

            var filters = new Dictionary<string, object?>
            {
                ["client_type"] = string.IsNullOrWhiteSpace(ComboBoxClientType.Text) ? null : ComboBoxClientType.Text.Trim()

            };

            var globalSearch = new Dictionary<string, object?>
            {
                ["first_name"] = TextBoxSearch.Text.Trim(),
                ["last_name"] = TextBoxSearch.Text.Trim(),
                ["doc_identity"] = TextBoxSearch.Text.Trim()
            };


            // Ejecuta el filtro en un hilo separado para no bloquear la UI
            var result = await Task.Run(() => _controller.FilterAsync(filters, globalSearch, CheckBoxIsActived.Checked));

            // Reactiva el repintado y asigna el resultado
            DataGridView.DataSource = result;
            _clientList = result;
            //_clientList = await _controller.FilterAsync(filters, globalSearch, CheckBoxIsActived.Checked);
            //DataGridView.DataSource = _clientList;
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


        //Buttons icon color
        IconPictureBoxSearch.IconColor = AppColors.Primary;
        BtnNuevo.IconColor = AppColors.Primary;

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
        }
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
    private void CheckBoxIsActived_CheckedChanged(object sender, EventArgs e)
    {

    }
    private void ComboBoxClientType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Clic Only on valid cell and column
        Guid clientId = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);

        if (DataGridView.Columns[e.ColumnIndex].Name == "editCol")
        {
            OpenFrmClient(clientId);
        }
    }
}
