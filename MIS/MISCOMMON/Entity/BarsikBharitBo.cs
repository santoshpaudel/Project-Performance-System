using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISCOMMON.Entity
{
    public class BarsikBharitBo
    {
        public int BarshikBharitId { get; set; }
        public int  ProjectId { get; set; }
        public int FiscalYearId { get; set; }
        public Decimal BarshikBharitLakshya { get; set; }
        public Decimal FirstBharitLakshya { get; set; }
        public Decimal SecondBharitLakshya { get; set; }
        public Decimal ThirdBharitLakshya { get; set; }
        public string Mode { get; set; }
    }
}
