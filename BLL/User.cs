using System;
using System.Data;
using System.Collections.Generic;
using ims.Model;
namespace ims.BLL
{
    /// <summary>
    /// User
    /// </summary>
    public partial class User
    {
        private readonly ims.DAL.User dal = new ims.DAL.User();
        public User()
        { }
        /// <summary>
        /// 检查登陆用户名密码
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="upwd"></param>
        /// <returns></returns>
        public string CheckLogin(string uname, string upwd)
        {
           
            DataTable dt = GetList("UserName='" + uname + "' and UserPwd='" + upwd + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {

                return "0";//登录成功
            }
            else
                return "1";
        }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        //public int Add(ims.Model.User model)
        //{
        //    return ims.DAL
        //        ims.dal.Add(model);
        //}

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ims.Model.User model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ims.Model.User GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ims.Model.User> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ims.Model.User> DataTableToList(DataTable dt)
        {
            List<ims.Model.User> modelList = new List<ims.Model.User>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ims.Model.User model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ims.Model.User();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.RealName = dt.Rows[n]["RealName"].ToString();
                    model.UserPwd = dt.Rows[n]["UserPwd"].ToString();
                    if (dt.Rows[n]["Role"].ToString() != "")
                    {
                        model.Role = int.Parse(dt.Rows[n]["Role"].ToString());
                    }
                    model.IsAdmin = dt.Rows[n]["IsAdmin"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}

