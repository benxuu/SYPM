using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    //项目对象，用于项目管理
    public class project
    {
        public project()
        { }
          //private int _id;
        private string projectName;//项目名称

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        private string projectNb;//项目编号

        public string ProjectNb
        {
            get { return projectNb; }
            set { projectNb = value; }
        }
        private DateTime approvalTime;//立项时间

        public DateTime ApprovalTime
        {
            get { return approvalTime; }
            set { approvalTime = value; }
        }
        private DateTime designTime;//设计时间

        public DateTime DesignTime
        {
            get { return designTime; }
            set { designTime = value; }
        }
        private DateTime presetTime;//预制时间

        public DateTime PresetTime
        {
            get { return presetTime; }
            set { presetTime = value; }
        }
        private DateTime completionTime;//完成时间

        public DateTime CompletionTime
        {
            get { return completionTime; }
            set { completionTime = value; }
        }
             
    }
}