$(document).ready(function(){
	loadLanguageForDataTable();
	
	$("#btnSearch").click(function () {
		var name = $("#name").val();
		var furigana = $("#nameFurigana").val();
		var phoneNumber = $("#phoneNumber").val();
		var email = $("#email").val();
		var userModel = {"name" : name, "nameFurigana" : furigana, "phoneNumber" : phoneNumber, "email" : email};
		
		var source = $("#search-result").html();
		var template = Handlebars.compile(source);
		$('#tblUserSchedule').dataTable().fnDestroy();
		$.ajax({
			type: "post",
			url: "ajax-search-user",
			data: JSON.stringify(userModel),
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				if (response.status == 200) {
					var data = {
						'userModels' : response.data,
					};
					$('#user-info-body').empty().append(template(data));
				}
//				alertResponseMessage(response);
			},
			complete: function() {
				$(".btn-delete").click(function (event) {
					var $target = $(event.currentTarget);
					var userId = $target.closest("tr").attr('data-id');
					var $confirmDialog = $('#deleteAccount');
					$confirmDialog.attr('data-id', userId);
				});
			},
			error: function() {
				alert('Error while request user ...');
			}
		});
		loadLanguageForDataTable();
	});
	
	function loadLanguageForDataTable() {
		$('#tblUserSchedule').dataTable({
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
		$("#tblUserSchedule_filter").hide();
	}

	$("#delete-account").click(function() {
		var userId = $('#deleteAccount').attr('data-id');
		$.ajax({
			type : "post",
			url : "ajax-delete-account",
			data : JSON.stringify({
				'userId' : userId,
			}),
			dataType : "json",
			async : false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				$('#deleteAccount').modal('hide');
				if(response.status == 200) {
					var table = $('#tblUserSchedule').dataTable();
					var index = $("table tbody tr[data-id='" + userId + "']").index();
					table.fnDeleteRow(index);
				} 
				alertResponseMessage(response);
				
			},
			error: function(){		
				// TODO: handle errors
				alert('Error while setting session');
			}
		}); 
	});
}); 