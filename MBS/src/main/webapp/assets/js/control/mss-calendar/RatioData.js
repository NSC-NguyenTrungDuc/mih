/**
 * @constructor
 * @inherit UIComponent
 * @param
 */
function RatioData(a) {
    a || (a = {});
    RatioData.superclass_.constructor.apply(this, arguments);
    this.total = a.total;
    this.filled = a.filled;
};
Util.inherit(RatioData, CellData);
RatioData.prototype.toHtml = function () {
    // Check if filled greater than 0. NghiaNM
    if (this.filled > 0) {
        return "<a href='#' style='color:#27ae61;'>" + this.filled + "/" + this.total + "</a>";
    } else {
        return "<a href='#'>" + this.filled + "/" + this.total + "</a>";
    }
};