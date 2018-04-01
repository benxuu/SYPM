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
                        context.Response.Write(getprojectdemo());
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
        private string getprojectdemo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"tasks\":    [");
            sb.Append("{\"id\": -1, \"name\": \"Gantt editor\", \"progress\": 0, \"progressByWorklog\": false, \"relevance\": 0, \"type\": \"\", \"typeId\": \"\", \"description\": \"\", \"code\": \"\", \"level\": 0, \"status\": \"STATUS_ACTIVE\", \"depends\": \"\", \"canWrite\": true, \"start\": 1396994400000, \"duration\": 20, \"end\": 1399586399999, \"startIsMilestone\": false, \"endIsMilestone\": false, \"collapsed\": false, \"assigs\": [], \"hasChild\": true},");
            sb.Append("{\"id\": -2, \"name\": \"coding\", \"progress\": 0, \"progressByWorklog\": false, \"relevance\": 0, \"type\": \"\", \"typeId\": \"\", \"description\": \"\", \"code\": \"\", \"level\": 1, \"status\": \"STATUS_ACTIVE\", \"depends\": \"\", \"canWrite\": true, \"start\": 1396994400000, \"duration\": 10, \"end\": 1398203999999, \"startIsMilestone\": false, \"endIsMilestone\": false, \"collapsed\": false, \"assigs\": [], \"hasChild\": true},");
            sb.Append("{\"id\": -3, \"name\": \"gantt part\", \"progress\": 0, \"progressByWorklog\": false, \"relevance\": 0, \"type\": \"\", \"typeId\": \"\", \"description\": \"\", \"code\": \"\", \"level\": 2, \"status\": \"STATUS_ACTIVE\", \"depends\": \"\", \"canWrite\": true, \"start\": 1396994400000, \"duration\": 2, \"end\": 1397167199999, \"startIsMilestone\": false, \"endIsMilestone\": false, \"collapsed\": false, \"assigs\": [], \"hasChild\": false},");
            sb.Append("{\"id\": -4, \"name\": \"editor part\", \"progress\": 0, \"progressByWorklog\": false, \"relevance\": 0, \"type\": \"\", \"typeId\": \"\", \"description\": \"\", \"code\": \"\", \"level\": 2, \"status\": \"STATUS_SUSPENDED\", \"depends\": \"3\", \"canWrite\": true, \"start\": 1397167200000, \"duration\": 4, \"end\": 1397685599999, \"startIsMilestone\": false, \"endIsMilestone\": false, \"collapsed\": false, \"assigs\": [], \"hasChild\": false},");
            sb.Append("{\"id\": -5, \"name\": \"testing\", \"progress\": 0, \"progressByWorklog\": false, \"relevance\": 0, \"type\": \"\", \"typeId\": \"\", \"description\": \"\", \"code\": \"\", \"level\": 1, \"status\": \"STATUS_SUSPENDED\", \"depends\": \"2:5\", \"canWrite\": true, \"start\": 1398981600000, \"duration\": 5, \"end\": 1399586399999, \"startIsMilestone\": false, \"endIsMilestone\": false, \"collapsed\": false, \"assigs\": [], \"hasChild\": true},");
            sb.Append("{\"id\": -6, \"name\": \"test on safari\", \"progress\": 0, \"progressByWorklog\": false, \"relevance\": 0, \"type\": \"\", \"typeId\": \"\", \"description\": \"\", \"code\": \"\", \"level\": 2, \"status\": \"STATUS_SUSPENDED\", \"depends\": \"\", \"canWrite\": true, \"start\": 1398981600000, \"duration\": 2, \"end\": 1399327199999, \"startIsMilestone\": false, \"endIsMilestone\": false, \"collapsed\": false, \"assigs\": [], \"hasChild\": false},");
            sb.Append("{\"id\": -7, \"name\": \"test on ie\", \"progress\": 0, \"progressByWorklog\": false, \"relevance\": 0, \"type\": \"\", \"typeId\": \"\", \"description\": \"\", \"code\": \"\", \"level\": 2, \"status\": \"STATUS_SUSPENDED\", \"depends\": \"6\", \"canWrite\": true, \"start\": 1399327200000, \"duration\": 3, \"end\": 1399586399999, \"startIsMilestone\": false, \"endIsMilestone\": false, \"collapsed\": false, \"assigs\": [], \"hasChild\": false},");
            sb.Append("{\"id\": -8, \"name\": \"test on chrome\", \"progress\": 0, \"progressByWorklog\": false, \"relevance\": 0, \"type\": \"\", \"typeId\": \"\", \"description\": \"\", \"code\": \"\", \"level\": 2, \"status\": \"STATUS_SUSPENDED\", \"depends\": \"6\", \"canWrite\": true, \"start\": 1399327200000, \"duration\": 2, \"end\": 1399499999999, \"startIsMilestone\": false, \"endIsMilestone\": false, \"collapsed\": false, \"assigs\": [], \"hasChild\": false} ],");
            sb.Append("\"resources\": [");
            sb.Append("{\"id\": \"tmp_1\", \"name\": \"Resource 1\"},");
            sb.Append("{\"id\": \"tmp_4\", \"name\": \"Resource 4\"}],");
            sb.Append("\"roles\":       [");
            sb.Append("{\"id\": \"tmp_1\", \"name\": \"Project Manager\"},");
            sb.Append("{\"id\": \"tmp_4\", \"name\": \"Customer\"}");
            sb.Append("], \"canWrite\":    true, \"canDelete\":true, \"canWriteOnParent\": true, \"canAdd\":true}");
            return sb.ToString();
        
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
           // string s = "[{\"id\": 1, \"name\": \"server 1\", \"series\": [{ \"name\": \"Planned\", \"start\": new Date(2010,00,01), \"end\": new Date(2010,00,03) },	{ \"name\": \"Actual\", \"start\": \"new Date(2010,00,02)\", \"end\": \"new Date(2010,00,05)\", \"color\": \"#f0f0f0\" }]}]";
            string s = "[{\"id\": 1, \"name\": \"server 1\", \"series\": [{ \"name\": \"Planned\", \"start\":\"/Date(1323802400000)/\", \"end\": \"/Date(1325685200000)/\" }]}]";


            return s;
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