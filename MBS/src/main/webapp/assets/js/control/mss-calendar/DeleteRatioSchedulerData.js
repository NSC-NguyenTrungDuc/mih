/**
 * @constructor
 * @inherit UIComponent
 * @param
 */
function DeleteRatioSchedulerData(a) {
    a || (a = {});
    this.doctor = a.doctor;
    this.total = a.total;
    this.filled = a.filled;
    this.isClicked = a.isClicked;
    DeleteRatioSchedulerData.superclass_.constructor.apply(this, arguments);
};
Util.inherit(DeleteRatioSchedulerData, CellData);
DeleteRatioSchedulerData.prototype.compareKeyRow = function(keyData){
	if(this.getDateString() == keyData.date.toString(DATETIME.FORMAT.DATE) && this.doctor.equals(keyData.doctor)){
		return true;
	}
	return false;
};
DeleteRatioSchedulerData.prototype.setFlag = function(v) {
	this.isClicked = v;
	this.trigger("DataChange", this);
};
DeleteRatioSchedulerData.prototype.toHtml = function(){
	if(this.total != 0 || this.filled != 0) {
		return '<a>' + this.filled + '/' + this.total + '</a>';
	}
	else {
		return '<span style="display:block;padding:10px;">' + this.filled + '/' + this.total + '</span>';
	}
};
