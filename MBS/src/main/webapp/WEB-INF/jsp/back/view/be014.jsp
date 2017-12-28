<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

<c:url var="submitUrl" value="/booking-manage/execute-import-department-schedule" />

<h2><spring:message code="be014.title.input.department.doctor" /></h2>

<div class="form-group">
	<div class="col-sm-8">${hospitalName}</div>
	<div class="col-sm-8">${departmentName}</div>
	<div class="col-sm-8"><spring:message code="be014.delete.doctor" /> ${doctorName}</div>
	<div class="col-sm-8"><spring:message code="be014.label.reservation.pending.of.doctor" /></div>
</div>

<table id="tblReservationOfDoctor" class="table table-bordered">
	<thead>
		<tr class="success">
			<td><spring:message code="be014.label.reservation.date" /></td>
			<td><spring:message code="be014.label.reservation.time" /></td>
			<td><spring:message code="be014.label.patient.name" /></td>
			<td><spring:message code="be014.label.email" /></td>
			<td><spring:message code="be014.label.phone" /></td>
		</tr>
	</thead>
	<c:forEach var="item" items="${lstReservation}">
		<tr>
			<td>${item.reservationDate}</td>
			<td>${item.reservationTime}</td>
			<td>${item.patientName}</td>
			<td>${item.email}</td>
			<td>${item.phoneNumber}</td>
		</tr>
	</c:forEach>
</table>
<div class="form-group" align="center">
	<button id="btnExport" type="button" class="btn btn-success" style="width: 270px;" ><spring:message code="be014.label.export.to.csv" /></button>
</div>
<div class="form-group" align="center">
	<button type="button" class="btn btn-danger" style="width: 270px;" data-toggle='modal' data-target='#deleteDoctor'><spring:message code="be014.delete.doctor" /> </button>
</div>

<div class="modal fade" id="deleteDoctor">
	<div class="modal-dialog modal-sm">
		<div class="modal-content">
			<div class="modal-body">
				<button type="button" class="close" data-dismiss="modal">
					<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message code="fe022.modal.close" /></span>
				</button>
				<p>
					<spring:message code="be014.modal.delete.doctor" /> 
				</p>
			</div>
			<div class="modal-footer">
				<button id="btnExecuteDelete" type="button" value="" class="btn btn-success" onclick="doDeleteDoctor(this)">
					<spring:message code="fe022.modal.confirm" />
				</button>
				<button type="button" class="btn btn-default" data-dismiss="modal">
					<spring:message code="fe022.modal.close" />
				</button>
			</div>
		</div>
	</div>
</div>

<script type="text/javascript">
	
	$(document).ready(function() {
		$("#tblReservationOfDoctor").dataTable();
		$("#tblReservationOfDoctor_filter").hide();
		$("#tblReservationOfDoctor_length").hide();
	});

	$("#btnExecuteDelete").click(function() {
		location.href = "../schedule/accept-delete-doctor?doctorId=" + '${doctorId}';
// 		var doctor = {
// 			"doctorId" : '${doctorId}'
// 		};
// 		$.ajax({
// 			type : "post",
// 			url : "ajax-delete-doctor",
// 			data : JSON.stringify(doctor),
// 			dataType : "json",
// 			async : false,
// 			beforeSend : function(xhr) {
// 				xhr.setRequestHeader("Accept", "application/json");
// 				xhr.setRequestHeader("Content-Type", "application/json");
// 			},
// 			success : function(data) {
// 				if (data == true) {
// 					$('#deleteDoctor').modal('hide');
// 				}
// 			},
// 			error : function() {
// 				alert('Error while request..');
// 			}
// 		});
	});

	$("#btnExport").click(function() {
		location.href = "../schedule/export-reservation-of-doctor?doctorId=" + '${doctorId}';
	});
	
	/*  $(".export").on('click', function (event) {
	        // CSV
	        exportTableToCSV.apply(this, [$('#tblReservationOfDoctor'), 'export1.csv']);
	        
	        // IF CSV, don't do event.preventDefault() or return false
	        // We actually need this to be a typical hyperlink
	 }); */
	 
	/* function exportTableToCSV($table, filename) {

		var $rows = $table.find('tr:has(td)'),

		// Temporary delimiter characters unlikely to be typed by keyboard
		// This is to avoid accidentally splitting the actual contents
		tmpColDelim = String.fromCharCode(11), // vertical tab character
		tmpRowDelim = String.fromCharCode(0), // null character

		// actual delimiter characters for CSV format
		colDelim = '","', rowDelim = '"\r\n"',

		// Grab text from table into CSV formatted string
		csv = '"'+ $rows.map(function(i, row) {
					var $row = $(row), $cols = $row.find('td');

					return $cols.map(function(j, col) {
						var $col = $(col), text = $col.text();

						return text.replace('"', '""'); // escape double quotes

					}).get().join(tmpColDelim);

				}).get().join(tmpRowDelim).split(tmpRowDelim).join(rowDelim)
						.split(tmpColDelim).join(colDelim) + '"',

		// Data URI
		csvData = 'data:application/csv;charset=utf-8,'+ encodeURIComponent(csv);

		$(this).attr({
			'download' : filename,
			'href' : csvData,
			'target' : '_blank'
		});
	}; */
</script>
