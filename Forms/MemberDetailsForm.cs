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

        public MemberDetailsForm(IMemberService memberService, Member? member)
        {
            _memberService = memberService;
            _member = member;
            InitializeComponent();
            if (_member != null)
            {
                this.Text = "Edit Member";
                statusComboBox.Items.AddRange(new[] { "active", "inactive", "suspended" });
            }
            else
            {
                statusLabel.Visible = false;
                statusComboBox.Visible = false;
            }
            LoadMemberData();
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


