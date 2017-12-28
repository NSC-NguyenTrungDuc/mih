$(document).ready(function(){
	$(".btn-cancel").on("click", function(event) {
		var $target = $(event.currentTarget);
		var mailTemplateId = $target.closest("tr").attr('data-id');
		var $confirmDialog = $('#deleteMailTemplate');
		$confirmDialog.attr('data-id', mailTemplateId);
	});
	
	$("#btn-delete-mail-template").click(function() {
		var mailTemplateId = $('#deleteMailTemplate').attr('data-id');
		$.ajax({
			type : "post",
			url : "ajax-delete-mail-template",
			data : JSON.stringify({"mailTemplateId" : mailTemplateId}),
			dataType : "json",
			async : false,
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type","application/json");
			},
			success : function(response) {
				$('#deleteMailTemplate').modal('hide');
				if (response.status == 200) {
					$("table tbody tr[data-id='" + mailTemplateId + "']").remove();
				}
				alertResponseMessage(response);
			},
			complete: function() {
				
			},
			error : function() {
				alert('Error while deleting..');
			}
		});
	});
});