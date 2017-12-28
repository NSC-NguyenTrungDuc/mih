$(document).ready(function(){
	initVaccineSchedule();
		
	
	function initVaccineSchedule() {
		var source = $("#vaccine-schedule-list").html();
		var template = Handlebars.compile(source);
		$('.vaccine-table').each(function(){
			var childId = $(this).attr('data-id');
			var table = '#vaccine-schedule-table' + childId;
			var tbody = '#vaccine-schedule-body' + childId;
			$(table).dataTable().fnDestroy();;
			$.ajax({
				type: "post",
				url: "ajax-init-full-vaccine-schedule-list",
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
				complete: function() {
					$('.choose-hospital-link').on('click', showChooseHospitalDialog);
					initDatePicker();
				},
				error: function() {
					alert('Error while request vaccine schedule..');
				}
			});
			loadLanguageForDataTable(childId);
		});
    };
    
    function loadLanguageForDataTable(childId){
    	var table = '#vaccine-schedule-table' + childId; 
		$(table).dataTable({
			"language": {
				"sProcessing":   "処理中...",
				"sLengthMenu":   "_MENU_ " + re007_table_record_each_page,
				"sZeroRecords":  re007_table_empty,
				"sInfo":         re007_s_info,
				"sInfoEmpty":    re007_table_info_empty,
				"sInfoFiltered": "（全 _MAX_ 件より抽出）",
				"sInfoPostFix":  "",
				"sSearch":       "検索:",
				"sUrl":          "",
				"oPaginate": {
					"sFirst":    "先頭",
					"sPrevious": re007_table_previous,
					"sNext":     re007_table_next,
					"sLast":     re007_table_last
				}
			},
			"bSort": false
	    });
		$(table + "_filter").hide();
	}
    
    function showChooseHospitalDialog(event) {
    	event.preventDefault();
		var $target = $(event.currentTarget);
		var vaccineId = $target.attr('data-id');
		var injectedNo = $target.attr('data-times-inject');
		var $chooseHospitalDialog = $('#choose-hospital');
		// reset hospital name
		$('#hospitalName').val('');
		$chooseHospitalDialog.attr('data-id', vaccineId);
		$chooseHospitalDialog.attr('data-times-inject', injectedNo);
		$chooseHospitalDialog.modal('show');
	}
    
    function initDatePicker() {
		
		$("#injectedDate").datepicker({ 
			dateFormat: 'yy/mm/dd',
			minDate: 0
		});
		
		$("#injectedDate").val(getCurrentDate());
	}
	
	function getCurrentDate() {
		var now = new Date();
	    var day = ("0" + now.getDate()).slice(-2);
	    var month = ("0" + (now.getMonth() + 1)).slice(-2);
	    var today = now.getFullYear() +"/"+ month +"/"+ day+"";
	    return today;
	}
	
	$("#btn-update-hospital").click(function() {
		var vaccineId = $('#choose-hospital').attr('data-id');
		var date = $("#injectedDate").val();
		var injectedNo = $('#choose-hospital').attr('data-times-inject');
		var childId = userChildId;
		var hospitalName = $("#hospitalName").val();
		if (hospitalName == '' || date == "") {
			if (hospitalName == '')	$("#hospitalNameError").show();
			if (date == '') $("#dateError").show();
			window.setTimeout(function() {$("#hospitalNameError").hide(); }, 2000);
			window.setTimeout(function() {$("#dateError").hide(); }, 2000);
			return;
		}
		$.ajax({
			type : "post",
			url : "ajax-vaccine-update-hospital",
			data : JSON.stringify({"vaccineId" : vaccineId, "childId" : childId, "hospitalName" : hospitalName, "injectedNo" : injectedNo, "injectedDateStr" : date}),
			dataType : "json",
			async : false,
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type","application/json");
			},
			success : function(response) {
				$('#choose-hospital').modal('hide');
				if (response.status == 200) {
					initVaccineSchedule();
				}
				alertResponseMessage(response);
			},
			complete: function() {
				
			},
			error : function() {
				alert('Error while request..');
			}
		});
	});
	
	$('#choose-hospital').on('hidden.bs.modal', function () {
		$("#hospitalNameError").hide();
	})
});
		