using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Practice.Models
{
    public class tbl_CauseOfDeath
    {
        public int ID { get; set; }
        public string Cause { get; set; }
        public int? FK_User { get; set; }
        public TblUsers FK_UserNatigate { get; set; }


    }
}
