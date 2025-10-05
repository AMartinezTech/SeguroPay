using AMartinezTech.Application.Setting.User.Interfaces;
using AMartinezTech.WinForms.Client;
using AMartinezTech.WinForms.Settings;
using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;

namespace AMartinezTech.WinForms;

public partial class FrmMainView : Form
{
    #region "Fields"
    private readonly IFormFactory _formFactory;
    private Form _childForm;
    private readonly ICurrectUser _currectUser;

    #endregion
    #region "Constructor" 
    public FrmMainView(IFormFactory formFactory, ICurrectUser currectUser)
    {
        InitializeComponent();
        _formFactory = formFactory;
        _currectUser = currectUser;
        SetColorUI();
    }
    #endregion
    #region "Form evens"
    private void FrmMainView_Load(object sender, EventArgs e)
    {
        LabelWelcome.Text = $"Bienvenido {_currectUser.User!.FullName.Value} ({_currectUser.User.Rol.Type})";
    }

    #endregion

    #region "Methods"
    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;
        PanelTopMenu.BackColor = AppColors.SurfaceVariant;
        PanelLineHorizontal.BackColor = AppColors.Primary;
        PanelContainer.BackColor = AppColors.Surface;
        PanelButtomMenu.BackColor = AppColors.Primary;

        //Buttons icon color
        BtnClient.IconColor = AppColors.Primary;
        BtnInsurance.IconColor = AppColors.Primary;
        BtnPolicy.IconColor = AppColors.Primary;
        BtnCash.IconColor = AppColors.Primary;
        BtnBank.IconColor = AppColors.Primary;
        BtnSetting.IconColor = AppColors.Primary;

        //Buttons text color 
        BtnClient.ForeColor = AppColors.OnSurface;
        BtnInsurance.ForeColor = AppColors.OnSurface;
        BtnPolicy.ForeColor = AppColors.OnSurface;
        BtnCash.ForeColor = AppColors.OnSurface;
        BtnBank.ForeColor = AppColors.OnSurface;
        BtnSetting.ForeColor = AppColors.OnSurface;

        //Label text color
        LabelWelcome.ForeColor = AppColors.OnPrimary;
    }
    private void OpenChildForm(Form childForm)
    {
        //Main form
        _childForm?.Close();
        _childForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;
        PanelContainer.Controls.Add(childForm);
        PanelContainer.Tag = childForm;
        childForm.BringToFront();
        childForm.Show();

    }
    #endregion

    #region "Btn Events"
    private void BtnClient_Click(object sender, EventArgs e)
    {
        var frmClientDashboardView = _formFactory.CreateFormFactory<FrmClientDashboardView>();
        OpenChildForm(frmClientDashboardView);
    }

    private void BtnInsurance_Click(object sender, EventArgs e)
    {

    }

    private void BtnPolicy_Click(object sender, EventArgs e)
    {

    }

    private void BtnCash_Click(object sender, EventArgs e)
    {

    }

    private void BtnBank_Click(object sender, EventArgs e)
    {

    }

    private void BtnSetting_Click(object sender, EventArgs e)
    {
        var frmSettingDashboardView = _formFactory.CreateFormFactory<FrmSettingDashboardView>();    
        OpenChildForm(frmSettingDashboardView);
    }
    #endregion
}
