using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;

namespace Gym_Manager_System.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly DatabaseContext _context;

        public AttendanceRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<Attendance?> GetByIdAsync(int attendanceId)
        {
            throw new NotImplementedException();
        }

        public Task<Attendance?> GetByBookingIdAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Attendance>> GetByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Attendance>> GetByMemberIdAsync(int memberId, DateTime? fromDate, DateTime? toDate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(Attendance attendance)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Attendance attendance)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int attendanceId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Attendance>> GetByClassInstanceAsync(int instanceId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> HasAttendanceRecordAsync(int bookingId)
        {
            throw new NotImplementedException();
        }
        public Task<int> GetAttendanceCountForInstanceAsync(int instanceId)
        {
            throw new NotImplementedException();
        }
    }
}