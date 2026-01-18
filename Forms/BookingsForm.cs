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
        private DataGridView bookingsGridView;
        private Button addButton;
        private Button cancelButton;
        private Button checkInButton;
        private Button refreshButton;
        private ComboBox memberFilterComboBox;

        public BookingsForm(IBookingService bookingService, IMemberService memberService, IClassService classService)
        {
            _bookingService = bookingService;
            _memberService = memberService;
            _classService = classService;
            InitializeComponent();
            LoadBookings();
            LoadMembers();
        }

        private void InitializeComponent()
        {
            this.Text = "Bookings Management";
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

            var allMembersOption = new { Id = 0, Name = "All Members" };
            memberFilterComboBox.DisplayMember = "Name";
            memberFilterComboBox.ValueMember = "Id";

            filterPanel.Controls.AddRange(new Control[] { memberFilterLabel, memberFilterComboBox });
            this.Controls.Add(filterPanel);

            // Create DataGridView
            bookingsGridView = new DataGridView
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
                Text = "New Booking",
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(100, 30)
            };
            addButton.Click += AddButton_Click;

            cancelButton = new Button
            {
                Text = "Cancel Booking",
                Location = new System.Drawing.Point(120, 10),
                Size = new System.Drawing.Size(100, 30),
                Enabled = false
            };
            cancelButton.Click += CancelBookingButton_Click;

            checkInButton = new Button
            {
                Text = "Check In",
                Location = new System.Drawing.Point(230, 10),
                Size = new System.Drawing.Size(100, 30),
                Enabled = false
            };
            checkInButton.Click += CheckInButton_Click;

            refreshButton = new Button
            {
                Text = "Refresh",
                Location = new System.Drawing.Point(340, 10),
                Size = new System.Drawing.Size(100, 30)
            };
            refreshButton.Click += (s, e) => LoadBookings();

            bookingsGridView.SelectionChanged += (s, e) =>
            {
                bool hasSelection = bookingsGridView.SelectedRows.Count > 0;
                cancelButton.Enabled = hasSelection;
                checkInButton.Enabled = hasSelection;
            };

            buttonPanel.Controls.AddRange(new Control[] { addButton, cancelButton, checkInButton, refreshButton });

            this.Controls.Add(bookingsGridView);
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
            }
        }
    

