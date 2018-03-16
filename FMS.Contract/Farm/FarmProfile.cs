using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Farm
{
   public class FarmProfile
    {
        [Key, Column(Order = 0)]
        public Int32 FarmID { get; set; }
        public string FarmName { get; set; }
        public string FarmAddress { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string LineID { get; set; }
        public string SocialPage { get; set; }
        public string WebSite { get; set; }
        public string AboutUs { get; set; }
        public string FarmLogo { get; set; }
        public bool Status { get; set; }
    }
}
