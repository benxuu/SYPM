using AchieveBLL;
using AchieveCommon;
using AchieveEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Data;

namespace AchieveManageWeb.Controllers
{
    [AchieveManageWeb.App_Start.JudgmentLogin]
    public class ProjectController : Controller
    {

        //public ActionResult getGantt2Demo()
        //{
        //    string strWhere = "1=1";
        //    string sort = Request["sort"] == null ? "FPlanCommitDate" : Request["sort"];
        //    string order = Request["order"] == null ? "desc" : Request["order"];
        //    //首先获取前台传递过来的参数
        //    int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
        //    int pagesize = Request["rows"] == null ? 8 : Convert.ToInt32(Request["rows"]);
        //    string userid = Request["accountid"] == null ? "" : Request["accountid"];
        //    string username = Request["username"] == null ? "" : Request["username"];
        //    string isable = Request["isable"] == null ? "" : Request["isable"];
        //    string ifchangepwd = Request["ifchangepwd"] == null ? "" : Request["ifchangepwd"];
        //    string userperson = Request["userperson"] == null ? "" : Request["userperson"];
        //    string adddatestart = Request["adddatestart"] == null ? "" : Request["adddatestart"];
        //    string adddateend = Request["adddateend"] == null ? "" : Request["adddateend"];
        //    if (userid.Trim() != "" && !SqlInjection.GetString(userid))   //防止sql注入
        //        strWhere += string.Format(" and AccountName like '%{0}%'", userid.Trim());
        //    if (username.Trim() != "" && !SqlInjection.GetString(username))
        //        strWhere += string.Format(" and RealName like '%{0}%'", username.Trim());
        //    if (isable.Trim() != "select" && isable.Trim() != "")
        //        strWhere += " and IsAble = '" + isable.Trim() + "'";
        //    if (ifchangepwd.Trim() != "select" && ifchangepwd.Trim() != "")
        //        strWhere += " and IfChangePwd = '" + ifchangepwd.Trim() + "'";
        //    if (adddatestart.Trim() != "")
        //        strWhere += " and CreateTime > '" + adddatestart.Trim() + "'";
        //    if (adddateend.Trim() != "")
        //        strWhere += " and CreateTime < '" + adddateend.Trim() + "'";
        //    //抽取主作业计划单,规则不包含-、_两种连接符
        //    strWhere += "and Fbillno not like '%v_%'  ESCAPE   'v'  and  Fbillno not like '%v-%' ESCAPE   'v'";
        //    int totalCount;   //输出参数
        //    DataTable dt = new ProjectBLL().GetDataTablePager("ICMO", "FBillNo,FStatus,FPlanCommitDate,FPlanFinishDate,FStartDate,FFinishDate,FItemID", sort + " " + order, pagesize, pageindex, strWhere, out totalCount);
        //    string strJson = ToGanttJson(dt);
        //    return Content(strJson);
        //}

        public string ToGanttJson(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StringBuilder sb1 = new StringBuilder();
                string plandateS = dt.Rows[i]["FPlanCommitDate"].ToString();
                string plandateE = dt.Rows[i]["FPlanFinishDate"].ToString();
                string realdateS = dt.Rows[i]["FStartDate"].ToString();
                string realdateE = dt.Rows[i]["FFinishDate"].ToString();

                sb1.AppendFormat("{{\"id\":{0},\"name\":{1},", i, "\"" + dt.Rows[i]["FBillNo"].ToString() + "\"");
                sb1.AppendFormat("\"series\":[{{\"name\":\"计划日程\",\"start\":\"{0}\",\"end\":\"{1}\",\"color\":\"{2}\" }},", plandateS, plandateE, "#f0f0f0");
                sb1.AppendFormat("{{\"name\":\"实际日程\",\"start\":\"{0}\",\"end\":\"{1}\",\"color\":\"{2}\" }}]}}", realdateS, realdateE, "#8C7853");
                if (i < dt.Rows.Count - 1)
                    sb.Append(sb1.ToString() + ",");
                else
                    sb.Append(sb1.ToString());
            }
            sb.Append("]");
            return sb.ToString();
        }
        /// <summary>
        /// 获取主订单的作业明细，即部件作业计划
        /// </summary>
        /// <returns></returns>
        public ActionResult GetProjectEntry()
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
        /// <summary>
        /// 主作业计划通用分页查询,view=Projectgrid,
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPageProjectInfo()
        {
            string strWhere = "1=1";
            string sort = Request["sort"] == null ? "FPlanCommitDate" : Request["sort"];
            string order = Request["order"] == null ? "desc" : Request["order"];
            string view = Request["view"] == null ? "" : Request["view"];

            //首先获取前台传递过来的参数
            int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);//输出的数据页码
            int pagesize = Request["rows"] == null ? 10 : Convert.ToInt32(Request["rows"]);//每页输出数量
            string FBillNo = Request["FBillNo"] == null ? "" : Request["FBillNo"];
            string FName = Request["FName"] == null ? "" : Request["FName"];
            string isable = Request["isable"] == null ? "" : Request["isable"];
            string ifchangepwd = Request["ifchangepwd"] == null ? "" : Request["ifchangepwd"];
            string userperson = Request["userperson"] == null ? "" : Request["userperson"];
            string FPlanCommitDate = Request["FPlanCommitDate"] == null ? "" : Request["FPlanCommitDate"];
            //string FPlanFinishDate = Request["FPlanFinishDate"] == null ? "" : Request["FPlanFinishDate"];

            if (FBillNo.Trim() != "" && !SqlInjection.GetString(FBillNo))   //防止sql注入
                strWhere += string.Format(" and FBillNo like '%{0}%'", FBillNo.Trim());
            //FName为非主表字段，暂不支持直接查询；
            //后期解决思路，先根据FName在子表中查询对应的FItemID，可能有多个，则将这多个拼接成where条件；
            //例如  FItemID = id1 or FItemID = id2  or FItemID = id3...
            //if (FName.Trim() != "" && !SqlInjection.GetString(FName))
            //    strWhere += string.Format(" and FName like '%{0}%'", FName.Trim());
            if (FName.Trim() != "" && !SqlInjection.GetString(FName))
            {
                //获取fitemid表
                DataTable dtfitemid = new ProjectBLL().GetFItemIDByFName(FName);
                strWhere += " and (";
          for (int i = 0; i < dtfitemid.Rows.Count; i++)
                {
                    strWhere += string.Format("FItemID = {0}", dtfitemid.Rows[i]["FItemID"]);
                    if (i< dtfitemid.Rows.Count-1)
                    {
                        strWhere += " or ";
                    }
                    else
                    {
                        strWhere += ")";
                    }
                   
                }
            }           

            if (isable.Trim() != "select" && isable.Trim() != "")
                strWhere += " and IsAble = '" + isable.Trim() + "'";
            if (ifchangepwd.Trim() != "select" && ifchangepwd.Trim() != "")
                strWhere += " and IfChangePwd = '" + ifchangepwd.Trim() + "'";
            if (FPlanCommitDate.Trim() != "")
                strWhere += " and FPlanCommitDate > '" + FPlanCommitDate.Trim() + "'";
            //if (FPlanFinishDate.Trim() != "")
            //    strWhere += " and FPlanFinishDate < '" + FPlanFinishDate.Trim() + "'";

            //抽取主作业计划单,规则不包含-、_两种连接符
            strWhere += " and Fbillno not like '%v_%'  ESCAPE   'v'  and  Fbillno not like '%v-%' ESCAPE   'v'";

            string content = "";
            if (view == "ProjectGrid")
            {
                int totalCount;   //输出参数 
                string strJson = new ProjectBLL().GetJsonPager("ICMO", "FBillNo,FStatus,FQty,FCommitQty,FPlanCommitDate,FPlanFinishDate,FStartDate,FFinishDate,FType,FWorkShop,FItemID", sort + " " + order, pagesize, pageindex, strWhere, out totalCount);
                content = "{\"total\": " + totalCount.ToString() + ",\"rows\":" + strJson + "}";
            }
            if (view == "ProjectGantt")
            {
                 int totalCount;   //输出参数
                // pagesize = 5;//限制甘特图输出数据量
            DataTable dt = new ProjectBLL().GetDataTablePager("ICMO", "FBillNo,FStatus,FPlanCommitDate,FPlanFinishDate,FStartDate,FFinishDate,FItemID", sort + " " + order, pagesize, pageindex, strWhere, out totalCount);
            string strJson = ToGanttJson(dt);
            content = "{\"total\": " + totalCount.ToString() + ",\"rows\":" + strJson + "}";
            }

            return Content(content);
        }
        /// <summary>
        /// 获取工序计划表，输入FBillNo，ICMO.FBillNo==shworkbill.FICMONO，暂不支持分页
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPageProcessInfo()
        {                     
            //首先获取前台传递过来的参数          
            string FBillNo = Request["FBillNo"] == null ? "" : Request["FBillNo"];

//            select a.ficmono,a.fitemid,b.FQTYPLAN,b.FPLANSTARTDATE,b.FPLANENDDATE,b.FStartWorkDate,b.FEndWorkDate,b.fcheckdate,b.fopernote,
            //b.fstatus,b.FWorkCenterID,b.ffinishtime from SHWORKBILL as a left join shworkbillentry as b  on a.FInterID=b.FInterID where a.ficmono=1"
            StringBuilder sqlsb=new StringBuilder();
            sqlsb.Append("select a.ficmono,a.fitemid,b.FQTYPLAN,b.FPLANSTARTDATE,b.FPLANENDDATE,b.FStartWorkDate,");
            sqlsb.Append("b.FEndWorkDate,b.fcheckdate,b.fopernote,b.fstatus,b.FWorkCenterID,b.ffinishtime ");
            sqlsb.Append("from SHWORKBILL as a left join shworkbillentry as b  on a.FInterID=b.FInterID where a.ficmono='"+FBillNo+"'");
           
            string content = "";
            if (true)//view == "ProjectGrid")
            {
                string strJson = new ProjectBLL().GetJsonFromSqlK3(sqlsb.ToString());
                int totalCount = 100;
               // string strJson = new ProjectBLL().GetJsonPager("ICMO", "FBillNo,FStatus,FQty,FCommitQty,FPlanCommitDate,FPlanFinishDate,FStartDate,FFinishDate,FType,FWorkShop,FItemID", sort + " " + order, pagesize, pageindex, strWhere, out totalCount);
                content = "{\"total\": " + totalCount.ToString() + ",\"rows\":" + strJson + "}";
            }          

            return Content(content);
        }
        public ActionResult GetGanttDemo()
        {
            //for gantt edit, not used
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
            return Content(sb.ToString());
        }

        //
        // GET: /Project/

        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult ProjectGrid()
        {
            return View();
        }
        public ActionResult ProjectGantt()
        {
            return View();
        }
        public ActionResult rpt()
        {
            return View();
        }
        public ActionResult ganttview()
        {
            return View();
        }
        public ActionResult test()
        {
            return View();
        }
        //
        // GET: /Project/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Project/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Project/Create

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
        // GET: /Project/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Project/Edit/5

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
        // GET: /Project/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Project/Delete/5

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
