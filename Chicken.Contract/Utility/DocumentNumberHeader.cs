using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken.Contract.Utility
{
    public class DocumentNumberHeader
    {
        [Key, Column(Order = 0)]
        public Int64 BranchID { get; set; }
        [Key, Column(Order = 1)]
        public string DocumentID { get; set; }
        [Key, Column(Order = 2)]
        public string DocumentKey { get; set; }
    }
}
