using AMartinezTech.WinForms.Utils;

namespace AMartinezTech.WinForms.Cash.Utils;

internal class FormatingDGColumns
{
    public static void Apply(DataGridView dataGridView)
    {
        //Desable aut generate columns
        dataGridView.AutoGenerateColumns = false;



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

        var CreatedAt = new DataGridViewTextBoxColumn
        {
            Name = "CreatedAt",
            HeaderText = "REGISTRADO",
            DataPropertyName = "CreatedAt", // Vincula con la propiedad del resultado
            Width = 100,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft, Format = "dd-MMM-yyyy" }

        };
        dataGridView.Columns.Add(CreatedAt);

        var PaymentMethod = new DataGridViewTextBoxColumn
        {
            Name = "PaymentMethod",
            HeaderText = "Metódo de pago",
            DataPropertyName = "PaymentMethod", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(PaymentMethod);

        var PaymentDate = new DataGridViewTextBoxColumn
        {
            Name = "PaymentDate",
            HeaderText = "F. PAGO",
            DataPropertyName = "PaymentDate", // Vincula con la propiedad del resultado
            Width = 100,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft, Format = "dd-MMM-yyyy" }

        };
        dataGridView.Columns.Add(PaymentDate);

        var ClientName = new DataGridViewTextBoxColumn
        {
            Name = "ClientName",
            HeaderText = "CLIENTE",
            DataPropertyName = "ClientName", // Vincula con la propiedad del resultado
            Width = 200,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft },
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        };
        dataGridView.Columns.Add(ClientName);
          
        var MadeIn = new DataGridViewTextBoxColumn
        {
            Name = "MadeIn",
            HeaderText = "Realizado en",
            DataPropertyName = "MadeIn", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(MadeIn);

        var TypeName = new DataGridViewTextBoxColumn
        {
            Name = "TypeName",
            HeaderText = "Tipo de ingreso",
            DataPropertyName = "TypeName", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(TypeName);

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
