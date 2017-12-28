/**
 * @constructor
 * @inherit UIComponent
 * @param
 */
function SchedulerData(a) {
    a || (a = {});
    this.doctor = a.doctor;
    this.endTime = a.endTime;
    this.value = a.value;
    SchedulerData.superclass_.constructor.apply(this, arguments);
};
Util.inherit(SchedulerData, CellData);
SchedulerData.prototype.compareKeyRow = function(keyData){
	if(this.getDateString() == keyData.date.toString(DATETIME.FORMAT.DATE) && this.doctor.equals(keyData.doctor)){
		return true;
	}
	return false;
};
SchedulerData.prototype.setValue = function(v){
	this.value = v;
	this.trigger("DataChange", this);
};
SchedulerData.prototype.toHtml = function(){
	var title = $("#editableTitle").text();
	if ($("#btn-save").length){
		return '<a class="cell-editable" id="' + this.getDateStringNoSeparator() + "_" + enhanceTime(this.getTimeString()) + "_" + this.doctor.id + "_" + this.endTime + '" href="#" data-type="text" data-pk="1" data-title="' + title + '">' + this.value.toString() + '</a>';
	}
	else {
		return '<span style="font-weight:bold">' + this.value.toString() + '</span>';
	}
};