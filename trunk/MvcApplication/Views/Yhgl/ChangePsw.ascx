<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Models.UsersModel>" %>
    <link type="text/css" href="../../DataTables/css/demo_page.css" rel="Stylesheet" />
    <link type="text/css" href="../../DataTables/css/demo_table.css" rel="Stylesheet" />
    <script type="text/javascript" src="../../DataTables/js/jquery.dataTables.js"></script>
<div class="upload_content">
<table cellpadding="0" cellspacing="0" border="0" class="display"style="font-size:12px">
<thead>
<tr>
<th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">用户名</th>
<th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">重置密码</th>
<th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">确定</th>
</tr>
</thead>
<tbody>
<%foreach (var user in Model.Users)
  { %>
  <tr>
  <%using (Ajax.BeginForm("SetNewPsw", "Yhgl", new { userId=user.user_id}, new AjaxOptions { }))
    { %>
  <td class="sorting_1" ><%=user.user_name%></td>
  <td class="sorting_1" align=center><%=Html.Password("newPsw")%></td>
  <td class="sorting_1" align=center><input type="submit" value="确定" /></td>
  <%} %>
  </tr>
<%} %>
</tbody>
</table>
</div>
    
    <script type="text/javascript">
        $('.display').dataTable();
    </script>

