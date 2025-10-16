using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;
 

namespace AMartinezTech.WinForms.Insurance;

public partial class FrmInsuranceDashboardView : Form
{
    #region "Fields"
    private readonly IFormFactory _formFactory;
    #endregion
    #region "Constructor"
    public FrmInsuranceDashboardView(IFormFactory formFactory)
    {
        InitializeComponent();
        _formFactory = formFactory;
        SetColorUI();

    }
    #endregion
    #region "Form Events"
    private void FrmInsuranceDashboardView_Load(object sender, EventArgs e)
    {

    }
    #endregion
    #region "Methods"
    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;
        PanelLineTop.BackColor = AppColors.Outline;
        LabelTitle.ForeColor = AppColors.OnSurface;


        //Buttons icon color
        IconPictureBoxSearch.IconColor = AppColors.Primary;
        BtnInsurance.IconColor = AppColors.Primary;

    }
    #endregion

}
