using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISCOMMON.Entity
{
    public class ProjectBarshikAnyaBO
    {
        public int BarshikAnyaID { get; set; }
        public int ProjectId { get; set; }
        public Decimal FiscalYearId { get; set; }
        public Decimal FirstRakamAnya { get; set; }
        public Decimal SecondRakamAnya { get; set; }
        public Decimal ThirdRakamAnya { get; set; }
        public string RemarksAnya { get; set; }
        public string Mode { get; set; }
        public Decimal FirstAnyaPragati { get; set; }
        public Decimal SecondAnyaPragati { get; set; }
        public Decimal ThirdAnyaPragati { get; set; }
    }
}
