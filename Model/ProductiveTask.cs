using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ims.Model
{
   public class ProductiveTask:ICMO
    {
        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime DocumentationDate;
        /// <summary>
        /// 关闭标志
        /// </summary>
        public int CloseTag;
        /// <summary>
        /// 物料名称
        /// </summary>
        public string ItemName;
        /// <summary>
        /// 规格型号
        /// </summary>
        public string Model;
        /// <summary>
        /// 是否领料
        /// </summary>
        public int IsPick;
        
    }
}
