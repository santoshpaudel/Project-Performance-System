using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISCOMMON.Entity
{
    public class ActivityOutputMapBO
    {
        public Decimal ActivityOutputMapId { get; set; }
        public Decimal ActivityDetailId { get; set; }
        public Decimal ActivityOutputId { get; set; }
        public Decimal FiscalYearId { get; set; }
        public Decimal Isenabled { get; set; }
        public Decimal Islocked { get; set; }
        public string Lang { get; set; }
        public string Mode { get; set; }
    }
}
