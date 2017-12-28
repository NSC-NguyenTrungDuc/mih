$(document).ready(function() {
	
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

	$("#btn-add-new-detail").on("click", function(){
		var mailListId = document.getElementById('mailListId').value;
		window.location.href = "mail-add-new-mailDetail?mailListId=" + mailListId;
	});
	
	
	$('#btn-add-mail-detail').on("click", createNameAndSave);
	function createNameAndSave() {
		var table = document.getElementById('dataTable');
		var rowCount = table.rows.length;
		var lstReminderMailInfo = [];
		for (var i = 0; i < rowCount; i++) {
			var name = table.rows[i].cells[1].childNodes[0].value;
			var email = table.rows[i].cells[2].childNodes[0].value;

			var reminderMailInfo = {};
			if (name == null || name == "" || email == null || email == "") {
				alert('Please! Enter name and email.');
				return;
			}
			if (ValidateEmail(email) == false) {
				alert("You have entered an invalid email address!");
				return;
			}
			reminderMailInfo['name'] = name;
			reminderMailInfo['mail'] = email;
			lstReminderMailInfo.push(reminderMailInfo);
		}
		
		$.ajax({
			url : "ajax-mail-add-mail-detail-for-update",
			type : "POST",
			data : JSON.stringify(lstReminderMailInfo),
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type", "application/json");
			},
			success : function(response) {
				if (response.status == 200) {
					window.location.href = response.data;
				}
			},
			error : function() {
				// TODO: handle errors
//				console.log('error');
			}
		});
	}
});


function addMailDetailRow() {
	var table = document.getElementById('tblMailListDetail').tBodies[0];

	var rowCount = table.rows.length;
	var row = table.insertRow(rowCount);

	var colCount = table.rows[0].cells.length;
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