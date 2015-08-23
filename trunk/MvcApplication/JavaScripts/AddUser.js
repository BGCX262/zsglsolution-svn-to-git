$(function() {
    $('#uplodaAvatar').load("/Upload/UploadAvatar");
    $('#username').attr("value", getCookie("username"));
    $('#psw').attr("value", getCookie("psw"));
    $('#pswAgain').attr("value", getCookie("pswAgain"));
    $('#email').attr("value", getCookie("email"));
    $('#bm').attr("value", getCookie("bm"));
    $('#mobile').attr("value", getCookie("mobile"));
    $('#tel').attr("value", getCookie("tel"));
    $('#fax').attr("value", getCookie("fax"));
    clearCookie("username");
    clearCookie("psw");
    clearCookie("pswAgain");
    clearCookie("email");
    clearCookie("bm");
    clearCookie("mobile");
    clearCookie("tel");
    clearCookie("fax");
});

function UploadAvatar() {
    $('#uplodaAvatar').slideToggle('slow');
}

var canSubmit = true;

//验证用户名是否已经被注册
function ValidationData() {
    if ($('#username').val() == "") {
        $('#valRst').text("用户名不能为空。");
        canSubmit = false;
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Register/ValidationData",
            data: "userName=" + $('#username').val(),
            success: function(msg) {
                if (msg == "true") {
                    canSubmit = true;
                    $('#valRst').text("该用户名可以使用。");
                }
                else {
                    canSubmit = false;
                    $('#valRst').text("已存在该用户名。");
                }
            }
        });
    }
}

//验证两次密码输入是否一致
function CheckPsw() {
    var pswAgain = $('#pswAgain').val();
    var psw = $('#psw').val();
    if (psw == "") {
        canSubmit = false;
        $('#pswRst').text("密码不能为空。");
    }
    else {
        if (psw == pswAgain) {
            canSubmit = true;
            $('#pswRst').text("两次输入一致。");
        }
        else {
            canSubmit = false;
            $('#pswRst').text("两次输入不一致！");
        }
    }
}

//验证邮箱格式是否正确
function CheckEmail() {
    var temp = $('#email').val();
    if (temp == "") {
        canSubmit = false;
        $('#emailRst').text("邮箱不能为空。");
    }
    else {
        var myreg = /^[0-9a-zA-Z]+([._\-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+\.[0-9a-zA-Z]+$/;
        if (!myreg.test(temp)) {
            canSubmit = false;
            $('#emailRst').text("邮箱格式不正确。");
        } else {
            canSubmit = true;
            $('#emailRst').text("邮箱格式正确。");
        }
    }
    ValidationBefore();
}

//在提交前最后验证
function ValidationBefore() {
    if (canSubmit != true) {
        $('#beforeRst').text("数据没有填写正确或完整不能注册，请仔细检查。");
        $('#submitForm').attr("disabled", "disabled");
        return false;
    }
    else {
        $('#beforeRst').text("数据填写正确,可以注册。");
        $('#submitForm').removeAttr("disabled");
    }
}
var s;
function ChangeCaptha() {
    document.cookie = "username" + "=" + escape($('#username').val());
    document.cookie = "psw" + "=" + escape($('#psw').val());
    document.cookie = "pswAgain" + "=" + escape($('#pswAgain').val());
    document.cookie = "email" + "=" + escape($('#email').val());
    document.cookie = "bm" + "=" + escape($('#bm').val());
    document.cookie = "mobile" + "=" + escape($('#mobile').val());
    document.cookie = "tel" + "=" + escape($('#tel').val());
    document.cookie = "fax" + "=" + escape($('#fax').val());
    window.location.reload();
}

function getCookie(name) {
    var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));

    if (arr != null) {
        return unescape(arr[2]);
    }
    return null;
}

function clearCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    if (cval != null) document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
}