/*document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.sidenav');
    var instances = M.Sidenav.init(elems, options);
});*/

$(document).ready(function () {
    $('.sidenav').sidenav();
    $('.tabs').tabs();
    $('.tooltipped').tooltip();
    $('.datepicker').datepicker();
    $('select').formSelect();
    $('.modal').modal();

    //if page is refreshed, do not change previous url
    if (String(localStorage.getItem("previousUrl")) !== String(window.location.href).replace(/^.*\/\/[^\/]+/, '')) {
        //get the current url, will be use for cancel, back buttons
        localStorage.setItem("savedPreviousUrl", String(localStorage.getItem("previousUrl")));
    }

    //get approval notification counts
    $.ajax({
        url: '/Approval/CountRequestAndApprovall',
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            //return data is like 5,2
            //request is 5, for approval is 2
            //split the return string
            var result = data.split(",");
            var requestCount = result[0];
            var approvalCount = result[1];
            //add the total
            var totalCount = parseInt(requestCount) + parseInt(approvalCount);
            totalCount = totalCount.toString();

            if (requestCount !== "0" && !isNaN(parseInt(requestCount))) {
                $(".requestCount").removeClass("hide");
                $(".requestCount").html(requestCount);
            }

            else if (requestCount === "0" || isNaN(parseInt(requestCount))) {
                $(".requestCount").remove();
            }

            if (approvalCount !== "0" && !isNaN(parseInt(approvalCount))) {
                $(".approvalCount").removeClass("hide");
                $(".approvalCount").html(approvalCount);
            }

            else if (approvalCount === "0" || isNaN(parseInt(approvalCount))) {
                $(".approvalCount").remove();
            }

            if (totalCount !== "0" && !isNaN(parseInt(totalCount))) {
                $(".totalCount").removeClass("hide");
                $(".totalCount").html(totalCount);
            }

            else if (totalCount === "0" || isNaN(parseInt(totalCount))) {
                $(".totalCount").remove();
            }
        },
        error: function (data) {

        }
    });

});

$(window).bind('beforeunload', function () {
    localStorage.setItem("previousUrl", String(window.location.href).replace(/^.*\/\/[^\/]+/, ''));
});

$(".dropdown-trigger").dropdown();
