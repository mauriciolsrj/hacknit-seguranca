var waitForEl = function (selector, callback, maxTimes = false) {
    if ($(selector).length) {
    callback();
    } else {
    if (maxTimes === false || maxTimes > 0) {
        (maxTimes != false) && maxTimes-- ;
        setTimeout(function () {
        waitForEl(selector, callback, maxTimes);
        }, 500);
    }
    }
};

var onload = function() {
    waitForEl('#g-recaptcha',callback,5);

    
}

var callback = function() {
    if( $('#g-recaptcha').html()=='')
    {
        grecaptcha.render('g-recaptcha', {
            'sitekey' : '6LeGkGAUAAAAAOyLLTNFl0TRuLBiK9CIVHFeDtVg',
            'callback' : verifyCaptchaCallback
        });
    }
}

var verifyCaptchaCallback = function(g_recaptcha_response) {
    // Server Side checking for verification 
}