/**
 * @author HoanPC
 *  Function relate module profile information
 */
//Config table
var iDisplayLength = 10;
var targets = 0;
var iDisplayStart = 0;

function fillDataToTablePatientExamination(date, messagesKey)
{
	$("#list_examination_upcoming").html("");
	$("#list_examination_completed").html("");
	$("#list_examination_expired").html("");
	
	$.ajax({
		url : "get-patient-waiting-list",
		data : "examinationDate=" + date + "&iDisplayStart=0&iDisplayLength=0",
		type : "GET",

		success : function(data) {
			if(data.iTotalDisplayRecords > 0)
			{
				var aaData = data.aaData;
				jQuery.each(aaData, function(index, item) {
					/*alert(item.examinationDate + item.examinationTime + item.departmentName 
							+ item.patientName + item.patientCode + item.patientNameKana + item.receiptedTime + item.isOnline + item.status);*/
					
					//List<PatientWaitingInfo> listUpcoming = new ArrayList<PatientWaitingInfo>();
					// Display is Green
					//status = "0";
					if("0" == item.status) {
						var element =
							'<div class="col-md-4">'+
								'<div class="event-item goingon ready ready_openmovie" id="' + item.reservationCode + '*' + item.patientCode +'">'+
									'<div class="time">'+
										'<div class="clock">'+ item.examinationTimeFrm +'</div>'+
										'<div class="meta">'+ item.examinationTimeAmPm +'</div>'+
									'</div>'+
									'<div class="info">'+
										'<div>' + item.departmentName + '</div>'+
										'<div class="doctor-name">' + item.doctorName + '</div>'+
										/*'<div class="status">'+
											'<i class="icon fa fa-clock-o"></i>'+
										'</div>'+*/
										'<div class="patient-code">'+
											'<div>' + messagesKey.patientCode + '</div>'+
											'<div class="doctor-name">' + item.patientCode + '</div>'+
										'</div>'+
									'</div>'+
								'</div>'+
							'</div>';
						
						var oldHtml = $("#list_examination_upcoming").html();
						$("#list_examination_upcoming").html(oldHtml+ element);
					}
					
					// List<PatientWaitingInfo> listCompleted = new ArrayList<PatientWaitingInfo>();
					// Display is Blue
					//status = "1";
					if("1" == item.status) {
						//alert("Blue");
						var element =
							'<div class="col-md-4">'+
								'<div class="event-item complated">'+
									'<div class="time">'+
										'<div class="clock">'+ item.examinationTimeFrm +'</div>'+
										'<div class="meta">'+ item.examinationTimeAmPm +'</div>'+
									'</div>'+
									'<div class="info">'+
										'<div>' + item.departmentName + '</div>'+
										'<div class="doctor-name">' + item.doctorName + '</div>'+
										/*'<div class="status">'+
											'<i class="icon fa fa-clock-o"></i>'+
										'</div>'+*/
										'<div class="patient-code">'+
											'<div>' + messagesKey.patientCode + '</div>'+
											'<div class="doctor-name">' + item.patientCode + '</div>'+
										'</div>'+
									'</div>'+
								'</div>'+
							'</div>';
							
							var oldHtml = $("#list_examination_completed").html();
							$("#list_examination_completed").html(oldHtml+ element);
					}
					
					//List<PatientWaitingInfo> listExpired = new ArrayList<PatientWaitingInfo>();
					// Display is Gray
					//status = "-1";
					if("-1" == item.status) {
						var element =
							'<div class="col-md-4">'+
								'<div class="event-item expired">'+
									'<div class="time">'+
										'<div class="clock">'+ item.examinationTimeFrm +'</div>'+
										'<div class="meta">'+ item.examinationTimeAmPm +'</div>'+
									'</div>'+
									'<div class="info">'+
										'<div>' + item.departmentName + '</div>'+
										'<div class="doctor-name">' + item.doctorName + '</div>'+
										/*'<div class="status">'+
											'<i class="icon fa fa-clock-o"></i>'+
										'</div>'+*/
										'<div class="patient-code">'+
											'<div>' + messagesKey.patientCode + '</div>'+
											'<div class="doctor-name">' + item.patientCode + '</div>'+
										'</div>'+
									'</div>'+
								'</div>'+
							'</div>';
							
							var oldHtml = $("#list_examination_expired").html();
							$("#list_examination_expired").html(oldHtml+ element);
					}
		        });
			}
			
		},
		error : function(xhr, status, error) {
			//alert(xhr.responseText);
		}
	});
	
}

function updateMtCallingId(reservationCode, mtCallingId)
{
	$.ajax({
		url : "update-mt-calling-id",
		data : "reservationCode=" + reservationCode + "&mtCallingId=" + mtCallingId,
		type : "GET",

		success : function(data) {
			//alert(data);
		},
		error : function(xhr, status, error) {
			//alert(xhr.responseText);
		}
	});
	
}
