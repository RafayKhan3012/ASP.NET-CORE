using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class TblUsers
    {
        public TblUsers()
        {
            TblOutlet = new HashSet<TblOutlet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Role { get; set; }
        public DateTime? Date { get; set; }

        public ICollection<TblOutlet> TblOutlet { get; set; }
        public ICollection<tbl_CauseOfDeath> causeOfDeaths { get; set; }
    }
}
