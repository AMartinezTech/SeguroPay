using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;
using FontAwesome.Sharp;

namespace AMartinezTech.WinForms.Policy;

public partial class FrmPolicyDashboardView : Form
{
    #region "Fields"
    private readonly IFormFactory _formFactory;
    #endregion
    #region "Constructor"
    public FrmPolicyDashboardView(IFormFactory formFactory)
    {
        InitializeComponent();
        _formFactory = formFactory;
        SetColorUI();
    }
    #endregion

    #region "Form Events"
    private void FrmPolicyDashboardView_Load(object sender, EventArgs e)
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
        BtnInsurance.IconColor = AppColors.Primary;
        BtnPrintList.IconColor = AppColors.Primary;

    }
    #endregion

    private void BtnInsurance_Click(object sender, EventArgs e)
    {
        var frmPolicyView = _formFactory.CreateFormFactory<FrmPolicyView>();
        frmPolicyView.ShowDialog();
    }
}
