using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym_Manager_System.Model;
using Gym_Manager_System.Services.Interfaces;
using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Repositories;
using Gym_Manager_System.Repositories.Interfaces;

namespace Gym_Manager_System.Forms
{
    public partial class ClassDetailsForm : Form
    {
        private readonly IClassService _classService;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ClassInstance? _classInstance;

        public ClassDetailsForm(IClassService classService, ClassInstance? classInstance = null)
        {
            _classService = classService;
            _classInstance = classInstance;
            
            // Initialize repositories with the same connection string as MainForm
            var connectionString = "Server=54.252.85.7;Database=gym_management_system;UserID=admin_son;Password=son16012005;";
            var dbContext = new DatabaseContext(connectionString);
            _instructorRepository = new InstructorRepository(dbContext);
            _roomRepository = new RoomRepository(dbContext);
            
            InitializeComponent();
            if (_classInstance != null)
            {
                this.Text = "Edit Class";
            }
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                // Load instructors
                var instructors = await _instructorRepository.GetActiveInstructorsAsync();
                instructorComboBox.DisplayMember = "FullName";
                instructorComboBox.ValueMember = "InstructorId";
                foreach (var instructor in instructors)
                {
                    instructorComboBox.Items.Add(new { InstructorId = instructor.InstructorId, FullName = $"{instructor.FirstName} {instructor.LastName}" });
                }

                // Load rooms
                var rooms = await _roomRepository.GetAvailableRoomsAsync();
                roomComboBox.DisplayMember = "RoomName";
                roomComboBox.ValueMember = "RoomId";
                foreach (var room in rooms)
                {
                    roomComboBox.Items.Add(new { RoomId = room.RoomId, RoomName = $"{room.RoomName} (Capacity: {room.Capacity})" });
                }

                // Load status options
                statusComboBox.Items.AddRange(new[] { "scheduled", "in_progress", "completed", "cancelled" });

                if (_classInstance != null)
                {
                    // Set selected values for edit mode
                    classDatePicker.Value = _classInstance.ClassDate != default ? _classInstance.ClassDate : DateTime.Now;
                    startTimePicker.Value = DateTime.Today.Add(_classInstance.StartTime.ToTimeSpan());
                    endTimePicker.Value = DateTime.Today.Add(_classInstance.EndTime.ToTimeSpan());
                    capacityNumericUpDown.Value = _classInstance.Capacity;
                    statusComboBox.SelectedItem = _classInstance.Status;
                    
                    // Set instructor and room selections
                    foreach (var item in instructorComboBox.Items)
                    {
                        var instructorObj = item.GetType().GetProperty("InstructorId")?.GetValue(item);
                        if (instructorObj != null && (int)instructorObj == _classInstance.InstructorId)
                        {
                            instructorComboBox.SelectedItem = item;
                            break;
                        }
                    }
                    
                    foreach (var item in roomComboBox.Items)
                    {
                        var roomObj = item.GetType().GetProperty("RoomId")?.GetValue(item);
                        if (roomObj != null && (int)roomObj == _classInstance.RoomId)
                        {
                            roomComboBox.SelectedItem = item;
                            break;
                        }
                    }
                }
                else
                {
                    classDatePicker.Value = DateTime.Now;
                    startTimePicker.Value = DateTime.Today.AddHours(9); // Default 9 AM
                    endTimePicker.Value = DateTime.Today.AddHours(10); // Default 10 AM
                    capacityNumericUpDown.Value = 20;
                    statusComboBox.SelectedItem = "scheduled";
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
                if (instructorComboBox.SelectedItem == null || roomComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select both instructor and room.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                var instructorId = (int)instructorComboBox.SelectedItem.GetType().GetProperty("InstructorId")?.GetValue(instructorComboBox.SelectedItem)!;
                var roomId = (int)roomComboBox.SelectedItem.GetType().GetProperty("RoomId")?.GetValue(roomComboBox.SelectedItem)!;
                var classDate = classDatePicker.Value.Date;
                var startTime = TimeOnly.FromDateTime(startTimePicker.Value);
                var endTime = TimeOnly.FromDateTime(endTimePicker.Value);
                var capacity = (int)capacityNumericUpDown.Value;
                var status = statusComboBox.SelectedItem?.ToString() ?? "scheduled";

                if (startTime >= endTime)
                {
                    MessageBox.Show("Start time must be before end time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                if (classDate < DateTime.Now.Date)
                {
                    MessageBox.Show("Class date cannot be in the past.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                var instance = _classInstance ?? new ClassInstance();
                instance.ClassDate = classDate;
                instance.StartTime = startTime;
                instance.EndTime = endTime;
                instance.InstructorId = instructorId;
                instance.RoomId = roomId;
                instance.Capacity = capacity;
                instance.Status = status;
                // For manual classes, we need to handle schedule_id differently
                // Since the database requires a valid schedule_id, we'll need to check if NULL is allowed
                // For now, we'll try to use a special value or handle it in the repository
                // Note: This may require database schema change to allow NULL schedule_id
                instance.ClassScheduleId = 0; // Manual class, not from schedule - will be set to NULL in repository
                instance.CreatedAt = DateTime.Now; // Ensure CreatedAt is set
                instance.CurrentBookings = 0; // Initialize current bookings

                var createdInstance = await _classService.CreateClassInstanceAsync(instance);
                if (createdInstance != null)
                {
                    MessageBox.Show("Class created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Failed to create class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating class: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}

