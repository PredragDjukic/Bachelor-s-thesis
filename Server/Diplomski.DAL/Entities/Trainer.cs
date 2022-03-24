using System;
using System.Collections.Generic;

namespace Diplomski.DAL.Entities
{
    public partial class Trainer
    {
        public int Id { get; set; }
        public string Bio { get; set; } = null!;
        public int Experience { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual User? User { get; set; }
    }
}
