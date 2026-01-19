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
    public partial class RoomsForm : Form
    {
        private readonly IRoomRepository _roomRepository;

        public RoomsForm()
        {
            // Initialize repository with the same connection string as MainForm
            var connectionString = "Server=54.252.85.7;Database=gym_management_system;UserID=admin_son;Password=son16012005;";
            var dbContext = new DatabaseContext(connectionString);
            _roomRepository = new RoomRepository(dbContext);
            
            InitializeComponent();
            LoadRooms();
        }

        private async void LoadRooms()
        {
            try
            {
                var rooms = await _roomRepository.GetAllAsync();
                roomsGridView.DataSource = rooms.ToList();
                
                if (roomsGridView.Columns.Count > 0)
                {
                    roomsGridView.Columns["RoomId"].HeaderText = "ID";
                    roomsGridView.Columns["RoomName"].HeaderText = "Room Name";
                    roomsGridView.Columns["Capacity"].HeaderText = "Capacity";
                    roomsGridView.Columns["EquipmentAvailable"].HeaderText = "Equipment Available";
                    roomsGridView.Columns["Status"].HeaderText = "Status";
                    roomsGridView.Columns["CreatedAt"].HeaderText = "Created At";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RoomsGridView_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = roomsGridView.SelectedRows.Count > 0;
            editButton.Enabled = hasSelection;
            deleteButton.Enabled = hasSelection;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new RoomDetailsForm(_roomRepository, null);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadRooms();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (roomsGridView.SelectedRows.Count > 0)
            {
                var selectedRow = roomsGridView.SelectedRows[0];
                var room = selectedRow.DataBoundItem as Room;
                if (room != null)
                {
                    var editForm = new RoomDetailsForm(_roomRepository, room);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadRooms();
                    }
                }
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (roomsGridView.SelectedRows.Count > 0)
            {
                var selectedRow = roomsGridView.SelectedRows[0];
                var room = selectedRow.DataBoundItem as Room;
                if (room != null)
                {
                    var result = MessageBox.Show(
                        $"Are you sure you want to delete {room.RoomName}?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            var deleted = await _roomRepository.DeleteAsync(room.RoomId);
                            if (deleted)
                            {
                                MessageBox.Show("Room deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadRooms();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadRooms();
        }
    }
}

