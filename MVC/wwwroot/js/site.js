$(".NumberValid").on("input", function () {
    var e = '۰'.charCodeAt(0);
    this.value = this.value.replace(/[۰-۹]/g, function (t) {
        return t.charCodeAt(0) - e;
    });
    // convert arabic indic digits [٠١٢٣٤٥٦٧٨٩]
    e = '٠'.charCodeAt(0);
    this.value = this.value.replace(/[٠-٩]/g, function (t) {
        return t.charCodeAt(0) - e;
    });
    this.value = this.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');
});
$(".valid-empty").on("blur", function () {
    var value_check = $(this).val();
    value_check = value_check.replace(/\s/g, '');
    if (value_check === null || value_check.length < 1) {
        $(this).removeClass("is-valid").addClass("is-invalid");
        $(this).next(".invalid-tooltip").text("فیلد نمی تواند خالی باشد.");
        return false;
    }
    $(this).removeClass("is-invalid").addClass("is-valid");
});
function checkItem(e) {
    var value_check = $(e).val();
    value_check = value_check.replace(/\s/g, '');
    if (value_check === null || value_check.length < 1) {
        $(e).removeClass("is-valid").addClass("is-invalid");
        $(e).next(".invalid-tooltip").text("فیلد نمی تواند خالی باشد.");
        return false;
    }
    $(e).removeClass("is-invalid").addClass("is-valid");
}
function ThousandSeprator(id, event) {
    var element = document.getElementById(id);
    var input = element.value;
    element.value = numberWithCommas(input);
}
function numberWithCommas(x) {
    //return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    var val = x.replace(/,/g, '');
    var parts = val.toString().split(".");
    parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    return parts.join(".");
}

(function (window) {
    // Define Modiran class
    function Modiran() {
        // Define tooltip
        this.tooltip = function () {
            var tooltipTriggerList = [].slice.call(document.querySelectorAll("[rel='tooltip'], .has-tooltip"))
            var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
                return new bootstrap.Tooltip(tooltipTriggerEl)
            })
        };
        // Define popover
        this.popover = function () {
            var popoverTriggerList = [].slice.call(document.querySelectorAll("[data-toggle='popover'] .has-popover"))
            var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
                return new bootstrap.Popover(popoverTriggerEl)
            })
        };
        // Handle  switcheries
        this.handleSwitchery = function () {
            if (typeof Switchery != "undefined") {
                var size = "small",
                    color = "#999";
                new Switchery(fixHeaderSwitch,
                    {
                        size: size,
                        color: color
                    });
                fixHeaderSwitch.onchange = function () {
                    // Fix header setting
                    if (fixHeaderSwitch.checked) {
                        $("body").addClass("fix-header");
                        $("#main-navbar").addClass("navbar-fixed-top");
                    } else {
                        $("body").removeClass("fix-header");
                        $("#main-navbar").removeClass("navbar-fixed-top");
                    }

                    window.Modiran.updateSettingCodes();
                };

                new Switchery(toggleSidebarSwitch,
                    {
                        size: size,
                        color: color
                    });
                toggleSidebarSwitch.onchange = function () {
                    // Sidebar toggle setting
                    if (toggleSidebarSwitch.checked) {
                        window.Modiran.changeSidebarState("collapse");
                    } else {
                        window.Modiran.changeSidebarState("expand");
                    }
                };

                new Switchery(creativeSidebarSwitch,
                    {
                        size: size,
                        color: color
                    });
                creativeSidebarSwitch.onchange = function () {
                    // Sidebar creative switch
                    if (creativeSidebarSwitch.checked) {
                        if ($('body').hasClass("sidebar-extra")) {
                            $('body').removeClass("sidebar-extra");
                        }
                    } else {
                        if (!$('body').hasClass("sidebar-extra")) {
                            $('body').addClass("sidebar-extra");
                        }
                    }
                    window.Modiran.updateSettingCodes();
                };
            }
        };
        // Initilize sweet alert
        this.initiSwal = function () {
            if (typeof swal != "undefined") {
                swal.setDefaults({
                    confirmButtonText: 'تائید',
                    cancelButtonText: 'لغو'
                });
            }
        };
    }
    // Creates a Modiran object.
    window.Modiran = new Modiran();
})(window);

(function ($) {
    $(document).ready(function () {
        Modiran.tooltip();
        Modiran.popover();
        Modiran.handleSwitchery();
        Modiran.initiSwal();
    });

    // IE detector for jQuery, so we can use $.browser.msie
    jQuery.browser = {};
    (function () {
        jQuery.browser.msie = false;
        jQuery.browser.version = 0;
        if (navigator.userAgent.match(/MSIE ([0-9]+)\./)) {
            jQuery.browser.msie = true;
            jQuery.browser.version = RegExp.$1;
        }
    })();
})(jQuery);