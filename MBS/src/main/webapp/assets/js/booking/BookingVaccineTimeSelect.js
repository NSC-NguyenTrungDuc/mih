$(document).ready(function(){
	var TimePeriods = [];
	var DatePeriods = [];
	comparedDate = Date.today();
	if (curDate != "") {
		currentDate = new Date(curDate);
		if (isVaccine) comparedDate = new Date(curDate);
	}
	else {
		currentDate = Date.today();
	}

	initMssCalendarData();
	bindWeekNavigationClickEvent(initMssCalendarData, comparedDate);

	function caculatorTime(timeslotStr) {
		return  parseInt( timeslotStr.substring(0, timeslotStr.length - 2))  * 60 +  parseInt(timeslotStr.substring(timeslotStr.length - 2, timeslotStr.length));
	};

	function getFormatTime(total) {
		var h = Math.floor(total/60);
		var s = total % 60 ;
		if(h < 10) h = '0' + String(h);
		else  	h = String(h);
		if(s<10) s = '0' + String(s);
		else 	s = String(s);
		return h + s;
	};

	function initMssCalendarData() {
		// clear data in table
		DatePeriods = [];
		$("#booking-time").empty();
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
			url: "ajax-get-vaccine-timeslot-list",
			data: JSON.stringify(bookingTime),
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type", "application/json");
			},
			success: function(response) {
				if ( response.data) {
					var startTime = response.data.start_time_hhmm;
					var endTime = response.data.end_time_hhmm;
					var totalStart = caculatorTime(String(startTime));
					var totalEnd  = caculatorTime(String(endTime));
					var period = response.data.avg_time ? parseInt(response.data.avg_time) : 30;
					var TimePeriods = [];
					while (totalStart <= totalEnd){
						TimePeriods.push(insertColonToTimeslot(getFormatTime(totalStart)));
						totalStart += period;
					}
					var data = [];
					response.data.enable_slot.forEach(function(value) {
						key = value.enable_date_slot + '_' + value.enable_time_slot;
						data[key] = true;
					});
					DatePeriods.forEach(function(date) {
						TimePeriods.forEach(function(time) {
							if (time) {
								var timeslot = date.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR) + "_" + enhanceTime(time);
								var dt = Date.parseExact(date.toString(DATETIME.FORMAT.DATE) + " " + time, DATETIME.FORMAT.DATE_TIME);
								result.push(new BinaryData({
									dateTime: dt,
									isEditable: data[timeslot] == undefined ? false : data[timeslot],
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
					bindCellClickEvent('ajax-select-timeslot');
					alignTable();
				}
				$("#btn-current-week").prop("disabled", false);
				$("#btn-previous-week").prop("disabled", false);
				$("#btn-next-week").prop("disabled", false);
				checkPreviousButtonStatus(currentDate, comparedDate);
			},
			error: function(){
				// TODO: handle errors
				alert('Error while request..');
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
});