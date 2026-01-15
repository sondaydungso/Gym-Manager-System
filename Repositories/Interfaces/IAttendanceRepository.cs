using Gym_Manager_System.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<Attendance?> GetByIdAsync(int attendanceId);
        Task<Attendance?> GetByBookingIdAsync(int bookingId);
        Task<IEnumerable<Attendance>> GetByDateAsync(DateTime date);
        Task<IEnumerable<Attendance>> GetByMemberIdAsync(int memberId, DateTime? fromDate, DateTime? toDate);
        Task<IEnumerable<Attendance>> GetByClassInstanceAsync(int instanceId);
        Task<int> CreateAsync(Attendance attendance);
        Task<bool> UpdateAsync(Attendance attendance);
        Task<bool> DeleteAsync(int attendanceId);
        Task<bool> HasAttendanceRecordAsync(int bookingId);
        Task<int> GetAttendanceCountForInstanceAsync(int instanceId);
    }
}



