using System;
using System.Windows.Forms;
using Gym_Manager_System.Model;
using Gym_Manager_System.Services.Interfaces;

namespace Gym_Manager_System.Forms
{
    public partial class MemberDetailsForm : Form
    {
        private readonly IMemberService _memberService;
        private readonly Member? _member;
        
        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private TextBox emailTextBox;
        private TextBox phoneTextBox;
        private DateTimePicker dateOfBirthPicker;
        private TextBox emergencyContactNameTextBox;
        private TextBox emergencyContactPhoneTextBox;
        private TextBox medicalNotesTextBox;
        private ComboBox statusComboBox;
        private Button saveButton;
        private Button cancelButton;

        public MemberDetailsForm(IMemberService memberService, Member? member)
        {
            _memberService = memberService;
            _member = member;
            InitializeComponent();
            LoadMemberData();
        }

        private void InitializeComponent()
        {
            this.Text = _member == null ? "Add New Member" : "Edit Member";
            this.Size = new System.Drawing.Size(500, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            int yPos = 20;
            int labelWidth = 150;
            int textBoxWidth = 300;
            int spacing = 30;

            // First Name
            var firstNameLabel = new Label { Text = "First Name:", Location = new System.Drawing.Point(20, yPos), Width = labelWidth };
            firstNameTextBox = new TextBox { Location = new System.Drawing.Point(180, yPos), Width = textBoxWidth };
            this.Controls.AddRange(new Control[] { firstNameLabel, firstNameTextBox });
            yPos += spacing;

            // Last Name
            var lastNameLabel = new Label { Text = "Last Name:", Location = new System.Drawing.Point(20, yPos), Width = labelWidth };
            lastNameTextBox = new TextBox { Location = new System.Drawing.Point(180, yPos), Width = textBoxWidth };
            this.Controls.AddRange(new Control[] { lastNameLabel, lastNameTextBox });
            yPos += spacing;

            // Email
            var emailLabel = new Label { Text = "Email:", Location = new System.Drawing.Point(20, yPos), Width = labelWidth };
            emailTextBox = new TextBox { Location = new System.Drawing.Point(180, yPos), Width = textBoxWidth };
            this.Controls.AddRange(new Control[] { emailLabel, emailTextBox });
            yPos += spacing;

            // Phone
            var phoneLabel = new Label { Text = "Phone Number:", Location = new System.Drawing.Point(20, yPos), Width = labelWidth };
            phoneTextBox = new TextBox { Location = new System.Drawing.Point(180, yPos), Width = textBoxWidth };
            this.Controls.AddRange(new Control[] { phoneLabel, phoneTextBox });
            yPos += spacing;

            // Date of Birth
            var dobLabel = new Label { Text = "Date of Birth:", Location = new System.Drawing.Point(20, yPos), Width = labelWidth };
            dateOfBirthPicker = new DateTimePicker { Location = new System.Drawing.Point(180, yPos), Width = textBoxWidth };
            this.Controls.AddRange(new Control[] { dobLabel, dateOfBirthPicker });
            yPos += spacing;

            // Emergency Contact Name
            var emergencyNameLabel = new Label { Text = "Emergency Contact:", Location = new System.Drawing.Point(20, yPos), Width = labelWidth };
            emergencyContactNameTextBox = new TextBox { Location = new System.Drawing.Point(180, yPos), Width = textBoxWidth };
            this.Controls.AddRange(new Control[] { emergencyNameLabel, emergencyContactNameTextBox });
            yPos += spacing;

            // Emergency Contact Phone
            var emergencyPhoneLabel = new Label { Text = "Emergency Phone:", Location = new System.Drawing.Point(20, yPos), Width = labelWidth };
            emergencyContactPhoneTextBox = new TextBox { Location = new System.Drawing.Point(180, yPos), Width = textBoxWidth };
            this.Controls.AddRange(new Control[] { emergencyPhoneLabel, emergencyContactPhoneTextBox });
            yPos += spacing;

            // Medical Notes
            var medicalNotesLabel = new Label { Text = "Medical Notes:", Location = new System.Drawing.Point(20, yPos), Width = labelWidth };
            medicalNotesTextBox = new TextBox { Location = new System.Drawing.Point(180, yPos), Width = textBoxWidth, Height = 60, Multiline = true };
            this.Controls.AddRange(new Control[] { medicalNotesLabel, medicalNotesTextBox });
            yPos += 80;

            // Status (only for edit mode)
            if (_member != null)
            {
                var statusLabel = new Label { Text = "Status:", Location = new System.Drawing.Point(20, yPos), Width = labelWidth };
                statusComboBox = new ComboBox { Location = new System.Drawing.Point(180, yPos), Width = textBoxWidth, DropDownStyle = ComboBoxStyle.DropDownList };
                statusComboBox.Items.AddRange(new[] { "active", "inactive", "suspended" });
                this.Controls.AddRange(new Control[] { statusLabel, statusComboBox });
                yPos += spacing;
            }

            // Buttons
            saveButton = new Button
            {
                Text = "Save",
                Location = new System.Drawing.Point(180, yPos + 20),
                Width = 100,
                DialogResult = DialogResult.OK
            };
            saveButton.Click += SaveButton_Click;

            cancelButton = new Button
            {
                Text = "Cancel",
                Location = new System.Drawing.Point(290, yPos + 20),
                Width = 100,
                DialogResult = DialogResult.Cancel
            };

            this.Controls.AddRange(new Control[] { saveButton, cancelButton });
            this.AcceptButton = saveButton;
            this.CancelButton = cancelButton;
        }

        private void LoadMemberData()
        {
            if (_member != null)
            {
                firstNameTextBox.Text = _member.FirstName ?? "";
                lastNameTextBox.Text = _member.LastName ?? "";
                emailTextBox.Text = _member.Email ?? "";
                phoneTextBox.Text = _member.PhoneNumber ?? "";
                dateOfBirthPicker.Value = _member.DateOfBirth != default ? _member.DateOfBirth : DateTime.Now.AddYears(-25);
                emergencyContactNameTextBox.Text = _member.Emergency_contact_name ?? "";
                emergencyContactPhoneTextBox.Text = _member.Emergency_contact_phone ?? "";
                medicalNotesTextBox.Text = _member.Medical_notes ?? "";
                if (statusComboBox != null && !string.IsNullOrEmpty(_member.Status))
                {
                    statusComboBox.SelectedItem = _member.Status;
                }
            }
            else
            {
                dateOfBirthPicker.Value = DateTime.Now.AddYears(-25);
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var member = _member ?? new Member();
                member.FirstName = firstNameTextBox.Text;
                member.LastName = lastNameTextBox.Text;
                member.Email = emailTextBox.Text;
                member.PhoneNumber = phoneTextBox.Text;
                member.DateOfBirth = dateOfBirthPicker.Value;
                member.Emergency_contact_name = emergencyContactNameTextBox.Text;
                member.Emergency_contact_phone = emergencyContactPhoneTextBox.Text;
                member.Medical_notes = medicalNotesTextBox.Text;

                if (_member == null)
                {
                    // Create new member
                    member.JoinDate = DateTime.Now;
                    member.Status = "active";
                    await _memberService.CreateMemberAsync(member);
                    MessageBox.Show("Member created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Update existing member
                    if (statusComboBox != null)
                    {
                        member.Status = statusComboBox.SelectedItem?.ToString() ?? "active";
                    }
                    var updated = await _memberService.UpdateMemberAsync(member);
                    if (updated)
                    {
                        MessageBox.Show("Member updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving member: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}

