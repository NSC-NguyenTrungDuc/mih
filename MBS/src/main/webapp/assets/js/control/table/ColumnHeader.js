/*
 * This is used to make Header for table
 */
ColumnHeader = function (a) {
    a.cellsArray = a.cellsArray.map(makeDomForHeader);
    ColumnHeader.superclass_.constructor.call(this, a);
    this.parentTable = a.parentTable;
    this.$container.addClass("head");
    this.$container.children("div :not(:last-child)").on("click", this.clickHeader.bind(this))
};
Util.inherit(ColumnHeader, Row);

function makeDomForHeader(a) {
    return "<span><span>" + a + '</span></span>'
};
ColumnHeader.prototype.clickHeader = function (table) {
	if(this.parentTable.autoSorting){
	    var a = $(table.target).parents(".cell:first").length ? $(table.target).parents(".cell:first") : $(table.target),
	        b = a.prevAll().length,
	        c = !a.hasClass("sort_asc");
	//        c = !a.hasClass("sort_desc");
	  
	    this.parentTable.autoSortingDirection = c;
	    this.parentTable.autoSortingColumn=b;
	    addSortClass(this, a, c);
	   
	    this.parentTable.sorting(b, c);
	    this.parentTable.update();
	}
};

function addSortClass(header, b, flag) {
    header.$container.children(".sort_asc").removeClass("sort_asc");
    header.$container.children(".sort_desc").removeClass("sort_desc");
    flag ? b.addClass("sort_asc") : b.addClass("sort_desc")
//    flag ? b.addClass("sort_desc") : b.addClass("sort_asc")
};

function aj(a) {
    var b = a.data("contentWidth");
    b || (b = a.width(), a.data("contentWidth", b));
    return b
};
function bj(a) {
    var b = 0;
    a.find("img:visible").length && (b = 8);
    var c = a.children("span"),
        d = aj(c.children("span")) + 1,
        a = a.width() - b;
    a > d && (a = d);
    c.css({
        width: a + "px"
    })
};
ColumnHeader.prototype.update = function () {
    for (var a = this.$container.children(".cell"), b = 0; b < a.length; b++) bj($(a[b]))
};
ColumnHeader.prototype.setCell = function (a, b) {
    b = makeDomForHeader(b);
    ColumnHeader.superclass_.constructor.prototype.setCell.call(this, a, b)
};