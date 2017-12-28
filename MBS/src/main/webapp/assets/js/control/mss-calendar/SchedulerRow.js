/**
 * @constructor
 * @inherit UIComponent
 * @param
 */
function SchedulerRow(key, data, timePeriods, isFirst) {
	// check is saturday or sunday
	var weekendClass = "";
	if(getDayOfWeek(key.date) == '6' || getDayOfWeek(key.date) == '7') {
		weekendClass = " weekendCell";
	}
    var a = {};    
	a.cellsArray = [
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
	
	SchedulerRow.superclass_.constructor.call(this, a);

	this.initDataEvent();
	this.initCellEvent();
};
Util.inherit(SchedulerRow, Row);
SchedulerRow.prototype.initCellEvent = function(){
	this.$container.find(".cell-editable").editable({
		type : 'text' ,
		url: "ajax-submit-monthly-coma",
		tpl: "<input type='text' style='width: 50px'>",
		ajaxOptions:{
			type: 'POST',
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
	        dataType: 'json',
		},
		params: function (params) {
		    var split = params.name.split("_");
		    var doctorSchedule = {
		    	checkDate: split[0],
		    	startTime: split[1],
		    	doctorId: split[2],
		    	endTime: split[3],
		    	kpi: params.value
		    };
		    return JSON.stringify(doctorSchedule);
		},
		display: function(value, response) {
			if (value != 0) {
				value = value.replace(/^0+/, '');
			}
			else {
				value = 0;
			}
			$(this).text(value);
		},
		success: function(response){
			// do nothing
		},
		validate: function(value) {
			if ($.trim(value) == '') {
		        return 'This field is required';
		    }
		    var re = /^\d+$/g;
		    if (!re.test(value)) {
		    	return 'Invalid input value';
		    }
		},
		error: function(errors){
	          return "Error: Can't connect to server. Pls try again";			
		}
	});
};
SchedulerRow.prototype.initDataEvent = function(timeString){
	var l = this.data.length;
	for(var i = 0; i < l; i++){
		this.data[i].on("DataChange", this.onDataChange.bind(this));
	}
};
SchedulerRow.prototype.onDataChange = function(dt){
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
SchedulerRow.prototype.getDataByTimeString = function(timeString){
	var l = this.data.length;
	for(var i = 0; i < l; i++){
		if(this.data[i].getTimeString() == timeString){
			return this.data[i];
		}
	}
	return null;
};
SchedulerRow.prototype.getAjaxData = function(timeString){
	
};
