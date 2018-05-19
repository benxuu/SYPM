using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace AchieveCommon
{
    /// <summary>
    /// SQL Server数据库访问类
    /// </summary>
    public abstract class SqlHelper
    {
        //读取配置文件里的数据库连接字符串
        public static readonly string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public static readonly string connStrK3 = ConfigurationManager.ConnectionStrings["K3ConnectionString"].ConnectionString;

        //空构造
        public SqlHelper() { }

        //Hashtable to store cached parameters
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 自动生成数据表的序列号,string类型，8位日期码+4位流水码，
        /// </summary>
        /// <param name="tableName">目标数据表名</param>
        ///  <param name="serialColumn">目标数据表列名，默认为id</param>
        /// <returns></returns>
        public static string GetSerialNumber(string tableName, string serialColumn="id")
        {           
            string sql="select max("+serialColumn+") as maxSerialNumber from "+tableName ;
            string serialNumber = Convert.ToString( ExecuteScalar(connStr, CommandType.Text, sql, null));
            if (serialNumber.Length==12)
            {
                string headDate = serialNumber.Substring(0, 8);
                int lastNumber = int.Parse(serialNumber.Substring(8));
                //如果数据库最大值流水号中日期和生成日期在同一天，则顺序号加1
                if (headDate == DateTime.Now.ToString("yyyyMMdd"))
                {
                    lastNumber++;
                    return headDate + lastNumber.ToString("0000");
                }
            }
            return DateTime.Now.ToString("yyyyMMdd") + "0001";
        }

    

   /// <summary>
        /// 生成消费单号，按日期生成单号，默认是年月日+四位数字，如：200906010001；后四位数字可以自动增长位数。
   /// </summary>
        /// <param name="LastNumStr">目前数据库中最后的单号</param>
   /// <returns></returns>     
   public static String Assignment(String LastNumStr)
       {
           string number0 = "";
           DateTime date = System.DateTime.Now;
           string year = date.Year.ToString();
           string month = date.Month.ToString();
           string day = date.Day.ToString();
           if (month.Length < 2)
               month = '0' + month;
           if (day.Length < 2)
               day = '0' + day;
           string ymd = year + month + day;
if (LastNumStr.Length < 8 || LastNumStr.Substring(0, 8) != ymd)
           {
               return ymd + "0001";
           }
           else
           {
               Int32 clientnumber = Convert.ToInt32(LastNumStr.Substring(8, LastNumStr.Length - 8)) + 1;
               if (clientnumber.ToString().Length > LastNumStr.Length - 8)
               {
                   return ymd + clientnumber.ToString();
               }
               else
               {
                   for (int i = 0; i < LastNumStr.Length - 8 - clientnumber.ToString().Length; i++)
                   {
                       number0 += "0";
                   }
                   return ymd + number0 + clientnumber.ToString();
               }
           }
       }

        /// <summary>
        /// 执行增删改【常用】
        /// </summary>
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, commandType, commandText, paras);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();          //清空参数
                return val;
            }
        }
        /// <summary>
        /// 执行增删改【常用】
        /// </summary>
        public static int ExecuteNonQuerySql(string connectionString, string commandText)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, commandText);
                int val = cmd.ExecuteNonQuery();
                //cmd.Parameters.Clear();          //清空参数
                return val;
            }
        }

        /// <summary>
        /// 执行增删改（对现有的数据库连接）【不常用】
        /// </summary>
        public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, commandType, commandText, paras);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 执行多条sql语句（List泛型集合）【事务】（无参数）
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="listSql">包含多条sql语句的泛型集合</param>
        /// <returns>受影响行数</returns>
        public static int ExecuteNonQuery(string connectionString, List<string> listSql)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            PrepareCommand(cmd, conn, trans, CommandType.Text, null, null);
            try
            {
                int count = 0;
                for (int n = 0; n < listSql.Count; n++)
                {
                    string strSql = listSql[n];
                    if (strSql.Trim().Length > 1)
                    {
                        cmd.CommandText = strSql;
                        count += cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
                cmd.Parameters.Clear();
                return count;
            }
            catch
            {
                trans.Rollback();
                cmd.Parameters.Clear();
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行多条sql语句（Hashtable）【事务】（带一组参数，一个参数也得封装成组)
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="sqlStringList">Hashtable表，键值对形式</param>
        public static void ExecuteNonQuery(string connectionString, Hashtable sqlStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        foreach (DictionaryEntry item in sqlStringList)
                        {
                            string cmdText = item.Key.ToString();   //要执行的sql语句
                            SqlParameter[] cmdParas = (SqlParameter[])item.Value;  //sql语句对应的参数
                            PrepareCommand(cmd, conn, trans, CommandType.Text, cmdText, cmdParas);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        if (sqlStringList.Count > 0)
                            trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// 返回DataReader对象
        /// </summary>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string cmdText, params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                PrepareCommand(cmd, conn, null, commandType, cmdText, paras);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return reader;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// 返回第一行第一列信息（可能是字符串 所以返回类型是object）【常用】
        /// </summary>
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, commandType, commandText, paras);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// 返回第一行第一列信息（可能是字符串 所以返回类型是object）【常用简洁】
        /// </summary>
        public static object ExecuteScalar(string connectionString,  string commandText )
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, CommandType.Text, commandText, null);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// 返回第一行第一列信息（针对现有的数据库连接）【不常用】
        /// </summary>
        public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, commandType, commandText, paras);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        public static DataTable GetDataTable(string connectionString, CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, commandType, commandText, paras);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /// <summary>
        /// 返回DataTable
        /// </summary>
        public static DataTable GetDataTable(string connectionString,   string commandText )
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, commandText);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// 返回DataSet
        /// </summary>
        public static DataSet GetDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, commandType, commandText, paras);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="cmdParms">an array of SqlParamters to be cached</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached SqlParamters array</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        /// <summary>
        /// 准备一个待执行的SqlCommand
        /// </summary>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }
                cmd.Connection = conn;
                if (commandText != null)
                    cmd.CommandText = commandText;
                cmd.CommandType = commandType;     //这里设置执行的是T-Sql语句还是存储过程

                if (trans != null)
                    cmd.Transaction = trans;

                if (paras != null && paras.Length > 0)
                {
                    //cmd.Parameters.AddRange(paras);
                    for (int i = 0; i < paras.Length; i++)
                    {
                        if (paras[i].Value == null || paras[i].Value.ToString() == "")
                            paras[i].Value = DBNull.Value;   //插入或修改时，如果有参数是空字符串，那么以NULL的形式插入数据库
                        cmd.Parameters.Add(paras[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 通用分页存储过程，有条件查询，有排序字段，按照排序字段的降序排列
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="CurrentCount">当前记录数量（页码*每页记录数）</param>
        /// <param name="TableName">表名称</param>
        /// <param name="Where">查询条件，例："ID>1000 AND Name like '%LiLinFeng%'" 排序条件，直接在后面加，例：" ORDER BY ID DESC,NAME ASC"</param>
        /// <param name="TotalCount">记录总数</param>
        /// <returns></returns>
        public static DataSet GetList(string connectionString, string Order, int PageSize, int CurrentCount, string TableName, string Where, out int TotalCount)
        {
            SqlParameter[] parmList =
                {
                    new SqlParameter("@PageSize",PageSize),
                    new SqlParameter("@CurrentCount",CurrentCount),
                    new SqlParameter("@TableName",TableName),
                    new SqlParameter("@Where",Where),
                    new SqlParameter("@Order",Order),
                    new SqlParameter("@TotalCount",SqlDbType.Int,4)
                };
            parmList[5].Direction = ParameterDirection.Output;
            DataSet ds = GetDataset(connectionString, CommandType.StoredProcedure, "sp_MvcPager", parmList);
            TotalCount = Convert.ToInt32(parmList[5].Value);
            return ds;
        }
    }
}
