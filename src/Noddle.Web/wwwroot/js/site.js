// Write your JavaScript code.
$(function () {
	$('li.nav-item > a[href="' + window.location.pathname + '"]').parent().addClass('active');

    var rotateDuration = 20000; // 5000ms = 5s
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

	var clock = new StationClock("clock");
	clock.body = StationClock.NoBody;
	clock.dial = StationClock.GermanStrokeDial;
	clock.hourHand = StationClock.PointedHourHand;
	clock.minuteHand = StationClock.PointedMinuteHand;
	clock.secondHand = StationClock.HoleShapedSecondHand;
	clock.boss = StationClock.NoBoss;
	clock.minuteHandBehavoir = StationClock.BouncingMinuteHand;
	clock.secondHandBehavoir = StationClock.OverhastySecondHand;

    clock.dialColor = 'rgb(360,360,360)';

	window.setInterval(function() { clock.draw() }, 50);
});

