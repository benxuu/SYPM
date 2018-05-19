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

        /// <summary>
        /// ProjectID
        /// </summary>		
        private string _projectid;
        public string ProjectID
        {
            get { return _projectid; }
            set { _projectid = value; }
        }
        /// <summary>
        /// ProjectNo
        /// </summary>		
        private string _projectno;
        public string ProjectNo
        {
            get { return _projectno; }
            set { _projectno = value; }
        }
        /// <summary>
        /// ProjectName
        /// </summary>		
        private string _projectname;
        public string ProjectName
        {
            get { return _projectname; }
            set { _projectname = value; }
        }
        /// <summary>
        /// ProjectManager
        /// </summary>		
        private string _projectmanager;
        public string ProjectManager
        {
            get { return _projectmanager; }
            set { _projectmanager = value; }
        }
        /// <summary>
        /// ProjectClerk
        /// </summary>		
        private string _projectclerk;
        public string ProjectClerk
        {
            get { return _projectclerk; }
            set { _projectclerk = value; }
        }
        /// <summary>
        /// Remark
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime _updatetime;
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// UpdateBy
        /// </summary>		
        private string _updateby;
        public string UpdateBy
        {
            get { return _updateby; }
            set { _updateby = value; }
        }
        /// <summary>
        /// AppendID
        /// </summary>		
        private string _appendid;
        public string AppendID
        {
            get { return _appendid; }
            set { _appendid = value; }
        }
        /// <summary>
        /// AppendListID
        /// </summary>		
        private string _appendlistid;
        public string AppendListID
        {
            get { return _appendlistid; }
            set { _appendlistid = value; }
        }
        /// <summary>
        /// CreateBy
        /// </summary>		
        private string _createby;
        public string CreateBy
        {
            get { return _createby; }
            set { _createby = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }

    }
}