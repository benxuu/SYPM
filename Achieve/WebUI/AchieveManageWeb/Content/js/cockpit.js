//列显示样式处理函数
function valuedisplay(value, row, index) {
    a = parseFloat(value).toFixed(1);
    p = value * 100 / (row.DayTime * 6) > 100 ? 100 : value * 100 / (row.DayTime * 6);
    if (value > row.AlertValue * row.DayTime * 6 / 100) {
        return '<div style="width:'+p+'%;height:20px; position:relative;background:red; "> <span style="text-align:right; width:80; position:absolute; ">'+a+'</span></div>';
    } else {
        return '<div style="width:' + p + '%;height:20px; position:relative;background:green; "> <span style="text-align:center; width:80; position:absolute; ">' + a + '</span></div>';
    }
}

//预定义列格式
var myColums = [
         { field: 'OperGroupID', title: 'Code', width: 80, hidden: true },
           { field: 'OperGroupName', title: '工艺', width: 60 },
            { field: 'AlertValue', title: '预警%', width: 50 },
             {
                 field: 'DayTime', title: '周能力', width: 50,
                 formatter: function (value, row, index) { return value * 6; }
             },
                 {
                     field: '1', title: '1', width: 80,
                     formatter: function (value, row, index) {
                         return valuedisplay(value, row, index);
                     }
                                  },


              {
                  field: '2', title: '2', width: 80,
                  formatter: function(value,row,index){
                     // return parseFloat(value).toFixed(1);
                      return valuedisplay(value, row, index);
                  }//,
               //   styler: function (value, row, index) {
               //       if (value > row.AlertValue * row.DayTime * 6 / 100) {
              //            return 'background-color:red;color:black;';
             //         } else {
             //             return 'background-color:green';
             //         }
              //    }
              },
              {
                  field: '3', title: '3', width: 80,
                  formatter: function (value, row, index) {
                      return valuedisplay(value, row, index);
                  } 
              },
            {
                field: '4', title: '4', width: 80, align: 'left',
                formatter: function (value, row, index) {
                    return valuedisplay(value, row, index);
                } 
            },
            {
                field: '5', title: '5', width: 80, align: 'left',
                formatter: function (value, row, index) {
                    return valuedisplay(value, row, index);
                } 
            }
];

var weekadjust = 0;//定义距离本周前后n周的值；

function lastweek() {
    weekadjust--;
    weekdatagrid(weekadjust);

}

function nextweek() {
    weekadjust++;
    weekdatagrid(weekadjust);

}

function weekdatagrid(weekadjust) {
    $.ajax({     //请求当前数据的列名
        url: "/Home/GetOperWeekAlert?r=" + Math.random(),
        type: "post",
        data: { "key": "columns", "weekadjust": weekadjust },
        dataType: "json",
        timeout: 5000,
        success: function (data) {
            //if (data.success) { 
            //动态更新myColums
            for (var i = 4; i < 9; i++) {
                myColums[i].title = data.columns[i - 1].title;
                myColums[i].field = data.columns[i - 1].field;
            };

            $("#weektime_dg").datagrid({
                url: "/Home/GetOperWeekAlert?key=datarows",
                queryParams: {
                    key: 'datarows',
                    weekadjust: weekadjust
                },
                striped: true, rownumbers: true, pagination: false, pageSize: 20, singleSelect: true,
                fitColumns: false,
                //idField: '',
                //sortName: '',
                //sortOrder: 'desc',
                pageList: [20, 40, 60, 80, 100],
                //frozenColumns: [],
                columns: [myColums],
                toolbar: [{
                    text: '<前一周',
                    
                    handler: function () { lastweek() }
                }, {
                    text: '>后一周',
                    
                    handler: function () { nextweek() }
                }]
            });

            //} else {
            //    $.show_alert("错误", data.result);
            //}
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            if (textStatus == "timeout") {
                $.show_alert("提示", "请求超时，请刷新当前页重试！");
            }
            else {
                $.show_alert("错误", textStatus + "：" + errorThrown);
            }
        }
    })
}

$(function () {

    weekdatagrid(weekadjust);

})


