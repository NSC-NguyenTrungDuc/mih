$(document).ready(function(){
	
	$('#confirm-add').on("click", acceptAddDepartment);
	function acceptAddDepartment() {
		var deptName = $("#inputDeptName").val();
		var displayOrder = $("#inputDisplayOrder").val();

		var object = {
				deptName : deptName,
				displayOrder : displayOrder
		};

		$.ajax({
			url: "accept-add-department",
			type : "POST",
			data : JSON.stringify(object),
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
			}
		});
	}
});
