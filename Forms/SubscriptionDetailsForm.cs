using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym_Manager_System.Model;
using Gym_Manager_System.Services.Interfaces;

namespace Gym_Manager_System.Forms
{
    public partial class SubscriptionDetailsForm : Form
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IMemberService _memberService;
        private readonly Subscription? _subscription;

        public SubscriptionDetailsForm(ISubscriptionService subscriptionService, IMemberService memberService, Subscription? subscription)
        {
            _subscriptionService = subscriptionService;
            _memberService = memberService;
            _subscription = subscription;
            InitializeComponent();
            if (_subscription != null)
            {
                this.Text = "Edit Subscription";
            }
            startDatePicker.Value = DateTime.Now;
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                // Load members
                var members = await _memberService.GetAllMembersAsync();
                memberComboBox.DisplayMember = "FullName";
                memberComboBox.ValueMember = "Id";
                foreach (var member in members)
                {
                    memberComboBox.Items.Add(new { Id = member.MemberId, FullName = $"{member.FirstName} {member.LastName}" });
                }

                // Note: Plan loading would need MembershipPlanRepository
                // For now, adding placeholder
                planComboBox.Items.Add(new { Id = 1, Name = "Basic Plan" });
                planComboBox.Items.Add(new { Id = 2, Name = "Premium Plan" });
                planComboBox.DisplayMember = "Name";
                planComboBox.ValueMember = "Id";

                if (_subscription != null)
                {
                    // Set selected values for edit mode
                    // Implementation for edit mode if needed
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (memberComboBox.SelectedItem == null || planComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select both member and plan.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                var memberId = (int)memberComboBox.SelectedItem.GetType().GetProperty("Id")?.GetValue(memberComboBox.SelectedItem)!;
                var planId = (int)planComboBox.SelectedItem.GetType().GetProperty("Id")?.GetValue(planComboBox.SelectedItem)!;
                var startDate = startDatePicker.Value;

                await _subscriptionService.CreateSubscriptionAsync(memberId, planId, startDate);
                MessageBox.Show("Subscription created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating subscription: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}


