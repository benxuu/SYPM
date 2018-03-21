using AchieveCommon;
using AchieveDALFactory;
using AchieveEntity;
using AchieveInterfaceDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AchieveBLL
{
    public class ProjectBLL
    {
        IProduceDAL dal = DALFactory.GetProduceDAL();
        public DataTable GetAllProduceData(string strwhere)
        {
            return dal.GetAllProduceData(strwhere);
        }
    }
}
