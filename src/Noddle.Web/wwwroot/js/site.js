// Write your JavaScript code.
$(function () {
    var rotateDuration = 5000; // 5000ms = 5s
    var refreshCountdownDuration = 1000; // 1s
    var timeUntilNextRotation = rotateDuration;
    $("#rotator-countdown").text(timeUntilNextRotation / 1000);

    setInterval(function () {
        var nextUrl = $("#next-url").attr("href");
        if (!nextUrl)
            nextUrl = "/Rotator/Next";
        window.location.assign(nextUrl);
    }, rotateDuration);
    setInterval(function () {
    	timeUntilNextRotation -= refreshCountdownDuration;
    	$("#rotator-countdown").text(timeUntilNextRotation / 1000);
    }, refreshCountdownDuration);    
});