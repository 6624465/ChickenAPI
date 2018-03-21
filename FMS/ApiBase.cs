using FMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FMS
{
    public class ApiBase : ApiController
    {
        public string USERID
        {
            get
            {
                return HttpContext.Current.Request.Headers[Utility.HDRUSERID];
            }
        }
        public Int32 FARMID
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Request.Headers[Utility.HDRFARMID]);
            }
        }
        public Int64 BRANCHID
        {
            get
            {
                return Convert.ToInt64(HttpContext.Current.Request.Headers[Utility.HDRBRANCHID]);
            }
        }
        public string AUTHTOKEN
        {
            get
            {
                return HttpContext.Current.Request.Headers[Utility.HDRAUTHTOKEN];
            }
        }

        public string HeaderValueByKey(string key)
        {
            IEnumerable<string> headerValues;
            var headerVal = string.Empty;
            if (Request.Headers.TryGetValues(key, out headerValues))
            {
                headerVal = headerValues.FirstOrDefault();
            }
            return headerVal;
        }

        public string Nokeylist = "0123456789";
        public string GenerateOTP()
        {
            var password = "";
            Random r = new Random();
            int keyLength = Nokeylist.Length;
            for (var i = 0; i < 4; i++)
            {
                password += Nokeylist[r.Next(0, keyLength)];
            }
            return password;
        }

        public bool SendOTP(string To, string OTP)
        {
            return new smsGenerator().ConfigSms(To, string.Format(Utility.SmsSignUpOTP, OTP));
        }

        public bool SendOTP(string To)
        {
            return new smsGenerator().ConfigSms(To, string.Format(Utility.SmsOTP, GenerateOTP()));
        }


    }
}