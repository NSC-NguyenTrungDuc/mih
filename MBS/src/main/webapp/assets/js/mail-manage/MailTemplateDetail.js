$(document).ready(function(){
	$("textarea#editor").ckeditor();
	$(".error-msg").closest("div").addClass("has-error");
	if (!$("#validation").is(":empty")) {
		$('#saveMailTemplate').modal('show');
	}
});