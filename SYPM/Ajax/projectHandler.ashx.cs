using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SYPM.Ajax
{
    /// <summary>
    /// projectHandler 的摘要说明
    /// </summary>
    public class projectHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            // if (context.Session["userid"] != null || true)
            if (true)
            {
                context.Response.ContentType = "text/plain";
                System.Diagnostics.Debug.WriteLine(context.Request.QueryString["o"]);
                switch (context.Request.QueryString["o"])
                {
                    case "icmo":
                        context.Response.Write("icmo");
                        break;
                    case "getproject":
                        context.Response.Write(getproject());
                        break;
                    default:
                        context.Response.Write("没有识别到请求！！");
                        break;
                }
            }
        }

        private string getproject()
        {
             //DAL.project.GetProjectList
            int x;
            DBUtility.JsonBuilder jb =new DBUtility.JsonBuilder();
            return jb.ListToGantt(DAL.project.GetProjectList(1,out x)); 
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