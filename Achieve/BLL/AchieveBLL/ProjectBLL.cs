using AchieveCommon;
using AchieveDALFactory;
using AchieveEntity;
using AchieveInterfaceDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace AchieveBLL
{
    /// <summary>
    /// 生产任务的业务逻辑层
    /// </summary>
    public class ProjectBLL
    {
        IProduceDAL dal = DALFactory.GetProduceDAL();
        public DataTable GetAllProduceData(string strwhere)
        {
            return dal.GetAllProduceData(strwhere);
        }
        /// <summary>
        /// 获取生产任务单-分页数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columns"></param>
        /// <param name="order"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="where"></param>
        /// <param name="totalCount"></param>
        /// <returns>返回DataTable</returns>
        public DataTable GetDataTablePager(string tableName, string columns, string order, int pageSize, int pageIndex, string where, out int totalCount)
        {
            DataTable dt = AchieveCommon.SqlPagerHelper.GetPagerK3("ICMO", "FBillNo,FStatus,FQty,FCommitQty,FPlanCommitDate,FPlanFinishDate,FStartDate,FFinishDate,FType,FWorkShop,FItemID", order, pageSize, pageIndex, where, out totalCount);
            dt.Columns.Add(new DataColumn("FModel"));
            dt.Columns.Add(new DataColumn("FName"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dticitemcore = GetFNameByFItemID(Convert.ToInt32(dt.Rows[i]["FItemID"]));
                dt.Rows[i]["FModel"] = AchieveCommon.JsonHelper.ColumnToJson(dticitemcore, 0);
                dt.Rows[i]["FName"] = AchieveCommon.JsonHelper.ColumnToJson(dticitemcore, 1);
            }
            return dt;
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columns">要取的列名（逗号分开）</param>
        /// <param name="order">排序</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="where">查询条件</param>
        /// <param name="totalCount">总记录数</param>
        public string GetJsonPager(string tableName, string columns, string order, int pageSize, int pageIndex, string where, out int totalCount)
        {
            DataTable dt = GetDataTablePager(tableName, columns, order, pageSize, pageIndex, where, out totalCount);
            return AchieveCommon.JsonHelper.ToJson(dt);
         }

        public  DataTable GetFNameByFItemID(int FItemID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select FModel,FName from t_icitemcore");
            sb.Append(" where FItemID=@Id");
            return SqlHelper.GetDataTable(SqlHelper.connStrK3, CommandType.Text, sb.ToString(), new SqlParameter("@Id", FItemID));
        }

      

    }
}
