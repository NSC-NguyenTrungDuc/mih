$(document).ready(function() {
//	$('#confirm-change-doctor-btn').on('click', saveChange);
	
//	function saveChange(event) {
//		event.preventDefault();
//		//disable confirm button
//		$('#confirm-change-doctor-btn').attr('disabled','disabled');
//		var $bookingCtn = $('#booking-info');
//		var date = $bookingCtn.attr('data-date');
//		var time = $bookingCtn.attr('data-time');
//		var id = $bookingCtn.attr('data-id');
//		var doctorId = $("#slt-doctor").val();
//		var templateCode = $("#slt-mail-template").val();
//		var bookingTime = {'reservationId' : id, 'selectedDate' : date, 'selectedTime' : time, 'doctorId' : doctorId, 'templateCode' : templateCode};
//		$.ajax({
//				type: "post",
//				url: "ajax-save-booking-change-doctor",
//				data: JSON.stringify(bookingTime),
//				dataType: "json",
//				beforeSend: function(xhr) {
//		            xhr.setRequestHeader("Accept", "application/json");
//		            xhr.setRequestHeader("Content-Type", "application/json");
//		        },
//				success: function(response) {
//					if (response.status == 200) {
//						location.href = response.data;
//						alertResponseMessage(response);
//					} else {
//						// TODO: show error msg
//						console.log('Error while saving booking');
//					}
//					$('#confirm-change-doctor-btn').removeAttr("disabled");
//				}
//		});
//	};
	
	$('#confirm-change-doctor-btn').on('click', changeDoctorConfirm);
	function changeDoctorConfirm(event) {
		var doctorId = $("#slt-doctor").val();
		var templateCode = $("#slt-mail-template").val();
		location.href = "../booking-manage/booking-change-doctor-confirm?doctorId=" + doctorId + "&templateCode=" + templateCode;
	}
	
});