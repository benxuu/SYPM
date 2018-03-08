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
    /// HandlerICMO 的摘要说明
    /// </summary>
    public class HandlerICMO : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           // if (context.Session["userid"] != null || true)
   if (true)
            {
                context.Response.ContentType = "text/plain";
               
                switch (context.Request.QueryString["o"])
                {
                    case "icmo":

                        context.Response.Write(getICMO());

                        break;

                    case "ptask":
                        context.Response.Write(getptask());
                        break;

                    case "work":
                        context.Response.Write(getwork());
                        break;

                }
            }

        }




        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public string getICMO()
        {
            DAL.ICMO ic = new ICMO();
            DataSet ds = new DataSet();
            ds = ic.GetList(10, "", "FBillNo");
            ds.Tables["ds"].TableName = "rows";//改变表名，用于json序列化时自动生成对象名“rows”
            string str = JsonConvert.SerializeObject(ds);
            return str;

        }

        public string getwork()
        {
            DAL.ICMO ic = new ICMO();
            DataSet ds = new DataSet();
            ds = ic.GetList(10, "", "FBillNo");
            //ds.Tables["ds"].TableName = "rows";//改变表名，用于json序列化时自动生成对象名“rows”
            JsonBuilder jb = new JsonBuilder();
            return jb.DataTableToJson(ds.Tables[0], 3);
            //string str = JsonConvert.SerializeObject(ds);
            //return str;

        }

        public string getptask()
        {
            DataSet ds = new DataSet();
            ProductionTask pt = new ProductionTask();
            ds = pt.GetPTask(20);
            ds.Tables[0].TableName = "rows";         
            string str = JsonConvert.SerializeObject(ds);
            return str;
        }

      
    }
}