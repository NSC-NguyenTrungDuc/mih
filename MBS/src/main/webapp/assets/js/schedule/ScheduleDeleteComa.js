$(document).ready(function(){
	var TimePeriods = [];
	var DatePeriods = [];
	var Doctors = [];
	var result = [];
	var hasData = true;
	currentDate = Date.today();
	
	initTimeslot();
	initDoctorData();
	initMssDeleteRatioSchedulerData();
	bindWeekNavigationClickEvent(initMssDeleteRatioSchedulerData, Date.today());
	
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
	        	if (response.data.length != 0) {
	        		for (i in response.data) {
						TimePeriods.push(insertColonToTimeslot(response.data[i]));
					}
	        	}
	        	else {
	        		hasData = false;
	        	}
			},
			error: function() {
				alert('Error while request timeslot..');
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
				if (response.data.length != 0) {
					for (var id in response.data){
						Doctors.push(new Doctor({id: id, name: response.data[id]}));
					}
				}
	        	else {
	        		hasData = false;
	        	}
			},
			error: function(){		
				// TODO: handle errors
				alert('Error while request doctor list..');
			}
		});
	}
	
	function initMssDeleteRatioSchedulerData(){
		// clear data in table
		DatePeriods = [];
		$("#schedule-delete-coma-table").empty();
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
						TimePeriods.forEach(function(time){
							if(time){
								var timeslot = date.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR) + "_" + enhanceTime(time);
								var dt = Date.parseExact(date.toString(DATETIME.FORMAT.DATE) + " " + time, DATETIME.FORMAT.DATE_TIME);
								Doctors.forEach(function(doctor, index){
									var key = timeslot + "_" + doctor.id;
									result.push(new DeleteRatioSchedulerData({
										dateTime: dt,
										isEditable: true,
										total: response.data[key] == undefined? 0 : response.data[key].kpi,
										filled: response.data[key] == undefined? 0 : response.data[key].totalReservation,
										doctor: doctor,
										isClicked : false
									}));
								});
							}
						});
					});
					new MssDeleteRatioScheduler({
						startDate: start,
						endDate: end,
						data: result,
						timePeriods: TimePeriods,
						jContainerId: "#schedule-delete-coma-table",
						doctors: Doctors
					});
				},
				error: function(){		
					// TODO: handle errors
					alert('Error while request data to fill to table..');
				}
			});
		}
		else {
			var html = "<h4>データなし</h4>";
			$(".schedule-content").html(html);
		}
		createCheckboxRow();
	}
	
	$("#btn-view-patient-list").click(function(){
		var doctorSchedulePKList = $(".remove-list .header").map(function(){
		    return $(this).data("id");
		}).get();
		$.ajax({
			type: "post",
			url: "ajax-schedule-get-doctorSchedulePK-list",
			data: JSON.stringify(doctorSchedulePKList),
			dataType: "json",
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				window.location.href = response.data;
			},
			error: function(){		
				// TODO: handle errors
				alert('Error while setting session..');
			}
		});
	});
	
	function createCheckboxRow(){
		//alert(result[510].setFlag(true));
		$("#schedule-delete-coma-table .table .row.head").clone().removeClass("head").addClass("checkboxRow").prependTo("#schedule-delete-coma-table .table");
		var checkboxCell = $("#schedule-delete-coma-table .table .checkboxRow .cell");
		var timePeriodsLength = TimePeriods.length;
		for(var i = 0; i < 4; i++){
			$(checkboxCell[i]).children(".cell span").text("");
		}
		for(var i = 0; i < timePeriodsLength; i++){
			$(checkboxCell[i + 4]).attr("data", TimePeriods[i]);
			$(checkboxCell[i + 4]).attr("data-index", i + 4);
			$(checkboxCell[i + 4]).children(".cell span").html("<input type='checkbox'>");
		}
		
		$(checkboxCell).on("click", "input", function(){
			var timeString = $(this).closest("div").attr("data");
			var result = getRowDataByTimeString(timeString);
			var index = $(this).closest("div").attr("data-index");
			var doctorSchedulePKList = [];
			var source = $("#reservations-list").html();
			var template = Handlebars.compile(source); 
			for (key in result) {
				var dt = result[key];
				var checkeDate = dt.dateTime.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR);
				var startTime = dt.dateTime.toString(DATETIME.FORMAT.TIME_NO_SEPARATOR);
				var doctorId = dt.doctor.id;
				var dataAttribute = checkeDate + '_' + startTime + '_' + doctorId;
				var doctorSchedulePK = {'doctorId': dt.doctor.id, 'checkDate' : checkeDate, 'startTime' : startTime};
				if($(this).is(':checked')) { // tick the check box
					$("#schedule-delete-coma-table .table .row").each(function(){
						var cell = $(this).children(".cell:eq(" + index + ")");
						var value = $(cell).children().text();
						if(value.match(/^[0-9]+\/[0-9]+$/)){ // regex format "X/X"
							var split = value.split("/");
							if(split[1] != "0" || split[0] != "0"){
								$(this).children(".cell:eq(" + index + ")").addClass("selected");
							}
						}
					});
					if(!$('.remove-list div[data-id=' + dataAttribute + '].header').length) {
						$('.remove-list').append('<div class="header" data-id="' + dataAttribute + '"></div>');
					}
					result[key].setFlag(true);
					doctorSchedulePKList.push(doctorSchedulePK);
				}
				else { // un-tick the check box
					$("#schedule-delete-coma-table .table .row").each(function(){
						$(this).children(".cell:eq(" + index + ")").removeClass("selected");
					});
					$('.remove-list div[data-id=' + dataAttribute + '].header').remove();
					result[key].setFlag(false);
				}
			}
			// send ajax to get reservation List from doctor schedule list
			if(doctorSchedulePKList.length > 0) {
				$.ajax({
					type: "post",
					url: "ajax-schedule-get-reservations-multi-records",
					data: JSON.stringify(doctorSchedulePKList),
					dataType: "json",
					beforeSend: function(xhr) {
			            xhr.setRequestHeader("Accept", "application/json");
			            xhr.setRequestHeader("Content-Type", "application/json");
			        },
					success: function(response) {
						for(dsPK in response.data) {
							if($('.remove-list div[data-id=' + dsPK + '].header').text().length == 0) {
								$('.remove-list div[data-id=' + dsPK + '].header').append(template({reservations : response.data[dsPK]}));
							}
						}
					},
					error: function(){		
						// TODO: handle errors
						alert('Error while request the reservation for selected schedule..');
					}
				});
			}
		});
	}
	
	function getRowDataByTimeString(timeString) {
		var rs = [];
		var l = result.length;
		for(var i = 0; i < l; i++){
			if(result[i].getTimeString() == timeString && (result[i].total != 0 || result[i].filled != 0)){
				rs.push(result[i]);
			}
		}
		return rs;
	}
});
