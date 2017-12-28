$(document).ready(function(){
	var TimePeriods = [];
	var DatePeriods = [];
	var Doctors = [];
	var hasData = true;

	initTimeslot();
	initDoctorData();
	initMssDefaultComaSchedulerData();

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
					for(i in response.data) {
						TimePeriods.push(insertColonToTimeslot(response.data[i]));
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

	function initMssDefaultComaSchedulerData(){
		for (var i = 0; i <= 6; i++) {
			// hard code from Monday to Sunday
			DatePeriods.push(new Date("2014/08/04").add({days: i}));
		}
		var start = DatePeriods[0],
			end = DatePeriods[6];
		var result = [];
		if (hasData) {
			$.ajax({
				type: "post",
				url: "ajax-get-default-department-kpi",
				async: false,
				beforeSend: function(xhr) {
					xhr.setRequestHeader("Accept", "application/json");
					xhr.setRequestHeader("Content-Type", "application/json");
				},
				success: function(response) {
					DatePeriods.forEach(function(date) {
						TimePeriods.forEach(function(time){
							if(time){
								var timeslot = getDayOfWeek(date) + "_" + enhanceTime(time);
								var dt = Date.parseExact(date.toString(DATETIME.FORMAT.DATE) + " " + time, DATETIME.FORMAT.DATE_TIME);
								Doctors.forEach(function(doctor, index){
									var key =  timeslot + "_" + doctor.id;
									result.push(new DefaultComaSchedulerData({
										dateTime: dt,
										isEditable: true,
										value: response.data[key] == undefined? -1 : response.data[key].kpi,
										doctor: doctor,
										departmentScheduleId: response.data[key] == undefined? 0 : response.data[key].departmentScheduleId,
										isClicked : false
									}));
								});
							}
						});
					});
					new MssDefaultComaScheduler({
						startDate: start,
						endDate: end,
						data: result,
						timePeriods: TimePeriods,
						jContainerId: "#schedule-default-coma-table",
						doctors: Doctors
					});
				},
				error: function(){
					// TODO: handle errors
					alert('Error while request..');
				}
			});
		}
		else {
			var html = "<h4>データなし</h4>";
			$(".schedule-content").html(html);
		}
	}

	$("#btn-save-default-coma").click(function(){
		$.ajax({
			type: "post",
			url: "ajax-save-default-coma",
			beforeSend: function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type", "application/json");
			},
			success: function(response) {
				$('#saveDefaultComa').modal("hide");
				alertResponseMessage(response);
			},
			error: function(){
				alert('Error while saving..');
			}
		});
	});
});
