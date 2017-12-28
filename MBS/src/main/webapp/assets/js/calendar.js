$(document).ready(function(){	
	runCalendar();

	//customize title of calendar
	function customizeTitle(){
		var title;
		$('.fc-event-title').each(function(){
			title = $(this).text();
			if (title == '0') {
				$(this).html('<i class="fa fa-times"></i>');
			}
			else if (title == '1') {
				$(this).html('<i class="fa fa-play fa-rotate-270"></i>');
			}
			else {
				$(this).html('<i class="fa fa-circle"></i>');
			}
		});
	}
	
	function initMonthData(m, y) {
		var MonthData = [];
		var calendarInfo = {'month' : m+1, 'year' : y};
		$.ajax({
			type: "post",
			url: "ajax-init-month-data-calendar",
			data: JSON.stringify(calendarInfo),
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				var className;
				var clickable;
				var date;
				for(i in response.data) {
					// customize title
					date = new Date(response.data[i].checkedDate);
					if (date.compareTo(Date.today()) != -1) {
						if (response.data[i].status == 0) {
							className = 'label-orange';
							clickable = false;
						}
						else if (response.data[i].status == 1) {
							className = 'label-yellow';
							clickable = true;
						}
						else {
							className = 'label-green';
							clickable = true;
						}
						MonthData.push({
							title: response.data[i].status.toString(),
					        start: date,
					        className: className,			                
			                clickable: clickable,
			                type: 0
					    });
					}
				}
			},
			error: function() {
				alert('Error while request..');
			}
		});
		return MonthData;
	}
	
    function runCalendar() {
        var $modal = $('#event-management');
        $('#event-categories div.event-category').each(function () {
            // create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)
            // it doesn't need to have a start or end
            var eventObject = {
                title: $.trim($(this).text()) // use the element's text as the event title
            };
            // store the Event Object in the DOM element so we can get to it later
            $(this).data('eventObject', eventObject);
            // make the event draggable using jQuery UI
            $(this).draggable({
                zIndex: 999,
                revert: true, // will cause the event to go back to its
                revertDuration: 50 //  original position after the drag
            });
        });
        /* initialize the calendar
				 -----------------------------------------------------------------*/
        var form = '';
        var calendar = $('#calendar').fullCalendar({
        	
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
//                right: ''
            },
            allDaySlot: false,
            editable: false,
            selectable: true,
            selectHelper: true,
            select: function (start, end, allDay) {
                $modal.modal({
                    backdrop: 'static'
                });
                form = $("<form></form>");
                form.append("<div class='row'></div>");
                form.find(".row").append("<div class='col-md-6'><div class='form-group'><label class='control-label'>New Event Name</label><input class='form-control' placeholder='Insert Event Name' type=text name='title'/></div></div>").append("<div class='col-md-6'><div class='form-group'><label class='control-label'>Category</label><select class='form-control' name='category'></select></div></div>").find("select[name='category']").append("<option value='label-default'>Work</option>").append("<option value='label-green'>Home</option>").append("<option value='label-purple'>Holidays</option>").append("<option value='label-orange'>Party</option>").append("<option value='label-yellow'>Birthday</option>").append("<option value='label-teal'>Generic</option>").append("<option value='label-beige'>To Do</option>");
                $modal.find('.remove-event').hide().end().find('.save-event').show().end().find('.modal-body').empty().prepend(form).end().find('.save-event').unbind('click').click(function () {
                    form.submit();
                });
                $modal.find('form').on('submit', function () {
                    title = form.find("input[name='title']").val();
                    $categoryClass = form.find("select[name='category'] option:checked").val();
                    if (title !== null) {
                        calendar.fullCalendar('renderEvent', {
                                title: title,
                                start: start,
                                end: end,
                                allDay: allDay,
                                className: $categoryClass
                            }, true // make the event "stick"
                        );
                    }
                    $modal.modal('hide');
                    return false;
                });
                calendar.fullCalendar('unselect');
            },
            eventClick: function (calEvent, jsEvent, view) {
            	if (calEvent.clickable) {
        			window.open($("#serverAddress").text() + '/booking/booking-time?hospitalCode=' + $("#hospitalCode").text() + '&deptCode=' + $("#deptCode").text() + '&date=' + (calEvent.start).toString(DATETIME.FORMAT.DATE_NO_SEPARATOR),'_blank');
            	}
            },
            viewDisplay: function (view) {
            	var date = new Date(view.start);
            	$('#calendar').fullCalendar('removeEvents');
                $('#calendar').fullCalendar('addEventSource', initMonthData(date.getMonth(), date.getFullYear()));
                $('#calendar').fullCalendar('rerenderEvents');
            },
            eventAfterAllRender: function(event, element, view) {
            	customizeTitle();
                clickToWeekAndDayButton();
            }
        });
        
        function clearWeekAndDayButton(){
        	$(".fc-button-agendaWeek").unbind();
        	$(".fc-button-agendaDay").unbind();
        }
        
        function clickToWeekAndDayButton(){
        	clearWeekAndDayButton();
        	$(".fc-button-agendaWeek").click(function(){
        		 window.location.href = $("#weekView").text() + "?isWeekMode=true";
        	});
        	$(".fc-button-agendaDay").click(function(){
       		 window.location.href = $("#weekView").text() + "?isWeekMode=false";
       	});
        }
    };
});
		