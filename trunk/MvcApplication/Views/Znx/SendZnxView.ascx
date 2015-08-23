<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Models.UserModel>" %>
<link type="text/css" href="../../DataTables/css/demo_page.css" rel="Stylesheet" />
<link type="text/css" href="../../DataTables/css/demo_table.css" rel="Stylesheet" />
<script type="text/javascript" src="../../DataTables/js/jquery.dataTables.js"></script>
<script type="text/javascript" src="../../Scripts/MicrosoftAjax.js"></script>
<script type="text/javascript" src="../../Scripts/MicrosoftMvcAjax.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
<script type="text/javascript">
    function ZnxSend() {
        $('#overlay').css("visibility", "visible");
        $('#sending').css("visibility", "visible");
    }
    function ZnxSuccessed() {
        alert('站内信送成功！');
        $('#overlay').css("visibility", "hidden");
        $('#sending').css("visibility", "hidden");
    }
    function ZnxFailed(msg) {
        alert("站内信发送失败！" + msg);
        $('#overlay').css("visibility", "hidden");
        $('#sending').css("visibility", "hidden");
    }

    function AddReceiver() {
        $('#overlay').css("visibility", "visible");
        $('#frinds').css("visibility", "visible");
    }

    function SelectFriend(id, name) {
        var isExist = false;
        var checkedFiles = $('#rsvName input');
        for (j = 0; j < checkedFiles.length; j++) {
            if (checkedFiles[j].value == id) {
                isExist = true;
            }
        }
        if (isExist)
            return false;
        else {
            var a_Onclick = "removeSelect('" + id + "','rsvName')";
            $('#rsvName').append("<div id='" + id + "' class='shanchu'><div id='shanchu_word'><div>" + name + "</div></div><span onclick=" + a_Onclick + "><div id='shanchu_cha'></div></span>" +
        "<input type='hidden' value='" + id + "' name='rsvID' /></div>");
            cancelNotRefresh('frinds');
        }
    }
</script>
<div id="frinds" class="back-G" style="visibility:hidden; z-index: 1002;">
    <div class="tanchu">
    <div class="tanchu_cha" onclick="cancelNotRefresh('frinds')"></div>
    <div class="tanchu_content">
    <div>
        <%foreach (var friend in Model.FriendMx)
          { %>
          <%=friend.YhInfo.user_name%>
          <a onclick="SelectFriend('<%=friend.YhInfo.user_id %>','<%=friend.YhInfo.user_name %>')" href="#">选择</a>
        <%} %>
    </div>
    </div>
    </div>
</div>
<div class="upload_content">
    <%using (Ajax.BeginForm("Send", new AjaxOptions { UpdateTargetId="emailRst"}))
      { %>
      <div class="sendmail_sender">
        <%=Html.Label("发信人") %>
        <%=Html.TextBox("sender", Model.UserInfo.user_name, new { @class = "common_text" })%>
      </div>
     <div class="sendmail_sender">
        <%=Html.Label("收信人") %>
        <input type="button" value=">>" onclick="AddReceiver()"/><br /><div id="rsvName" style="margin-left:40px;"></div>
      </div>
      
       <div class="sendmail_sender">
        <%=Html.Label("主题") %>
        <%=Html.TextBox("topic", "", new { @class = "common_text" })%>
      </div>
     <div class="sendmail_content">
        <%=Html.Label("内容") %><br />
        <%=Html.TextArea("content", new { cols="62" ,rows="25", @class="common_longtext"})%>
      </div>
      <input type="submit" value="发送" onclick="ZnxSend()" class="sendmail_send"/>
      <div id="receiverID" style=" visibility:hidden"></div>
    <%} %>
    <div id="emailRst"></div>
</div>

