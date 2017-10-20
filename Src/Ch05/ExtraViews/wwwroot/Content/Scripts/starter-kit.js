var SK = SK || {};

SK.rootServer = "";

SK.goto = function (url) {
    var absoluteUrl = YK.rootServer + url;
    window.location.href = absoluteUrl;
}

SK.fromServer = function (url) {
    var absoluteUrl = YK.rootServer + url;
    return absoluteUrl;
}

SK.pad = function(num, size) {
    var s = num + "";
    while (s.length < size) {
        s = "0" + s;
    }
    return s;
}