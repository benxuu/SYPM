using System;
namespace AchieveEntity
{
    public class OperEntity
    {
        public OperEntity()
        {
        }
        public int FoperID { get;set;}
        public string fopernote { get; set; }
        public float daytime { get; set; }
        public float weektime { get; set; }
        public float monthtime { get; set; }
        public DateTime updatetime { get; set; }
        public string updateby { get; set; }
        public string checkby { get; set; }
        public DateTime checktime { get; set; }
        public bool ischeck { get; set; }

    }
}
