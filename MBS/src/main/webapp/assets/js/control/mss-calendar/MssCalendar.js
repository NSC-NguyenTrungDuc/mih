/**
 * @constructor
 * @inherit UIComponent
 * @param
 */
function MssCalendar(a) {
    a || (a = {});
    
    this.selectedData = void 0;
    MssCalendar.superclass_.constructor.apply(this, arguments);    
};
Util.inherit(MssCalendar, BaseScheduler);

MssCalendar.prototype.initDiffColumn = function(){
	this.columns = [{
		header: $("#dateTitle").html(),
	    weight: 1.5
	}, {
		header: $("#dayTitle").html(),
	    weight: 0.8
	}];
};

MssCalendar.prototype.createTable = function(){
    return new Table({
        columns: this.columns,
        cellsMargins: 0,
        rowClass: CalendarRow,
        LAZY_PADDINGS:Infinity,
        ROW_HEIGHT:26,
        autoSorting: !1,
        autoSortingColumn: 0,
        autoSortingDirection: !1,
        dontCalculateHeight: !1
    });
};

MssCalendar.prototype.createTableRow = function(){
	var d = new Date(this.startDate);
	for(var i = 0; d <= this.endDate; i++){
		var dt = this.getDataByKey(d);
		var r = new CalendarRow(d, dt, this.timePeriods);
		r.on("CellDataChange", this.onCellDataChange.bind(this));
		this.currentTable.addRowDom(r);
		d = d.add({days: 1});
	}	
	this.currentTable.update();
};
MssCalendar.prototype.onCellDataChange = function(dt){
	if(dt instanceof BinaryData){
		if(dt.value){
			if(this.selectedData && this.selectedData != dt){
				this.selectedData.setValue(false);
			}
			this.selectedData = dt;			
		}
	}
};
