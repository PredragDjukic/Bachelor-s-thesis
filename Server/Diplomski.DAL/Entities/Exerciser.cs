using System;
using System.Collections.Generic;

namespace Diplomski.DAL.Entities
{
    public partial class Exerciser
    {
        public int Id { get; set; }
        public int ExerciseHistory { get; set; }
        public int Goal { get; set; }
        public string MessageForCoaches { get; set; } = null!;
        public string EmergencyContactFullName { get; set; } = null!;
        public string EmergencyContactPhoneNumber { get; set; } = null!;
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual User? User { get; set; }
    }
}
