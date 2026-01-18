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
        private DataGridView subscriptionsGridView;
        private Button addButton;
        private Button renewButton;
        private Button cancelButton;
        private Button refreshButton;
        private ComboBox memberFilterComboBox;

        public SubscriptionsForm(ISubscriptionService subscriptionService, IMemberService memberService)
        {
            _subscriptionService = subscriptionService;
            _memberService = memberService;
            InitializeComponent();
            LoadSubscriptions();
            LoadMembers();
        }

        private void InitializeComponent()
        {
            this.Text = "Subscriptions Management";
            this.Size = new System.Drawing.Size(1200, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            // Filter panel
            var filterPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };

            var memberFilterLabel = new Label
            {
                Text = "Filter by Member:",
                Location = new System.Drawing.Point(10, 15),
                AutoSize = true
            };

            memberFilterComboBox = new ComboBox
            {
                Location = new System.Drawing.Point(120, 12),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            memberFilterComboBox.SelectedIndexChanged += MemberFilterComboBox_SelectedIndexChanged;

            filterPanel.Controls.AddRange(new Control[] { memberFilterLabel, memberFilterComboBox });
            this.Controls.Add(filterPanel);

            // Create DataGridView
            subscriptionsGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                AllowUserToAddRows = false
            };

            // Create buttons panel
            var buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50
            };

            addButton = new Button
            {
                Text = "New Subscription",
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(120, 30)
            };
            addButton.Click += AddButton_Click;

            renewButton = new Button
            {
                Text = "Renew",
                Location = new System.Drawing.Point(140, 10),
                Size = new System.Drawing.Size(100, 30),
                Enabled = false
            };
            renewButton.Click += RenewButton_Click;

            cancelButton = new Button
            {
                Text = "Cancel",
                Location = new System.Drawing.Point(250, 10),
                Size = new System.Drawing.Size(100, 30),
                Enabled = false
            };
            cancelButton.Click += CancelButton_Click;

            refreshButton = new Button
            {
                Text = "Refresh",
                Location = new System.Drawing.Point(360, 10),
                Size = new System.Drawing.Size(100, 30)
            };
            refreshButton.Click += (s, e) => LoadSubscriptions();

            subscriptionsGridView.SelectionChanged += (s, e) =>
            {
                bool hasSelection = subscriptionsGridView.SelectedRows.Count > 0;
                renewButton.Enabled = hasSelection;
                cancelButton.Enabled = hasSelection;
            };

            buttonPanel.Controls.AddRange(new Control[] { addButton, renewButton, cancelButton, refreshButton });

            this.Controls.Add(subscriptionsGridView);
            this.Controls.Add(buttonPanel);
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
                    ? await _subscriptionService.GetMemberSubscriptionsAsync(0) // This needs to be fixed
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
    }
}

