// reference:   //wurfl.io/wurfl.js


function uxDebugInit() {
    __updateSize();
    __updateDevice();
    $(window).resize(function () {
        __updateSize();
    });
    $("#uxdebug-container").click(function () {
        $(window).resize(null);
        $(this).hide();
    });
}

function __currentBootstrapScreenClass() {
    var screen = "LG";
    var width = $(window).width();
    if (width <= 768)
        screen = "XS";
    else if (width <= 992)
        screen = "SM";
    else if (width <= 1200)
        screen = "MD";
    return screen;
}

function __updateSize() {
    var info = __currentBootstrapScreenClass();
    $('#uxdebug-wh').text($(window).width() + "px");
    $('#uxdebug-bspoint').text(info);
}

function __updateDevice() {
    var dev1 = "Unknown";
    var dev2 = "UA N/A";
    try {
        dev1 = WURFL.form_factor;
        dev2 = WURFL.complete_device_name;
    } catch (err) {

    }
    $('#uxdebug-formfactor').text(dev1);
    $('#uxdebug-device').html("<small>" + dev2 + "</small>");
}
 