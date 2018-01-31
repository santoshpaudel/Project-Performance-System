using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISCOMMON.Entity
{
    public class ProjectOutputTBarsikBO
    {
        public Decimal PTargetBId { get; set; }
        public String PTargetFirstC { get; set; }
        public String PTargetSecondC { get; set; }
        public String PTargetThirdC { get; set; }
        public String PTargetFirstP { get; set; }
        public String PTargetSecondP { get; set; }
        public String PTargetThirdP { get; set; }
        public Decimal PTargetId { get; set; }
        public String EntryDate { get; set; }
        public Decimal Isenable { get; set; }
        public Decimal Islocked { get; set; }
        public Decimal ProjectId { get; set; }
        public Decimal FiscalYearId { get; set; }
        public int ChaumasikId { get; set; }
        public string Mode { get; set; }
        public string Lang { get; set; }
        public int ProjectOutputId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
