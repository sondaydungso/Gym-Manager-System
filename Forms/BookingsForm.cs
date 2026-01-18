using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym_Manager_System.Model;
using Gym_Manager_System.Services.Interfaces;

namespace Gym_Manager_System.Forms
{
    public partial class BookingsForm : Form
    {
        private readonly IBookingService _bookingService;
        private readonly IMemberService _memberService;
        private readonly IClassService _classService;

        public BookingsForm(IBookingService bookingService, IMemberService memberService, IClassService classService)
        {
            _bookingService = bookingService;
            _memberService = memberService;
            _classService = classService;
            InitializeComponent();
            LoadBookings();
            LoadMembers();
        }

        private async void LoadMembers()
        {
            try
            {
                var members = await _memberService.GetAllMembersAsync();
                memberFilterComboBox.Items.Clear();
                memberFilterComboBox.DisplayMember = "Name";
                memberFilterComboBox.ValueMember = "Id";
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

        private async void LoadBookings()
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

                var bookings = memberId == 0
                    ? await _bookingService.GetMemberBookingsAsync(0) // This needs to be fixed - get all bookings
                    : await _bookingService.GetMemberBookingsAsync(memberId);

                bookingsGridView.DataSource = bookings.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MemberFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBookings();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new BookingDetailsForm(_bookingService, _memberService, _classService, null);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadBookings();
            }
        }

        private async void CancelBookingButton_Click(object sender, EventArgs e)
        {
            if (bookingsGridView.SelectedRows.Count > 0)
            {
                var selectedRow = bookingsGridView.SelectedRows[0];
                var booking = selectedRow.DataBoundItem as Booking;
                if (booking != null)
                {
                    var reasonForm = new Form
                    {
                        Text = "Cancel Booking",
                        Size = new System.Drawing.Size(400, 150),
                        StartPosition = FormStartPosition.CenterParent,
                        FormBorderStyle = FormBorderStyle.FixedDialog
                    };
                    var reasonTextBox = new TextBox { Location = new System.Drawing.Point(10, 10), Width = 360, Multiline = true, Height = 50 };
                    var okButton = new Button { Text = "OK", Location = new System.Drawing.Point(200, 70), DialogResult = DialogResult.OK };
                    var cancelBtn = new Button { Text = "Cancel", Location = new System.Drawing.Point(280, 70), DialogResult = DialogResult.Cancel };
                    reasonForm.Controls.AddRange(new Control[] { reasonTextBox, okButton, cancelBtn });
                    reasonForm.AcceptButton = okButton;
                    reasonForm.CancelButton = cancelBtn;

                    if (reasonForm.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(reasonTextBox.Text))
                    {
                        var reason = reasonTextBox.Text;
                        {
                            try
                            {
                                var cancelled = await _bookingService.CancelBookingAsync(booking.BookingId, reason);
                                if (cancelled)
                                {
                                    MessageBox.Show("Booking cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadBookings();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error cancelling booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private async void CheckInButton_Click(object sender, EventArgs e)
        {
            if (bookingsGridView.SelectedRows.Count > 0)
            {
                var selectedRow = bookingsGridView.SelectedRows[0];
                var booking = selectedRow.DataBoundItem as Booking;
                if (booking != null)
                {
                    try
                    {
                        var checkedIn = await _bookingService.CheckInMemberAsync(booking.BookingId);
                        if (checkedIn)
                        {
                            MessageBox.Show("Member checked in successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBookings();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error checking in member: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadBookings();
        }

        private void BookingsGridView_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = bookingsGridView.SelectedRows.Count > 0;
            cancelButton.Enabled = hasSelection;
            checkInButton.Enabled = hasSelection;
        }
    }
}

