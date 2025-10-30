using AMartinezTech.Application.Setting.Company;
using AMartinezTech.Application.Setting.User;
using AMartinezTech.WinForms.Settings.User;
using AMartinezTech.WinForms.Utils;
using System.Drawing.Imaging;
namespace AMartinezTech.WinForms.Settings.Company;

public partial class FrmCompanyView : Form
{
    #region "Fileds"
    private CancellationTokenSource? _cts;
    private readonly CompanyAppServices _companyAppServices;
    private Guid CompanyId { set; get; }
    #endregion

    #region "Constructor"
    public FrmCompanyView(CompanyAppServices companyAppServices)
    {
        InitializeComponent();
        SetColorUI();
        _companyAppServices = companyAppServices;
    }
    #endregion

    #region "Form Events" 
    private void FrmCompanyView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        InvokeFilterAsync();
    }
    #endregion

    #region "Methods"
    private async void InvokeFilterAsync()
    {
        var companyData = await _companyAppServices.FilterAsync();
        var data = companyData.FirstOrDefault();

        if (data != null)
        {

            CompanyId = data.Id;
            TxtRNC.Text = data.RNC;
            TxtName.Text = data.Name;
            TxtEmail.Text = data.Email;
            TxtPhone.Text = data.Phone;
            TxtLine1.Text = data.Line1;
            TxtLine2.Text = data.Line2;

            // Mostrar logo si existe
            if (data.Logo != null && data.Logo.Length > 0)
            {
                data.Logo.Position = 0; // Asegura que el stream esté al inicio
                PbLogo.Image = Image.FromStream(data.Logo);
                PbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                PbLogo.Image = null; // Limpia si no hay logo
            }
        }
    }

    private void ValidationFields(string fieldName)
    {

        if (fieldName.Contains("CompanyName"))
        {
            TxtName.Focus();
            errorProvider1.SetError(TxtName, "Aquí!");
        }
        else if (fieldName.Contains("DocIdentity"))
        {
            TxtRNC.Focus();
            errorProvider1.SetError(TxtRNC, "Aquí!");
        }
        else if (fieldName.Contains("Email"))
        {
            TxtPhone.Focus();
            errorProvider1.SetError(TxtPhone, "Aquí");
        }
        else if (fieldName.Contains("Phone"))
        {
            TxtPhone.Focus();
            errorProvider1.SetError(TxtPhone, "Aquí");
        }
        else if (fieldName.Contains("Line1"))
        {
            TxtLine1.Focus();
            errorProvider1.SetError(TxtLine1, "Aquí");
        }
        else if (fieldName.Contains("Line2"))
        {
            TxtLine2.Focus();
            errorProvider1.SetError(TxtLine2, "Aquí");
        }

    }
    private void ClearMessageErr()
    {
        errorProvider1.Clear();

        if (LabelAlertMessage.Text.Contains("Formulario"))
        {
            return;
        }

        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
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
                onCountdownFinished: () => SetMessage("Formulario preparado para recibir datos.", MessageType.Information));

            // Inicia la cuenta establecida en CountdownTimer y espera
            await countdown.StartAsync(_cts!.Token);
        }
        catch (OperationCanceledException)
        {
            // Captura la cancelación del temporizador
            SetMessage("Formulario preparado para recibir datos.", MessageType.Information);

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
    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;
        PanelButtom.BackColor = AppColors.Primary;
        PanelLineTop.BackColor = AppColors.Outline;
        PanelLineButtom.BackColor = AppColors.Outline;
        PanelAlertMessage.BackColor = AppColors.SurfaceMessage;


        // Btn
        BtnPersistence.IconColor = AppColors.Primary;


        // Label
        LabelTitle.ForeColor = AppColors.OnPrimary;
    }
    #endregion

    #region "Btn Events"
    private async void BtnPersistence_Click(object sender, EventArgs e)
    {
        ClearMessageErr();
        _cts = new CancellationTokenSource();
        try
        {
            MemoryStream? logoStream = null;

            // Si el PictureBox tiene una imagen, la convertimos a MemoryStream
            if (PbLogo.Image != null)
            {
                logoStream = new MemoryStream();
                PbLogo.Image.Save(logoStream, ImageFormat.Png); // o ImageFormat.Jpeg según tu caso
                logoStream.Position = 0; // Reiniciar posición
               
            }
            var newDto = new CompanyDto
            {
                Id = CompanyId,
                RNC = TxtRNC.Text.Trim(),
                Name = TxtName.Text.Trim(),
                Email = TxtEmail.Text.Trim(),
                Phone = TxtPhone.Text.Trim(),
                Line1 = TxtLine1.Text.Trim(),
                Line2 = TxtLine2.Text.Trim(),
                Logo = logoStream
            };
            CompanyId = await _companyAppServices.PersistenceAsync(newDto);

        }
        catch (OperationCanceledException ex)
        {
            SetMessage(ex.Message, MessageType.Warning);
            // Set to 3 secons for alert
            await SetInitialMessage(3, LabelAlertMessage);
            BtnPersistence.Enabled = true;
        }
        catch (Exception ex)
        {
            var message = DomainMessageSplit.SplitMessage(ex.Message);
            ValidationFields(message.FieldName);

            SetMessage("Cerrar - " + message.Message, MessageType.Warning);

            // Set to 3 secons for alert
            await SetInitialMessage(4, LabelAlertMessage);
            BtnPersistence.Enabled = true;
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
    #endregion

    private void PbLogo_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Title = "Seleccionar logo de la empresa";
            openFileDialog.Filter = "Imágenes (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Carga la imagen seleccionada
                    Image selectedImage = Image.FromFile(openFileDialog.FileName);
                    PbLogo.Image = selectedImage;
                    PbLogo.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen al cuadro
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
