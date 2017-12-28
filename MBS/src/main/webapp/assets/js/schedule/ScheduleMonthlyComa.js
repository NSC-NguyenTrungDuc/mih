$(document).ready(function(){
	var FullTimePeriods = [];
	var TimePeriods = [];
	var DatePeriods = [];
	var Doctors = [];
	var AllDatesInMonth = [];
	var DatesArray = [];
	var index = 0;
	
	initTimeslot();
	initDoctorData();
	initDatePeriodData();
	initMssMonthlyComaSchedulerData();
	setMonthlyComaToSession();
	
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
	        	var time;
				for(i in response.data) {
					time = response.data[i].split("_");
					startTime = insertColonToTimeslot(time[0]);
					FullTimePeriods.push(startTime + "_" + time[1]);
					TimePeriods.push(startTime);
				}
				
			},
			error: function() {
				alert('Error while request..');
			}
		});
	}
	
	function initDoctorData(){
		$.ajax({
			type: "post",
			url: "ajax-get-doctor-list",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				for (var id in response.data){
					Doctors.push(new Doctor({id: id, name: response.data[id]}));
				};
			},
			error: function(){		
				// TODO: handle errors
				alert('Error while request doctor list..');
			}
		});
	}
	
	function initDatePeriodData(){
		$.ajax({
			type: "post",
			url: "ajax-get-days-of-month-list",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				// format M_yyyy
				var split = response.data.split("_");
				AllDatesInMonth = getDaysInMonth(split[0], split[1]);
				for (var i = 0; i < AllDatesInMonth.length; i += 7) {
					DatesArray.push(AllDatesInMonth.slice(i, i + 7));
				}
			},
			error: function(){		
				// TODO: handle errors
				alert('Error while request DatePeriods list..');
			}
		});
	}
	
	function initMssMonthlyComaSchedulerData(){
		DatePeriods = DatesArray[index];
		$("#schedule-monthly-coma-table").empty();
		// check to disable previous button
		checkNavigationButtonStatus();
		var start = DatePeriods[0],
			end = DatePeriods[DatePeriods.length - 1];
		var bookingTime = {'startDate' : start.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR), 'endDate' : end.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR)};
		var result = [];
		$.ajax({
			type: "post",
			url: "ajax-get-monthly-department-kpi",
			data: JSON.stringify(bookingTime),
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {				
				DatePeriods.forEach(function(date) {
					FullTimePeriods.forEach(function(time){
						if(time){
							var splitTime = time.split("_");
							var startTime = splitTime[0];
							var endTime = splitTime[1];
							var timeslot = date.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR) + "_" + enhanceTime(startTime);
							var dt = Date.parseExact(date.toString(DATETIME.FORMAT.DATE) + " " + startTime, DATETIME.FORMAT.DATE_TIME);
							Doctors.forEach(function(doctor, index){
								var key =  timeslot + "_" + doctor.id;
								result.push(new SchedulerData({
									dateTime: dt,
									isEditable: true,
									value: response.data[key] == undefined? 0 : response.data[key].split("_")[0],
									doctor: doctor,
									endTime: endTime
								}));
							});
						}
					});
				});
				new MssScheduler({
					startDate: start,
					endDate: end,
					data: result,
					timePeriods: TimePeriods,
					jContainerId: "#schedule-monthly-coma-table",
					doctors: Doctors
				});
			},
			error: function(){		
				// TODO: handle errors
				alert('Error while request..');
			}
		});
	}
	
	function setMonthlyComaToSession(){
		var start = AllDatesInMonth[0],
			end = AllDatesInMonth[AllDatesInMonth.length - 1];
		var bookingTime = {'startDate' : start.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR), 'endDate' : end.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR)};
		$.ajax({
			type: "post",
			url: "ajax-set-monthly-coma-to-session",
			data: JSON.stringify(bookingTime),
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {				
				// do nothing
			},
			error: function(){		
				// TODO: handle errors
				alert('Error while setting monthly coma to session..');
			}
		});
	}
	
	/**
     * @param {int} The month number, 0 based
     * @param {int} The year, not zero based, required to account for leap years
     * @return {Date[]} List with date objects for each day of the month
     */
    function getDaysInMonth(month, year) {
         // Since no month has fewer than 28 days
    	var date = new Date(year, month, 1);
    	var days = [];
    	while (date.getMonth() === parseInt(month)) {
    		days.push(new Date(date));
    		date.setDate(date.getDate() + 1);
    	}
    	return days;
    }
	
	$("#btn-save-monthly-coma").on("click", function(){
		$.ajax({
			type: "post",
			url: "ajax-save-monthly-coma",
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				$('#saveMonthlyComa').modal("hide");
				alertResponseMessage(response);
			},
			error: function(){
				alert('Error while saving..');
			}
		});
	});
	
	$("#btn-first-week").on("click", function(){		
		index = 0;
		initMssMonthlyComaSchedulerData();
	});
	
	$("#btn-previous-week").on("click", function(){		
		index --;
		initMssMonthlyComaSchedulerData();
	});
	
	$("#btn-next-week").on("click", function(){
		index ++;
		initMssMonthlyComaSchedulerData();
	});
	
	$("#btn-last-week").on("click", function(){		
		index = DatesArray.length - 1;
		initMssMonthlyComaSchedulerData();
	});

	function checkNavigationButtonStatus(){
		$("#btn-next-week").removeAttr("disabled");
		$("#btn-previous-week").removeAttr("disabled");
		if (index == 0) {
			$("#btn-previous-week").attr("disabled", "disabled");
		}
		if (index == DatesArray.length - 1) {
			$("#btn-next-week").attr("disabled", "disabled");
		}
	}
});
