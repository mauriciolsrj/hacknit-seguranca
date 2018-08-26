/*global $, window, document, setTimeout, WOW, jQuery*/
$(document).ready(function() {
    "use strict";
    $('body').scrollspy({
        target: '#minify_nav',
        offset: 100
    });

    $('nav a[href^="#"]:not([href="#"]), .scroll').on('click', function(event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top - 60
        }, 1500);
        event.preventDefault();
    });
    $(window).on("scroll touchmove", function() {
        $('#minify_nav').toggleClass('mini-nav', $(document).scrollTop() > 60);
    });
    $(window).scroll(function() {
        if ($(this).scrollTop() > 600) {
            $('.scrollup').fadeIn();
        } else {
            $('.scrollup').fadeOut();
        }
    });

    $('.scrollup').on('click', function() {
        $("html, body").animate({
            scrollTop: 0
        }, 600);
        return false;
    });


    $('.fade-left').waypoint(function() {
        $('.fade-left').addClass('animated fadeInLeft');
    }, {
        offset: '50%'
    });


    $('.fade-right').waypoint(function() {
        $('.fade-right').addClass('animated fadeInRight');
    }, {
        offset: '100%'
    });
    new WOW().init();
});


var $sync2 = $("#sync2"),
    $sync3 = $(".sync3"),
    flag = false,
    duration = 300;
$sync2.owlCarousel({
    animateOut: 'fadeInDown',
    animateIn: 'fadeOutDown',
    margin: 20,
    items: 1,
    nav: false,
    loop: true,
    autoplay: true,
    center: false,
    dotsEach: false,
    dots: true,
    dotsContainer: '#carousel-custom-dots',
}).on('click', '.owl-item', function() {
    $sync3.trigger('to.owl.carousel', [$(this).index(), duration, true]);
}).on('changed.owl.carousel', function(e) {
    if (!flag) {
        flag = true;
        var a = e.property.value++;
        $sync3.trigger('to.owl.carousel', [e.item.index, duration, true]);
        flag = false;
    }
});

$(".team-images").eq(0).addClass("current_dot");
$('.team-images').on('click', function(e) {
    $(".team-images").removeClass("current_dot");
    $(this).addClass("current_dot");
    $sync2.trigger('to.owl.carousel', [$(this).index(), duration, true]);
});


$('.video-play').magnificPopup({
    type: 'iframe',
    closeOnBgClick: false,
    iframe: {
        markup: '<div class="mfp-iframe-scaler">' + '<div class="mfp-close"></div>' + '<iframe class="mfp-iframe" frameborder="0" allowfullscreen></iframe>' + '<div class="mfp-title">Some caption</div>' + '</div>'
    },
    callbacks: {
        markupParse: function(template, values, item) {
            values.title = item.el.attr('title');
        }
    },
    removalDelay: 300,
    mainClass: 'mfp-fade'
});

$('#feel-the-wave').wavify({
    height: 40,
    bones: 5,
    amplitude: 30,
    color: 'rgba(48, 53, 73, 1)',
    speed: .15
});

$('#feel-the-wave-two').wavify({
    height: 30,
    bones: 5,
    amplitude: 40,
    color: 'rgba(48, 53, 73, .5)',
    speed: .25
});