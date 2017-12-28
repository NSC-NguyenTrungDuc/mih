/*
Update by cuong.ta.van on 2016/08/03
 */
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
	
	initTimeslot();
	initMssCalendarData();
	bindWeekNavigationClickEvent(initMssCalendarData, comparedDate);
	
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
	if($("#booking-slt-doctor").length) {
		bookingTime.doctorId = $("#booking-slt-doctor").val();
	}
		if($("#booking-slt-doctor").length) {
			bookingTime.doctorId = $("#booking-slt-doctor").val();
		}
	}

	var $mnContainer;
	var lastResponse;
	var avgTime = "";
	function initMssCalendarData() {
		// clear data in table
		DatePeriods = [];
		TimePeriods = [];
		$mnContainer = $("#time-slot-list").appendTo('body');
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
		$("#btn-reception").hide();
		$.ajax({
			type: "post",
			url: "ajax-booking-time",
			data: JSON.stringify(bookingTime),
			dataType: "json",
			//async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				lastResponse = response;
				if (response.status == 200 && response.data) {
					$("#btn-reception").show();
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
									isEditable: !response.data.schedule[timeslot] ? false : response.data.schedule[timeslot],
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
					//bindCellClickEvent('ajax-select-timeslot');
					cellClickCallBack(cellChoose);
					alignTable();
				}
				if (response.status == 500){
					//$("#table").hide();
					$("#booking-time").hide();
					$("#no-table").show();
				}
				$("#btn-current-week").prop("disabled", false);
				$("#btn-previous-week").prop("disabled", false);
				$("#btn-next-week").prop("disabled", false);
				checkPreviousButtonStatus(currentDate, comparedDate);
			},
			error: function(){
				lastResponse = null;
				// TODO: handle errors
				//alert('Error while request..');
			},
			complete: function(){
				$("#tableAjax").dataTable().fnDestroy();  //Reinitialize datatable to avoid warning
				showPopupBookingFaster();
				editCssTable();
				var isMobile = MssUtils.detectmob();
				if(isMobile)
				{
					MssUtils.focusIncaseMobile('#table');
				}			
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
				//'margin-left':'210px'
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
		if($("#booking-slt-doctor").length > 0) {
			bookingTime.doctorId = $("#booking-slt-doctor").val();
		}
		saveBookingInfo(bookingTime);
		// off double click event
		$('.cell[data]').off('dblclick');
	}

	function saveBookingInfo(bookingInfo){
		$.ajax({
			type: "post",
			url: "ajax-select-timeslot",
			data: JSON.stringify({
				selectedDate: bookingInfo.selectedDate,
				selectedTime: bookingInfo.selectedTime,
				doctorCode: bookingInfo.doctorCode,
				doctorId: bookingInfo.doctorId,
				templateName : bookingInfo.templateName
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
	function editCssTable()
	{
			$('.table').css( { margin : "20px 0 0"});
			$('table.dataTable thead th').css("border-bottom","none");
			$('table.dataTable.no-footer').css("border-bottom","none");
			
	}
	function showPopupBookingFaster()
	{
		var iDisplayLength = 8;
		var targets = 0;
		var iDisplayStart = 0;
		var order = 1;
		var roundNum = 2;
		var language = multiLanguage();
		   jQuery.fn.dataTableExt.oApi.fnPagingInfo = function ( oSettings )
			{
				return {
					"iStart":         oSettings._iDisplayStart,
					"iEnd":           oSettings.fnDisplayEnd(),
					"iLength":        oSettings._iDisplayLength,
					"iTotal":         oSettings.fnRecordsTotal(),
					"iFilteredTotal": oSettings.fnRecordsDisplay(),
					"iPage":          oSettings._iDisplayLength === -1 ?
						0 : Math.ceil( oSettings._iDisplayStart / oSettings._iDisplayLength ),
					"iTotalPages":    oSettings._iDisplayLength === -1 ?
						0 : Math.ceil( oSettings.fnRecordsDisplay() / oSettings._iDisplayLength )
				};
			};
	if(!(isVaccine === "true" || isVaccine === true))
	 {
	 var table = $("#tableAjax").dataTable( {
		  scrollCollapse: true,
	      "bProcessing": false,
	      "bServerSide": false,
	      "sort": "position",
	      "bFilter": false,
	      "bStateSave": false,
	      "columnDefs": [ {
	            "searchable": false,
	            "orderable": false,
	            "targets": targets,

	        }
	        ],
	        "language" : {
	        	  "sEmptyTable":     language.emptyTable,
	        	  "sInfo":           language.info,
	        	    "sInfoEmpty":      language.infoEmpty,
	        	    "sInfoFiltered":   "（全 _MAX_ 件より抽出）",
	        	  "sInfoPostFix":    "",
	        	  "sInfoThousands":  ",",
	        	    "sLengthMenu":    language.lengthMenu,
	        	  "sLoadingRecords": "読み込み中...",
	        	    "sProcessing":     "処理中...",
	        	  "sSearch":         "検索:",
	        	    "sZeroRecords":    "一致するレコードがありません",
	        	    "oPaginate": {
	        	        "sFirst":    language.paginate.first,
	        	        "sLast":     language.paginate.last,
	        	        "sNext":     language.paginate.next,
	        	        "sPrevious": language.paginate.previous
	        	    }},
	       "bLengthChange": false,
	       "paging":         true,
	       "info":     false,
	      //Default: Page display length
	      "iDisplayLength": iDisplayLength,
	      "iDisplayStart": iDisplayStart,
	      "sDom": 'rt<"bottom"ip><"clear">',
	      "fnDrawCallback": function () {
	      },
	      "sAjaxSource": "get-nearest_doctor_schedule",
	      "columnDefs": [
	                     { className: "doctor-name", "targets": [ 1 ] }
	                   ],
	      "aoColumns": [
	          {	 "bSortable": false,
	        	  render: function (data, type, row, meta) {
	        	        return meta.row + meta.settings._iDisplayStart + 1;
	        	    }},
	          { "bSortable": false, "mData": "doctor_code","width": "100%" ,
	        	  render: function (data, type, row, meta) {
	        		  	var doctorName = data.split("_")[1];        		  	
	        	        return doctorName;
	        	   }
	          } ,
	          { "bSortable": false, "mData": "waiting_patient","width": "100%"},
	          { "bSortable": false, "mData": "start_time","width": "100%" ,
	        	  render: function (data, type, row, meta) {
	        		  	currentHour = parseFloat(language.currHH);
	        		  	currentMinute = parseFloat(language.currMM);        		  	
	        		  	return (parseFloat(data.substring(0,2))*60  + parseFloat(data.substring(2,4)) - parseFloat(currentHour)*60 - parseFloat(currentMinute)) + " " + language.minute;
	        	    }}
	      ]
	  });
	}
	$("#tableAjax tbody tr").hover(function() {
	     $(this).css("cursor","pointer");
	 }, function() {
	     $(this).css("cursor","default");
	 });
	var dt = $('#tableAjax').DataTable();
	dt.on( 'click', 'tr', function () {
		var language = multiLanguage();
	    var table = $('#tableAjax').DataTable();
	    var dataRow = table.rows(this).data()[0];
	    var doctorInfo = dataRow.doctor_code.split("_");
	    var currentDate = formatDateCurrent();
	    var bookingInfo = {
				'selectedTime': dataRow.start_time,
				'doctorCode': doctorInfo[0],
				'doctorId' : doctorInfo[2],
				'selectedDate' : language.currDD,
				'templateName': 'recept'
	    }	    
	    saveBookingInfo(bookingInfo);
	    $('#pop-up-01').modal('hide');
	} ); 
	function formatDateCurrent() {
	    var d = new Date(),
	        month = '' + (d.getMonth() + 1),
	        day = '' + d.getDate(),
	        year = d.getFullYear();

	    if (month.length < 2) month = '0' + month;
	    if (day.length < 2) day = '0' + day;

	    return [year, month, day].join('');
	}
}
});