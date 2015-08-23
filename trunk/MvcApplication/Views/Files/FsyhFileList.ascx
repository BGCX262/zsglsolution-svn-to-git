<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Models.FsyhFileListModel>" %>
    <link type="text/css" href="../../DataTables/css/demo_page.css" rel="Stylesheet" />
    <link type="text/css" href="../../DataTables/css/demo_table.css" rel="Stylesheet" />
    <script type="text/javascript" src="../../DataTables/js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../../Scripts/MicrosoftMvcAjax.js"></script>
    <script type="text/javascript" src="../../Scripts/MicrosoftMvcValidation.js"></script>
    <script type="text/javascript">
        $(function() {
            $('.display').dataTable();
        });
    </script>
    <div class="upload_content">
    <table cellpadding="0" cellspacing="0" border="0" class="display" style="font-size:12px">
    <thead>
    <tr>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">文件名</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">上传时间</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">查看</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">下载</th>
    </tr>
    </thead>
    <tbody>
        <%foreach (var file in Model.FsyhFilesEntities)
      { %>
    <tr>
    <td class=" sorting_1"><%=file.FileInfo.file_name %></td>
    <td class=" sorting_1"><%=file.FileInfo.file_scsj%></td>
    <td class=" sorting_1"><a onclick="showFile('<%=Url.Encode(file.FileInfo.file_path) %>')" href="#">查看</a></td>
    <td class=" sorting_1"><%=Ajax.ActionLink("下载", "DownloadFile", "Download", new { fileID = file.FileInfo.file_id }, new AjaxOptions { })%></td>
    </tr>
    <%} %>
    </tbody>
</table>
</div>

