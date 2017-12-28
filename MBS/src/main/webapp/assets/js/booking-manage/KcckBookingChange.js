$(document).ready(function(){
	var TimePeriods = [];
	var DatePeriods = [];
	comparedDate = Date.today();
	var curDate = "";
	if (curDate != "") {
		currentDate = new Date(curDate);
		if (isVaccine) comparedDate = new Date(curDate);
	}
	else {
		currentDate = Date.today();
	}

	initTimeslot();
	initMssCalendarData();
	bindWeekNavigationClickEvent(initMssCalendarData, comparedDate);

	function initTimeslot() {
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
		if($("#booking-slt-doctor").length) {
			bookingTime.doctorId = $("#booking-slt-doctor").val();
		}
	}

	function initMssCalendarData() {
		// clear data in table
		DatePeriods = [];
		TimePeriods = [];
		$("#doctor-schedule-table").empty();
		// check to disable previous button
		checkPreviousButtonStatus(currentDate, comparedDate);
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
			url: "ajax-get-booking-change",
			data: JSON.stringify(bookingTime),
			dataType: "json",
			beforeSend: function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type", "application/json");
			},
			success: function(response) {
				if (response.status == 200 && response.data) {
					$("#doctor-table").show();
					$("#no-table").hide();
					for(i in response.data.timeslots) {
						TimePeriods.push(insertColonToTimeslot(response.data.timeslots[i]));
					}
					DatePeriods.forEach(function(date) {
						TimePeriods.forEach(function(time) {
							if (time) {
								var timeslot = date.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR) + "_" + enhanceTime(time);
								var dt = Date.parseExact(date.toString(DATETIME.FORMAT.DATE) + " " + time, DATETIME.FORMAT.DATE_TIME);
								result.push(new BinaryData({
									dateTime: dt,
									isEditable: response.data.schedule[timeslot] == undefined ? false : response.data.schedule[timeslot],
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
						jContainerId: "#doctor-schedule-table"
					});
					
					$('.cell[data]').on("click", selectTime);
					alignTable();
				}
				if (response.status == 500){
					$("#doctor-table").hide();
					$("#no-table").show();
				}
				
				$("#btn-previous-week").prop("disabled", false);
				$("#btn-current-week").prop("disabled", false);
				$("#btn-next-week").prop("disabled", false);
				checkPreviousButtonStatus(currentDate, comparedDate);
			},
			error: function(){
				// TODO: handle errors
				//alert('Error while request..');
			}
		});
		
	}

	$("#booking-slt-doctor").change(function() {
		initMssCalendarData();
	});

	function alignTable(){
		if ( window.matchMedia('(min-width: 768px)').matches){
			$( ".table .row .cell:nth-child(1)" ).addClass( "cell-fix1" );
			$( ".table .row .cell:nth-child(2)" ).addClass( "cell-fix2" );
			var cellcount=$('.row.head').find('.cell').length-2;
			var cellcountall=$('.row.head').find('.cell');
			var width_row=cellcount*$('.row.head .cell:nth-child(3)').innerWidth();
			var row=width_row+cellcount;
			$(".table .row").css('width',row);
			$('.booking-time-s').css({
				'width': '76.02%',
				'margin-left':'190px'
			})
			if(cellcount<=8){

				$(".table .row").css('width','100%');
				$(".table .row .cell").css('width',100/cellcount+'%')
			}
			else{
				$('.booking-time-s').css('overflow-x','scroll')
			}
		}
	}
	

	function selectTime(event) {
		event.preventDefault();
		var $target = $(event.currentTarget);
		var schedule = $target.text();
						var date = $target.closest('.row').find('.cell:first-child').html().trim();	
						var cl = $target.context.lastChild.lastChild.className;				
		var dt = Date.parse(date).toString(DATETIME.FORMAT.DATE_NO_SEPARATOR);
		var time = enhanceTime($target.attr('data'));
		var bookingForSearch = $("#bookingForSearch").text();
		var vaccineChildId = $("#vaccineChildId").text();
		if(cl == "fa fa-circle-o" ){
			if (bookingForSearch != null && bookingForSearch == 'true') {
				location.href = "../booking-manage/change-booking-time-for-search-confirm?date=" + dt + "&time=" + time +"&vaccineChildId=" + vaccineChildId;
			} else {
				location.href = "../booking-manage/change-booking-time-confirm?date=" + dt + "&time=" + time;
			}
		}
	}
});