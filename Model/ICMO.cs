using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ims.Model
{
   
   public class ICMO
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string FBillNo;
        /// <summary>
        /// 单据状态
        /// </summary>
        public  int FStatus;
        /// <summary>
        /// 计划数量
        /// </summary>
        public decimal  FQty;
        /// <summary>
        /// 实际数量
        /// </summary>
        public decimal FCommitQty;
        /// <summary>
        /// 计划开工日期
        /// </summary>
        public DateTime FPlanCommitDate;
        /// <summary>
        /// 计划完工日期
        /// </summary>
        public DateTime FPlanFinishDate;
        /// <summary>
        /// 实际开工日期
        /// </summary>
          public DateTime FStartDate;
        /// <summary>
        /// 实际完工日期
        /// </summary>
          public DateTime FFinishDate;
        /// <summary>
        /// 表单类型
        /// </summary>
        public int FType;
        /// <summary>
        /// 工作车间
        /// </summary>
        public int  FWorkShop;
        /// <summary>
        /// 物料代码
        /// </summary>
        public int FItemID;

    }  


}

