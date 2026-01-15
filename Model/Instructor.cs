using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Model
{
    public class Instructor
    {
        private int _instructorId;
        private string? _firstName;
        private string? _lastName;
        private string? _email;
        private string? _phoneNumber;
        private string? _certifications;
        private string? _specializations;
        private DateTime _hireDate;
        public enum Status { Active, Inactive}
        private DateTime _createdAt;

        public int InstructorId { get => _instructorId; set => _instructorId = value; }
        public string? FirstName { get => _firstName; set => _firstName = value; }
        public string? LastName { get => _lastName; set => _lastName = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string? Certifications { get => _certifications; set => _certifications = value; }
        public string? Specializations { get => _specializations; set => _specializations = value; }
        public DateTime HireDate { get => _hireDate; set => _hireDate = value; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }

    }
}
