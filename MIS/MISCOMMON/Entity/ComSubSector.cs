using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISCOMMON.Entity
{
    public class ComSubSector
    {
        public Decimal SubSectorId { get; set; }
        public String SubSectorEngName { get; set; }
        public String SubSectorNepName { get; set; }
        public String SubSectorCode { get; set; }
        public Decimal SectorId { get; set; }
        public Decimal Isenable { get; set; }
        public Decimal Islocked { get; set; }
        public String Mode { get; set; }
        public String Lang { get; set; }
    }
}
