// Write your JavaScript code.
$(function () {
    configureNavigation();
    configureRotator();
    configureClock();
});

function configureNavigation() {
    $('li.nav-item > a[href="' + window.location.pathname + '"]').parent().addClass('active');
}

function configureRotator() {
    var gIsRotatorPaused = false;
    var rotateDuration = 20000; // 5000ms = 5s
    var refreshCountdownDuration = 1000; // 1s

    // initialize rotator countdown
    $("#rotator-countdown").text(rotateDuration / 1000);

    // after refreshCountdownDuration has passed, update countdown
    var timeUntilNextRotation = rotateDuration;
    setInterval(function () {
        if (!gIsRotatorPaused) {
            timeUntilNextRotation -= refreshCountdownDuration;
            $("#rotator-countdown").text(timeUntilNextRotation / 1000);
            if (timeUntilNextRotation == 0) {
                var nextUrl = $("#next-url").attr("href");
                if (!nextUrl)
                    nextUrl = "/Rotator/Next";
                window.location.assign(nextUrl);
            }
        }
    }, refreshCountdownDuration);

    //with jquery
    $('#play-pause').on('click', function(e) {
        e.preventDefault();
        gIsRotatorPaused = !gIsRotatorPaused;
        if (gIsRotatorPaused) {
            $("#paused-info-text").addClass('visible').removeClass('invisible');
            $('.fa-pause').addClass('fa-play').removeClass('fa-pause');
        }
        else {
            $("#paused-info-text").addClass('invisible').removeClass('visible');
            $('.fa-play').addClass('fa-pause').removeClass('fa-play');
        }
    });

}

function configureClock() {
    var clock = new StationClock("clock");
    clock.body = StationClock.NoBody;
    clock.dial = StationClock.SwissStrokeDial;
    clock.hourHand = StationClock.PointedHourHand;
    clock.minuteHand = StationClock.PointedMinuteHand;
    clock.secondHand = StationClock.HoleShapedSecondHand;
    clock.boss = StationClock.NoBoss;
    clock.minuteHandBehavoir = StationClock.ElasticBouncingMinuteHand;
    clock.secondHandBehavoir = StationClock.ElasticBouncingSecondHand;

    clock.dialColor = 'rgb(235,235,235)';
    clock.hourHandColor = 'rgb(360,360,360)';
    clock.minuteHandColor = 'rgb(360,360,360)';

    window.setInterval(function() { clock.draw() }, 50);
}

