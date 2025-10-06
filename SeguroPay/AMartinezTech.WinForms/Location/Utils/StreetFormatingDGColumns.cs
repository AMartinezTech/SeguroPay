namespace AMartinezTech.WinForms.Location.Utils;

internal class StreetFormatingDGColumns
{
    public static void Apply(DataGridView dataGridView)
    {
        //Desable aut generate columns
        dataGridView.AutoGenerateColumns = false;

        // Add columns
        var colId = new DataGridViewTextBoxColumn
        {
            Name = "id",
            HeaderText = "ID",
            DataPropertyName = "id", // Vincula con la propiedad del resultado
            Width = 75,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },
            Visible = false

        };
        dataGridView.Columns.Add(colId);

        

        var colName = new DataGridViewTextBoxColumn
        {
            Name = "Name",
            HeaderText = "NOMBRE",
            DataPropertyName = "Name", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft },
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        };
        dataGridView.Columns.Add(colName);

        
    }
}
