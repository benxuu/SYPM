﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AchieveCommon
{
    
        public class DateHelper
        {
             /// <summary>
            /// 确定某时间属于一年的第几周，如果12月31号与下一年的1月1好在同一个星期则算下一年的第一周 
            /// </summary>
            /// <param name="dTime"></param>
            /// <returns></returns>
            public static int GetWeekIndex(DateTime dTime)
            {
                try
                {
                    //确定此时间在一年中的位置  
                    var dayOfYear = dTime.DayOfYear;
                    //当年第一天  
                    var tempDate = new DateTime(dTime.Year, 1, 1);
                    //确定当年第一天  
                    var tempDayOfWeek = (int)tempDate.DayOfWeek;
                    tempDayOfWeek = tempDayOfWeek == 0 ? 7 : tempDayOfWeek;
                    //确定星期几  
                    var index = (int)dTime.DayOfWeek;
                    index = index == 0 ? 7 : index;
                    //当前周的范围  
                    DateTime retStartDay = dTime.AddDays(-(index - 1));
                    DateTime retEndDay = dTime.AddDays(7 - index);
                    //确定当前是第几周  
                    var weekIndex = (int)Math.Ceiling(((double)dayOfYear + tempDayOfWeek - 1) / 7);
                    if (retStartDay.Year < retEndDay.Year)
                    {
                        weekIndex = 1;
                    }

                    return weekIndex;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }


            public static int GetWeekIndex(string strDate)
            {
                try
                {
                    //需要判断的时间  
                    DateTime dTime = Convert.ToDateTime(strDate);
                    return GetWeekIndex(dTime);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            //改写dayofweek方法，使周日为7
            public static int dayOfWeek(DateTime dt) {
                return (int)dt.DayOfWeek == 0 ? 7 : (int)dt.DayOfWeek;
            }
            /// <summary>  
            /// 用年份和第几周来获得一周开始和结束的时间,这里用星期一做开始。  
            /// </summary>  
            public static void GetWeek(int year, int weekNum, out DateTime weekStart, out DateTime weekEnd)
            {
                var dateTime = new DateTime(year, 1, 1);
                dateTime = dateTime.AddDays(7 * weekNum-1);
                weekStart = dateTime.AddDays(-dayOfWeek(dateTime) + (int)DayOfWeek.Monday);
                weekEnd = dateTime.AddDays((int)DayOfWeek.Saturday - dayOfWeek(dateTime) + 1);
               // Console.WriteLine("weekNum:{0} --start:{1}--end:{2}", weekNum, weekStart.ToString(), weekEnd.ToString());
                System.Diagnostics.Debug.WriteLine("weekNum:{0} --start:{1}--end:{2}", weekNum, weekStart.ToString(), weekEnd.ToString());
            }
           
            /// <summary> 求某年有多少周  
            /// </summary>  
            public static int GetYearWeekCount(int year)
            {
                var dateTime = DateTime.Parse(year + "-01-01");
                var firstDayOfWeek = Convert.ToInt32(dateTime.DayOfWeek);//得到该年的第一天是周几   
                if (firstDayOfWeek == 1)
                {
                    var countDay = dateTime.AddYears(1).AddDays(-1).DayOfYear;
                    var countWeek = countDay / 7 + 1;
                    return countWeek;
                }
                else
                {
                    var countDay = dateTime.AddYears(1).AddDays(-1).DayOfYear;
                    var countWeek = countDay / 7 + 2;
                    return countWeek;
                }
            }

            /// <summary>  
            /// 求当前日期是一年的中第几周  
            /// </summary>  
            //public static int WeekOfYear(DateTime todayTime)
            //{
            //    var firstdayofweek = Convert.ToInt32(Convert.ToDateTime(todayTime.Year.ToString(CultureInfo.InvariantCulture) + "- " + "1-1 ").DayOfWeek);
            //    var days = todayTime.DayOfYear;
            //    var daysOutOneWeek = days - (7 - firstdayofweek);
            //    if (daysOutOneWeek <= 0)
            //    {
            //        return 1;
            //    }
            //    var weeks = daysOutOneWeek / 7;
            //    if (daysOutOneWeek % 7 != 0)
            //        weeks++;
            //    return weeks + 1;
            //}

            /// <summary>  
            /// 当前月有多少天  
            /// </summary>  
            public static int HowMonthDay(int year, int month)
            {
                int next_month;
                int next_year;
                if (month < 12)
                {
                    next_month = month + 1;
                    next_year = year;
                }
                else
                {
                    next_month = 1;
                    next_year = year + 1;
                }
                DateTime dt1 = Convert.ToDateTime(year + "-" + month + "-1");
                DateTime dt2 = Convert.ToDateTime(next_year + "-" + next_month + "-1");
                TimeSpan diff = dt2 - dt1;
                return diff.Days;
            }

            public static string GetDateTimeString(DateTime dt) {
                //CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
                //string format = "ddd MMM d HH:mm:ss zz00 yyyy";
                return dt.ToString("yyyy-MM-dd HH:mm:ss"); // 得到日期字符串
            }
            public static DateTime GetDatetime(string strDate)
            {
                try
                {
                    //需要判断的时间  
                    DateTime dTime = Convert.ToDateTime(strDate);
                    return dTime;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }

            /// <summary>
            /// 将给定的DateTime转换成毫秒
            /// </summary>
            public static long DateTimeToMilliseconds(DateTime dt)
            {
                DateTime dt_1970 = new DateTime(1970, 1, 1);
                TimeSpan span = dt - dt_1970;

                // .net开发中计算的都是标准时区的差，但java的解析时间跟时区有关，
                // 而我们的java服务器系统时区不是标准时区，解析时间会差8个小时。
                span -= TimeSpan.FromHours(8);

                return (long)span.TotalMilliseconds;
            }

            /// <summary>
            /// 将给定的毫秒数转换成DateTime
            /// </summary>
            public static DateTime MillisecondsToDateTime(long milliseconds)
            {
                DateTime dt_1970 = new DateTime(1970, 1, 1);

                //// .net开发中计算的都是标准时区的差，但java的解析时间跟时区有关，
                // 而我们的java服务器系统时区不是标准时区，解析时间会差8个小时。
                TimeSpan span = TimeSpan.FromMilliseconds(milliseconds) + TimeSpan.FromHours(8);

                return dt_1970 + span;
            }
        }  
    }
 
