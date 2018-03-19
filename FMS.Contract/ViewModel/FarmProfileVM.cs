using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FMS.Contract.ViewModel
{
    public class FarmProfileVM
    {
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
        public bool? Status { get; set; }
        public string FileName { get; set; }
    }
}
