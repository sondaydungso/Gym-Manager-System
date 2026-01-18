using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Model
{
    public class ClassType
    {
        private int _classTypeId;
        private string _classTypeName = string.Empty;
        private string _classTypeDescription = string.Empty;
        private int _durationInMinutes;
        private int _capacity;
        public enum DifficultyLevel { Beginner, Intermediate, Advanced }
        private DateTime _createdAt;

        public int ClassTypeId { get => _classTypeId; set => _classTypeId = value; }
        public string ClassTypeName { get => _classTypeName; set => _classTypeName = value; }
        public string ClassTypeDescription { get => _classTypeDescription; set => _classTypeDescription = value; }
        public int DurationInMinutes { get => _durationInMinutes; set => _durationInMinutes = value; }
        public int Capacity { get => _capacity; set => _capacity = value; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }

    }
}
