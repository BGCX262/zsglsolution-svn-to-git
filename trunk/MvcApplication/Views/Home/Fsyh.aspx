<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CommonSite.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication.Models.FsyhModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<%Html.RenderAction("FsyhFileList", "Files", new { fsyhId =Model.FsyhInfo.fsyh_id}); %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<title>附属用户</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ShowDialog" runat="server">
    <%--遮罩--%>
    <div id="overlay" class="simplemodal-overlay" 
    style="opacity: 0.5; height: 589px; width: 1366px; position: fixed; left: 0px; top: 0px; 
    z-index: 1001; visibility:hidden;"></div>
    <%--显示文件--%>
    <div id="fileShows" class="back-GB" style=" visibility:hidden;z-index: 1002;">
        <div class="tanchuB">
        <div class="tanchu_topB">
	    <div class="tanchu_cha" onclick="cancelNotRefresh('fileShows')"></div>
	    </div>
	    <div id="fileShow" class="tanchu_contentB">
	    </div>
	    </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="menuList" runat="server">
<div id="leftMenu">
<ul>
    <li class="button">文件列表</li>
    <li class="dropdown">
        <ul>
        <li class="canClickLi">共享文件夹</li>
        </ul>
    </li>
</ul>
</div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="FriendMenu" runat="server">
</asp:Content>
