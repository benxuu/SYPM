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
 /// <summary>
 /// 目前没有用！！！
 /// </summary>
    public class ProduceController : Controller
    {
        /// <summary>
        /// 获取主订单的作业明细，即部件作业计划
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllProduceDetail()
        {

            string FBillNo = Request["FBillNo"];
            string sort = "FBillNo desc";
            int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
            int pagesize = Request["rows"] == null ? 8 : Convert.ToInt32(Request["rows"]);
           
            //抽取主作业计划单,规则不包含-、_两种连接符
             string strWhere = "FBillNo like '" + FBillNo + "_%'";
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
            string FBillNo = Request["FBillNo"] == null ? "" : Request["FBillNo"];
            string FItemID = Request["FItemID"] == null ? "" : Request["FItemID"];
            string isable = Request["isable"] == null ? "" : Request["isable"];
            string ifchangepwd = Request["ifchangepwd"] == null ? "" : Request["ifchangepwd"];
            string userperson = Request["userperson"] == null ? "" : Request["userperson"];
            string FPlanCommitDate = Request["FPlanCommitDate"] == null ? "" : Request["FPlanCommitDate"];
            string FPlanFinishDate = Request["FPlanFinishDate"] == null ? "" : Request["FPlanFinishDate"];

            if (FBillNo.Trim() != "" && !SqlInjection.GetString(FBillNo))   //防止sql注入
                strWhere += string.Format(" and FBillNo like '%{0}%'", FBillNo.Trim());
            //FName为非主表字段，暂不支持直接查询；
            //后期解决思路，先根据FName在子表中查询对应的FItemID，可能有多个，则将这多个拼接成where条件；
            //例如  FItemID = id1 and FItemID = id2  and FItemID = id3...
            //if (FName.Trim() != "" && !SqlInjection.GetString(FName))
            //    strWhere += string.Format(" and FName like '%{0}%'", FName.Trim());
            if (FItemID.Trim() != "" && !SqlInjection.GetString(FItemID))
                strWhere += string.Format(" and FItemID like '%{0}%'", FItemID.Trim());
            if (isable.Trim() != "select" && isable.Trim() != "")
                strWhere += " and IsAble = '" + isable.Trim() + "'";
            if (ifchangepwd.Trim() != "select" && ifchangepwd.Trim() != "")
                strWhere += " and IfChangePwd = '" + ifchangepwd.Trim() + "'";
            if (FPlanCommitDate.Trim() != "")
                strWhere += " and FPlanCommitDate > '" + FPlanCommitDate.Trim() + "'";
            if (FPlanFinishDate.Trim() != "")
                strWhere += " and FPlanFinishDate < '" + FPlanFinishDate.Trim() + "'";

            //抽取主作业计划单,规则不包含-、_两种连接符
            strWhere +=  "and Fbillno not like '%v_%'  ESCAPE   'v'  and  Fbillno not like '%v-%' ESCAPE   'v'";           

            int totalCount;   //输出参数           
            string strJson = new ProjectBLL().GetJsonPager("ICMO", "FBillNo,FStatus,FQty,FCommitQty,FPlanCommitDate,FPlanFinishDate,FStartDate,FFinishDate,FType,FWorkShop,FItemID", sort + " " + order, pagesize, pageindex, strWhere, out totalCount);
            //var jsonResult = new { total = totalCount.ToString(), rows = strJson };
            return Content("{\"total\": " + totalCount.ToString() + ",\"rows\":" + strJson + "}");           
        }

        /// <summary>
        /// 将生产栏的查询请求跳转到项目栏
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Projectgrid(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Project/Projectgrid");
            }
            catch
            {
                return View();
            }
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
