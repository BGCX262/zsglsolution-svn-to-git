var isDrag;
var canRelease;
var targetId;
var targetText;
var dragId;
var dragText;
$(function() {
    $('.DragTarget').mouseover(function() {
        if (isDrag == true) {
            targetId = $.trim($(this).attr("id"));
            targetText = $.trim($(this).text());
            $('.DragElement img').attr("src", "../../Images/ok.gif");
            canRelease = true;
        }
    })
    .mouseout(function() {
        if (isDrag == true) {
            targetId = "";
            targetText = "";
            $('.DragElement img').attr("src", "../../Images/cannot.gif");
            canRelease = false;
        }
    });
    var dragTreeNode = $('.DragTreeNode');
    for (i = 0; i < dragTreeNode.length; i++) {
        //绑定拖动元素对象
        bindDrag(dragTreeNode[i]);
    }
});

//绑定
function bindDrag(el) {
    //初始化参数
    var els = el.style,
    //鼠标的 X 和 Y 轴坐标
    x = y = 0;
    $(el).mousedown(function(e) {
        isDrag = true;
        //按下元素后，计算当前鼠标位置
        x = e.clientX - el.scrollLeft;
        y = e.clientY - el.scrollTop;
        dragId = $.trim($(el).attr("id"));
        dragText = $.trim($(el).text());
        CreateElement(dragId, dragText, x, y);
        //绑定事件
        $(document).bind('mousemove', mouseMove).bind('mouseup', mouseUp);
    });
    function CreateElement(id, text, left, top) {
        if (id == "")
            dragId = id = text;
        $('body').append("<div id='" + id + "' class='DragElement'><img src='../../Images/cannot.gif' />" + text + "</div>");
        $('.DragElement').css("top", top + "px")
                      .css("left", left + "px");
    }
    //移动事件
    function mouseMove(e) {
        var scrollH = $(document).scrollTop();
        els.top = e.clientY + scrollH + 'px';
        els.left = e.clientX + 'px';
        $('.DragElement').css("top", els.top)
                        .css("left", els.left);
    }
    //停止事件
    function mouseUp() {
        isDrag = false;
        $(document).unbind('mousemove', mouseMove).unbind('mouseup', mouseUp);
        if (canRelease == true) {
            canRelease = false;
            release(targetId, targetText, dragId, dragText);
        }
        $('.DragElement').remove();
    }
}