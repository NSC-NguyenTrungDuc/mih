$(document).ready(function(){
	var TimePeriods = [];
	var DatePeriods = [];
	
	prepareData();
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
				//alert('Error while request..');
			}
		});
	}
	
	function initMssCalendarData() {
		// clear data in table
		DatePeriods = [];
		$("#doctor-schedule-table").empty();
		$("#doctor-reservations").empty();
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
		if($("#booking-slt-doctor").length) {
			bookingTime.doctorId = $("#booking-slt-doctor").val();
		}
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
				if (response.status == 200 && response.data) {
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
						jContainerId: "#doctor-schedule-table"
					});
					
					$('.cell[data]').on("click", loadDoctorReservations);
				}
/*				$("#btn-current-week").prop("disabled", false);
				$("#btn-previous-week").prop("disabled", false);
				$("#btn-next-week").prop("disabled", false);
				checkPreviousButtonStatus(currentDate, comparedDate);*/
			},
			error: function(){		
				// TODO: handle errors
				alert('Error while request..');
			}
		});
	};
	
	function loadDoctorReservations(event) {
		event.preventDefault();
		var $target = $(event.currentTarget);
		var date = $target.closest('.row').find('.cell:first-child').html().trim();
		var dt = Date.parse(date).toString(DATETIME.FORMAT.DATE_NO_SEPARATOR);
		var time = enhanceTime($target.attr('data'));
		var bookingTime = {'selectedDate' : dt, 'selectedTime' : time};
		var doctorId = "";
		if($("#booking-slt-doctor").length) {
			doctorId = $("#booking-slt-doctor").val();
			bookingTime.doctorId = doctorId;
		}
		// check the clicked status
		if ($target.hasClass("selected")) {
			$target.removeClass("selected");
				$('#doctor-reservations').find("div[data-id='" + dt + time + "']").remove();
		}
		else {
			var schedule = $target.text();
			var kpi = schedule.split('/')[0];
			if (doctorId == '' && kpi == '0') {
				return;
			}
			
			var source = $("#reservations-list").html();
			var template = Handlebars.compile(source); 
			$.ajax({
				type: "post",
				url: "ajax-doctor-reservations",
				data: JSON.stringify(bookingTime),
				async: false,
				dataType: "json",
				beforeSend: function(xhr) {
		            xhr.setRequestHeader("Accept", "application/json");
		            xhr.setRequestHeader("Content-Type", "application/json");
		        },
		        success: function(response) {
		        	var data = {
	        			'lstReservations' : response.data.lstReservations, 
	        			'selectedTime' : time,
	        			'selectedDate' : dt
		        	};
		        	$target.addClass('selected');
		        	$('#doctor-reservations').append(template(data));
		        	$('.cancel-bk-btn').on('click', showConfirmDialog);
		        	bindChangeReservationClickEvent();
		        	// clear local storage
		        	localStorage.removeItem("currentDate");
		        	localStorage.removeItem("selectedDoctor");
		        	// set storage when click on link
		        	submitSelectedTime();
		        }
			});
		}
	}
	
	function showConfirmDialog(event) {
		var $target = $(event.currentTarget);
		var resId = $target.attr('data-id');
		var date = $target.attr('data-date');;
		var time = $target.attr('data-time');;
		var $confirmDialog = $('#confirm-cancel');
		$confirmDialog.attr('data-id', resId);
		$confirmDialog.attr('data-date', date);
		$confirmDialog.attr('data-time', time);
		$confirmDialog.modal('show');
	}
	
	function submitSelectedTime() {
		$(".new-booking-btn").on("click", function(){
    		localStorage.setItem("currentDate", currentDate);
    		localStorage.setItem("selectedDoctor", $("#booking-slt-doctor").val());
    		var date = $(this).data("date");
    		var time = $(this).data("time");
    		var doctorId = $(this).data("doctorid");
    		var reservation = {"reservationDate" : date, "reservationTime" : time};
			$.ajax({
				type: "post",
				url: "ajax-validate-selected-time",
				data: JSON.stringify(reservation),
				async: false,
				dataType: "json",
				beforeSend: function(xhr) {
		            xhr.setRequestHeader("Accept", "application/json");
		            xhr.setRequestHeader("Content-Type", "application/json");
		        },
		        success: function(response) {
		        	if (response.status == 200) {
		        		if ($("#isBookingVaccine").text() == 'true') {
		        			window.location.href = "booking-new?date=" + date + "&time=" + time + "&doctorId=" + doctorId + "&isBookingVaccine=" + true;
		        		} else {
		        			window.location.href = "booking-new?date=" + date + "&time=" + time + "&doctorId=" + doctorId;
		        		}
		        	}
		        	else {
		        		alertResponseMessage(response);
		        	}
		        },
		        error : function() {
					alert('Error while validating selected time..');
				}
			});
		});
	}
	
	function bindChangeReservationClickEvent() {
		$('.btn-change-reservation').click(function(e) {
			e.preventDefault();
			var $target = $(e.currentTarget);
			var reservationId = $target.attr("data-id");
			localStorage.setItem("currentDate", currentDate);
			localStorage.setItem("selectedDoctor", $("#booking-slt-doctor").val());
			window.location.href = "booking-info?id=" + reservationId;
		});
	}
	
	function prepareData() {
		if(localStorage.getItem('currentDate')) {
			currentDate = new Date(localStorage.getItem('currentDate'));
		} 
		else if ($("#curDate").text() != "") {
			currentDate = new Date($("#curDate").text());
		}
		else {
			currentDate = Date.today();
		}
		if(localStorage.getItem('selectedDoctor')) {
			$("#booking-slt-doctor").val(localStorage.getItem('selectedDoctor'));
		}
	}
	
	$("#btn-cancel-booking").click(function() {
		var reservationId = $('#confirm-cancel').attr('data-id');
		var date = $('#confirm-cancel').attr('data-date');
		var time = $('#confirm-cancel').attr('data-time');
		$.ajax({
			type : "post",
			url : "ajax-cancel-reservation",
			data : JSON.stringify({"reservationId" : reservationId, "reservationDate" : date, "reservationTime" : time}),
			dataType : "json",
			async : false,
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type","application/json");
			},
			success : function(response) {
				$('#confirm-cancel').modal('hide');
				if (response.status == 200) {
					$('#doctor-reservations table tr td a[data-id="' + reservationId + '"]').closest("tr").remove();
					var split = $('#doctor-schedule-table .table .row .cell.selected').text().split("/");
					var reservation = split[0];
					var kpi = split[1];
					var newReservation = +reservation - 1;
					$('#doctor-schedule-table .table .row .cell.selected').html(newReservation + "/" + kpi);
				}
				alertResponseMessage(response);
			},
			complete: function() {
				
			},
			error : function() {
				alert('Error while request..');
			}
		});
	});
	
	$("#booking-slt-doctor").change(function() {
		initMssCalendarData();
	});	
});