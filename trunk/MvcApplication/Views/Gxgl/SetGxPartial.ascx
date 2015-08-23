<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<link type="text/css" href="../../Content/GxNode.css" rel="Stylesheet" />
<script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
<script type="text/javascript" src="../../Scripts/MicrosoftAjax.js"></script>
<script type="text/javascript" src="../../Scripts/MicrosoftMvcAjax.js"></script>
<script type="text/javascript">
</script>
<div class="upload_content">
<%using (Ajax.BeginForm("SetGx", new AjaxOptions { }))
  { %>
    <fieldset style="width:500px;height:100px;border:solid 1px #42B2E7">
        <legend style="color:#2D82BD">文件</legend>
        <p><a onclick="AddFileForGx()" href="#" style="text-decoration:none;color:#2D82BD;font-weight:bold">添加文件</a></p>
        <div id="gxFiles"></div>
    </fieldset>
    <fieldset style="width:500px;margin-top:20px;height:100px;border:solid 1px #42B2E7">
        <legend style="color:#2D82BD">用户</legend>
        <div id="gxUsers"></div>
    </fieldset>
    <fieldset style="width:500px;margin-top:20px;height:100px;border:solid 1px #42B2E7">
        <legend style="color:#2D82BD">附属用户</legend>
        <div id="gxFsyh"></div>
    </fieldset>
    <input type="submit" value="确定" class="upload_choosedoc"/>
<%} %>
</div>

