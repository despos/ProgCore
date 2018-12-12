//////////////////////////////////////////////////////////////////
//
// YBQ FORMS
// General
//
$(".ybq-form").each(function() {
    var form = $(this);
    var title = form.data("title");
    var showTimer = form.data("timer") === true;
    var size = form.data("size");
    var msgId = form.attr("id") + "-state";
    var tmrId = form.attr("id") + "-timer";
    var successCallback = form.data("successcallback");
    var errorCallback = form.data("errorcallback");

    // Track the time editing started
    form.data("edit-started", new Date().getTime());

    // Arrange the form header
    var formTitleContainer = form.find(".ybq-form-header").first();
    formTitleContainer.append(title);

    // Arrange the form control bar
    var controlBar = form.find(".ybq-form-controlbar").first();
    controlBar.addClass("row m0 p0");
    var buffer = "<div class='col-9 m-0 p-0'>" +
        "<div class='d-flex align-items-center'>" +       
        "<div><button onclick='__undo(this)' type='button' class='btn btn-secondary undo'><i class='fa fa-undo'></i></button></div>" +
        "<div><span class='ybq-form-state' id='" +
        msgId +
        "'></span></div>" +       
        "</div></div>" +
        "<div class='col-3 text-right m-0 p-0'>" +
        "<div class='d-flex align-items-center justify-content-end'>" +
        "<div><span class='ybq-form-timer' id='" +
        tmrId +
        "'></span></div>" +
        "<div><button class='btn btn-primary ybq-form-submit'><i class='fa fa-save'></i></button></div>" +
        "</div></div>";
    controlBar.append(buffer);

    // Add onsubmit handler
    form.on("submit",
        function (e) {
            var valid = (form.find("input.is-invalid").length === 0);
            if (!valid) {
                return false;
            }
            var formData = new FormData(form);
            $.ajax({
                cache: false,
                url: form.attr("action"),
                type: form.attr("method"),
                dataType: "html",
                data: formData,
                processData: false,
                contentType: false,
                success: function (data) {
                    (__eval(successCallback))(data);
                },
                error: function (data) {
                    (__eval(errorCallback))(data);
                }
            });
            return false;
        });

    // Finalize initial setup
    __stateHasChanged(form, false);

    // Add data-attributes with original values
    form.find("input").each(function() {
        __preserveOriginalValue($(this));
        __attachValidationHandler($(this));
    });

    window.setInterval(function() {
            __stateHasChanged(form, false);
            if (showTimer) {
                __updateTimer(form);
            }
            form.find("input").each(function() {
                if (__isChanged($(this))) {
                    __stateHasChanged(form, true);
                    return false;
                }
                return true;
            });
        },
        1000);
});

// Internal functions
function __updateTimer(form) {
    var tmrId = form.attr("id") + "-timer";
    var start = parseInt(form.data("edit-started"));
    if (isNaN(start)) {
        $("#" + tmrId).html("");
        return;
    }
    var current = new Date().getTime();
    var spent = parseInt((current - start) / 1000 / 60);
    if (spent > 0)
        $("#" + tmrId).html(spent + " min");
    else 
        $("#" + tmrId).html("<1 min spent");
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
    return outcome;
}

function __stateHasChanged(form, state) {
    var msgId = form.attr("id") + "-state";
    var valid = (form.find("input.is-invalid").length === 0);
    
    if (state) {
        $("#" + msgId).html("CHANGED");
        $(".ybq-form-controlbar").addClass("bg-warning");
    } else {
        $("#" + msgId).html("NO CHANGES PENDING")
        $(".ybq-form-controlbar").removeClass("bg-warning");
    }
    if (state && valid) {
        form.find(".ybq-form-submit").removeAttr("disabled");
    } else {
        form.find(".ybq-form-submit").attr("disabled", "disabled");
    }
}

function __attachValidationHandler(input) {
    var rule = input.data("rule");

    if (typeof rule !== 'undefined' && rule.length > 0) {
        input.on("blur",
            function () {
                var current = __getCurrentValue($(this));
                var code = rule.replace("{val}", "'" + current + "'");
                var result = __eval(code);
                if (result)
                    $(this).removeClass("is-invalid");
                else
                    $(this).addClass("is-invalid");
            });
    }
}

function __eval(code) {
    return Function('"use strict";return (' + code + ')')();
}

function __undo(elem) {
    var form = $(elem).parents('form:first');
    form.find("input").each(function () {
        var orig = $(this).data("orig");
        $(this).val(orig);
        $(this).blur();
    });

    // Remove focus from the clicked button
    $(elem).blur();
}

//////////////////////////////////////////////////////////////////
//
// YBQ FORMS
// Number 
//
$("input[type=number]")
    .on("keypress",
        function (event) {
            if (event.charCode < 48 || event.charCode > 57) {
                event.preventDefault();
                return false;
            }
        })
    .on("keyup", function () {
        var buffer = $(this).val();
        var maxLength = parseInt($(this).attr("maxlength"));
        if (buffer.length > maxLength) {
            $(this).val("");
            return false;
        }
        var minVal = parseInt($(this).attr("min"));
        var maxVal = parseInt($(this).attr("max"));
        if (isNaN(minVal)) {
            minVal = 0;
        }
        if (isNaN(maxVal)) {
            maxVal = 1000000;
        }
        var number = parseInt(buffer);
        if (number < minVal || number > maxVal) {
            $(this).val("");
            return false;
        }
        return true;
    });

//////////////////////////////////////////////////////////////////
//
// YBQ FORMS
// Email 
//
$("input[type=email]").on("blur",
    function () {
        var email = $.trim($(this).val());
        var required = $(this).attr("required") != null;
        if (email.length === 0 && !required)
            return;

        // If email is required or non-blank content provided, use RE to check
        var re =
            /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        var pattern = $(this).attr("pattern");
        if (pattern != null) {
            re = new RegExp($(this).attr("pattern"));
        }
        var success = re.test(email);
        if (success)
            $(this).removeClass("is-invalid");
        else
            $(this).addClass("is-invalid");
    });

//////////////////////////////////////////////////////////////////
//
// YBQ FORMS
// URL 
//
$("input[type=url]").on("blur",
    function () {
        var url = $(this).val();
        var required = $(this).attr("required") != null;
        if (url.length === 0 && !required)
            return;

        // If URL is required or non-blank content provided, use RE to check
        var re =
            /((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)/;
        var pattern = $(this).attr("pattern");
        if (pattern != null) {
            re = new RegExp($(this).attr("pattern"));
        }

        var success = re.test(url);
        if (success)
            $(this).removeClass("is-invalid");
        else
            $(this).addClass("is-invalid");
    });

//////////////////////////////////////////////////////////////////
//
// YBQ FORMS
// Text - alphanumeric only 
//
$("input[type=text][data-alphanumeric]").on("keypress",
    function (event) {
        var re = /[a-zA-Z0-9-_]/;
        var code = event.charCode || event.keyCode;    
        var chr = String.fromCharCode(code);          
        var success = re.test(chr);
        if (success) {
            return true;
        } else {
            event.preventDefault();
            return false;
        }
    });


    //attr("onkeypress", "return /[a-zA-Z0-9-_]/.test(event.charCode)");

//////////////////////////////////////////////////////////////////
//
// YBQ FORMS
// Any input with focus - click specified button ID
//
$("input[data-click-on-enter]").each(function () {
    $(this).attr("onkeyup",
        "__clickOnEnter(event, '" + $(this).data("click-on-enter") + "')");
});

// Internal
function __clickOnEnter(event, selector) {
    if (event.keyCode === 13) {
        $(selector).click();
    }
}

//////////////////////////////////////////////////////////////////
//
// YBQ FORMS
// File
//
$(".ybq-inputfile").each(function () {
    // Hide the INPUT FILE
    var inputFile = $(this).find("input[type=file]").first();
    inputFile.hide();

    // Sets references to internal components
    var baseId = "#" + $(inputFile).attr("id");
    var isDefinedId = baseId + "-isdefined";
    var previewId = baseId + "-preview";
    var removerId = baseId + "-remover";
    var placeholderId = baseId + "-placeholder";
    var isAnyImageLinked = ($(isDefinedId).val() === "true");

    // Sets up the image placeholder  
    if (isAnyImageLinked) {
        $(placeholderId).hide();
    } else {
        $(placeholderId).show();
    }

    $(placeholderId).click(function () {
        inputFile.click();
    });

    // Sets up the image preview
    $(previewId).data("fileid", baseId);
    if (isAnyImageLinked)
        $(previewId).show();
    else
        $(previewId).hide();
    $(previewId).click(function () {
        inputFile.click();
    });

    // Sets up the remover
    if (isAnyImageLinked)
        $(removerId).show();
    else
        $(removerId).hide();
    $(removerId).click(function () {
        inputFile.val("");
        $(previewId).removeAttr("src").removeAttr("title");
        $(previewId).hide();
        $(placeholderId).show();
        $(this).hide();
        $(isDefinedId).val("false");
        return false;
    });

    // Display selected image
    inputFile.change(function (evt) {
        var files = evt.target.files;
        if (files && files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $(previewId).attr("src", e.target.result);
                $(previewId).show();
                $(placeholderId).hide();
                $(removerId).show();
                $(isDefinedId).val("true");
            };
            reader.readAsDataURL(files[0]);
        }
    });
    inputFile.click(function (ev) {
        return ev.stopPropagation();
    });
});

// Internal
Ybq.imgLoadError = function (img) {
    var placeholderId = $(img).data("fileid") + "-placeholder";
    $(img).hide();
    $(placeholderId).append("not found");
    $(placeholderId).show();
    var removerId = $(img).data("fileid") + "-remover";
    $(removerId).hide();
};

//////////////////////////////////////////////////////////////////
//
// YBQ FORMS
// Password 
//
$("input[type=password]").each(function() {
    $(this)
        .add(
            "<span class='input-group-btn'>" +
            "<button type='button' class='btn btn-primary btn-square' onclick='__togglePswdView(this)'>" +
            "<i class='fa fa-eye'></i></button></span>")
        .wrapAll("<div class='input-group' />");
}).on("blur",
    function() {
        var pswd = $.trim($(this).val());
        var minLength = parseInt($(this).attr("minlength"));
        var maxLength = parseInt($(this).attr("maxlength"));
        if (isNaN(minLength)) {
            minLength = 0;
        }
        if (isNaN(maxLength)) {
            maxLength = 100;
        }
        if (pswd.length < minLength || pswd.length > maxLength)
            $(this).addClass("is-invalid");
        else
            $(this).removeClass("is-invalid");
    });
function __togglePswdView(elem) {
    var pswd = $(elem).closest("div").find("input");
    var type = $(pswd).attr("type");
    if (type === "password")
        pswd.attr("type", "text");
    else
        pswd.attr("type", "password");
}

//////////////////////////////////////////////////////////////////
//
// YBQ FORMS
// Tel 
//
$("input[type=tel]").on("blur",
    function () {
        var tel = $(this).val();
        var required = $(this).attr("required") != null;
        if (tel.length === 0 && !required)
            return;

        var re = new RegExp($(this).attr("pattern"));
        var success = re.test(tel);
        if (success)
            $(this).removeClass("is-invalid");
        else
            $(this).addClass("is-invalid");
    });

//////////////////////////////////////////////////////////////////
//
// YBQ FORMS
// Text 
//
$("input[type=text]").on("blur",
    function () {
        var text = $(this).val();
        var re = /(?:)/;
        var pattern = $(this).attr("pattern");
        if (pattern != null) {
            re = new RegExp($(this).attr("pattern"));
        }

        var success = re.test(text);
        if (success)
            $(this).removeClass("is-invalid");
        else
            $(this).addClass("is-invalid");

    });