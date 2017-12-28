/**
  *@author Khac Viet Nguyen 
  */
function EventDriven() {
    this._events = {}
};
/*
 * This function is used to handle an event after you define it with funtion "trigger"
 */
EventDriven.prototype.on = function Ca(b, c, d, e) {
    if (-1 < b.indexOf(" ")) {
        var f = [].slice.call(arguments);
        b.trim().split(" ").forEach(function (b) {
            f[0] = b;
            Ca.apply(this, f)
        }, this);
        return this
    }
    "function" == typeof c && (e = d, d = c, c = void 0);
    var i = !1;
    "single:" == b.slice(0, 7) && (b = b.slice(7), i = !0);
    var k = this._events || (this._events = {}),
        k = k[b] || (k[b] = []);
    i && (k.length = 0);
    k.push([d, e, c]);
    return this
};
/*
 * To turn off an event 
 */
EventDriven.prototype.off = function (a, b) {
    var c = this._events || (this._events = {}),
        d = c[a] || (c[a] = []);
    c[a] = d.filter(function (a) {
        return a[1] !== b
    });
    return this
};
/*
 * This is used to define an event for an object 
 */
EventDriven.prototype.trigger = function (a) {
    for (var b = this._events || (this._events = {}), b = b[a] || (b[a] = []), c = Array.prototype.splice.call(arguments, 1), d, e = 0; e < b.length; e++) {
        var f = b[e][1] || this;
        d = "undefined" !== typeof b[e][2] ? c.concat([b[e][2]]) : c;
        b[e][0] && f && d && b[e][0].apply(f, d)
    }
};
/*
 * This is used to clear all event 
 */
EventDriven.prototype.clearAllEvent = function () {
    this._events = {}
};
var ED = EventDriven;
