/**
 * @constructor
 * @inherit UIComponent
 * @param
 */
function BinaryData(a) {
    a || (a = {});
    BinaryData.superclass_.constructor.apply(this, arguments);
    this.value = a.value;
};
Util.inherit(BinaryData, CellData);
BinaryData.prototype.setValue = function(v){
	this.value = v;
	this.trigger("DataChange", this);
};
BinaryData.prototype.toHtml = function(){
	if(!this.isEditable){
		return '<span class="tb-respon">' + this.dateTime.toString(DATETIME.FORMAT.TIME) + '</span><i class="fa fa-times"></i>';
	}
	if(this.value){
		return '<span class="tb-respon">' + this.dateTime.toString(DATETIME.FORMAT.TIME) + '</span>V';
	}else{
		return '<span class="valid" style="display:block"><span class="tb-respon">' + this.dateTime.toString(DATETIME.FORMAT.TIME) + '</span><i class="fa fa-circle-o"></i></span>';
	}
};