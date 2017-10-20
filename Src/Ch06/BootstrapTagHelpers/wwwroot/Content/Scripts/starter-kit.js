var SK = SK || {};

SK.rootServer = "";

SK.goto = function (url) {
    var absoluteUrl = SK.rootServer + url;
    window.location.href = absoluteUrl;
}

SK.fromServer = function (url) {
    var absoluteUrl = SK.rootServer + url;
    return absoluteUrl;
}

SK.pad = function(num, size) {
    var s = num + "";
    while (s.length < size) {
        s = "0" + s;
    }
    return s;
}

/// <summary>
/// Cascading display when a bunch of controls are visible only if 
/// a particular value is selected in a SELECT element.
/// </summary>
SK.cascadingDisplay = function() {
    $("select[data-display-filter]").each(function () {
        SK.cascadingDisplayApply($(this));
    });
    $("select[data-display-filter]").on("change", function () {
        SK.cascadingDisplayApply($(this));
    });
};

/// <summary>
/// Supports cascading display 
/// </summary>
SK.cascadingDisplayApply = function (elem) {
    var filterName = elem.data("display-filter");
    var current = elem.val().toLowerCase();
    $("*[data-display-filter-buddy=" + filterName + "]").each(function() {
        var options = $(this).data("display-options").toLowerCase();
        if (options.match(new RegExp("(?:^|,)" + current + "(?:,|$)"))) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
};