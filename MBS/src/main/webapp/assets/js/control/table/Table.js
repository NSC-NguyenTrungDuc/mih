/**
 * @constructor
 * @inherit UIComponent
 * @param
 */
function Table(a) {
    a || (a = {});
    Table.superclass_.constructor.apply(this, arguments);
    this.autoSorting = a.autoSorting;
    this.autoSortingColumn = a.autoSortingColumn;
    this.autoSortingDirection = a.autoSortingDirection;
    

    this.$container.addClass("table");
    this.init(a.columns.map(function (a) {
        return a.header
    }));
    this.columns = a.columns.map(function (a) {
        "number" !== typeof a.weight && (a.weight = 1);
        return a
    });
    a.ROW_HEIGHT ? (this.ROW_HEIGHT = a.ROW_HEIGHT):(this.ROW_HEIGHT = 26);
    a.LAZY_PADDINGS ? ( this.LAZY_PADDINGS = a.LAZY_PADDINGS):(this.LAZY_PADDINGS = 50);
    this.cellsMargins = a.cellsMargins || 0;
    this.sd = this.nd = 0;
    this.cols = this.columns.filter(function (a) {
        return !a.unResizable
    }).length;
    this.constructor == Table && Object.seal(this);
};
Util.inherit(Table, UIComponent);
Table.prototype.sorting = function () {
    this.autoSorting && this.sortingColumn && (this.sortingColumn(this.autoSortingColumn, this.autoSortingDirection), this.update());
};
Table.prototype.clear = function () {
    this.$container.children(".row:not(.head)").remove();
    this.rows.length = 0
};
/*
 * This is used to remove a row in table with it index "b"
 */
Table.prototype.removeRow = function (b) {
    this.rows[b].$container.remove();
    this.rows.splice(b, 1);
    this.trigger("domUpdated");
};
Table.prototype.deleteAt = function (a) {
    a = this.getRowIndex(a);
    "undefined" !== typeof a && this.rows.splice(a, 1);
};
Table.prototype.getRowIndex = function (b) {
    for (var c, d = 0; d < this.rows.length; d++){ 
    	if (b === this.rows[d]) {
	        c = d;
	        break;
    	}
    }
    return c;
};
/*
 * This is used to Cell in row a and column b
 */
Table.prototype.getCell = function (a, b) {
    return this.rows[a].getCell(b)
};

Table.prototype.setCell = function (a, b, c) {
    this.rows[a].setCell(b, c)
};
function Ki(a, b, c) {
    a.head ? a.head.setCell(b, c) : a.$container.children(".head:first").children(":eq(" + b + ")").html(c)
};
Table.prototype.init = function (a) {
    "undefined" === typeof a && (a = []);
    !a instanceof Array && (a = [a]);
    this.head = new ColumnHeader({
        cellsArray: a,
        parentTable: this
    });
    this.$container.append(this.head.$container);
    this.rows = []
};
Table.ROW_HEIGHT = 26;
Table.LAZY_PADDINGS = 50;
Table.prototype.makeNewRow = function (arrayOfCell, flag) {
    b = arrayOfCell.row || arrayOfCell;
    b instanceof Array && (b = new Row({
        cellsArray: arrayOfCell,
        parentthis: this
    }));
    flag || (b.off("mouseover"), b.on("mouseover", function () {
        this.trigger("mouseover", b)
    }.bind(this)), b.off("mouseout"), b.on("mouseout", function () {
        this.trigger("mouseout", b)
    }.bind(this)));
    return b
};
Table.prototype.addRow = function (arrayOfCell, flag) {
    var c = this.makeNewRow(arrayOfCell, flag);
    this.rows.push(c);
    return c
};

Table.prototype.addRowDom = function (c) {
	this.$container.append(c.$container);
	this.updateRowWidth(c);
    this.rows.push(c);
    return c;
};

Table.prototype.updateRowWidth = function (r) {
	var $vColumn = r.$container.children("div");
    for (var i = 0; i < this.columns.length; i++){ 
    	$vColumn.eq(i).css({
            width: this.columns[i].calWidth + "px"
        });
    }
};

Table.prototype.sortingColumn=function(a, b) {
//	console.log("a is index of column ="+a +" b is direction =" +b);
	this.autoSorting = !0;
    this.autoSortingColumn = a;
    this.autoSortingDirection = b;
    for (var c = {}, d = [], e = this.rows, f = 0; f < e.length; f++) {
        var h = b ? e.length - f : f,
            h = (e[f].cells[a].data || e[f].cells[a]) + "-" + h;
        d.push(h);
        c[h] = e[f]
    }
    d.sort(function(a, c) {
        return (b ? 1 : -1) * $i(a, c)
    });
    for (f = e.length = 0; f < d.length; f++) e.push(c[d[f]])
};
function $i(a, b) {
	a=a.replace(',','');
	b=b.replace(",","");
	var _ai=a.lastIndexOf('-');
	var _bi=b.lastIndexOf('-');
	a=a.substring(0, _ai);
	if(a=='-') a=0;
	b=b.substring(0, _bi);
	if(b=='-') b=0;
    var c = parseFloat(a, 10),
        d = parseFloat(b, 10);
    
      // var kq= isNaN(a) || isNaN(b) ? a > b ? 1 : -1 : c - d;
       var kq2;
       if(isNaN(a) || isNaN(b)){
    	   if(a > b){
    		   kq2= 1;
//    		   console.log("a ="+a+" b ="+b+"  return a > b="+1);
    	   }else{
//    		   console.log("a ="+a+" b ="+b+"  return a <= b=-"+1);
    		   kq2= -1;
    	   }
    	   
       }else{
     	   kq2= c-d;
//    	   console.log("a ="+a+" b ="+b+"  return c-d="+kq2);
       }
       

    return kq2;
};

Table.prototype.update = function () {
    this.updateDom();
    this.setWidth();
    this.head.update();    
};

Table.prototype.updateSize = function () {
    this.setWidth();
};

Table.prototype.setWidth = function() {
    var b = this.columns.length,
        widthOfthis = this.$container.width() - this.cellsMargins,
        sumOfWeight = 0,
        availableWidth, f;
    this.columns.forEach(function (a) {
        if("number" === typeof a.width){
        	widthOfthis -= a.width;
        	b--;
        }else{
        	 sumOfWeight += a.weight;
        }
    });
    if (!(0 >= widthOfthis)) {
        availableWidth = widthOfthis ;
        /*
         * Calculate width for each column
         */
        for (f = 0; f < this.columns.length; f++) {
            var col = this.columns[f];
            var n;
            var m;
            if("number" === typeof col.width){
            	n = col.width;
            	m = Math.floor(n + availableWidth - widthOfthis);
            }
            else{
            	n = widthOfthis * col.weight / sumOfWeight;
            	m = Math.floor(n + availableWidth - widthOfthis);
            	sumOfWeight -= col.weight;
            	availableWidth -= m;
            	widthOfthis -= n;
            } 
            this.columns[f].calWidth = m;
        }
        var $visibleRows = this.$container.children();//".row:visible");
        /*
         * Navigate all cell to set width
         */
        var $vRow, $vColumn;
        for (var e = 0; e < $visibleRows.length; e++) {
        	$vRow = $visibleRows.eq(e);
        	$vColumn = $vRow.children("div");
            for (var i = 0; i < this.columns.length; i++){ 
            	$vColumn.eq(i).css({
	                width: this.columns[i].calWidth + "px"
	            });
            }
        }
    }
};
//Table.ROW_HEIGHT = 26;
//Table.LAZY_PADDINGS = 50;
Table.prototype.render = function (a, b) {
    this.nd = calculateNumberRows(a,this);
    this.sd = calculateMaxRows(a, b,this);
    this.update()
};

Table.prototype.updateDom = function () {
    var b = this.nd,
        c = this.rows.length - 1;
    this.$container.css({
        "padding-top": b * this.ROW_HEIGHT + "px",
        "padding-bottom": Math.max(this.rows.length - c - 1, 0) * this.ROW_HEIGHT + "px"
    });
    this.$container.children().detach();
    this.$container.append(this.head.$container);
    for (""; b <= c; b ++) {
    	this.$container.append(this.rows[b].$container);
    };
    this.trigger("domUpdated");
};

function calculateNumberRows(a,table) {
    a = Math.max(a - table.LAZY_PADDINGS, 0);
    return Math.floor(a / table.ROW_HEIGHT)
};
function calculateMaxRows(a, b,table) {
    var c = a + b + table.LAZY_PADDINGS;
    return Math.floor(c / table.ROW_HEIGHT)
};
Table.prototype.resetNumberRows = function () {
    this.sd = this.nd = 0
};