var myColums = [
         { field: 'OperGroupID', title: 'Code', width: 80, hidden: true },
           { field: 'OperGroupName', title: '工艺', width: 60 },
            { field: 'AlertValue', title: '预警%', width: 50 },
             {
                 field: 'DayTime', title: '周能力', width: 50,
                 formatter: function (value, row, index) { return value * 6; }
             },
                 {
                     field: '1', title: '1', width: 60,
                     formatter: function (value, row, index) {
                         return parseFloat(value).toFixed(1);
                     },
                     styler: function (value, row, index) {
                         if (value > row.AlertValue * row.DayTime * 6 / 100) {
                             return 'background-color:red;color:black;';
                         } else {
                             return 'background-color:green';
                         }
                     }
                 },


              {
                  field: '2', title: '2', width: 60,
                  formatter: function(value,row,index){
                      return parseFloat(value).toFixed(1);
                  },
                  styler: function (value, row, index) {
                      if (value > row.AlertValue * row.DayTime * 6 / 100) {
                          return 'background-color:red;color:black;';
                      } else {
                          return 'background-color:green';
                      }
                  }
              }, {
                  field: '3', title: '3', width: 60,
                  formatter: function (value, row, index) {
                      return parseFloat(value).toFixed(1);
                  },
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
                field: '4', title: '4', width: 60, align: 'left',
                formatter: function (value, row, index) {
                    return parseFloat(value).toFixed(1);
                },
                styler: function (value, row, index) {
                    if (value > row.AlertValue * row.DayTime * 6 / 100) {
                        return 'background-color:red;color:black;';
                    } else {
                        return 'background-color:green';
                    }
                }
            },
            {
                field: '5', title: '5', width: 60, align: 'left',
                formatter: function (value, row, index) {
                    return parseFloat(value).toFixed(1);
                },
                styler: function (value, row, index) {
                    if (value > row.AlertValue * row.DayTime * 6 / 100) {
                        return 'background-color:red;color:black;';
                    } else {
                        return 'background-color:green';
                    }
                }
            }
];

var weekadjust = 0;

function lastweek() {
    weekadjust--;
    weekdatagrid(weekadjust);
    //$('#weektime_dg').datagrid(
    //    'load', {
    //        weekadjust: weekadjust
    //    });
}

function nextweek() {
    weekadjust++;
    weekdatagrid(weekadjust);
    //$('#weektime_dg').datagrid(
    //    'load', {
    //        weekadjust: weekadjust
    //    });
}

function weekdatagrid(weekadjust) {
    $.ajax({     //请求当前用户可以操作的按钮
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
                    iconCls: 'icon-undo',
                    handler: function () { lastweek() }
                }, '-', {
                    iconCls: 'icon-redo',
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
    //$('#weektime_dg').datagrid({
    //    url: "/Home/GetOperWeekAlert",
    //    singleSelect: true,
    //    columns: [[
    //       { field: 'OperGroupID', title: 'Code', width: 100, hidden: true },
    //       { field: 'OperGroupName', title: '工艺', width: 100 },
    //        { field: 'AlertValue', title: '预警%', width: 60 },
    //         {
    //             field: 'DayTime', title: '周能力', width: 60,
    //             formatter: function (value, row, index) { return value * 6; }
    //         },
    //             {
    //                 field: '1', title: '1', width: 60,
    //                 styler: function (value, row, index) {
    //                     if (value > row.AlertValue * row.DayTime * 6 / 100) {
    //                         return 'background-color:red;color:black;';
    //                     } else {
    //                         return 'background-color:green';
    //                     }
    //                 }
    //             },


    //          {
    //              field: '2', title: '2', width: 60,
    //              styler: function (value, row, index) {
    //                  if (value > row.AlertValue * row.DayTime * 6 / 100) {
    //                      return 'background-color:red;color:black;';
    //                  } else {
    //                      return 'background-color:green';
    //                  }
    //              }
    //          }, {
    //              field: '3', title: '3', width: 60,
    //              styler: function (value, row, index) {
    //                  if (value > row.AlertValue * row.DayTime * 6 / 100) {
    //                      return 'background-color:red;color:black;';
    //                      // the function can return predefined css class and inline style
    //                      // return {class:'c1',style:'color:red'}
    //                  } else {
    //                      return 'background-color:green';
    //                  }
    //              }
    //          },
    //        {
    //            field: '4', title: '4', width: 60, align: 'left',
    //            styler: function (value, row, index) {
    //                if (value > row.AlertValue * row.DayTime * 6 / 100) {
    //                    return 'background-color:red;color:black;';
    //                } else {
    //                    return 'background-color:green';
    //                }
    //            }
    //        },
    //        {
    //            field: '5', title: '5', width: 60, align: 'left',
    //            styler: function (value, row, index) {
    //                if (value > row.AlertValue * row.DayTime * 6 / 100) {
    //                    return 'background-color:red;color:black;';
    //                } else {
    //                    return 'background-color:green';
    //                }
    //            }
    //        }
    //    ]],
    //    onLoadSuccess: function (data) {
    //        //alert($('#weektime_dg').datagrid('getData').columns[8].title);
    //        //alert(data.columns[8].title);
    //      //  $('#weektime_dg').datagrid.columns = data.columns;
    //       // $('#weektime_dg').datagrid({ columns: [data.columns] });
    //        for (var i = 1; i < 6; i++) {
    //            var opt = $('#weektime_dg').datagrid("getColumnOption", i)//'"'+i+'"')
    //            opt.title = data.columns[i + 3].title;
    //            opt.field = data.columns[i + 3].field;
    //        }
    //        $.parser.parse($('#weektime_dg').datagrid());//重新渲染
    //    }//this.columns =data.columns}
    //});

})


//$(function () {
//    $.ajax({     //请求当前用户可以操作的按钮
//        url: "/Button/GetUserAuthorizeButton?r=" + Math.random(),
//        type: "post",
//        data: { "KeyCode": "produceOrder", "KeyName": "Produce" },
//        dataType: "json",
//        timeout: 5000,
//        success: function (data) {
//            if (data.success) {
//                var toolbar = getToolBar(data);      //common.js
//                if (data.search) {     //判断是否有浏览权限
//                    $("#ui_produce_dg").datagrid({
//                        url: "/Project/GetPageProjectInfo?view=ProjectGrid",
//                        queryParams: {
//                            //view: 'ProjectGrid',
//                            subject: 'datagrid'
//                        },
//                        striped: true, rownumbers: true, pagination: true, pageSize: 20, singleSelect: true,
//                        fitColumns: false,
//                        idField: 'FBillNo',
//                        sortName: 'FPlanCommitDate',
//                        sortOrder: 'desc',
//                        pageList: [20, 40, 60, 80, 100],
//                        frozenColumns: [],
//                        columns: myColums,
//                        toolbar: toolbar.length == 0 ? null : toolbar
//                    }).datagrid('subgrid', conf);
//                }
//                else {
//                    $.show_alert("提示", "无权限，请联系管理员！");
//                }
//            } else {
//                $.show_alert("错误", data.result);
//            }
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            if (textStatus == "timeout") {
//                $.show_alert("提示", "请求超时，请刷新当前页重试！");
//            }
//            else {
//                $.show_alert("错误", textStatus + "：" + errorThrown);
//            }
//        }
//    })
//});
