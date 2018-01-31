using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISCOMMON.Entity
{
    /// <summary>
    /// Activity_detail tables object
    /// </summary>
    public class ActivityDetailBO
    {
        public Decimal ActivityDetailId { get; set; }
        public String ActivityDetailEngName { get; set; }
        public String ActivityDetailNepName { get; set; }
        public Decimal ActivityUnitId { get; set; }
        public Decimal Isenable { get; set; }
        public Decimal Islocked { get; set; }
        public Decimal ActivitySubSectorId { get; set; }
        public string Lang { get; set; }
        public string Mode { get; set; }
    }
}
