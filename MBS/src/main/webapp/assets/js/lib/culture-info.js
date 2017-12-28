/**
 * Version: 1.0 Alpha-1 
 * Build Date: 13-Nov-2007
 * Copyright (c) 2006-2007, Coolite Inc. (http://www.coolite.com/). All rights reserved.
 * License: Licensed under The MIT License. See license.txt and http://www.datejs.com/license/. 
 * Website: http://www.datejs.com/ or http://www.coolite.com/datejs/
 */
CultureInfoVi = {
	/* Culture Name */
    name: "vi-VN",
    englishName: "Vietnamese (Vietnam)",
    nativeName: "Tiếng Việt (Việt Nam)",
    
    /* Day Name Strings */
    dayNames: ["Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy"],
    abbreviatedDayNames: ["CN", "Hai", "Ba", "Tư", "Năm", "Sáu", "Bảy"],
    shortestDayNames: ["C", "H", "B", "T", "N", "S", "B"],
    firstLetterDayNames: ["C", "H", "B", "T", "N", "S", "B"],
    
    /* Month Name Strings */
    monthNames: ["Tháng Giêng", "Tháng Hai", "Tháng Ba", "Tháng Tư", "Tháng Năm", "Tháng Sáu", "Tháng Bảy", "Tháng Tám", "Tháng Chín", "Tháng Mười", "Tháng Mười Một", "Tháng Mười Hai"],
    abbreviatedMonthNames: ["Thg1", "Thg2", "Thg3", "Thg4", "Thg5", "Thg6", "Thg7", "Thg8", "Thg9", "Thg10", "Thg11", "Thg12"],

	/* AM/PM Designators */
    amDesignator: "SA",
    pmDesignator: "CH",

    firstDayOfWeek: 1,
    twoDigitYearMax: 2029,
    
    /**
     * The dateElementOrder is based on the order of the 
     * format specifiers in the formatPatterns.DatePattern. 
     *
     * Example:
     <pre>
     shortDatePattern    dateElementOrder
     ------------------  ---------------- 
     "M/d/yyyy"          "mdy"
     "dd/MM/yyyy"        "dmy"
     "yyyy-MM-dd"        "ymd"
     </pre>
     * The correct dateElementOrder is required by the parser to
     * determine the expected order of the date elements in the
     * string being parsed.
     * 
     * NOTE: It is VERY important this value be correct for each Culture.
     */
    dateElementOrder: "mdy",
    
    /* Standard date and time format patterns */
    formatPatterns: {
        shortDate: "dd/MM/yyyy",
        longDate: "dd MMMM yyyy",
        shortTime: "h:mm tt",
        longTime: "h:mm:ss tt",
        fullDateTime: "dd MMMM yyyy h:mm:ss tt",
        sortableDateTime: "yyyy-MM-ddTHH:mm:ss",
        universalSortableDateTime: "yyyy-MM-dd HH:mm:ssZ",
        rfc1123: "ddd, dd MMM yyyy HH:mm:ss GMT",
        monthDay: "dd MMMM",
        yearMonth: "MMMM yyyy"
    },

    /**
     * NOTE: If a string format is not parsing correctly, but
     * you would expect it parse, the problem likely lies below. 
     * 
     * The following regex patterns control most of the string matching
     * within the parser.
     * 
     * The Month name and Day name patterns were automatically generated
     * and in general should be (mostly) correct. 
     *
     * Beyond the month and day name patterns are natural language strings.
     * Example: "next", "today", "months"
     *
     * These natural language string may NOT be correct for this culture. 
     * If they are not correct, please translate and edit this file
     * providing the correct regular expression pattern. 
     *
     * If you modify this file, please post your revised CultureInfo file
     * to the Datejs Discussions located at
     *     http://groups.google.com/group/date-js
     *
     * Please mark the subject with [CultureInfo]. Example:
     *    Subject: [CultureInfo] Translated "da-DK" Danish(Denmark)
     * 
     * We will add the modified patterns to the master source files.
     *
     * As well, please review the list of "Future Strings" section below. 
     */	
    regexPatterns: {
        jan: /^tháng giêng/i,
        feb: /^tháng hai/i,
        mar: /^tháng ba/i,
        apr: /^tháng tư/i,
        may: /^tháng năm/i,
        jun: /^tháng sáu/i,
        jul: /^tháng bảy/i,
        aug: /^tháng tám/i,
        sep: /^tháng chín/i,
        oct: /^tháng mười/i,
        nov: /^tháng mười một/i,
        dec: /^tháng mười hai/i,

        sun: /^c(n(ủ nhật)?)?/i,
        mon: /^h(ai(́ hai)?)?/i,
        tue: /^b(a(ứ ba)?)?/i,
        wed: /^t(ư(ứ tư)?)?/i,
        thu: /^n(ăm(́ năm)?)?/i,
        fri: /^s(áu( sáu)?)?/i,
        sat: /^b(ảy( bảy)?)?/i,

        future: /^next/i,
        past: /^last|past|prev(ious)?/i,
        add: /^(\+|after|from)/i,
        subtract: /^(\-|before|ago)/i,
        
        yesterday: /^yesterday/i,
        today: /^t(oday)?/i,
        tomorrow: /^tomorrow/i,
        now: /^n(ow)?/i,
        
        millisecond: /^ms|milli(second)?s?/i,
        second: /^sec(ond)?s?/i,
        minute: /^min(ute)?s?/i,
        hour: /^h(ou)?rs?/i,
        week: /^w(ee)?k/i,
        month: /^m(o(nth)?s?)?/i,
        day: /^d(ays?)?/i,
        year: /^y((ea)?rs?)?/i,
		
        shortMeridian: /^(a|p)/i,
        longMeridian: /^(a\.?m?\.?|p\.?m?\.?)/i,
        timezone: /^((e(s|d)t|c(s|d)t|m(s|d)t|p(s|d)t)|((gmt)?\s*(\+|\-)\s*\d\d\d\d?)|gmt)/i,
        ordinalSuffix: /^\s*(st|nd|rd|th)/i,
        timeContext: /^\s*(\:|a|p)/i
    },

    abbreviatedTimeZoneStandard: { GMT: "-000", EST: "-0400", CST: "-0500", MST: "-0600", PST: "-0700" },
    abbreviatedTimeZoneDST: { GMT: "-000", EDT: "-0500", CDT: "-0600", MDT: "-0700", PDT: "-0800" }
    
};
CultureInfoEn = {
	/* Culture Name */
    name: "en-US",
    englishName: "English (United States)",
    nativeName: "English (United States)",
    
    /* Day Name Strings */
    dayNames: ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"],
    abbreviatedDayNames: ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"],
    shortestDayNames: ["Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"],
    firstLetterDayNames: ["S", "M", "T", "W", "T", "F", "S"],
    
    /* Month Name Strings */
    monthNames: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
    abbreviatedMonthNames: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],

	/* AM/PM Designators */
    amDesignator: "AM",
    pmDesignator: "PM",

    firstDayOfWeek: 0,
    twoDigitYearMax: 2029,
    
    /**
     * The dateElementOrder is based on the order of the 
     * format specifiers in the formatPatterns.DatePattern. 
     *
     * Example:
     <pre>
     shortDatePattern    dateElementOrder
     ------------------  ---------------- 
     "M/d/yyyy"          "mdy"
     "dd/MM/yyyy"        "dmy"
     "yyyy-MM-dd"        "ymd"
     </pre>
     * The correct dateElementOrder is required by the parser to
     * determine the expected order of the date elements in the
     * string being parsed.
     * 
     * NOTE: It is VERY important this value be correct for each Culture.
     */
    dateElementOrder: "mdy",
    
    /* Standard date and time format patterns */
    formatPatterns: {
        shortDate: "M/d/yyyy",
        longDate: "dddd, MMMM dd, yyyy",
        shortTime: "h:mm tt",
        longTime: "h:mm:ss tt",
        fullDateTime: "dddd, MMMM dd, yyyy h:mm:ss tt",
        sortableDateTime: "yyyy-MM-ddTHH:mm:ss",
        universalSortableDateTime: "yyyy-MM-dd HH:mm:ssZ",
        rfc1123: "ddd, dd MMM yyyy HH:mm:ss GMT",
        monthDay: "MMMM dd",
        yearMonth: "MMMM, yyyy"
    },

    /**
     * NOTE: If a string format is not parsing correctly, but
     * you would expect it parse, the problem likely lies below. 
     * 
     * The following regex patterns control most of the string matching
     * within the parser.
     * 
     * The Month name and Day name patterns were automatically generated
     * and in general should be (mostly) correct. 
     *
     * Beyond the month and day name patterns are natural language strings.
     * Example: "next", "today", "months"
     *
     * These natural language string may NOT be correct for this culture. 
     * If they are not correct, please translate and edit this file
     * providing the correct regular expression pattern. 
     *
     * If you modify this file, please post your revised CultureInfo file
     * to the Datejs Discussions located at
     *     http://groups.google.com/group/date-js
     *
     * Please mark the subject with [CultureInfo]. Example:
     *    Subject: [CultureInfo] Translated "da-DK" Danish(Denmark)
     * 
     * We will add the modified patterns to the master source files.
     *
     * As well, please review the list of "Future Strings" section below. 
     */	
    regexPatterns: {
        jan: /^jan(uary)?/i,
        feb: /^feb(ruary)?/i,
        mar: /^mar(ch)?/i,
        apr: /^apr(il)?/i,
        may: /^may/i,
        jun: /^jun(e)?/i,
        jul: /^jul(y)?/i,
        aug: /^aug(ust)?/i,
        sep: /^sep(t(ember)?)?/i,
        oct: /^oct(ober)?/i,
        nov: /^nov(ember)?/i,
        dec: /^dec(ember)?/i,

        sun: /^su(n(day)?)?/i,
        mon: /^mo(n(day)?)?/i,
        tue: /^tu(e(s(day)?)?)?/i,
        wed: /^we(d(nesday)?)?/i,
        thu: /^th(u(r(s(day)?)?)?)?/i,
        fri: /^fr(i(day)?)?/i,
        sat: /^sa(t(urday)?)?/i,

        future: /^next/i,
        past: /^last|past|prev(ious)?/i,
        add: /^(\+|after|from)/i,
        subtract: /^(\-|before|ago)/i,
        
        yesterday: /^yesterday/i,
        today: /^t(oday)?/i,
        tomorrow: /^tomorrow/i,
        now: /^n(ow)?/i,
        
        millisecond: /^ms|milli(second)?s?/i,
        second: /^sec(ond)?s?/i,
        minute: /^min(ute)?s?/i,
        hour: /^h(ou)?rs?/i,
        week: /^w(ee)?k/i,
        month: /^m(o(nth)?s?)?/i,
        day: /^d(ays?)?/i,
        year: /^y((ea)?rs?)?/i,
		
        shortMeridian: /^(a|p)/i,
        longMeridian: /^(a\.?m?\.?|p\.?m?\.?)/i,
        timezone: /^((e(s|d)t|c(s|d)t|m(s|d)t|p(s|d)t)|((gmt)?\s*(\+|\-)\s*\d\d\d\d?)|gmt)/i,
        ordinalSuffix: /^\s*(st|nd|rd|th)/i,
        timeContext: /^\s*(\:|a|p)/i
    },

    abbreviatedTimeZoneStandard: { GMT: "-000", EST: "-0400", CST: "-0500", MST: "-0600", PST: "-0700" },
    abbreviatedTimeZoneDST: { GMT: "-000", EDT: "-0500", CDT: "-0600", MDT: "-0700", PDT: "-0800" }
    
};

CultureInfoJa = {
		/* Culture Name */
	    name: "ja-JP",
	    englishName: "Japanese (Japan)",
	    nativeName: "日本語 (日本)",
	    
	    /* Day Name Strings */
	    dayNames: ["日曜日", "月曜日", "火曜日", "水曜日", "木曜日", "金曜日", "土曜日"],
	    abbreviatedDayNames: ["日", "月", "火", "水", "木", "金", "土"],
	    shortestDayNames: ["日", "月", "火", "水", "木", "金", "土"],
	    firstLetterDayNames: ["日", "月", "火", "水", "木", "金", "土"],
	    
	    /* Month Name Strings */
	    monthNames: ["1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"],
	    abbreviatedMonthNames: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"],

		/* AM/PM Designators */
	    amDesignator: "午前",
	    pmDesignator: "午後",

	    firstDayOfWeek: 0,
	    twoDigitYearMax: 2029,
	    
	    /**
	     * The dateElementOrder is based on the order of the 
	     * format specifiers in the formatPatterns.DatePattern. 
	     *
	     * Example:
	     <pre>
	     shortDatePattern    dateElementOrder
	     ------------------  ---------------- 
	     "M/d/yyyy"          "mdy"
	     "dd/MM/yyyy"        "dmy"
	     "yyyy-MM-dd"        "ymd"
	     </pre>
	     * The correct dateElementOrder is required by the parser to
	     * determine the expected order of the date elements in the
	     * string being parsed.
	     * 
	     * NOTE: It is VERY important this value be correct for each Culture.
	     */
	    dateElementOrder: "ymd",
	    
	    /* Standard date and time format patterns */
	    formatPatterns: {
	        shortDate: "yyyy/MM/dd",
	        longDate: "yyyy'年'M'月'd'日'",
	        shortTime: "H:mm",
	        longTime: "H:mm:ss",
	        fullDateTime: "yyyy'年'M'月'd'日' H:mm:ss",
	        sortableDateTime: "yyyy-MM-ddTHH:mm:ss",
	        universalSortableDateTime: "yyyy-MM-dd HH:mm:ssZ",
	        rfc1123: "ddd, dd MMM yyyy HH:mm:ss GMT",
	        monthDay: "M'月'd'日'",
	        yearMonth: "yyyy'年'M'月'"
	    },

	    /**
	     * NOTE: If a string format is not parsing correctly, but
	     * you would expect it parse, the problem likely lies below. 
	     * 
	     * The following regex patterns control most of the string matching
	     * within the parser.
	     * 
	     * The Month name and Day name patterns were automatically generated
	     * and in general should be (mostly) correct. 
	     *
	     * Beyond the month and day name patterns are natural language strings.
	     * Example: "next", "today", "months"
	     *
	     * These natural language string may NOT be correct for this culture. 
	     * If they are not correct, please translate and edit this file
	     * providing the correct regular expression pattern. 
	     *
	     * If you modify this file, please post your revised CultureInfo file
	     * to the Datejs Discussions located at
	     *     http://groups.google.com/group/date-js
	     *
	     * Please mark the subject with [CultureInfo]. Example:
	     *    Subject: [CultureInfo] Translated "da-DK" Danish(Denmark)
	     * 
	     * We will add the modified patterns to the master source files.
	     *
	     * As well, please review the list of "Future Strings" section below. 
	     */	
	    regexPatterns: {
	        jan: /^1(月)?/i,
	        feb: /^2(月)?/i,
	        mar: /^3(月)?/i,
	        apr: /^4(月)?/i,
	        may: /^5(月)?/i,
	        jun: /^6(月)?/i,
	        jul: /^7(月)?/i,
	        aug: /^8(月)?/i,
	        sep: /^9(月)?/i,
	        oct: /^10(月)?/i,
	        nov: /^11(月)?/i,
	        dec: /^12(月)?/i,

	        sun: /^日曜日/i,
	        mon: /^月曜日/i,
	        tue: /^火曜日/i,
	        wed: /^水曜日/i,
	        thu: /^木曜日/i,
	        fri: /^金曜日/i,
	        sat: /^土曜日/i,

	        future: /^next/i,
	        past: /^last|past|prev(ious)?/i,
	        add: /^(\+|after|from)/i,
	        subtract: /^(\-|before|ago)/i,
	        
	        yesterday: /^yesterday/i,
	        today: /^t(oday)?/i,
	        tomorrow: /^tomorrow/i,
	        now: /^n(ow)?/i,
	        
	        millisecond: /^ms|milli(second)?s?/i,
	        second: /^sec(ond)?s?/i,
	        minute: /^min(ute)?s?/i,
	        hour: /^h(ou)?rs?/i,
	        week: /^w(ee)?k/i,
	        month: /^m(o(nth)?s?)?/i,
	        day: /^d(ays?)?/i,
	        year: /^y((ea)?rs?)?/i,
			
	        shortMeridian: /^(a|p)/i,
	        longMeridian: /^(a\.?m?\.?|p\.?m?\.?)/i,
	        timezone: /^((e(s|d)t|c(s|d)t|m(s|d)t|p(s|d)t)|((gmt)?\s*(\+|\-)\s*\d\d\d\d?)|gmt)/i,
	        ordinalSuffix: /^\s*(st|nd|rd|th)/i,
	        timeContext: /^\s*(\:|a|p)/i
	    },

	    abbreviatedTimeZoneStandard: { GMT: "-000", EST: "-0400", CST: "-0500", MST: "-0600", PST: "-0700" },
	    abbreviatedTimeZoneDST: { GMT: "-000", EDT: "-0500", CDT: "-0600", MDT: "-0700", PDT: "-0800" }
	    
	};