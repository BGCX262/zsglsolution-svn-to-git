<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Models.Files_ShareToOthersModel>" %>
<link type="text/css" href="../../DataTables/css/demo_page.css" rel="Stylesheet" />
<link type="text/css" href="../../DataTables/css/demo_table.css" rel="Stylesheet" />
<script type="text/javascript" src="../../DataTables/js/jquery.dataTables.js"></script>
<script type="text/javascript" src="../../Scripts/MicrosoftMvcAjax.js"></script>
<script type="text/javascript" src="../../Scripts/MicrosoftMvcValidation.js"></script>
<div class="upload_content">
<table cellpadding="0" cellspacing="0" border="0" class="display" style="font-size:12px">
    <thead>
    <tr>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">文件名</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">共享对象</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">共享对象类型</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">共享时间</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">取消共享</th>
    </tr>
    </thead>
    <tbody>
    <%foreach (var zyhFile in Model.Files_ShareToZyhEntities)
      { %>
      <tr>
      <td><%=zyhFile.FileName %></td>
      <td><%=zyhFile.ZyhName %></td>
      <td>主用户</td>
      <td><%=zyhFile.File_ShareToZyh.gx_sj %></td>
      <td><%=Ajax.ActionLink("取消共享", "CancelGx", new { gxId = zyhFile.File_ShareToZyh.gx_id, userType="主用户" }, new AjaxOptions { })%></td>
      </tr>
    <%} %>
    <%foreach (var fsyhFile in Model.Files_ShareToFsyhEntities)
      { %>
      <tr>
      <td><%=fsyhFile.FileName %></td>
      <td><%=fsyhFile.FsyhName %></td>
      <td>附属用户</td>
      <td><%=fsyhFile.File_ShareToFsyh.fsyhgx_sj %></td>
      <td><%=Ajax.ActionLink("取消共享", "CancelGx", new { gxId = fsyhFile.File_ShareToFsyh.fsyhgx_id, userType = "附属用户" }, new AjaxOptions { })%></td>
      </tr>
    <%} %>
    </tbody>
</table>
</div>

