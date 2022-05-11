using System;
using System.Collections.Generic;

namespace Diplomski.DAL.Entities
{
    public partial class Package
    {
        public Package()
        {
            Bundle = new HashSet<Bundle>();
        }

        public int Id { get; set; }
        public int NumberOfSessions { get; set; }
        public decimal Price { get; set; }
        public int TrainerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Bundle> Bundle { get; set; }
    }
}
