$(document).ready(function(){
	$("#btn-send-email").click(function(){
		var reservationList = [];
		$("table tbody tr").each(function(){
			var deleteComaInfo = {
				'reservationId' : $(this).find("td.chk-send-email input").data("id"),
				'originalDoctorId' : $(this).closest("table").find("td input[type=hidden].doctorId").val(),
				'originalDoctorName' : $(this).closest("table").find("td div.doctorName").text().trim(),
				'doctorId' : $(this).find("td select#slt-doctor").val(),
				'doctorName' : $(this).find("td select#slt-doctor option:selected").text().trim(),
				'isSentEmail' : $(this).find("td.chk-send-email input").is(":checked"),
			};
			reservationList.push(deleteComaInfo);
		});
		$.ajax({
			type: "post",
			url: "ajax-schedule-send-email",
			data: JSON.stringify(reservationList),
			dataType: "json",
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				window.location.href = response.data + "?templateId=" + $('select#slt-mail-template').val();
			},
			error: function(){		
				// TODO: handle errors
				alert('Error while setting session');
			}
		});
	});
	
	$("table").each(function(){
		var table = $(this);
		var checkDate = $(this).find("td input[type=hidden].checkDate").val();
		var startTime = $(this).find("td input[type=hidden].startTime").val();
		var bookingTime = {'startDate' : checkDate, 'selectedTime' : startTime};
		$.ajax({
			type: "post",
			url: "ajax-delete-coma-get-doctor-for-select-box",
			data: JSON.stringify(bookingTime),
			dataType: "json",
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				var options = "";
				response.data.forEach(function(doctorSchedule){
					options += '<option value="' + doctorSchedule.doctorId + '">' + doctorSchedule.doctorName + '</option>';
				});
				$(table).find("td select#slt-doctor").append(options);
			},
			error: function(){		
				// TODO: handle errors
				alert('Error while setting session');
			}
		});
	});
});