$(document).ready(function(){
	var currentDate = Date.today();
	var isWeekMode = $("#isWeekMode").text() === 'true';
	initWeekData(currentDate, isWeekMode);
	
	function initWeekData(start, isWeekMode) {
		$("#calendar").empty();
		var source = $("#week-list").html();
		var template = Handlebars.compile(source); 
		var calendarInfo = {'startDateTime' : start.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR), 'isWeekMode' : isWeekMode};
		$.ajax({
			type: "post",
			url: "ajax-init-week-data-calendar",
			data: JSON.stringify(calendarInfo),
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				var data = {
	        			'weekList' : response.data,
		        	};
		        	$('#calendar').append(template(data));
			},
			complete: function(response) {
				convertToDay();
				reCalculateFirstColumnHeight();
				initClickFunction();
				checkPrevButtonStatus();
				checkActiveButton()
			},
			error: function() {
				alert('Error while request..');
			}
		});
    };
    
    function convertToDay() {
    	$(".cl-calendar .first-day .row-day").each(function() {
    		var date = new Date($(this).text());
    		$(this).text(date.toString("ddd"));
    	});
    }
    
    function reCalculateFirstColumnHeight() {
    	$(".cl-calendar table tr .first-day").each(function(){
    		var rowCount = $(this).siblings().length;
    		var newHeight = $(this).next().outerHeight() * Math.ceil(rowCount / 6);
    		$(this).css("height", newHeight + "px");
    		$(this).css("line-height", newHeight + "px");
    	});
    }
    
    function initClickFunction() {
    	$(".fc-button-next").click(function(){
    		if (isWeekMode) {
    			initWeekData(currentDate.add({days: 7}), true);
    		}
    		else {
    			initWeekData(currentDate.add({days: 1}), false);
    		}
	    });
    	$(".fc-button-today").click(function(){
    		currentDate = Date.today();
    		initWeekData(currentDate, isWeekMode);
    	});
    	$(".fc-button-agendaDay").click(function(){
    		isWeekMode = false;
    		initWeekData(currentDate, isWeekMode);
    	});
    	$(".fc-button-agendaWeek").click(function(){
    		isWeekMode = true;
    		initWeekData(currentDate, isWeekMode);
    	});
    	$(".fc-button-month").click(function(){
    		window.location.href = $("#monthView").text();
    	});
    	
    	$("td:not(.first-day)").click(function(){
    		callAjaxSelectTimeslot($(this).data("date"), $(this).data("time"));
    	});
    }
    
    function checkPrevButtonStatus() {
    	if (new Date($("#startDate").text()).compareTo(Date.today()) <= 0) {
    		$(".fc-button-prev").addClass("fc-state-disabled");
    	}
    	else {
    		$(".fc-button-prev").removeClass("fc-state-disabled");
    		$(".fc-button-prev").click(function(){
    			if (isWeekMode) {
    				initWeekData(currentDate.add({days: -7}), true);
    			}
    			else {
    				initWeekData(currentDate.add({days: -1}), false);
    			}
        	});
    	}
    }
    
    function checkActiveButton() {
    	if (isWeekMode){
    		$(".fc-button-agendaDay").removeClass("fc-state-active");
    		$(".fc-button-agendaWeek").addClass("fc-state-active");
    	}
    	else {
    		$(".fc-button-agendaDay").addClass("fc-state-active");
    		$(".fc-button-agendaWeek").removeClass("fc-state-active");
    	}
    }
    
    function callAjaxSelectTimeslot(date, time) {
		var bookingTime = {'selectedDate': date, 'selectedTime': time};
		$.ajax({
			type: "post",
			url: "ajax-select-timeslot-calendar",
			async: false,
			data: JSON.stringify(bookingTime),
			dataType: 'json',
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				if (response.status == 200) {
					window.open($("#serverAddress").text() + "/booking/booking-info",'_blank');
				}
				else {
					alertResponseMessage(response);
				}
			},
			error: function() {		
				// TODO: handle errors
				console.log('error');
			}
		});
    }
});
		