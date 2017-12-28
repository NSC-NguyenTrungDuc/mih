var mbs = "https://10.2.9.29/mss-web";
var mis = "http://10.2.9.26";
var noLogoUrl = "/logo/logo_default.jpg";


$(document).ready(function(){

	$('.loading').hide();
	$('.no-result').hide();
	$('.cancel').hide();
	$('.input').val("");
	$('input').bind('input propertychange', function() {
		clinic = $('.input').val();
		if(clinic == ""){
			$('.cancel').hide();
		}else{
			$('.cancel').show();
		}
	});
	$("input").change(function(){
		if($('.input').val() == ""){
			$('.cancel').hide();
			$('.loading').hide();
		}
		$('.cancel').hide();
		$('.loading').show();
		$.ajax({
            type: "GET",
            data: {hosp_code : $("input").val()},
            url: "/cms/hospital/search",
            dataType: "json",
            success: function (res) {
                if (res.status == 1) {
                    setTimeout(function () {
                        if (!res.data.logo) {
                            res.data.logo = noLogoUrl;
                        }
                        $('.no-result').hide();
                        $('#logo_img').html('<img src="' + res.data.logo + '" />');
                        $('.clinic-title').html(res.data.hosp_code);
                        $('.clinic-desc').html(res.data.hosp_name);

                        $(".btn-go-booking").attr("href", mbs + "/booking/index?tokenHospCode=" + res.data.descrypt_code);
                        $(".btn-go-booking-frontend").attr("href", mbs + "/back/login?tokenHospCode=" + res.data.descrypt_code);
                        $(".btn-go-interview").attr("href", mis + "/#/login?code=" + res.data.descrypt_code);
                        $(".btn-go-survey").attr("href", mis + "/#/login?code=" + res.data.descrypt_code + '&p=1');

                        $('.btn-go-booking').removeClass('btn-disable');
                        $('.btn-go-interview').removeClass('btn-disable');
                        $('.btn-go-survey').removeClass('btn-disable');
                        $('.btn-go-booking-frontend').removeClass('btn-disable');

                        $('.cancel').show();
                        $('.loading').hide();

                        /**
                         * Change view port to enable zoom when focus input
                         */
                        $('head meta[name=viewport]').remove();
                        $('head').prepend('<meta name="viewport" content="width=device-width, initial-scale=1" />');
                    }, 1000);
                }
                if (res.status == 0) {
                    $('.no-result').show();
                    $('#logo_img').html('');
                    $('.clinic-title').html('');
                    $('.clinic-desc').html('');

                    $('.btn-go-booking').addClass('btn-disable');
                    $('.btn-go-interview').addClass('btn-disable');
                    $('.btn-go-survey').addClass('btn-disable');
                    $('.btn-go-booking-frontend').addClass('btn-disable');

                    $('.cancel').show();
                    $('.loading').hide();
                }
            }, error: function (res) {
                console.log('error:' + res);
            }
        });
        /**
         * Hide keyboard
         */
        $('input').blur();
        /**
         * Change viewport to default view when lose focus input
         */
        $('head meta[name=viewport]').remove();
        $('head').prepend('<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />');
    });
    $('.cancel').click(function () {
        $('.input').val("");
        $('#logo_img').html('');
        $('.clinic-title').html('');
        $('.clinic-desc').html('');

        $('.btn-go-booking').addClass('btn-disable');
        $('.btn-go-interview').addClass('btn-disable');
        $('.btn-go-survey').addClass('btn-disable');
        $('.btn-go-booking-frontend').addClass('btn-disable');
    });
});
