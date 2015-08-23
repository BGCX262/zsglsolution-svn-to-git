var menu;
var tags;
var ck;
var cj;
var j;
var isGx = false;
var clickCount = 0;
var clickCountU = 0;
$(function() {
    $('#leftMenu ul>li').click(function() {
        var dropDown = $(this).next();
        if ($(dropDown).attr("class") == "dropdown")
            dropDown.slideToggle('slow');
    }
  );
    menu = $('#topTags').children();
    tags = menu.children();
    ck = $('.canClickLi');
    for (i = 0; i < ck.length; i++) {
        if ($(ck[i]).attr("class") == "fileList" || $(ck[i]).attr("class") != "canClickLi") continue;
        ck[i].onclick = function() {
            $('#welcome').css("display", "none");
            //循环取得当前索引
            for (j = 0; j < ck.length; j++) {
                if (this == ck[j]) {
                    //                    alert(j);
                    if ($.trim(this.innerHTML) == "设置共享")
                        changeFriendCheckBox(true);
                    else
                        changeFriendCheckBox(false);
                    openNew(j, this.innerHTML); //设置标签显示文字
                }
            }
            return false;
        }
    }

    var menuId = getMenu("Menu");
    refreshToOpen(menuId);
    clearCookie("Menu");
});

function beforeOpenNew(id, name) {
    $('#OperList').css("visibility", "hidden");
    clickCount = 0;
    if ($("#p" + id).html() == null) {
        openNewFileShow(id, name); //设置标签显示文字
    }
    clearStyle();
    $("#p" + id).css("background", "url(../../Images/tabbg1.gif)");
    clearContent_ShowFile();
    $("#" + id).css("display", "block");
}

function refreshToOpen(id) {
    if (id != null) {
        clearStyle();
        clearContent();
        $('#' + id).css("display", "block");
    }
}

function openNew(id, name) {
    if ($.trim(name) == "上传文件") {
        $('#c' + id).load("/Upload/UploadPartial");
    }
    clearStyle();
    clearContent();
    $("#c" + id).css("display", "block");
}

function changeFriendCheckBox(target) {
    if (target == true) {
        $('.checkbox').css("display", "block");
    } else {
        $('.checkbox').css("display", "none");
    }
}
//清除标签样式
function clearStyle() {
    for (i = 0; i < tags.length; i++) {
        tags[i].css("background" , "url(../../Images/tabbg2.gif)");
    }
}
//清除内容
function clearContent() {
    for (i = 0; i < 5; i++) {
        $("#c" + i).css("display","none");
    }
    clearContent_ShowFile();
}

//清楚文件显示内容
function clearContent_ShowFile() {
    var contents = $('div.content');
    for (i = 0; i < contents.length; i++) {
        contents[i].style.display = "none";
    }
}

function moveTo(fileName, fileID) {
    $('#overlay').css("visibility", "visible");
    $('#floderList p').remove();
    $('#floderList').css("visibility", "visible");
    $('#floderList>div>div.tanchu_content').prepend("<p id=" + fileID + ">移动<span style='color:Red'>《" + fileName + "》</span>到：</p>");
}

function saveAllMenu() {
    var target = $(".content");
    for (i = 0; i < target.length; i++) {
        if ($(target[i]).css("display") == "block") {
            var aimMenu = target[i];
            var menuId = $(aimMenu).attr("id");
            document.cookie = "Menu=" + escape(menuId);
        }
    }
}

function getMenu(name) {
    var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
    if (arr != null) {
        return unescape(arr[2]);
    }
    return null;
}

function clearCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getMenu(name);
    if (cval != null) document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
}

function checkInt(val) {
    var pattern = /^[1-9]\d*|0$/; //匹配非负整数
    if (!pattern.test(val)) {
        return false;
    } else {
        return true;
    }
}

function FileLiClick(id, name) {
    clickCount = 0;
    $('#OperList').css("visibility", "hidden");
    if (!isGx) {
        return false;
    }
    else {
        $('#gxFiles').append("<p>" + name + "</p>")
        .append("<input type='hidden' name='filesGx' value=" + id + "/>");
    }
}

function UserLiClick(id, name) {
    clickCount = 0;
    $('#OperList').css("visibility", "hidden");
    if (!isGx) {
        return false;
    }
    else {
        $('#gxUsers').append("<p>" + name + "</p>")
        .append("<input type='hidden' name='usersGx' value=" + id + "/>");
    }
}

function FsyhLiClick(id, name) {
    clickCount = 0;
    $('#OperList').css("visibility", "hidden");
    if (!isGx) {
        return false;
    }
    else {
        $('#gxFsyh').append("<p>" + name + "</p>")
        .append("<input type='hidden' name='fsyhsGx' value=" + id + "/>");
    }
}

//<<---------------------------------------------------------------------------------------------------
function addFolder(floderName) {
    $('#overlay').css("visibility", "visible");
    $('#basic-modal-content').css("visibility", "visible");
    $("#basic-modal-content p#newFloderPassData input[name='higherFloder']").remove();
    $('#basic-modal-content p#newFloderPassData')
            .append("<input type='hidden' name='higherFloder' value=" + floderName + " />");

    return false;
}
function refresh() {
    saveAllMenu();
    window.location.reload();
}
function cancel(id) {
    cancelNotRefresh(id);
    refresh();
}
function cancelNotRefresh(id) {
    $('#overlay').css("visibility", "hidden");
    $('#' + id).css("visibility", "hidden");
}
function moveToNewFloder(floderName, higherFloder) {
    var id = $('#floderList p').attr("id");
    $.ajax({
        type: "POST",
        url: "/Floder/MoveToFloder",
        data: "fileID=" + id + "&floderName=" + floderName + "&higherFloder=" + higherFloder
    });
}

function friendOper(id) {
    $('#overlay').css("visibility", "visible");
    $('#' + id).css("visibility", "visible");
}

function showFile(filePath) {
    $('#overlay').css("visibility", "visible");
    $('#fileShow').load("/ShowFile/ShowFilePartial?filePath=" + filePath);
    $('#fileShows').css("visibility", "visible");
}

function AddFileForGx() {
    $('#overlay').css("visibility", "visible");
    $('#FileList').css("visibility", "visible");
}

function AddFilesTo() {
    var fileCheck = $('input');
    for (var i = 0; i < fileCheck.length; i++) {
        if (fileCheck[i].type == "checkbox" && fileCheck[i].id.indexOf("fileCheck") != -1) {
            if (fileCheck[i].checked) {
                var isExist = false;
                var fileName = $(fileCheck[i]).prev().prev().text();
                var fileId = $(fileCheck[i]).prev().val();
                var checkedFiles = $('#gxFiles input');
                for (j = 0; j < checkedFiles.length; j++) {
                    if (checkedFiles[j].value == fileId) {
                        isExist = true;
                    }
                }
                if (isExist)
                    continue;
                else {
                    var a_Onclick = "removeSelect('" + fileId + "','gxFiles')";
                    isExist = false;
                    $('#gxFiles').append("<div id='" + fileId + "' class='shanchu'><div id='shanchu_word'><div>" + fileName + "</div></div><span onclick="+a_Onclick+"><div id='shanchu_cha'></div></span>" +
                                "<input type='hidden' name='filesGx' value='" + fileId + "'/></div>");
                }
            }
        }
    }
    $('#FileList').css("visibility", "hidden");
    $('#overlay').css("visibility", "hidden");
}

function removeSelect(id, type) {
    $('#' + type).find("#" + id).remove();
}

//>>---------------------------------------------------------------------------------------------------

//<<---------------------------------------------------------------------------------------------------
function moveFriend(name, id) {
    $('#FriendGroups p').remove();
    $('#FriendGroups').css("visibility", "visible")
                      .prepend("<p id=" + id + ">移动<span style='color:Red'>&nbsp;" + name + "&nbsp;</span>到：</p>");
}
function moveToNewGroup(groupId) {
    var id = $('#FriendGroups p').attr("id");
    $.ajax({
        type: "POST",
        url: "/Friend/MoveFriend",
        data: "groupId=" + groupId + "&friendId=" + id
    });
}
//>>--------------------------------------------------------------------------------------------------- 