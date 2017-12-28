$(document).ready(function () {
    $('.panel-nav a').css('line-height', $('.panel-nav').height() + 'px');

    //Panel Toggle
    $('.panel-toggle .panel-heading .panel-title').click(function () {
        $(this).closest('.panel-toggle').find('.panel-body').toggle();
    });

    //Disable input on Servery Preview
    $(".servey-preview-area input").attr('disabled', 'disabled');
});