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
        public DataTable GetProjectDataTablePager(int startPage, int endPage, string where, out int totalCount, string order = "order by FPlanCommitDate desc")
        { 
            StringBuilder sbsql=new StringBuilder();
            sbsql.Append("select FBillNo,FStatus,FName,FModel,FQty,FCommitQty,FPlanCommitDate,FPlanFinishDate,FStartDate,FFinishDate,FType,FWorkShop,FItemID from (");
            sbsql.AppendFormat(" select row_number() over({0})",order);
            sbsql.Append(" as Rownum,FBillNo,FStatus,FQty,FCommitQty,FPlanCommitDate,FPlanFinishDate,FStartDate,FFinishDate,FType,FWorkShop,ICMO.FItemID as FItemID,FName,FModel ");
            sbsql.Append(" from ICMO left join t_ICITEMCORE on ICMO.FItemID=t_ICITEMCORE.FItemID where ");
            sbsql.Append(where);
            sbsql.AppendFormat(") as T where T.Rownum between  {0}  and  {1}" ,startPage,endPage);
            DataTable dt = AchieveCommon.SqlHelper.GetDataTable(SqlHelper.connStrK3,CommandType.Text,sbsql.ToString(),null);
           StringBuilder sbtotalsql=new StringBuilder();
            sbtotalsql.AppendFormat(" select  count(*) from ICMO left join t_ICITEMCORE on ICMO.FItemID=t_ICITEMCORE.FItemID where {0}",where);
           DataTable dttotal= AchieveCommon.SqlHelper.GetDataTable(SqlHelper.connStrK3,CommandType.Text,sbtotalsql.ToString(),null);
           totalCount = Convert.ToInt32(dttotal.Rows[0][0]);
           dt.Columns.Add(new DataColumn("FStockQty"));
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               DataTable dticitemcore = GetFQTYByFItemID(Convert.ToInt32(dt.Rows[i]["FItemID"]));
              // dt.Rows[i]["FStockQty"] = AchieveCommon.JsonHelper.ColumnToJson(dticitemcore, 0) ;
               dt.Rows[i]["FStockQty"] = dticitemcore.Rows[0][0].GetType() ==typeof( DBNull) ? 0 : Convert.ToSingle(dticitemcore.Rows[0][0]);
           }
            return dt;
        }
        public string GetJsonPager(int startPage, int endPage, string where, out int totalCount, string order = "order by FPlanCommitDate desc")
        {
            DataTable dt =GetProjectDataTablePager( startPage,  endPage,  where, out  totalCount,  order );
            return AchieveCommon.JsonHelper.ToJson(dt);
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
        public string GetJsonFromSqlK3(string sql)
        {
          DataTable dt = AchieveCommon.SqlHelper.GetDataTable(SqlHelper.connStrK3, CommandType.Text, sql);
            return AchieveCommon.JsonHelper.ToJson(dt);
        }
        /// <summary>
        /// 根据物料ID查找物料名称、规格型号等信息
        /// </summary>
        /// <param name="FItemID"></param>
        /// <returns></returns>
        public  DataTable GetFNameByFItemID(int FItemID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select FModel,FName from t_icitemcore");
            sb.Append(" where FItemID=@Id");
            return SqlHelper.GetDataTable(SqlHelper.connStrK3, CommandType.Text, sb.ToString(), new SqlParameter("@Id", FItemID));
        }
        /// <summary>
        /// 根据物料ID查询物料库存数量
        /// </summary>
        /// <param name="FItemID"></param>
        /// <returns></returns>
        public DataTable GetFQTYByFItemID(int FItemID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select sum(FQty) from ICINVENTORy ");
            sb.Append(" where FItemID=@Id");
            return SqlHelper.GetDataTable(SqlHelper.connStrK3, CommandType.Text, sb.ToString(), new SqlParameter("@Id", FItemID));
        }

        public DataTable GetFItemIDByFName(string FName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select FItemID from t_icitemcore");
            sb.Append(" where FName like '%"+FName+"%'");
            return SqlHelper.GetDataTable(SqlHelper.connStrK3, CommandType.Text, sb.ToString(), null);
        }

      

    }
}
