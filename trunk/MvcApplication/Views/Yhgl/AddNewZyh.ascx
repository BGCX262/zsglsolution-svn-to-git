<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="../../Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="../../Scripts/MicrosoftMvcAjax.js"></script>
    <script type="text/javascript" src="../../JavaScripts/AddUser.js"></script>
    <div class="upload_content">
        <fieldset style="color:#42B2E7;font-size:12px;">
            <legend style="color:#2D82BD;font-size:14px;">用户注册</legend>
            <%using (Ajax.BeginForm("AddNewZyh2SQL","Yhgl", new AjaxOptions { }))
              { %>
              <p>
              <%=Html.Label("头像") %>
              <img id="Avatar" src="../../Avatar/default.gif" alt="默认头像" style=" width:90px; height:90px;" />
              <a href="#" onclick="UploadAvatar()">上传头像</a>
              <input type="hidden" value="../../Avatar/default.gif" name="avatarPath" />
              </p>
              <div id="uplodaAvatar" style=" display:none">
              <%Html.RenderAction("UploadAvatar", "Upload"); %>
              </div>
                <%--用户名--%>
              
                <p>
                    <div class="main_text1">
                    <span style="color:Red">*</span> <%=Html.Label("用户名:")%>
                    <%=Html.TextBox("username", "", new { onchange = "ValidationData()" })%>
                    </div>
                    <span id="valRst" style="font-size:12px;margin-left:10px;"></span>
                </p>
              
                <%--密码--%>
                <p>
                    <div class="main_text2">
                    <span style="color:Red">*</span> <%=Html.Label("密码:") %>
                    <%=Html.Password("psw") %>
                    </div>
                </p>
                <%--再次输入--%>
                <p>
                    <div class="main_text3">
                    <%=Html.Label("再次输入:") %>
                    <%=Html.Password("pswAgain", "", new { onchange = "CheckPsw()" })%>
                     </div>
                    <span id="pswRst" style="font-size:12px;margin-left:10px;"></span>
                </p>
                <%--邮箱--%>
                <p>
                    <div class="main_text4">
                    <span style="color:Red">*</span> <%=Html.Label("邮箱:") %>
                    <%=Html.TextBox("email", "", new { onchange = "CheckEmail()" })%>
                    </div>
                    <span id="emailRst" style="font-size:12px;margin-left:10px;"></span>
                </p>
                <p>
                    <div class="main_text5">
                    <%=Html.Label(" 部门:") %>
                    <%=Html.TextBox("bm") %>
                    </div>
                </p>
                <p>
                    <div class="main_text6">
                    <%=Html.Label("移动电话:") %>
                    <%=Html.TextBox("mobile") %>
                    </div>
                </p>
                <p>
                    <div class="main_text7">
                    <%=Html.Label("固定电话:") %>
                    <%=Html.TextBox("tel") %>
                    </div>
                </p>
                <p>
                    <div class="main_text5">
                    <%=Html.Label("传真:") %>
                    <%=Html.TextBox("fax") %>
                    </div>
                </p>
                <input type="submit" value="确定" disabled="disabled" id="submitForm"/>
                <div id="beforeRst"></div>
            <%} %>
        </fieldset>
    </div>


