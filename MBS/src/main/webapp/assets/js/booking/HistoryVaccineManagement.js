$(document).ready(function(){
	initPage();
	initVaccineChildHistory();
	updateInjectedNo();
	
	function initVaccineChildHistory(childId) {
		var childId = $("#childId").val();
		var source = $("#vaccine-child-history-list").html();
		var template = Handlebars.compile(source);
		$('#tblVaccineChildHistory').dataTable().fnDestroy();;
		$.ajax({
			type: "post",
			url: "ajax-init-vaccine-child-history-list",
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
						'vaccineChildHistoryList' : response.data,
					};
					$('#vaccine-child-history-body').empty().append(template(data));
				}
				alertResponseMessage(response);
			},
			complete: function() {
				
			},
			error: function() {
				alert('Error while request vaccine schedule..');
			}
		});
		loadLanguageForDataTable();
    };
	
	function loadLanguageForDataTable(){
		$('#tblVaccineChildHistory').dataTable({
	        "language": {
	        	"sProcessing":   "処理中...",
	        	 "sLengthMenu":   "_MENU_ " + vm_table_record_each_page,
	        	 "sZeroRecords":  vm_table_empty,
	        	 "sInfo":         vm_s_info,
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
	        "bSort": false
	    });
		$("#tblVaccineChildHistory_filter").hide();
	};
	
	function initPage() {
		
		$("#injectedDateStr").datepicker({ 
			dateFormat: 'yy/mm/dd',
			maxDate: 0
		});
		
		$("#injectedDateStr").val(getCurrentDate());
	};
	
	function getCurrentDate() {
		var now = new Date();
	    var day = ("0" + now.getDate()).slice(-2);
	    var month = ("0" + (now.getMonth() + 1)).slice(-2);
	    var today = now.getFullYear() +"/"+ month +"/"+ day+"";
	    return today;
	};
	
	$(".btn-delete").on("click", function(event) {
		var $target = $(event.currentTarget);
		var vaccineChildId = $target.closest("tr").attr('data-id');
		var $confirmDialog = $('#deleteVaccineChildHistory');
		$confirmDialog.attr('data-id', vaccineChildId);
	});
	
	$("#delete-vaccine-history").click(function() {
		var vaccineChildId = $('#deleteVaccineChildHistory').attr('data-id');
		$.ajax({
			type : "post",
			url : "ajax-delete-vaccine-child-history",
			data : JSON.stringify({
				'vaccineChildId' : vaccineChildId,
			}),
			dataType : "json",
			async : false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				$('#deleteVaccineChildHistory').modal('hide');
				if(response.status == 200) {
					$("table tbody tr[data-id='" + vaccineChildId + "']").remove();
				} 
				alertResponseMessage(response);
				
			},
			error: function(){		
				// TODO: handle errors
				alert('Error while setting session');
			}
		}); 
	});
	
	
	$("#slt-vaccine").change(function() {
		updateInjectedNo();
	});
	
	function updateInjectedNo() {
		var vaccineId = $("#slt-vaccine").val();
		var childId = $("#childId").val();
		var vaccineChildHistoryModel = {
			"vaccineId" : vaccineId,
			"childId"   : childId
		};
		var optionHtml = "<option value=''>" + "-- 選択 --" + "</option>";
		$.ajax({
			type : "post",
			url : "ajax-get-injectedNo",
			data : JSON.stringify(vaccineChildHistoryModel),
			dataType : "json",
			async : false,
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept",
						"application/json");
				xhr.setRequestHeader("Content-Type",
						"application/json");
			},
			success : function(response) {
//				optionHtml += "<form:options items=" + response.data + "></form:options>";
				for (i in response.data) {
					optionHtml += "<option value=" + i + ">"
							+ response.data[i] + "回目" + "</option>";
				}
				$('#slt-injectedNo').html(optionHtml);
			},
			error : function() {
				alert('Error while request..');
			}
		});
	}
});