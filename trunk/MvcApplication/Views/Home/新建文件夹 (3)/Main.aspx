<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MvcApplication.Models.UserModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>知识管理系统-个人首页</title>
    <link href="../../Content/index.css" type="text/css" rel="Stylesheet" />
    <link href="../../Content/menu.css" type="text/css" rel="Stylesheet" />
    <link type="text/css" href="../../Content/Main.css" rel="Stylesheet" />
    <link type="text/css" href="../../DataTables/css/demo_page.css" rel="Stylesheet" />
    <link type="text/css" href="../../DataTables/css/demo_table.css" rel="Stylesheet" />
    <script type="text/javascript" src="../../Scripts/menu.js"></script>
    <script type="text/javascript" src="../../DataTables/js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="../../JavaScripts/main.js"></script>
    <script type="text/javascript" src="../../Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="../../Scripts/MicrosoftMvcAjax.js"></script>
    <script type="text/javascript" src="../../Scripts/MicrosoftMvcValidation.js"></script>
</head>
<body>
    <%--遮罩--%>
    <div id="overlay" class="simplemodal-overlay" 
    style="opacity: 0.5; height: 589px; width: 1366px; position: fixed; left: 0px; top: 0px; 
    z-index: 1001; visibility:hidden;"></div>
    <div id="sending" class="back-G" style=" border:solid 1px; visibility:hidden; z-index:1002">
    <div class="tanchu">
    <div class="tanchu_content">
        <img src="../../Images/wait.gif" alt="发送中" />邮件发送中……
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
            <%foreach (var file in Model.Files)
              { %>
              <p><span><%=file.file_name %></span><input type="hidden" value="<%=file.file_id %>" /><%=Html.CheckBox("fileCheck") %></p>
            <%} %>
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
    <center>
        <div class="index_main">
            <div class="index_banner">
            </div>
            <div class="index_content">
                <div class="index_content_left">
                    <div id="menu" class="js-active">
                    <div id="leftMenu">
                    <ul>
                        <li class="button">文件管理</li>
                        <li class="dropdown">
                            <ul>
                                <li class="canClickLi">上传文件</li>
                                <li class="canClickLi">设置共享</li>
                                <li class="canClickLi">全文检索</li>
                                <li class="canClickLi">备注检索</li>
                                <li class="canClickLi">发送邮件</li>
                                <li class="canClickLi">共享文件查看</li>
                                <li class="canClickLi">邮件查看</li>
                                <li class="canClickLi">发送站内信</li>
                                <li class="canClickLi">站内信查看</li>
                            </ul>
                        </li>
                        <li class="button">文件列表</li>
                        <li class="dropdown">
                            <ul>
                            <li class="canClickLi">默认文件夹</li>
                                <%foreach (var floder in Model.UserFloders)
                                  { %>
                                  <%if (floder.floder_higher == null || floder.floder_higher == "")
                                    { %>
                                    <li class="canClickLi"><%=floder.floder_name%></li>
                                    <li class="dropdown">
                                        <ul>
                                            <%foreach (var floderLower in Model.UserFloders)
                                              { %>
                                              <%if (floderLower.floder_higher == floder.floder_name)
                                                { %>
                                                <li class="canClickLi"><%=floderLower.floder_name%></li>
                                              <%} %>
                                            <%} %>
                                        </ul>
                                    </li>
                                    <%} %>
                                <%} %>
                             <li class="canClickLi">共享文件夹</li>
                            </ul>
                        </li>
                        <li class="button">用户管理</li>
                        <li class="dropdown">
                            <ul>
                            <li class="canClickLi">用户信息</li>
                            </ul>
                        </li>
                    </ul>
                    </div>        
                    </div>
                    <div id="copyright" style="display: none">
                        Copyright © 2011 <a href="http://apycom.com/">Apycom jQuery Menus</a>
                    </div>
                </div>
                <div class="index_content_content">
                <%Html.RenderAction("Welcome"); %>
                </div>
                <div class="index_content_right" align="left">
                
                <%Html.RenderAction("FriendNav", "FriendList"); %>
                    
                </div>
            </div>
        </div>
    </center>
</body>
</html>
