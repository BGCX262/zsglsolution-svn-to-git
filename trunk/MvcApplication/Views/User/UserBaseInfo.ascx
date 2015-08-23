<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Models.UserModel>" %>
<script type="text/javascript">
    function UploadAvatar() {
        $('#uplodaAvatar').slideToggle('slow')
        .load("/Upload/UploadAvatar");
    }
    
</script>
<div class="upload_content">
<%using (Ajax.BeginForm("UpdateUserInfo", "User", new AjaxOptions { }))
  { %>
<div class="usermsg_pic">
<%=Html.Label("头像") %>
<img id="Avatar" alt="用户头像" src="<%=Model.UserInfo.user_avatar %>" style=" width:80px; height:80px;" />
<a href="#" onclick="UploadAvatar()">上传头像</a>
<span id="uplodaAvatar" style=" display:none">
</span>
</div>
<div class="usermsg_mail">
<%=Html.Label("用 户 名") %>
<%=Html.TextBox("userName", Model.UserInfo.user_name, new { @class = "common_text" })%>
</div>
<div class="usermsg_mail">
<%=Html.Label("邮箱地址")%>
<%=Html.TextBox("email", Model.UserInfo.user_email, new { @class = "common_text" })%>
</div>
<div class="usermsg_mail">
<%=Html.Label("手机号码")%>
<%=Html.TextBox("mobile", Model.UserInfo.user_mobile, new { @class = "common_text" })%>
</div>
<div class="usermsg_mail">
<%=Html.Label("电话号码")%>
<%=Html.TextBox("tel", Model.UserInfo.user_tel, new { @class = "common_text" })%>
</div>
<div class="usermsg_mail">
<%=Html.Label("传真号码")%>
<%=Html.TextBox("fax", Model.UserInfo.user_fax, new { @class = "common_text" })%>
</div>
<input type="submit" value="修改" class="upload_choosedoc"/>
<%} %>
</div>
<script type="text/javascript">
    $('.display').dataTable();
</script>

