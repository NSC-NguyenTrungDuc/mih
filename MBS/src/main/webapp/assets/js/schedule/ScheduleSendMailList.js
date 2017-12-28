$(document).ready(function() {
	
	//updateDepartment();
	updateDoctor();
	
//	$("#slt-hospital").change(function() {
//		updateDepartment();
//		updateDoctor();
//	});

//	function updateDepartment() {
//		var hospitalId = $("#slt-hospital").val();
//		var hospitalModel = {
//			"hospitalId" : hospitalId
//		};
//		var optionHtml = "<option value=''>" + "診療科選択" + "</option>";
//		$.ajax({
//			type : "post",
//			url : "ajax-get-department-in-hospital",
//			data : JSON.stringify(hospitalModel),
//			dataType : "json",
//			async : false,
//			beforeSend : function(xhr) {
//				xhr.setRequestHeader("Accept",
//						"application/json");
//				xhr.setRequestHeader("Content-Type",
//						"application/json");
//			},
//			success : function(response) {
//				for (i in response.data) {
//					optionHtml += "<option value="+ i +">"
//							+ response.data[i] + "</option>";
//				}
//				$('#slt-department').html(optionHtml);
//			},
//			error : function() {
//				alert('Error while request..');
//			}
//		});
//	}
	
	$("#slt-department").change(function() {
		updateDoctor();
	});
	
	function updateDoctor() {
		var deptId = $("#slt-department").val();
		var departmentModel = {
			"deptId" : deptId
		};
		var optionHtml = "<option value=''>" + "</option>";
		$.ajax({
			type : "post",
			url : "ajax-get-doctor-in-department",
			data : JSON.stringify(departmentModel),
			dataType : "json",
			async : false,
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept",
						"application/json");
				xhr.setRequestHeader("Content-Type",
						"application/json");
			},
			success : function(response) {
				for (i in response.data) {
					optionHtml += "<option value="+ i +">"
							+ response.data[i] + "</option>";
				}
				$('#slt-doctor').html(optionHtml);
			},
			error : function() {
				alert('Error while request..');
			}
		});
	}
	
	$("#btn-send-email").click(function() {
		$('#selectMailTemp').text("");
		var mailListSends = [];
		$("table tbody tr").each(function() {
			var mailListSendInfo = {
				'mailListId' : $(this).find("td.chk-send-email input").val(),
				'name' : $(this).find(".name").text(),
				'phone' :$(this).find("#phone").text(),
				'email' : $(this).find(".email").text(),
				'isSentEmail' : $(this).find("td.chk-send-email input").is(":checked"),
			};

			if($(this).find("td.chk-send-email input").is(":checked") == true) {
				mailListSends.push(mailListSendInfo);
			}
			
		});
		
		$.ajax({
			type: "post",
			url: "ajax-mail-send-mail-list-confirm",
			data: JSON.stringify(mailListSends),
			dataType: "json",
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				if (response.status == 200) {
					var templateId = $('select#slt-mail-template').val();
					var doctorId = $("#slt-doctor").val();
					if(templateId == "" || templateId == null) {
						//$('#selectMailTemp').text("メールテンプレートを選択してください");'
						$('#selectMailTemp').text(be043_email_template_required);
					} else {
						window.location.href = response.data + "?templateId=" + templateId + "&doctorId=" +doctorId;
					}
				} else {
					alertResponseMessage(response);
				}
			},
			error: function(){		
				// TODO: handle errors
				alert('Error while setting session');
			}
		});
	});
});