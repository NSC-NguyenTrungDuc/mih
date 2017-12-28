$(document).ready(function() {
	$("#nameFurigana").keydown(function() {
		return furiganaCheck();
	});
	if (!$("#validation").is(":empty")) {
		$('#confirm-booking').modal('show');
	}
	disableSubmitButtonAfterSubmission("#btnYes");
});


function furiganaCheck() {
	var str = document.iform.FuriganaText.value;
	if (str.match(/[^ぁ-んァ-ン　\s]+/)) {
		alert("ふりがなは、「ひらがな」・「カタカナ」のみで入力して下さい。");
		return true;
	}
	return false;
}