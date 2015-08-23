<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MvcApplication.Models.UserModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>知识管理系统-管理员</title>
    <link type="text/css" href="../../Content/Main.css" rel="Stylesheet" />
    <link type="text/css" href="../../Content/GxNode.css" rel="Stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="../../JavaScripts/main.js"></script>
    <script type="text/javascript" src="../../Scripts/MicrosoftMvcAjax.js"></script>
    <script type="text/javascript" src="../../Scripts/MicrosoftMvcValidation.js"></script>
    <script type="text/javascript">
        $(function() {
            $('.display').dataTable();
        });
    </script>
</head>
<body>
    <%--遮罩--%>
    <div id="overlay" class="simplemodal-overlay" 
    style="opacity: 0.5; height: 589px; width: 1366px; position: fixed; left: 0px; top: 0px; 
    z-index: 1001; visibility:hidden;"></div>
    
    <div id="top">
        <h2>管理菜单</h2>
        <div class="jg"></div>
        <div id="topTags">
            <ul>
            </ul>
        </div>
        <div id="friends">
        </div>
    </div>
    <div id="main"> 
        <div id="leftMenu">
            <ul>
                <li class="button">用户管理</li>
                <li class="dropdown">
                    <ul>
                        <li class="canClickLi">新增用户</li>
                        <li class="canClickLi">禁用用户</li>
                        <li class="canClickLi">启用用户</li>
                        <li class="canClickLi">查看用户</li>
                        <li class="canClickLi">设置密码</li>
                    </ul>
                </li>
            </ul>
        </div>
        <div class="jg"></div>
       <div id="content">
            <div id="welcome" class="content" style="display:block;">
                <div align="center">
                    <p>&nbsp;</p>
                    <p><strong>欢迎使用用户管理系统！</strong></p>
                    <p>&nbsp;</p>
                </div>
            </div> 
            <div id="c0" class="content"><%Html.RenderAction("AddNewZyh", "Yhgl"); %></div>
            <div id="c1" class="content"><%Html.RenderAction("DisableZyhView", "Yhgl"); %></div>
            <div id="c2" class="content"><%Html.RenderAction("EnabledZyhView", "Yhgl"); %></div>
            <div id="c3" class="content"><%Html.RenderAction("UsersView", "Yhgl"); %></div>
            <div id="c4" class="content"><%Html.RenderAction("ChangePsw", "Yhgl"); %></div>
        </div>
    </div>
    <div id="footer">copyright for 865171 by 865171</div>
</body>
</html>
