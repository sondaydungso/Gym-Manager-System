using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Repositories;

namespace Gym_Manager_System.Forms
{
    public partial class InstructorsForm : Form
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorsForm()
        {
            // Initialize repository with the same connection string as MainForm
            var connectionString = "Server=54.252.85.7;Database=gym_management_system;UserID=admin_son;Password=son16012005;";
            var dbContext = new DatabaseContext(connectionString);
            _instructorRepository = new InstructorRepository(dbContext);
            
            InitializeComponent();
            LoadInstructors();
        }

        private async void LoadInstructors()
        {
            try
            {
                var instructors = await _instructorRepository.GetAllAsync();
                instructorsGridView.DataSource = instructors.ToList();
                
                if (instructorsGridView.Columns.Count > 0)
                {
                    instructorsGridView.Columns["InstructorId"].HeaderText = "ID";
                    instructorsGridView.Columns["FirstName"].HeaderText = "First Name";
                    instructorsGridView.Columns["LastName"].HeaderText = "Last Name";
                    instructorsGridView.Columns["Email"].HeaderText = "Email";
                    instructorsGridView.Columns["PhoneNumber"].HeaderText = "Phone";
                    instructorsGridView.Columns["Status"].HeaderText = "Status";
                    instructorsGridView.Columns["HireDate"].HeaderText = "Hire Date";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading instructors: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InstructorsGridView_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = instructorsGridView.SelectedRows.Count > 0;
            editButton.Enabled = hasSelection;
            deleteButton.Enabled = hasSelection;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new InstructorDetailsForm(_instructorRepository, null);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadInstructors();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (instructorsGridView.SelectedRows.Count > 0)
            {
                var selectedRow = instructorsGridView.SelectedRows[0];
                var instructor = selectedRow.DataBoundItem as Instructor;
                if (instructor != null)
                {
                    var editForm = new InstructorDetailsForm(_instructorRepository, instructor);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadInstructors();
                    }
                }
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (instructorsGridView.SelectedRows.Count > 0)
            {
                var selectedRow = instructorsGridView.SelectedRows[0];
                var instructor = selectedRow.DataBoundItem as Instructor;
                if (instructor != null)
                {
                    var result = MessageBox.Show(
                        $"Are you sure you want to delete {instructor.FirstName} {instructor.LastName}?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            var deleted = await _instructorRepository.DeleteAsync(instructor.InstructorId);
                            if (deleted)
                            {
                                MessageBox.Show("Instructor deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadInstructors();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete instructor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting instructor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadInstructors();
        }
    }
}


