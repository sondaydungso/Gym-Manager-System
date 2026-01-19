using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym_Manager_System.Model;
using Gym_Manager_System.Services.Interfaces;
using Gym_Manager_System.Repositories.Interfaces;
using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Repositories;

namespace Gym_Manager_System.Forms
{
    public partial class SubscriptionDetailsForm : Form
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IMemberService _memberService;
        private readonly IMembershipPlanRepository _membershipPlanRepository;
        private readonly Subscription? _subscription;

        public SubscriptionDetailsForm(ISubscriptionService subscriptionService, IMemberService memberService, Subscription? subscription)
        {
            _subscriptionService = subscriptionService;
            _memberService = memberService;
            _subscription = subscription;
            
            // Initialize repository with the same connection string as MainForm
            var connectionString = "Server=54.252.85.7;Database=gym_management_system;UserID=admin_son;Password=son16012005;";
            var dbContext = new DatabaseContext(connectionString);
            _membershipPlanRepository = new MembershipPlanRepository(dbContext);
            
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

                // Load membership plans from database
                var plans = await _membershipPlanRepository.GetActivePlansAsync();
                planComboBox.DisplayMember = "DisplayName";
                planComboBox.ValueMember = "PlanId";
                foreach (var plan in plans)
                {
                    planComboBox.Items.Add(new 
                    { 
                        PlanId = plan.PlanId, 
                        DisplayName = $"{plan.PlanName} - ${plan.PlanPrice:F2} ({plan.PlanDurationInMonths} months)" 
                    });
                }

                if (_subscription != null)
                {
                    // Set selected values for edit mode
                    startDatePicker.Value = _subscription.StartDate != default ? _subscription.StartDate : DateTime.Now;
                    
                    // Set selected member
                    foreach (var item in memberComboBox.Items)
                    {
                        var memberObj = item.GetType().GetProperty("Id")?.GetValue(item);
                        if (memberObj != null && (int)memberObj == _subscription.MemberId)
                        {
                            memberComboBox.SelectedItem = item;
                            break;
                        }
                    }
                    
                    // Set selected plan
                    foreach (var item in planComboBox.Items)
                    {
                        var planObj = item.GetType().GetProperty("PlanId")?.GetValue(item);
                        if (planObj != null && (int)planObj == _subscription.PlanId)
                        {
                            planComboBox.SelectedItem = item;
                            break;
                        }
                    }
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
                var planId = (int)planComboBox.SelectedItem.GetType().GetProperty("PlanId")?.GetValue(planComboBox.SelectedItem)!;
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


