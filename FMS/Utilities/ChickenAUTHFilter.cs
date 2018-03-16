using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FMS.Utilities
{
    public class ChickenAUTHFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var USERID = HttpContext.Current.Request.Headers[Utility.HDRUSERID];
            var COMPANYID = Convert.ToInt32(HttpContext.Current.Request.Headers[Utility.HDRCOMPANYID]);
            var BRANCHID = Convert.ToInt64(HttpContext.Current.Request.Headers[Utility.HDRBRANCHID]);
            var AUTHTOKEN = HttpContext.Current.Request.Headers[Utility.HDRAUTHTOKEN];

            try
            {
                var result = true;
                //var result = new LoginActivityBO().ValidateAuth(new LoginActivity
                //{
                //    UserId = USERID,
                //    BranchId = BRANCHID,
                //    TokenNo = AUTHTOKEN
                //});
            }
            catch (Exception ex)
            {
                //var response = actionContext.Request.CreateResponse(HttpStatusCode.Moved);
                //response.Headers.Location = new Uri("http://uat.1trade.exchange/");
                //return response;
                //throw ex;
                actionContext.Response = new HttpResponseMessage
                {
                    Content = new StringContent(ex.Message),
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

        }
    }
}