function addRow(tableID) {
	var table = document.getElementById(tableID).tBodies[0];
	var rowCount = table.rows.length;
	var row = table.insertRow(rowCount);

	var colCount = table.rows[0].cells.length;
	if(colCount == null) {
		
	}
	for (var i = 0; i < colCount; i++) {

		var newcell = row.insertCell(i);
		
		newcell.innerHTML = table.rows[0].cells[i].innerHTML;
		// alert(newcell.childNodes);
		switch (newcell.childNodes[0].type) {
		case "text":
			newcell.childNodes[0].value = "";
			break;
		}
	}
};

function deleteRow(tableID, currentRow) {
	try {
        var table = document.getElementById(tableID).tBodies[0];
        var rowCount = table.rows.length;
        for (var i = 0; i < rowCount; i++) {
            var row = table.rows[i];
            if (row==currentRow.parentNode.parentNode) {
                if (rowCount <= 1) {
                	validate(be041_error_delete_rows);
                    break;
                }
                table.deleteRow(i);
                rowCount--;
                i--;
            }
        }
    } catch (e) {
        alert(e);
    }
}

$(document).ready(function() {
	$('#create-and-save').on("click", createNameAndSave);
	function createNameAndSave() {
		$('#errorMessage').text('');
		var table = document.getElementById('dataTable').tBodies[0];
		var rowCount = table.rows.length;
		var lstReminderMailInfo = [];
		for (var i = 0; i < rowCount; i++) {
			var name = table.rows[i].cells[0].childNodes[0].value;
			var phone = table.rows[i].cells[1].childNodes[0].value;
			var email = table.rows[i].cells[2].childNodes[0].value;

			var reminderMailInfo = {};
			
			if (name == null || name == "" || email == null || email == "") {
//				validate("名前とメールが要求されます");
				//$('#errorMessage').text("名前とメールが要求されます");
				$('#errorMessage').text(be041_name_email_invalid);
				return;
			}
			
			if (name != null && name != "") {
				if (email == null || email == "") {
//					validate("名前が要求されます。");
					$('#errorMessage').text("メールアドレスを入力してください ");
					return;
				}
			}
			
			if (email != null && email != "") {
				if (name == null || name == "") {
//					validate("メールが要求されます。");
					$('#errorMessage').text("メールが要求されます。");
					return;
				}
			}

			if (name != null && name != "" && email != null && email != "") {
				reminderMailInfo['name'] = name;
				reminderMailInfo['phone'] = phone;
				reminderMailInfo['mail'] = email;
				lstReminderMailInfo.push(reminderMailInfo);
			}
			
		}
		
//		console.log(lstReminderMailInfo);
		$.ajax({
			url : "ajax-mail-get-list-reminder-info",
			type : "POST",
			data : JSON.stringify(lstReminderMailInfo),
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type", "application/json");
			},
			success : function(response) {
				if (response.status == 200) {
					window.location.href = response.data;
				} else {
					alertResponseMessage(response);
					response.data.forEach(function(reminderMailInfo){
						var emailTxt = $("tbody tr td input[name='email']");
						$(emailTxt).each(function(){
							if ($(this).val() == reminderMailInfo.mail) {
								$(this).closest("td").addClass("has-error");
							}
						});
					});
				}
			},
			error : function() {
				// TODO: handle errors
//				console.log('error');
			}
		});
	};
	
	$('#btn-update-mail-list').on("click", createAndUpdate);
	function createAndUpdate() {
		$('#errorMsgUpdate').text('');
		var mailListId = document.getElementById('mailListId').value;
		var tableUpdate = document.getElementById('tblMailListDetail').tBodies[0];
		var rowCount = tableUpdate.rows.length;
		var lstMailInfoUpdate = [];
		
		for (var i = 0; i < rowCount; i++) {
			var name = tableUpdate.rows[i].cells[0].childNodes[0].value;
			var phone = tableUpdate.rows[i].cells[1].childNodes[0].value;
			var email = tableUpdate.rows[i].cells[2].childNodes[0].value;
			
			var reminderMailInfo = {};
			if (name == null || name == "") {
//				validate("Please! Enter name and email.");
				$('#errorMsgUpdate').text("メールが要求されます。");
				return;
			}
			reminderMailInfo['mailListId'] = mailListId;
			reminderMailInfo['name'] = name;
			reminderMailInfo['phone'] = phone;
			reminderMailInfo['mail'] = email;
			lstMailInfoUpdate.push(reminderMailInfo);
		}
		
		
		var tableInsert = document.getElementById('tblAddMailListDetail').tBodies[0];
		var rowCountInsert = tableInsert.rows.length;
		
		for (var j = 0; j < rowCountInsert; j++) {
			var nameInsert = tableInsert.rows[j].cells[0].childNodes[0].value;
			var phoneInsert = tableInsert.rows[j].cells[1].childNodes[0].value;
			var emailInsert = tableInsert.rows[j].cells[2].childNodes[0].value;

			var reminderMailInfoInsert = {};
			if (nameInsert != null && nameInsert != "" && emailInsert != null && emailInsert != "") {
				reminderMailInfoInsert['mailListId'] = mailListId;
				reminderMailInfoInsert['name'] = nameInsert;
				reminderMailInfoInsert['phone'] = phoneInsert;
				reminderMailInfoInsert['mail'] = emailInsert;
				lstMailInfoUpdate.push(reminderMailInfoInsert);
			} 
			
			if (nameInsert != null && nameInsert != "") {
				if (emailInsert == null || emailInsert == "") {
					$('#errorMsgUpdate').text("メールアドレスを入力してください ");
					return;
				}
			}
			
			if (emailInsert != null && emailInsert != "") {
				if (nameInsert == null || nameInsert == "") {
					$('#errorMsgUpdate').text("メールが要求されます。");
					return;
				}
			}
		}
		
//		console.log(lstMailInfoUpdate);
		$.ajax({
			url : "ajax-mail-update-mail-list",
			type : "POST",
			data : JSON.stringify(lstMailInfoUpdate),
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type", "application/json");
			},
			success : function(response) {
				if (response.status == 200) {
					window.location.href = response.data;
				} else {
					alertResponseMessage(response);
					response.data.forEach(function(reminderMailInfo){
						var emailTxt = $("tbody tr td input[name='email']");
						$(emailTxt).each(function(){
							if ($(this).val() == reminderMailInfo.mail) {
								$(this).closest("td").addClass("has-error");
							}
						});
					});
				}
			},
			error : function() {
				// TODO: handle errors
				console.log('error');
			}
		});
	};
	
	$(".btn-delete-mail-confirm").on("click", function(event) {
		var $target = $(event.currentTarget);
		var email = $target.closest("tr").attr('data-id');
		var $confirmDialog = $('#deleteMailListDetail');
		$confirmDialog.attr('data-id', email);
	});
	
	$("#delete-mail").click(function() {
		var email = $('#deleteMailListDetail').attr('data-id');
		var mailListId = document.getElementById('mailListId').value;
		$.ajax({
			type : "post",
			url : "mail-ajax-delete-mail-detail",
			data : JSON.stringify({
				'mailListId' : mailListId,
				'email' : email
			}),
			dataType : "json",
			async : false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				$('#deleteMailListDetail').modal('hide');
				if(response.status == 200) {
// 					alertResponseMessage(response);
					$("table tbody tr[data-id='" + email + "']").remove();
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


function validate(message) {
	var $ajaxAlert = $('#ajax-alert-error');
	$ajaxAlert.find('#ajax-msg-error').html(message);
	$ajaxAlert.removeClass('hidden');
	window.setTimeout(function() {$ajaxAlert.addClass('hidden'); }, 5000);
};

