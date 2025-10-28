using AMartinezTech.Application.Insurance;
using AMartinezTech.Application.Policy;
using AMartinezTech.Application.Policy.DTOs;
using AMartinezTech.Application.Reports.Policies.Interfaces;
using AMartinezTech.Domain.Utils.Enums;
using AMartinezTech.WinForms.Cash.Income;
using AMartinezTech.WinForms.Policy.Utils;
using AMartinezTech.WinForms.Utils;
using AMartinezTech.WinForms.Utils.Factories;
using FontAwesome.Sharp;
using System.ComponentModel;

namespace AMartinezTech.WinForms.Policy;

public partial class FrmPolicyDashboardView : Form
{
    #region "Fields"
    private readonly IFormFactory _formFactory;
    private readonly IPolicyReportService _policyReportService;
    private CancellationTokenSource? _cts;
    private bool _isChangeValueControl = false;
    private BindingList<PolicyDto> _list = [];
    private readonly PolicyAppService _applicationService;
    private readonly InsuranceAppServices _insuranceApplicationServices;

    #endregion

    #region "Constructor"
    public FrmPolicyDashboardView(IFormFactory formFactory, PolicyAppService applicationService, IPolicyReportService policyReportService, InsuranceAppServices insuranceApplicationServices)
    {
        InitializeComponent();
        _formFactory = formFactory;
        _applicationService = applicationService;
        _policyReportService = policyReportService;
        SetColorUI();
        _insuranceApplicationServices = insuranceApplicationServices;
    }
    #endregion

    #region "Form Events"

    private void FrmPolicyDashboardView_Load(object sender, EventArgs e)
    {
        InvokeDataViewSetting();
        DataGridView.EnableDoubleBuffering();
        FillComboBoxStatus();
        FillInsurance();
        FillPolicyType();
        InvokeFilterAsync();
        SetMessage("Alertas!", MessageType.Information);
    }
    #endregion

    #region "Methods"
    private async void LoadPolicyStatusChart()
    {
        var report = await _policyReportService.GetPolicyReportAsync();
        var summaries = report.Summary.ToList();

        int cardWidth = 300;
        int cardHeight = 80;
        int spacing = 5;
        int totalPolicies = 0;

        PanelLeyenda1.Controls.Clear();
        PanelLeyenda2.Controls.Clear();

        for (int i = 0; i < summaries.Count; i++)
        {
            var summary = summaries[i];
            totalPolicies += summary.Total;

            // Crear la tarjeta
            Panel card = new()
            {
                Width = cardWidth,
                Height = cardHeight,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Label para Status
            Label lblStatus = new()
            {
                Text = $"Estado: {summary.Status}",
                Location = new Point(10, 10),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            card.Controls.Add(lblStatus);

            // Label para Total
            Label lblTotal = new()
            {
                Text = $"Total: {summary.Total}",
                Location = new Point(10, 35),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };
            card.Controls.Add(lblTotal);

            // Label para Porcentaje
            Label lblPercentage = new()
            {
                Text = $"Porcentaje: {summary.Percentage:F2}%",
                Location = new Point(150, 35),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };
            card.Controls.Add(lblPercentage);

            // Calcular posición vertical dentro del panel correspondiente
            int yOffset = ((i % 2) * (cardHeight + spacing));

            // Agregar la tarjeta al panel correspondiente
            if (i < 2)
            {
                card.Location = new Point(10, yOffset);
                PanelLeyenda1.Controls.Add(card);
            }
            else
            {
                card.Location = new Point(10, yOffset);
                PanelLeyenda2.Controls.Add(card);
            }
        }


        PanelLeyenda_1.Controls.Clear();
        PanelLeyenda_2.Controls.Clear();


        int yOffset1 = 10;
        int yOffset2 = 10;

        // Creamos tarjeta para Active Pendientes
        Panel cardPending = new()
        {
            Width = 250,
            Height = 60,
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Location = new Point(10, yOffset1)
        };
        cardPending.Controls.Add(new Label() { Text = $"PENDIENTES DE PAGO", Location = new Point(10, 5), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold) });
        cardPending.Controls.Add(new Label() { Text = $"Total: {report.ActivePendingCount}", Location = new Point(10, 30), AutoSize = true });
        cardPending.Controls.Add(new Label() { Text = $"Porcentaje: {report.ActivePendingPercentage:F2}%", Location = new Point(125, 30), AutoSize = true });

        PanelLeyenda_1.Controls.Add(cardPending);

        // Creamos tarjeta para Active Al día
        Panel cardOnTime = new()
        {
            Width = 250,
            Height = 60,
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Location = new Point(10, yOffset2)
        };
        cardOnTime.Controls.Add(new Label() { Text = $"PAGO AL DÍA", Location = new Point(10, 5), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold) });
        cardOnTime.Controls.Add(new Label() { Text = $"Total: {report.ActiveOnTimeCount}", Location = new Point(10, 30), AutoSize = true });
        cardOnTime.Controls.Add(new Label() { Text = $"Porcentaje: {report.ActiveOnTimePercentage:F2}%", Location = new Point(125, 30), AutoSize = true });

        PanelLeyenda_2.Controls.Add(cardOnTime);
        // Accedes a los totales de las activas:
        var pendingCount = report.ActivePendingCount;
        var onTimeCount = report.ActiveOnTimeCount;
        var pendingPercentage = report.ActivePendingPercentage;
        var onTimePercentage = report.ActiveOnTimePercentage;

        // Para Label:
        LabelPayPendingPolicy.Text = $"Pendientes: {pendingCount} ({pendingPercentage:F2}%), Al día: {onTimeCount} ({onTimePercentage:F2}%)";
    }
    private void FillComboBoxStatus()
    {
        var statuses = Enum.GetValues<PolicyStatus>()
            .Cast<PolicyStatus>()
            .Select(e => new
            {
                Value = e,
                Text = e.GetDisplayName()
            })
            .ToList();

        Status.DataSource = statuses;
        Status.DisplayMember = "Text";
        Status.ValueMember = "Value";
    }
    private void FillPolicyType()
    {
        var statuses = Enum.GetValues<PolicyTypes>()
            .Cast<PolicyTypes>()
            .Select(e => new
            {
                Value = e,
                Text = e.GetDisplayName()
            })
            .ToList();
        //statuses.Insert(0, item: new { Value = (PolicyTypes)"All", Text = "[Todas]" });
        PolicyType.DataSource = statuses;
        PolicyType.DisplayMember = "Text";
        PolicyType.ValueMember = "Value";
        PolicyType.SelectedIndex = 0;
    }
    private async void FillInsurance()
    {
        var result = await _insuranceApplicationServices.FilterAsync();
        // Crear una lista y agregar la opción "Todas"
        var list = result.ToList();
        list.Insert(0, new InsuranceDto { Id = Guid.Empty, Name = "[Todas]" });

        Insurance.DataSource = list;
        Insurance.DisplayMember = "Name";
        Insurance.ValueMember = "Id";
        Insurance.SelectedIndex = 0;
    }
    private async void InvokeFilterAsync()
    {
        try
        {
            // Detiene el repintado del DataGridView temporalmente
            DataGridView.SuspendLayout();
            DataGridView.DataSource = null;

            var filters = new Dictionary<string, object?>();

            if (Status.SelectedValue != null && Status.SelectedValue.ToString() != "[Todas]")
                filters["status"] = Status.SelectedValue.ToString();

            if (PolicyType.SelectedValue != null && PolicyType.SelectedValue.ToString() != "[Todas]")
                filters["policy_type"] = PolicyType.SelectedValue.ToString();

            if (Insurance.SelectedValue != null && Guid.TryParse(Insurance.SelectedValue.ToString(), out var insuranceId) && insuranceId != Guid.Empty)
            {
                filters["insurance_id"] = insuranceId;
            }

           

            var searchText = TextBoxSearch.Text.Trim();
            var search = new Dictionary<string, object?>
            {
                ["CONCAT(c.first_name, ' ', c.last_name)"] = searchText,
                ["i.name"] = searchText,
                ["c.doc_identity"] = searchText
            };


            // Ejecuta el filtro en un hilo separado para no bloquear la UI
            var result = await Task.Run(() => _applicationService.FilterAsync(filters, search));

            if (PayStatus.Text != string.Empty)
            {
                filters["insurance_id"] = PayStatus.Text;
            }
            var filterByPayStatus = result.Where(x => x.PendingPayment == PayStatus.Text).ToList();

            // Reactiva el repintado y asigna el resultado
            _list = new BindingList<PolicyDto>(filterByPayStatus);
            DataGridView.DataSource = _list;
            DataGridView.TranslateEnumColumns("PolicyType");

            // Traducir solo las columnas de enum
            LoadPolicyStatusChart();
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
    private void InvokeDataViewSetting()
    {
        try
        {
            DataGridView.SetCustomDesign(new CustomDataGridViewParams
            {
                EditColumnView = true,
                EditColumnName = "EDITAR",
                MenuColumnView = true,
            });
            // Set custom columns
            FormatingDGColumns.Apply(DataGridView);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void SetColorUI()
    {
        // Set Backgroud color
        this.BackColor = AppColors.Surface;
        PanelLineTop.BackColor = AppColors.Outline;
        PanelTopFilter1.BackColor = AppColors.Outline;
        PanelTopFilter2.BackColor = AppColors.Outline;
        LabelTitle.ForeColor = AppColors.OnSurface;

        //Buttons icon color
        IconPictureBoxSearch.IconColor = AppColors.Primary;
        IconPictureBox.IconColor = AppColors.Primary;
        BtnInsurance.IconColor = AppColors.Primary;
        BtnPrintList.IconColor = AppColors.Primary;

    }
    private void OpenFrmPolicy(Guid policyId)
    {
        var frmPolicyView = _formFactory.CreateFormFactory<FrmPolicyView>();
        frmPolicyView.PolicyId = policyId;

        if (frmPolicyView.ShowDialog() == DialogResult.OK)
        {
            var newClient = frmPolicyView.Policy;

            if (newClient != null)
            {
                InvokeFilterAsync();
            }
            //LoadClientTypeChart();
        }
    }
    private void ClearMessageErr()
    {
        errorProvider1.Clear();

        if (LabelAlertMessage.Text.Contains("Alertas"))
        {
            return;
        }

        SetMessage("Alertas!", MessageType.Information);
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
                onCountdownFinished: () => SetMessage("Alertas!", MessageType.Information));

            // Inicia la cuenta establecida en CountdownTimer y espera
            await countdown.StartAsync(_cts!.Token);
        }
        catch (OperationCanceledException)
        {
            // Captura la cancelación del temporizador
            SetMessage("Alertas!", MessageType.Information);
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
    private async Task SafeExecuteAsync(Func<Task> action)
    {
        ClearMessageErr();
        _cts = new CancellationTokenSource();
        try
        {
            await action();
        }
        catch (OperationCanceledException ex)
        {
            SetMessage(ex.Message, MessageType.Warning);
            // Set to 3 secons for alert
            await SetInitialMessage(3, LabelAlertMessage);

        }
        catch (Exception ex)
        {
            var message = DomainMessageSplit.SplitMessage(ex.Message);

            SetMessage("Cerrar - " + message.Message, MessageType.Warning);

            // Set to 3 secons for alert
            await SetInitialMessage(4, LabelAlertMessage);

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
    #endregion

    #region "Field Events" 
    private void TextBoxSearch_Enter(object sender, EventArgs e)
    {
        if (_isChangeValueControl)
        {
            _isChangeValueControl = false;
            InvokeFilterAsync();
        }
    }
    private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
            InvokeFilterAsync();

    }
    private void ComboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        _isChangeValueControl = true;
        TextBoxSearch.Focus();
    }
    private void ComboBoxStatus_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
    private void PolicyType_SelectedIndexChanged(object sender, EventArgs e)
    {
        _isChangeValueControl = true;
        TextBoxSearch.Focus();
    }
    private void PolicyType_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
    private void Insurance_SelectedIndexChanged(object sender, EventArgs e)
    {
        _isChangeValueControl = true;
        TextBoxSearch.Focus();
    }
    private void Insurance_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
    private void PayStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        _isChangeValueControl = true;
        TextBoxSearch.Focus();
    }

    private void PayStatus_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = true;
    }
    #endregion

    #region "Btn Events"
    private void BtnInsurance_Click(object sender, EventArgs e)
    {
        OpenFrmPolicy(Guid.Empty);
    }
    #endregion

    #region "DataGridView Events"
    private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Clic Only on valid cell and column

        if (DataGridView.Columns[e.ColumnIndex].Name == "editCol")
        {
            Guid policyId = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);
            OpenFrmPolicy(policyId);
        }
        else if (DataGridView.Columns[e.ColumnIndex].Name == "menuCol")
        {

            var status = DataGridView.Rows[e.RowIndex].Cells["Status"].Value?.ToString();


            // Obtener el ID de la póliza seleccionada
            Guid policyId = Guid.Parse(DataGridView.Rows[e.RowIndex].Cells["Id"].Value!.ToString()!);

            // Crear el menú contextual
            var contextMenu = new ContextMenuStrip();

            // Crear las opciones del menú
            if (status == "Active")
            {
                var cancelItem = new ToolStripMenuItem("→ Cancelar", null, async (s, ev)
               => await SafeExecuteAsync(async () =>
               {
                   await _applicationService.CancelAsync(policyId, true);
                   Status.SelectedValue = PolicyStatus.Canceled;
               }));


                var suspendItem = new ToolStripMenuItem("→ Suspender", null, async (s, ev)
                    => await SafeExecuteAsync(async () =>
                    {
                        await _applicationService.SuspendAsync(policyId, true);
                        Status.SelectedValue = PolicyStatus.Suspended;

                    }
                ));


                // Agregar las opciones al menú
                contextMenu.Items.AddRange([cancelItem, suspendItem]);
            }

            if (status == "Inactive" || status == "Suspended")
            {
                var activateItem = new ToolStripMenuItem("→ Activar", null, async (s, ev)
              => await SafeExecuteAsync(async () =>
              {
                  await _applicationService.ActiveAsync(policyId);
                  Status.SelectedValue = PolicyStatus.Active;

              }));


                contextMenu.Items.AddRange([activateItem]);
            }


            // Evaluar si la póliza tiene pago pendiente
            var pendingStatus = DataGridView.Rows[e.RowIndex].Cells["PendingPayment"].Value?.ToString();

            if (pendingStatus == "Pendiente" && status == "Active")
            {

                // Separador antes del pago
                contextMenu.Items.Add(new ToolStripSeparator());

                var payItem = new ToolStripMenuItem("→ Cobrar", null, async (s, ev) =>
                await SafeExecuteAsync(async () =>
                    {
                        var frmIncomeView = _formFactory.CreateFormFactory<FrmIncomeView>();
                        frmIncomeView.PolicyId = policyId;
                        frmIncomeView.ShowDialog();
                        await Task.CompletedTask;
                        if (frmIncomeView.DialogResult == DialogResult.OK)
                        {
                            InvokeFilterAsync();
                        }
                    })
                );

                // Insertarlo al inicio del menú
                contextMenu.Items.Add(payItem);

            }

            // Mostrar el menú en la posición del clic
            var cellRectangle = DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            var menuX = DataGridView.PointToScreen(new Point(cellRectangle.Left + 20, cellRectangle.Bottom));
            contextMenu.Cursor = Cursors.Hand;
            contextMenu.Show(menuX);


        }

    }
    #endregion


  
}
