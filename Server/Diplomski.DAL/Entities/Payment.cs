using System;
using System.Collections.Generic;

namespace Diplomski.DAL.Entities
{
    public partial class Payment
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int ExerciserId { get; set; }
        public int TrainerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public virtual User Exerciser { get; set; } = null!;
        public virtual User Trainer { get; set; } = null!;
    }
}
