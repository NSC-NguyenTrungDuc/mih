/**
 * @constructor
 * @inherit UIComponent
 * @param
 */
function DefaultComaSchedulerData(a) {
	a || (a = {});
	this.departmentScheduleId = a.departmentScheduleId;
	this.doctor = a.doctor;
	this.value = a.value;
	DefaultComaSchedulerData.superclass_.constructor.apply(this, arguments);
};
Util.inherit(DefaultComaSchedulerData, CellData);
DefaultComaSchedulerData.prototype.compareKeyRow = function(keyData){
	if(getDayOfWeek(this.getDateString()) == getDayOfWeek(keyData.date) && this.doctor.equals(keyData.doctor)){
		return true;
	}
	return false;
};
DefaultComaSchedulerData.prototype.setValue = function(v){
	this.value = v;
	this.trigger("DataChange", this);
};
DefaultComaSchedulerData.prototype.toHtml = function(){
	if(this.value != -1) {
		var title = $("#editableTitle").text();
		if ($("#btn-save").length){
			return '<a class="cell-editable" id="' + this.departmentScheduleId + '" href="#" data-type="text"  data-pk="1" data-title="' + title + '">' + this.value.toString() + '</a>';
		}
		else {
			return '<span style="font-weight:bold;display:block;padding:10px">' + this.value.toString() + '</span>';
		}
	}
	else {
		return '<span style="display:block;padding:10px;"></span>';
	}
};