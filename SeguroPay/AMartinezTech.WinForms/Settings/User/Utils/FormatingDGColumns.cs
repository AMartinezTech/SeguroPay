namespace AMartinezTech.WinForms.Settings.User.Utils;

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

        //var colEmail = new DataGridViewTextBoxColumn
        //{
        //    Name = "Email",
        //    HeaderText = "CORREO",
        //    DataPropertyName = "email", // Vincula con la propiedad del resultado
        //    Width = 150,
        //    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        //};
        //dataGridView.Columns.Add(colEmail);

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

        //var colRol = new DataGridViewTextBoxColumn
        //{
        //    Name = "Rol",
        //    HeaderText = "ROL",
        //    DataPropertyName = "rol", // Vincula con la propiedad del resultado
        //    Width = 150,
        //    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        //};
        //dataGridView.Columns.Add(colRol);


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
