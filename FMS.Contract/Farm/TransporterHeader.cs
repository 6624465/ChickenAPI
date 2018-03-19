using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Farm
{
    public class TransporterHeader
    {
        [Key, Column(Order = 0)]
        public Int32 FarmID { get; set; }
        [Key, Column(Order = 1)]
        public Int32 TransporterID { get; set; }
        public string TransporterName { get; set; }
        public string TransporterAddress { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string LineID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
