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

        private ComboBox memberComboBox;
        private ComboBox planComboBox;
        private DateTimePicker startDatePicker;
        private Button saveButton;
        private Button cancelButton;

        public SubscriptionDetailsForm(ISubscriptionService subscriptionService, IMemberService memberService, Subscription? subscription)
        {
            _subscriptionService = subscriptionService;
            _memberService = memberService;
            _subscription = subscription;
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = _subscription == null ? "New Subscription" : "Edit Subscription";
            this.Size = new System.Drawing.Size(500, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            int yPos = 20;
            int labelWidth = 150;
            int controlWidth = 300;

            // Member
            var memberLabel = new Label { Text = "Member:", Location = new System.Drawing.Point(20, yPos), Width = labelWidth };
            memberComboBox = new ComboBox { Location = new System.Drawing.Point(180, yPos), Width = controlWidth, DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.AddRange(new Control[] { memberLabel, memberComboBox });
            yPos += 40;

            // Plan (would need to load from MembershipPlanRepository)
            var planLabel = new Label { Text = "Plan:", Location = new System.Drawing.Point(20, yPos), Width = labelWidth };
            planComboBox = new ComboBox { Location = new System.Drawing.Point(180, yPos), Width = controlWidth, DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.AddRange(new Control[] { planLabel, planComboBox });
            yPos += 40;

            // Start Date
            var startDateLabel = new Label { Text = "Start Date:", Location = new System.Drawing.Point(20, yPos), Width = labelWidth };
            startDatePicker = new DateTimePicker { Location = new System.Drawing.Point(180, yPos), Width = controlWidth };
            startDatePicker.Value = DateTime.Now;
            this.Controls.AddRange(new Control[] { startDateLabel, startDatePicker });
            yPos += 60;

            // Buttons
            saveButton = new Button
            {
                Text = "Save",
                Location = new System.Drawing.Point(180, yPos),
                Width = 100,
                DialogResult = DialogResult.OK
            };
            saveButton.Click += SaveButton_Click;

            cancelButton = new Button
            {
                Text = "Cancel",
                Location = new System.Drawing.Point(290, yPos),
                Width = 100,
                DialogResult = DialogResult.Cancel
            };

            this.Controls.AddRange(new Control[] { saveButton, cancelButton });
            this.AcceptButton = saveButton;
            this.CancelButton = cancelButton;
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

