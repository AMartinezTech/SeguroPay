
using AMartinezTech.WinForms.Settings.Company;
using AMartinezTech.WinForms.Settings.User;
using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;

namespace AMartinezTech.WinForms.Settings;

public partial class FrmSettingDashboardView : Form
{
    private readonly IFormFactory _formFactory;
    public FrmSettingDashboardView(IFormFactory formFactory)
    {
        InitializeComponent();
        _formFactory = formFactory;
        SetColorUI();
    }

    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;


        //Buttons icon color
        BtnUser.IconColor = AppColors.Primary;
        BtnCompany.IconColor = AppColors.Primary;

        //Buttons text color 
        BtnUser.ForeColor = AppColors.OnSurface;
        BtnCompany.ForeColor = AppColors.OnSurface;

    }
    private void BtnUser_Click(object sender, EventArgs e)
    {
        var frmUserView = _formFactory.CreateFormFactory<FrmUserView>();
        frmUserView.ShowDialog();
    }

    private void BtnCompany_Click(object sender, EventArgs e)
    {
        var frmCompanyView = _formFactory.CreateFormFactory<FrmCompanyView>();
        frmCompanyView.ShowDialog();
    }
}
