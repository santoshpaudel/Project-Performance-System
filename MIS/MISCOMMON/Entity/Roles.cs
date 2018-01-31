using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISCOMMON.Entity
{
    public class Roles
    {
        public Decimal RoleId { get; set; }
        public String RoleEngName { get; set; }
        public String RoleNepName { get; set; }
        public Decimal Isenable { get; set; }
        public Decimal Islocked { get; set; }
        public String Mode { get; set; }
        public String Lang { get; set; }
    }
}
