namespace AMartinezTech.WinForms.Client.Utils;

internal class FormatingDGColumnsSelectClient
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



        var colDocIdentity = new DataGridViewTextBoxColumn
        {
            Name = "DocIdentity",
            HeaderText = "DOC. IDENT.",
            DataPropertyName = "DocIdentity", // Vincula con la propiedad del resultado
            Width = 100,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(colDocIdentity);

        var colName = new DataGridViewTextBoxColumn
        {
            Name = "FullName",
            HeaderText = "NOMBRE",
            DataPropertyName = "FullName", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft },
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        };
        dataGridView.Columns.Add(colName);

        var colPhone = new DataGridViewTextBoxColumn
        {
            Name = "Phone",
            HeaderText = "TELÉFONO",
            DataPropertyName = "phone", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(colPhone);


       


    }
}
