$(document).ready(function(){
	var vaccineList = [];
	var dateList = [];
	initDatePicker();
	
	$('#cbo-setting').multiselect2side({
		labelsx: $("#undisplayedLabel").text(),
		labeldx: $("#displayedLabel").text(),
		labelSort: $("#sortLabel").text(),
		labelTop: $("#topLabel").text() ,
		labelUp: $("#upLabel").text() ,
		labelDown: $("#downLabel").text() ,
		labelBottom: $("#bottomLabel").text() 
	});
	
	initVaccineList();
	
	function initDatePicker() {	
		$("#fromDate").datepicker({ 
			dateFormat: 'yy/mm/dd',
			maxDate: getNextMonth(),
			onClose: function( selectedDate ) {
		        $( "#toDate" ).datepicker( "option", "minDate", selectedDate );
		      }
		});
		$("#toDate").datepicker({ 
			dateFormat: 'yy/mm/dd',
			minDate: getCurrentDate(),
			onClose : function( selectedDate ) {
		        $( "#fromDate" ).datepicker( "option", "maxDate", selectedDate );
		    }
		});
		
		$("#fromDate").val(getCurrentDate());
		$("#toDate").val(getNextMonth());
		
	}
	
	function getCurrentDate() {
		var now = new Date();
	    var day = ("0" + now.getDate()).slice(-2);
	    var month = ("0" + (now.getMonth() + 1)).slice(-2);
	    var today = now.getFullYear() +"/"+ month +"/"+ day+"";
	    return today;
	}
	
	function getNextMonth() {
		var now = new Date();
		var nextMonth = new Date(now.getFullYear(), now.getMonth() + 1, now.getDate());
		var day = ("0" + nextMonth.getDate()).slice(-2);
		var month = ("0" + (nextMonth.getMonth() + 1)).slice(-2);
		var nextMonthDay = nextMonth.getFullYear() +"/"+ month +"/"+ day+"";
	    return nextMonthDay;
	}
	
	function initVaccineList() {
		vaccineList = [];
	    $("#cbo-settingms2side__dx option").each(function()
		{
	    	vaccineList.push($(this).text());
		});
	}
	
	function initDateList() {
		var fromDateString = $("#fromDate").val();
		var fromDate = new Date(fromDateString.split('/')[0], fromDateString.split('/')[1] - 1, fromDateString.split('/')[2]);
		var toDateString = $("#toDate").val();
		var toDate = new Date(toDateString.split('/')[0], toDateString.split('/')[1] - 1, toDateString.split('/')[2]);
	    var currentDate = fromDate;
	    while (currentDate <= toDate) {
	        dateList.push( new Date (currentDate) )
	        currentDate = currentDate.add({days: 1});
	    }
	}
	
	$('#generateBtn').click(function(){
		fillData();
	});
	
	$("#settingBtn").click(function(){
		var $settingVaccineDialog = $('#setting-vaccine');
		$settingVaccineDialog.modal('show');
	});
	
	$('#saveBtn').click(function(){
		fillData();
		var $settingVaccineDialog = $('#setting-vaccine');
		$settingVaccineDialog.modal('hide');
	});
	
	function loadLanguageForDataTable(){
		$('#tblVaccineReport').dataTable({
	        "language": {
	        	"sProcessing":   "処理中...",
	        	 "sLengthMenu":   "_MENU_ " + md_table_record_each_page,
	        	 "sZeroRecords":  md_table_empty,
	        	 "sInfo":         md_s_info,
	        	 "sInfoEmpty":    md_table_info_empty,
	        	 "sInfoFiltered": "（全 _MAX_ 件より抽出）",
	        	 "sInfoPostFix":  "",
	        	 "sSearch":       "検索:",
	        	 "sUrl":          "",
	        	 "oPaginate": {
	        	 	"sFirst":    "先頭",
	        	    "sPrevious": md_table_previous,
	        	    "sNext":     md_table_next,
	        	    "sLast":     md_table_last
	        	 }
	        },
	        "bSort": false
	    });
		$("#tblVaccineReport_filter").hide();
	}
	
	function initTable(){
		$("#vaccine-report-list").empty();
		$("#vaccine-report-list").append("<table class='table table-bordered display' id='tblVaccineReport'></table>");
		initVaccineList();
		var content = '';
		content += "<thead>";
		content += "<tr style='background-color: #4f6070;color: white;font-weight: bold;'>";
		content += "<th style='text-align:center'>" + $("#dateLabel").text() + "</th>";
		content += "<th style='text-align:center'>" + $("#dayLabel").text() + "</th>";
		$.each(vaccineList, function(index, value){
			content += "<th>" + value + "</th>";
		});
		content += "<th>" + $("#bookingLabel").text() + "</th>";
		content += "</tr>";
		content += "</thead><tbody></tbody>";
		$("#tblVaccineReport").empty().append(content);
		$('#tblVaccineReport').dataTable().fnDestroy();
	}
	
	function fillData(){
		initTable();
		var multipleValues = [];
	    $("#cbo-settingms2side__dx option").each(function()
		{
	    	var vaccineModel = {};
	    	vaccineModel["vaccineId"] = $(this).val();
		    multipleValues.push(vaccineModel);
		});
	    var vaccineReportAjaxRequest = {'fromDate' : $("#fromDate").val().replace(/\//g,''), 'toDate' : $("#toDate").val().replace(/\//g,''), 'vaccineModelList' : multipleValues};
		$.ajax({
			type : "post",
			url : "ajax-vaccine-report",
			data : JSON.stringify(vaccineReportAjaxRequest),
			dataType : "json",
			async : false,
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type","application/json");
			},
			success : function(response) {
				if (response.status == 200 && response.data) {
					initDateList();
					var content = '';
					$.each( response.data, function( key, value ) {
						var date = new Date(key.split('/')[0], key.split('/')[1] - 1, key.split('/')[2]);
						if (getDayOfWeek(date) == '6' || getDayOfWeek(date) == '7'){
							content += "<tr style='background-color: #FFFFEE'>";
						}
						else {
							content += "<tr>";
						}
						content += "<td style='text-align:center'>" + date.toString(DATETIME.FORMAT.DATE) + "</td>";
						content += "<td style='text-align:center'>" + date.toString("ddd") + "</td>";
						value.forEach(function(vaccine){
							content += "<td>";
							if (vaccine.total != 0) {
								content += vaccine.total + " (" + vaccine.numberOfFinished + ")";
							}
							content += "</td>";
						});
						var url = $("#searchUrl").text() + date.toString(DATETIME.FORMAT.DATE_NO_SEPARATOR);
						if ($("#deptId").text() != "") {
							url += "&deptId=" + $("#deptId").text();
						}
						content += "<td><div style='color:#428bca; cursor:pointer;' onclick='window.open(\"" + url + "\",\"mywindow\");'>" + $("#bookingLabel").text() + "</div></td>";
						content += "</tr>";
					});
					$("#tblVaccineReport tbody").empty();
					$("#tblVaccineReport tbody").append(content);
				}
			},
			complete: function() {
				
			},
			error : function() {
				alert('Error while request..');
			}
		});
		loadLanguageForDataTable();
	}
});
		 