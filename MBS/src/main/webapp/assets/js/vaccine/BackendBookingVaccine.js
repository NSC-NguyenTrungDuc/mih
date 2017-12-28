$(document).ready(function(){
	
	loadLanguageForDataTable();
	loadLanguageForChildTable();
	
	$("#btnSearch").click(function () {
		var name = $("#name").val();
		var furigana = $("#nameFurigana").val();
		var phoneNumber = $("#phoneNumber").val();
		var email = $("#email").val();
		var userModel = {"name" : name, "nameFurigana" : furigana, "phoneNumber" : phoneNumber, "email" : email};
		
		var source1 = $("#list-child-result").html();
		var template1 = Handlebars.compile(source1);
		
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

					document.getElementById("info-vaccine").style.display = "none";
					$('#tblChildSchedule').dataTable().fnClearTable();
				}
//				alertResponseMessage(response);
			},
			complete: function() {
				$(".select-user").click(function() {
					document.getElementById("info-vaccine").style.display = "none";
					var userId = $(this).closest("tr").find("td input.select-user").val();
					// Show info child
					$('#tblChildSchedule').dataTable().fnDestroy();
					$.ajax({
						type: "post",
						url: "ajax-search-user-child",
						data: JSON.stringify({"userId" : userId}),
						dataType: "json",
						async: false,
						beforeSend: function(xhr) {
				            xhr.setRequestHeader("Accept", "application/json");
				            xhr.setRequestHeader("Content-Type", "application/json");
				        },
				        success: function(response) {
							if (response.status == 200) {
								var data = {
									'lstChild' : response.data,
								};
								$('#child-info-body').empty().append(template1(data));
							}
//							alertResponseMessage(response);
						},
						complete: function() {
							$(".select-child").click(function() {
								var vaccindId = $("#slt-vaccine").val();
								var childId =  $(this).closest("tr").find("td input.select-child").val();
								getInfoVaccine(vaccindId, childId);
							});
						},
						error: function() {
							alert('Error while request user ...');
						}
					});
					loadLanguageForChildTable();
				});
			},
			error: function() {
				alert('Error while request user ...');
			}
		});
		loadLanguageForDataTable();
	});
	
	function loadLanguageForDataTable(){
		$('#tblUserSchedule').dataTable({
	        "language": {
	        	 "sProcessing":   "処理中...",
	        	 //"sLengthMenu":   "_MENU_ 件表示",
	        	 "sLengthMenu":   "_MENU_ " + be301_table_record_each_page,
	        	 //"sZeroRecords":  "データはありません。",
	        	 "sZeroRecords":  be301_table_empty,
	        	 //"sInfo":         " _TOTAL_ 件中 _START_ から _END_ まで表示",
	        	 "sInfo":         be301_s_info,
	        	 //"sInfoEmpty":    " 0 件中 0 から 0 まで表示",
	        	 "sInfoEmpty":    be301_table_info_empty,
	        	 "sInfoFiltered": "（全 _MAX_ 件より抽出）",
	        	 "sInfoPostFix":  "",
	        	 "sSearch":       "検索:",
	        	 "sUrl":          "",
	        	 "oPaginate": {
	        	 	"sFirst":    "先頭",
	        	    "sPrevious": be301_table_previous,
	        	    "sNext":     be301_table_next,
	        	    "sLast":     be301_table_last
	        	 }
	        },
	        "bSort": false
	    });
		$("#tblUserSchedule_filter").hide();
	}
	
	function loadLanguageForChildTable(){
		$('#tblChildSchedule').dataTable({
	        "language": {
	        	 "sProcessing":   "処理中...",
	        	 //"sLengthMenu":   "_MENU_ 件表示",
	        	 "sLengthMenu":   "_MENU_ " + be301_table_record_each_page,
	        	 //"sZeroRecords":  "データはありません。",
	        	 "sZeroRecords":  be301_table_empty,
	        	 //"sInfo":         " _TOTAL_ 件中 _START_ から _END_ まで表示",
	        	 "sInfo":         be301_s_info,
	        	 //"sInfoEmpty":    " 0 件中 0 から 0 まで表示",
	        	 "sInfoEmpty":    be301_table_info_empty,
	        	 "sInfoFiltered": "（全 _MAX_ 件より抽出）",
	        	 "sInfoPostFix":  "",
	        	 "sSearch":       "検索:",
	        	 "sUrl":          "",
	        	 "oPaginate": {
	        	 	"sFirst":    "先頭",
	        	    "sPrevious": be301_table_previous,
	        	    "sNext":     be301_table_next,
	        	    "sLast":     be301_table_last
	        	 }
	        },
	        "bSort": false
	    });
		$("#tblChildSchedule_filter").hide();
	}
	
	$("#slt-vaccine").change(function() {
		var vaccineId = $("#slt-vaccine").val();
		var childId = "";
		$("#tblChildSchedule tbody tr").each(function() {
			if ($(this).find("td input.select-child").is(":checked") == true) {
				childId = $(this).find("td input.select-child").val();
			}
		});
		getInfoVaccine(vaccineId, childId);
		
	});
	
	function getInfoVaccine(vaccineId, childId) {
		var infoVaccineId = document.getElementById("info-vaccine");
		$.ajax({
			type: "post",
			url: "ajax-init-info-vaccine",
			data: JSON.stringify({"childId" : childId, "vaccineId" : vaccineId}),
			dataType: "json",
			async: false,
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				if (response.status == 200) {
					document.getElementById("btnSubmit").style.display = "block";
					infoVaccineId.style.display = "block";
					var infoVaccine = response.data;
					$("#fromAge").val(infoVaccine.fromYear);
					$("#toDate").val(infoVaccine.toYear);
					$("#timeUsing").val(infoVaccine.injectdNoCurrent + "/" + infoVaccine.totalInject);
					$("#bookingDateFormat").val(infoVaccine.fromDateFormat);
					$("#bookingDate").val(infoVaccine.strFromDate);
					$("#timeUsingValue").val(infoVaccine.injectdNoCurrent + 1);
				} else if (response.status == 405) {
					document.getElementById("btnSubmit").style.display = "none";
					infoVaccineId.style.display = "block";
					var infoVaccine = response.data;
					$("#fromAge").val(infoVaccine.fromYear);
					$("#toDate").val(infoVaccine.toYear);
					$("#timeUsing").val(infoVaccine.injectdNoCurrent + "/" + infoVaccine.totalInject);
					$("#bookingDateFormat").val(infoVaccine.fromDateFormat);
					$("#bookingDate").val(infoVaccine.strFromDate);
					$("#timeUsingValue").val(infoVaccine.injectdNoCurrent + 1);
					alertResponseMessage(response);
				} else {
					infoVaccineId.style.display = "none";
//					alertResponseMessage(response);
				}
			},
			complete: function() {
			},
			error: function() {
				alert('Error while request vaccine info ...');
			}
		});
	}
	
	
	$("#btnSubmit").click(function () {
		var vaccineId = $("#slt-vaccine").val();
		var userId = "";
		$("#tblUserSchedule tbody tr").each(function() {
			if ($(this).find("td input.select-user").is(":checked") == true) {
				userId = $(this).find("td input.select-user").val();
			}
		});
		var childId = "";
		$("#tblChildSchedule tbody tr").each(function() {
			if ($(this).find("td input.select-child").is(":checked") == true) {
				childId = $(this).find("td input.select-child").val();
			}
		});
		var dateBooking = $("#bookingDate").val();
		var timeUsing = $("#timeUsingValue").val();
		location.href = "../booking-manage/select-time-booking-vaccine?vaccineId=" + vaccineId + "&childId=" + childId + "&dateBooking=" + dateBooking + "&userId=" + userId + "&timeUsing=" + timeUsing;
	});
});
