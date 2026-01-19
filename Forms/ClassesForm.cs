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

        public ClassesForm(IClassService classService)
        {
            _classService = classService;
            InitializeComponent();
            fromDatePicker.Value = DateTime.Now;
            toDatePicker.Value = DateTime.Now.AddDays(30);
            LoadClasses();
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
            var addForm = new ClassDetailsForm(_classService, null);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadClasses();
            }
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

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadClasses();
        }
    }
}


