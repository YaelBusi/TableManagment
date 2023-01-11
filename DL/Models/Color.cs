using System;
using System.Collections.Generic;

namespace DL.Models
{
    public partial class Color
    {
        public string Desc { get; set; } = null!;
        public string? Color1 { get; set; }
        public int? Price { get; set; }
        public int? Order { get; set; }
        public int Id { get; set; }
    }
}
