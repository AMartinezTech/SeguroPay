

using AMartinezTech.Application.Cash.Expense.Category;
using AMartinezTech.Application.Location.Street;
using AMartinezTech.WinForms.Location.Controllers;
using AMartinezTech.WinForms.Location.Utils;
using AMartinezTech.WinForms.Utils;
using System.ComponentModel;

namespace AMartinezTech.WinForms.Cash.Expense.Category
{
    public partial class FrmExpenseCategory : Form
    {
        private CancellationTokenSource? _cts; 
        private Guid Id {  get; set; }
        private readonly ExpenseCategoryAppService _appService;
        private BindingList<ExpenseCategoryDto> _expenseCategories = [];
        public FrmExpenseCategory(ExpenseCategoryAppService appService)
        {
            InitializeComponent();
            _appService = appService;
            SetColorUI();

        }
        private void FrmExpenseCategory_Load(object sender, EventArgs e)
        {
            SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
            InvokeDataViewSetting();
            InvokeFilterAsync();
        }
        #region "Methods"
        private void InvokeDataViewSetting()
        {
            try
            {
                DataGridView.SetCustomDesign(new CustomDataGridViewParams
                {
                    EditColumnView = true,
                    EditColumnName = "EDITAR",
                });
                // Set custom columns
                ExpenseCategoryFormatingDGColumns.Apply(DataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearMessageErr()
        {
            errorProvider1.Clear();

            if (LabelAlertMessage.Text.Contains("Formulario"))
            {
                return;
            }

            SetMessage("Formulario preparado para recibir datos.", MessageType.Information);
        }
        private async Task SetInitialMessage(int seconds, Label messageLabel)
        {
            messageLabel.Click += (sender, e) =>
            {
                _cts?.Cancel();

            };
            try
            {
                // Cambiar a mensaje inicial
                var countdown = new CountdownTimer(seconds,
                    onCountdownFinished: () => SetMessage("Formulario preparado para recibir datos.", MessageType.Information));

                // Inicia la cuenta establecida en CountdownTimer y espera
                await countdown.StartAsync(_cts!.Token);
            }
            catch (OperationCanceledException)
            {
                // Captura la cancelación del temporizador
                SetMessage("Formulario preparado para recibir datos.", MessageType.Information);

            }
            finally
            {
                if (_cts != null)
                {
                    _cts.Dispose();
                    _cts = null;
                }
            }
        }
        private void SetMessage(string message, MessageType type)
        {

            var msg = new HandlerMessages(message, type);
            LabelAlertMessage.Text = $"{msg.Icon} {msg.Message}";
            LabelAlertMessage.ForeColor = msg.MessageColor;
        }
        private void SetColorUI()
        {
            // Set Backgroud color
            this.BackColor = AppColors.Surface;
            PanelButtom.BackColor = AppColors.Primary;
            PanelLineTop.BackColor = AppColors.Outline;
            PanelLineButtom.BackColor = AppColors.Outline;
            PanelAlertMessage.BackColor = AppColors.SurfaceMessage;


            // Btn
            BtnPersistence.IconColor = AppColors.Primary;
            BtnClear.IconColor = AppColors.Primary;

            // Label
            LabelTitle.ForeColor = AppColors.OnPrimary;
        }
        private void ValidationFields(string fieldName)
        {

            if (fieldName.Contains("Name"))
            {
                TextBoxName.Focus();
                errorProvider1.SetError(TextBoxName, "Aquí!");
            }
            


        }
        private void ClearFields()
        {
            ClearMessageErr();
            Id = Guid.Empty;
            TextBoxName.Text = string.Empty;

            BtnPersistence.Enabled = true;
            DataGridView.Refresh();
        }
        private async void InvokeGetByIdAsync()
        {
            var data = await _appService.GetByIdAsync(Id);

            Id = data.Id;
            TextBoxName.Text = data.Name;
            CbIsActive.Checked = data.IsActive;

        }
        private async void InvokeFilterAsync()
        {

            try
            {
                // Mostrar indicador de carga (opcional)
                LblLoadingData.Visible = true;
                DataGridView.Visible = false;

                // Llamada asíncrona al servicio de aplicación
                var result = await _appService.PaginationAsync(1, 100, true);
                var data = result.Data.ToList();
                // Convertir los datos en una lista enlazable
                _expenseCategories = new BindingList<ExpenseCategoryDto>(data);

                // Asignar el origen de datos
                DataGridView.DataSource = _expenseCategories;

                // Mostrar la grilla solo si hay registros
                DataGridView.Visible = _expenseCategories.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Siempre ocultar el indicador de carga
                LblLoadingData.Visible = false;
            }

        }

        #endregion

       

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            ClearMessageErr();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private async void BtnPersistence_Click(object sender, EventArgs e)
        {
            ClearMessageErr();
            _cts = new CancellationTokenSource();
            try
            {
                BtnPersistence.Enabled = false;
                var newDto = new ExpenseCategoryDto
                {
                    Id = Id,
                    Name = TextBoxName.Text.Trim(),
                    IsActive = CbIsActive.Checked,
                };
                Id = await _appService.PersistenceAsync(newDto);
                newDto.Id = Id;

                ExpenseCategoryUpdatingMemoryData.Excecute(newDto, _expenseCategories);
                DataGridView.DataSource = _expenseCategories;
                ClearFields();
            }
            catch (OperationCanceledException ex)
            {
                SetMessage(ex.Message, MessageType.Warning);
                // Set to 3 secons for alert
                await SetInitialMessage(3, LabelAlertMessage);
                BtnPersistence.Enabled = true;
            }
            catch (Exception ex)
            {
                var message = DomainMessageSplit.SplitMessage(ex.Message);
                ValidationFields(message.FieldName);

                SetMessage("Cerrar - " + message.Message, MessageType.Warning);

                // Set to 3 secons for alert
                await SetInitialMessage(4, LabelAlertMessage);
                BtnPersistence.Enabled = true;
            }
            finally
            {
                if (_cts != null)
                {
                    _cts.Dispose();
                    _cts = null;
                }
            }
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Clic Only on valid cell and column
            Id = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);

            if (DataGridView.Columns[e.ColumnIndex].Name == "editCol")
            {
                InvokeGetByIdAsync();
            }
        }
    }
}
