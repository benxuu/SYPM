using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;

namespace DAL
{
    public partial class ICMO
    {
        public ICMO()
        { }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append("FBillNo,FStatus,FQty,FCommitQty,FPlanCommitDate,FPlanFinishDate,");
            strSql.Append("FStartDate,FFinishDate,FType,FWorkShop,FItemID");
            strSql.Append(" FROM ICMO ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
