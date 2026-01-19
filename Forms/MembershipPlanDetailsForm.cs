using System;
using System.Windows.Forms;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;

namespace Gym_Manager_System.Forms
{
    public partial class MembershipPlanDetailsForm : Form
    {
        private readonly IMembershipPlanRepository _membershipPlanRepository;
        private readonly MembershipPlan? _plan;

        public MembershipPlanDetailsForm(IMembershipPlanRepository membershipPlanRepository, MembershipPlan? plan)
        {
            _membershipPlanRepository = membershipPlanRepository;
            _plan = plan;
            InitializeComponent();
            if (_plan != null)
            {
                this.Text = "Edit Membership Plan";
            }
            LoadPlanData();
        }

        private void LoadPlanData()
        {
            if (_plan != null)
            {
                planNameTextBox.Text = _plan.PlanName ?? "";
                durationMonthsNumericUpDown.Value = _plan.PlanDurationInMonths > 0 ? _plan.PlanDurationInMonths : 1;
                priceNumericUpDown.Value = _plan.PlanPrice > 0 ? _plan.PlanPrice : 0;
                maxClassesNumericUpDown.Value = _plan.MaxClassPerMonth > 0 ? _plan.MaxClassPerMonth : 0;
                descriptionTextBox.Text = _plan.PlanDescription ?? "";
            }
            else
            {
                durationMonthsNumericUpDown.Value = 1;
                priceNumericUpDown.Value = 0;
                maxClassesNumericUpDown.Value = 0;
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(planNameTextBox.Text))
                {
                    MessageBox.Show("Plan name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                if (durationMonthsNumericUpDown.Value <= 0)
                {
                    MessageBox.Show("Duration must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                if (priceNumericUpDown.Value < 0)
                {
                    MessageBox.Show("Price cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                var plan = _plan ?? new MembershipPlan();
                plan.PlanName = planNameTextBox.Text;
                plan.PlanDurationInMonths = (int)durationMonthsNumericUpDown.Value;
                plan.PlanPrice = priceNumericUpDown.Value;
                plan.MaxClassPerMonth = (int)maxClassesNumericUpDown.Value;
                plan.PlanDescription = descriptionTextBox.Text;

                if (_plan == null)
                {
                    // Create new plan
                    plan.CreatedAt = DateTime.Now;
                    var result = await _membershipPlanRepository.CreateAsync(plan);
                    if (result > 0)
                    {
                        MessageBox.Show("Membership plan created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Failed to create membership plan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    // Update existing plan
                    var updated = await _membershipPlanRepository.UpdateAsync(plan);
                    if (updated)
                    {
                        MessageBox.Show("Membership plan updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Failed to update membership plan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving membership plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}

