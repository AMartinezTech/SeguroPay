using AMartinezTech.Application.Cash.Income;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.WinForms.Cash.Income;
using AMartinezTech.WinForms.Cash.Income.Print;
using AMartinezTech.WinForms.Cash.Utils;
using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;
using System.ComponentModel;
using System.Threading.Tasks;

namespace AMartinezTech.WinForms.Cash;

public partial class FrmCashDashboardView : Form
{
    #region "Fields"
    private readonly IFormFactory _formFactory;
    private CancellationTokenSource? _cts;
    private readonly IncomeAppServices _incomeAppServices;
    private BindingList<IncomeDto> _list = [];
    #endregion
    #region "Constructor"
    public FrmCashDashboardView(IFormFactory formFactory, IncomeAppServices incomeAppServices)
    {
        InitializeComponent();
        _formFactory = formFactory;
        _incomeAppServices = incomeAppServices;
        SetColorUI();
    }
    #endregion

    #region "Form Events"

    private void FrmCashDashboardView_Load(object sender, EventArgs e)
    {
        InvokeDataViewSetting();
        DataGridView.EnableDoubleBuffering();
        InvokeFilterAsync();
        SetMessage("Alertas!", MessageType.Information);
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
        BtnOtherIncome.IconColor = AppColors.Primary;
        BtnExpense.IconColor = AppColors.Primary;
        BtnPrintList.IconColor = AppColors.Primary;

    }
    private async void InvokeFilterAsync()
    {
        try
        {
            // Detiene el repintado del DataGridView temporalmente
            DataGridView.SuspendLayout();
            DataGridView.DataSource = null;

            var filters = new Dictionary<string, object?>();

            //if (Status.SelectedValue != null && Status.SelectedValue.ToString() != "[Todas]")
            //    filters["status"] = Status.SelectedValue.ToString();

            //if (PolicyType.SelectedValue != null && PolicyType.SelectedValue.ToString() != "[Todas]")
            //    filters["policy_type"] = PolicyType.SelectedValue.ToString();

            //if (Insurance.SelectedValue != null && Guid.TryParse(Insurance.SelectedValue.ToString(), out var insuranceId) && insuranceId != Guid.Empty)
            //{
            //    filters["insurance_id"] = insuranceId;
            //}



            var searchText = TextBoxSearch.Text.Trim();
            var search = new Dictionary<string, object?>
            {
                ["CONCAT(c.first_name, ' ', c.last_name)"] = searchText,
                ["i.payment_method"] = searchText,
                ["c.doc_identity"] = searchText
            };


            // Ejecuta el filtro en un hilo separado para no bloquear la UI
            var result = await Task.Run(() => _incomeAppServices.FilterAsync(filters, search));


            // Reactiva el repintado y asigna el resultado
            _list = new BindingList<IncomeDto>(result);
            DataGridView.DataSource = _list;

            DataGridView.TranslateEnumColumns("MadeIn", "PaymentMethod");

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
            // Set custom columns
            FormatingDGColumns.Apply(DataGridView);
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

    }

    private void FilterBy_KeyPress(object sender, KeyPressEventArgs e)
    {

    }
    #endregion

    #region "Btn Events"
    private void BtnOtherIncome_Click(object sender, EventArgs e)
    {

    }

    private void BtnExpense_Click(object sender, EventArgs e)
    {

    }

    private void BtnPrintList_Click(object sender, EventArgs e)
    {

    }

    #endregion

    private async void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Clic Only on valid cell and column

        Guid incomeId = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);
        if (DataGridView.Columns[e.ColumnIndex].Name == "deleteCol")
        {
            if (MessageBox.Show("¿Seguro que desea borrar el registro?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _incomeAppServices.DeleteAsync(incomeId);
                InvokeFilterAsync();
            }

        }
        else if (DataGridView.Columns[e.ColumnIndex].Name == "printCol")
        {

            var _frmPrintPreviewView = _formFactory.CreateFormFactory<FrmPrintPreviewView>();
            _frmPrintPreviewView.IncomeId = incomeId;
            _frmPrintPreviewView.ReportName = "IncomeReceipt";
            _frmPrintPreviewView.Show();

        }
    }
}
