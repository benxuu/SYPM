using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AchieveEntity;
using System.Data;



namespace AchieveInterfaceDAL
{
     public interface  IProduceDAL
    {
         DataTable GetAllProduceData(string strwhere);
    }
}
