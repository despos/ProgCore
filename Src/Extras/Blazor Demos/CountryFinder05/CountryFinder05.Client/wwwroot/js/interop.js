// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

//Blazor.registerFunction("Ybq.Helpers.Alert",
//    function(message) {
//        return alert(message);
//    });


//Blazor.registerFunction("Ybq.Helpers.UxDebug",
//    function () {
//        $(document).ready(function () {
//            uxDebugInit();
//        });
//    });

$(document).on("selection-made",
    function () {
        alert("Minkia");
        $("").trigger("change");
    });

window.Ybq = {
    alert: function(message) {
        return alert(message);
    },
    uxDebug: function() {
        $(document).ready(function() {
            uxDebugInit();
        });
    },
    typeAhead: function (inputSelector, buddySelector, url, hints = 10) {
        $(document).ready(function() {
            new TypeAheadContainer({
                targetSelector: $(inputSelector),
                buddySelector: $(buddySelector),
                maxNumberOfHints: hints,
                hintUrl: url + "?filter=%QUERY"
            }).attach();
        });
    },
    val: function(selector) {
        alert($(selector).val());
    }
};
