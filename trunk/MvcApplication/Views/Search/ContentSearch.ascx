<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<script type="text/javascript" src="../../Scripts/MicrosoftAjax.js"></script>
<script type="text/javascript" src="../../Scripts/MicrosoftMvcAjax.js"></script>

<div class="upload_content"><br />  
    <%using (Ajax.BeginForm("SearchResult", new { searchKind = "全文检索" }, new AjaxOptions { UpdateTargetId = "rst" }))
      { %>
       <span style="color:#2D82BD;font-weight:bold"> <%=Html.Label("请输入要检索的内容：")%></span><br/><br/>
        <%=Html.TextArea("Content", new { @class = "common_textarea" })%>
        <input type="submit" value="确定" class="upload_choosedoc" />
    <%} %>
<div id="rst"></div>
</div>

