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
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;
        private string _phoneNumber = string.Empty;
        private string _certifications = string.Empty;
        private string _specializations = string.Empty;
        private DateTime _hireDate;
        private string _status = string.Empty;
        private DateTime _createdAt;
        public string Status { get => _status; set => _status = value; }

        public int InstructorId { get => _instructorId; set => _instructorId = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Certifications { get => _certifications; set => _certifications = value; }
        public string Specializations { get => _specializations; set => _specializations = value; }
        public DateTime HireDate { get => _hireDate; set => _hireDate = value; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }

    }
}
