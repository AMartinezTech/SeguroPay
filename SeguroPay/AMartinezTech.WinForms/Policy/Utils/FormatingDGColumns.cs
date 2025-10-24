using AMartinezTech.WinForms.Utils;

namespace AMartinezTech.WinForms.Policy.Utils;

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
            HeaderText = "REGISTRADA",
            DataPropertyName = "CreatedAt", // Vincula con la propiedad del resultado
            Width = 100,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft, Format = "dd-MMM-yyyy" }

        };
        dataGridView.Columns.Add(CreatedAt);

        var PolicyNo = new DataGridViewTextBoxColumn
        {
            Name = "PolicyNo",
            HeaderText = "POLIZA NO.",
            DataPropertyName = "PolicyNo", // Vincula con la propiedad del resultado
            Width = 125,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(PolicyNo);

      
        var InsuranceName = new DataGridViewTextBoxColumn
        {
            Name = "InsuranceName",
            HeaderText = "ASEGURADORA",
            DataPropertyName = "InsuranceName", // Vincula con la propiedad del resultado
            Width = 150,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(InsuranceName);


        var PolicyType = new DataGridViewTextBoxColumn
        {
            Name = "PolicyType",
            HeaderText = "TIPO",
            DataPropertyName = "PolicyType", // Vincula con la propiedad del resultado
            Width = 100,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }

        };
        dataGridView.Columns.Add(PolicyType);
         
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

        

        var LastPayment = new DataGridViewTextBoxColumn
        {
            Name = "LastPayment",
            HeaderText = "ULT. PAGO",
            DataPropertyName = "LastPayment", // Vincula con la propiedad del resultado
            Width = 100,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft, Format = "dd-MMM-yyyy" },
        };
        dataGridView.Columns.Add(LastPayment);

        var PendingPayment = new DataGridViewTextBoxColumn
        {
            Name = "PendingPayment",
            HeaderText = "PAGO",
            DataPropertyName = "PendingPayment", // Vincula con la propiedad del resultado
            Width = 100,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft },
        };
        dataGridView.Columns.Add(PendingPayment);

        var Amount = new DataGridViewTextBoxColumn
        {
            Name = "Amount",
            HeaderText = "MONTO",
            DataPropertyName = "Amount", // Vincula con la propiedad del resultado
            Width = 200,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft, Format = "RD$ #,##0.00" , BackColor = AppColors.Primary, ForeColor = AppColors.OnPrimary }

        };
        dataGridView.Columns.Add(Amount);

         

    }
}
