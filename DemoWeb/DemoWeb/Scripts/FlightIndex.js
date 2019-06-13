'use strict';

$(document).ready(function () {
 
    var flightRows = document.querySelectorAll("#flightRow");

    flightRows.forEach(function (x) {
        if (x.querySelector("input").checked == true) {
            $(x).addClass("highlightRow");
        }
    });
});