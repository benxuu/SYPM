<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexdemo.aspx.cs" Inherits="MesserRDLC.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <title>
        <asp:Literal ID="Literal1" runat="server" Text="<%$Resources:lang,index_title%>" />
    </title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            width: 100px;
            text-align: right;
        }
        .style3
        {
            width: 2px;
        }
        .style4
        {
            width: 155px;
        }
        .style5
        {
            width: 190px;
            font-size: small;
            text-align: left;
        }
        #college
        {
            width: 141px;
        }
    </style>
    <link href="Css/default.css" rel="stylesheet" type="text/css" />
    <link href="js/jquery-easyui-1.2.5/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="js/jquery-easyui-1.2.5/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-easyui-1.2.5/jquery-1.7.1.min.js" type="text/javascript"></script>
    <%--<script type="text/javascript" src="js/jquery-1.4.4.min.js"></script>--%>
    <%-- <script type="text/javascript" src="js/jquery.easyui.min.1.2.2.js"></script>--%>
    <script src="js/jquery-easyui-1.2.5/jquery.easyui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src='js/common.js'> </script>
    <script src="js/index.js" type="text/javascript"></script>
    <script type="text/javascript">
        var zh_cn_menus = {
            "menus": [
            //各种报表
    {
    "menuid": "2",
    "icon": "icon-sys",
    "menuname": "切割报表",
    "menus": [{
        "menuid": "21",
        "menuname": "选择日报表",
        "icon": "icon-nav",
        "url": "../dayrpt.aspx"
    },
        {
            "menuid": "22",
            "menuname": "选择周报表",
            "icon": "icon-nav",
            "url": "../weekrpt.aspx"
        },
        {
            "menuid": "23",
            "menuname": "选择月报表",
            "icon": "icon-nav",
            "url": "../monthrpt.aspx"
        },
        {
            "menuid": "24",
            "menuname": "选择年报表",
            "icon": "icon-nav",
            "url": "../yearrpt.aspx"
        }]
},


            //网站链接
    {
    "menuid": "8",
    "icon": "icon-sys",
    "menuname": "常用链接",
    "menus": [

        {
            "menuid": "80",
            "menuname": "梅塞尔",
            "icon": "icon-nav",
            "url": "http://www.messer-kunshan.com.cn/"
        },
        {
            "menuid": "81",
            "menuname": "百度搜索",
            "icon": "icon-nav",
            "url": "http://www.baidu.com/"
        },
        {
            "menuid": "82",
            "menuname": "163邮箱",
            "icon": "icon-nav",
            "url": "http://mail.163.com"
        },
        {
            "menuid": "83",
            "menuname": "新浪新闻",
            "icon": "icon-nav",
            "url": "http://news.sina.com.cn/"
        }

        ]
},

            //控制面板
    {
    "menuid": "00",
    "icon": "icon-sys",
    "menuname": "控制面板",
    "menus": [{
        "menuid": "001",
        "menuname": "分班管理",
        "icon": "icon-add",
        "url": "../shiftedit.aspx"
    },
        {
            "menuid": "002",
            "menuname": "开发测试",
            "icon": "icon-log",
            "url": "../test.aspx"
        },

        {
            "menuid": "005",
            "menuname": "帮助说明",
            "icon": "icon-log",
            "url": "../help.html"
        }
        ]
}
    ]
        };
        var en_us_menus = {
            "menus": [
            //各种报表
    {
    "menuid": "2",
    "icon": "icon-sys",
    "menuname": "Cutting Report",
    "menus": [{
        "menuid": "21",
        "menuname": "Daily Report",
        "icon": "icon-nav",
        "url": "../dayrpt.aspx"
    },
        {
            "menuid": "22",
            "menuname": "Weekly Report",
            "icon": "icon-nav",
            "url": "../weekrpt.aspx"
        },
        {
            "menuid": "23",
            "menuname": "Monthly Report",
            "icon": "icon-nav",
            "url": "../monthrpt.aspx"
        },
        {
            "menuid": "24",
            "menuname": "Yearly Report",
            "icon": "icon-nav",
            "url": "../yearrpt.aspx"
        }]
},


            //网站链接
    {
    "menuid": "8",
    "icon": "icon-sys",
    "menuname": "常用链接",
    "menus": [

        {
            "menuid": "80",
            "menuname": "梅塞尔",
            "icon": "icon-nav",
            "url": "http://www.messer-kunshan.com.cn/"
        },
        {
            "menuid": "81",
            "menuname": "百度搜索",
            "icon": "icon-nav",
            "url": "http://www.baidu.com/"
        },
        {
            "menuid": "82",
            "menuname": "163邮箱",
            "icon": "icon-nav",
            "url": "http://mail.163.com"
        },
        {
            "menuid": "83",
            "menuname": "新浪新闻",
            "icon": "icon-nav",
            "url": "http://news.sina.com.cn/"
        }

        ]
},

            //控制面板
    {
    "menuid": "00",
    "icon": "icon-sys",
    "menuname": "控制面板",
    "menus": [{
        "menuid": "001",
        "menuname": "分班管理",
        "icon": "icon-add",
        "url": "../shiftedit.aspx"
    },
        {
            "menuid": "002",
            "menuname": "开发测试",
            "icon": "icon-log",
            "url": "../test.aspx"
        },

        {
            "menuid": "005",
            "menuname": "帮助说明",
            "icon": "icon-log",
            "url": "../help.html"
        }
        ]
}
    ]
        };

    </script>
</head>
<!--<body class="easyui-layout" style="overflow-y: hidden"  scroll="no">-->
<body class="easyui-layout">
    <%--<form id="form1" runat="server">--%>
    <noscript>
        <div style="position: absolute; z-index: 100000; height: 2046px; top: 0px; left: 0px;
            width: 100%; background: white; text-align: center;">
            <img src="images/noscript.gif" alt='抱歉，请开启脚本支持！' />
        </div>
    </noscript>
    <div region="north" split="true" border="false" style="overflow: hidden; height: 45px;
        background: url(images/layout-browser-hd-bg.gif) #7f99be repeat-x center 50%;
        line-height: 45px; color: #fff; font-family: Verdana, 微软雅黑,黑体;">
        <span style="float: right; padding-right: 20px; padding-bottom: 1px;" class="head"><a
            href="#" id="langEN">English</a> <a href="#" id="langCN">中文</a> <a href="#" id="langCNEN">
                中英文</a> </span><span style="padding-left: 10px; font-size: 22px; clip: rect(auto, auto, 0px, auto);
                    padding-bottom: 1px; font-weight: 700;">
                    <img src="images/messer.jpg" width="140" height="40" align="left" style="background-color: #FFFFFF" />
                    <asp:Literal ID="Literal2" runat="server" Text="<%$Resources:lang,index_title%>" />
                    <asp:Label ID="lblang" runat="server" Text="zh-cn" Font-Bold="False" Font-Size="XX-Small"></asp:Label>
                </span>
    </div>
    <div id="lwest" title="导航菜单" region="west" split="true" style="width: 140px;">
        <div id="nav" class="easyui-accordion" fit="true" border="false">
        </div>
    </div>
    <div region="south" split="true" style="height: 30px; background: #D2E0F2;">
        <div id="footer" class="footer">
            Copyright © 2011 - 2021 AHUT All Rights Reserved
        </div>
    </div>
    <div id="mainPanle" region="center" style="background: #eee; overflow-y: hidden;
        display: none">
        <div id="tabs" class="easyui-tabs" fit="true" border="false">
        </div>
        <!--右键tab页弹出菜单-->
        <div id="mm" class="easyui-menu" style="width: 150px; display: none">
            <div id="mm-tabupdate">
                刷新</div>
            <div class="menu-sep">
            </div>
            <div id="mm-tabclose">
                关闭</div>
            <div id="mm-tabcloseall">
                全部关闭</div>
            <div id="mm-tabcloseother">
                除此之外全部关闭</div>
            <div class="menu-sep">
            </div>
            <div id="mm-tabcloseright">
                当前页右侧全部关闭</div>
            <div id="mm-tabcloseleft">
                当前页左侧全部关闭</div>
            <div class="menu-sep">
            </div>
            <div id="mm-exit">
                退出</div>
        </div>
       
</body>
</html>
