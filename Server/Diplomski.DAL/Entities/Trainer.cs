using System;
using System.Collections.Generic;

namespace Diplomski.DAL.Entities
{
    public partial class Trainer
    {
        public string Bio { get; set; } = null!;
        public int Experience { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
