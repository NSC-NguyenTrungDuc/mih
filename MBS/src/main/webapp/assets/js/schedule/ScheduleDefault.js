$(document).ready(function() {
	$("#updateDefaultSchedule").click(function() {
		var defaultScheduleList = [];
		$("#defaultSchedule select").each(function(){
			var defaultSchedule = {
				'deptId' : $(this).attr('data-dept-id'),
				'deptCode' : $(this).attr('data-dept-code'),
				'defaultTimeSlot' : $(this).val(),
			};
			defaultScheduleList.push(defaultSchedule);
		});
		$.ajax({
			type : "post",
			url : "ajax-update-default-schedule-department",
			data : JSON.stringify(defaultScheduleList),
			dataType : "json",
			async : false,
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type", "application/json");
			},
			success : function(response) {
				if (response.status == 200) {
//				window.location.href = response.data;
					alertResponseMessage(response);
					window.setTimeout(function() {location.reload(); }, 2000);
				} else {
					alertResponseMessage(response);
				}
			},
			error : function() {
				alert('Error while setting session');
			}
		});
	});
	
	$("#resetDefaultSchedule").click(function() {
		location.reload();
	});
});