var Row = function (a) {
    Row.superclass_.constructor.apply(this, [{}]);
    this.parentTable = a.parentTable;
    this.cells = a.cellsArray;
    var htmlInner = this.cells && this.cells.reduce(function (previousValue, currentValue) {        
        var html = (currentValue.html !== void 0  ? currentValue.html : currentValue);
        var cls = "cell" + (currentValue.className !== void 0 ? (" " + currentValue.className) : "");
        var data = (currentValue.data !== void 0  ? 'data = "' + currentValue.data + '"': "");
        return previousValue += '<div class="' + cls + '"' + data +'>' + html + "</div>";
    }, "");
    this.$container.addClass("row").html(htmlInner);
    this.$container.on("mouseover", this.handleMouseOver.bind(this));
    this.$container.on("mouseout", this.handleMouseOut.bind(this));
};
Util.inherit(Row, UIComponent);

/*
 * This is used to get a cell in row
 */
Row.prototype.getCell = function (a) {
    "string" === typeof a && (a = this.returnCellIndex(a));
    return this.$container.children("div:eq(" + a + ")");
};
/*
 * This is used to set content for a cell in row
 */
Row.prototype.setCell = function (index, b) {
    "string" === typeof index && (a = this.returnCellIndex(index));
    this.cells[a] !== b && (this.cells[a] = b, this.getCell(a).html(b));
};
Row.prototype.handleMouseOver = function (a) {
    $(a.fromElement).parents(".row")[0] != this.$container[0] && (a.CTRow = this, this.trigger("mouseover"));
};
Row.prototype.handleMouseOut = function (a) {
    $(a.toElement).parents(".row")[0] != this.$container[0] && (a.CTRow = this, this.trigger("mouseout"));
};