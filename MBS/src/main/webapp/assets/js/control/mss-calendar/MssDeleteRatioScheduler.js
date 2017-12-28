/**
 * @constructor
 * @inherit UIComponent
 * @param
 */
function MssDeleteRatioScheduler(a) {
    a || (a = {});
    
    this.selectedData = void 0;
    this.doctors = a.doctors;
    MssDeleteRatioScheduler.superclass_.constructor.apply(this, arguments);    
};
Util.inherit(MssDeleteRatioScheduler, BaseScheduler);

MssDeleteRatioScheduler.prototype.initDiffColumn = function(){
	this.columns = [{
		header: "",
		weight: 0.5
	}, {
	    header: $("#dateTitle").html(),
	    weight: 0.8
	}, {
	    header: $("#doctorTitle").html(),
	    weight: 1.4
	}, {
	    header: $("#dayTitle").html(),
	    weight: 0.3
	}];
};

MssDeleteRatioScheduler.prototype.createTable = function(){
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

MssDeleteRatioScheduler.prototype.createTableRow = function(){
	var d = new Date(this.startDate);
	var l = this.doctors.length;
	for(var i = 0; d <= this.endDate; i++){
		for(var j = 0; j < l; j++){
			var key = {date: d, doctor: this.doctors[j]};
			var dt = this.getDataByKey(key);
			var r = new DeleteRatioSchedulerRow(key, dt, this.timePeriods, isFirst = j==0?true:false);
			r.on("CellDataChange", this.onCellDataChange.bind(this));
			this.currentTable.addRowDom(r);
		}
		d = d.add({days: 1});
	}	
	this.currentTable.update();
};
MssDeleteRatioScheduler.prototype.onCellDataChange = function(dt){
	if(dt.value){
		if(this.selectedData && this.selectedData != dt){
			this.selectedData.setValue(false);
		}
		this.selectedData = dt;			
	}
};
