using AchieveCommon;
using AchieveDALFactory;
using AchieveEntity;
using AchieveInterfaceDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AchieveBLL
{
    public class ProduceBLL
    {
              public string GetJsonPager(string tableName, string columns, string order, int pageSize, int pageIndex, string where, out int totalCount)
        {
            DataTable dt = GetDataTablePager(tableName, columns, order, pageSize, pageIndex, where, out totalCount);
            return AchieveCommon.JsonHelper.ToJson(dt);
        }
        public DataTable GetDataTablePager(string tableName, string columns, string order, int pageSize, int pageIndex, string where, out int totalCount)
        {
            DataTable dt = AchieveCommon.SqlPagerHelper.GetPager(tableName, columns, order, pageSize, pageIndex, where, out totalCount);
            //dt.Columns.Add(new DataColumn("FModel"));
            //dt.Columns.Add(new DataColumn("FName"));
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataTable dticitemcore = GetFNameByFItemID(Convert.ToInt32(dt.Rows[i]["FItemID"]));
            //    dt.Rows[i]["FModel"] = AchieveCommon.JsonHelper.ColumnToJson(dticitemcore, 0);
            //    dt.Rows[i]["FName"] = AchieveCommon.JsonHelper.ColumnToJson(dticitemcore, 1);
            //}
            return dt;
        }

        /// <summary>
        /// 根据工艺名获取工艺
        /// </summary>
        public OperEntity GetOperByOperNote(string OperNote)
        {
            string sql = "select top 1  OperID,OperNote,DayTime,WeekTime,MonthTime,UpdateTime,UpdateBy,Remark from tbOper where OperNote = @OperNote";
            OperEntity oper = null;
            DataTable dt = SqlHelper.GetDataTable(SqlHelper.connStr, CommandType.Text, sql, new SqlParameter("@OperNote", OperNote));
            if (dt.Rows.Count > 0)
            {
                oper = new OperEntity();
                DataRowToModel(oper, dt.Rows[0]);
                return oper;
            }
            else
                return null;
        }

        /// <summary>
        /// 添加工艺
        /// </summary>
        public int AddOper(OperEntity Oper)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbOper([OperID],[OperNote],[DayTime],[WeekTime],[MonthTime],UpdateTime,Remark,UpdateBy)");
            strSql.Append(" values ");
            strSql.Append("(@OperID,@OperNote,@DayTime,@WeekTime,@MonthTime,@UpdateTime,@UpdateBy,@Remark)");
            strSql.Append(";SELECT @@IDENTITY");   //返回插入用户的主键
            SqlParameter[] paras = { 
                                   new SqlParameter("@OperID",SqlDbType.VarChar,50),
                                   new SqlParameter("@OperNote",SqlDbType.VarChar,50),
                                   new SqlParameter("@DayTime",SqlDbType.Decimal),
                                   new SqlParameter("@WeekTime",SqlDbType.Decimal),
                                   new SqlParameter("@MonthTime",SqlDbType.Decimal),
                                   new SqlParameter("@Remark",SqlDbType.NVarChar,100),
                                   new SqlParameter("@UpdateTime",SqlDbType.DateTime),
                                   new SqlParameter("@UpdateBy",SqlDbType.NVarChar,100)
                                   };
            paras[0].Value = Oper.OperID;
            paras[1].Value = Oper.OperNote;
            paras[2].Value = Oper.DayTime;
            paras[3].Value = Oper.WeekTime;
            paras[4].Value = Oper.MonthTime;
            paras[5].Value = Oper.Remark;
            paras[6].Value = Oper.UpdateTime;
            paras[7].Value = Oper.UpdateBy;
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras));
        }

        /// <summary>
        /// 删除工艺（删除按钮同时删除对应的：菜单按钮/角色菜单按钮【即权限】）
        /// </summary>
        public bool DeleteButton(string id)
        {
            List<string> list = new List<string>();
            list.Add("delete from tbButton where Id in (" + id + ")");
            list.Add("delete from [tbMenuButton] where ButtonId in (" + id + ")");
            list.Add("delete from [tbRoleMenuButton] where ButtonId in (" + id + ")");

            try
            {
                if (SqlHelper.ExecuteNonQuery(SqlHelper.connStr, list) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改 按钮
        /// </summary>
        public bool EditButton(ButtonEntity Button)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbButton set ");
            strSql.Append("Name=@Name,Code=@Code,Icon=@Icon,Sort=@Sort,Description=@Description,UpdateBy=@UpdateBy,UpdateTime=@UpdateTime");
            strSql.Append(" where Id=@Id");

            SqlParameter[] paras = { 
                                   new SqlParameter("@Id",SqlDbType.Int),
                                   new SqlParameter("@Name",SqlDbType.VarChar,50),
                                   new SqlParameter("@Code",SqlDbType.VarChar,50),
                                   new SqlParameter("@Icon",SqlDbType.VarChar,50),
                                   new SqlParameter("@Sort",SqlDbType.Int),
                                   new SqlParameter("@Description",SqlDbType.VarChar,100),
                                   new SqlParameter("@UpdateTime",SqlDbType.DateTime),
                                   new SqlParameter("@UpdateBy",SqlDbType.NVarChar,100)
                                   };
            paras[0].Value = Button.Id;
            paras[1].Value = Button.Name;
            paras[2].Value = Button.Code;
            paras[3].Value = Button.Icon;
            paras[4].Value = Button.Sort;
            paras[5].Value = Button.Description;
            paras[6].Value = Button.UpdateTime;
            paras[7].Value = Button.UpdateBy;
            object obj = SqlHelper.ExecuteNonQuery(SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras);
            if (Convert.ToInt32(obj) > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// 把DataRow行转成实体类对象
        /// </summary>
        private void DataRowToModel(OperEntity model, DataRow dr)
        {
            if (!DBNull.Value.Equals(dr["OperID"]))
            {
                model.OperID = int.Parse(dr["OperID"].ToString());
            }
            if (!DBNull.Value.Equals(dr["OperNote"]))
            {
                model.OperNote = dr["OperNote"].ToString();
            }
            if (!DBNull.Value.Equals(dr["DayTime"]))
            {
                model.DayTime = float.Parse(dr["DayTime"].ToString());
            }
            if (!DBNull.Value.Equals(dr["WeekTime"]))
            {
                model.WeekTime = float.Parse(dr["WeekTime"].ToString());
            }
            if (!DBNull.Value.Equals(dr["MonthTime"]))
            {
                model.WeekTime = float.Parse(dr["MonthTime"].ToString());
            }
            if (!DBNull.Value.Equals(dr["Remark"]))
            {
                model.Remark = dr["Remark"].ToString();
            }

            if (!DBNull.Value.Equals(dr["UpdateTime"]))
            {
                model.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]);
            }
            if (!DBNull.Value.Equals(dr["UpdateBy"]))
            {
                model.UpdateBy = dr["UpdateBy"].ToString();
            }
        }
          
    }
}
