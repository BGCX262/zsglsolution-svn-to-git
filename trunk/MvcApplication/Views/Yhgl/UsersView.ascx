<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Models.UserWithFilesModel>" %>
<link type="text/css" href="../../DataTables/css/demo_page.css" rel="Stylesheet" />
<link type="text/css" href="../../DataTables/css/demo_table.css" rel="Stylesheet" />
<script type="text/javascript" src="../../DataTables/js/jquery.dataTables.js"></script>
<div class="upload_content">
<%foreach (var userWithFiles in Model.UserWithFiles)
  { %>
      <div class="fileTable" onclick="UserClick(this)" style="color:#42B2E7;">用户名：<%=userWithFiles.User.user_name %><span style=" float:right;*margin-top:-20px;">文件数：<%=userWithFiles.Files.Count %></span></div>
      <div style=" display:none; border:1px solid">
        <table cellpadding="0" cellspacing="0" border="0" class="display" style="font-size:12px">
        <thead>
        <tr>
        <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">文件名</th>
        <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">上传时间</th>
        <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">备注</th>
        <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">删除文件</th>
        </tr>
        </thead>
        <tbody>
        <%foreach (var file in userWithFiles.Files)
          { %>
          <tr>
          <td class=" sorting_1"><%=file.file_name %></td>
          <td class=" sorting_1"><%=file.file_scsj %></td>
          <td class=" sorting_1"><%=file.file_bz %></td>
          <td class=" sorting_1"><%=Ajax.ActionLink("删除","DelFile", "Files", new {fileId=file.file_id }, new AjaxOptions { })%></td>
          </tr>
        <%} %>
        </tbody>
        </table>
      </div>
<%} %>
</div>
<script type="text/javascript">
var fileTable = $('.fileTable');
for (i = 0; i < fileTable.length; i++) {
    if (i % 2 == 0)
        $(fileTable[i]).css("background-color", "#BBFFEE");
    else
        $(fileTable[i]).css("background-color", "#FFFFFF");
};

    function UserClick(e) {
        var dropDown = $(e).next('div');
        dropDown.slideToggle('slow');
    }
</script>
