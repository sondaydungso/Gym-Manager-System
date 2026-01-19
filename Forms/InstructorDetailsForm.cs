using System;
using System.Windows.Forms;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;

namespace Gym_Manager_System.Forms
{
    public partial class InstructorDetailsForm : Form
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly Instructor? _instructor;

        public InstructorDetailsForm(IInstructorRepository instructorRepository, Instructor? instructor)
        {
            _instructorRepository = instructorRepository;
            _instructor = instructor;
            InitializeComponent();
            if (_instructor != null)
            {
                this.Text = "Edit Instructor";
                statusComboBox.Items.AddRange(new[] { "active", "inactive" });
            }
            else
            {
                statusLabel.Visible = false;
                statusComboBox.Visible = false;
            }
            LoadInstructorData();
        }

        private void LoadInstructorData()
        {
            if (_instructor != null)
            {
                firstNameTextBox.Text = _instructor.FirstName ?? "";
                lastNameTextBox.Text = _instructor.LastName ?? "";
                emailTextBox.Text = _instructor.Email ?? "";
                phoneTextBox.Text = _instructor.PhoneNumber ?? "";
                hireDatePicker.Value = _instructor.HireDate != default ? _instructor.HireDate : DateTime.Now;
                certificationsTextBox.Text = _instructor.Certifications ?? "";
                specializationsTextBox.Text = _instructor.Specializations ?? "";
                if (statusComboBox != null && !string.IsNullOrEmpty(_instructor.Status))
                {
                    statusComboBox.SelectedItem = _instructor.Status;
                }
            }
            else
            {
                hireDatePicker.Value = DateTime.Now;
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(firstNameTextBox.Text))
                {
                    MessageBox.Show("First name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                if (string.IsNullOrWhiteSpace(lastNameTextBox.Text))
                {
                    MessageBox.Show("Last name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                if (string.IsNullOrWhiteSpace(emailTextBox.Text))
                {
                    MessageBox.Show("Email is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                var instructor = _instructor ?? new Instructor();
                instructor.FirstName = firstNameTextBox.Text;
                instructor.LastName = lastNameTextBox.Text;
                instructor.Email = emailTextBox.Text;
                instructor.PhoneNumber = phoneTextBox.Text;
                instructor.HireDate = hireDatePicker.Value;
                instructor.Certifications = certificationsTextBox.Text;
                instructor.Specializations = specializationsTextBox.Text;

                if (_instructor == null)
                {
                    // Create new instructor
                    instructor.Status = "active";
                    instructor.CreatedAt = DateTime.Now;
                    var result = await _instructorRepository.CreateAsync(instructor);
                    if (result > 0)
                    {
                        MessageBox.Show("Instructor created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Failed to create instructor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    // Update existing instructor
                    if (statusComboBox != null)
                    {
                        instructor.Status = statusComboBox.SelectedItem?.ToString() ?? "active";
                    }
                    var updated = await _instructorRepository.UpdateAsync(instructor);
                    if (updated)
                    {
                        MessageBox.Show("Instructor updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Failed to update instructor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving instructor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}

