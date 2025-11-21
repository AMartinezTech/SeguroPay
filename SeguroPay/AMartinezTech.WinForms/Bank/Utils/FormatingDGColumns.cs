namespace AMartinezTech.WinForms.Bank.Utils;

internal class FormatingDGColumns
{
    internal static void Apply(DataGridView dataGridView)
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

        var Name = new DataGridViewTextBoxColumn
        {
            Name = "Name",
            HeaderText = "Nombre",
            DataPropertyName = "Name", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft },
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        };
        dataGridView.Columns.Add(Name);

        var Number = new DataGridViewTextBoxColumn
        {
            Name = "Number",
            HeaderText = "Número",
            DataPropertyName = "Number", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(Number);

        var Type = new DataGridViewTextBoxColumn
        {
            Name = "Type",
            HeaderText = "Tipo",
            DataPropertyName = "Type", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(Type);

        var colIsActive = new DataGridViewTextBoxColumn
        {
            Name = "IsActiveName",
            HeaderText = "Activa",
            DataPropertyName = "IsActiveName", // Vincula con la propiedad del resultado
            Width = 75,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },

        };
        colIsActive.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridView.Columns.Add(colIsActive);
    }
}
