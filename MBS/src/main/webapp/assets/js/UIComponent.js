function setSizeOfCss(a) {
    var b = a.$container;
    a._width !== void 0 && b.css("width", a._width);
    a._height !== void 0 && b.css("height", a._height)
};
 var UIComponent = function dd(b) {
        b || (b = {});
        var c = b.nodeType || "div";
        UIComponent.superclass_.constructor.apply(this, arguments);
        Array.isArray(b.mixins) && b.mixins.forEach(function (b) {
            Util.extend(this, b, j)
        }, this);
        this.$container = "undefined" === typeof b.container ? Util.spawnDomElement("<" + c + ">") : $(b.container);
        b.className && this.$container.addClass(b.className);
        this._width = this._height = this._outerWidth = this._outerHeight = void 0;
        this.hidden = !1;
        this.name = "";
        this.id = "";
        this.parent = b.parent;
        this.constructor === dd && Object.seal(this)
    };
Util.inherit(UIComponent, ED);
UIComponent.prototype.destroy = function () {
    this.$container.remove();
    this.trigger("destructed")
};
UIComponent.prototype.setSize = function (a, b) {
    this.width = a;
    this.height = b;
    setSizeOfCss(this);
};
UIComponent.prototype.append = function (a) {
    if (a instanceof UIComponent) return this.$container.append(a.$container), a;
    a = $(a);
    this.$container.append(a);
    return a
};
UIComponent.prototype.hide = function () {
    if (this.hidden) return !1;
    this.hidden = !0;
    this.$container.hide();
    return !0
};
UIComponent.prototype.show = function () {
    if (!this.hidden) return !1;
    this.hidden = !1;
    this.$container.show();
    return !0
};
UIComponent.prototype.update = function(){};
UIComponent.prototype.remove = function () {
    return this.$container.remove()
};
UIComponent.prototype.addClass = function(a){
	this.$container.addClass(a);
};