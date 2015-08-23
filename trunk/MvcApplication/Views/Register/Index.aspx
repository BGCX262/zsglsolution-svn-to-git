<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MvcApplication.Helpers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Index</title>
    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="../../Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="../../Scripts/MicrosoftMvcAjax.js"></script>
    <script type="text/javascript">
        $(function() {
            $('#username').attr("value", getCookie("username"));
            $('#psw').attr("value", getCookie("psw"));
            $('#pswAgain').attr("value", getCookie("pswAgain"));
            $('#email').attr("value", getCookie("email"));
            $('#bm').attr("value", getCookie("bm"));
            $('#mobile').attr("value", getCookie("mobile"));
            $('#tel').attr("value", getCookie("tel"));
            $('#fax').attr("value", getCookie("fax"));
            clearCookie("username");
            clearCookie("psw");
            clearCookie("pswAgain");
            clearCookie("email");
            clearCookie("bm");
            clearCookie("mobile");
            clearCookie("tel");
            clearCookie("fax");
        });
        var canSubmit = true;
        
        //验证用户名是否已经被注册
        function ValidationData() {
            if ($('#username').val() == "")
                $('#valRst').text("用户名不能为空。");
            else {
                $.ajax({
                    type: "POST",
                    url: "/Register/ValidationData",
                    data: "userName=" + $('#username').val(),
                    success: function(msg) {
                        if (msg == "true")
                            $('#valRst').text("该用户名可以使用。");
                        else {
                            canSubmit = msg;
                            $('#valRst').text("已存在该用户名。");
                        }
                    }
                });
            }
        }
        
        //验证两次密码输入是否一致
        function CheckPsw() {
            var pswAgain = $('#pswAgain').val();
            var psw = $('#psw').val();
            if (psw == "")
                $('#pswRst').text("密码不能为空。");
            else{
                if (psw == pswAgain)
                    $('#pswRst').text("两次输入一致。");
                else {
                    canSubmit = false;
                    $('#pswRst').text("两次输入不一致！");
                }
            }
        }

        //验证邮箱格式是否正确
        function CheckEmail() {
            var temp = $('#email').val();
            if (temp == "")
                $('#emailRst').text("邮箱不能为空。");
            else {
                var myreg = /^[0-9a-zA-Z]+([._\-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+\.[0-9a-zA-Z]+$/;
                if (!myreg.test(temp)) {
                    canSubmit = false;
                    $('#emailRst').text("邮箱格式不正确。");
                    return false;
                } else {
                    $('#emailRst').text("邮箱格式正确。");
                }
            }
        }
        //验证码
        function CheckAttempt() {
            var temp = $('#attempt').val();
            if (temp == "")
                $('#attemptRst').text("验证码不能为空。");
            else {
                $.ajax({
                    type: "POST",
                    url: "/Register/SubmitRegistration",
                    data: "myCaptcha=" + $('#myCaptcha').val() + "&attempt=" + temp,
                    success: function(msg) {
                        if (msg == "true")
                            $('#attemptRst').text("正确。");
                        else {
                            canSubmit = msg;
                            ChangeCaptha();
                            $('#attemptRst').text("验证码输入错误。");
                        }
                    }
                });
            }
            ValidationBefore();
        }
        
        //在提交前最后验证
        function ValidationBefore() {
            ValidationData();
            CheckEmail();
            CheckPsw();
            if (canSubmit != "true") {
                $('#beforeRst').text("数据没有填写正确或完整不能注册，请仔细检查。");
                $('#submitForm').attr("disabled", "disabled");
                return false;
            }
            else {
                $('#beforeRst').text("数据填写正确,可以注册。");
                $('#submitForm').removeAttr("disabled");
            }
        }
        var s;
        function ChangeCaptha() {
            document.cookie = "username" + "=" + escape($('#username').val());
            document.cookie = "psw" + "=" + escape($('#psw').val());
            document.cookie = "pswAgain" + "=" + escape($('#pswAgain').val());
            document.cookie = "email" + "=" + escape($('#email').val());
            document.cookie = "bm" + "=" + escape($('#bm').val());
            document.cookie = "mobile" + "=" + escape($('#mobile').val());
            document.cookie = "tel" + "=" + escape($('#tel').val());
            document.cookie = "fax" + "=" + escape($('#fax').val());
            window.location.reload();
        }

        function getCookie(name) {
            var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));

            if (arr != null) {
                return unescape(arr[2]);
            }
            return null;
        }

        function clearCookie(name) {
            var exp = new Date();
            exp.setTime(exp.getTime() - 1);
            var cval = getCookie(name);
            if (cval != null) document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
        }
    </script>
</head>
<body>
    <div>
        <fieldset>
            <legend>用户注册</legend>
            <%using (Ajax.BeginForm("RegisterUser", new AjaxOptions { }))
              { %>
                <%--用户名--%>
                <p>
                    <span style="color:Red">*</span> <%=Html.Label("用户名:")%>
                    <%=Html.TextBox("username", "", new { onchange = "ValidationData()" })%>
                    <span id="valRst"></span>
                </p>
                <%--密码--%>
                <p>
                    <span style="color:Red">*</span> <%=Html.Label("密码:") %>
                    <%=Html.Password("psw") %>
                </p>
                <%--再次输入--%>
                <p>
                    <%=Html.Label("再次输入:") %>
                    <%=Html.Password("pswAgain", "", new { onchange = "CheckPsw()" })%>
                    <span id="pswRst"></span>
                </p>
                <%--邮箱--%>
                <p>
                    <span style="color:Red">*</span> <%=Html.Label("邮箱:") %>
                    <%=Html.TextBox("email", "", new { onchange = "CheckEmail()" })%>
                    <span id="emailRst"></span>
                </p>
                <p>
                    <%=Html.Label("部门:") %>
                    <%=Html.TextBox("bm") %>
                </p>
                <p>
                    <%=Html.Label("移动电话:") %>
                    <%=Html.TextBox("mobile") %>
                </p>
                <p>
                    <%=Html.Label("固定电话:") %>
                    <%=Html.TextBox("tel") %>
                </p>
                <p>
                    <%=Html.Label("传真") %>
                    <%=Html.TextBox("fax") %>
                </p>
                <p id="p_capthca">
                    <%=Html.Captcha("myCaptcha") %>
                    <a id="changeCaptha" onclick="ChangeCaptha()">换一个</a>
                </p>
                <p>
                    <%=Html.Label("输入验证码:") %>
                    <%=Html.TextBox("attempt", "", new { onchange = "CheckAttempt()" })%>
                    <span id="attemptRst"></span>
                </p>
                <input type="submit" value="注册" disabled="disabled" id="submitForm"/>
                <div id="beforeRst"></div>
            <%} %>
        </fieldset>
    </div>
</body>
</html>
