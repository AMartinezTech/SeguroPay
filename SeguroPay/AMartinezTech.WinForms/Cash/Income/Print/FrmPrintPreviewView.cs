using AMartinezTech.Application.Reports.Companies;
using AMartinezTech.Application.Reports.Incomes;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.WinForms.Utils;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.Drawing.Printing; 

namespace AMartinezTech.WinForms.Cash.Income.Print;

public partial class FrmPrintPreviewView : Form
{

    public required Guid IncomeId = Guid.Empty;
    public required string ReportName = string.Empty;
    private readonly ReportViewer _reportViewer;
    private readonly IncomeReportService _incomeReportService;
    private readonly CompanyReportService _companyReportService;
    private readonly Dictionary<string, ReportDefinition> _reports = [];

    private void RegisterReports()
    {
        _reports["IncomeReceipt"] = new ReportDefinition
        {
            Title = "Recibo de Ingreso",
            Name = "IncomeReceipt",
            ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Cash\Income\Print\IncomeReceipt.rdlc"),
            DataSourceName = "DSIncomeReceipt",
            GetDataAsync = async () => await _incomeReportService.GetReceiptAsync(IncomeId),
            GetDataCompanyAsync = async () => await _companyReportService.GetByIdAsync(),
            DataSourceCompanyName = "DSCompany",
            PaperSize = new PaperSize("Custom", 850, 550)
        };

        //_reports["IncomeList"] = new ReportDefinition
        //{
        //    Name = "IncomeList",
        //    ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Cash\Income\Print\IncomeList.rdlc"),
        //    DataSourceName = "DSIncomeList",
        //    GetDataAsync = async () => await _incomeReportService.GetIncomeListAsync(),
        //    PaperSize = new PaperSize("A4", 850, 1100)
        //};
    }
    public FrmPrintPreviewView(IncomeReportService incomeReportService, CompanyReportService companyReportService)
    {
        InitializeComponent();
        _reportViewer = new ReportViewer();
        _incomeReportService = incomeReportService;
        _companyReportService = companyReportService;
    }

    private void FrmPrintPreviewView_Load(object sender, EventArgs e)
    {
        _reportViewer.Dock = DockStyle.Fill;
        this.Controls.Add(_reportViewer);
        RegisterReports();
        LoadReports(ReportName);
    }

    private async void LoadReports(string reportName)
    {
        if (!_reports.TryGetValue(reportName, out var reportDef))
        {
            MessageBox.Show($"El reporte '{reportName}' no está registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        this.Text = reportDef.Title;

        _reportViewer.LocalReport.DataSources.Clear();

        DataTable incomeData = await reportDef.GetDataAsync();

        // Traducir PaymentMethod al español
        foreach (DataRow row in incomeData.Rows)
        {
            if (row["PaymentMethod"] != DBNull.Value)
            {
                string value = row["PaymentMethod"].ToString();

                if (Enum.TryParse(typeof(PaymentMethods), value, out var enumValue))
                {
                    var displayName = ((PaymentMethods)enumValue).GetDisplayName();
                    row["PaymentMethod"] = displayName;
                }
            }
        }
        ReportDataSource incomeDataSource = new(reportDef.DataSourceName, incomeData);

        DataTable companyData = await reportDef.GetDataCompanyAsync();
        
        ReportDataSource companyDataSource = new(reportDef.DataSourceCompanyName, companyData);

        _reportViewer.LocalReport.ReportPath = reportDef.ReportPath;

        _reportViewer.LocalReport.DataSources.Add(incomeDataSource);
        _reportViewer.LocalReport.DataSources.Add(companyDataSource);


        var qrData = QrGenerator.GenerateQr(IncomeId);
        var qrDataSource = new ReportDataSource("DSQr", qrData);

        _reportViewer.LocalReport.DataSources.Add(qrDataSource);

        // === Establecer configuración de página personalizada ===
        PageSettings pageSettings = new()
        {
            // Ejemplo: tamaño de papel 8.5x11 pulgadas (Carta)
            PaperSize = reportDef.PaperSize,

            // Márgenes (también en centésimas de pulgada)
            Margins = new Margins(50, 50, 50, 50)
        };

        // Asignar la configuración de página al reporte
        _reportViewer.SetPageSettings(pageSettings);

       

        // Mostrar en modo impresión
        _reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
        _reportViewer.ZoomMode = ZoomMode.Percent;
        _reportViewer.ZoomPercent = 100;
        _reportViewer.ShowToolBar = true;
        _reportViewer.RefreshReport();

    }
}
