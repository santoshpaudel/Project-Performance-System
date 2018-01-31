using System;

namespace MISCOMMON
{
    public class ComMenuRolePermissionBO
    {
        public Decimal PermissionMapId { get; set; }
        public Decimal RoleId { get; set; }
        public Decimal MenuId { get; set; }
        public Decimal AllowAdd { get; set; }
        public Decimal AllowDelete { get; set; }
        public Decimal AllowEdit { get; set; }
        public Decimal AllowVerifyLevel1 { get; set; }
        public Decimal AllowVerifyLevel2 { get; set; }
        public Decimal AllowVerifyLevel3 { get; set; }
        public Decimal AllowVerifyLevel4 { get; set; }
        public Decimal AllowView { get; set; }
        public string Mode { get; set; }
        public string PermissionMode { get; set; }//determine which column to update allowadd,allowedit
    }
}
