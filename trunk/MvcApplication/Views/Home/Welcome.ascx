<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Models.UserModel>" %>
    <img src="../../Images/welcome.gif" class="index_welcome" alt="欢迎">
    <font style="color:#2D82BD">未查看的共享文件:</font>
    <%bool count = false; foreach (var gx in Model.ZyhGxFiles)
      {
          if (gx.Gxmx.gx_isread == "否")
              count = true;
      }%>
      <%bool znxcount = false; foreach (var znx in Model.ZnxMx) {
            if (znx.Znxmx.znx_isread == "否")
                znxcount = true;
        } %>
      <%if (!count)
        { %>
        无
      <%}
        else
        { %>
    <div>
    <table cellpadding="0" cellspacing="0" border="0" class="display">
    <thead>
    <tr>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">文件名</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">共享时间</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">共享来源</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">查看</th>
    </tr>
    </thead>
    <tbody>
    <%foreach (var gx in Model.ZyhGxFiles)
      {
          if (gx.Gxmx.gx_isread == "否")
          { %>
      <tr>
      <td class="sorting_1"><%=gx.FileInfo.file_name%></td>
      <td class="sorting_1"><%=gx.Gxmx.gx_sj%></td>
      <td class="sorting_1"><%=gx.GxyhInfo.user_name%></td>
      <td class="sorting_1"><%=Ajax.ActionLink("查看", "ShowUnreadFile", "Files", new { fileId = gx.FileInfo.file_id }, new AjaxOptions { })%></td>
      </tr>
    <%}
      } %>
    </tbody>
    </table>
    </div>
    <%} %>
    <font style="color:#2D82BD">未阅读的站内信：</font>
    <%if (!znxcount)
      { %>
      无
    <%}
      else
      { %>
    <div>
    <table cellpadding="0" cellspacing="0" border="0" class="display">
    <thead>
    <tr>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">主题</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">内容</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">发件人</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">时间</th>
    <th class="sorting_desc" rowspan="1" colspan="1" style="width: 100px; ">阅读</th>
    </tr>
    </thead>
    <tbody>
    <%foreach(var znx in Model.ZnxMx){
      if (znx.Znxmx.znx_isread == "否")
      {%>
        <tr>
      <td class="sorting_1"><%=znx.Znxmx.znx_topic%></td>
      <td class="sorting_1"><%=znx.Znxmx.znx_nr%></td>
      <td class="sorting_1"><%=znx.SenderName%></td>
      <td class="sorting_1"><%=znx.Znxmx.znx_fssj%></td>
      <td class="sorting_1"><%=Ajax.ActionLink("知道了", "SetIsRead", "Znx", new { znxId = znx.Znxmx.znx_id }, new AjaxOptions { })%></td>
        </tr>
    
    <%}
      } %>
    </tbody>
    </table>
    </div>
    <%} %>

