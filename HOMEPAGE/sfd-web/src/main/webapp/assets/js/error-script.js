$(document).ready(function() {
	$("span.input-error").each(function(){
		$(this).parent().siblings(".form-control").addClass("validate-fr-fr");
		$(this).parent().siblings("#recaptcha_widget_div").find("div#recaptcha_area table#recaptcha_table").addClass("validate-fr-fr");
	});
});