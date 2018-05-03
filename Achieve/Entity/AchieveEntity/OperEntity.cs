using System;
namespace AchieveEntity
{
    public class OperEntity
    {
        public OperEntity()
        { 
        }
        public int OperID { get; set; }
        public string OperNote { get; set; }
        public float DayTime { get; set; }
        public float WeekTime { get; set; }
        public float MonthTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateBy { get; set; }
        public string CheckBy { get; set; }
        public DateTime CheckTime { get; set; }
        public bool ischeck { get; set; }
        public string Remark { get; set; }

    }
}
