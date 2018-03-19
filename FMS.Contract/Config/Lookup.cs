using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Config
{
    public class Lookup
    {
        [Key, Column(Order = 0)]
        public Int16 LookupID { get; set; }
        public string LookupCode { get; set; }
        public string LookupDescription { get; set; }
        public string LookupCategory { get; set; }
        public bool Status { get; set; }
        public string ISOCode { get; set; }
        public string MappingCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
