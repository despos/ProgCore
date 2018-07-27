// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

Blazor.registerFunction("Ybq.Helpers.Alert",
    function(message) {
        return alert(message);
    });


Blazor.registerFunction("Ybq.Helpers.UxDebug",
    function () {
        $(document).ready(function () {
            uxDebugInit();
        });
    });
