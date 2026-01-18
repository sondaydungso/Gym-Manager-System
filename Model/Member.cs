using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Model
{
    public class Member
    {
        private int _memberId;
        private string? _firstName;
        private string? _lastName;
        private string? _email;
        private string? _phoneNumber;
        private DateTime _dateOfBirth;
        private DateTime _joinDate;
        private string _status;
        private string? _emergency_contact_name;
        private string? _emergency_contact_phone;
        private string? _medical_notes;


        public int MemberId { get => _memberId; set => _memberId = value; }
        public string? FirstName { get => _firstName; set => _firstName = value; }
        public string? LastName { get => _lastName; set => _lastName = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public DateTime JoinDate { get => _joinDate; set => _joinDate = value; }
        public string? Emergency_contact_name { get => _emergency_contact_name; set => _emergency_contact_name = value; }
        public string? Emergency_contact_phone { get => _emergency_contact_phone; set => _emergency_contact_phone = value; }
        public string? Medical_notes { get => _medical_notes; set => _medical_notes = value; }
        public string Status { get => _status; set => _status = value; }


    }
}
