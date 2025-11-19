using AMartinezTech.WinForms.Utils;

namespace AMartinezTech.WinForms.Cash.Utils;

internal class ExpenseDGColumns
{
    internal static void Apply(DataGridView dataGridView)
    {
        //Desable aut generate columns
        dataGridView.AutoGenerateColumns = false;

        dataGridView.Columns.Clear(); // <-- limpiar columnas antes de aplicar


        // Add columns
        var Id = new DataGridViewTextBoxColumn
        {
            Name = "Id",
            HeaderText = "ID",
            DataPropertyName = "Id", // Vincula con la propiedad del resultado
            Width = 75,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },
            Visible = false

        };
        dataGridView.Columns.Add(Id);
        dataGridView.Columns["Id"]!.Visible = false;

        var CreatedAt = new DataGridViewTextBoxColumn
        {
            Name = "CreatedAt",
            HeaderText = "REGISTRADO",
            DataPropertyName = "CreatedAt", // Vincula con la propiedad del resultado
            Width = 100,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft, Format = "dd-MMM-yyyy" }

        };
        dataGridView.Columns.Add(CreatedAt);

        var CategoryName = new DataGridViewTextBoxColumn
        {
            Name = "CategoryName",
            HeaderText = "Categpría",
            DataPropertyName = "CategoryName", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(CategoryName);

        

        var Note = new DataGridViewTextBoxColumn
        {
            Name = "Note",
            HeaderText = "DESCRIPCIÓN",
            DataPropertyName = "Note", // Vincula con la propiedad del resultado
            Width = 200,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft },
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        };
        dataGridView.Columns.Add(Note);

       

        var Amount = new DataGridViewTextBoxColumn
        {
            Name = "Amount",
            HeaderText = "MONTO",
            DataPropertyName = "Amount", // Vincula con la propiedad del resultado
            Width = 200,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "RD$ #,##0.00", BackColor = AppColors.Primary, ForeColor = AppColors.OnPrimary }

        };
        dataGridView.Columns.Add(Amount);


    }
}
