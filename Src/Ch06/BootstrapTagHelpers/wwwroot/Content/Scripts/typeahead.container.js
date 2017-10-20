
///////////////////////////////////////////////////////////
// 
// WRAPPER for common operations on Twitter TypeAhead
//
//

// OPTIONAL LINKS 
//      handlebars-v4-0-2            

/// <reference path="~/Content/Scripts/jquery-1.10.2.min.js" />
/// <reference path="~/Content/Scripts/typeahead.bundle.min.js" />


var TypeAheadContainerSettings = function () {
    var that = {};
    that.postOnSelection = false;
    that.displayKey = 'value';
    that.hintUrl = '';
    that.targetSelector = '';
    that.buddySelector = '';
    that.submitSelector = '';
    that.showHint = true;
    that.maxNumberOfHints = 10;
    that.highlight = true;
    return that;
}

var TypeAheadContainer = function (options) {
    var settings = new TypeAheadContainerSettings();
    jQuery.extend(settings, options);

    // Set up the default Bloodhound hint adapter
    this.hintAdapter = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace(settings.displayKey),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        limit: settings.maxNumberOfHints,
        remote: settings.hintUrl
    });

    // Register handlers
    $(settings.targetSelector).on('typeahead:selected', function (e, datum) {
        $(settings.targetSelector).attr("data-itemselected", 1);
        $(settings.buddySelector).val(datum.id).trigger("change");;

        // Post on selection
        if (settings.postOnSelection) {
            $(settings.submitSelector).click();
        }
    });
    $(settings.targetSelector).on('blur', function () {
        var typeaheadItemSelected = $(settings.targetSelector).attr("data-itemselected");
        if (typeaheadItemSelected != 1) {
            $(settings.targetSelector).val("");
            $(settings.buddySelector).val("").trigger("change");;
        }
    });
    $(settings.targetSelector).on('input', function () {
        var typeaheadItemSelected = $(settings.targetSelector).attr("data-itemselected");
        if (typeaheadItemSelected == 1) {
            $(settings.targetSelector).attr("data-itemselected", 0);
            $(settings.buddySelector).val('').trigger("change");
            $(settings.targetSelector).val('');
        }
    });

    // Initializer
    this.attach = function() {
        this.hintAdapter.initialize();
        $(settings.targetSelector).typeahead(
            {
                hint: settings.showHint,
                highlight: settings.highlight,
                limit: settings.maxNumberOfHints
            },
            {
                displayKey: settings.displayKey,
                source: this.hintAdapter.ttAdapter()
            }
        );
    }
}