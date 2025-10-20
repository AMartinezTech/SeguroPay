
using AMartinezTech.WinForms.Client.Utils;
using AMartinezTech.WinForms.Utils;

namespace AMartinezTech.WinForms.Client;

public partial class FrmSelectClientView : Form
{
    private readonly ClientController _controller;

    public ClientViewModel? SelectedClient { get; private set; }
    public FrmSelectClientView(ClientController clientController)
    {
        InitializeComponent();
        _controller = clientController; 
    }

    private void FrmSelectClientView_Load(object sender, EventArgs e)
    {
        InvokeDataViewSetting();
        InvokeFilterAsync();
    }
    private void InvokeDataViewSetting()
    {
        try
        {
            DataGridView.SetCustomDesign(new CustomDataGridViewParams {});
            // Set custom columns
            FormatingDGColumnsSelectClient.Apply(DataGridView);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private async void InvokeFilterAsync()
    {
        try
        {
            // Detiene el repintado del DataGridView temporalmente
            DataGridView.SuspendLayout();
            DataGridView.DataSource = null;


            var globalSearch = new Dictionary<string, object?>
            {
                ["first_name"] = TextBoxSearch.Text.Trim(),
                ["last_name"] = TextBoxSearch.Text.Trim(),
                ["doc_identity"] = TextBoxSearch.Text.Trim()
            };


            // Ejecuta el filtro en un hilo separado para no bloquear la UI
            var result = await Task.Run(() => _controller.FilterAsync(null, globalSearch, true));

            // Reactiva el repintado y asigna el resultado
            DataGridView.DataSource = result;


        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al filtrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            // Reanuda el pintado del DataGridView
            DataGridView.ResumeLayout();
        }
    }

    private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            InvokeFilterAsync();
        }
    }

    private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Clic Only on valid cell and column 

        //ClientId = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);
        SelectedClient = (ClientViewModel)DataGridView.CurrentRow!.DataBoundItem!;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void DataGridView_KeyDown(object sender, KeyEventArgs e)
    {
        // Solo actuamos si el usuario presiona Enter
        if (e.KeyCode == Keys.Enter && DataGridView.CurrentRow != null)
        {
            e.Handled = true; // Evita el beep de Windows
            e.SuppressKeyPress = true;

            //ClientId = Guid.Parse(DataGridView.CurrentRow.Cells["Id"].Value!.ToString()!);
            SelectedClient = (ClientViewModel)DataGridView.CurrentRow!.DataBoundItem!;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
