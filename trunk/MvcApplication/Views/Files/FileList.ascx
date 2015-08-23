<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Entities.FileListEntity>" %>
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
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">移动</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">删除</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">下载</th>
    </tr>
    </thead>
    <tbody>
    <%foreach (var file in Model.Files)
      { %>
    <tr>
    <td class=" sorting_1"><%=file.file_name %></td>
    <td class=" sorting_1"><%=file.file_scsj %></td>
    <td class=" sorting_1"><%=Ajax.ActionLink("查看", "ShowFile", new { filePath = file.file_path }, new AjaxOptions { })%></td>
    <td class=" sorting_1"><a onclick="moveTo('<%=file.file_name %>','<%=file.file_id %>')" href="#">移动到》</a></td>
    <td class=" sorting_1"><%=Ajax.ActionLink("删除", "DelFile", "Files", new { fileID = file.file_id }, new AjaxOptions { })%></td>
    <td class=" sorting_1"><%=Ajax.ActionLink("下载", "DownloadFile", "Download", new { fileID=file.file_id }, new AjaxOptions { })%></td>
    </tr>
    <%} %>
    </tbody>
</table>
<%if (Model.CanAddNewFloder)
  { %>
     <div ><a  onclick="addFolder('<%=Model.FloderInfo.floder_name %>')" href="#">新建文件夹</a></div>
<%} %>
<%if (Model.CanDelFolder)
  { %>
  
     <div style="margin-top:10px;"><%=Ajax.ActionLink("删除该文件夹", "DelFloder", "Floder", 
              new { floderName = Model.FloderInfo.floder_name, higherFloder = Model.FloderInfo.floder_higher },
              new AjaxOptions { })%></div>
<%} %>
</div>