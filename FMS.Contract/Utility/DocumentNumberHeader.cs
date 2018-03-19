using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Utility
{
    public class DocumentNumberHeader
    {
        [Key, Column(Order = 0)]
        public Int64 BranchID { get; set; }
        [Key, Column(Order = 1)]
        public string DocumentID { get; set; }
        [Key, Column(Order = 2)]
        public string DocumentKey { get; set; }
        public string DocumentPrefix { get; set; }
        public Int16 NumberLength { get; set; }
        public Int16 LastNumber { get; set; }
        public bool UseCompany { get; set; }
        public bool UseBranch { get; set; }
        public bool UseYear { get; set; }
        public bool UseMonth { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
