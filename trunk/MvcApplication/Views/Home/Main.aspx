<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CommonSite.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication.Models.UserModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<div id="welcome" class="content" style="display:block;">
<%Html.RenderAction("Welcome"); %>
</div>
<div id="c0" class="content"></div><%--上传文件--%>
<div id="c1" class="content"><%Html.RenderAction("SetGxPartial", "Gxgl"); %></div>    <%--设置共享--%>
<div id="c2" class="content"><%Html.RenderAction("ContentSearch", "Search"); %></div> <%--全文检索--%>
<div id="c3" class="content"><%Html.RenderAction("RemarkSearch", "Search"); %></div>  <%--备注检索--%>
<div id="c4" class="content"><%Html.RenderAction("Index", "Email"); %></div>          <%--发送邮件--%>
<div id="c5" class="content"><%Html.RenderAction("GxFiles_ToOthers", "Gxgl"); %></div><%--共享文件查看--%>
<div id="c6" class="content"><%Html.RenderAction("EmailsView", "Email"); %></div>
<div id="c7" class="content"><%Html.RenderAction("SendZnxView", "Znx"); %></div>
<div id="c8" class="content"><%Html.RenderAction("AllZnx", "Znx"); %></div>

<div id="c9" class="content"><%Html.RenderAction("FileList", "Files", new { floderName = "默认" }); %></div>
<div id="c<%=Model.UserFloders.Count+10 %>" class="content">
    <%Html.RenderAction("FileList", "Files", new { floderName = "共享" }); %>
</div>
<%for (int i = 0; i < Model.UserFloders.Count; i++)
  { %>
  <div id="c<%=10+i %>" class="content">
    <%Html.RenderAction("FileList", "Files", new { floderName = Model.UserFloders[i].floder_name }); %>
  </div>
<%} %>
<div id="c<%=11+Model.UserFloders.Count %>" class="content"><%Html.RenderAction("UserBaseInfo", "User"); %></div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <title>知识管理系统-主用户：<%=Model.UserInfo.user_name %></title>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ShowDialog" runat="server">
    <%--遮罩--%>
    <div id="overlay" class="simplemodal-overlay" 
    style="opacity: 0.5; height: 100%; width: 100%; position: fixed; left: 0px; top: 0px; 
    z-index: 1001; visibility:hidden;"></div>
    <div id="sending" class="back-G" style=" border:solid 1px; visibility:hidden; z-index:1002">
    <div class="tanchu">
    <div class="tanchu_content">
        <img src="../../Images/wait.gif" />邮件发送中……
    </div>
    </div>
    </div>
    <div id="uploading" class="back-G" style=" border:solid 1px; visibility:hidden; z-index:1002">
    <div class="tanchu">
    <div class="tanchu_content">
        <img src="../../Images/wait.gif" />文件上传中……
    </div>
    </div>
    </div>
    
    <%--好友组--%>
    <div id="FriendGroups" class="back-G" style=" visibility:hidden; z-index:1002">
        <div class="tanchu">
	    <div class="tanchu_cha"></div>
	    <div class="tanchu_content">
            <%if (Model.FriendGroups == null || Model.FriendGroups.Count == 0)
              { %>
              没有可以移动的组！
            <%}
              else
              { %>
               移动到：
              <%foreach (var group in Model.FriendGroups)
                { %>
                <div><a onclick="moveToNewGroup('<%=group.group_id %>')" href="#"><%=group.group_name %></a></div>
              <%} %>
            <%} %>
            </div>
        </div>
    </div>
    
    <%--文件列表--%>
    <div id="FileList" class="back-G" style=" visibility:hidden; z-index:1002">
        <div class="tanchu">
	    <div class="tanchu_cha" onclick="cancelNotRefresh('FileList')"></div>
	    <div class="tanchu_content">
	        <div style="height:150px;overflow:auto">
                <%foreach (var file in Model.Files)
                  { %>
                  <li><span style="float:left;margin-top:0px;margin-left:10px;width:350px;font-size:12px;color:#42B2E7"><%=file.file_name %></span><input type="hidden" value="<%=file.file_id %>" /><%=Html.CheckBox("fileCheck") %></li>
                <%} %>
            </div>
                <input type="button" value="确定" onclick="AddFilesTo()" />
            
        </div>
        </div>
    </div>
    
    <%--附件--%>
    <div id="EmailAttachment" class="back-G" style=" visibility:hidden; z-index: 1002;">
        <div class="tanchu">
	    <div class="tanchu_cha" onclick="cancelNotRefresh('EmailAttachment')"></div>
	    <div class="tanchu_content">
        <%foreach (var file in Model.Files)
          { %>
          <div class="shanchu"><div id="shanchu_word">
          <%=Ajax.ActionLink(file.file_name, "AddAccessories", "Email", new { filePath = file.file_path, fileName = file.file_name, fileID = file.file_id }, new AjaxOptions { })%>
          </div>
          </div>
        <%} %>
        </div>
        </div>
    </div>
    
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
    
    <%--文件夹列表--%>
    <div id="floderList" class="back-G" style="visibility:hidden; z-index:1002">
        <div class="tanchu">
	    <div class="tanchu_cha" onclick="cancelNotRefresh('floderList')"></div>
	    <div class="tanchu_content">
         <%if (Model.UserFloders == null)
           {%>
           <div>没有可移动到的文件夹</div>
         <%}
           else
           { %>
           <%foreach(var floder in Model.UserFloders){%>
            <a onclick="moveToNewFloder('<%=floder.floder_name %>','<%=floder.floder_higher %>')" href="#"><%=floder.floder_name %></a>
           <%} %>
         <%} %>
         </div>
         </div>
    </div>
    
    <%--添加文件夹--%>
    <div id="basic-modal-content" class="back-G" style="visibility:hidden; z-index: 1002;">
        <div class="tanchu">
	    <div class="tanchu_cha" onclick="cancelNotRefresh('basic-modal-content')"></div>
	    <div class="tanchu_content">
       <%using (Ajax.BeginForm("AddFloder","Floder", new AjaxOptions { }))
          { %>
          <p id="newFloderPassData">
          <%=Html.Label("文件夹名") %>
          <%=Html.TextBox("floderName") %>
          </p>
          <input type="submit" value="确定" />
        <%} %>
        </div>
        </div>
    </div>
    
    <%--查找好友--%>
    <div id="findUsers" class="back-G" style="visibility:hidden; z-index: 1002;">
        <div class="tanchu">
	    <div class="tanchu_cha" onclick="cancel('findUsers')"></div>
	    <div class="tanchu_content">
        <div>
            <%using (Ajax.BeginForm("FindUsers", "Yhgl", new AjaxOptions { UpdateTargetId = "rstUserL" }))
               { %>
               <%=Html.Label("用户名：") %>
               <%=Html.TextBox("username") %>
               <input type="submit" value="查找" />
            <%} %>
            <div id="rstUserL"></div>
        </div>
        </div>
        </div>
    </div>
    
    <%--添加附属用户--%>
    <div id="addFsyh" class="back-G" style="visibility:hidden; z-index: 1002;">
        <div class="tanchu">
	    <div class="tanchu_cha" onclick="cancel('addFsyh')"></div>
	    <div class="tanchu_content">
        <div>
            <%using (Ajax.BeginForm("AddNewFsyh","Yhgl", new AjaxOptions { }))
              { %>
              <%=Html.Label("附属用户名:") %>
              <%=Html.TextBox("fsyhName") %>
              <input type="submit" value="确定" />
            <%} %>
        </div>
        </div>
        </div>
    </div>
    
    <%--添加分组--%>
    <div id="addGroup" class="back-G" style="visibility:hidden; z-index: 1002;">
        <div class="tanchu">
	    <div class="tanchu_cha" onclick="cancel('addGroup')"></div>
	    <div class="tanchu_content">
        <div>
            <%using (Ajax.BeginForm("AddNewGroup", "Yhgl", new AjaxOptions { }))
              { %>
              <%=Html.Label("组名:") %>
              <%=Html.TextBox("groupName") %>
              <input type="submit" value="确定" />
            <%} %>
        </div>
        </div>
        </div>
    </div>
    
    <%--修改备注--%>
    <div id="changeBz" class="back-G" style="visibility:hidden; z-index:1002;">
        <div class="tanchu">
	    <div class="tanchu_cha" onclick="cancelNotRefresh('changeBz')"></div>
	    <div class="tanchu_content">
	    <%using (Ajax.BeginForm("ChangeBz", "Friend", new AjaxOptions { }))
       { %>
       <%=Html.Label("备注：") %>
       <%=Html.TextBox("bz") %><br />
       <input type="submit" value="确定" />
	    <%} %>
	    </div>
        </div>
    </div>
    <%--修改组名--%>
        <div id="ChangeGroup" class="back-G" style="visibility:hidden; z-index:1002;">
        <div class="tanchu">
	    <div class="tanchu_cha" onclick="cancelNotRefresh('ChangeGroup')"></div>
	    <div class="tanchu_content">
	    <%using (Ajax.BeginForm("ChangeGroupName", "Friend", new AjaxOptions { }))
       { %>
       <%=Html.Label("新分组名：") %>
       <%=Html.TextBox("name") %><br />
       <input type="submit" value="确定" />
	    <%} %>
	    </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="menuList" runat="server">
<div id="leftMenu">
    <ul>
        <li class="button">文件管理</li>
        <li class="dropdown">
            <ul>
                <li class="canClickLi">上传文件</li>
                <li class="canClickLi" style="*margin-top:-15px;">设置共享</li>
                <li class="canClickLi" style="*margin-top:-15px;">全文检索</li>
                <li class="canClickLi" style="*margin-top:-15px;">备注检索</li>
                <li class="canClickLi" style="*margin-top:-15px;">发送邮件</li>
                <li class="canClickLi" style="*margin-top:-15px;">共享文件查看</li>
                <li class="canClickLi" style="*margin-top:-15px;">邮件查看</li>
                <li class="canClickLi" style="*margin-top:-15px;">发送站内信</li>
                <li class="canClickLi" style="*margin-top:-15px;">站内信查看</li>
            </ul>
        </li>
        <li class="button">文件列表</li>
        <li class="dropdown">
            <ul>
            <li class="canClickLi" style="*margin-top:-5px;">默认文件夹</li>
                <%foreach (var floder in Model.UserFloders)
                  { %>
                  <%if (floder.floder_higher == null || floder.floder_higher == "")
                    { %>
                    <li class="canClickLi" style="*margin-top:-5px;"><%=floder.floder_name%> ></li>
                    <li class="dropdown" style="margin-left:30px;">
                        <ul>
                            <%foreach (var floderLower in Model.UserFloders)
                              { %>
                              <%if (floderLower.floder_higher == floder.floder_name)
                                { %>
                                <li class="canClickLi" style="*margin-top:-5px;"><%=floderLower.floder_name%></li>
                              <%} %>
                            <%} %>
                        </ul>
                    </li>
                    <%} %>
                <%} %>
             <li class="canClickLi" style="*margin-top:-5px;">共享文件夹</li>
            </ul>
        </li>
        <li class="button">用户管理</li>
        <li class="dropdown">
            <ul>
            <li class="canClickLi" style="*margin-top:0px;">用户信息</li>
            </ul>
        </li>
    </ul>
</div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="FriendMenu" runat="server">
<%Html.RenderAction("FriendNav", "FriendList"); %>
</asp:Content>
