$(document).ready(function(){
	var TimePeriods = [];
	var DatePeriods = [];
	currentDate = Date.today();
	comparedDate = Date.today();
	initTimeslot();
	initBookingChangeCalendar();
	bindWeekNavigationClickEvent(initBookingChangeCalendar, Date.today());
	
	function initTimeslot() {
		$("#booking-time").empty();
		var d;
		for (var i = 0; i <= 6; i++) {
			d = new Date(currentDate);
			DatePeriods.push(d.add({days: i}));
		}
		var start = DatePeriods[0],
		end = DatePeriods[6];
		var bookingTime = {'startDate' : start.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR), 'endDate' : end.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR)};
	}
	var $mnContainer;
	var lastResponse;
	var avgTime = "";
	function initBookingChangeCalendar(){
		// clear data in table
		DatePeriods = [];
		TimePeriods = [];
		$mnContainer = $("#time-slot-list").appendTo('body');
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
				lastResponse = response;
				if (response.status == 200 && response.data) {
					$("#table").show();
					$("#no-table").hide();
					avgTime = response.data.avgTime;
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
						jContainerId: "#booking-time"
					});
					//bindCellClickEvent('ajax-submit-booking-change');
					cellClickCallBack(cellChoose);
					alignTable();
				}	
				if (response.status == 500){
					$("#booking-time").hide();
					$("#no-table").show();
				}
				
				$("#btn-current-week").prop("disabled", false);
				$("#btn-previous-week").prop("disabled", false);
				$("#btn-next-week").prop("disabled", false);
				checkPreviousButtonStatus(currentDate, comparedDate);
			},
			error: function(){
				// TODO: handle errors
				//
			}
		});
	}
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
		function prettyTimeslotMenu(){
			var $menuList = $("#time-slot-list > .dropdown-menu");
			//set menu to center from cell
			$mnContainer.css({top: - ($menuList.height()/2) + 10});

			//Start calculate suitable position of menu
			//Check if has scroll on parent, change position of menu
			var top = 0, i= 0, $bookingTime = $('#booking-time');
			while(i < 10){
				var topDirection = 0;
				if($mnContainer.offset().top < $bookingTime.offset().top){
					topDirection = 1;
				}else if($bookingTime.get(0).scrollHeight + 10> $bookingTime.height()){
					topDirection = -1;
				}
				//if postion of menu is ok, breank loop
				if(topDirection == 0){
					break;
				}
				//else change postion
				top = $mnContainer.css('top', parseInt($mnContainer.css('top'), 10) + topDirection*10);
				i++;
			}
		}
		function showTimeslotMenu(bookingInfo, uniqueTimeFrames){
			addTimeslotMenuItem(bookingInfo, uniqueTimeFrames);
			//Loop until open (an hack method :D)
			while (!$mnContainer.hasClass("open")) {
				$("#time-slot-list > .dropdown-toggle").dropdown('toggle');
			}
			prettyTimeslotMenu();
		}
		function addTimeslotMenuItem(bookingInfo, uniqueTimeFrames){
			bookingInfo.$cellOffset.parent().append($("#time-slot-list"));
			var $menuList = $("#time-slot-list > .dropdown-menu").empty();
			var $mnItem;
			$.each(uniqueTimeFrames, function(index, val){
				$mnItem = $('<li><a href="javascript:void(0)">'
					+ MssUtils.stringSplice(val.start_time, 2, 0, ":")
					+ '~'
					+ MssUtils.stringSplice(val.end_time, 2, 0, ":")
					+ '</a></li>');
				$mnItem.data(val);
				$menuList.append($mnItem);
			});
			//bind click event for those menu items
			$menuList.children().click(timeFrameClick);
		}

		function timeFrameClick(e){
			e.preventDefault();
			var $target = $(e.currentTarget);
			var $row = $target.closest('.row');
			var date = $row.find('.cell:first-child').text();
			var parsedDate = Date.parse(date, DATETIME.FORMAT.DATE_NO_SEPARATOR);
			var time = $target.closest('.cell').attr('data');
			var bookingTime = {
				'selectedDate': parsedDate.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR),
				'selectedTime': $(this).data().start_time,
				'doctorCode': $(this).data().first_doctor_code
			};
			//bindCellClickEvent('ajax-submit-booking-change');
			saveBookingInfo(bookingTime);
			// off double click event
			$('.cell[data]').off('dblclick');
		}

		function saveBookingInfo(bookingInfo){
			$.ajax({
				type: "post",
				url: "ajax-submit-booking-change",
				data: JSON.stringify({
					selectedDate: bookingInfo.selectedDate,
					selectedTime: bookingInfo.selectedTime,
					doctorCode: bookingInfo.doctorCode,
					doctorId: bookingInfo.doctorId
				}),
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
		}


		//Check whether we should show timeslot menu or not
		function isShowTimeslotMenu(bookingInfo, uniqueTimeslots){
			var endTimeFrame =  Date.parseExact(bookingInfo.selectedTime, "HHmm").addMinutes(avgTime).toString("HHmm");
			return uniqueTimeslots[0].end_time && !(uniqueTimeslots.length == 1 &&  uniqueTimeslots[0].start_time == bookingInfo.selectedTime && uniqueTimeslots[0].end_time == endTimeFrame);
		}

		function getUniqueTimeFrames(timeslots){
			var uni = {}, key;
			$.each(timeslots, function(i, e){
				key = e.start_time + '_' + e.end_time;
				if(!uni[key]){
					uni[key] = {
						start_time: e.start_time,
						end_time: e.end_time,
						first_doctor_code: e.doctor_code
					}
				};
			});
			var arr = $.map(uni, function(v, k){
				return [v];
			})
			return arr.sort(function(a, b){
				if(a.start_time == b.start_time){
					if(a.end_time < b.end_time) return -1;
					else if(a.end_time > b.end_time) return 1;
				}
				else if(a.start_time < b.start_time) return -1
				else return 1;
				return 0;
			});
		}

		function cellChoose(bookingInfo){
			var ts = timeslots(bookingInfo.selectedDate, bookingInfo.selectedTime);
			var uniqueTimeFrames = getUniqueTimeFrames(ts);
			if(isShowTimeslotMenu(bookingInfo, uniqueTimeFrames)) {
				showTimeslotMenu(bookingInfo, uniqueTimeFrames);
				return;
			}
			//other wise, choose first doctor
			bookingInfo.doctorCode = uniqueTimeFrames[0].first_doctor_code;
			//bindCellClickEvent('ajax-submit-booking-change');
			saveBookingInfo(bookingInfo);
		}

		function timeslots(date, time){
			return lastResponse.data.schedule[date + "_" + time];
			/*var result = [];
			for (var i = 0; i < 15; i++){
					result.push({
						'doctor_code': 'd' + 1,
						'start_time': '0800',
						'end_time': '0900'
					})
			}
			return result;*/
		}
});