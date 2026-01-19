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
    public partial class MembershipPlansForm : Form
    {
        private readonly IMembershipPlanRepository _membershipPlanRepository;

        public MembershipPlansForm()
        {
            // Initialize repository with the same connection string as MainForm
            var connectionString = "Server=54.252.85.7;Database=gym_management_system;UserID=admin_son;Password=son16012005;";
            var dbContext = new DatabaseContext(connectionString);
            _membershipPlanRepository = new MembershipPlanRepository(dbContext);
            
            InitializeComponent();
            LoadPlans();
        }

        private async void LoadPlans()
        {
            try
            {
                var plans = await _membershipPlanRepository.GetAllAsync();
                plansGridView.DataSource = plans.ToList();
                
                if (plansGridView.Columns.Count > 0)
                {
                    plansGridView.Columns["PlanId"].HeaderText = "ID";
                    plansGridView.Columns["PlanName"].HeaderText = "Plan Name";
                    plansGridView.Columns["PlanDurationInMonths"].HeaderText = "Duration (Months)";
                    plansGridView.Columns["PlanPrice"].HeaderText = "Price";
                    plansGridView.Columns["MaxClassPerMonth"].HeaderText = "Max Classes/Month";
                    plansGridView.Columns["PlanDescription"].HeaderText = "Description";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading plans: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PlansGridView_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = plansGridView.SelectedRows.Count > 0;
            editButton.Enabled = hasSelection;
            deleteButton.Enabled = hasSelection;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new MembershipPlanDetailsForm(_membershipPlanRepository, null);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadPlans();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (plansGridView.SelectedRows.Count > 0)
            {
                var selectedRow = plansGridView.SelectedRows[0];
                var plan = selectedRow.DataBoundItem as MembershipPlan;
                if (plan != null)
                {
                    var editForm = new MembershipPlanDetailsForm(_membershipPlanRepository, plan);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadPlans();
                    }
                }
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (plansGridView.SelectedRows.Count > 0)
            {
                var selectedRow = plansGridView.SelectedRows[0];
                var plan = selectedRow.DataBoundItem as MembershipPlan;
                if (plan != null)
                {
                    var result = MessageBox.Show(
                        $"Are you sure you want to delete {plan.PlanName}?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            var deleted = await _membershipPlanRepository.DeleteAsync(plan.PlanId);
                            if (deleted)
                            {
                                MessageBox.Show("Plan deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadPlans();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete plan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadPlans();
        }
    }
}

