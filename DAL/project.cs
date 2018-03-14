using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using Model;
using System.Collections.Generic;
using System.Linq;
namespace DAL
{
   public class project
    {
        public project()
        { }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DataTable Getproject(int count = 10)
        {
            List<Model.project> projectlist = new List<Model.project>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top @top a.FBillNo,a.FStatus,a.FQty,a.FCommitQty,a.FPlanCommitDate,a.FPlanFinishDate,a.FStartDate,a.FFinishDate,a.FType,a.FWorkShop,a.FItemID, ");
            strSql.Append("b.FModel,b.FName FROM ICMO as a left join t_icitemcore as b on a.FItemID = b.FItemID");
            SqlParameter[] parameters = { new SqlParameter("@top", SqlDbType.Int, 6) };
            parameters[0].Value = count;

            // Model.ProductiveTask pt = new Model.ProductiveTask();
            //DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            DataTable dt = DbHelperSQL.ExcuteDataQuery(strSql.ToString());


            return dt;
        }

        /// <summary>  
        /// 列表-分页  
        /// </summary>  
        /// <param name="userId"></param>  
        /// <param name="pageIndex">当前页</param>  
        /// <param name="pageCount">总页数</param>  
        /// <returns></returns>  
        public static List<Model.project> GetProjectList(int pageIndex, out int pageCount)
        {
            var list = new List<Model.project>();
            pageCount = 0;
            try
            {
                //查询项目编号、项目名称、项目时间等信息  
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT [projectNb],[ProjectName],[approvalTime],[designTime],[presetTime],[completionTime] FROM AA_project");
                //                string sql = string.Format(@"select hotels.hid,hotels.hotelName,hotels.images,hotelorder.UserID,user_HotelComment.comment from hotels with(nolock) join hotelorder with(nolock) join user_HotelComment   
                //
                //telorder.UserID=user_HotelComment.userID on hotels.hid=hotelorder.HotelID where hotelorder.UserID={0}", userId);

                // DataTable dt = SQLHelper.Get_DataTable(sql, SQLHelper.GetCon(), null);
                DataTable dt = DbHelperSQL.ExcuteDataQuery(strSql.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    list = (from p in dt.AsEnumerable()  //这个list是查出全部的项目  
                            select new Model.project
                            {
                                ProjectNb = p.Field<string>("projectNb"),
                                // Id = p.Field<int>("hid"), //p.Filed<int>("Id") 其实就是获取DataRow中ID列。即：row["ID"]  
                                ProjectName = p.Field<string>("ProjectName"),
                                ApprovalTime = p.Field<DateTime>("approvalTime"),
                                PresetTime = p.Field<DateTime>("presetTime"),
                                DesignTime = p.Field<DateTime>("designTime"),
                                CompletionTime = p.Field<DateTime>("completionTime")

                            }).ToList(); //将这个集合转换成list  
                    int pageSize = 10; //每页显示十条数据  
                    //获取总页数  
                    pageCount = list.Count % pageSize == 0 ? ((list.Count - pageSize >= 0 ? (list.Count / pageSize) : (list.Count == 0 ? 0 : 1))) : list.Count / pageSize + 1;

                    //这个list 就是取到10条数据  
                    //Skip跳过序列中指定数量的元素，然后返回剩余的元素。
                    //Take序列的开头返回指定数量的连续元素。
                    list = list.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(); //假设当前页为第三页。这么这里就是跳过 10*(3-1) 即跳过20条数据，Take(pageSize)的意思是:取10条数据,既然前面已经跳过前20条数据了，那么这里就是从21条开始，取10条咯  

                }
            }
            catch (Exception ex)
            {
                // write log here  
            }
            return list;
        }



        //        /// <summary>  

        //        /// 将DataTable转换成一个list  

        //        /// </summary>  

        //        /// <returns>返回一个List<User>对象</returns>  

        //        public List<User> TableToList()  

        //        {  

        //            string sql = "select  * from T_User"; //T_User表里总共有 id,UserName,Age,Gender四列  

        //            DataTable dt= SqlHelper.ExecuteDataTable(sql,null);  

        //            var list = new List<User>(); //创建一个List<User>的实例  

        //            if (dt != null && dt.Rows.Count > 0)  

        //            {  

        //                //AsEnumerable()：返回一个IEnumerable<T> 对象，其泛型参数 T 为 System.Data.DataRow。  

        //                list = (from p in dt.AsEnumerable()  

        //                        select new User  //new一个User对象  

        //                        {  

        //                            Id = p.Field<int>("id"),//p.Filed<int>("id") 其实就是获取DataRow中ID列。即：row["ID"] 然后将它赋值给User类的Id字段。  

        //                            UserName = p.Field<string>("UserName"),  

        //                            Age = p.Field<int>("Age"),  

        //                            Gender = p.Field<int>("Gender")  

        //                        }).ToList(); //将这个User类对象转换成list  

        //            }  

        //            int dataCount = list.Count; // 总的数据条数。  

        //            int pageSize=10;//每页显示多少条数据。              

        //            int pageCount; //总页数。  

        //            int currentPage=3;//当前页。--这里假设当前页为第3页。  

        //            pageCount = dataCount % pageSize == 0 ? (dataCount < pageSize ? (dataCount==0?0:1): (dataCount / pageSize)) : (dataCount / pageSize + 1); 
        //     //这个list 就是取到10条数据    

        //            //Skip跳过序列中指定数量的元素，然后返回剩余的元素。    

        //            //Take序列的开头返回指定数量的连续元素。    

        //            list = list.Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList(); //假设当前页为第3页。这么这里就是跳过 10*(3-1) 即跳过20条数据，Take(pageSize)的意思是:取10条数据,既然前面已经跳过前20条数据了，那么这里就是从21条开始，取10条咯    

        //            return list;   

        //        }          

        //    }  

        //}
    }
}
