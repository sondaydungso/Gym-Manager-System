using System;
using System.Windows.Forms;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;

namespace Gym_Manager_System.Forms
{
    public partial class RoomDetailsForm : Form
    {
        private readonly IRoomRepository _roomRepository;
        private readonly Room? _room;

        public RoomDetailsForm(IRoomRepository roomRepository, Room? room)
        {
            _roomRepository = roomRepository;
            _room = room;
            InitializeComponent();
            if (_room != null)
            {
                this.Text = "Edit Room";
                statusComboBox.Items.AddRange(new[] { "available", "maintenance", "closed" });
            }
            else
            {
                statusLabel.Visible = false;
                statusComboBox.Visible = false;
            }
            LoadRoomData();
        }

        private void LoadRoomData()
        {
            if (_room != null)
            {
                roomNameTextBox.Text = _room.RoomName ?? "";
                capacityNumericUpDown.Value = _room.Capacity > 0 ? _room.Capacity : 1;
                equipmentAvailableTextBox.Text = _room.EquipmentAvailable ?? "";
                if (statusComboBox != null && !string.IsNullOrEmpty(_room.Status))
                {
                    statusComboBox.SelectedItem = _room.Status;
                }
            }
            else
            {
                capacityNumericUpDown.Value = 1;
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(roomNameTextBox.Text))
                {
                    MessageBox.Show("Room name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                if (capacityNumericUpDown.Value <= 0)
                {
                    MessageBox.Show("Capacity must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                var room = _room ?? new Room();
                room.RoomName = roomNameTextBox.Text;
                room.Capacity = (int)capacityNumericUpDown.Value;
                room.EquipmentAvailable = equipmentAvailableTextBox.Text;

                if (_room == null)
                {
                    // Create new room
                    room.Status = "available";
                    room.CreatedAt = DateTime.Now;
                    var result = await _roomRepository.CreateAsync(room);
                    if (result > 0)
                    {
                        MessageBox.Show("Room created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Failed to create room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    // Update existing room
                    if (statusComboBox != null)
                    {
                        room.Status = statusComboBox.SelectedItem?.ToString() ?? "available";
                    }
                    var updated = await _roomRepository.UpdateAsync(room);
                    if (updated)
                    {
                        MessageBox.Show("Room updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Failed to update room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}

