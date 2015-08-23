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
        $('#fileInput1').uploadify({
            'uploader': '../../uploadify/uploadify.swf',
            'script': '/Upload/UploadAndSave',
            'folder': '../../UploadFiles',
            'cancelImg': '../../uploadify/cancel.png',
            'multi': false,
            'onComplete': fun,
            'buttonText': '选择文件',
            'fileExt': '*.png;*.jpg;*.gif;*.doc;*.docx;*.xls;*.xlsx;*.ppt;*.pptx'
        });
    });
    function upload() {
        $("#fileInput1").uploadifySettings('scriptData', { 'bz': $('#bz').val(), 'userId': $('#uid').val() });
        if (checkImport()) {
            $('#overlay').css("visibility", "visible");
            $('#uploading').css("visibility", "visible");
             $('#fileInput1').uploadifyUpload();
        }
    }   
    function fun(event, queueID, fileObj, response, data) {
        if (response != "") {
            showInfo("成功上传" + response, true); //showInfo方法设置上传结果     
        }
        else {
            showInfo("文件上传出错！", false);
        }
    }
    //显示提示信息，textstyle2为绿色，即正确信息；textstyl1为红色，即错误信息
    function showInfo(msg, type) {
        var msgClass = type == true ? "textstyle2" : "textstyle1";
        $("#result").removeClass();
        $("#result").addClass(msgClass);
        $("#result").html(msg);
        $('#overlay').css("visibility", "hidden");
        $('#uploading').css("visibility", "hidden");
    }
    //如果点击‘导入文件’时选择文件为空，则提示
    function checkImport() {
        if ($.trim($('#fileInput1Queue').html()) == "") {
            alert('请先选择要导入的文件！');
            return false;
        }
        return true;
    }
</script>

<div class="upload_content">
    <p><input id="fileInput1" name="fileInput1" type="file" class="upload_choosedoc"/></p>
    <div class="upload_textarea">备注：<br/><br/>
    <p><%=Html.TextArea("bz", new { @class = "common_textarea" })%></p>
    <p><%=Html.Hidden("uid", Model.UserInfo.user_id) %></p>
    </div>
    <p>
    <div onclick="upload()" class="upload_choosedoc">上传</div></p>
    <p><span id="result"></span></p>
</div> 

