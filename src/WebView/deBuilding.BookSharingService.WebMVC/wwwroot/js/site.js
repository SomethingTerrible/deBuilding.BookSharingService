$(document).ready(function () {
    $(".plus").click(function () {
        $(this).toggleClass("minus").siblings("ul").toggle();
    })

    $("input[type=checkbox]").click(function () {
        //alert($(this).attr("id"));
        //var sp = $(this).attr("id");
        //if (sp.substring(0, 4) === "c_bs" || sp.substring(0, 4) === "c_bf") {
        $(this).siblings("ul").find("input[type=checkbox]").prop('checked', $(this).prop('checked'));
        //}
    })

    $("input[type=checkbox]").change(function () {
        var sp = $(this).attr("id");
        if (sp.substring(0, 4) === "c_io") {
            var ff = $(this).parents("ul[id^=bf_l]").attr("id");
            if ($('#' + ff + ' > li input[type=checkbox]:checked').length == $('#' + ff + ' > li input[type=checkbox]').length) {
                $('#' + ff).siblings("input[type=checkbox]").prop('checked', true);
                check_fst_lvl(ff);
            }
            else {
                $('#' + ff).siblings("input[type=checkbox]").prop('checked', false);
                check_fst_lvl(ff);
            }
        }

        if (sp.substring(0, 4) === "c_bf") {
            var ss = $(this).parents("ul[id^=bs_l]").attr("id");
            if ($('#' + ss + ' > li input[type=checkbox]:checked').length == $('#' + ss + ' > li input[type=checkbox]').length) {
                $('#' + ss).siblings("input[type=checkbox]").prop('checked', true);
                check_fst_lvl(ss);
            }
            else {
                $('#' + ss).siblings("input[type=checkbox]").prop('checked', false);
                check_fst_lvl(ss);
            }
        }
    });

})

function check_fst_lvl(dd) {
    //var ss = $('#' + dd).parents("ul[id^=bs_l]").attr("id");
    var ss = $('#' + dd).parent().closest("ul").attr("id");
    if ($('#' + ss + ' > li input[type=checkbox]:checked').length == $('#' + ss + ' > li input[type=checkbox]').length) {
        //$('#' + ss).siblings("input[id^=c_bs]").prop('checked', true);
        $('#' + ss).siblings("input[type=checkbox]").prop('checked', true);
    }
    else {
        //$('#' + ss).siblings("input[id^=c_bs]").prop('checked', false);
        $('#' + ss).siblings("input[type=checkbox]").prop('checked', false);
    }

}

function pageLoad() {
    $(".plus").click(function () {
        $(this).toggleClass("minus").siblings("ul").toggle();
    })
}