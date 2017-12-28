<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

<c:url var="bookingChangeUrl" value="/booking-manage/save-change-booking-time?vaccineChildId=${bookingInfo.vaccineChildHistoryId}" />
<form:form method="post" action="${bookingChangeUrl}" modelAttribute="reservation" class="form-horizontal">
<div id="booking-info">
	
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="fe003.label.name" />
		</div>
		<div class="col-xs-8 col-md-8"><form:label path="patientName">${reservation.patientName}</form:label></div>
	</div>
	<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="fe003.label.furigana" />
		</div>
		<div class="col-xs-8 col-md-8">${reservation.nameFurigana}</div>
	</div>
	<%} %>
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="fe003.label.phone" />
		</div>
		<div class="col-xs-8 col-md-8">${reservation.phoneNumber}</div>
	</div>
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="fe003.label.email" />
		</div>
		<div class="col-xs-8 col-md-8">${reservation.email}</div>
	</div>
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="general.label.sex" />
		</div>
		<div class="col-xs-8 col-md-8">${patient.genderText}</div>
	</div>
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="re008.label.birthday" />
		</div>
		<div class="col-xs-8 col-md-8">${patient.formattedBirthDay}</div>
	</div>
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="fe003.label.ticket" />
		</div>
		<div class="col-xs-8 col-md-8">${reservation.cardNumber}</div>
	</div>
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="fe003.label.time.reminder" /> 
		</div>
		<div class="col-xs-8 col-md-8">${mapReminderTime.get(reservation.reminderTime)}</div>
	</div>
	<c:if test="${isChangeBookingVaccine}">
<!-- 	<div class="row extend-row"> -->
<%-- 		<label class="col-xs-12 col-md-3 control-label"> <spring:message code="fe003.label.detail.bookingVaccine" /></label> --%>
<!-- 	</div> -->
	<div class="row extend-row">
		<div class="col-xs-12 ">
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
						<td style="text-align: center;">${bookingInfo.childName}</td>
						<td style="text-align: center;">${bookingInfo.dob}</td>
						<td style="text-align: center;">
							<c:choose>
								<c:when test="${bookingInfo.sex == '1'}">
									<spring:message code="general.label.sex.male" />
								</c:when>
								<c:otherwise>
									<spring:message code="general.label.sex.female" />
								</c:otherwise>
							</c:choose>
						</td>
						<td style="text-align: center;">${bookingInfo.vaccineName}</td>
						<td style="text-align: center;">${bookingInfo.timesUsing}</td>
					</tr>
				</tbody>
			</table>
		</div>
	</div>
	</c:if>
	<div class="row extend-row">
		<div class="col-xs-8 col-md-8">
		${reservation.deptName}&nbsp;&nbsp;${reservation.doctorName}&nbsp;&nbsp;${reservation.formattedReservationDate}&nbsp;&nbsp;${reservation.formattedReservationTime}
		</div>
	</div>
	<div class="row extend-row">
		<div class="col-xs-8 col-md-8">
			<button type="submit" id="confirm-change-btn" class="btn btn-primary"><spring:message code="be005.label.change_booking_btn" /></button>
			<button type="button" class="btn btn-default" onclick="window.history.back()"><spring:message code="be005.label.back_btn"/></button>
		</div>
	</div>
</div>
</form:form>
<script>
	disableSubmitButtonAfterSubmission(":submit");
</script>