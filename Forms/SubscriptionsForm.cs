using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym_Manager_System.Model;
using Gym_Manager_System.Services.Interfaces;

namespace Gym_Manager_System.Forms
{
    public partial class SubscriptionsForm : Form
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IMemberService _memberService;

        public SubscriptionsForm(ISubscriptionService subscriptionService, IMemberService memberService)
        {
            _subscriptionService = subscriptionService;
            _memberService = memberService;
            InitializeComponent();
            LoadSubscriptions();
            LoadMembers();
        }

        private async void LoadMembers()
        {
            try
            {
                var members = await _memberService.GetAllMembersAsync();
                memberFilterComboBox.Items.Clear();
                memberFilterComboBox.Items.Add(new { Id = 0, Name = "All Members" });
                foreach (var member in members)
                {
                    memberFilterComboBox.Items.Add(new { Id = member.MemberId, Name = $"{member.FirstName} {member.LastName}" });
                }
                memberFilterComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading members: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadSubscriptions()
        {
            try
            {
                var selectedMember = memberFilterComboBox.SelectedItem;
                int memberId = 0;
                if (selectedMember != null)
                {
                    var memberObj = selectedMember.GetType().GetProperty("Id")?.GetValue(selectedMember);
                    if (memberObj != null)
                    {
                        memberId = (int)memberObj;
                    }
                }

                var subscriptions = memberId == 0
                    ? await _subscriptionService.GetAllSubscriptionsAsync() // Fetch all subscriptions when memberId is 0
                    : await _subscriptionService.GetMemberSubscriptionsAsync(memberId);

                subscriptionsGridView.DataSource = subscriptions.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subscriptions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MemberFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubscriptions();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new SubscriptionDetailsForm(_subscriptionService, _memberService, null);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadSubscriptions();
            }
        }

        private async void RenewButton_Click(object sender, EventArgs e)
        {
            if (subscriptionsGridView.SelectedRows.Count > 0)
            {
                var selectedRow = subscriptionsGridView.SelectedRows[0];
                var subscription = selectedRow.DataBoundItem as Subscription;
                if (subscription != null)
                {
                    try
                    {
                        var renewed = await _subscriptionService.RenewSubscriptionAsync(subscription.SubscriptionId);
                        if (renewed)
                        {
                            MessageBox.Show("Subscription renewed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadSubscriptions();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error renewing subscription: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void CancelButton_Click(object sender, EventArgs e)
        {
            if (subscriptionsGridView.SelectedRows.Count > 0)
            {
                var selectedRow = subscriptionsGridView.SelectedRows[0];
                var subscription = selectedRow.DataBoundItem as Subscription;
                if (subscription != null)
                {
                    var result = MessageBox.Show(
                        "Are you sure you want to cancel this subscription?",
                        "Confirm Cancel",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            var cancelled = await _subscriptionService.CancelSubscriptionAsync(subscription.SubscriptionId);
                            if (cancelled)
                            {
                                MessageBox.Show("Subscription cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadSubscriptions();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error cancelling subscription: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadSubscriptions();
        }

        private void SubscriptionsGridView_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = subscriptionsGridView.SelectedRows.Count > 0;
            renewButton.Enabled = hasSelection;
            cancelButton.Enabled = hasSelection;
        }

        private void SubscriptionsForm_Load(object sender, EventArgs e)
        {

        }
    }
}


