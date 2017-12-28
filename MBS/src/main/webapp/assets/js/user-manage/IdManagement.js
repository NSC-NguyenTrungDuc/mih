$(document).ready(function() {
	$(".roleSelect").change(function() {
		var loginId = $(this).parent().parent().find("td:first").text();
		var roleId = $(this).val();
		var model = {"loginId":loginId,"roleId":roleId};
		$.ajax({
			type : "post",
			url : "ajax-update-role-for-user",
			data : JSON.stringify(model),
			dataType : "json",
			async : false,
			beforeSend : function(xhr) { 
				xhr.setRequestHeader("Accept","application/json");
				xhr.setRequestHeader("Content-Type","application/json");
			},
			success : function(response) {
				alertResponseMessage(response);
			},
			error : function() {
				alert('Error while request..');
			}
		}); 
	});
	
	$("#btnExecuteDelete").click(function() {
		var loginId = $(this).val();
		var model = {"loginId":loginId};
		$.ajax({
			type : "post",
			url : "ajax-delete-user",
			data : JSON.stringify(model),
			dataType : "json",
			async : false,
			beforeSend : function(xhr) { 
				xhr.setRequestHeader("Accept","application/json");
				xhr.setRequestHeader("Content-Type","application/json");
			},
			success : function(response) {
				$('#deleteUser').modal('hide');
				if(response.status == 200) {
					window.setTimeout(function() {location.reload(); }, 2000);
				}
				alertResponseMessage(response);
			},
			error : function() {
				alert('Error while request..');
			}
		}); 
	});
	
	
	$("#btnExecuteAddUser").click(function(){
		var loginId = $("#loginId").val();
		var roleId = $("#roleId").val();
		var loginPass = $("#loginPass").val();
		var model = {"loginId":loginId,"roleId":roleId,"loginPass":loginPass};
		$.ajax({
			type : "post",
			url : "ajax-add-new-user",
			data : JSON.stringify(model),
			dataType : "json",
			async : false,
			beforeSend : function(xhr) { 
				xhr.setRequestHeader("Accept","application/json");
				xhr.setRequestHeader("Content-Type","application/json");
			},
			success : function(response) {
				if(response.status == 200) {
					window.setTimeout(function() {location.reload(); }, 2000);
				}
				alertResponseMessage(response);
				$('#divAddNewUser').modal('hide');
			},
			error : function() {
				alert('Error while request..');
			}
		}); 
	});
	$("#tblIdManagement").dataTable({
        "bSort": false,
        "fnCreatedRow": function( nRow, aData, iDataIndex ) {
            $(nRow).children("td").css("overflow", "hidden");
            $(nRow).children("td").css("white-space", "nowrap");
            $(nRow).children("td").css("text-overflow", "ellipsis");
        },
		"language": {
			"sZeroRecords"		:  re007_table_empty,
				"sInfo"			:  re007_s_info,
				"sInfoEmpty"	:  re007_table_info_empty,
				"oPaginate": {
					"sPrevious"	: 	re007_table_previous,
					"sNext"		:   re007_table_next,
					"sLast"		:   re007_table_last
				}
		},
		"bSort": false
	});
	$("#tblIdManagement_filter").hide();
	$("#tblIdManagement_length").hide();
}); 

function setUserToDelete(field) {
	var loginId = $(field).parent().parent().find("td:first").text();
	$("#btnExecuteDelete").val(loginId);
}
