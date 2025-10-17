using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;

namespace AMartinezTech.WinForms;

public partial class FrmBankDashboardView : Form
{
    #region "Fields"
    private readonly IFormFactory _formFactory;
    #endregion
    #region "Constructor"
    public FrmBankDashboardView(IFormFactory formFactory)
    {
        InitializeComponent();
        _formFactory = formFactory;
        SetColorUI();
    }
    #endregion
    #region "Form Events"
    private void FrmBankDashboardView_Load(object sender, EventArgs e)
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
        IconPictureBox.IconColor = AppColors.Primary;
        BtnBankAccount.IconColor = AppColors.Primary;
        BtnMovement.IconColor = AppColors.Primary;
        BtnPrintList.IconColor = AppColors.Primary;

    }
    #endregion
}
