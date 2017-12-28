$(document).ready(function(){
	var FullTimePeriods = [];
	var TimePeriods = [];
	var DatePeriods = [];
	var Doctors = [];
	var hasData = true;
	currentDate = Date.today();
	
	initTimeslot();
	initDoctorData();
	initMssAddComaSchedulerData();
	bindWeekNavigationClickEvent2(initMssAddComaSchedulerData, Date.today());
	
	function initTimeslot() {
		$.ajax({
			type: "post",
			url: "ajax-get-full-timeslot-list",
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
	        success: function(response) {
	        	if (response.data.length != 0) {
					for(i in response.data) {
						time = response.data[i].split("_");
						startTime = insertColonToTimeslot(time[0]);
						FullTimePeriods.push(startTime + "_" + time[1]);
						TimePeriods.push(startTime);
					}
	        	}
	        	else {
	        		hasData = false;
	        	}
			},
			error: function() {
				alert('Error while request..');
			}
		});
	}
	
	function initDoctorData() {
		$.ajax({
			type: "post",
			url: "ajax-get-doctor-list",
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				if (response.data.length != 0) {
					for(i in response.data) {
						Doctors.push(new Doctor({id : i , name:response.data[i]}));
					}
				}
		    	else {
		    		hasData = false;
		    	}
			},
			error: function() {
				alert('Error while request..');
			}
		});
	}
	
	function initMssAddComaSchedulerData() {
		// clear data in table
		DatePeriods = [];
		$("#schedule-adding-coma").empty();
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
		var result = [];
		if (hasData) {
			$.ajax({
				type: "post",
				url: "ajax-get-total-reservation-kpi-doctors",
				data: JSON.stringify(bookingTime),
				dataType: "json",
				async: false,
				beforeSend: function(xhr) {
		            xhr.setRequestHeader("Accept", "application/json");
		            xhr.setRequestHeader("Content-Type", "application/json");
		        },
				success: function(response) {
					DatePeriods.forEach(function(date) {
						FullTimePeriods.forEach(function(time) {
							if (time) {
								var splitTime = time.split("_");
								var startTime = splitTime[0];
								var endTime = splitTime[1];
								var dt = Date.parseExact(date.toString(DATETIME.FORMAT.DATE) + " " + startTime, DATETIME.FORMAT.DATE_TIME);
								Doctors.forEach(function(value, index) {
									var id = date.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR) + "_" + enhanceTime(startTime)+"_"+value.id;
									
									result.push(new AddRatioSchedulerData({
										dateTime: dt,
										isEditable: true,
										total: response.data[id] != undefined? response.data[id].kpi : 0,
										filled: response.data[id] != undefined? response.data[id].totalReservation: 0,
										doctor: value,
										endTime: endTime
									}));
								});
							}
						});
					});
					
					new MssAddRatioScheduler({
						startDate: start,
						endDate: end,
						data: result,
						timePeriods: TimePeriods,
						jContainerId: "#schedule-adding-coma",
						doctors: Doctors
					});
				},
				error: function(){		
					alert('Error while request..');
				}
			});
		}
		else {
			var html = "<h4>データなし</h4>";
			$(".schedule-content").html(html);
		}
	}//end init
});
