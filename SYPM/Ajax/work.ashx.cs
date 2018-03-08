using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Newtonsoft.Json;
using DAL;
using DBUtility;
namespace SYPM.Ajax
{
    /// <summary>
    /// work 的摘要说明
    /// </summary>
    public class work : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            DAL.ICMO ic = new ICMO();
          
            DataSet rows =  ic.GetList(5, "", "FBillNo");
            string json = JsonConvert.SerializeObject(rows);
            
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}