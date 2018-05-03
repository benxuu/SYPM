using AchieveCommon;
using AchieveEntity;
using AchieveInterfaceDAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace AchieveDAL
{
    /// <summary>
    /// 生产任务的数据库实现
    /// </summary>
    public class ProduceDAL:IProduceDAL
    {
        public DataTable GetAllProduceData(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.FBillNo,a.FStatus,a.FQty,a.FCommitQty,a.FPlanCommitDate,a.FPlanFinishDate,a.FStartDate,a.FFinishDate,a.FType,a.FWorkShop,a.FItemID, ");
            strSql.Append("b.FModel,b.FName FROM ICMO as a left join t_icitemcore as b on a.FItemID = b.FItemID  WHERE 1=1 " + strwhere);
            strSql.Append(" order by a.FBillNo ");
            
            return SqlHelper.GetDataTable(SqlHelper.connStrK3, CommandType.Text, strSql.ToString(), null);
        }
       
    }
}
