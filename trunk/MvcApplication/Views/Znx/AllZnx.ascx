<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Models.ZnxModel>" %>
<div class="upload_content">
<table cellpadding="0" cellspacing="0" border="0" class="display" style="font-size:12px">
<thead>
<tr>
<th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">主题</th>
<th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">接收人</th>
<th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">内容</th>
<th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">发送时间</th>
</tr>
</thead>
<tbody>
<%foreach (var znx in Model.ZnxEntities)
  { %>
  <tr>
  <td class="sorting_1"><%=znx.Znxmx.znx_topic %></td>
  <td class="sorting_1"><%=znx.ReceiverName %></td>
  <td class="sorting_1"><%=znx.Znxmx.znx_nr %></td>
  <td class="sorting_1"><%=znx.Znxmx.znx_fssj %></td>
  </tr>
<%} %>
</tbody>
</table>
</div>
