<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Models.GxFilesModel>" %>
<div class="upload_content">
<table>
    <thead>
        <tr>
            <td>文件名</td>
            <td>上传时间</td>
            <td>共享对象</td>
            <td>查看</td>
        </tr>
    </thead>
    <%foreach (var file in Model.ZyhGxFiles)
      { %>
      <tr>
        <td><%=file.FileInfo.file_name %></td>
        <td><%=file.FileInfo.file_scsj %></td>
        <td><%=file.GxyhInfo.user_name %></td>
        <td><%=Ajax.ActionLink("查看", "ShowFile", new { filePath = file.FileInfo.file_path }, new AjaxOptions { })%></td>
      </tr>
    <%} %>
</table>
</div>