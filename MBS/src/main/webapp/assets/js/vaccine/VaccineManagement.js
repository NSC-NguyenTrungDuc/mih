$(document).ready(function() {
	initPage();
//	loadLanguageForDataTable();
	initVaccineHospitalSchedule();
	
	function initPage() {
		
		$("#strFromDate").datepicker({ 
			dateFormat: 'yy/mm/dd',
			onClose: function( selectedDate ) {
				$( "#strToDate" ).datepicker( "option", "minDate", selectedDate );
			}
		});
		
		$("#strToDate").datepicker({ 
			dateFormat: 'yy/mm/dd', 
			onClose : function( selectedDate ) {
				$( "#strFromDate" ).datepicker( "option", "maxDate", selectedDate );
			}
		});
		
		$("#strFromDate").val();
		$("#strToDate").val();
	}
	
	function initVaccineHospitalSchedule() {
		var source = $("#vaccine-hospital-schedule-list").html();
		var template = Handlebars.compile(source);
		$('#tblVaccineHospital').dataTable().fnDestroy();;
		$.ajax({
			type: "post",
			url: "ajax-init-vaccine-hospital-schedule-list",
//			data: JSON.stringify({"childId" : childId}),
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				if (response.status == 200) {
					var data = {
							'vaccineHospitals' : response.data,
					};
					$('#vaccine-hospital-schedule-body').empty().append(template(data));
				}
//				alertResponseMessage(response);
			},
			complete: function() {
				$('.delete-vaccineHospital-btn').on('click', showConfirmDialog);
			},
			error: function() {
				alert('Error while request vaccine schedule..');
			}
		});
		loadLanguageForDataTable();
    };
	
	function showConfirmDialog(event) {
		var $target = $(event.currentTarget);
		var vaccineHospitalId = $target.attr('data-id');
		
		var $confirmDialog = $('#confirm-delete-vaccine');
		$confirmDialog.attr('data-id', vaccineHospitalId);
		$confirmDialog.modal('show');
	}

	$("#btn-delete-vaccineHospital").click(function() {
		var vaccineHospitalId = $('#confirm-delete-vaccine').attr('data-id');
		
		$.ajax({
			type : "post",
			url : "ajax-delete-vaccineHospital",
			data : JSON.stringify({'vaccineHospitalId' : vaccineHospitalId}),
			dataType : "json",
			async : false,
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type","application/json");
			},
			success: function(response) {
				$('#confirm-delete-vaccine').modal('hide');
				if(response.status == 200) {
					$("table tbody tr[data-id='" + vaccineHospitalId + "']").remove();
					alertResponseMessage(response);
				} else {
					alertResponseMessage(response);
				}
				
			},
			error: function(){		
				// TODO: handle errors
				alert('Error while delete vaccine');
			}
			
		});
	});
	
	
	$("#btnUpdate").click(function () {
		var vaccineHospitalId = $('#confirm-delete-vaccine').attr('data-id');
		location.href = "../vaccine/edit-vaccine-management";
	});
	
	
	function loadLanguageForDataTable(){
		$('#tblVaccineHospital').dataTable({
			"language": {
				"sProcessing":   "処理中...",
				//"sLengthMenu":   "_MENU_ 件表示",
				"sLengthMenu":		"_MENU_ " + vm_table_record_each_page,
				//"sZeroRecords":  "データはありません。",
				"sZeroRecords":  vm_table_empty,
				//"sInfo":         " _TOTAL_ 件中 _START_ から _END_ まで表示",
				"sInfo":         vm_s_info,
				//"sInfoEmpty":    " 0 件中 0 から 0 まで表示",
				"sInfoEmpty":    vm_table_info_empty,
				"sInfoFiltered": "（全 _MAX_ 件より抽出）",
				"sInfoPostFix":  "",
				"sSearch":       "検索:",
				"sUrl":          "",
				"oPaginate": {
					"sFirst":    "先頭",
					"sPrevious": vm_table_previous,
	        	    "sNext":     vm_table_next,
	        	    "sLast":     vm_table_last
				}
			},
			"aoColumnDefs": [{
				'bSortable': false,
				'aTargets': ['nosort']
			}]
		});
		$("#tblVaccineHospital_filter").hide();
	}
});