function bindCellClickEvent(url) {
	$('.cell[data] .valid').click(function(e) {
		e.preventDefault();
		var $target = $(e.currentTarget);
		var $row = $target.closest('.row');
		var date = $row.find('.cell:first-child').text();
		var parsedDate = Date.parse(date, DATETIME.FORMAT.DATE_NO_SEPARATOR);
		var time = $target.closest('.cell').attr('data');
		var bookingTime = {'selectedDate': parsedDate.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR), 'selectedTime': enhanceTime(time)};
		if($("#booking-slt-doctor").length) {
			bookingTime.doctorId = $("#booking-slt-doctor").val();
		}
		$.ajax({
			type: "post",
			url: url,
			data: JSON.stringify(bookingTime),
			dataType: 'json',
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				if (response.status == 200) {
					window.location.href = response.data;
				}
				alertResponseMessage(response);
			},
			error: function() {		
				// TODO: handle errors
				console.log('error');
			}
		});
	});
	// off double click event
	$('.cell[data]').off('dblclick');
}

function cellClickCallBack(callback){
	$('.cell[data] .valid').click(function(e) {
		e.stopPropagation();
		e.preventDefault();
		var $target = $(e.currentTarget);
		var $row = $target.closest('.row');
		var date = $row.find('.cell:first-child').text();
		var parsedDate = Date.parse(date, DATETIME.FORMAT.DATE_NO_SEPARATOR);
		var time = $target.closest('.cell').attr('data');
		var bookingTime = {
			'selectedDate': parsedDate.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR),
			'selectedTime': enhanceTime(time),
			'$cellOffset': $target
		};
		if($("#booking-slt-doctor").length) {
			bookingTime.doctorId = $("#booking-slt-doctor").val();
		}
		callback(bookingTime);
	});
	// off double click event
	$('.cell[data]').off('dblclick');
}