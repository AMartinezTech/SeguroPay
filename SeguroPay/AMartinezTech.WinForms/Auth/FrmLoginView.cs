


using AMartinezTech.WinForms.Utils;

namespace AMartinezTech.WinForms.Auth;

public partial class FrmLoginView : Form
{
    #region "Fields"
    #endregion

    #region "Constructor"
    public FrmLoginView()
    {
        InitializeComponent();
        SetColorUI();
    }
    #endregion

    #region "Form Events"
    private void FrmLoginView_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region "Methods"
    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;
        PanelLineButtom.BackColor = AppColors.Outline;
        PanelLineTop.BackColor = AppColors.Outline;

        PanelButtom.BackColor = AppColors.Primary;

        //Buttons icon color
        IconPictureBoxLogin.IconColor = AppColors.Primary;
        BtnLogin.IconColor = AppColors.Primary;


        //Buttons text color 
        BtnLogin.ForeColor = AppColors.OnSurface;

    }
    #endregion

    private void BtnLogin_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}
