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
        public ActionResult OperMgr()
        {
            return View();
        }

        /// <summary>
        /// 新增工序操作
        /// </summary>
        /// <returns></returns>
        public ActionResult AddOper()
        {
            try
            {
                UserEntity uInfo = ViewData["Account"] as UserEntity;
                            OperEntity oper = new OperEntity();
                oper.OperID = int.Parse(Request["FoperID"]);
                oper.UpdateTime = DateTime.Now;
                oper.UpdateBy = uInfo.AccountName;
                oper.OperNote = Request["OperNote"];
                oper.DayTime = float.Parse(Request["DayTime"]);
                oper.WeekTime = float.Parse(Request["WeekTime"]);
                oper.MonthTime = float.Parse(Request["MonthTime"]);
                int operid = new AchieveBLL.ProduceBLL().AddOper(oper);
                //int operid = new AchieveDAL.ProduceDAL().AddOper(oper);
                if (operid > 0)
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
                return Content("{\"msg\":\"添加失败," + ex.Message + "\",\"success\":false}");
            }
        }
        /// <summary>
        /// 新增工序页面展示
        /// </summary>
        /// <returns></returns>
        public ActionResult OperAdd()
        {
            return View();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public ActionResult AddButton()
        {
            try
            {
                UserEntity uInfo = ViewData["Account"] as UserEntity;
                ButtonEntity buttonAdd = new ButtonEntity();
                buttonAdd.Name = Request["Name"];
                buttonAdd.Code = Request["Code"];
                buttonAdd.Icon = Request["Icon"];
                buttonAdd.Sort = int.Parse(Request["Sort"]);
                buttonAdd.Description = Request["Description"];
                buttonAdd.CreateBy = uInfo.AccountName;
                buttonAdd.CreateTime = DateTime.Now;
                buttonAdd.UpdateBy = uInfo.AccountName;
                buttonAdd.UpdateTime = DateTime.Now;
                int buttonId = new ButtonBLL().AddButton(buttonAdd);
                if (buttonId > 0)
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
                return Content("{\"msg\":\"添加失败," + ex.Message + "\",\"success\":false}");
            }
        }

        /// <summary>
        /// 编辑页面展示
        /// </summary>
        /// <returns></returns>
        public ActionResult ButtonEdit()
        {
            return View();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult EditButton()
        {
            try
            {
                int id = Convert.ToInt32(Request["id"]);
                string originalName = Request["originalName"];
                UserEntity uInfo = ViewData["Account"] as UserEntity;
                ButtonEntity buttonEdit = new ButtonEntity();
                buttonEdit.Id = id;
                buttonEdit.Name = Request["Name"];
                buttonEdit.Code = Request["Code"];
                buttonEdit.Icon = Request["Icon"];
                buttonEdit.Sort = int.Parse(Request["Sort"]);
                buttonEdit.Description = Request["Description"];
                buttonEdit.UpdateBy = uInfo.AccountName;
                buttonEdit.UpdateTime = DateTime.Now;
                bool result = new ButtonBLL().EditButton(buttonEdit, originalName);
                if (result)
                {
                    return Content("{\"msg\":\"修改成功！\",\"success\":true}");
                }
                else
                {
                    return Content("{\"msg\":\"修改失败！\",\"success\":false}");
                }
            }
            catch (Exception ex)
            {
                return Content("{\"msg\":\"修改失败," + ex.Message + "\",\"success\":false}");
            }
        }

        public ActionResult DelButtonByIDs()
        {
            try
            {
                string Ids = Request["IDs"] == null ? "" : Request["IDs"];
                if (!string.IsNullOrEmpty(Ids))
                {
                    if (new ButtonBLL().DeleteButton(Ids))
                    {
                        return Content("{\"msg\":\"删除成功！\",\"success\":true}");
                    }
                    else
                    {
                        return Content("{\"msg\":\"删除失败！\",\"success\":false}");
                    }
                }
                else
                {
                    return Content("{\"msg\":\"删除失败！\",\"success\":false}");
                }
            }
            catch (Exception ex)
            {
                return Content("{\"msg\":\"删除失败," + ex.Message + "\",\"success\":false}");
            }
        }


        /// <summary>
        /// 获取所有工艺能力设置
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllOperInfo()
        {

            //string FBillNo = Request["FBillNo"];
            string sort = "OperID desc";
            int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
            int pagesize = Request["rows"] == null ? 8 : Convert.ToInt32(Request["rows"]);
            string strWhere = "1=1"; 
            int totalCount;   //输出参数           
            string strJson = new ProduceBLL().GetJsonPager("tbOper", "OperID,OperNote,DayTime,WeekTime,MonthTime,UpdateTime,UpdateBy,Remark", sort, pagesize, pageindex, strWhere, out totalCount);
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
