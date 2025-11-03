using AMartinezTech.Application.Reports.Clients.Interfaces;
using AMartinezTech.Application.Reports.Companies; 
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.WinForms.Utils;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.Drawing.Printing;

namespace AMartinezTech.WinForms.Client.Print;



public partial class FrmPrintClientPreviewView : Form
{
    private readonly ReportViewer _reportViewer;
    public required string ReportName = string.Empty;
    public required Dictionary<string, object?>? filter = [];
    public readonly IClientReportService _clientReportService; 
    private readonly CompanyReportService _companyReportService;
    private readonly Dictionary<string, ReportDefinition> _reports = [];
    public FrmPrintClientPreviewView(IClientReportService clientReportService, CompanyReportService companyReportService)
    {
        InitializeComponent();
        _reportViewer = new ReportViewer();
        _clientReportService = clientReportService;
        _companyReportService = companyReportService;
    }

    private void FrmPrintClientPreviewView_Load(object sender, EventArgs e)
    {
        _reportViewer.Dock = DockStyle.Fill;
        this.Controls.Add(_reportViewer);
        RegisterReports(filter);
        LoadReports(ReportName);
    }
    private void RegisterReports(Dictionary<string, object?>? filter = null)
    {
        _reports["ListOfClients"] = new ReportDefinition
        {
            Title = "Listado de clientes",
            Name = "ListOfClients",
            ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Client\Print\ListOfClients.rdlc"),
            DataSourceName = "DSClients",
            GetDataAsync = async () => await _clientReportService.GetByFilterReportsAsync(filter),
            GetDataCompanyAsync = async () => await _companyReportService.GetByIdAsync(),
            DataSourceCompanyName = "DSCompany",
            PaperSize = new PaperSize("Custom", 850, 1100)
        };

        
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

        DataTable clientsData = await _clientReportService.GetByFilterReportsAsync();

        // Traducir PaymentMethod al español
        foreach (DataRow row in clientsData.Rows)
        {
            if (row["client_type"] != DBNull.Value)
            {
                string value = row["client_type"].ToString()!;

                if (Enum.TryParse(typeof(ClientTypes), value, out var enumValue))
                {
                    var displayName = ((ClientTypes)enumValue).GetDisplayName();
                    row["client_type"] = displayName;
                }
            }
        }
        ReportDataSource clientsDataSource = new(reportDef.DataSourceName, clientsData);

        DataTable companyData = await reportDef.GetDataCompanyAsync(); 
        ReportDataSource companyDataSource = new(reportDef.DataSourceCompanyName, companyData);

        _reportViewer.LocalReport.ReportPath = reportDef.ReportPath;

        _reportViewer.LocalReport.DataSources.Add(clientsDataSource);
        _reportViewer.LocalReport.DataSources.Add(companyDataSource);
 

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
