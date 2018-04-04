using AchieveBLL;
using AchieveCommon;
using AchieveEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace AchieveManageWeb.Controllers
{
    public class ProduceController : Controller
    {

        public ActionResult GetAllProduceDetail()
        {

            string FBillNo = Request["FBillNo"];
            string sort = "FBillNo desc";
            int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
            int pagesize = Request["rows"] == null ? 8 : Convert.ToInt32(Request["rows"]);
           
            //抽取主作业计划单,规则不包含-、_两种连接符
             string strWhere = "FBillNo like '" + FBillNo + "%'";
            int totalCount;   //输出参数           
            string strJson = new ProjectBLL().GetJsonPager("ICMO", "FBillNo,FStatus,FQty,FCommitQty,FPlanCommitDate,FPlanFinishDate,FStartDate,FFinishDate,FType,FWorkShop,FItemID", sort, pagesize, pageindex, strWhere, out totalCount);
            return Content("{\"total\": " + totalCount.ToString() + ",\"rows\":" + strJson + "}");   
        }

        public ActionResult GetAllProduceInfo()
        {
            string strWhere = "1=1";
            string sort = Request["sort"] == null ? "FPlanCommitDate" : Request["sort"];
            string order = Request["order"] == null ? "desc" : Request["order"];

            //首先获取前台传递过来的参数
            int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
            int pagesize = Request["rows"] == null ? 10 : Convert.ToInt32(Request["rows"]);
            string userid = Request["accountid"] == null ? "" : Request["accountid"];
            string username = Request["username"] == null ? "" : Request["username"];
            string isable = Request["isable"] == null ? "" : Request["isable"];
            string ifchangepwd = Request["ifchangepwd"] == null ? "" : Request["ifchangepwd"];
            string userperson = Request["userperson"] == null ? "" : Request["userperson"];
            string adddatestart = Request["adddatestart"] == null ? "" : Request["adddatestart"];
            string adddateend = Request["adddateend"] == null ? "" : Request["adddateend"];

            if (userid.Trim() != "" && !SqlInjection.GetString(userid))   //防止sql注入
                strWhere += string.Format(" and AccountName like '%{0}%'", userid.Trim());
            if (username.Trim() != "" && !SqlInjection.GetString(username))
                strWhere += string.Format(" and RealName like '%{0}%'", username.Trim());
            if (isable.Trim() != "select" && isable.Trim() != "")
                strWhere += " and IsAble = '" + isable.Trim() + "'";
            if (ifchangepwd.Trim() != "select" && ifchangepwd.Trim() != "")
                strWhere += " and IfChangePwd = '" + ifchangepwd.Trim() + "'";
            if (adddatestart.Trim() != "")
                strWhere += " and CreateTime > '" + adddatestart.Trim() + "'";
            if (adddateend.Trim() != "")
                strWhere += " and CreateTime < '" + adddateend.Trim() + "'";

            //抽取主作业计划单,规则不包含-、_两种连接符
            strWhere +=  "and Fbillno not like '%v_%'  ESCAPE   'v'  and  Fbillno not like '%v-%' ESCAPE   'v'";           

            int totalCount;   //输出参数           
            string strJson = new ProjectBLL().GetJsonPager("ICMO", "FBillNo,FStatus,FQty,FCommitQty,FPlanCommitDate,FPlanFinishDate,FStartDate,FFinishDate,FType,FWorkShop,FItemID", sort + " " + order, pagesize, pageindex, strWhere, out totalCount);
            //var jsonResult = new { total = totalCount.ToString(), rows = strJson };
            return Content("{\"total\": " + totalCount.ToString() + ",\"rows\":" + strJson + "}");           
        }
      



     
        //
        // GET: /Produce/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexDetail()
        {
            return View();
        }
        //
        // GET: /Produce/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Produce/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Produce/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Produce/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Produce/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Produce/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Produce/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
