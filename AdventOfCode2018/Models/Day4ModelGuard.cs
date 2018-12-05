using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.Models
{
    public class Day4ModelGuard
    {
        public int ID { get; set; }
        public int[] Minutes { get; set; } = new int[60];
        public int Month { get; set; }
        public int Date { get; set; }

        public int MinutesAsleep
        {
            get { return Minutes.Sum(); }
        }

        public string FormattedDate
        {
            get { return Month + "-" + (Date < 10 ? "0" + Date : "" + Date); }
        }
    }
}
