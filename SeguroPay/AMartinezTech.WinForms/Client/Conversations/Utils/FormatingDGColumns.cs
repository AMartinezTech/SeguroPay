namespace AMartinezTech.WinForms.Client.Conversations.Utils;

public class FormatingDGColumns
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

        var colCreatedAt = new DataGridViewTextBoxColumn
        {
            Name = "CreatedAt",
            HeaderText = "FECHA",
            DataPropertyName = "CreatedAt", // Vincula con la propiedad del resultado
           
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft, Format = "dd/MMM/yy hh:mm:ss tt" }

        }
        ;
        dataGridView.Columns.Add(colCreatedAt);

       
        
        var colSubject = new DataGridViewTextBoxColumn
        {
            Name = "Subject",
            HeaderText = "MOTIVO",
            DataPropertyName = "Subject", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(colSubject);
          
        var colMessage = new DataGridViewTextBoxColumn
        {
            Name = "Message",
            HeaderText = "NOTA",
            DataPropertyName = "Message", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft },
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        };
        dataGridView.Columns.Add(colMessage);
    }
}
