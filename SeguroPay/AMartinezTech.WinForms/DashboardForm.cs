
using System.Windows.Forms.DataVisualization.Charting;

namespace AMartinezTech.WinForms;

public partial class DashboardForm : Form
{
    public DashboardForm()
    {
        Text = "Dashboard - Gestión de Seguros Médicos";
        WindowState = FormWindowState.Maximized;
        BackColor = ColorTranslator.FromHtml("#F9FBFD"); // Surface

        var mainLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 3,
            ColumnCount = 1
        };
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 150)); // Panel superior
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 60));   // Medio
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40));   // Inferior
        Controls.Add(mainLayout);

        // 🔹 Panel Superior: Resumen Financiero
        var resumenLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 4
        };
        for (int i = 0; i < 4; i++)
            resumenLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));

        resumenLayout.Controls.Add(CreateCard("Pólizas Activas", "120", "#4DB6AC"), 0, 0);
        resumenLayout.Controls.Add(CreateCard("Monto Recaudado", "$1,250,000", "#619563"), 1, 0);
        resumenLayout.Controls.Add(CreateCard("Pagos Pendientes", "34", "#8C752B"), 2, 0);
        resumenLayout.Controls.Add(CreateCard("Pagos Vencidos", "12", "#E57373"), 3, 0);

        mainLayout.Controls.Add(resumenLayout, 0, 0);

        // 🔹 Panel Medio: Izquierda (Alertas) + Derecha (Próximos pagos + gráficos)
        var middleLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2
        };
        middleLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
        middleLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));

        // Izquierda: Alertas
        var alertPanel = new GroupBox
        {
            Text = "Alertas",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 10, FontStyle.Bold)
        };
        var alertList = new ListBox { Dock = DockStyle.Fill };
        alertList.Items.Add("⚠ Cliente con póliza vencida");
        alertList.Items.Add("⚠ Pago atrasado 15 días");
        alertList.Items.Add("✔ Depósito confirmado");
        alertPanel.Controls.Add(alertList);

        middleLayout.Controls.Add(alertPanel, 0, 0);

        // Derecha: Próximos Pagos + Gráfico
        var rightPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 2
        };
        rightPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
        rightPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));

        // Próximos Pagos
        var pagosGrid = new DataGridView
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor = ColorTranslator.FromHtml("#FFFFFF"),
        };
        pagosGrid.Columns.Add("Cliente", "Cliente");
        pagosGrid.Columns.Add("Poliza", "Póliza");
        pagosGrid.Columns.Add("Fecha", "Fecha");
        pagosGrid.Columns.Add("Monto", "Monto");

        pagosGrid.Rows.Add("Juan Pérez", "POL-001", "2025-10-05", "RD$ 5,000");
        pagosGrid.Rows.Add("María Gómez", "POL-002", "2025-10-10", "RD$ 3,500");

        rightPanel.Controls.Add(pagosGrid, 0, 0);

        // Gráfico
        var chart = new Chart { Dock = DockStyle.Fill };
        var chartArea = new ChartArea();
        chart.ChartAreas.Add(chartArea);

        var series = new Series("Pagos")
        {
            ChartType = SeriesChartType.Column
        };
        series.Points.AddXY("Realizados", 50);
        series.Points.AddXY("Pendientes", 34);
        series.Points.AddXY("Vencidos", 12);
        chart.Series.Add(series);

        rightPanel.Controls.Add(chart, 0, 1);

        middleLayout.Controls.Add(rightPanel, 1, 0);

        mainLayout.Controls.Add(middleLayout, 0, 1);

        // 🔹 Panel Inferior: Historial de depósitos y comunicaciones
        var bottomLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2
        };
        bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

        var depositoGrid = new DataGridView
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor = ColorTranslator.FromHtml("#FFFFFF")
        };
        depositoGrid.Columns.Add("Fecha", "Fecha");
        depositoGrid.Columns.Add("Banco", "Banco");
        depositoGrid.Columns.Add("Monto", "Monto");
        depositoGrid.Rows.Add("2025-09-20", "Banco Popular", "RD$ 15,000");
        depositoGrid.Rows.Add("2025-09-19", "Banco BHD", "RD$ 20,000");

        var commList = new ListView
        {
            Dock = DockStyle.Fill,
            View = View.Details
        };
        commList.Columns.Add("Fecha", 120);
        commList.Columns.Add("Cliente", 150);
        commList.Columns.Add("Canal", 100);
        commList.Columns.Add("Resumen", 250);
        commList.Items.Add(new ListViewItem(new[] { "2025-09-18", "Carlos Ruiz", "WhatsApp", "Consultó sobre pago" }));
        commList.Items.Add(new ListViewItem(new[] { "2025-09-17", "Ana López", "Teléfono", "Solicitó suspensión" }));

        bottomLayout.Controls.Add(depositoGrid, 0, 0);
        bottomLayout.Controls.Add(commList, 1, 0);

        mainLayout.Controls.Add(bottomLayout, 0, 2);
    }

    private Panel CreateCard(string title, string value, string colorHex)
    {
        var panel = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = ColorTranslator.FromHtml("#FFFFFF"),
            Margin = new Padding(10),
            Padding = new Padding(10)
        };

        var lblTitle = new Label
        {
            Text = title,
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            ForeColor = ColorTranslator.FromHtml("#2C3E50"),
            Dock = DockStyle.Top
        };

        var lblValue = new Label
        {
            Text = value,
            Font = new Font("Segoe UI", 16, FontStyle.Bold),
            ForeColor = ColorTranslator.FromHtml(colorHex),
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter
        };

        panel.Controls.Add(lblValue);
        panel.Controls.Add(lblTitle);

        return panel;
    }
}



