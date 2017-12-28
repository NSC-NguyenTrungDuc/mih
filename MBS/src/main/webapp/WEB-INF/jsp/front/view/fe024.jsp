<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<c:url var="confirmUrl" value="/booking/booking-change-accept" />
<!-- Change URL after cancelling -->
<c:url var="cancelUrl" value="/booking/booking-change" />

<div id="booking-change-confirm-wrapper" class="form-horizontal">
	<div id="booking-change-confirm-info">
		<div class="form-group">
			<div class="col-xs-12">
				<p class="form-control-static"><spring:message code="fe024.message.header" /></p>
			</div>
		</div>
		<div class="form-group">
			<label class="col-xs-12 col-sm-3 control-label"> <spring:message code="fe024.label.name" />
			</label>
			<div class="col-xs-12 col-sm-9">
				<p class="form-control-static">${reservation.patientName}</p>
			</div>
		</div>
		<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
		<div class="form-group">
			<label class="col-xs-12 col-sm-3 control-label"> <spring:message code="fe024.label.furigana" />
			</label>
			<div class="col-xs-12 col-sm-9">
				<p class="form-control-static">${reservation.nameFurigana}</p>
			</div>
		</div>
		<%} %>
		<div class="form-group">
			<label class="col-xs-12 col-sm-3 control-label"> <spring:message code="fe024.label.phone" />
			</label>
			<div class="col-xs-12 col-sm-9">
				<p class="form-control-static">${reservation.phoneNumber}</p>
			</div>
		</div>
		<div class="form-group">
			<label class="col-xs-12 col-sm-3 control-label"> <spring:message code="fe024.label.email" />
			</label>
			<div class="col-xs-12 col-sm-9">
				<p class="form-control-static">${reservation.email}</p>
			</div>
		</div>
		<div class="form-group">
			<label class="col-xs-12 col-sm-3 control-label"> <spring:message code="general.label.sex" />
			</label>
			<div class="col-xs-12 col-sm-9">
				<p class="form-control-static">${patient.genderText}</p>
			</div>
		</div>
		<div class="form-group">
			<label class="col-xs-12 col-sm-3 control-label"> <spring:message code="re008.label.birthday" />
			</label>
			<div class="col-xs-12 col-sm-9">
				<p class="form-control-static">${patient.formattedBirthDay}</p>
			</div>
		</div>
		<div class="form-group">
			<label class="col-xs-12 col-sm-3 control-label"> <spring:message code="fe024.label.card.number" />
			</label>
			<div class="col-xs-12 col-sm-9">
				<p class="form-control-static">${reservation.cardNumber}</p>
			</div>
		</div>
		<c:if test="${bookingVaccine}">
			<div class="form-group">
<%-- 				<label class="col-xs-12 col-md-3 control-label"> <spring:message --%>
<%-- 						code="fe003.label.detail.bookingVaccine" /> --%>
<!-- 				</label> -->
				<div class="col-sm-12">
					<table id="dataTable" class="table table-bordered">
						<thead>
							<tr>
								<th width="" style="text-align: center;"><spring:message
										code="fe003.label.child.name" /></th>
								<th width="" style="text-align: center;"><spring:message
										code="fe003.label.child.dob" /></th>
								<th width="" style="text-align: center;"><spring:message
										code="general.label.sex" /></th>
								<th width="" style="text-align: center;"><spring:message
										code="fe003.label.vaccine" /></th>
								<th width="" style="text-align: center;"><spring:message
										code="fe003.label.dateTimeUsing" /></th>
							</tr>
						</thead>
						<tbody>
							<tr>
								<td style="text-align: center;">${childName}</td>
								<td style="text-align: center;">${dob}</td>
								<td style="text-align: center;"><c:choose>
										<c:when test="${sex == '1'}">
											<spring:message code="general.label.sex.male" />
										</c:when>
										<c:otherwise>
											<spring:message code="general.label.sex.female" />
										</c:otherwise>
									</c:choose></td>
								<td style="text-align: center;">${vaccineName}</td>
								<td style="text-align: center;">${injectedNo}</td>
							</tr>
						</tbody>
					</table>
				</div>
			</div>
		</c:if>
		<div class="form-group">
			<label class="col-xs-12 col-sm-3 control-label"> <spring:message
					code="fe024.label.reminder.time" />
			</label>
			<div class="col-xs-12 col-sm-9">
				<p class="form-control-static">
					<spring:message
						code="${reservation.mapReminderTime.get(reservation.reminderTime)}" />
				</p>
			</div>
		</div>
		<div class="form-group">
			<div class="col-xs-12 col-md-12">
				<p class="form-control-static">${reservation.deptName} ${reservation.doctorName} ${reservation.formattedReservationDate} ${reservation.formattedReservationTime}</p>
			</div>
		</div>
		<div class="form-group">
			<div class="col-md-offset-3 col-md-12">
				<button type="button" class="btn btn-success" id="btnSubmit">
					<spring:message code="fe024.button.changeSchedule"/>
				</button> 
				<button type="button" class="btn btn-default" onclick="location.href='${cancelUrl}'">
					<spring:message code="fe024.button.back"/>
				</button>
			</div>
		</div>
	</div><!-- End #booking-change-confirm-info -->
</div><!-- End #booking-change-confirm-wrapper -->
<script type="text/javascript">
	$("#btnSubmit").click(function(){
		$("#btnSubmit").attr("disabled", "disabled");
		window.location.href = '${confirmUrl}'; 
	});
</script>