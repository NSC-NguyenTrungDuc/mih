/**
 * @constructor
 * @inherit UIComponent
 * @param
 */
function AddRatioSchedulerData(a) {
    a || (a = {});
    this.doctor = a.doctor;
    this.total = a.total;
    this.filled = a.filled;
    this.endTime = a.endTime;
    AddRatioSchedulerData.superclass_.constructor.apply(this, arguments);
};
Util.inherit(AddRatioSchedulerData, CellData);
AddRatioSchedulerData.prototype.compareKeyRow = function(keyData){
	if(this.getDateString() == keyData.date.toString(DATETIME.FORMAT.DATE) && this.doctor.equals(keyData.doctor)){
		return true;
	}
	return false;
};
AddRatioSchedulerData.prototype.setValue = function(v) {
	this.total = v;
	this.trigger("DataChange", this);
};
AddRatioSchedulerData.prototype.toHtml = function() {
	var title = $("#editableTitle").text();
	if ($("#hidden-field").length){
		return '<a class="cell-editable" id="' + this.getDateStringNoSeparator() + "_" + enhanceTime(this.getTimeString()) + "_" + this.doctor.id + "_" + this.endTime + '" href="#" data-type="text" data-pk="1" data-title="' + title + '">1</a><span class="cell-filled" style="display:none">' + this.filled + '</span><span class="cell-total" style="display:none">' + this.total + '</span>';
	}
	else {
		return '<span style="font-weight:bold">' + this.filled.toString() + '/' + this.total.toString() + '</span>';
	}
};
