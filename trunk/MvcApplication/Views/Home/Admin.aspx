<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CommonSite.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication.Models.UserModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<style>
body
{
	*margin-top:-590px;
}
</style>
<div id="welcome" class="content" style="display:block;">
    <div align="center">
        <p>&nbsp;</p>
        <p><strong>欢迎使用用户管理系统！</strong></p>
        <p>&nbsp;</p>
    </div>
</div> 
<div id="c0" class="content"><%Html.RenderAction("AddNewZyh", "Yhgl"); %></div>
<div id="c1" class="content"><%Html.RenderAction("DisableZyhView", "Yhgl"); %></div>
<div id="c2" class="content"><%Html.RenderAction("EnabledZyhView", "Yhgl"); %></div>
<div id="c3" class="content"><%Html.RenderAction("UsersView", "Yhgl"); %></div>
<div id="c4" class="content"><%Html.RenderAction("ChangePsw", "Yhgl"); %></div>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ShowDialog" runat="server">
    <%--遮罩--%>
    <div id="overlay" class="simplemodal-overlay" 
    style="opacity: 0.5; height: 589px; width: 1366px; position: fixed; left: 0px; top: 0px; 
    z-index: 1001; visibility:hidden;"></div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="menuList" runat="server">
<div id="leftMenu">
<ul>
    <li class="button">用户管理</li>
    <li class="dropdown">
        <ul>
            <li class="canClickLi">新增用户</li>
            <li class="canClickLi">禁用用户</li>
            <li class="canClickLi">启用用户</li>
            <li class="canClickLi">查看用户</li>
            <li class="canClickLi">设置密码</li>
        </ul>
    </li>
</ul>
</div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="FriendMenu" runat="server">
<%Html.RenderAction("FriendNav", "FriendList"); %>
</asp:Content>