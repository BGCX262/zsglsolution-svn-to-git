<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Models.FriendListModel>" %>
<link type="text/css" href="../../Content/checktree.css" rel="Stylesheet" />
<link type="text/css" href="../../Content/DargDrop.css" rel="Stylesheet" />
<script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
<script type="text/javascript" src="../../JavaScripts/jquery.checktree.js"></script>
<script type="text/javascript" src="../../JavaScripts/DragDrop.js"></script>
<script type="text/javascript" src="../../JavaScripts/FriendNav.js"></script>

<div id="rightMenu"><p><%if (Model.IsAdmin)
                         { %>用户列表<%}
                         else
                         { %>好友列表<%} %></p>

    <ul class="tree" onselectstart="return false;">
    <%if (!Model.IsAdmin)
      { %>
        <%foreach (var group in Model.FriendGroups)
          { %>
        <li>
            <div class="arrow collapsed">
            </div>
            <div class="checkbox" style="display:none" onclick="zyhNodeClick('<%=group.group_name %>','<%=group.group_name %>',this)">
            </div>
            <input type="checkbox" style="display: none;" />
            <div class="rightMenu_list">
                <span id="<%=group.group_id %>" class="DragTarget">
                    <%=group.group_name%></span>
            </div>
            <ul>
                <%foreach (var friendInfo in Model.FriendMx)
                  { %>
                <%if (friendInfo.GroupInfo.group_id == group.group_id)
                  { %>
                <li>
                    <div class="rightMenu_list2">
                        <div class="arrow">
                        </div>
                        <div class="checkbox" style="display:none" onclick="zyhNodeClick('<%=friendInfo.YhInfo.user_name %>','<%=friendInfo.YhInfo.user_id %>',this)">
                        </div>
                        <input type="checkbox" name="geo" value="<%=friendInfo.YhInfo.user_name %>" style="display: none;" />
                        <img alt="用户头像" src="<%=friendInfo.YhInfo.user_avatar %>" style=" width:15px; height:15px;" />
                        <span class="DragTreeNode" id="<%=friendInfo.YhInfo.user_id %>">
                            <%=friendInfo.YhInfo.user_name%></span><span class="friendBz">(<%=friendInfo.FriendMx.hy_bz?? "无"%>)</span>
                    </div>
                </li>
                <%} %>
                <%} %>
            </ul>
        </li>
        <%} %>
        <%} %>
        <li>
            <div class="arrow collapsed">
            </div>
            <div class="checkbox" style="display:none" onclick="zyhNodeClick('默认组','默认组',this)">
            </div>
            <input type="checkbox" style="display: none;" />
            <div class="rightMenu_list">
            <%if (Model.IsAdmin)
              { %>
                <span id="0">
                    默认组</span><%}
              else
              { %>
                <span id="0" class="DragTarget">
                    默认组</span>
                    <%} %>
            </div>
            <ul>
                <%foreach (var friendInfo in Model.FriendMx)
                  { %>
                <%if (friendInfo.GroupInfo.group_id == 0)
                  { %>
                <li>
                    <div class="rightMenu_list2">
                        <div class="arrow">
                        </div>
                        <div class="checkbox" style="display:none" onclick="zyhNodeClick('<%=friendInfo.YhInfo.user_name %>','<%=friendInfo.YhInfo.user_id %>',this)">
                        </div>
                        <input type="checkbox" name="geo" value="<%=friendInfo.YhInfo.user_name %>" style="display: none;" />
                        <img alt="用户头像" src="<%=friendInfo.YhInfo.user_avatar %>" style=" width:15px; height:15px;" />
                        <span class="DragTreeNode" id="<%=friendInfo.YhInfo.user_id %>">
                            <%=friendInfo.YhInfo.user_name%></span><span class="friendBz">(<%=friendInfo.FriendMx.hy_bz?? "无"%>)</span>
                    </div>
                </li>
                <%} %>
                <%} %>
            </ul>
        </li>
        <%if (!Model.IsAdmin)
          { %>
        <li>
            <div class="arrow collapsed">
            </div>
            <div class="checkbox" style="display:none" onclick="fsyhNodeClick('附属用户','附属用户',this)">
            </div>
            <input type="checkbox" style="display: none;" />
            <div class="rightMenu_list">
                <span>
                    附属用户</span>
            </div>
            <ul>
                <%foreach (var fsyh in Model.FsyhMx)
                  {%>
                <li>
                    <div class="rightMenu_list2">
                        <div class="arrow">
                        </div>
                        <div class="checkbox" style="display:none" onclick="fsyhNodeClick('<%=fsyh.fsyh_name%>','<%=fsyh.fsyh_id %>',this)">
                        </div>
                        <input type="checkbox" name="geo" value="<%=fsyh.fsyh_name %>" style="display: none;" />
                        <span id="<%=fsyh.fsyh_id %>">
                            <%=fsyh.fsyh_name%></span><span class="fsfriendBz">(<%=fsyh.fsyh_bz??"无" %>)</span>
                    </div>
                </li>
                <%}%>
            </ul>
        </li>
        <%} %>
    </ul>
</div>
<%if (!Model.IsAdmin)
  { %>
<div id="findAndAddNew">
        <a onclick="friendOper('findUsers')" style="border-right-style:double; padding-right:3px;">查找</a> 
        <a onclick="friendOper('addFsyh')" style="border-right-style:double; padding-right:3px;">附属用户</a>
        <a onclick="friendOper('addGroup')" >分组</a>
</div>
<%} %>
