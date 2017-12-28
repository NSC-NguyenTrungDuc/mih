/**
 * @constructor
 * @inherit UIComponent
 * @param
 */
function Doctor(a) {
    a || (a = {});
    Doctor.superclass_.constructor.apply(this, arguments);
    this.id = a.id;
    this.name = a.name;
};
Util.inherit(Doctor, EventDriven);
Doctor.prototype.equals = function(d){
	if(this.id == d.id){
		return true;
	}
	return false;
};