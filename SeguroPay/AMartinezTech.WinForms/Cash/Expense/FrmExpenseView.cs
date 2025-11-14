
using AMartinezTech.WinForms.Cash.Expense.Category;
using AMartinezTech.WinForms.Utils.Factories;

namespace AMartinezTech.WinForms.Cash.Expense;

public partial class FrmExpenseView : Form
{
    private readonly IFormFactory _formFactory;
    public FrmExpenseView(IFormFactory formFactory )
    {
        InitializeComponent();
        _formFactory = formFactory;
    }

    private void FrmExpenseView_Load(object sender, EventArgs e)
    {

    }

    private void CbExpenseCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void BtnExpenseCategory_Click(object sender, EventArgs e)
    {
        var frmCategoryExpense = _formFactory.CreateFormFactory<FrmExpenseCategory>();
        frmCategoryExpense.ShowDialog();
    }

    private void BtnClear_Click(object sender, EventArgs e)
    {

    }

    private void BtnPersistence_Click(object sender, EventArgs e)
    {

    }
}
