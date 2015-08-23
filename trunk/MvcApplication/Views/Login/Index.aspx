<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>知识管理系统登录页面</title>
    <link href="../../Content/login_style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="../../Scripts/MicrosoftMvcAjax.js"></script>
    <script type="text/javascript">
        function Register() {
            document.location = "/Register/Index";
        }
    </script>
</head>
<body>
    <center>
    	<div>
            <div id="content">
            	<div id="main">
            	<%using(Ajax.BeginForm("Verify", new AjaxOptions { })){%>
                    <div id="main_text">
                    	<div id="main_text1">
                            <%=Html.TextBox("username") %>
                        </div>
                        <div id="main_text2">
                            <%=Html.Password("password")%>
                        </div>
                        <div id="main_text3">
                            <p><%=Html.RadioButton("userKind", "主用户", true)%>主用户
                          <%=Html.RadioButton("userKind", "附属用户")%>附属用户</p>
                        </div>
                    </div>
                    <div id="main_queren">
                      <input style="margin-right:150px;" type="button" value="注册" onclick="Register()"/>
                      <input type="submit"value="登录" />
                    </div>
           	  </div>
           	  <%} %>
            </div>
        </div>
    </center>
</body>
</html>
