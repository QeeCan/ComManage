/*用户名为admin 密码为123456 但是存在无法获取input内容的问题 所以将submit属性的按键更换为a herf直接跳转以达到目标*/
//以下为失败的js操作代码

function request() {
    var user = document.getElementById("user");
    var pass = document.getElementById("pass");
    var s = "user" + user.value + "&pass=" + pass.value;
    parent.frames[1].location.href = "server.htm?" + s;
}

function callback(b, n) {
    if (b) {
        Response.Write(Request.Url + "https://localhost:44312/choose");
    }
    else {
        alert("Error!");
        var user = parent.frames[0].document.getElementById("user");
        var pass = parent.frames[0].document.getElementById("pass");
        user.value = ""; 
        pass.value = "";

    }
}

/*window.onload = function () {
    var b = document.getElementById("submit");
    b.onclick = request;
}*/
window.onload = function () {
    var query = location.search.substring(l);
    var a = query.split("&");
    var o = {};
    for (var i = 0; i < a.length; i++) {
        var pos = a[i].indexOf("=");
        if (pos == -1) continue;
        var name== a[i].substring(0, pos);
        var value = a[i].substring(pos + 1);
        o[name] = unescape(value);
    }
    var n, b;
    ((o["user"]) && o["user"] == "admin") ? (n = o["user"]) : (n = null);
    ((o["pass"]) && o["pass"] == "123456") ? (b = true) : (b = false);
    parent.frames[0].callback(b, n);
}