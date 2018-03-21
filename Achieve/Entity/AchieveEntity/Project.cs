using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AchieveEntity;
using System.ComponentModel.DataAnnotations;


namespace AchieveEntity
{
    public class Project
    {
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime ApprovalTime { get; set; }
        public DateTime DesignTime { get; set; }
        public DateTime PresetTime { get; set; }
        public DateTime CompletionTime { get; set; }

    }
    public class ProjectDetail
    { 
        //项目的其他信息
    }
}