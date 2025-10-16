namespace AMartinezTech.WinForms.Client.Utils;

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

       

        var colDocIdentity = new DataGridViewTextBoxColumn
        {
            Name = "DocIdentity",
            HeaderText = "DOC. IDENT.",
            DataPropertyName = "DocIdentity", // Vincula con la propiedad del resultado
            Width = 150,
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


        var colEmail = new DataGridViewTextBoxColumn
        {
            Name = "Email",
            HeaderText = "CORREO",
            DataPropertyName = "Email", // Vincula con la propiedad del resultado
            Width = 200,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(colEmail);

        var colContactName = new DataGridViewTextBoxColumn
        {
            Name = "ContactName",
            HeaderText = "NOMBRE CONTACTO",
            DataPropertyName = "ContactName", // Vincula con la propiedad del resultado
            Width = 200,
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

         
    }
}
