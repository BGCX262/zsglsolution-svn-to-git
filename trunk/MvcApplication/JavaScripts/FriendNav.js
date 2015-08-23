$(function() {
    $("ul.tree").checkTree({
});

$('.friendBz').dblclick(function() {
    $('#overlay').css("visibility", "visible");
    $('#changeBz').css("visibility", "visible");
    $("form[action$='ChangeBz']>input#bz").attr("value", $(this).text());
    $("form[action$='ChangeBz']").append("<input type='hidden'  name='hiddenId' value='" + $(this).prev().attr("id") + "'/>");
    $("form[action$='ChangeBz']").append("<input type='hidden'  name='friendType' value='主用户'/>");
});

$('.fsfriendBz').dblclick(function() {
    $('#overlay').css("visibility", "visible");
    $('#changeBz').css("visibility", "visible");
    $("form[action$='ChangeBz']>input#bz").attr("value", $(this).text());
    $("form[action$='ChangeBz']").append("<input type='hidden'  name='hiddenId' value='" + $(this).prev().attr("id") + "'/>");
    $("form[action$='ChangeBz']").append("<input type='hidden'  name='friendType' value='附属用户'/>");
});
});

function release(targetId, targetText, dragId, dragText) {
    moveFriendToNewGroup(targetId, dragId);
}


function moveFriendToNewGroup(groupId, friendId) {
    if (groupId == "")
        groupId = 0;
    $.ajax({
        type: "POST",
        url: "/Friend/MoveFriend",
        data: "groupId=" + groupId + "&friendId=" + friendId
    });
}

function zyhNodeClick(name, id, obj) {
    var childNode = $(obj).next().next().next().find("li");
    if (childNode.length > 0) {
        if ($(obj).attr("class") == "checkbox") {
            for (i = 0; i < childNode.length; i++) {
                var zyhName = $(childNode[i]).find("span:first").text();
                var zyhId = $(childNode[i]).find("span:first").attr("id");
                $("#gxUsers").append("<div id='" + zyhId + "' class='shanchu'><div id='shanchu_word'><div>"
                + zyhName + "<div></div><input type='hidden' name='usersGx' value='" + zyhId + "'/></div>");
            }
        } else {
            for (i = 0; i < childNode.length; i++) {
                var fsyhId = $(childNode[i]).find("span").attr("id");
                removeSelect(fsyhId, "gxUsers");
            }
        }
    } else {
        if ($(obj).attr("class") == "checkbox") {
            $("#gxUsers").append("<div id='" + id + "' class='shanchu'><div id='shanchu_word'><div>"
                + name + "</div></div><input type='hidden' name='usersGx' value='" + id + "'/></div>");
        } else {
            removeSelect(id, "gxUsers");
        }
    }

}

function fsyhNodeClick(name, id, obj) {
    var childNode = $(obj).next().next().next().find("li");
    if (childNode.length > 0) {
        if ($(obj).attr("class") == "checkbox") {
            for (i = 0; i < childNode.length; i++) {
                var fsyhName = $(childNode[i]).find("span:first").text();
                var fsyhId = $(childNode[i]).find("span:first").attr("id");
                $("#gxFsyh").append("<div id='" + fsyhId + "' class='shanchu'><div id='shanchu_word'><div>"
                + fsyhName + "</div></div><input type='hidden' name='fsyhsGx' value='" + fsyhId + "'/></div>");
            }
        } else {
            for (i = 0; i < childNode.length; i++) {
                var fsyhId = $(childNode[i]).find("span").attr("id");
                removeSelect(fsyhId, "gxFsyh");
            }
        }
    } else {
        if ($(obj).attr("class") == "checkbox") {
            $("#gxFsyh").append("<div id='" + id + "' class='shanchu'><div id='shanchu_word'><div>"
                + name + "</div></div><input type='hidden' name='fsyhsGx' value='" + id + "'/></div>");
        } else {
            removeSelect(id, "gxFsyh");
        }
    }
}

function CheckClick(obj)
{
 alert(123);   
}