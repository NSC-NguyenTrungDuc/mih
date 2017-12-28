/**
 * @constructor
 * @inherit UIComponent
 * @param
 */
function CellData(a) {
    a || (a = {});
    CellData.superclass_.constructor.apply(this, arguments);
    this.dateTime = a.dateTime;
    this.isEditable = a.isEditable;
};
Util.inherit(CellData, EventDriven);
CellData.prototype.getDateString = function(){
	return this.dateTime.toString(DATETIME.FORMAT.DATE);
};
CellData.prototype.getDateStringNoSeparator = function(){
	return this.dateTime.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR);
};
CellData.prototype.getTimeString = function(){
	return this.dateTime.toString(DATETIME.FORMAT.TIME);
};
CellData.prototype.getDateJP = function(){
	return "月";
};
/**
 * Need to be implement 
 *
 */
CellData.prototype.toHtml = function(){
};
/**
 * Implement if you want.
 */
CellData.prototype.compareKeyRow = function(keyData){
	//This case, keydata is a Date object
	if(this.getDateString() == keyData.toString(DATETIME.FORMAT.DATE)){
		return true;
	}
	return false;
};