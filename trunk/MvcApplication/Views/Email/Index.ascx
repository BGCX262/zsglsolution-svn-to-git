<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Models.UserModel>" %>

<script type="text/javascript" src="../../Scripts/MicrosoftAjax.js"></script>
<script type="text/javascript" src="../../Scripts/MicrosoftMvcAjax.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
<script type="text/javascript">
    function AddAccessories() { 
        $('#overlay').css("visibility", "visible");
        $('#EmailAttachment').css("visibility", "visible");
    }
    function FileClick(fileID, fileName) {
        try {
            var a_Onclick = "RemomveAccessories('" + fileID + "','AccessoriesList')";

            $('#AccessoriesList').append("<div id='" + fileID + "' class='shanchu'><div id='shanchu_word'><div>" + fileName + "</div></div><span onclick=" + a_Onclick + "><div id='shanchu_cha'></div></span>" +
                                "<input type='hidden' name='filesGx' value='" + fileID + "'/></div>");
        } catch (e) {
            alert(e.message);
        }
    }

    function RemomveAccessories(id, elId) {
        $('#' + elId).find("#" + id).remove();
        $.ajax({
            type: "POST",
            url: "/Email/RemoveAccessories",
            data: "fileId=" + id
        });
    }
    function Send() {
        $('#overlay').css("visibility", "visible");
        $('#sending').css("visibility", "visible");
    }
    function Successed() {
        alert('邮件发送成功！');
        $('#overlay').css("visibility", "hidden");
        $('#sending').css("visibility", "hidden");
    }
    function Failed(msg) {
        alert("邮件发送失败！" + msg);
        $('#overlay').css("visibility", "hidden");
        $('#sending').css("visibility", "hidden");
    }
</script>
<div style="width:550px;height:auto!important;height:725px;min-height:725px;background:#FFFFFF;border:solid 1px #D1D8DD;margin-top:24px;">
    <%using (Ajax.BeginForm("Send", new AjaxOptions { UpdateTargetId="emailRst"}))
      { %>
      <div class="sendmail_sender">
        <%=Html.Label("发信人") %>
        <%=Html.TextBox("sender", Model.UserInfo.user_email, new { @class = "common_text" })%>
      </div>
      <div class="sendmail_recieve">
        <%=Html.Label("收信人") %>
        <%=Html.TextBox("receiver", "", new { @class = "common_text" })%>
     
      </div>
      <div class="sendmail_recieve">
        <%=Html.Label("主题　") %>
        <%=Html.TextBox("topic", "", new { @class = "common_text" }) %>
      </div>
      <div class="sendmail_content">
        <%=Html.Label("内容:") %>
        <%=Html.TextArea("content", new { @class = "common_longtext" })%>
      </div>
      <div class="sendmail_mailpass">
        <%=Html.Label("邮箱密码") %>
        <%=Html.Password("psw", "", new { @class = "common_text" }) %>
      <p><input type="button" value="添加附件" onclick="AddAccessories()" /></p>
      <div id="AccessoriesList"></div>
      </div>
	  <div class="sendmail_fasong">
      <input type="submit" value="发送" onclick="Send()" class="sendmail_fasong_btn"/>
      </div>
    <%} %>
    <div id="emailRst"></div>
</div>