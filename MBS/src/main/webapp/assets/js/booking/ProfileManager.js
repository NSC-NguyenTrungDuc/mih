$(document).ready(function() {
		
		
		$("#changePassword").click(function() {
			$('#confirmChangePassword').modal('show');
		});
		
		$("#confirm-change-password").click(function() {
			$('#confirmChangePassword').modal('hide');
			$('#divInputPassnew').removeAttr('style');
			$('#divConfirmChangePass').removeAttr('style');
			$('#passWordOld').remove();
			
		});
		
		$(".btn-delete").on("click", function(event) {
			var $target = $(event.currentTarget);
			var childId = $target.closest("tr").attr('data-id');
			var $confirmDialog = $('#deleteNewborns');
			$confirmDialog.attr('data-id', childId);
		});
		
		$("#delete-borns").click(function() {
			var childId = $('#deleteNewborns').attr('data-id');
			$.ajax({
				type : "post",
				url : "mail-ajax-delete-child",
				data : JSON.stringify({
					'childId' : childId,
				}),
				dataType : "json",
				async : false,
				beforeSend: function(xhr) {
		            xhr.setRequestHeader("Accept", "application/json");
		            xhr.setRequestHeader("Content-Type", "application/json");
		        },
				success: function(response) {
					$('#deleteNewborns').modal('hide');
					if(response.status == 200) {
						$("table tbody tr[data-id='" + childId + "']").remove();
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