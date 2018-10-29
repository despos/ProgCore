// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.Ybq = {
    alert: function(message) {
        alert(message);
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
                //buddySelector: $(buddySelector),
                maxNumberOfHints: hints,
                hintUrl: url + "?filter=%QUERY"
            }).attach();
        });
    },
    val: function(selector) {
        return $(selector).val().toString();
    },
    ta: function() {
        $("input .blazor-typeahead").on("input",
            function () {
                $(this).change();
                alert($(this).val());
            });
    },
    datePicker: function (selector) {
        $(document).ready(function () {
            $(selector).datepicker();
        });
    }
};
