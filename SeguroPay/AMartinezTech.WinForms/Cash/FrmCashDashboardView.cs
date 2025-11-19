using AMartinezTech.Application.Cash.Expense;
using AMartinezTech.Application.Cash.Income;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.WinForms.Cash.Expense;
using AMartinezTech.WinForms.Cash.Income;
using AMartinezTech.WinForms.Cash.Income.Print;
using AMartinezTech.WinForms.Cash.Utils;
using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;
using System.ComponentModel; 

namespace AMartinezTech.WinForms.Cash;

public partial class FrmCashDashboardView : Form
{
    #region "Fields"
    private readonly IFormFactory _formFactory;
    private CancellationTokenSource? _cts;
    private readonly ExpenseAppService _expenseAppService;
    private BindingList<ExpenseDto> _listExpense = [];

    private readonly IncomeAppServices _incomeAppServices;
    private BindingList<IncomeDto> _list = [];
    private bool _isChangeValueControl = false;

    #endregion
    #region "Constructor"
    public FrmCashDashboardView(IFormFactory formFactory, IncomeAppServices incomeAppServices, ExpenseAppService expenseAppService)
    {
        InitializeComponent();
        _formFactory = formFactory;
        _incomeAppServices = incomeAppServices;
        _expenseAppService = expenseAppService;
        SetColorUI();
    }
    #endregion

    #region "Form Events"

    private void FrmCashDashboardView_Load(object sender, EventArgs e)
    {
        InvokeDataViewSetting();
        DataGridView.EnableDoubleBuffering();
        InvokeFilterAsync("Ingresos");
        SetMessage("Alertas!", MessageType.Information);
        FillComboBoxes();
    }
    #endregion
    #region "Methods"
    private void FillComboBoxes()
    {

        var incomeTypes = Enum.GetValues<IncomeTypes>()
            .Cast<IncomeTypes>()
            .Select(e => new
            {
                Value = (IncomeTypes?)e,
                Text = e.GetDisplayName()
            })
            .ToList();

        incomeTypes.Insert(0, new { Value = (IncomeTypes?)null, Text = "[Todas]" });
        ComboBoxIncomeTypes.DataSource = incomeTypes;
        ComboBoxIncomeTypes.DisplayMember = "Text";
        ComboBoxIncomeTypes.ValueMember = "Value";
        ComboBoxIncomeTypes.SelectedIndex = 0;

        var paymentMethods = Enum.GetValues<PaymentMethods>()
            .Cast<PaymentMethods>()
            .Select(e => new
            {
                Value = (PaymentMethods?)e,
                Text = e.GetDisplayName()
            })
            .ToList();

        paymentMethods.Insert(0, new { Value = (PaymentMethods?)null, Text = "[Todas]" }); 
        ComboBoxPaymentMethods.DataSource = paymentMethods;
        ComboBoxPaymentMethods.DisplayMember = "Text";
        ComboBoxPaymentMethods.ValueMember = "Value";
        ComboBoxPaymentMethods.SelectedIndex = 0;

        var incomeMadeIn = Enum.GetValues<IncomeMadeIn>()
            .Cast<IncomeMadeIn>()
            .Select(e => new
            {
                Value = (IncomeMadeIn?)e,
                Text = e.GetDisplayName()
            })
            .ToList();
        incomeMadeIn.Insert(0, new { Value = (IncomeMadeIn?)null, Text = "[Todas]" });
        ComboBoxIncomeMadeIn.DataSource = incomeMadeIn;
        ComboBoxIncomeMadeIn.DisplayMember = "Text";
        ComboBoxIncomeMadeIn.ValueMember = "Value";
        ComboBoxIncomeMadeIn.SelectedIndex = 0;



    }
    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;
        PanelLineTop.BackColor = AppColors.Outline;
        LabelTitle.ForeColor = AppColors.OnSurface;


        //Buttons icon color
        IconPictureBoxSearch.IconColor = AppColors.Primary;
        IconPictureBox.IconColor = AppColors.Primary;
        BtnOtherIncome.IconColor = AppColors.Primary;
        BtnExpense.IconColor = AppColors.Primary;
        BtnPrintList.IconColor = AppColors.Primary;

    }
    private void InvokeFilterAsync(string filterBy)
    {
        if (string.IsNullOrWhiteSpace(filterBy))
            return;



        if (filterBy == "Ingresos")
        {
            IncomenDGColumns.Apply(DataGridView);   // columnas de ingresos
            InvokeIncomeFilterAsync(false);              // consulta de ingresos
        }
        else
        {
            ExpenseDGColumns.Apply(DataGridView);   // columnas de gastos
            InvokeExpenseFilterAsync();             // consulta de gastos
        }
    }
    private async void InvokeExpenseFilterAsync()
    {
        try
        {
            ClearMessageErr();
            // Detiene el repintado del DataGridView temporalmente _expenseAppService
            DataGridView.SuspendLayout();
            DataGridView.DataSource = null;

            var filters = new Dictionary<string, object?>();

            var searchText = TextBoxSearch.Text.Trim();
            var search = new Dictionary<string, object?>
            {
                ["e.note"] = searchText
            };

            Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null;

            // Verifica que ambos controles tengan fechas válidas
            if (DateTimePicker1.Value.Date > DateTimePicker2.Value.Date)
            {

                SetMessage("La fecha inicial no puede ser mayor que la fecha final. Rango de fechas inválido", MessageType.Warning);
                return;
            }

            if (DateTimePicker1.Value.Date == DateTimePicker2.Value.Date)
            {
                // Si ambas fechas son iguales → filtra desde esa fecha (inicio = fecha, fin = null)
                dateRanges = new Dictionary<string, (DateTime? start, DateTime? end)>
                {
                    { "e.created_at", (DateTimePicker1.Value.Date, null) }
                };
            }
            else
            {
                // Si hay un rango de fechas válido → BETWEEN start AND end
                dateRanges = new Dictionary<string, (DateTime? start, DateTime? end)>
                {
                    { "e.created_at", (DateTimePicker1.Value.Date, DateTimePicker2.Value.Date) }
                };
            }


            var fecha = dateRanges;
            // Ejecuta el filtro en un hilo separado para no bloquear la UI
            var result = await Task.Run(() => _expenseAppService.FilterAsync(filters, search, dateRanges));


            // Reactiva el repintado y asigna el resultado
            _listExpense = new BindingList<ExpenseDto>(result);
            DataGridView.DataSource = _listExpense;

            LabelTotal.Text = _listExpense.Sum(x => x.Amount).ToString("N2");
            //DataGridView.TranslateEnumColumns("MadeIn", "PaymentMethod");

            // Traducir solo las columnas de enum
            //LoadPolicyStatusChart();
            //// Para Label: 
            //int totalPolicyFiltered = filterByPayStatus.Count;
            //TotalPolicyFiltered.Text = $"Total de pólizas filtradas: {totalPolicyFiltered}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al filtrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            // Reanuda el pintado del DataGridView
            DataGridView.ResumeLayout();
        }
    }
    private async void InvokeIncomeFilterAsync(bool incomeFilter)
    {
        try
        {
            ClearMessageErr();
            // Detiene el repintado del DataGridView temporalmente _expenseAppService
            DataGridView.SuspendLayout();
            DataGridView.DataSource = null;

            var filters = new Dictionary<string, object?>();

            if (incomeFilter)
            {
                if (ComboBoxPaymentMethods.SelectedValue != null && ComboBoxPaymentMethods.SelectedValue.ToString() != "[Todas]")
                    filters["payment_method"] = ComboBoxPaymentMethods.SelectedValue!.ToString();

                if (ComboBoxIncomeTypes.SelectedValue != null && ComboBoxIncomeTypes.SelectedValue.ToString() != "[Todas]")
                    filters["income_type"] = ComboBoxIncomeTypes.SelectedValue!.ToString();

                if (ComboBoxIncomeMadeIn.SelectedValue != null && ComboBoxIncomeMadeIn.SelectedValue.ToString() != "[Todas]")
                    filters["made_in"] = ComboBoxIncomeMadeIn.SelectedValue!.ToString();
                 
            }
          

            var searchText = TextBoxSearch.Text.Trim();
            var search = new Dictionary<string, object?>
            {
                ["CONCAT(c.first_name, ' ', c.last_name)"] = searchText,
                ["i.payment_method"] = searchText,
                ["c.doc_identity"] = searchText
            };

            Dictionary<string, (DateTime? start, DateTime? end)>? dateRanges = null;

            // Verifica que ambos controles tengan fechas válidas
            if (DateTimePicker1.Value.Date > DateTimePicker2.Value.Date)
            {

                SetMessage("La fecha inicial no puede ser mayor que la fecha final. Rango de fechas inválido", MessageType.Warning);
                return;
            }

            if (DateTimePicker1.Value.Date == DateTimePicker2.Value.Date)
            {
                // Si ambas fechas son iguales → filtra desde esa fecha (inicio = fecha, fin = null)
                dateRanges = new Dictionary<string, (DateTime? start, DateTime? end)>
                {
                    { "i.created_at", (DateTimePicker1.Value.Date, null) }
                };
            }
            else
            {
                // Si hay un rango de fechas válido → BETWEEN start AND end
                dateRanges = new Dictionary<string, (DateTime? start, DateTime? end)>
                {
                    { "i.created_at", (DateTimePicker1.Value.Date, DateTimePicker2.Value.Date) }
                };
            }

            // Ejecuta el filtro en un hilo separado para no bloquear la UI
            var result = await Task.Run(() => _incomeAppServices.FilterAsync(filters, search, dateRanges));

            // Reactiva el repintado y asigna el resultado
            _list = new BindingList<IncomeDto>(result);
            DataGridView.DataSource = _list;

            DataGridView.TranslateEnumColumns("MadeIn", "PaymentMethod");

            DataGridView.Refresh();

            LabelTotal.Text = _list.Sum(x => x.Amount).ToString("N2");


            // Traducir solo las columnas de enum
            // LoadPolicyStatusChart();
            // Para Label: 
            // int totalPolicyFiltered = filterByPayStatus.Count;
            // TotalPolicyFiltered.Text = $"Total de pólizas filtradas: {totalPolicyFiltered}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al filtrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            // Reanuda el pintado del DataGridView
            DataGridView.ResumeLayout();
        }
    }
    private void InvokeDataViewSetting()
    {
        try
        {
            DataGridView.SetCustomDesign(new CustomDataGridViewParams
            {
                DeleteColumnView = true,
                DeleteColumnName = "BORRAR",
                PrintColumnView = true,
                PrintColumnName = "IMPRIMIR",
            });

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void ClearMessageErr()
    {
        errorProvider1.Clear();

        if (LabelAlertMessage.Text.Contains("Alertas"))
        {
            return;
        }

        SetMessage("Alertas!", MessageType.Information);
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
                onCountdownFinished: () => SetMessage("Alertas!", MessageType.Information));

            // Inicia la cuenta establecida en CountdownTimer y espera
            await countdown.StartAsync(_cts!.Token);
        }
        catch (OperationCanceledException)
        {
            // Captura la cancelación del temporizador
            SetMessage("Alertas!", MessageType.Information);
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
    private async Task SafeExecuteAsync(Func<Task> action)
    {
        ClearMessageErr();
        _cts = new CancellationTokenSource();
        try
        {
            await action();
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

            SetMessage("Cerrar - " + message.Message, MessageType.Warning);

            // Set to 3 secons for alert
            await SetInitialMessage(4, LabelAlertMessage);

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

    #region "Field Events"
    private void FilterBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        _isChangeValueControl = true;
        TextBoxSearch.Focus();
    }

    private void FilterBy_KeyPress(object sender, KeyPressEventArgs e)
    {

    }
    private void TextBoxSearch_Enter(object sender, EventArgs e)
    {
        if (_isChangeValueControl)
        {
            _isChangeValueControl = false;
            PanelIncomeFilter.Visible = false;
            InvokeFilterAsync(FilterBy.Text);

            if (FilterBy.Text == "Ingresos")
                PanelIncomeFilter.Visible = true;
        }
    }

    private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        _isChangeValueControl = true;
        TextBoxSearch.Focus();
    }

    private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
    {
        _isChangeValueControl = true;
        TextBoxSearch.Focus();
    }

    private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
            InvokeFilterAsync(FilterBy.Text);
    }
    #endregion

    #region "Btn Events"
    private void BtnOtherIncome_Click(object sender, EventArgs e)
    {
        var frmOtherIncomeView = _formFactory.CreateFormFactory<FrmOtherIncomeView>();

        if (frmOtherIncomeView.ShowDialog() == DialogResult.OK)
        {
            _isChangeValueControl = true;
            TextBoxSearch.Focus();
        }
    }

    private void BtnExpense_Click(object sender, EventArgs e)
    {
        var frmOtherIncomeView = _formFactory.CreateFormFactory<FrmExpenseView>();

        if (frmOtherIncomeView.ShowDialog() == DialogResult.OK)
        {
            _isChangeValueControl = true;
            FilterBy.Text = "Gastos";
            TextBoxSearch.Focus();
        }
    }

    private void BtnPrintList_Click(object sender, EventArgs e)
    {

    }

    #endregion

    #region "DataGridView Events"
    private async void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Clic Only on valid cell and column

        Guid incomeId = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);
        if (DataGridView.Columns[e.ColumnIndex].Name == "deleteCol")
        {
            if (MessageBox.Show("¿Seguro que desea borrar el registro?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _incomeAppServices.DeleteAsync(incomeId);
                InvokeFilterAsync(FilterBy.Text);
            }

        }
        else if (DataGridView.Columns[e.ColumnIndex].Name == "printCol")
        {

            var _frmPrintPreviewView = _formFactory.CreateFormFactory<FrmPrintIncomePreviewView>();
            _frmPrintPreviewView.IncomeId = incomeId;
            _frmPrintPreviewView.ReportName = "IncomeReceipt";
            _frmPrintPreviewView.Show();

        }
    }

    #endregion


    private void BtnIncomeFilter_Click(object sender, EventArgs e)
    {
        InvokeIncomeFilterAsync(true);
    }
}
