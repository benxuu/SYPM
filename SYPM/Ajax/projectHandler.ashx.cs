using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

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
                    case "gantt1":
                        context.Response.Write(getprojectg1());
                        break;
                    case "gantt2":
                        context.Response.Write(getprojectg2());
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
        /// <summary>
        /// gantt图1使用
        /// </summary>
        /// <returns></returns>
        private string getprojectg1()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" [");
            sb.Append("{	\"name\": \"task  3\",	\"desc\": \"from server\",	\"values\": [{\"from\": \"/Date(1323802400000)/\",	\"to\": \"/Date(1325685200000)/\",	\"label\": \"\",	\"customClass\": \"ganttGreen\"	}]}, ");
            sb.Append("{	\"name\": \"more\",	\"desc\": \"for gantt1\",	\"values\": [{	\"from\": \"/Date(1322611200000)/\",	\"to\": \"/Date(1323302400000)/\",		\"label\": \"\",		\"customClass\": \"ganttBlue\"	}, {		\"from\": \"/Date(1323802400000)/\",		\"to\": \"/Date(1325685200000)/\",		\"label\": \"\",		\"customClass\": \"ganttorange\"	}]}");
            sb.Append(" ]");
            
            
            return sb.ToString();
       
        }
        /// <summary>
        /// gantt图2使用
        /// </summary>
        /// <returns></returns>
        private string getprojectg2()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" [");
            sb.Append("{	\"name\": \"task  3\",	\"desc\": \"from server\",	\"values\": [{\"from\": \"/Date(1323802400000)/\",	\"to\": \"/Date(1325685200000)/\",	\"label\": \"\",	\"customClass\": \"ganttGreen\"	}]}, ");
            sb.Append("{	\"name\": \"more\",	\"desc\": \"for gantt2\",	\"values\": [{	\"from\": \"/Date(1322611200000)/\",	\"to\": \"/Date(1323302400000)/\",		\"label\": \"\",		\"customClass\": \"ganttBlue\"	}, {		\"from\": \"/Date(1323802400000)/\",		\"to\": \"/Date(1325685200000)/\",		\"label\": \"\",		\"customClass\": \"ganttorange\"	}]}");
            sb.Append(" ]");


            return sb.ToString();
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