namespace AMartinezTech.WinForms.Insurance.Utils;

internal class FormatingDGColumns
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

        var colPhone = new DataGridViewTextBoxColumn
        {
            Name = "Phone",
            HeaderText = "TELÉFONO",
            DataPropertyName = "phone", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(colPhone);

        var colContactName = new DataGridViewTextBoxColumn
        {
            Name = "ContactName",
            HeaderText = "CONTACTO",
            DataPropertyName = "ContactName", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(colContactName);


        var colContactPhone = new DataGridViewTextBoxColumn
        {
            Name = "ContactPhone",
            HeaderText = "TEL. CONTACTO",
            DataPropertyName = "ContactPhone", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(colContactPhone);


        var colIsActive = new DataGridViewTextBoxColumn
        {
            Name = "IsActiveName",
            HeaderText = "ESTADO",
            DataPropertyName = "IsActiveName", // Vincula con la propiedad del resultado
            Width = 75,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },

        };
        colIsActive.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridView.Columns.Add(colIsActive);
    }
}
