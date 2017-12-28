$(document).ready(function() {
	$("#delete-mail-list").click(function() {
		$("#message").text("");
		var mailListId = $("form#mailList select").val();
		if (mailListId == null || mailListId == -1) {
			//$("#message").text("メールリストを選択してください");
			$("#message").text(be040_email_group_invalid);
			$("#confirmDeleteMailList").modal("hide");
			return;
		}
		$.ajax({
			type : "post",
			url : "mail-ajax-delete-mail-list",
			data : JSON.stringify({
				"mailListId" : mailListId
			}),
			dataType : "json",
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type", "application/json");
			},
			success : function(response) {
				$('#confirmDeleteMailList').modal('hide');
				if (response.status == 200) {
					$("#mailListId option[value=" + mailListId + "]").remove();
					window.location.href = response.data;
					alertResponseMessage(response);
				} else {
					alertResponseMessage(response);
				}
			},
			error : function() {
				alert('Error while setting session');
			}
		});
	});
	
	$("#update-mail-list").on("click", function(){
		$("#message").text("");
		var mailListId = $("form#mailList select").val();
		if (mailListId == null || mailListId == -1) {
			//$("#message").text("メールリストを選択してください");
			$("#message").text(be040_email_group_invalid);
		} else {
			window.location.href = "mail-update-mail-list?mailListId=" + mailListId;
		}
	});
	
	$("#export-csv").on("click", function() {
		$("#message").text("");
		var mailListId = $("form#mailList select").val();
		if (mailListId == null || mailListId == -1) {
			//$("#message").text("メールリストを選択してください");
			$("#message").text(be040_email_group_invalid);
		} else {
			window.location.href = "mail-export-csv-mailList?mailListId=" + mailListId;
		}
		
	});
	
});
