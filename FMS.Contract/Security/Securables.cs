using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Security
{
    public class Securables
    {
        [Key, Column(Order = 0)]
        public Int32 SecurableID { get; set; }
        public Int64 RegistrationType { get; set; }
        public string PageID { get; set; }
        public string PageDescription { get; set; }
        public string OperationID { get; set; }
        public string OperationDescription { get; set; }
        public Int16 Type { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedBy { get; set; }
    }
}
