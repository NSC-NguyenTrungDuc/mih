window.MssUtils = {
	/**
	 * {JSDoc}
	 *
	 * The splice() method changes the content of a string by removing a range of
	 * characters and/or adding new characters.
	 *
	 * @this {String}
	 * @param {number} start Index at which to start changing the string.
	 * @param {number} delCount An integer indicating the number of old chars to remove.
	 * @param {string} newSubStr The String that is spliced in.
	 * @return {string} A new string with the spliced substring.
	 */
	stringSplice: function(str, start, delCount, newSubStr) {
		return str.slice(0, start) + newSubStr + str.slice(start + Math.abs(delCount));
	},
	detectmob: function() { 
	 if( navigator.userAgent.match(/Android/i)
	 || navigator.userAgent.match(/webOS/i)
	 || navigator.userAgent.match(/iPhone/i)
	 || navigator.userAgent.match(/iPad/i)
	 || navigator.userAgent.match(/iPod/i)
	 || navigator.userAgent.match(/BlackBerry/i)
	 || navigator.userAgent.match(/Windows Phone/i)
	 ){
	    return true;
	  }
	 else {
	    return false;
	  }
	},
	focusIncaseMobile: function(id){
		var offset = $(id).offset().top;
		$('body').scrollTop(offset);
	}
}
function enhanceTime(time) {
	var enhancedTime = time.replace(':', '');
	if (enhancedTime.length == 3) {
		enhancedTime = '0' + enhancedTime;
	}
	return enhancedTime;
}

function getDayOfWeek (date) {
	var d = new Date(date);
	return d.getDay() == 0 ? 7 : d.getDay();
}

function insertColonToTimeslot(timeslotStr) {
	timeslotStr = timeslotStr.substr(0, 2) + ":" + timeslotStr.substr(2);
	if(timeslotStr.indexOf("0") == 0){
		return timeslotStr.substr(1);
	}
	return timeslotStr;
};

function alertResponseMessage(response) {
	if(typeof timeOut != 'undefined'){
		clearTimeout(timeOut);
	}
	if (response.status == 200) {
		if (response.message != null && response.message.length) {
			var $ajaxAlert = $('#ajax-alert-success');
			$ajaxAlert.find('#ajax-msg-success').html(response.message);
			$ajaxAlert.removeClass('hidden');
			window.setTimeout(function() {$ajaxAlert.addClass('hidden'); }, 5000);
		}
	}
	else {
		var $ajaxAlert = $('#ajax-alert-error');
		$ajaxAlert.find('#ajax-msg-error').html(response.message);
		$ajaxAlert.removeClass('hidden');
		timeOut = window.setTimeout(function() {$ajaxAlert.addClass('hidden'); }, 5000);
	}
}

function bindWeekNavigationClickEvent(initCalendarData, comparedDate){
	$("#btn-current-week").on("click", function(){
		$("#btn-current-week").prop("disabled", true);
		/* var timeout = setTimeout(function() {
	        }, 3000)*/
		currentDate = new Date(comparedDate);
		initCalendarData();
	
	});


	$("#btn-previous-week").on("click", function(){		
		$("#btn-previous-week").prop("disabled", true);
		if (currentDate.addDays(-7).compareTo(comparedDate) < 0) {
			currentDate = comparedDate;
		}
		initCalendarData();
	
	});
	
	$("#btn-next-week").on("click", function(){
		$("#btn-next-week").prop("disabled", true);
		currentDate.addDays(7);
		initCalendarData();
		
	});
}

	function bindWeekNavigationClickEvent2(initCalendarData, comparedDate){
		$("#btn-current-week").on("click", function(){
			currentDate = new Date(comparedDate);
			initCalendarData();
		});
		
		$("#btn-previous-week").on("click", function(){		
			if (currentDate.addDays(-7).compareTo(comparedDate) < 0) {
				currentDate = comparedDate;
			}
			initCalendarData();
		});
		
		$("#btn-next-week").on("click", function(){
			currentDate.addDays(7);
			initCalendarData();
		});
	}
	function checkPreviousButtonStatus2(currentDate, comparedDate){
		$("#btn-previous-week").removeAttr("disabled");
		if (currentDate.compareTo(comparedDate) == 0) {
			$("#btn-previous-week").attr("disabled", "disabled");
		}
	}

function checkPreviousButtonStatus(currentDate, comparedDate){
/*	$("#btn-previous-week").removeAttr("disabled");*/
	if (currentDate.compareTo(comparedDate) == 0) {
		/*$("#btn-previous-week").attr("disabled", "disabled");*/
		$("#btn-previous-week").prop("disabled", true);
	}
}

function disableSubmitButtonAfterSubmission(button){
	$(button).removeAttr("disabled");
	$('form').submit(function(){
		$(button).attr('disabled','disabled');
	});
}
