using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Contract.Farm
{
    public class Registration
    {
        [Key, Column(Order = 0)]
        public Int32 ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public string OTPNo { get; set; }
        public bool IsOTPSent { get; set; }
        public DateTime? OTPSentDate { get; set; }
        public bool IsOTPReSent { get; set; }
        public Byte? OTPSentCount { get; set; }
        public string CountryCode { get; set; }
        public bool IsOTPVerified { get; set; }
    }
}
