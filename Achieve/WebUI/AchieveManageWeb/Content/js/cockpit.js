var myColums = [[
       { width: 100, title: '工艺组编号', field: 'OperGroupID', sortable: true },
       { width: 100, title: '工艺组', field: 'OperGroupName', sortable: false },
        { width: 60, title: '标准周能力', field: 'DayTime',
                            formatter: function (value, row, index) {
                                return value * 6;
                            }
                        },
                        { width: 100, title: '第18周', field: '1' },
                         { width: 100, title: '第17周', field: '2' },
                          { width: 100, title: '第16周', field: '3' },
                           { width: 100, title: '第15周', field: '4',
                               formatter: function (value, row, index)
                               { return value > row.AlertValue * row.DayTime * 6 / 100 ? '<span style="border:1px; background:#FFF">' + value + '</span>' : value; }
                           },
                    { width: 120, title: '预警%', field: 'AlertValue' }
]]

$(function () {
    $('#weektime_dg').datagrid({
        url: "/Home/GetOperWeekAlert",
        singleSelect: true,
        columns: [[
            { field: 'OperGroupID', title: 'Code', width: 100, hidden: true },
            { field: 'OperGroupName', title: '工艺', width: 100 },
             { field: 'AlertValue', title: '预警%', width: 60 },
              {
                  field: 'DayTime', title: '周能力', width: 60,
                  formatter: function (value, row, index) { return value * 6; }
              },
                  {
                      field: '4', title: '上3周', width: 60,
                      styler: function (value, row, index) {
                          if (value > row.AlertValue * row.DayTime * 6 / 100) {
                              return 'background-color:red;color:black;';
                          } else {
                              return 'background-color:green';
                          }
                      }
                  },


               {
                   field: '3', title: '上上周', width: 60,
                   styler: function (value, row, index) {
                       if (value > row.AlertValue * row.DayTime * 6 / 100) {
                           return 'background-color:red;color:black;';
                       } else {
                           return 'background-color:green';
                       }
                   }
               }, {
                   field: '2', title: '上周', width: 60,
                   styler: function (value, row, index) {
                       if (value > row.AlertValue * row.DayTime * 6 / 100) {
                           return 'background-color:red;color:black;';
                           // the function can return predefined css class and inline style
                           // return {class:'c1',style:'color:red'}
                       } else {
                           return 'background-color:green';
                       }
                   }
               },
             {
                 field: '1', title: '本周', width: 60, align: 'left',
                 styler: function (value, row, index) {
                     if (value > row.AlertValue * row.DayTime * 6 / 100) {
                         return 'background-color:red;color:black;';
                     } else {
                         return 'background-color:green';
                     }
                 }
             }
        ]]
    });

})
