/**
 * @constructor
 * @inherit UIComponent
 * @param
 */
function BaseScheduler(a) {
    a || (a = {});
    BaseScheduler.superclass_.constructor.apply(this, arguments);
    this.startDate = a.startDate;
    this.endDate = a.endDate;
    this.data = a.data;
    this.timePeriods = a.timePeriods;
    this.jContainerId = a.jContainerId;
    
    this.columns = [];
    this.selectedData = void 0;
    this.tables = {};
    this.initUi();
    
};
Util.inherit(BaseScheduler, UIComponent);
BaseScheduler.prototype.initUi = function(){
	//init column headers
	this.initDiffColumn();
	this.initColumn();
	this.initTable();
};

/**
 * Need to override
 * This method use to do...
 * */
BaseScheduler.prototype.initDiffColumn = function(){
};

BaseScheduler.prototype.initColumn = function(){
	var self = this;
	this.timePeriods.forEach(function(value){
		self.columns.push({
		    header: value,
		    weight: 0.5
		});
	});
};

BaseScheduler.prototype.initTimePeriodColumn = function(){
	var self = this;
	this.timePeriods.forEach(function(value){
		self.columns.push({
		    header: value,
		    weight: 0.5
		});
	});
};

BaseScheduler.prototype.initTable = function(){
    this.currentTable = this.createTable();
    $(this.jContainerId).append(this.currentTable.$container);
    this.createTableRow();
    this.tables[this.startDate.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR)];
};
/**
 * Need to be implemented
 * */
BaseScheduler.prototype.createTableRow = function(){
};

BaseScheduler.prototype.getDataByKey = function(key){
	var result = [];
	this.data && this.data.forEach(function(value){
		if(value.compareKeyRow(key)){
			result.push(value);
		}
	});
	return result;
};

BaseScheduler.prototype.nextWeek = function(){
	this.shiftDay(7);
};
BaseScheduler.prototype.prevWeek = function(){
	this.shiftDay(-7);
};

BaseScheduler.prototype.nextMonth = function(){
	this.shiftDay(30);
};
BaseScheduler.prototype.prevMonth = function(){
	this.shiftDay(30);
};

BaseScheduler.prototype.next = function(days){
	this.currentTable.hide();
	this.startDate = this.startDate.add({days: days});
	this.endDate = this.endDate.add({days: days});
	var table = this.tables[this.startDate.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR)];
	if(table){
		table.$container.show();
	}else{
		this.initTable();
	}	
};
BaseScheduler.prototype.shiftDay = function(days){
	this.currentTable.hide();
	this.startDate = this.startDate.add({days: days});
	this.endDate = this.endDate.add({days: days});
	var table = this.tables[this.startDate.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR)];
	if(table){
		table.$container.show();
	}else{
		this.initTable();
	}	
};

