using AchieveBLL;
using AchieveCommon;
using AchieveEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace AchieveManageWeb.Controllers
{
    [AchieveManageWeb.App_Start.JudgmentLogin]
    public class ProjectController : Controller
    {

        public ActionResult getGantt2Demo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" [");
            sb.Append("{	\"name\": \"task  3\",	\"desc\": \"from server\",	\"values\": [{\"from\": \"/Date(1323802400000)/\",	\"to\": \"/Date(1325685200000)/\",	\"label\": \"\",	\"customClass\": \"ganttGreen\"	}]}, ");
            sb.Append("{	\"name\": \"more\",	\"desc\": \"for gantt2\",	\"values\": [{	\"from\": \"/Date(1322611200000)/\",	\"to\": \"/Date(1323302400000)/\",		\"label\": \"\",		\"customClass\": \"ganttBlue\"	}, {		\"from\": \"/Date(1323802400000)/\",		\"to\": \"/Date(1325685200000)/\",		\"label\": \"\",		\"customClass\": \"ganttorange\"	}]}");
            sb.Append(" ]");


            return Content(sb.ToString());
        }
        public ActionResult GetGanttDemo()
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
            return  Content(sb.ToString());
        }
        
        //
        // GET: /Project/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult projectGantt()
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
