using AchieveBLL;
using AchieveCommon;
using AchieveEntity;
using AchieveManageWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Text;

namespace AchieveManageWeb.Controllers
{
    [AchieveManageWeb.App_Start.JudgmentLogin]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            UserEntity uInfo = ViewData["Account"] as UserEntity;
            if (uInfo == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.RealName = uInfo.RealName;
            ViewBag.TimeView = DateTime.Now.ToLongDateString();
            ViewBag.DayDate = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            return View();
        }


        public ActionResult IndexNew()
        {
            UserEntity uInfo = ViewData["Account"] as UserEntity;
            if (uInfo == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.RealName = uInfo.RealName;
            ViewBag.TimeView = DateTime.Now.ToLongDateString();
            ViewBag.DayDate = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            return View();
        }
        public ActionResult WeekOper()
        {           
            return View();
        }
        /// <summary>
        /// 查询出数据显示在菜单栏目中
        /// </summary>
        /// <returns></returns>
        public ActionResult LoadMenuData()
        {
            UserEntity uInfo = ViewData["Account"] as UserEntity;
            string menuJson = new MenuBLL().GetUserMenu(uInfo.ID);
            return Content(menuJson);
        }

        public ActionResult GetOperWeekAlert()
        {
            //UserEntity uInfo = ViewData["Account"] as UserEntity;
            int thisweek = DateHelper.GetWeekIndex(DateTime.Now);
            string key = Request["key"];//调整前后周，往后调整为负值
            int weekadjust = Request["weekadjust"]==null?0: Convert.ToInt32(Request["weekadjust"]);//调整前后周，往后调整为负值
            if (key=="columns")
            {
                string columns = "[{ \"width\": 100, \"title\": \"工艺\", \"field\":\"OperGroupName\", \"sortable\": \"false\" }";
                columns += ",{ \"width\": 60, \"title\": \"标准周能力\", \"field\":\"DayTime\", \"sortable\": \"false\" }";
                columns += ",{ \"width\": 60, \"title\": \"预警%\", \"field\":\"AlertValue\", \"sortable\": \"false\" }";
                for (int i = (thisweek + weekadjust - 4) > 0 ? thisweek + weekadjust - 4 : 0; i <= thisweek + weekadjust; i++)
                {
                    string cname = i.ToString();
                    if (i == thisweek)
                    {
                        cname = "本周";
                    }
                    else { cname = "第"+i+"周"; }
                    columns += ",{ \"width\": 60, \"title\": \"" + cname + "\", \"field\":\"" + i + "\", \"sortable\": \"false\" }";
                }
                columns += "]";
                return Content("{\"thisweek\": " + thisweek.ToString() + ",\"success\":true" + ",\"columns\":" + columns + "}"); 
            }
            string strJson = new CockpitBLL().getJsonOperAlert(thisweek+weekadjust);

            return Content("{\"total\": " + thisweek.ToString() +  ",\"rows\":" + strJson + "}");
            
        } 

        /// <summary>
        /// 判断是否修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckIsChangePwd()
        {
            UserEntity uInfo = ViewData["Account"] as UserEntity;
            return Content("{\"msg\":" + new JavaScriptSerializer().Serialize(uInfo) + ",\"success\":true}");
        }

        /// <summary>
        /// 获取导航菜单
        /// </summary>
        /// <param name="id">所属</param>
        /// <returns>树</returns>
        public JsonResult GetTreeByEasyui(string id)
        {
            try
            {
                UserEntity uInfo = ViewData["Account"] as UserEntity;
                if (uInfo != null)
                {
                    DataTable dt = new MenuBLL().GetUserMenuData(uInfo.ID, int.Parse(id));
                    List<SysModuleNavModel> list = new List<SysModuleNavModel>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SysModuleNavModel model = new SysModuleNavModel();
                        model.id = dt.Rows[i]["menuid"].ToString();
                        model.text = dt.Rows[i]["menuname"].ToString();
                        model.attributes = dt.Rows[i]["linkaddress"].ToString();
                        model.iconCls = dt.Rows[i]["icon"].ToString();
                        if (new MenuBLL().GetMenuList(" AND ParentId= " + model.id).Rows.Count > 0)
                        {
                            model.state = "closed";
                        }
                        else
                        {
                            model.state = "open";
                        }
                        list.Add(model);
                    }
                    return Json(list);
                }
                else
                {
                    return Json("0", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
