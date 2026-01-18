using System;
using System.Windows.Forms;
using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Repositories;
using Gym_Manager_System.Repositories.Interfaces;
using Gym_Manager_System.Services.Concrete;
using Gym_Manager_System.Services.Interfaces;
using System.Drawing;

namespace Gym_Manager_System.Forms
{
    public partial class MainForm : Form
    {
        private IMemberService? _memberService;
        private IBookingService? _bookingService;
        private IClassService? _classService;
        private ISubscriptionService? _subscriptionService;

        public MainForm()
        {
            InitializeComponent();
            InitializeServices();
        }

        private void InitializeServices()
        {
            try
            {
                // Initialize dependencies
                var connectionString = "Server=54.252.85.7;Database=gym_management_system;UserID=admin_son;Password=son16012005;";
                
                // Test connection first
                string? connectionError = null;
                if (!TestDatabaseConnection(connectionString, out connectionError))
                {
                    var result = MessageBox.Show(
                        $"Failed to connect to the database.\n\n" +
                        $"Error: {connectionError ?? "Unknown error"}\n\n" +
                        $"Please verify:\n" +
                        $"1. Database server at 54.252.85.7 is running and accessible\n" +
                        $"2. Username 'admin_son' and password are correct\n" +
                        $"3. Database 'gym_management_system' exists\n" +
                        $"4. User 'admin_son' has access permissions to the database\n" +
                        $"5. Firewall allows connection to port 3306\n\n" +
                        $"Would you like to continue anyway? (Database features will not work)",
                        "Database Connection Error",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error);
                    
                    if (result == DialogResult.No)
                    {
                        Application.Exit();
                        return;
                    }
                    // Continue without services
                    return;
                }
                
                var dbContext = new DatabaseContext(connectionString);
                
                // Initialize repositories
                var memberRepository = new MemberRepository(dbContext);
                var bookingRepository = new BookingRepository(dbContext);
                var classInstanceRepository = new ClassInstanceRepository(dbContext);
                var classScheduleRepository = new ClassScheduleRepository(dbContext);
                var subscriptionRepository = new SubscriptionRepository(dbContext);
                var membershipPlanRepository = new MembershipPlanRepository(dbContext);
                var attendanceRepository = new AttendanceRepository(dbContext);
                
                // Initialize services
                _memberService = new MemberService(memberRepository);
                _bookingService = new BookingService(bookingRepository, classInstanceRepository, memberRepository, subscriptionRepository, attendanceRepository);
                _classService = new ClassService(classInstanceRepository, classScheduleRepository, bookingRepository);
                _subscriptionService = new SubscriptionService(subscriptionRepository, memberRepository, membershipPlanRepository, bookingRepository);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error initializing services: {ex.Message}\n\nPlease check your database connection settings.",
                    "Initialization Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool TestDatabaseConnection(string connectionString, out string? errorMessage)
        {
            errorMessage = null;
            try
            {
                var dbContext = new DatabaseContext(connectionString);
                using (var connection = dbContext.CreateConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }


        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ViewMembersMenuItem_Click(object sender, EventArgs e)
        {
            OpenMembersForm();
        }

        private void ViewBookingsMenuItem_Click(object sender, EventArgs e)
        {
            OpenBookingsForm();
        }

        private void ViewClassesMenuItem_Click(object sender, EventArgs e)
        {
            OpenClassesForm();
        }

        private void ViewSubscriptionsMenuItem_Click(object sender, EventArgs e)
        {
            OpenSubscriptionsForm();
        }

        private void OpenMembersForm()
        {
            if (_memberService == null)
            {
                MessageBox.Show("Database connection is not available. Please check your database settings.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var membersForm = new MembersForm(_memberService);
            membersForm.MdiParent = this;
            membersForm.Show();
        }

        private void OpenBookingsForm()
        {
            if (_bookingService == null || _memberService == null || _classService == null)
            {
                MessageBox.Show("Database connection is not available. Please check your database settings.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var bookingsForm = new BookingsForm(_bookingService, _memberService, _classService);
            bookingsForm.MdiParent = this;
            bookingsForm.Show();
        }

        private void OpenClassesForm()
        {
            if (_classService == null)
            {
                MessageBox.Show("Database connection is not available. Please check your database settings.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var classesForm = new ClassesForm(_classService);
            classesForm.MdiParent = this;
            classesForm.Show();
        }

        private void OpenSubscriptionsForm()
        {
            if (_subscriptionService == null || _memberService == null)
            {
                MessageBox.Show("Database connection is not available. Please check your database settings.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var subscriptionsForm = new SubscriptionsForm(_subscriptionService, _memberService);
            subscriptionsForm.MdiParent = this;
            subscriptionsForm.Show();
        }
    }
}

