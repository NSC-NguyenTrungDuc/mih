var DateFormatter = { 
		ddMMyyyyHHmm : 'dd/MM/yyyy HH:mm',
		ddMMyyyyHHmmss : 'dd/MM/yyyy HH:mm:ss',
		yyyyMMddHHmmss : 'yyyy/MM/dd HH:mm:ss',
		yyyyMMddHHmm : 'yyyy/MM/dd HH:mm',
		yyyyMMddHHmm2 : 'yyyy.MM.dd HH:mm',
		yyyyMMddHHmmss1 : 'yyyy-MM-dd HH:mm:ss',
		MMddyyyyHHmmss : 'MM/dd/yyyy HH:mm:ss',
		yyyyMMddHHmmss2 : 'yyyy.MM.dd HH:mm:ss'
};
var dpFormatArr = DateFormatter.yyyyMMddHHmm2.split(" ");
var DatePickerFormatter = {
		dateFormat : dpFormatArr[0].toLowerCase().replace('yyyy', 'yy'),
		timeFormat : dpFormatArr[1].toLowerCase()		
}; 
var orderTypes = new Object ({ 'buy': '0', 'sell': '1'  });
// Define array of days in weeks
var Util = {} ;
function error(a) {
    throw a;
};

var NumberFormatter = {
	LOT : { format : "#,##0.00", locale:"us" },	
	PIP : { format : "#,##0.0", locale:"us" }, 	
	SWAP : { format : "#,##0.00", locale:"us" },
	FEE : { format : "#,##0.00", locale:"us" },
	PRICES: new Array (
			{ format : "#,##0", locale:"us" }, // Zero digit
			{ format : "#,##0.0", locale:"us" }, // Must 1 digit
			{ format : "#,##0.00", locale:"us" }, // Must 2 digits
			{ format : "#,##0.000", locale:"us" }, // Must 3 digits
			{ format : "#,##0.0000", locale:"us" }, // Must 4 digits
			{ format : "#,##0.00000", locale:"us" }, // Must 5 digits
			{ format : "#,##0.000000", locale:"us" }, // Must 6 digits
			{ format : "#,##0.0000000", locale:"us" }, // Must 7 digits
			{ format : "#,##0.00000000", locale:"us" }, // Must 8 digits
			{ format : "#,##0.000000000", locale:"us" }  // Must 9 digits			
		),
	PL: new Array (
			{ format : "#,##0", locale:"us" }, // Zero digit
			{ format : "#,##0.0", locale:"us" }, // Must 1 digit
			{ format : "#,##0.00", locale:"us" }, // Must 2 digits
			{ format : "#,##0.000", locale:"us" }, // Must 3 digits
			{ format : "#,##0.0000", locale:"us" }, // Must 4 digits
			{ format : "#,##0.00000", locale:"us" }, // Must 5 digits
			{ format : "#,##0.000000", locale:"us" }, // Must 6 digits
			{ format : "#,##0.0000000", locale:"us" }, // Must 7 digits
			{ format : "#,##0.00000000", locale:"us" }, // Must 8 digits
			{ format : "#,##0.000000000", locale:"us" }  // Must 9 digits			
		)	
};

Util.DAYS = "Sunday Monday Tuesday Wednesday Thursday Friday Saturday".split(" ");
// Define array of abreviation month in year
Util.MONTHS = "Jan Feb Mar Apr May Jun Jul Aug Sep Oct Nov Dec".split(" ");
// Define array of full month in year
Util.FULLMONTHS = "January February March April May June July August September October November December".split(" ");
// initBranding call ajax to load config file
Util.initBranding = function (url) {
    var a = window.location.href.substr(7).split(".")[0].replace(/-ct$/, "").replace("-", "_");
    window.process ? (a = fs.readFileSync("./common/branding/dev/js/config.js", "utf-8"), gb(a)) : $.ajax({
        url: "common/branding/" + a + "/js/config.js",
        type: "GET",
        dataType: "text",
        async: p,
        success: function (a) {
            gb(a)
        },
        error: function () {
            $.ajax({
                url: "common/branding/spotware/js/config.js",
                type: "GET",
                dataType: "text",
                async: p,
                success: function (a) {
                    gb(a)
                }
            })
        }
    })
};

// Disable all event when start
Util.disableSelections = function () {
    document.onselectstart = function (a) {
        return a.target instanceof HTMLTextAreaElement || a.target instanceof HTMLInputElement || $(a.target).parents().find(".edited").length
    }
};
// Convert to number with format 0a, if a < 10
Util.zeroPad = function (a) {
    a = new String(a);
    return 1 === a.length ? "0" + a : a
};
Util.padleft = function(val, ch, num) {
    var re = new RegExp(".{" + num + "}$");
    var pad = "";
    if (!ch) ch = " ";
    do  {
        pad += ch;
    }while(pad.length < num);
    return re.exec(pad + val)[0];
};
Util.padright = function(val, ch, num){
    var re = new RegExp("^.{" + num + "}");
    var pad = "";
    if (!ch) ch = " ";
    do {
        pad += ch;
    } while (pad.length < num);
    return re.exec(val + pad)[0];
};

Util.getUrlParams = function () {
    for (var a = window.location.href, b = {}, a = a.slice(a.indexOf("?") + 1).split("&"), c = 0; c < a.length; c++) {
        var d = a[c].split("=");
        b[d[0]] = decodeURIComponent(d[1])
    }
    return b
};
// Creat bind prototype for Function Object
"undefined" === typeof Function.prototype.bind && (Function.prototype.bind = function (a) {
    var b = this;
    return function () {
        b.apply(a, arguments)
    }
});
Util.roundMoney = function (a) {
    return Math.round(a * 100) / 100
};

// Format date with format of  date month year
Util.formatDate = function (a) {
    return a.getDate() + " " + Util.MONTHS[a.getMonth()] + " " + a.getFullYear()
};

// Format date with format of UTC date/month/year
Util.formatDateShort = function (a) {
    return Util.zeroPad(a.getDate()) + "/" + Util.zeroPad(a.getMonth() + 1) + "/" + a.getFullYear();
};
Util.formatMonth = function (a) {
    return a.getDate() + " " + Util.MONTHS[a.getMonth()]
};
// Format date time , a is String of date
Util.formatDateTime = function (a, b) {
    var c = new Date(a),
        d = c.getDate() + " " + Util.MONTHS[c.getMonth()] + " " + c.getFullYear();
    b && (d = d + (" " + Util.zeroPad(c.getHours()) + ":" + Util.zeroPad(c.getMinutes())));
    return d
};
Util.formatDateTimeShort = function (a) {
    if (!a) return "-";
    a = new Date(a);
    return Util.zeroPad(a.getDate()) + "/" + Util.zeroPad(a.getMonth() + 1) + "/" + a.getFullYear() + " " + Util.zeroPad(a.getHours()) + ":" + Util.zeroPad(a.getMinutes())
};
Util.formatTime = function (a) {
    return Util.zeroPad(a.getHours()) + ":" + Util.zeroPad(a.getMinutes())
};
// To quantize a number based a quantize
Util.quantizeUp = function (a, b) {
    return Math.ceil(a / b) * b
};
Util.quantizeDown = function (a, b) {
    return Math.floor(a / b) * b
};

Util.dayTimeToUTC = function (a, b, c, d, e) {
    c !== 0 && (new Date(d) < Date.now() && new Date(e) > Date.now()) && (b = b + c);
    a = a - b * 60;
    a < 0 && (a = a + 1440);
    return a
};
// Inhertit to make relationship between to object
// A is child object
// B is super object
// A contain .superclass_ to access the function of B
//           .constructor to access to itself and implement the new function
Util.inherit = function (a, b) {
    function c() {}
    a || error("Inherit - child undefined!");
    b || error("Inherit - parent undefined!");
    var d = a.prototype;
    c.prototype = b.prototype;
    a.prototype = new c;
    for (var e = (Object.getOwnPropertyNames(d)), f = 0; f < e.length; f++) {
        if (d.hasOwnProperty(e[f])) {
	        var i = Object.getOwnPropertyDescriptor(d, e[f]);
	        Object.defineProperty(a.prototype, e[f], i);
    }
    }
    a.prototype.constructor = a;
    a.superclass_ = b.prototype;
};

// extend to make b extend c
// b will got all the properties and functions of c
Util.extend = function hb(b, c, d) {
    b || error("Extend - class undefined!");
    c || error("Extend - trait undefined!");
    var e = c,
        f = d ? b : b.prototype;
    c.prototype && hb(b, c.prototype, d);
    for (var i in e)(b = Object.getOwnPropertyDescriptor(e, i)) && Object.defineProperty(f, i, b)
};
Util.spawnDomElement = function ib(b) {
    if (!ib.$container) ib.$container = $('<div id="spawning_pool"/>').css({
        width: 0,
        height: 0,
        overflow: "hidden",
        position: "relative"
    }).appendTo(document.body);
    return $(b).appendTo(ib.$container)
};
String.prototype.replaceAll = function(
		strTarget, // The substring you want to replace
		strSubString // The string you want to replace in.
		){
		var strText = this;
		var intIndexOfMatch = strText.indexOf( strTarget );
		 
		// Keep looping while an instance of the target string
		// still exists in the string.
		while (intIndexOfMatch != -1){
		// Relace out the current instance.
		strText = strText.replace( strTarget, strSubString )
		 
		// Get the index of any next matching substring.
		intIndexOfMatch = strText.indexOf( strTarget );
		}
		 
		// Return the updated string with ALL the target strings
		// replaced out with the new substring.
		return( strText );
		}
Util.sprintf = function () {
    for (var a = arguments[0], b = 1; b < arguments.length; b++){
    	a = a.replaceAll("{" + (b - 1) + "}", arguments[b]);
    }
    return a
};

// Include script to add script a to a page
// When a in onLoad, it will execute function b
// If Loading a fail , it will execute function c
Util.includeScript = function (a, b, c) {
	if (a != null){
		   var d = document.createElement("script");
		    d.src = a;
		    document.body.appendChild(d);
		    d.onload = b;
		    d.onerror = c
	}
};

// Replace escape in html
Util.escapeHtml = function (a) {
    return a.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;")
};

// Check an input is email
Util.isEmail = function (a) {
    var b = /^([a-zA-Z0-9_\.\-])+@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/i;
    return b.test(a)
};
Util.splitQuoteValue = function (a, b, c) {
    typeof a != "string" && (a = "" + a);
    for (var d = a.indexOf("."); a.length - d < c + 1;) a = a + "0";
    var c = a.substring(0, d + (b - 1)),
        e = a.substring(d + (b - 1), d + b + 1),
        a = a.substring(d + b + 1, a.length);
    return {
        first: c,
        pips: e,
        last: a
    }
};
// Detect browser and add class with each browser
// If browser is mozilla -> addClass('mozilla)
// If browser is ie => addClass('msie')
// If browser is chrome => addClass('chrome')
// If browser is safari => addClass('safari')
Util.enableBrowserDetectionForCSS = function () {
    $.browser.chrome = $.browser.webkit && /chrome/.test(navigator.userAgent.toLowerCase());
    $.browser.safari = !$.browser.chrome && $.browser.webkit;
    $.browser.mozilla && $(document.body).addClass("mozilla");
    $.browser.msie && $(document.body).addClass("msie");
    if ($.browser.chrome) {
        $(document.body).addClass("chrome");
        $(document.body).addClass("webkit")
    }
    if ($.browser.safari) {
        $(document.body).addClass("safari");
        $(document.body).addClass("webkit")
    }
};

// Convert Integer to String with a spaced at lead
Util.convertIntegerToSpacedString = function (a) {
    for (var a = "" + a, b = "", c = a.length - 1; c >= 0; c = c - 3) b = " " + (a[c - 2] || "") + (a[c - 1] || "") + (a[c] || "") + b;
    return b
};
Util.attachShared = function (a, b) {
    for (var c in b) if (b.hasOwnProperty(c)) {
        a.__defineGetter__(c, function () {
            var a = c;
            return function () {
                return b[a]
            }
        }());
        a.__defineSetter__(c, function () {
            var a = c;
            return function (c) {
                b[a] = c;
                b.trigger("change_" + a)
            }
        }())
    }
};
Util.expandNumber = function (a) {
    var b = 1;
    if (a.length > 0) 
    switch (a[a.length - 1]) {
        case "k":
            b = 1E3;
            break;
        case "m":
            b = 1E6
    }
    return b > 1 ? Number(a.substr(0, a.length - 1)) * b : Number(a)
};
Util.collapseNumber = function (a) {
    typeof a == "number" && (a = a.toFixed(0));
    a === h && (a = "");
    return a.replace(/0{6}$/, "m").replace(/0{3}$/, "k")
};
Util.collapseNumber2 = function (a) {
    typeof a == "string" && (a = new Number(a));
    var b = "";
    if (a >= 1E6) {
        a = a / 1E6;
        b = "m"
    } else if (a >= 1E3) {
        a = a / 1E3;
        b = "k"
    }
    return a.toFixed(2).replace(/0*$/, "").replace(/\.$/, "") + b
};

// Format number with default params
// digit after dots
// space splitters
Util.FORMAT_NUMBER_DEFAULT_PARAMS = {
    spaceSplitters: !0,
    digitsAfterDot: 2
};
// Format price with digitsAfterDot default
Util.formatPrice = function (a) {
    return a != void 0 && !isNaN(a) ? Util.formatNumber(a, Util.FORMAT_NUMBER_DEFAULT_PARAMS) : "-"
};
// Format a number to percent
Util.formatPercent = function (a) {
    return Util.formatNumber(a * 100, Util.FORMAT_NUMBER_DEFAULT_PARAMS) + "%"
};

// Format number : a is number, b is Util.FORMAT_NUMBER_DEFAULT_PARAMS contain 2 params 
Util.formatNumber = function (a, b) {
	if(!b) b = { };
	b.spaceSplitters = true,
	dAfterDot = b.digitsAfterDot;	
    var a = Number(String(a).replace(/\s/g, "")),
        c = a > 0 ? Math.floor(a) : -Math.ceil(a),
        c = b.spaceSplitters ? Util.convertIntegerToSpacedString(c) : "" + c;
        if(dAfterDot && !isNaN(dAfterDot) && dAfterDot > 0) {
        	c = c + ("." + a.toFixed(dAfterDot).split(".")[1]);	
        } else {
        	c = c + ("." + a.toString().split(".")[1]);
        }
        
    c = c.substring(1);
    return a >= 0 ? c : "-" + c
};
Util.mouseEventToChartY = function (a, b) {
    return x(a, Math.min(a.viewHeight, b.pageY - a.$container.offset().top))
};
Util.getRequestAnimationFrameFunction = function () {
    return window.webkitRequestAnimationFrame || window.mozRequestAnimationFrame || window.msRequestAnimationFrame || window.requestAnimationFrame || setTimeout
};
Util.makeLazy = function (a) {
    function b() {
        a.apply(e, d);
        d = [];
        c = !1
    }
    var c = !1,
        d = [],
        e;
    return function () {
        d = arguments;
        e = this;
        if (!c) {
            c = !0;
            Util.getRequestAnimationFrameFunction()(b)
        }
    }
};
// Check a number or array of number
Util.checkNumber = function () {
    for (var a = 0; a < arguments.length; a++) {
        var b = arguments[a],
            c;
        try {
            g("Stack:")
        } catch (d) {
            c = d
        }
        if (typeof b !== "number") {
            console.error("non-numeric type: " + b, c);
            return p
        }
        if (isNaN(b)) {
            console.error("NaN value!", c);
            return p
        }
        if (!isFinite(b)) {
            console.error("Infinity value!", c);
            return p
        }
        if (b === h) {
            console.error("Undefined value!", c);
            return p
        }
    }
    return !0
};
Util.Zd = function (a, b) {
    typeof a == "string" && (a = a.trim().split(/\s+/));
    b = b || this.namespace;
    return a.map(function (a) {
        return a + b
    }).join(" ")
};
Util.tmpl = function pb(b, c) {
    pb.reg_placeholders = pb.reg_placeholders || /\{(.*?)\}/g;
    pb.reg_params_inside = pb.reg_params_inside || /%\w+/g;
    pb.parse = pb.parse || function (b, c) {
        return b.replace(pb.reg_placeholders, function (b, d) {
            var k = d.replace(pb.reg_params_inside, function (b) {
                b = b.substr(1);
                b = c[b];
                return typeof b != "function" ? JSON.stringify(b) : b.toString()
            });
            try {
                return Function("return " + k)()
            } catch (n) {
                console.info(n.message, ":", k);
                return d
            }
        })
    };
    if (Array.isArray(c)) return c.map(function (c) {
        return pb(b, c)
    }).join("");
    if (arguments.length > 2 || typeof c != "object") c = $.makeArray(arguments).slice(1);
    return pb.parse(b, c)
};
Util.throttle = function (a) {
    var b = 150,
        c, d, e, f, i, k, n = jb(function () {
            i = f = p
        }, b);
    return function () {
        function m() {
            e = l;
            i && a.apply(c, d);
            n()
        }
        c = this;
        d = arguments;
        e || (e = setTimeout(m, b));
        f ? i = !0 : k = a.apply(c, d);
        n();
        f = !0;
        return k
    }
};
// Array equal
Util.arrayEqual = function (a, b) {
    return !!a && !! b && !(a < b || b < a)
};
Util.extrapolateLine = function (a, b, c, d, e, f) {
    var i = d - b,
        k = c - a;
    if (k == 0) {
        if (i == 0) return {
            x: c,
            y: d
        };
        b = d > b ? f : 0;
        return {
            x: c,
            y: b
        }
    }
    c = k > 0 ? e : 0;
    a = c - a;
    i = i / k * a;
    return {
        x: c,
        y: b + i
    }
};
Util.lineAngle = function (a, b, c, d) {
    var e = d - b,
        a = c - a;
    if (a == 0) return e == 0 ? 0 : b > d ? 90 : 270;
    b = a > 0 ? e > 0 ? 360 : 0 : 180;
    return b - Math.atan(e / a) * 360 / (Math.PI * 2)
};

//This function is used to  clone an object
Util.clone = function (a) {
	return jQuery.extend(true, {}, a);
};
Util.getMouseWheelDelta = function (a) {
    var b = a.originalEvent;
    if (b = b.detail ? b.detail * -1 : b.wheelDelta) {
        b = b / Math.abs(b);
        a.type === "DOMMouseScroll" && (b = -b);
        return b
    }
    return 0
};

Util.swapItems = function (a) {
    var a = $.extend({
        data: [],
        items: [],
        offset: "",
        callback: t()
    }, a),
        b = a.data,
        c = a.offset,
        d = a.items[0],
        e = a.items[1],
        f = b.indexOf(d),
        i = b.indexOf(e);
    if (f != -1 && i != -1) {
        if (c) {
            b.splice(f, 1);
            i = b.indexOf(e) + (c == "right" ? 1 : 0);
            b.splice(i, 0, d)
        } else {
            b[f] = e;
            b[i] = d
        }
        a.callback(c)
    }
};
var jb = Util.debounce = function (a, b, c) {
    function d() {
        function d() {
            e = null;
            c || a.apply(i, k)
        }
        var i = this,
            k = arguments;
        c && !e && a.apply(i, k);
        clearTimeout(e);
        e = setTimeout(d, b)
    }
    var e;
    d.source = a;
    d.stop = function () {
        clearTimeout(e)
    };
    return d
}, mb = function kb(b, c) {
    (!b || !b[c]) && error(Error("Argument is not exists"));
    if (b[c].type !== kb) {
        var d = function () {
            d.args = arguments;
            d.cont = this;
            d.isCalled = !0
        };
        d.src = b[c];
        d.isCalled = !1;
        d.type = kb;
        b.hasOwnProperty(c) ? b[c] = d : b.constructor.prototype[c] = d;
        if (d.src.type === lb) {
            d.src.isFrozen = d;
            d.src.rpl = d
        }
    }
};

function nb(a, b) {
    var c = a[b];
    (!c || !c.src) && g(Error("Argument does not exist!"));
    if (a[b].type === mb) {
        a.hasOwnProperty(b) ? a[b] = c.src : a.constructor.prototype[b] = c.src;
        if (c.src.type === lb) {
            c.src.isFrozen = p;
            delete c.src.rpl
        }
        c.isCalled && a[b].apply(c.cont, c.args)
    }
};
var lb = function ob(b, c, d) {
    (!b || !b[c]) && error(Error("Argument does not exist!"));
    var e = b[c];
    if (!(b[c].type === ob || b[c].type === mb)) {
        var f = function () {
            return f.isFrozen ? f.rpl.apply(this, arguments) : e.apply(this, arguments)
        };
        f.type = ob;
        f.isFrozen = !! d;
        b[c] = f
    }
};
Util.freezeFunction = mb;
Util.unfreezeFunction = nb;
Util.prepareFreezeFunction = lb;
Util.getDateTimeFromMT4 = function (a) {
	 if (!a) return "-";    
	 var d = new Date(getDateFromFormat(a, SERVER_TIME_FORMAT)); 
	 return formatDate(d, DateFormatter.yyyyMMddHHmm2);
};
/**
 * Show the time in the client time zone
 * */
Util.getTimeOnClientZone = function (a, inputDateFormatter, outputDateFormatter) {
	if (!a) return  "-";
	if (!inputDateFormatter) inputDateFormatter = SERVER_TIME_FORMAT;
	if (!outputDateFormatter) outputDateFormatter = DateFormatter.yyyyMMddHHmm2;
	var d = getDateFromFormat(a, inputDateFormatter);
	// Convert to client time zone 
	d = d + ((TIME_ZONE.client - TIME_ZONE.server) * 60 * 60 * 1000);
	return formatDate(new Date(d), outputDateFormatter);
};

Util.getTimeOnServerZone = function (a, inputDateFormatter, outputDateFormatter) {
	if (!a) return  "-";
	if (!inputDateFormatter) inputDateFormatter = SERVER_TIME_FORMAT;
	if (!outputDateFormatter) outputDateFormatter = DateFormatter.yyyyMMddHHmm2;
	var d = getDateFromFormat(a, inputDateFormatter);
	// Convert to client time zone 
	d = d + ((TIME_ZONE.server - TIME_ZONE.client) * 60 * 60 * 1000);
	return formatDate(new Date(d), outputDateFormatter);
};

Util.getNewFormatedDate = function (d, oldFormatter, newFormatter) {
	if(!d) return '-';
	var nD = new Date(getDateFromFormat(d, oldFormatter));
	return formatDate(nD, newFormatter);
};

Util.getDateTimeFromMe = function (a) {
    if (!a) return "-";
    var year = a.substring(0,4);
    var month = a.substring(4,6) - 1;
    var day = a.substring(6,8);
    var hour = a.substring(9,11);
    var min = a.substring(12,14);
    var sec = a.substring(15,17);
    a = new Date(year,month,day,hour,min,sec);
    return a;
//    return Util.zeroPad(a.getUTCDate()) + "/" + Util.zeroPad(a.getUTCMonth() + 1) + "/" + a.getUTCFullYear() + " " + Util.zeroPad(a.getUTCHours()) + ":" + Util.zeroPad(a.getUTCMinutes())
};
Util.formatDateTimeFollowLanguage = function(a,lang){
	var a = Util.getDateTimeFromMe(a);
	if(a =="-") return a
	if(lang == "en"){
		return Util.zeroPad(a.getUTCDate()) + "/" + Util.zeroPad(a.getUTCMonth() + 1) + "/" + a.getUTCFullYear() + " " + Util.zeroPad(a.getUTCHours()) + ":" + Util.zeroPad(a.getUTCMinutes())
	}
	else if(lang =="ja"){
		return a.getUTCFullYear()  + "/" + Util.zeroPad(a.getUTCMonth() + 1) + "/" + Util.zeroPad(a.getUTCDate()) + " " + Util.zeroPad(a.getUTCHours()) + ":" + Util.zeroPad(a.getUTCMinutes())
	}
};
Util.convertDateToServerDate = function(a){
	a = new Date(a);
	return a.getFullYear()  + Util.zeroPad(a.getMonth() + 1) + Util.zeroPad(a.getDate()) + " " + Util.zeroPad(a.getHours()) + ":" + Util.zeroPad(a.getMinutes()) +":"+Util.zeroPad(a.getSeconds())
};
Util.formatTimeFollowLanguage = function(a,lang){
	if(a == null ) return a
	if(lang == "en"){
		return Util.zeroPad(a.getDate()) + "/" + Util.zeroPad(a.getMonth() + 1) + "/" + a.getFullYear() + " " + Util.zeroPad(a.getHours()) + ":" + Util.zeroPad(a.getMinutes())+ ":"+ +Util.zeroPad(a.getSeconds());
	}
	else if(lang =="ja"){
		return a.getFullYear()  + "/" + Util.zeroPad(a.getMonth() + 1) + "/" + Util.zeroPad(a.getDate()) + " " + Util.zeroPad(a.getHours()) + ":" + Util.zeroPad(a.getMinutes())+":"+ +Util.zeroPad(a.getSeconds());
	}
};
Util.formatShortTimeFollowLanguage = function(a,lang){
	if(a == null ) return a
	if(lang == "en"){
		return Util.zeroPad(a.getDate()) + "/" + Util.zeroPad(a.getMonth() + 1) + "/" + a.getFullYear() + " " + Util.zeroPad(a.getHours()) + ":" + Util.zeroPad(a.getMinutes());
	}
	else if(lang =="ja"){
		return a.getFullYear()  + "/" + Util.zeroPad(a.getMonth() + 1) + "/" + Util.zeroPad(a.getDate()) + " " + Util.zeroPad(a.getHours()) + ":" + Util.zeroPad(a.getMinutes());
	}else{
		return Util.zeroPad(a.getMonth() + 1) + "/" +  Util.zeroPad(a.getDate())  + "/" + a.getFullYear() + " " + Util.zeroPad(a.getHours()) + ":" + Util.zeroPad(a.getMinutes());
	}
};
Util.addCommas = function(nStr) {
    nStr += '';
    var x = nStr.split('.');
    var x1 = x[0];
    var x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
};
/*
 * This fucntion is used to calculate the distance between 2 date
 * Use the keyword interval with " years, months,weeks,days,hours,minutes,seconds"
 * to set type for return
 */
Util.getDateDiff = function(date1, date2, interval) {
    var second = 1000,
    minute = second * 60,
    hour = minute * 60,
    day = hour * 24,
    week = day * 7;
    date1 = new Date(date1).getTime();
    date2 = (date2 == 'now') ? new Date().getTime() : new Date(date2).getTime();
    var timediff = date2 - date1;
    if (isNaN(timediff)) return NaN;
    switch (interval) {
    case "years":
        return date2.getFullYear() - date1.getFullYear();
    case "months":
        return ((date2.getFullYear() * 12 + date2.getMonth()) - (date1.getFullYear() * 12 + date1.getMonth()));
    case "weeks":
        return Math.floor(timediff / week);
    case "days":
        return Math.floor(timediff / day);
    case "hours":
        return Math.floor(timediff / hour);
    case "minutes":
        return Math.floor(timediff / minute);
    case "seconds":
        return Math.floor(timediff / second);
    default:
        return undefined;
    }
};
function getInternetExplorerVersion()
//Returns the version of Windows Internet Explorer or a -1
//(indicating the use of another browser).
{
	var rv = -1; // Return value assumes failure.
	if (navigator.appName == 'Microsoft Internet Explorer')
	{
	   var ua = navigator.userAgent;
	   var re  = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
	   if (re.exec(ua) != null)
	      rv = parseFloat( RegExp.$1 );
	}
	return rv;
}
function getSendingTime() {
	var d = new Date();
	var curr_date = d.getDate();
	var curr_month = d.getMonth() + 1;
	// Months are zero based
	var curr_year = d.getFullYear();
	var curr_hour = d.getHours();
	var curr_minute = d.getMinutes();
	var curr_second = d.getSeconds();
	return curr_year + "" + Util.zeroPad(curr_month) + "" + Util.zeroPad(curr_date) + " " + Util.zeroPad(curr_hour) + ":"
			+ Util.zeroPad(curr_minute) + ":" + Util.zeroPad(curr_second);
};
function getStartTimeOfDay() {
	var d = new Date();
	var curr_date = d.getDate();
	var curr_month = d.getMonth() + 1;
	// Months are zero based
	var curr_year = d.getFullYear();
	var curr_hour = "00";
	var curr_minute = "00";
	var curr_second = "01";
	return curr_year + "" + curr_month + "" + curr_date + " " + curr_hour + ":"
			+ curr_minute + ":" + curr_second;
};
Util.disableSelectionElement = function(element){
	$(element).addClass('disableSelection');
};
Util.isBlankString = function(str) {
    return (!str || /^\s*$/.test(str));
};
Util.isEmpty = function(str) {
    return (!str || 0 === str.length);
};
Util.roundNumber = function(a,number){
	var temp = Math.pow(10,number);
	return Math.round(a * temp) / temp
};
Util.formatTimeFromTimeStamp = function(a){
	var date = a.replace(/-/g,"");
	return date.replace(/T/g,' ');
};
Util.formatDateFromTsToStandard = function(a){
	var year = a.substring(0,4)||'';
	var mon = a.substring(5,7)||'';
	var day = a.substring(8,10)||'';
	var hour = a.substring(11,13)||'';
	var min = a.substring(14,16)||'';
	var secs = a.substring(17,19)||'';
	return mon + '/'+ day + '/'+ year +' '+ hour +':'+min+':'+secs;
};
Util.convertDateToServerDate2 = function(a){
	var d = new Date(getDateFromFormat(a, DateFormatter.yyyyMMddHHmm2));
	return formatDate(d, DateFormatter.yyyyMMddHHmmss1);	
};
Util.convertSeltDate = function(a){
	var year = a.substring(0,4)||'';
	var mon = a.substring(4,6)||'';
	var day = a.substring(6,8)||'';
	return mon  +"/"+ day +'/'+ year;
};
Util.formatDateShort2 = function (a) {
    return a.getFullYear() + "/"  + Util.zeroPad(a.getMonth() + 1) + "/"+  Util.zeroPad(a.getDate());
};
Util.convertDateToServerDate3 = function(a){
	a = new Date(a);
	return a.getFullYear()  + Util.zeroPad(a.getMonth() + 1) + Util.zeroPad(a.getDate())
}
Util.convertDateToServerDate4 = function(a){
	var year = a.substring(0,4)||'';
	var mon = a.substring(4,6)||'';
	var day = a.substring(6,8)||'';
	return year + "/" + mon +'/' +  day;
}
Util.formatshortDateFromTs = function(a){
	var year = a.substring(0,4)||'';
	var mon = a.substring(5,7)||'';
	var day = a.substring(8,10)||'';
	var hour = a.substring(11,13)||'';
	var min = a.substring(14,16)||'';
	return mon + '/'+ day + '/'+ year +' '+ hour +':'+min;
};
Util.convertJaToStandard = function(a){
	var day = a.substring(3,5)||'';
	var mon = a.substring(0,2)||'';
	var year = a.substring(6,10)||'';
	var hour = a.substring(11,13)||'';
	var min = a.substring(14,16)||'';
	var sec = a.substring(17,19)||'';
	return day + '/'+ mon + '/'+ year +' '+ hour +':'+min+':'+sec;
};

Util.convertToShordDate = function(a){
	var year = a.substring(0,4)||'';
	var mon = a.substring(4,6)||'';
	var day = a.substring(6,8)||'';
	return year  +"/"+ mon +'/'+ day;
};

Util.formateNumber = function(number) {
    return number.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
};

/**
 * Fix bug for select all text by click Cltr + A
 * */
Util.disableSelectText = function(){
	var ctrPressing = false;
	$(':not(input, select, textarear)').keydown(function(e){		
		if(e.keyCode == 17){
			ctrPressing = true;	
		}
		if(ctrPressing == true && e.keyCode == 65){		
			e.preventDefault();
		}
	}).keyup(function(e){
		if(e.keyCode == 17){
			ctrPressing = false;
		}
	});
};

Util.releaseConnection = function(){
	console.log('Begin closing socket when request time out');	
	$("#logout_msg_black").show();
	$.cookie(CLIENT_CLEAR_SESSION, 1);
	$.cookie(SERVER_CLEAR_SESSION, 1);	
	if (WTD.connectionManager) WTD.connectionManager.CONNECTION_READY = false;	
	if (WTD.connectionManager) WTD.connectionManager.connections.Rate.socket && WTD.connectionManager.connections.Rate.socket.close();
	if (WTD.connectionManager) WTD.connectionManager.connections.Order.socket && WTD.connectionManager.connections.Order.socket.close();
	console.log('End closing socket when request time out');
};

Util.disableMultipleClick = function (button, e, delayTime) {
	var button = $(button);
	if (button.attr('disabled') == 'disabled') {
		e.stopPropagation();
		return false;
	}	
	button.attr("disabled", "disabled");
	setTimeout(function() {
		button.removeAttr("disabled");		
	}, delayTime);
	return true;
};
/**
 * Remove zero repeated many time
 * */
Util.rightFloat = function (floatVal) {
	return parseFloat(floatVal.toFixed(15));
	
};
/**
 * Prevent the wrong result when minus 2 number
 * */
Util.rightMinus = function (num1, num2) {
	var maxNumOfDecimals = Math.max (Util.decimalPlaces(num1), Util.decimalPlaces(num2));	
	return  parseFloat((num1 - num2).toFixed(maxNumOfDecimals));
};

Util.decimalPlaces = function (num) {
	if (!num) return 0; 
		
	var match = (num.toString()).match(/(?:\.(\d+))?(?:[eE]([+-]?\d+))?$/);
	if (!match) { return 0; }
	return Math.max( 0,
       // Number of digits right of decimal point.
       (match[1] ? match[1].length : 0)
       // Adjust for scientific notation.
       - (match[2] ? + match[2] : 0));
};

Util.isPositiveInteger = function (value) {
	if (value.toString() == "0") {
		return true;
	}
	return (/^[1-9]([0-9])*$/).test(value.toString());	
};
/**
 * Bind the allow numeric to textbox
 * */
Util.allowPositiveInteger = function (textBoxObj) {
	textBoxObj.keyup(function() {
		var newValue = this.value.replace(/([^0-9.])/g,''); // Remove the text character		
		if (newValue && newValue != '') {
			newValue = parseInt(newValue).toString();
		}		
		this.value = newValue;
	}).focusout(function() {
		if (this.value.trim() == "") {
			this.value = "0";
		}
	});
};
/**
 * Allow put the numeric 
 * */
Util.allowNumeric = function (textBoxObj) {
	var dot = ".";
	textBoxObj.keyup(function(e) {
		var newValue = this.value.replace(/([^0-9.])/g,''); // Remove the text character
		newValue = newValue.replace("..", dot);
		this.value = newValue;
		if (newValue.indexOf(dot) == 0) {
			this.value = this.value.substring(1, this.value.length);;
		} 
	}).focusout(function() {
		if (this.value.substring(this.value.length - 1) == dot) {
			this.value = this.value.substring(0, this.value.length - 1); 
		}
	});
};

/**
 * Get the volume html show on position row
 * */
Util.getVolumeHtml = function(volume, symbol) {
	if(volume != undefined) {
		if (symbol == 'XAUUSD' || symbol == 'XAGUSD') {
			volume = volume/1e3;
			return Util.addCommas(volume) + ' k';
		} else {
			volume = volume/1e6;
			return Util.addCommas(volume) + ' m';
		}
		 
	}
	return "";	
};

/**
 * Get default order side
 * */
Util.getDefaultOrderSize = function (symbol) {
	if (symbol == 'XAUUSD' || symbol == 'XAGUSD') {
		return DEFAULT_SETTINGS.orderSizeK; 
	} else {
		return DEFAULT_SETTINGS.orderSizeM;
	}
};

Util.insertAt = function (array, item, index) {
	array.splice(index, 0, item);
	return array;
};