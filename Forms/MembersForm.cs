using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym_Manager_System.Model;
using Gym_Manager_System.Services.Interfaces;

namespace Gym_Manager_System.Forms
{
    public partial class MembersForm : Form
    {
        private readonly IMemberService _memberService;

        public MembersForm(IMemberService memberService)
        {
            _memberService = memberService;
            InitializeComponent();
            LoadMembers();
        }

        private async void LoadMembers()
        {
            try
            {
                var members = await _memberService.GetAllMembersAsync();
                membersGridView.DataSource = members.ToList();
                
                if (membersGridView.Columns.Count > 0)
                {
                    membersGridView.Columns["MemberId"].HeaderText = "ID";
                    membersGridView.Columns["FirstName"].HeaderText = "First Name";
                    membersGridView.Columns["LastName"].HeaderText = "Last Name";
                    membersGridView.Columns["Email"].HeaderText = "Email";
                    membersGridView.Columns["PhoneNumber"].HeaderText = "Phone";
                    membersGridView.Columns["Status"].HeaderText = "Status";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading members: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MembersGridView_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = membersGridView.SelectedRows.Count > 0;
            editButton.Enabled = hasSelection;
            deleteButton.Enabled = hasSelection;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new MemberDetailsForm(_memberService, null);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadMembers();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (membersGridView.SelectedRows.Count > 0)
            {
                var selectedRow = membersGridView.SelectedRows[0];
                var member = selectedRow.DataBoundItem as Member;
                if (member != null)
                {
                    var editForm = new MemberDetailsForm(_memberService, member);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadMembers();
                    }
                }
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (membersGridView.SelectedRows.Count > 0)
            {
                var selectedRow = membersGridView.SelectedRows[0];
                var member = selectedRow.DataBoundItem as Member;
                if (member != null)
                {
                    var result = MessageBox.Show(
                        $"Are you sure you want to delete {member.FirstName} {member.LastName}?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            var deleted = await _memberService.DeleteMemberAsync(member.MemberId);
                            if (deleted)
                            {
                                MessageBox.Show("Member deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadMembers();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting member: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadMembers();
        }
    }
}

