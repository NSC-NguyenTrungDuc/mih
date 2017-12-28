$(document).ready(function(){
	$.fn.dataTable.ext.errMode = 'none';
	initVaccineSchedule();
	
	$("#slt-child").on('change', function() {
		initVaccineSchedule();
	});
	
	function initVaccineSchedule() {
		var childId = $("#slt-child").val();
		var source = $("#vaccine-schedule-list").html();
		var template = Handlebars.compile(source);
		try {
			$('#vaccine-schedule-table').dataTable().fnDestroy();
		}catch ( e){

		}
		$.ajax({
			type: "post",
			url: "ajax-init-recommended-vaccine-schedule-list",
			data: JSON.stringify({"childId" : childId}),
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				if (response.status == 200) {
					var data = {
							'vaccineScheduleList' : response.data,
					};
					$('#vaccine-schedule-body').empty().append(template(data));
				}
//				alertResponseMessage(response);
			},
			complete: function() {
				$("#btnSubmit").click(function () {
					var deptId = $("#deptId").val();
					var childId = $("#slt-child").val();
					var vaccineId = "";
					var timesUsing = "";
					var dateCanBooking = "";
					$("table tbody tr").each(function() {
						if ($(this).find("td.select-vaccine input").is(":checked") == true) {
							vaccineId = $(this).find("td.select-vaccine input").val();
							timesUsing = $(this).find(".Time-Using").text();
							dateCanBooking = $(this).find("td.date-canBooking input").val();
						}
					});
					
					location.href = "../booking/booking-vaccine-select-time?deptId=" + deptId + "&vaccineId=" + vaccineId + "&childId=" + childId + "&timesUsing=" + timesUsing + "&date=" + dateCanBooking ;
				});
			},
			error: function() {
				alert('Error while request vaccine schedule..');
			}
		});
		//loadLanguageForDataTable();
    };
    
    function loadLanguageForDataTable(){
		$('#vaccine-schedule-table').DataTable({
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
		$("#vaccine-schedule-table_filter").hide();
	}
});
		