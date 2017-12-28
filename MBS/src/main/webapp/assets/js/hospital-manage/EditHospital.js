$(document).ready(function(){
	$(".error-msg").closest("div").addClass("has-error");
	if (!$("#validation").is(":empty")) {
		$('#saveHospital').modal('show');
	}
});

var loadFile = function(event) {
  var reader = new FileReader();
  reader.onload = function(){
    var output = document.getElementById('output');
    output.src = reader.result;
  };
  reader.readAsDataURL(event.target.files[0]);
};