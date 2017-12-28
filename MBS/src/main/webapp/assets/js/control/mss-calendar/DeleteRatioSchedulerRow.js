/**
 * @constructor
 * @inherit UIComponent
 * @param
 */
function DeleteRatioSchedulerRow(key, data, timePeriods, isFirst) {
	// check is saturday or sunday
	var weekendClass = "";
	if(getDayOfWeek(key.date) == '6' || getDayOfWeek(key.date) == '7') {
		weekendClass = " weekendCell";
	}
	var a = {};
	a.cellsArray = [{
						html: "<input type='checkbox'>",
						className: "checkboxCell",
						data: key.date.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR)
					},
	                isFirst ?
		                {
		                	html: key.date.toString(DATETIME.FORMAT.DATE),
		                	className: "firstSpanCell" + weekendClass
		                } : 
		                {
		                	html: "",
		                	className: "spanCell" + weekendClass
		                },
                    {
	                	html: key.doctor.name,
	                	className: weekendClass
                    },
	                isFirst ? 
		                {
		                	html: key.date.toString("ddd"),
		                	className: "firstSpanCell" + weekendClass
		                } :
		                {
		                	html: "",
		                	className: "spanCell" + weekendClass
		                },
		           ];
	this.data = data;
    this.date = key.date;
    this.doctor = key.doctor;
    this.isFirst = isFirst;
	timePeriods.forEach(function(timePeriodValue){
		var cellDisplay = "";
		var l = data.length;
		for(var i = 0; i < l; i++){
			if(!timePeriodValue == ""){
				if(data[i].getTimeString() == timePeriodValue){
					var cellValue = {};
					cellValue.html = data[i].toHtml();
					cellValue.data = data[i].getTimeString();
					cellValue.className = weekendClass;
					cellDisplay = cellValue;
					break;
				}
			}
			else {
				var cellValue = {};
				cellValue.html = "";
				cellValue.className = "emptyCell";
				cellDisplay = cellValue;
			}
		}		
		a.cellsArray.push(cellDisplay);
	});
	
	DeleteRatioSchedulerRow.superclass_.constructor.call(this, a);
	
	this.initDataEvent();
	this.initCellEvent();
};
Util.inherit(DeleteRatioSchedulerRow, Row);
DeleteRatioSchedulerRow.prototype.initCellEvent = function(){
	var self = this;
	this.$container.children().on("click", function(event){
		var timeString = $(this).attr("data");
		if(timeString && $(this).children("a").length > 0){
			var dt = self.getDataByTimeString(timeString);
			if(dt){
				var checkeDate = dt.dateTime.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR);
				var startTime = dt.dateTime.toString(DATETIME.FORMAT.TIME_NO_SEPARATOR);
				var doctorId = dt.doctor.id;
				var dataAttribute = checkeDate + '_' + startTime + '_' + doctorId;
				var doctorSchedulePK = {'doctorId': dt.doctor.id, 'checkDate' : checkeDate, 'startTime' : startTime};
				var source = $("#reservations-list").html();
				var template = Handlebars.compile(source); 
				if(dt.isClicked == false){
					// change background
					$(this).addClass("selected");
					$('.remove-list').append('<div class="header" data-id="' + dataAttribute + '"></div>');
					$.ajax({
						type: "post",
						url: "ajax-schedule-get-reservations",
						data: JSON.stringify(doctorSchedulePK),
						dataType: "json",
						beforeSend: function(xhr) {
				            xhr.setRequestHeader("Accept", "application/json");
				            xhr.setRequestHeader("Content-Type", "application/json");
				        },
						success: function(response) {
				        	if($('.remove-list div[data-id=' + dataAttribute + '].header').text().length == 0) {
				        		$('.remove-list div[data-id=' + dataAttribute + '].header').append(template({reservations : response.data}));
				        	}
						},
						error: function(){		
							// TODO: handle errors
							alert('Error while request..');
						}
					});
				}
				else {
					// change background and remove reservations
					$(this).removeClass("selected");
					$('.remove-list div[data-id=' + dataAttribute + '].header').remove();
				}
				// change flag
				dt.setFlag(!dt.isClicked);
				// not use cause data does not change
				//self.trigger("CellDataChange", dt);
			}
		}
	});
	
	this.$container.children().on("click", "input", function(event){
		var dateString = $(this).closest("div").attr("data");
		var result = self.getDataByDateString(dateString);
		var doctorSchedulePKList = [];
		var source = $("#reservations-list").html();
		var template = Handlebars.compile(source); 
		for (key in result) {
			var dt = result[key];
			var checkeDate = dt.dateTime.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR);
			var startTime = dt.dateTime.toString(DATETIME.FORMAT.TIME_NO_SEPARATOR);
			var timeString = dt.getTimeString();
			var doctorId = dt.doctor.id;
			var dataAttribute = checkeDate + '_' + startTime + '_' + doctorId;
			var doctorSchedulePK = {'doctorId': dt.doctor.id, 'checkDate' : checkeDate, 'startTime' : startTime};
			if($(this).is(':checked')) {
				$(this).closest("div").siblings("[data='" + timeString + "']").addClass("selected");
				if(!$('.remove-list div[data-id=' + dataAttribute + '].header').length) {
					$('.remove-list').append('<div class="header" data-id="' + dataAttribute + '"></div>');	
				}
				dt.setFlag(true);
				doctorSchedulePKList.push(doctorSchedulePK);
			}
			else {
				$(this).closest("div").siblings("[data='" + timeString + "']").removeClass("selected");
				$('.remove-list div[data-id=' + dataAttribute + '].header').remove();
				dt.setFlag(false);
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
					alert('Error while request..');
				}
			});
		}
	});
};
DeleteRatioSchedulerRow.prototype.initDataEvent = function(timeString){
	var l = this.data.length;
	for(var i = 0; i < l; i++){
		this.data[i].on("DataChange", this.onDataChange.bind(this));
	}
};
DeleteRatioSchedulerRow.prototype.onDataChange = function(dt){
	var $child = void 0;
	this.$container.children().each(function(){
		var timeStr = $(this).attr("data");
		if(timeStr && timeStr == dt.getTimeString()){
			$child =  $(this);
		}
	});
	if($child){
		$child.html(dt.toHtml());
	}
};
DeleteRatioSchedulerRow.prototype.getDataByTimeString = function(timeString){
	var l = this.data.length;
	for(var i = 0; i < l; i++){
		if(this.data[i].getTimeString() == timeString){
			return this.data[i];
		}
	}
	return null;
};
DeleteRatioSchedulerRow.prototype.getDataByDateString = function(dateString){
	var result = [];
	var l = this.data.length;
	for(var i = 0; i < l; i++){
		if(this.data[i].getDateStringNoSeparator() == dateString && (this.data[i].total != 0 || this.data[i].filled != 0)){
			result.push(this.data[i]);
		}
	}
	return result;
};
DeleteRatioSchedulerRow.prototype.getAjaxData = function(timeString){
	
};
