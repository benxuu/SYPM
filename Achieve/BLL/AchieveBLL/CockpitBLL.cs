using AchieveCommon;
using AchieveDALFactory;
using AchieveEntity;
using AchieveInterfaceDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Timers;

namespace AchieveBLL
{
    public class CockpitBLL
    {
        
    }
    class alertTime
    {
        public DateTime week1start { get; set; }
        public DateTime week1end { get; set; }
        public DateTime week1start { get; set; }
        public DateTime week1end { get; set; }
        public DateTime week1start { get; set; }
        public DateTime week1end { get; set; }
        public DateTime week1start { get; set; }
        public DateTime week1end { get; set; }

//        DateTime dt = DateTime.Now;  //当前时间
//DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一
//DateTime endWeek = startWeek.AddDays(6);  //本周周日

//DateTime startMonth = dt.AddDays(1 - dt.Day);  //本月月初
//DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);  //本月月末//

//endMonth = startMonth.AddDays((dt.AddMonths(1) - dt).Days - 1);  //本月月末
//DateTime startQuarter = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day);  //本季度初
//DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1);  //本季度末

//DateTime startYear = new DateTime(dt.Year, 1, 1);  //本年年初
//DateTime endYear = new DateTime(dt.Year, 12, 31);  //本年年末至于昨天、明天、上周、上月、上季度、上年度等等，

//var 上周一 = DateTime.Now.AddDays(Convert.ToInt32(1 - Convert.ToInt32(DateTime.Now.DayOfWeek)) - 7);        //上周一
//var 上周末 = DateTime.Now.AddDays(Convert.ToInt32(1 - Convert.ToInt32(DateTime.Now.DayOfWeek)) - 7).AddDays(6);     //上周末（星期日）//下周
//var 下周一 = DateTime.Now.AddDays(Convert.ToInt32(1 - Convert.ToInt32(DateTime.Now.DayOfWeek)) + 7);        //下周一
//var 下周末 = DateTime.Now.AddDays(Convert.ToInt32(1 - Convert.ToInt32(DateTime.Now.DayOfWeek)) + 7).AddDays(6); //下周末 

//DateTime.Parse(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + "1").AddMonths(1).AddDays(-1).ToShortDateString();//最后一天
////巧用C#里ToString的字符格式化更简便
//DateTime.Now.ToString("yyyy-MM-01");//本月初
//DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToShortDateString();//本月最后一天
//DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(-1).ToShortDateString();//上个月1号
//DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddDays(-1).ToShortDateString();//上个月最后一天
//DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(1).ToShortDateString();// 下个月1号
//DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(2).AddDays(-1).ToShortDateString();//下下月最后一天
//DateTime.Now.AddDays(7).ToShortDateString();//7天后
//DateTime.Now.AddDays(-7).ToShortDateString();//7天前
//DateTime.Now.Date.ToShortDateString();//本年度，用ToString的字符格式化我们也很容易地算出本年度的第一天和最后一天

//DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).ToShortDateString();//本年度第一天
//DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(1).AddDays(-1).ToShortDateString();//本年度最后一天

//DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(-1).ToShortDateString(); //上年度第一天， 
//DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddDays(-1).ToShortDateString();//上年度第最后一天， 

//DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(1).ToShortDateString();  //下年度第一天
//DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(2).AddDays(-1).ToShortDateString();//下年度最后一天
////本季度，
//DateTime.Now.AddMonths(0 - ((DateTime.Now.Month - 1) % 3)).AddDays(1 - DateTime.Now.Day);//本季度第一天； 
//DateTime.Parse(DateTime.Now.AddMonths(3 - ((DateTime.Now.Month - 1) % 3)).ToString("yyyy-MM-01")).AddDays(-1).ToShortDateString();//本季度的最后一天
//DateTime.Now.AddMonths(3 - ((DateTime.Now.Month - 1) % 3)).ToString("yyyy-MM-01");//下季度的第一天
//DateTime.Parse(DateTime.Now.AddMonths(6 - ((DateTime.Now.Month - 1) % 3)).ToString("yyyy-MM-01")).AddDays(-1).ToShortDateString();// 下季度最后一天

//DateTime.Now.AddMonths(-3 - ((DateTime.Now.Month - 1) % 3)).AddDays(1 - DateTime.Now.Day);// 上季度第一天
//DateTime.Now.AddMonths(0 - ((DateTime.Now.Month - 1) % 3)).AddDays(1 - DateTime.Now.Day).AddDays(-1).ToShortDateString();// 上季度最后一天
    }
}
