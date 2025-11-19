using AMartinezTech.Application.Cash.Expense;
using AMartinezTech.Application.Cash.Expense.Category;
using AMartinezTech.WinForms.Cash.Expense.Category;
using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;

namespace AMartinezTech.WinForms.Cash.Expense;

public partial class FrmExpenseView : Form
{
    private readonly ExpenseCategoryAppService _categoryAppService;
    private readonly ExpenseAppService _appService;
    private readonly IFormFactory _formFactory;
    private CancellationTokenSource? _cts;
    public Guid ExpenseId = Guid.Empty;
    public ExpenseDto? Expense { get; private set; }
    public FrmExpenseView(IFormFactory formFactory, ExpenseCategoryAppService categoryAppService, ExpenseAppService appService)
    {
        InitializeComponent();
        _formFactory = formFactory;
        SetColorUI();
        _categoryAppService = categoryAppService;
        _appService = appService;
    }

    private void FrmExpenseView_Load(object sender, EventArgs e)
    {
        SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        FillComboBoxs();
    }
    #region "Methods"
    private async void FillComboBoxs()
    {
        var paymentMethods = await _categoryAppService.PaginationAsync(1, 100, true);

        CbExpenseCategory.DataSource = paymentMethods.Data;
        CbExpenseCategory.DisplayMember = "Name";
        CbExpenseCategory.ValueMember = "Id";
        CbExpenseCategory.SelectedIndex = -1;

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
    private void ValidationFields(string fieldName)
    {
        if (fieldName.Contains("Category"))
        {
            CbExpenseCategory.Focus();
            errorProvider1.SetError(CbExpenseCategory, "Aquí!");
        }
        else if (fieldName.Contains("Amount"))
        {
            TextBoxAmount.Focus();
            errorProvider1.SetError(TextBoxAmount, "Aquí!");
        }
    }

    #endregion
    private void CbExpenseCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }

    private void BtnExpenseCategory_Click(object sender, EventArgs e)
    {
        var frmCategoryExpense = _formFactory.CreateFormFactory<FrmExpenseCategory>();
        frmCategoryExpense.ShowDialog();
    }


    private async void BtnPersistence_Click(object sender, EventArgs e)
    {
        ClearMessageErr();
        _cts = new CancellationTokenSource();
        try
        {
            //180 + 119 + 15

            if (string.IsNullOrEmpty(TextBoxAmount.Text))
                TextBoxAmount.Text = "0";


            BtnPersistence.Enabled = false;

            Expense = new ExpenseDto
            {
                Id = ExpenseId,
                CategoryId = CbExpenseCategory.SelectedValue == null ? Guid.Empty : Guid.Parse(CbExpenseCategory.SelectedValue!.ToString()!),
                Amount = decimal.Parse(TextBoxAmount.Text),
                Note = TextBoxNote.Text,

            };
            ExpenseId = await _appService.PersistenceASync(Expense);
            Expense.Id = ExpenseId;


            SetMessage("Cerrar - Operación realizada con exito.!", MessageType.Success);


            // Set to 2 secons for alert
            await SetInitialMessage(2, LabelAlertMessage);

            this.DialogResult = DialogResult.OK;
            this.Close();
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

    private void TextBoxAmount_TextChanged(object sender, EventArgs e)
    {
        ClearMessageErr();
    }
}
