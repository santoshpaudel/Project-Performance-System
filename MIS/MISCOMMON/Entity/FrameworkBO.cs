using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISCOMMON.Entity
{
    public class FrameworkBO
    {
        public int FrameworkId { get; set; }
        public string FrameworkEngName { get; set; }
        public string FrameworkNepName { get; set; }
        public int BaseYearId { get; set; }
        public int FirstYearId { get; set; }
        public int SecondYearId { get; set; }
        public int ThirdYearId { get; set; }
        public string Mode { get; set; }
        public decimal IsEnable { get; set; }
        public decimal IsLocked { get; set; }
        public string Lang { get; set; }
    }
}
