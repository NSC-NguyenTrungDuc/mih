$(document).ready(function() {
	initPage();
	loadLanguageForDataTable();
	
	$("#searchBtn").click(function() {
		var email = $("#email").val();
		var patientName = $("#patientName").val();
		var nameFurigana = $("#nameFurigana").val();
		var hospitalId = $("#hospitalId").val();
		var deptId = $("#deptId").val();
		var reservationFromDate = $("#reservationFromDate").val();
		var reservationToDate = $("#reservationToDate").val();
		
		var data = {"email":email,"patientName":patientName,"nameFurigana":nameFurigana,"hospitalId":hospitalId,"deptId":deptId,"reservationFromDate":reservationFromDate,"reservationToDate":reservationToDate };
		var dataHtml= "";
		$('#tblSearchBooking').dataTable().fnDestroy();
		$.ajax({
			type : "post",
			url : "ajax-search-reservation",
			data : JSON.stringify(data),
			dataType : "json",
			async : false,
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type","application/json");
			},
			success : function(response) {
				var source = $("#search-result").html();
				var template = Handlebars.compile(source);
				dataHtml = template({'reservations': response.data});
			},
			complete: function() {
				$('#search-result-body').empty().html(dataHtml);
				$(".timeSlot").each(function() {
				    var val = $(this).text();
				    $(this).text(insertString(2, val, ":"));
				});
				
				$(".reservationStatus").each(function() {
					var selectedValue = $(this).find(".stt").val();
					$(this).find("select option[value="+selectedValue+"]").attr('selected','selected');
				});
				$('.cancel-bk-btn').on('click', showConfirmDialog);
			},
			error : function() {
				alert('Error while request..');
			}
		});
		loadLanguageForDataTable();
		$(".rsvStatus").change(function(){
			var reservationId = $(this).parent().find(".rsi").val();
			var reservationStatus = $(this).val();
			$.ajax({
				type : "post",
				url : "ajax-update-reservation-status",
				data : JSON.stringify({"reservationId" : reservationId,"reservationStatus":reservationStatus}),
				dataType : "json",
				async : false,
				beforeSend : function(xhr) {
					xhr.setRequestHeader("Accept", "application/json");
					xhr.setRequestHeader("Content-Type","application/json");
				},
				success : function(response) {
					alertResponseMessage(response);
				},
				complete: function() {
					
				},
				error : function() {
					alert('Error while request..');
				}
			});
		});
	});
	
	function initPage() {
		
		$("#reservationFromDate").datepicker({ 
			dateFormat: 'yy/mm/dd',
			onClose: function( selectedDate ) {
		        $( "#reservationToDate" ).datepicker( "option", "minDate", selectedDate );
		      }
		});
		
		$("#reservationToDate").datepicker({ 
			dateFormat: 'yy/mm/dd', 
			onClose : function( selectedDate ) {
		        $( "#reservationFromDate" ).datepicker( "option", "maxDate", selectedDate );
		    }
		});
		
		$("#reservationToDate").val(getDate(new Date()));
		$("#reservationFromDate").val(getDate(new Date()));
	}
	
	function getDate(date) {
	    var day = ("0" + date.getDate()).slice(-2);
	    var month = ("0" + (date.getMonth() + 1)).slice(-2);
	    var result = date.getFullYear() +"/"+ month +"/"+ day+"";
	    return result;
	}
	
	function insertString(index, sourceString, addString) {
		  if (index > 0)
		    return sourceString.substring(0, index) + addString + sourceString.substring(index, sourceString.length);
		  else
		    return addString + sourceString;
	}; 
	
	function showConfirmDialog(event) {
		var $target = $(event.currentTarget);
		var resId = $target.attr('data-id');
		var date = $target.attr('data-date');
		var time = $target.attr('data-time');
		var vaccineChildId = $target.attr('data-vaccineChildId');
		
		var $confirmDialog = $('#confirm-cancel');
		$confirmDialog.attr('data-id', resId);
		$confirmDialog.attr('data-date', date);
		$confirmDialog.attr('data-time', time);
		$confirmDialog.attr('data-vaccineChildId', vaccineChildId);
		$confirmDialog.modal('show');
	}
	
	$("#btn-cancel-booking").click(function() {
		var reservationId = $('#confirm-cancel').attr('data-id');
		var date = $('#confirm-cancel').attr('data-date');
		var time = $('#confirm-cancel').attr('data-time');
		var vaccineChildId = $('#confirm-cancel').attr('data-vaccineChildId');
		$.ajax({
			type : "post",
			url : "ajax-cancel-reservation",
			data : JSON.stringify({"reservationId" : reservationId, "reservationDate" : date, "reservationTime" : time, "vaccineChildId" : vaccineChildId}),
			dataType : "json",
			async : false,
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type","application/json");
			},
			success : function(response) {
				$('#confirm-cancel').modal('hide');
				if (response.status == 200) {
					$('#search-result-body tr td a[data-id="' + reservationId + '"]').closest("tr").find(".reservationStatus .rsvStatus").val("5");
//					$('#search-result-body tr td a[data-id="' + reservationId + '"]').closest("tr").find(".reservationInfoBooking").html("");
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
	
	function loadLanguageForDataTable(){
		$('#tblSearchBooking').dataTable({
	        "language": {
	        	 "sProcessing":   "処理中...",
	        	 //"sLengthMenu":   "_MENU_ 件表示",
	        	 "sLengthMenu":		"_MENU_ " + be006_table_record_each_page,
	        	 //"sZeroRecords":  "データはありません。",
	        	 "sZeroRecords":  be006_table_empty,
	        	 //"sInfo":         " _TOTAL_ 件中 _START_ から _END_ まで表示",
	        	 "sInfo":         be006_s_info,
	        	 //"sInfoEmpty":    " 0 件中 0 から 0 まで表示",
	        	 "sInfoEmpty":    be006_table_info_empty,
	        	 "sInfoFiltered": "（全 _MAX_ 件より抽出）",
	        	 "sInfoPostFix":  "",
	        	 "sSearch":       "検索:",
	        	 "sUrl":          "",
	        	 "oPaginate": {
	        	 	"sFirst":    "先頭",
	        	    "sPrevious": be006_table_previous,
	        	    "sNext":     be006_table_next,
	        	    "sLast":     be006_table_last
	        	 }
	        },
	        "aoColumnDefs": [{
		        'bSortable': false,
		        'aTargets': ['nosort']
		    }]
	    });
		$("#tblSearchBooking_filter").hide();
	}
	
	 $("#hospitalId").change(function() {
		 var hospitalId = $(this).val();
		 $.ajax({
				type : "post",
				url : "ajax-get-department-list",
				data : JSON.stringify({"hospitalId" : hospitalId}),
				dataType : "json",
				async : false,
				beforeSend : function(xhr) {
					xhr.setRequestHeader("Accept", "application/json");
					xhr.setRequestHeader("Content-Type","application/json");
				},
				success : function(response) {
					var allValue = $("#allValue").text();
					var html = '<select id="deptId" name="deptId" class="form-control"><option value="-1"> ' + allValue + '</option>';
					for (i in response.data) {
						html += '<option value="' + i + '">'+ response.data[i] + '</option>';
					}
					html += '</select>';
					$("#deptId").closest("div").html(html);
				},
				complete: function() {
					
				},
				error : function() {
					alert('Error while get department list..');
				}
			});
     }); 
	 
	if ($("#searchDate").text() != "") {
		var date = new Date($("#searchDate").text()); 
		$("#reservationToDate").val(getDate(date));
		$("#reservationFromDate").val(getDate(date));
		if ($("#vaccineDeptId").text() != "") {
			$("#deptId").val($("#vaccineDeptId").text());
		}
		$("#searchBtn").trigger("click");
	}
});
