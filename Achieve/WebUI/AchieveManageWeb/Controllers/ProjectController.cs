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
using System.Data.Sql;
using System.Data.SqlClient;

namespace AchieveManageWeb.Controllers
{
    [AchieveManageWeb.App_Start.JudgmentLogin]
    public class ProjectController : Controller
    {
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
            //string sort = "FBillNo desc";
            int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
            int pagesize = Request["rows"] == null ? 8 : Convert.ToInt32(Request["rows"]);

            //抽取主作业计划单,规则不包含-、_两种连接符
            string strWhere = "FBillNo like '" + FBillNo + "_%'";
            int totalCount;   //输出参数
            //string strJson = new ProjectBLL().GetJsonPager("ICMO", "FBillNo,FStatus,FQty,FCommitQty,FPlanCommitDate,FPlanFinishDate,FStartDate,FFinishDate,FType,FWorkShop,FItemID", sort + " " + order, pagesize, pageindex, strWhere, out totalCount);
            string strJson = new ProjectBLL().GetJsonPager((pageindex - 1) * pagesize + 1, pageindex * pagesize, strWhere, out totalCount);
           // content = "{\"total\": " + totalCount.ToString() + ",\"rows\":" + strJson + "}";
           // string strJson = new ProjectBLL().GetJsonPager("ICMO", "FBillNo,FStatus,FQty,FCommitQty,FPlanCommitDate,FPlanFinishDate,FStartDate,FFinishDate,FType,FWorkShop,FItemID", sort, pagesize, pageindex, strWhere, out totalCount);
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
            //string isable = Request["isable"] == null ? "" : Request["isable"];
            string FModel = Request["FModel"] == null ? "" : Request["FModel"];
            string FStatus = Request["FStatus"] == null ? "" : Request["FStatus"];
            string FPlanCommitDate = Request["FPlanCommitDate"] == null ? "" : Request["FPlanCommitDate"]; 

            if (FBillNo.Trim() != "" && !SqlInjection.GetString(FBillNo))   //防止sql注入
                strWhere += string.Format(" and FBillNo like '%{0}%'", FBillNo.Trim());

            if (FName.Trim() != "" && !SqlInjection.GetString(FName))   //防止sql注入
                strWhere += string.Format(" and FName like '%{0}%'", FName.Trim());
            
            if (FModel.Trim() != "" && !SqlInjection.GetString(FModel))   //防止sql注入
                strWhere += string.Format(" and FModel like '%{0}%'", FModel.Trim());
            
            if (FStatus=="true")
            {
                strWhere += string.Format(" and FStatus > 2 ");
            }
            else 
            {
                strWhere += string.Format(" and FStatus < 3 ");
            }
  
           
            if (FPlanCommitDate.Trim() != "")
                strWhere += " and FPlanCommitDate > '" + FPlanCommitDate.Trim() + "'";

            //抽取主作业计划单,规则不包含-、_两种连接符
            strWhere += " and Fbillno not like '%v_%'  ESCAPE   'v'  and  Fbillno not like '%v-%' ESCAPE   'v'";

            string content = "";
            if (view == "ProjectGrid")
            {
                int totalCount;   //输出参数 
                //string strJson = new ProjectBLL().GetJsonPager("ICMO", "FBillNo,FStatus,FQty,FCommitQty,FPlanCommitDate,FPlanFinishDate,FStartDate,FFinishDate,FType,FWorkShop,FItemID", sort + " " + order, pagesize, pageindex, strWhere, out totalCount);
                string strJson = new ProjectBLL().GetJsonPager((pageindex - 1) * pagesize + 1, pageindex * pagesize, strWhere, out totalCount);
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
        /// <summary>
        /// 创建项目单据
        /// </summary>
        /// <returns></returns>
        public ActionResult CreatePMBill()
        {
            return View();
        }
        /// <summary>
        /// 新增项目单据--保存
        /// </summary>
        /// <returns></returns>
        public ActionResult AddNewProject()
        {
            try
            {
                string ProjectID = SqlHelper.GetSerialNumber("tbProject", "ProjectID");
                string ProjectNo = Request["ProjectNo"] == null ? "PM" + ProjectID : Request["ProjectNo"];
                string ProjectName = Request["ProjectName"] == null ? "" : Request["ProjectName"];
                string ProjectManager = Request["ProjectManager"] == null ? "" : Request["ProjectManager"];
                string ProjectClerk = Request["ProjectClerk"] == null ? "" : Request["ProjectClerk"];
                string Remark = Request["Remark"] == null ? "" : Request["Remark"];
                //string bsPSTime = Request["bsPSTime"] == null ? "" : Request["ProjectClerk"];
                string AppendListID = Request["AppendListID"] == null ? "" : Request["AppendListID"];
                string AppendID = Request["AppendID"] == null ? "" : Request["AppendID"];
               
                UserEntity uInfo = ViewData["Account"] as UserEntity;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into tbProject(");
                strSql.Append("ProjectID,AppendListID,CreateBy,CreateTime,ProjectNo,ProjectName,ProjectManager,ProjectClerk,Remark,UpdateTime,UpdateBy,AppendID");
                strSql.Append(") values (");
                strSql.Append("@ProjectID,@AppendListID,@CreateBy,@CreateTime,@ProjectNo,@ProjectName,@ProjectManager,@ProjectClerk,@Remark,@UpdateTime,@UpdateBy,@AppendID");
                strSql.Append(") ");

                SqlParameter[] parameters = {
			            new SqlParameter("@ProjectID", ProjectID) ,            
                        new SqlParameter("@AppendListID", AppendListID) ,            
                        new SqlParameter("@CreateBy",uInfo.AccountName) , 
                         new SqlParameter("@CreateTime", DateTime.Now) ,  
                        new SqlParameter("@ProjectNo", ProjectNo) ,            
                        new SqlParameter("@ProjectName",ProjectName) ,            
                        new SqlParameter("@ProjectManager",ProjectManager) ,            
                        new SqlParameter("@ProjectClerk", ProjectClerk) ,            
                        new SqlParameter("@Remark", Remark) ,            
                        new SqlParameter("@UpdateTime", DateTime.Now) ,            
                        new SqlParameter("@UpdateBy", uInfo.AccountName) ,            
                        new SqlParameter("@AppendID", AppendID) 
            };
              int id = SqlHelper.ExecuteNonQuery(SqlHelper.connStr,CommandType.Text,strSql.ToString(),parameters);
              if (id > 0)
              {
                  return Content("{\"msg\":\"添加成功！\",\"success\":true}");
              }
              else
              {
                  return Content("{\"msg\":\"添加失败！\",\"success\":false}");
              }
            }
            catch (Exception ex)
            {
                return Content("{\"msg\":\"添加失败," + ex.Message.Trim().Replace("\r", "").Replace("\n", "") + "\",\"success\":false}");
            }
                      
        }
        /// <summary>
        /// 编辑项目单据
        /// </summary>
        /// <returns></returns>
        public ActionResult EditBasicProject()
        {
            try
            {                
                string ProjectID;
                if (Request["ProjectID"] == null)	{
		throw new Exception("没有获取到ProjectID");
	}
                    
                 ProjectID =Request["ProjectID"];
                 string ProjectNo = Request["ProjectNo"] == null ? "PM" + ProjectID : Request["ProjectNo"];
                string ProjectName = Request["ProjectName"] == null ? "" : Request["ProjectName"];
                string ProjectManager = Request["ProjectManager"] == null ? "" : Request["ProjectManager"];
                string ProjectClerk = Request["ProjectClerk"] == null ? "" : Request["ProjectClerk"];
                string Remark = Request["Remark"] == null ? "" : Request["Remark"];
                //string bsPSTime = Request["bsPSTime"] == null ? "" : Request["ProjectClerk"];
                //string AppendListID = Request["AppendListID"] == null ? "" : Request["AppendListID"];
                //string AppendID = Request["AppendID"] == null ? "" : Request["AppendID"];

                UserEntity uInfo = ViewData["Account"] as UserEntity;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update tbProject set ");
                strSql.Append("ProjectNo =@ProjectNo,ProjectName=@ProjectName,ProjectManager=@ProjectManager,ProjectClerk=@ProjectClerk,Remark=@Remark,UpdateTime=@UpdateTime,UpdateBy=@UpdateBy");
                
                strSql.Append(" where ProjectID=@ProjectID ");

                SqlParameter[] parameters = {
			            new SqlParameter("@ProjectID", ProjectID) , 
                        new SqlParameter("@ProjectNo", ProjectNo) ,            
                        new SqlParameter("@ProjectName",ProjectName) ,            
                        new SqlParameter("@ProjectManager",ProjectManager) ,            
                        new SqlParameter("@ProjectClerk", ProjectClerk) ,            
                        new SqlParameter("@Remark", Remark) ,            
                        new SqlParameter("@UpdateTime", DateTime.Now) ,            
                        new SqlParameter("@UpdateBy", uInfo.AccountName) ,            
                      
            };
                int id = SqlHelper.ExecuteNonQuery(SqlHelper.connStr, CommandType.Text, strSql.ToString(), parameters);
                if (id > 0)
                {
                    return Content("{\"msg\":\"更新成功！\",\"success\":true}");
                }
                else
                {
                    return Content("{\"msg\":\"更新失败！\",\"success\":false}");
                }
            }
            catch (Exception ex)
            {
                return Content("{\"msg\":\"更新失败," + ex.Message.Trim().Replace("\r", "").Replace("\n", "") + "\",\"success\":false}");
            }

        }
        /// <summary>
        /// 项目管理甘特图
        /// </summary>
        /// <returns></returns>
        public ActionResult PMGantt()
        {
            return View();
        }
        /// <summary>
        /// 项目管理甘特图的json数据
        /// </summary>
        /// <returns></returns>
        public ActionResult PMGanttJson()
        {
            return View();
            //查找所有项目
            string sql = "select ProjectID,ProjectNo,ProjectName from tbProject where 1=1";
            DataTable projectdt= AchieveCommon.SqlHelper.GetDataTable(SqlHelper.connStr, sql);
            StringBuilder jsonResult=new StringBuilder();
            jsonResult.Append("[{\"name\":");
            foreach (DataRow dr in projectdt.Rows)
            {
                string drs="{\"name\":";
                drs+=string.Format("\"{0} {1}\",",dr["ProjectNo"].ToString(),dr["ProjectName"].ToString());
               //查询子表，获取项目节点信息
                dr["ProjectNo"]
            }

        }
        /// <summary>
        /// 项目清单的查询处理
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllPMInfo()
        {
            string strWhere = "1=1";
            string sort = Request["sort"] == null ? "ProjectID" : Request["sort"];
            string order = Request["order"] == null ? "desc" : Request["order"];
            string view = Request["view"] == null ? "PMMaintain" : Request["view"];

            //首先获取前台传递过来的参数
            int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);//输出的数据页码
            int pagesize = Request["rows"] == null ? 10 : Convert.ToInt32(Request["rows"]);//每页输出数量

            string ProjectID = Request["ProjectID"] == null ? "" : Request["ProjectID"];
            string ProjectNo = Request["ProjectNo"] == null ? "" : Request["ProjectNo"];
            string ProjectName = Request["ProjectName"] == null ? "" : Request["ProjectName"];

            string CreateTimeS = Request["CreateTime"] == null ? "" : Request["CreateTime"];
            string CreateTimeE = Request["CreateTime"] == null ? "" : Request["CreateTime"];

            if (ProjectID.Trim() != "" && !SqlInjection.GetString(ProjectID))   //防止sql注入
                strWhere += string.Format(" and ProjectID = '{0}'", ProjectID.Trim());
            if (ProjectNo.Trim() != "" && !SqlInjection.GetString(ProjectNo))
                strWhere += string.Format(" and ProjectNo like '%{0}%'", ProjectNo.Trim());
            if (ProjectName.Trim() != "" && !SqlInjection.GetString(ProjectName))
                strWhere += string.Format(" and ProjectName like '%{0}%'", ProjectName.Trim());

            if (CreateTimeS.Trim() != "")
                strWhere += " and CreateTime > '" + CreateTimeS.Trim() + "'";
            if (CreateTimeE.Trim() != "")
                strWhere += " and CreateTime < '" + CreateTimeE.Trim() + "'";

            string content = "";
            if (view == "PMMaintain")
            {
                int totalCount;   //输出参数 
                DataTable dt = AchieveCommon.SqlPagerHelper.GetPager("tbProject", "ProjectID,ProjectNo,ProjectName,ProjectManager,ProjectClerk,CreateBy,CreateTime,UpdateTime,UpdateBy,Remark", sort + " " + order, pagesize, pageindex, strWhere, out totalCount);
                //string strJson = new ProjectBLL().GetJsonPager("ICMO", "FBillNo,FStatus,FQty,FCommitQty,FPlanCommitDate,FPlanFinishDate,FStartDate,FFinishDate,FType,FWorkShop,FItemID", sort + " " + order, pagesize, pageindex, strWhere, out totalCount);
                string strJson = AchieveCommon.JsonHelper.ToJson(dt);
                content = "{\"total\": " + totalCount.ToString() + ",\"rows\":" + strJson + "}";
            }
            if (view == "PMGantt")
            {
                int totalCount;   //输出参数
                // pagesize = 5;//限制甘特图输出数据量
                //DataTable dt = new ProjectBLL().GetDataTablePager("ICMO", "FBillNo,FStatus,FPlanCommitDate,FPlanFinishDate,FStartDate,FFinishDate,FItemID", sort + " " + order, pagesize, pageindex, strWhere, out totalCount);
                //string strJson = ToGanttJson(dt);
                //content = "{\"total\": " + totalCount.ToString() + ",\"rows\":" + strJson + "}";
            }

            return Content(content);
        }
       /// <summary>
       /// 获取项目的节点详情
       /// </summary>
       /// <returns></returns>
        public ActionResult GetPMNodeInfo()
        {
            //首先获取前台传递过来的参数
            string strWhere = "1=1";           
            string view = Request["view"] == null ? "PMMaintain" : Request["view"];
            string ProjectID = Request["ProjectID"] == null ? "" : Request["ProjectID"];
            string ProjectNo = Request["ProjectNo"] == null ? "" : Request["ProjectNo"];
            string ProjectName = Request["ProjectName"] == null ? "" : Request["ProjectName"];
            if (ProjectID.Trim() != "" && !SqlInjection.GetString(ProjectID))   //防止sql注入
                strWhere += string.Format(" and ProjectID = '{0}'", ProjectID.Trim()); 
            string content = "";           
            try
            {
                string sqlstr =string.Format( "select * from tbMgrNodeInfo where ProjectID='{0}'" , ProjectID);
                DataTable dt = AchieveCommon.SqlHelper.GetDataTable(SqlHelper.connStr,sqlstr);
                string strJson = AchieveCommon.JsonHelper.ToJson(dt);
                content = "{\"success\": true ,\"rows\":" + strJson + "}";  
            }
            catch (Exception ex)
            {
                return Content("{\"msg\":\"获取数据失败," + ex.Message.Trim().Replace("\r", "").Replace("\n", "") + "\",\"success\":false}");
            }           

            return Content(content);
        }
        /// <summary>
        /// 项目管理--更新项目进度视图
        /// </summary>
        /// <returns></returns>
        public ActionResult PMEdit()
        {
            return View();
        }
        /// <summary>
        /// 项目管理--更新项目进度，数据更新操作
        /// </summary>
        /// <returns></returns>
        public ActionResult EditPM()
        {
            try
            {
                UserEntity uInfo = ViewData["Account"] as UserEntity;
                string updateby = uInfo.RealName;
                string ProjectID =Request["ProjectID"];
                string PSTime =Request["bsPSTime"];
                string PETime=Request["bsPETime"];
                string RSTime =Request["bsRSTime"];
                string RETime=Request["bsRETime"];
                saveNode("2", "项目商务", ProjectID, PSTime, PETime, RSTime, RETime, uInfo.AccountName);
                 PSTime = Request["tyPSTime"];
                 PETime = Request["tyPETime"];
                 RSTime = Request["tyRSTime"];
                 RETime = Request["tyRETime"];
                 saveNode("3", "技术方案", ProjectID, PSTime, PETime, RSTime, RETime, uInfo.AccountName);

                 PSTime = Request["dnPSTime"];
                 PETime = Request["dnPETime"];
                 RSTime = Request["dnRSTime"];
                 RETime = Request["dnRETime"];
                 saveNode("4", "设计管理", ProjectID, PSTime, PETime, RSTime, RETime, uInfo.AccountName);

                 PSTime = Request["mePSTime"];
                 PETime = Request["mePETime"];
                 RSTime = Request["meRSTime"];
                 RETime = Request["meRETime"];
                 saveNode("5", "生产管理", ProjectID, PSTime, PETime, RSTime, RETime, uInfo.AccountName);

                 PSTime = Request["cnPSTime"];
                 PETime = Request["cnPETime"];
                 RSTime = Request["cnRSTime"];
                 RETime = Request["cnRETime"];
                 saveNode("6", "施工管理", ProjectID, PSTime, PETime, RSTime, RETime, uInfo.AccountName);
              
                    return Content("{\"msg\":\"修改成功！\",\"success\":true}");         

            }
            catch (Exception ex)
            {
                return Content("{\"msg\":\"修改失败," + ex.Message + "\",\"success\":false}");
            }
        }
       /// <summary>
       /// 保持项目节点信息
       /// </summary>
       /// <param name="nodeid"></param>
       /// <param name="projectID"></param>
       /// <param name="ps">计划开始时间</param>
       /// <param name="pe"></param>
       /// <param name="rs"></param>
       /// <param name="re">实际结束时间</param>
       /// <returns></returns>
        public static bool saveNode(string nodeid,string nodename,string projectID,string ps,string pe,string rs,string re,string AccountName){            
            string strsql= string.Format("select count(*) from tbMgrNodeInfo where ProjectID='{0}' and nodeID='{1}'",projectID,nodeid);
            int n =Convert.ToInt32( AchieveCommon.SqlHelper.ExecuteScalar(SqlHelper.connStr, strsql));
            int x;
            if (n==0)
            {
                string InfoID = AchieveCommon.SqlHelper.GetSerialNumber("tbMgrNodeInfo", "InfoID");
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into tbMgrNodeInfo(");
                strSql.Append("InfoID,pstime,petime,rstime,retime,projectID,nodeid,nodename,UpdateBy");//,UpdateTime");
                strSql.Append(") values (");
                strSql.Append("@InfoID,@pstime,@petime,@rstime,@retime,@projectID,@nodeid,@nodename,@UpdateBy");//@UpdateTime,
                strSql.Append(") ");
                SqlParameter[] parameters = {
			            new SqlParameter("@InfoID", InfoID) ,            
                        new SqlParameter("@pstime", ps) ,            
                        new SqlParameter("@petime",pe) , 
                         new SqlParameter("@rstime", rs) ,  
                        new SqlParameter("@retime", re) ,            
                        new SqlParameter("@projectID",projectID) ,            
                        new SqlParameter("@nodeid",nodeid) ,                                          
                        new SqlParameter("@nodename", nodename) ,            
                    //   new SqlParameter("@UpdateTime", DateTime.Now.ToString()) ,            
                        new SqlParameter("@UpdateBy", AccountName) 
            };
               x= SqlHelper.ExecuteNonQuery(SqlHelper.connStr, CommandType.Text, strSql.ToString(), parameters);              
            }
            else                
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update tbMgrNodeInfo set ");
                strSql.Append("pstime=@pstime,petime=@petime,rstime=@rstime,retime=@retime,UpdateTime=@UpdateTime,UpdateBy=@UpdateBy where projectID=@projectID and nodeid=@nodeid");
              
                SqlParameter[] parameters = {		                   
                        new SqlParameter("@pstime", ps) ,            
                        new SqlParameter("@petime",pe) , 
                         new SqlParameter("@rstime", rs) ,  
                        new SqlParameter("@retime", re) ,            
                        new SqlParameter("@projectID",projectID) ,            
                        new SqlParameter("@nodeid",nodeid) ,        
                        new SqlParameter("@UpdateTime", DateTime.Now) ,            
                        new SqlParameter("@UpdateBy", AccountName) 
            };
                x = SqlHelper.ExecuteNonQuery(SqlHelper.connStr, CommandType.Text, strSql.ToString(), parameters);   
       
            }
            if (x > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 项目管理
        /// </summary>
        /// <returns></returns>
        public ActionResult PMMaintain()
        {
            return View();
        }
       /// <summary>
       /// 项目基本信息维护界面
       /// </summary>
       /// <returns></returns>
        public ActionResult PMBasicMaintain()
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
