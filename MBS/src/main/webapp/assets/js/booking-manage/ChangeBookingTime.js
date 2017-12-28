$(document).ready(function(){
	var TimePeriods = [];
	var DatePeriods = [];
	currentDate = Date.today();
	
	initTimeslot();
	initMssCalendarData();
	bindWeekNavigationClickEvent2(initMssCalendarData, Date.today());
	
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
		$("#doctor-schedule-table-noKcck").empty();
		// check to disable previous button
		checkPreviousButtonStatus2(currentDate, Date.today());
		var d;
		for (var i = 0; i <= 6; i++) {
			d = new Date(currentDate);
			DatePeriods.push(d.add({days: i}));
		}
		var start = DatePeriods[0],
			end = DatePeriods[6];
		var bookingTime = {'startDate' : start.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR), 'endDate' : end.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR)};
		bookingTime.doctorId = $("#doctorId").text();
		var result = [];
		$.ajax({
			type: "post",
			url: "ajax-doctor-schedule",
			data: JSON.stringify(bookingTime),
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				DatePeriods.forEach(function(date) {
					TimePeriods.forEach(function(time) {
						if (time) {
							var timeslot = date.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR) + "_" + enhanceTime(time);
							var dt = Date.parseExact(date.toString(DATETIME.FORMAT.DATE) + " " + time, DATETIME.FORMAT.DATE_TIME);
							var total = response.data == undefined ? 0 : (response.data[timeslot] == undefined ? 0 : response.data[timeslot].kpi);
							var filled = response.data == undefined ? 0 : (response.data[timeslot] == undefined ? 0 : response.data[timeslot].totalReservation);
							result.push(new RatioData({
								dateTime: dt,
								isEditable: false,
								total: total,
								filled: filled
							}));
						}
					});
				});
				
				new MssCalendar({
					startDate: start,
					endDate: end,
					data: result,
					timePeriods: TimePeriods,
					jContainerId: "#doctor-schedule-table-noKcck"
				});
				
				$('.cell[data]').on("click", selectTime);
				
			/*	$("#btn-current-week").prop("disabled", false);
				$("#btn-previous-week").prop("disabled", false);
				$("#btn-next-week").prop("disabled", false);
				checkPreviousButtonStatus(currentDate, comparedDate);*/
				
			},
			error: function(){		
				// TODO: handle errors
				//alert('Error while request..');
			}
		});
	};
	
	function selectTime(event) {
		event.preventDefault();
		var $target = $(event.currentTarget);
		var schedule = $target.text();
		var kpi = schedule.split('/')[1];
		if (kpi == '0') {
			return;
		}
		var date = $target.closest('.row').find('.cell:first-child').html().trim();
		var dt = Date.parse(date).toString(DATETIME.FORMAT.DATE_NO_SEPARATOR);
		var time = enhanceTime($target.attr('data'));
		var bookingForSearch = $("#bookingForSearch").text();
		var vaccineChildId = $("#vaccineChildId").text();
		if (bookingForSearch != null && bookingForSearch == 'true') {
			location.href = "../booking-manage/change-booking-time-for-search-confirm?date=" + dt + "&time=" + time +"&vaccineChildId=" + vaccineChildId;
		} else {
			location.href = "../booking-manage/change-booking-time-confirm?date=" + dt + "&time=" + time;
		}
	}
});