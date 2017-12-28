/**
 * @constructor
 * @inherit UIComponent
 * @param
 */
function CalendarRow(date, data, timePeriods) {
	// check is saturday or sunday
	var weekendClass = "";
	if(getDayOfWeek(date) == '6' || getDayOfWeek(date) == '7') {
		weekendClass = " weekendCell";
	}
    var a = {};    
	a.cellsArray = [ 
	                 {
	                	html: date.toString(DATETIME.FORMAT.DATE),
	                	className: weekendClass
	                 },
	                 {
	                	html: date.toString("ddd"),
	                	className: weekendClass
	                 }
		           ];
	this.data = data;
    this.date = date;
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
	
	CalendarRow.superclass_.constructor.call(this, a);

	this.initDataEvent();
	this.initCellEvent();
};
Util.inherit(CalendarRow, Row);
CalendarRow.prototype.initCellEvent = function(){
	var self = this; 
	this.$container.children().dblclick(function(){
		var timeString = $(this).attr("data");
		if(timeString){
			var dt = self.getDataByTimeString(timeString);
			if(dt && dt.isEditable){
				dt.setValue(!dt.value);
				self.trigger("CellDataChange", dt);	
//				alert("Event when click in date: " + dt.getDateString() + " AND time: " + dt.getTimeString() + " AND value: " + dt.toHtml());
			}
		}
	});
};
CalendarRow.prototype.initDataEvent = function(timeString){
	var l = this.data.length;
	for(var i = 0; i < l; i++){
		this.data[i].on("DataChange", this.onDataChange.bind(this));
	}
};
CalendarRow.prototype.onDataChange = function(dt){
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
CalendarRow.prototype.getDataByTimeString = function(timeString){
	var l = this.data.length;
	for(var i = 0; i < l; i++){
		if(this.data[i].getTimeString() == timeString){
			return this.data[i];
		}
	}
	return null;
};
