using System.Data;
using System.Drawing.Printing;

namespace AMartinezTech.WinForms.Utils;

public class ReportDefinition
{
    public string Title { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ReportPath { get; set; } = string.Empty;
    public Func<Task<DataTable>> GetDataAsync { get; set; } = default!;
    public string DataSourceCompanyName { get; set; } = string.Empty;
    public Func<Task<DataTable>> GetDataCompanyAsync { get; set; } = default!;
    public string DataSourceName { get; set; } = string.Empty;
    public PaperSize PaperSize { get; set; } = new PaperSize("Custom", 850, 550);
}