$(document).ready(function(){
	var TimePeriods = [];
	var DatePeriods = [];
	if (curDate != "") {
		currentDate = new Date(curDate);
	}
	else {
		currentDate = Date.today();
	}
	
	
	initTimeslot();
	initMssCalendarData();
	bindWeekNavigationClickEvent(initMssCalendarData, Date.today());
	
	function initTimeslot() {
		$.ajax({
			type: "post",
			url: "ajax-get-timeslot-list",
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
	        success: function(response) {
				for(i in response.data) {
					TimePeriods.push(insertColonToTimeslot(response.data[i]));
				}
				
			},
			error: function() {
				alert('Error while request..');
			}
		});
	}
	
	function initMssCalendarData() {
		// clear data in table
		DatePeriods = [];
		$("#booking-time").empty();
		// check to disable previous button
		checkPreviousButtonStatus(currentDate, Date.today());
		var d;
		for (var i = 0; i <= 6; i++) {
			d = new Date(currentDate);
			DatePeriods.push(d.add({days: i}));
		}
		var start = DatePeriods[0],
			end = DatePeriods[6];
		var bookingTime = {'startDate' : start.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR), 'endDate' : end.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR)};
//		if($("#booking-slt-doctor").length) {
//			bookingTime.doctorId = $("#booking-slt-doctor").val();
//		}
		var result = [];
		$.ajax({
			type: "post",
			url: "ajax-booking-time-re-examination",
			data: JSON.stringify(bookingTime),
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				if (response.status == 200 && response.data) {
					DatePeriods.forEach(function(date) {
						TimePeriods.forEach(function(time) {
							if (time) {
								var timeslot = date.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR) + "_" + enhanceTime(time);
								var dt = Date.parseExact(date.toString(DATETIME.FORMAT.DATE) + " " + time, DATETIME.FORMAT.DATE_TIME);
								result.push(new BinaryData({
									dateTime: dt,
									isEditable: response.data[timeslot] == undefined ? false : response.data[timeslot],
									value: false
								}));
							}
						});
					});
					
					new MssCalendar({
						startDate: start,
						endDate: end,
						data: result,
						timePeriods: TimePeriods,
						jContainerId: "#booking-time"
					});
					bindCellClickEvent('ajax-select-timeslot-re-examination');
				}
				$("#btn-current-week").prop("disabled", false);
				$("#btn-previous-week").prop("disabled", false);
				$("#btn-next-week").prop("disabled", false);
				checkPreviousButtonStatus(currentDate, comparedDate);
			},
			error: function(){		
				// TODO: handle errors
				//alert('Error while request..');
			}
		});
	}
	
//	$("#booking-slt-doctor").change(function() {
//		initMssCalendarData();
//	});	
});