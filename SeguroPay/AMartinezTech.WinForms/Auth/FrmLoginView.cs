using AMartinezTech.WinForms.Utils;
using System.Windows.Forms;

namespace AMartinezTech.WinForms.Auth;

public partial class FrmLoginView : Form
{
    #region "Fields"
    private CancellationTokenSource? _cts;

    private readonly UserLoginController _userLoginController;
    #endregion

    #region "Constructor"
    public FrmLoginView(UserLoginController userLoginController)
    {
        InitializeComponent();
        _userLoginController = userLoginController;
        SetColorUI();
    }
    #endregion

    #region "Form Events"
    private void FrmLoginView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para login.", MessageType.Information);
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
    private void ClearMessageErr()
    {
        errorProvider1.Clear();

        if (LabelAlertMessage.Text.Contains("Formulario"))
        {
            return;
        }

        SetMessage("Formulario preparado para login.", MessageType.Information);
    }
    private async Task SetInitialMessage(int seconds, Label messageLabel)
    {
        messageLabel.Click += (sender, e) =>
        {
            _cts?.Cancel();

        };
        try
        {
            // Cambiar a mensaje inicial
            var countdown = new CountdownTimer(seconds,
                onCountdownFinished: () => SetMessage("Formulario preparado para login.", MessageType.Information));

            // Inicia la cuenta establecida en CountdownTimer y espera
            await countdown.StartAsync(_cts!.Token);
        }
        catch (OperationCanceledException)
        {
            // Captura la cancelación del temporizador
            SetMessage("Formulario preparado para login.", MessageType.Information);

        }
        finally
        {
            if (_cts != null)
            {
                _cts.Dispose();
                _cts = null;
            }
        }
    }
    private void SetMessage(string message, MessageType type)
    {

        var msg = new HandlerMessages(message, type);
        LabelAlertMessage.Text = $"{msg.Icon} {msg.Message}";
        LabelAlertMessage.ForeColor = msg.MessageColor;
    }

    #endregion

    private async void BtnLogin_Click(object sender, EventArgs e)
    {
        ClearMessageErr();
        _cts = new CancellationTokenSource();
        try
        {

            var userName = TextBoxUser.Text.Trim();
            var password = TextBoxPassword.Text.Trim();

            var isLogin = await _userLoginController.LoginUserAsync(userName, password);
            if (isLogin)
                this.DialogResult = DialogResult.OK;

            this.Close();
        }
        catch (OperationCanceledException ex)
        {
            SetMessage(ex.Message, MessageType.Warning);
            // Set to 3 secons for alert
            await SetInitialMessage(3, LabelAlertMessage);

        }
        catch (Exception ex)
        {
            var message = DomainMessageSplit.SplitMessage(ex.Message);

            if (message.FieldName.Contains("UserName"))
            {
                TextBoxUser.Focus();
                errorProvider1.SetError(TextBoxUser, "Aquí!");
            }

            if (message.FieldName.Contains("Password"))
            {
                TextBoxPassword.Focus();
                errorProvider1.SetError(TextBoxPassword, "Aquí!");
            }


            SetMessage("Cerrar - " + message.Message, MessageType.Warning);

            // Set to 3 secons for alert
            await SetInitialMessage(4, LabelAlertMessage);

        }
    }

    private void TextBoxUser_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void TextBoxPassword_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }
}
