var _menus = { "menus": [
{ "menuid": "100", "icon": "icon-sys", "menuname": "开发测试",
    "menus": [{ "menuid": "21", "menuname": "甘特图设计器", "icon": "icon-nav", "url": "ganttedit/ganttview.html" + '?t=' + Math.random() },
									{ "menuid": "22", "menuname": "甘特图1", "icon": "icon-nav", "url": "gantt1/projectgantt.html" + '?t=' + Math.random() },
                                    { "menuid": "23", "menuname": "甘特图2", "icon": "icon-nav", "url": "gantt2/projectgantt.html" + '?t=' + Math.random() },
                                    { "menuid": "24", "menuname": "项目进度报表", "icon": "icon-nav", "url": "plans.html" + '?t=' + Math.random() },
                                    { "menuid": "25", "menuname": "gantt Json", "icon": "icon-nav", "url": "Ajax/projectHandler.ashx?o=getproject" + '&t=' + Math.random() }
								]
},
						 { "menuid": "8", "icon": "icon-sys", "menuname": "项目管理",
						     "menus": [{ "menuid": "21", "menuname": "项目查看", "icon": "icon-nav", "url": "ptask.html" + '?t=' + Math.random() },
									{ "menuid": "22", "menuname": "项目维护", "icon": "icon-nav", "url": "Ajax/HandlerICMO.ashx?o=ptask" + '&t=' + Math.random() },
                                    { "menuid": "23", "menuname": "项目查询", "icon": "icon-nav", "url": "plans.html" + '?t=' + Math.random() },
                                    { "menuid": "24", "menuname": "项目进度报表", "icon": "icon-nav", "url": "plans.html" + '?t=' + Math.random() },
                                    { "menuid": "25", "menuname": "项目成本报表", "icon": "icon-nav", "url": "plans.html" + '?t=' + Math.random() }
								]
						}, { "menuid": "56", "icon": "icon-sys", "menuname": "生产管理",
						    "menus": [{ "menuid": "31", "menuname": "车间信息", "icon": "icon-nav", "url": "plans2.html" + '?t=' + Math.random() },
									{ "menuid": "32", "menuname": "排产管理", "icon": "icon-nav", "url": "Ajax/work.ashx" + '?t=' + Math.random() },
                                    { "menuid": "33", "menuname": "委外管理", "icon": "icon-nav", "url": "Ajax/work.ashx" + '?t=' + Math.random() }
								]
						}, { "menuid": "28", "icon": "icon-sys", "menuname": "绩效管理",
						    "menus": [{ "menuid": "41", "menuname": "考评标准", "icon": "icon-nav", "url": "js/jquery-easyui/demo/datagrid/cacheeditor.html" },
									{ "menuid": "42", "menuname": "任务进度", "icon": "icon-nav", "url": "demo1.html" },
									{ "menuid": "43","hide":"true", "menuname": "**", "icon": "icon-nav", "url": "demo2.html" }
								]
						}, { "menuid": "39", "icon": "icon-sys", "menuname": "系统设置",
						    "menus": [{ "menuid": "51", "menuname": "用户管理", "icon": "icon-nav", "url": "demo.html" },
									{ "menuid": "52", "menuname": "部门管理", "icon": "icon-nav", "url": "demo1.html" },
									{ "menuid": "53", "menuname": "客户管理", "icon": "icon-nav", "url": "demo2.html" },
                                    { "menuid": "54", "menuname": "供应商管理", "icon": "icon-nav", "url": "demo2.html" },
                                    { "menuid": "55", "menuname": "设备管理", "icon": "icon-nav", "url": "demo2.html" }
								]
						},{ "menuid": "1", "icon": "icon-sys", "menuname": "控制面板",
						    "menus": [{ "menuid": "11", "menuname": "百度搜索", "icon": "icon-nav", "url": "http://www.baidu.com/" },
									{ "menuid": "12", "menuname": "添加用户", "icon": "icon-add", "url": "demo.html" },
									{ "menuid": "13", "menuname": "用户管理", "icon": "icon-users", "url": "/Sys/User/List.aspx" },
									{ "menuid": "14", "menuname": "角色管理", "icon": "icon-role", "url": "demo2.html" },
									{ "menuid": "15", "menuname": "权限设置", "icon": "icon-set", "url": "demo.html" },
									{ "menuid": "16", "menuname": "系统日志", "icon": "icon-log", "url": "demo1.html" }
								]
						}
				]
		};

		
         //设置登录窗口
         function openPwd() {
             $('#w').window({
                 title: '修改密码',
                 width: 300,
                 modal: true,
                 shadow: true,
                 closed: true,
                 height: 160,
                 resizable: false
             });
         }
         //关闭登录窗口
         function closePwd() {
             $('#w').window('close');
         }


         //修改密码
         function serverLogin() {
             var $newpass = $('#txtNewPass');
             var $rePass = $('#txtRePass');

             if ($newpass.val() == '') {
                 msgShow('系统提示', '请输入密码！', 'warning');
                 return false;
             }
             if ($rePass.val() == '') {
                 msgShow('系统提示', '请在一次输入密码！', 'warning');
                 return false;
             }

             if ($newpass.val() != $rePass.val()) {
                 msgShow('系统提示', '两次密码不一至！请重新输入', 'warning');
                 return false;
             }

             $.post('/ajax/editpassword.ashx?newpass=' + $newpass.val(), function (msg) {
                 msgShow('系统提示', '恭喜，密码修改成功！<br>您的新密码为：' + msg, 'info');
                 $newpass.val('');
                 $rePass.val('');
                 close();
             })

         }

         $(
		 function () {
		     var formLogin = $('#formLogin');
		     //SetCookie('username', 'wikstone');// set login for test;
		    // if (getCookie('username') == null || true)//未登录显示登录Dialog否则不渲染
		    if (getCookie('username') == null && false)//未登录显示登录Dialog否则不渲染
		     {
		         formLogin.dialog({ modal: true,
		             closable: false,

		             buttons: [{
		                 text: '登录', handler: function () {
		                     if (!formLogin.form("validate")) {
		                         return;
		                     }
		                     $.post(
                                          '/Ajax/HandlerLogin.ashx',
                                         { "username": $("#ipt_username").val(), "userpwd": $("#ipt_userpwd").val() },

                         function (a) {
                             if (a == '0') {//登录成功

                                 // $.messager.alert('提示', '登录成功', 'info')
                                 SetCookie('username', 'wikstone');
                                 formLogin.dialog('close');
                                 removecover();
                             }
                             else {//登录失败
                                 $.messager.alert('提示', '登录失败', 'info')
                             }

                         }
                         );

		                 }
		             }]

		         }
            );
         } else {
            removecover();
         }
		    
		     openPwd();
		     InitLeftMenu();
		     clockon();

		     $('#editpass').click(function () {
		         $('#w').window('open');
		     });

		     $('#btnEp').click(function () {
		         serverLogin();
		     })

		     $('#btnCancel').click(function () { closePwd(); })

		     $('#loginOut').click(function () {
		         $.messager.confirm('系统提示', '您确定要退出本次登录吗?', function (r) {

		             if (r) {
		                 location.href = '/ajax/loginout.ashx';
		             }
		         });
		     })
		 });

//设置登录遮盖		
function removecover(){
	var _mask = document.getElementById('cover');
  _mask.parentNode.removeChild(_mask);
 }
