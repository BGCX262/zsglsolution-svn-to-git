<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Models.EmailWithFilesModel>" %>
    <link type="text/css" href="../../DataTables/css/demo_page.css" rel="Stylesheet" />
    <link type="text/css" href="../../DataTables/css/demo_table.css" rel="Stylesheet" />
    <script type="text/javascript" src="../../DataTables/js/jquery.dataTables.js"></script>
    <script type="text/javascript">
        function forward(mailId, obj) {
            $('#overlay').css("visibility", "visible");
            $('#sending').css("visibility", "visible");
            var input = $('input');
            var receiver = $(obj).prev().val();
            var psw = $('input#forwardPsw').val();
            $.ajax({
                type: "POST",
                url: "/Email/ForwardEmail",
                data: "emailId=" + mailId + "&receiver=" + receiver + "&psw=" + psw
            });
        }
        function ForwardSuccessed() {
            alert('邮件发送成功！');
            $('#overlay').css("visibility", "hidden");
            $('#sending').css("visibility", "hidden");
        }

        function ForwardFailed(msg) {
            alert("邮件发送失败！" + msg);
            $('#overlay').css("visibility", "hidden");
            $('#sending').css("visibility", "hidden");
        }
    </script>
    <div class="upload_content">
    <%=Html.Label("邮箱密码：") %>
    <%=Html.Password("forwardPsw") %>
    <br /><br />
    <hr />
    <br /><br />
    <table class="display" cellpadding="0" cellspacing="0" border="0" style="font-size:12px;" width="560">
    <thead>
    <tr>
    <th class="sorting_desc" rowspan="1" colspan="1">邮件主题</th>
    <th class="sorting_desc" rowspan="1" colspan="1">收件人</th>
    <th class="sorting_desc" rowspan="1" colspan="1">邮件内容</th>
    <th class="sorting_desc" rowspan="1" colspan="1">邮件附件</th>
    <th class="sorting_desc" rowspan="1" colspan="1">发送时间</th>
    <th class="sorting_desc" rowspan="1" colspan="1">转发</th>
    </tr>
    </thead>
    <tbody>
    <%foreach (var email in Model.YjmxWithFilesEntites)
      { 
          var fjs=string.Empty;
          foreach(var file in email.Files){
            fjs+=file.file_name+"|";
          }
     %>
      <tr>
      <td class=" sorting_1"><%=email.Yjmx.yj_zt %></td>
      <td class=" sorting_1"><%=email.Yjmx.yj_sjr %></td>
      <td class=" sorting_1"><%=email.Yjmx.yj_nr %></td>
      <td class=" sorting_1"><%=fjs%></td>
      <td class=" sorting_1"><%=email.Yjmx.yj_fssj %></td>
      <td class=" sorting_1"><%=Html.TextBox(email.Yjmx.yj_id.ToString(), "", new { style="width:100px" })%><a onclick="forward('<%=email.Yjmx.yj_id %>',this)" href="#">转发</a></td>
      </tr>
    <%} %>
    </tbody>
    </table>
    </div>

