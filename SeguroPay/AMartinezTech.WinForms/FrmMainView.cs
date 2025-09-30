using AMartinezTech.WinForms.Utils;

namespace AMartinezTech.WinForms;

public partial class FrmMainView : Form
{

    #region "Constructor"

    public FrmMainView()
    {
        InitializeComponent();
        SetColorUI();
    }
    #endregion
    #region "Form evens"

    private void FrmMainView_Load(object sender, EventArgs e)
    {

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
    }
    #endregion
}
