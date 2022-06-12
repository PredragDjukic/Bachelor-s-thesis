using System;
using System.Collections.Generic;

namespace Diplomski.DAL.Entities
{
    public partial class Session
    {
        public Session()
        {
            Rate = new HashSet<Rate>();
        }

        public int Id { get; set; }
        public int? SessionNumber { get; set; }
        public string Location { get; set; } = null!;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int Status { get; set; }
        public int TrainerId { get; set; }
        public int? ExerciserId { get; set; }
        public int? BundleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public virtual Bundle? Bundle { get; set; }
        public virtual User? Exerciser { get; set; }
        public virtual User Trainer { get; set; } = null!;
        public virtual ICollection<Rate> Rate { get; set; }
    }
}
