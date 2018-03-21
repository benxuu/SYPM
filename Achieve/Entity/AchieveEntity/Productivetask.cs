using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AchieveEntity
{
    public class Productivetask
    {

        /// <summary>
        /// 编号
        /// </summary>
        public string FBillNo { get; set; }
        /// <summary>
        /// 单据状态
        /// </summary>
        public int FStatus { get; set; }
        /// <summary>
        /// 计划数量
        /// </summary>
        public decimal FQty { get; set; }
        /// <summary>
        /// 实际数量
        /// </summary>
        public decimal FCommitQty { get; set; }
        /// <summary>
        /// 计划开工日期
        /// </summary>
        public DateTime FPlanCommitDate { get; set; }
        /// <summary>
        /// 计划完工日期
        /// </summary>
        public DateTime FPlanFinishDate { get; set; }
        /// <summary>
        /// 实际开工日期
        /// </summary>
        public DateTime FStartDate { get; set; }
        /// <summary>
        /// 实际完工日期
        /// </summary>
        public DateTime FFinishDate { get; set; }
        /// <summary>
        /// 表单类型
        /// </summary>
        public int FType { get; set; }
        /// <summary>
        /// 工作车间
        /// </summary>
        public int FWorkShop { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        public int FItemID { get; set; }

    }

}
