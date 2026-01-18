using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym_Manager_System.Model;
using Gym_Manager_System.Services.Interfaces;

namespace Gym_Manager_System.Forms
{
    public partial class BookingDetailsForm : Form
    {
        private readonly IBookingService _bookingService;
        private readonly IMemberService _memberService;
        private readonly IClassService _classService;
        private readonly Booking? _booking;

        private ComboBox memberComboBox;
        private ComboBox classComboBox;
        private Button saveButton;
        private Button cancelButton;

        public BookingDetailsForm(IBookingService bookingService, IMemberService memberService, IClassService classService, Booking? booking)
        {
            _bookingService = bookingService;
            _memberService = memberService;
            _classService = classService;
            _booking = booking;
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = _booking == null ? "New Booking" : "Edit Booking";
            this.Size = new System.Drawing.Size(500, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            int yPos = 20;
            int labelWidth = 150;
            int comboBoxWidth = 300;

            // Member
            var memberLabel = new Label { Text = "Member:", Location = new System.Drawing.Point(20, yPos), Width = labelWidth };
            memberComboBox = new ComboBox { Location = new System.Drawing.Point(180, yPos), Width = comboBoxWidth, DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.AddRange(new Control[] { memberLabel, memberComboBox });
            yPos += 40;

            // Class Instance
            var classLabel = new Label { Text = "Class:", Location = new System.Drawing.Point(20, yPos), Width = labelWidth };
            classComboBox = new ComboBox { Location = new System.Drawing.Point(180, yPos), Width = comboBoxWidth, DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.AddRange(new Control[] { classLabel, classComboBox });
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

                // Load available classes
                var fromDate = DateTime.Now;
                var toDate = DateTime.Now.AddDays(30);
                var classes = await _classService.GetAvailableClassesAsync(fromDate, toDate);
                classComboBox.DisplayMember = "DisplayName";
                classComboBox.ValueMember = "ClassInstanceId";
                foreach (var classInstance in classes)
                {
                    classComboBox.Items.Add(new
                    {
                        ClassInstanceId = classInstance.ClassInstanceId,
                        DisplayName = $"{classInstance.ClassDate:yyyy-MM-dd} - {classInstance.StartTime:HH:mm}"
                    });
                }

                if (_booking != null)
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
                if (memberComboBox.SelectedItem == null || classComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select both member and class.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                var memberId = (int)memberComboBox.SelectedItem.GetType().GetProperty("Id")?.GetValue(memberComboBox.SelectedItem)!;
                var instanceId = (int)classComboBox.SelectedItem.GetType().GetProperty("ClassInstanceId")?.GetValue(classComboBox.SelectedItem)!;

                await _bookingService.CreateBookingAsync(memberId, instanceId);
                MessageBox.Show("Booking created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}

