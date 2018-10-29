
$(".ybq-form").each(function () {
    var form = $(this);
    var msgId = form.attr("id") + "-msg";
    var tmrId = form.attr("id") + "-tmr";
    var header = form.find(".ybq-form-header").first();
    header.append("<span id='" + msgId + "'></span>&nbsp;");
    header.append("<span id='" + tmrId + "'></span>");
    __stateHasChanged(form, false);

    // Add data-attributes with original values
    form.find("input").each(function () {
        __preserveOriginalValue($(this));
    });

    window.setInterval(function() {
            __stateHasChanged(form, false);
            __updateTimer(form);
            form.find("input").each(function() {
                if (__isChanged($(this))) {
                    __stateHasChanged(form, true);
                    return false;
                }
            });
        },
        1000);
});

function __updateTimer(form) {
    form.data("edit-started", new Date());
    console.log(form.data("edit-started"));
}

function __preserveOriginalValue(field) {
    field.data("orig", __getCurrentValue(field));
}

function __getCurrentValue(field) {
    if (field.prop("checked"))
        return true; 
    else
        return field.val();
}

function __isChanged(elem) {
    var outcome = __getCurrentValue(elem) != elem.data("orig");
    //if (outcome) {
    //    elem.css("font-weight", "700");
    //} else {
    //    elem.css("font-weight", "400");
    //}
    return outcome;
}

function __stateHasChanged(form, state) {
    //var messageBox = form.find(".ybq-form-messagebox").first();
    var msgId = form.attr("id") + "-msg";
    var tmrId = form.attr("id") + "-tmr";

    // Calculate the difference in milliseconds
    //var current = parseInt($("#" + tmrId).text());
    //if (isNaN(current))
    //    current = 0;
    //$("#" + tmrId).html(current + 1 + " seconds");

    if (state) {
        $("#" + msgId).html("CHANGED").parent().addClass("bg-warning");
        form.find(".ybq-form-submit").removeAttr("disabled");
    } else {
        $("#" + msgId).html("NO CHANGES PENDING").parent().removeClass("bg-warning");
        form.find(".ybq-form-submit").attr("disabled", "disabled");
    }
}

