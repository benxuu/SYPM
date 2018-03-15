using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;

namespace DBUtility
{
   public class JsonBuilder
    {
       /// <summary>
       /// 将project list数据转换为符合gantt图要求的json格式
       /// </summary>
       /// <returns></returns>
       public string ListToGantt(List<Model.project> projectlist)
       {
           StringBuilder jsonBuilder = new StringBuilder();
           jsonBuilder.Append("{\"tasks\":[{");

          // string tasks = string.Format("{\"id\": {0}, \"name\": \"{1}\", \"progress\": 0, \"progressByWorklog\": false, \"relevance\": 0, \"type\": \"\", \"typeId\": \"\", \"description\": \"\", \"code\": \"\", \"level\": 0, \"status\": \"STATUS_ACTIVE\", \"depends\": \"\", \"canWrite\": true, \"start\": {2}, \"duration\": 20, \"end\": {3}, \"startIsMilestone\": false, \"endIsMilestone\": false, \"collapsed\": false, \"assigs\": [], \"hasChild\": true}",);
           string tasks=" {\"id\": -1, \"name\": \"Gantt editor\", \"progress\": 0, \"progressByWorklog\": false, \"relevance\": 0, \"type\": \"\", \"typeId\": \"\", \"description\": \"\", \"code\": \"\", \"level\": 0, \"status\": \"STATUS_ACTIVE\", \"depends\": \"\", \"canWrite\": true, \"start\": 1396994400000, \"duration\": 20, \"end\": 1399586399999, \"startIsMilestone\": false, \"endIsMilestone\": false, \"collapsed\": false, \"assigs\": [], \"hasChild\": true},      {\"id\": -2, \"name\": \"coding\", \"progress\": 0, \"progressByWorklog\": false, \"relevance\": 0, \"type\": \"\", \"typeId\": \"\", \"description\": \"\", \"code\": \"\", \"level\": 1, \"status\": \"STATUS_ACTIVE\", \"depends\": \"\", \"canWrite\": true, \"start\": 1396994400000, \"duration\": 10, \"end\": 1398203999999, \"startIsMilestone\": false, \"endIsMilestone\": false, \"collapsed\": false, \"assigs\": [], \"hasChild\": true},      {\"id\": -3, \"name\": \"gantt part\", \"progress\": 0, \"progressByWorklog\": false, \"relevance\": 0, \"type\": \"\", \"typeId\": \"\", \"description\": \"\", \"code\": \"\", \"level\": 2, \"status\": \"STATUS_ACTIVE\", \"depends\": \"\", \"canWrite\": true, \"start\": 1396994400000, \"duration\": 2, \"end\": 1397167199999, \"startIsMilestone\": false, \"endIsMilestone\": false, \"collapsed\": false, \"assigs\": [], \"hasChild\": false},      {\"id\": -4, \"name\": \"editor part\", \"progress\": 0, \"progressByWorklog\": false, \"relevance\": 0, \"type\": \"\", \"typeId\": \"\", \"description\": \"\", \"code\": \"\", \"level\": 2, \"status\": \"STATUS_SUSPENDED\", \"depends\": \"3\", \"canWrite\": true, \"start\": 1397167200000, \"duration\": 4, \"end\": 1397685599999, \"startIsMilestone\": false, \"endIsMilestone\": false, \"collapsed\": false, \"assigs\": [], \"hasChild\": false} ";
           string resources="{\"id\": \"tmp_1\", \"name\": \"Resource 1\"}, {\"id\": \"tmp_2\", \"name\": \"Resource 2\"}, {\"id\": \"tmp_3\", \"name\": \"Resource 3\"}, {\"id\": \"tmp_4\", \"name\": \"Resource 4\"}";
           string roles="{\"id\": \"tmp_1\", \"name\": \"Project Manager\"}, {\"id\": \"tmp_2\", \"name\": \"Worker\"}, {\"id\": \"tmp_3\", \"name\": \"Stakeholder\"}, { \"id\": \"tmp_4\", \"name\": \"Customer\" }";
           string jsonString = string.Format("{\"tasks\":[{0}], \"selectedRow\": 2, \"deletedTaskIds\": [], \"resources\": [{1} ], \"roles\": [{2}],",tasks,resources,roles);
           
         //  {"id": -1, "name": "Gantt editor", "progress": 0, "progressByWorklog": false, "relevance": 0, "type": "", "typeId": "", "description": "", "code": "", "level": 0, "status": "STATUS_ACTIVE", "depends": "", "canWrite": true, "start": 1396994400000, "duration": 20, "end": 1399586399999, "startIsMilestone": false, "endIsMilestone": false, "collapsed": false, "assigs": [], "hasChild": true},
           jsonBuilder.Append(jsonString);
           jsonBuilder.Append(" \"canWrite\": false, \"canDelete\": false, \"canWriteOnParent\": false, canAdd: false }");
           return jsonBuilder.ToString();
       }
        /// <summary>
        /// 把DataTable数据转换为Json格式
        /// </summary>
        /// <param name="dt">传入DataTable数据</param>
        /// <returns></returns>
        public string DataTableToJson(DataTable dt, int pageTotal)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"total\"");
            jsonBuilder.Append(":");
            jsonBuilder.Append(pageTotal);
            jsonBuilder.Append(",\"rows");
            jsonBuilder.Append("\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("],");
            jsonBuilder.Append("\"title");
            jsonBuilder.Append(dt.TableName);
            jsonBuilder.Append("\":[");
            //这是循环获取列名称
            for (int n = 0; n < dt.Columns.Count; n++)
            {
                jsonBuilder.Append("{");
                jsonBuilder.Append("\"field");
                jsonBuilder.Append("\":\"");
                jsonBuilder.Append(dt.Columns[n].ColumnName);
                jsonBuilder.Append("\",");
                jsonBuilder.Append("\"title");
                jsonBuilder.Append("\":\"");
                jsonBuilder.Append(dt.Columns[n].ColumnName);
                jsonBuilder.Append("\"");
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("},");

            jsonBuilder.Remove(jsonBuilder.Length - 2, 2);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

 
    }
}
