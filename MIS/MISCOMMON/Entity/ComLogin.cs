using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISCOMMON.Entity
{
    public class ComLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int FiscalYearId { get; set; }
        public string Lang { get; set; }
        public string NewPassword { get; set; }
        public int UserId { get; set; }
    }
}
