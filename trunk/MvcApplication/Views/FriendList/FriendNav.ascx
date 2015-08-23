<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Models.FriendListModel>" %>
<link type="text/css" href="../../Content/checktree.css" rel="Stylesheet" />
<link type="text/css" href="../../Content/DargDrop.css" rel="Stylesheet" />
<script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
<script type="text/javascript" src="../../JavaScripts/jquery.checktree.js"></script>
<script type="text/javascript" src="../../JavaScripts/DragDrop.js"></script>
<script type="text/javascript" src="../../JavaScripts/FriendNav.js"></script>
<script type="text/javascript">
    function ExChgClsName(Obj, NameA, NameB) {
        var Obj = document.getElementById(Obj) ? document.getElementById(Obj) : Obj;
        Obj.className = Obj.className == NameA ? NameB : NameA;
    }
    function showMenu(iNo) {
        ExChgClsName("Menu_" + iNo, "MenuBox", "MenuBox2");
    }

    function ChangeGroupName(id) {
        $('#overlay').css("visibility", "visible");
        $('#ChangeGroup').css("visibility", "visible");
        $("form[action$='ChangeGroupName']").append("<input type='hidden' value=" + id + " name='groupId'/>");
        
    }
</script>
<div class="index_content_right_top">
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
            <span class="rightMenu_list">
                <span id="<%=group.group_id %>" class="DragTarget" onclick="ChangeGroupName('<%=group.group_id %>')">
                    <%=group.group_name%></span></span>
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
                            <%=friendInfo.YhInfo.user_name%></span><span class="friendBz" style=" color:Gray">(<%=friendInfo.FriendMx.hy_bz?? "无"%>)</span>
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
            <span class="rightMenu_list">
            <%if (Model.IsAdmin)
              { %>
                <span id="0">
                    默认组</span><%}
              else
              { %>
                <span id="0" class="DragTarget">
                    默认组</span>
                    <%} %>
            </span>
            <ul>
                <%foreach (var friendInfo in Model.FriendMx)
                  { %>
                <%if (friendInfo.GroupInfo.group_id == 0)
                  { %>
                <li>
                    <span class="rightMenu_list2">
                        <div class="arrow">
                        </div>
                        <div class="checkbox" style="display:none" onclick="zyhNodeClick('<%=friendInfo.YhInfo.user_name %>','<%=friendInfo.YhInfo.user_id %>',this)">
                        </div>
                        <input type="checkbox" name="geo" value="<%=friendInfo.YhInfo.user_name %>" style="display: none;" />
                        <img alt="用户头像" src="<%=friendInfo.YhInfo.user_avatar %>" style=" width:15px; height:15px;" />
                        <span class="DragTreeNode" id="<%=friendInfo.YhInfo.user_id %>">
                            <%=friendInfo.YhInfo.user_name%></span><span class="friendBz" style=" color:Gray">(<%=friendInfo.FriendMx.hy_bz?? "无"%>)</span>
                    </span>
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
            <span class="rightMenu_list">
                <span>
                    附属用户</span>
            </span>
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
                            <%=fsyh.fsyh_name%></span><span class="fsfriendBz" style=" color:Gray">(<%=fsyh.fsyh_bz??"无" %>)</span>
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
<div class="index_content_right_bottom">
    <div class="index_content_right_bottom_search">
        <img src="../../Images/search.png" width="12" height="12" ><span onclick="friendOper('findUsers')">查找</span>
    </div>
    <div class="index_content_right_bottom_user">
        <img src="../../Images/user.png" width="12" height="12" ><span onclick="friendOper('addFsyh')">附属用户</span>
    </div>
    <div class="index_content_right_bottom_group">
        <img src="../../Images/group.png" width="12" height="12" ><span onclick="friendOper('addGroup')">分组</span>
    </div>
</div>
</div>
<%} %>
