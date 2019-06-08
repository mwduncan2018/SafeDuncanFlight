'use strict';

$(document).ready(function () {
    alert("0");
    var flightRows = document.querySelectorAll("#flightRow");

    flightRows.forEach(function (x) {
        alert("1");
        if (x.querySelector("input").checked == true) {
            alert("2");
            $(x).addClass("highlightRow");
        }
    });
});