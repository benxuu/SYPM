using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;

namespace DAL
{
      

    public partial class ProductionTask
    {
        public ProductionTask()
        { }

             /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataSet GetPTask(int count=10)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 10 a.FBillNo,a.FStatus,a.FQty,a.FCommitQty,a.FPlanCommitDate,a.FPlanFinishDate,a.FStartDate,a.FFinishDate,a.FType,a.FWorkShop,a.FItemID, ");
            strSql.Append("b.FModel,b.FName FROM ICMO as a left join t_icitemcore as b on a.FItemID = b.FItemID");
           SqlParameter[] parameters = {new SqlParameter("@top", SqlDbType.Int,4)};
            parameters[0].Value = count;

           // Model.ProductiveTask pt = new Model.ProductiveTask();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
         
                return ds;
            }
            
           
          
        }

       
 }