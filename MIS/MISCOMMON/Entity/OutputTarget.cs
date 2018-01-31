using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISCOMMON.Entity
{
    public class OutputTarget
    {
        public Decimal ActivityOutputId { get; set; }
        public String ActivityOutputEngName { get; set; }
        public String ActivityOutputNepName { get; set; }
        public String ActivityOutputCode { get; set; }
        public Decimal ActivityOutputTypeId { get; set; }
        public String ToipYear { get; set; }
        public Decimal SubSectorId { get; set; }
        public string Mode { get; set; }
        public decimal IsEnable { get; set; }
        public decimal IsLocked { get; set; }
        public string Lang { get; set; }

        public Decimal TargetId { get; set; }
        public string TargetFirstYear { get; set; }
        public string TargetSecondYear { get; set; }
        public string TargetThirdYear { get; set; }
        public Decimal ActivityOutputMapId { get; set; }
        public Decimal FiscalYearId { get; set; }
        public decimal SectorId { get; set; }

        //for project
        public string OverallTarget { get; set; }
        public string BaseYearTarget { get; set; }
        public decimal ProjectId { get; set; }
        public decimal FrameworkId { get; set; }
        public decimal PtargetId { get; set; }

        public string PustyayiyekoShrot { get; set; }
        public string ResponsibleOfficeId { get; set; }

        public int MinistryId { get; set; }
        public int ParentOutputId { get; set; }
    }
}
