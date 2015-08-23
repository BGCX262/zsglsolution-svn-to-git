<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication.Models.UserModel>" %>
<link href="../../uploadify/uploadify.css" rel="Stylesheet" type="text/css" />
<script src="../../uploadify/jquery-1.4.2.min.js" type="text/javascript"></script>
<script src="../../uploadify/swfobject.js" type="text/javascript"></script>
<script src="../../uploadify/jquery.uploadify.v2.1.4.js" type="text/javascript"></script>
<style type="text/css">
.textstyle1
{
    color: Red;
    font-weight: bold;
}
.textstyle2
{
    color: Green;
    font-weight: bold;
}
</style>
<script type="text/javascript">
    $(function() {
        //上传
        $('#fileInput2').uploadify({
            'uploader': '../../uploadify/uploadify.swf',
            'script': '/Upload/UploadImage',
            'folder': '../../Avatar',
            'cancelImg': '../../uploadify/cancel.png',
            'multi': false,
            'onComplete': fun,
            'buttonText': '选择文件',
            'fileExt': '*.png;*.jpg;*.gif;'
        });
    });
    function upload() {
        $("#fileInput2").uploadifySettings('scriptData', { 'userId': $('#uid').val() });
        if (checkImport()) { $('#fileInput2').uploadifyUpload(); }
    }   
    function fun(event, queueID, fileObj, response, data) {
        var res = response.split('|');
        if (res[0] != "") {
            showInfo("成功上传" + res[0], res[1], true); //showInfo方法设置上传结果     
        }
        else {
            showInfo("文件上传出错！","", false);
        }
    }
    //显示提示信息，textstyle2为绿色，即正确信息；textstyl1为红色，即错误信息
    function showInfo(msg, path, type) {
        var msgClass = type == true ? "textstyle2" : "textstyle1";
        $("#result").removeClass();
        $("#result").addClass(msgClass);
        $("#result").html(msg);
        if (type == true)
            $("#Avatar").attr("src", path);
    }
    //如果点击‘导入文件’时选择文件为空，则提示
    function checkImport() {
        if ($.trim($('#fileInput2Queue').html()) == "") {
            alert('请先选择要导入的文件！');
            return false;
        } else {
            return true;
        }
    } 
</script>
<div>
    <p><input id="fileInput2" name="fileInput2" type="file"/></p>
    <p style="margin-top:5px;font-size:14px;font-weight:bold;">
    <p><%=Html.Hidden("uid", Model.UserInfo.user_id) %></p>
    <a href="#" onclick="upload()">上传</a></p>
    <p style="margin-top:5px;font-size:14px;font-weight:bold;"><span id="result"></span></p>
</div>