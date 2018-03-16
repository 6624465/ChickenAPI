using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Utility
{
   public class DocumentNumberDetail
    {
        [Key, Column(Order = 0)]
        public Int64 BranchID { get; set; }
        [Key, Column(Order = 1)]
        public string DocumentKey { get; set; }
        [Key, Column(Order = 2)]
        public Int16 YearNo { get; set; }
    }
}
