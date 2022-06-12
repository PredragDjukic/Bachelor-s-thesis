using System;
using System.Collections.Generic;

namespace Diplomski.DAL.Entities
{
    public partial class Rate
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public int Rate1 { get; set; }
        public int SessionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public virtual Session Session { get; set; } = null!;
    }
}
