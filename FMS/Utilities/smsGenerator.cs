﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace FMS.Utilities
{
    public class smsGenerator
    {
        public bool ConfigSms(string to, string msgContent)
        {
            return SendSms(to, msgContent, ConfigurationManager.AppSettings["smsFrom"]);
        }

        public bool ConfigSms(string to, string msgContent, string smsFrom)
        {
            return SendSms(to, msgContent, smsFrom);
        }

        public bool SendSms(string to, string msgContent, string smsFrom)
        {
            var userName = ConfigurationManager.AppSettings["smsUserName"];
            var password = ConfigurationManager.AppSettings["smsPassword"];
            var isTesting = Convert.ToBoolean(ConfigurationManager.AppSettings["isTesting"]);

            if (!isTesting)
            {
                //var smsUrl = string.Format("http://login.smstake.com/SMSPanel?username={0}&password={1}&from={2}&to={3}&msg={4}&type=1&dnd_check=0",
                //                            userName, password, smsFrom, to, msgContent);
                var smsUrl = string.Format("http://103.16.101.52:8080/bulksms/bulksms?username={0}&password={1}&type=0&dlr=1&destination={2}&source={3}&message={4}&ts={5}",
                    userName, password, to, smsFrom, msgContent, DateTime.Now.Ticks);

                var apiResponse = SmsWebApi(smsUrl);

                if (apiResponse.Length > 0)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        public string SmsWebApi(string Url)
        {
            WebRequest request = WebRequest.Create(Url);
            using (WebResponse response = request.GetResponse())
            {
                string strRes = "";
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    strRes = sr.ReadToEnd();
                }
                return strRes;
            }
        }
    }
}