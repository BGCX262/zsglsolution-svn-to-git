<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Models.UsersModel>" %>
    <link type="text/css" href="../../DataTables/css/demo_page.css" rel="Stylesheet" />
    <link type="text/css" href="../../DataTables/css/demo_table.css" rel="Stylesheet" />
    <script type="text/javascript" src="../../DataTables/js/jquery.dataTables.js"></script>
<div class="upload_content">
<table cellpadding="0" cellspacing="0" border="0" class="display" style="font-size:12px;">
    <thead>
    <tr>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">用户名</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">邮箱</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">部门</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">手机</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">电话</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">禁用</th>
    </tr>
    </thead>
    <tbody>
    <%foreach (var user in Model.Users)
      { %>
      <tr>
      <td class=" sorting_1"><%=user.user_name %></td>
      <td class=" sorting_1"><%=user.user_email %></td>
      <td class=" sorting_1"><%=user.user_bm %></td>
      <td class=" sorting_1"><%=user.user_mobile %></td>
      <td class=" sorting_1"><%=user.user_tel %></td>
      <td class=" sorting_1" align=center><%=Ajax.ActionLink("禁用", "DisableZyh", new {userId=user.user_id }, new AjaxOptions { })%></td>
      </tr>
    <%} %>
    </tbody>
</table>
</div>

