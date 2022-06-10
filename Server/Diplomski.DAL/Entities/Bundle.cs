using System;
using System.Collections.Generic;

namespace Diplomski.DAL.Entities
{
    public partial class Bundle
    {
        public Bundle()
        {
            Session = new HashSet<Session>();
        }

        public int Id { get; set; }
        public int SessionsLeft { get; set; }
        public int PackageId { get; set; }
        public int ExerciserId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual User Exerciser { get; set; } = null!;
        public virtual Package Package { get; set; } = null!;
        public virtual ICollection<Session> Session { get; set; }
    }
}
