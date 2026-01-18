using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym_Manager_System.Model;
using Gym_Manager_System.Services.Interfaces;

namespace Gym_Manager_System.Forms
{
    public partial class ClassesForm : Form
    {
        private readonly IClassService _classService;
        private DataGridView classesGridView;
        private Button addButton;
        private Button generateButton;
        private Button refreshButton;
        private DateTimePicker fromDatePicker;
        private DateTimePicker toDatePicker;

        public ClassesForm(IClassService classService)
        {
            _classService = classService;
            InitializeComponent();
            LoadClasses();
        }

        private void InitializeComponent()
        {
            this.Text = "Classes Management";
            this.Size = new System.Drawing.Size(1200, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            // Filter panel
            var filterPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };

            var fromDateLabel = new Label { Text = "From:", Location = new System.Drawing.Point(10, 15), AutoSize = true };
            fromDatePicker = new DateTimePicker { Location = new System.Drawing.Point(50, 12), Width = 150 };
            fromDatePicker.Value = DateTime.Now;

            var toDateLabel = new Label { Text = "To:", Location = new System.Drawing.Point(220, 15), AutoSize = true };
            toDatePicker = new DateTimePicker { Location = new System.Drawing.Point(250, 12), Width = 150 };
            toDatePicker.Value = DateTime.Now.AddDays(30);

            filterPanel.Controls.AddRange(new Control[] { fromDateLabel, fromDatePicker, toDateLabel, toDatePicker });
            this.Controls.Add(filterPanel);

            // Create DataGridView
            classesGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                AllowUserToAddRows = false
            };

            // Create buttons panel
            var buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50
            };

            addButton = new Button
            {
                Text = "Add Class",
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(100, 30)
            };
            addButton.Click += AddButton_Click;

            generateButton = new Button
            {
                Text = "Generate from Schedule",
                Location = new System.Drawing.Point(120, 10),
                Size = new System.Drawing.Size(150, 30)
            };
            generateButton.Click += GenerateButton_Click;

            refreshButton = new Button
            {
                Text = "Refresh",
                Location = new System.Drawing.Point(280, 10),
                Size = new System.Drawing.Size(100, 30)
            };
            refreshButton.Click += (s, e) => LoadClasses();

            buttonPanel.Controls.AddRange(new Control[] { addButton, generateButton, refreshButton });

            this.Controls.Add(classesGridView);
            this.Controls.Add(buttonPanel);
        }

        private async void LoadClasses()
        {
            try
            {
                var classes = await _classService.GetAvailableClassesAsync(fromDatePicker.Value, toDatePicker.Value);
                classesGridView.DataSource = classes.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading classes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Implementation for adding a class manually
            MessageBox.Show("Add class functionality to be implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void GenerateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await _classService.GenerateClassInstancesFromScheduleAsync(fromDatePicker.Value, toDatePicker.Value);
                if (result)
                {
                    MessageBox.Show("Classes generated successfully from schedule.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadClasses();
                }
                else
                {
                    MessageBox.Show("No classes were generated.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating classes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

