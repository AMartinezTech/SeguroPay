using AMartinezTech.Domain.Utils.Enums;
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
    #endregion
    #region "Constructor"
    public FrmClientDashboardView(IFormFactory formFactory, ClientController clientController)
    {
        InitializeComponent();
        _formFactory = formFactory;
        _controller = clientController;
        SetColorUI();
    }
    #endregion
    #region "Form Events"
    private void FrmClientDashboardView_Load(object sender, EventArgs e)
    {
        FillComboBox();
        InvokeDataViewSetting();
        InvokeFilterAsync();

    }
    #endregion
    #region "Methods"

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

        _clientList = await _controller.FilterAsync(filters, globalSearch, CheckBoxIsActived.Checked);
        DataGridView.DataSource = _clientList;
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
    #endregion
    private void BtnNuevo_Click(object sender, EventArgs e)
    {
        var frmClientView = _formFactory.CreateFormFactory<FrmClientView>();
               
        if (frmClientView.ShowDialog() == DialogResult.OK)
        {
            //MessageBox.Show(frmClientView.Client.FirstName);
        }
    }

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
}
