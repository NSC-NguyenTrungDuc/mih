$(document).ready(function(){
	initVaccineSchedule();	
	
	$("#slt-child").change(function() {
		initVaccineSchedule();
	});
	
	function initVaccineSchedule() {
		var childId = $("#slt-child").val();
		var source = $("#vaccine-schedule-list").html();
		var template = Handlebars.compile(source);
		var table = '#vaccine-schedule-table';
		var tbody = '#vaccine-schedule-body';
		$(table).dataTable().fnDestroy();;
		// get vaccine info
		$.ajax({
			type: "post",
			url: "ajax-init-recommended-booking-vaccine-schedule-list",
			data: JSON.stringify({"childId" : childId}),
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				var data = {
	        			'vaccineScheduleList' : response.data,
		        	};
		        	$(tbody).empty().append(template(data));
			},
			error: function() {
				alert('Error while request vaccine schedule..');
			}
		});
		loadLanguageForDataTable(childId);
		
		// get child info
		$.ajax({
			type: "post",
			url: "ajax-get-child-info",
			data: JSON.stringify({"childId" : childId}),
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				var child = response.data;
				$("#child-name").text(child.childName);
				$("#gender").text(child.genderText);
				$("#birthday").text(child.formattedBirthDay);
			},
			error: function() {
				alert('Error while request vaccine schedule..');
			}
		});
    };
    
    function loadLanguageForDataTable(childId){
    	var table = '#vaccine-schedule-table'; 
		$(table).dataTable({
			"language": {
				"sProcessing":   "処理中...",
				"sLengthMenu":   "_MENU_ " + fe000_table_record_each_page,
				"sZeroRecords":  fe000_table_empty,
				"sInfo":         fe000_s_info,
				"sInfoEmpty":    fe000_table_info_empty,
				"sInfoFiltered": "（全 _MAX_ 件より抽出）",
				"sInfoPostFix":  "",
				"sSearch":       "検索:",
				"sUrl":          "",
				"oPaginate": {
					"sFirst":    "先頭",
					"sPrevious": fe000_table_previous,
					"sNext":     fe000_table_next,
					"sLast":     fe000_table_last
				}
			},
			"bSort": false
	    });
		$(table + "_filter").hide();
	}
});
		