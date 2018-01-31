using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISCOMMON.Entity
{
    public class ProjectUpalabdhiBO
    {
        public Decimal UplabdhiId { get; set; }
        public Decimal ProjectId { get; set; }
        public Decimal FiscalYearId { get; set; }
        public String FirstCDesc { get; set; }
        public String SecondCDesc { get; set; }
        public String ThirdCDesc { get; set; }
        public string Mode { get; set; }
    }
}
