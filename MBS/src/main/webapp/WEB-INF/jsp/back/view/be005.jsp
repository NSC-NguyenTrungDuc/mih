<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<c:url var="cancelUrl" value="/booking-manage/cancel-booking?id=${reservation.reservationId}&vaccineChildId=${bookingInfo.vaccineChildHistoryId}&patientCode=${patient.cardNumber}" />
<form:form method="post" action="${cancelUrl}" class="form-horizontal">
<div id="booking-info">
	<div class="form-group">
		<label class="control-label col-xs-3"><spring:message code="fe003.label.name" /></label>
		<div class="col-xs-8">
			<p class="form-control-static">${reservation.patientName}</p>
		</div>
	</div>
	<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
	<div class="form-group">
		<label class="control-label col-xs-3"><spring:message code="fe003.label.furigana" /></label>
		<div class="col-xs-8">
			<p class="form-control-static">${reservation.nameFurigana}</p>
		</div>
	</div>
	<%} %>
	<div class="form-group">
		<label class="control-label col-xs-3"><spring:message code="fe003.label.phone" /></label>
		<div class="col-xs-8">
			<p class="form-control-static">${reservation.phoneNumber}</p>
		</div>
	</div>
	<div class="form-group">
		<label class="control-label col-xs-3"><spring:message code="fe003.label.email" /></label>
		<div class="col-xs-8">
			<p class="form-control-static">${reservation.email}</p>
		</div>
	</div>
	<div class="form-group">
		<label class="control-label col-xs-3"><spring:message code="general.label.sex" /></label>
		<div class="col-xs-8">
			<p class="form-control-static">${patient.genderText}</p>
		</div>
	</div>
	<div class="form-group">
		<label class="control-label col-xs-3"><spring:message code="re008.label.birthday" /></label>
		<div class="col-xs-8">
			<p class="form-control-static">${patient.formattedBirthDay}</p>
		</div>
	</div>
	<div class="form-group">
		<label class="control-label col-xs-3"><spring:message code="fe003.label.ticket" /></label>
		<div class="col-xs-8">
			<p class="form-control-static">${patient.cardNumber}</p>
		</div>
	</div>
	<div class="form-group">
		<label class="control-label col-xs-3"><spring:message code="fe003.label.time.reminder" /></label>
		<div class="col-xs-8">
			<p class="form-control-static">${reservation.reminderTime}</p>
		</div>
	</div>
	<c:if test="${isChangeBookingVaccine}">
	<div class="form-group">
<%-- 		<label class="col-xs-12 col-md-3 control-label"> <spring:message --%>
<%-- 			code="fe003.label.detail.bookingVaccine" /> --%>
<!-- 		</label> -->
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
					
	<div class="form-group">${reservation.deptName}&nbsp;&nbsp;${reservation.doctorName}&nbsp;&nbsp;${reservation.formattedReservationDate}&nbsp;&nbsp;${reservation.formattedReservationTime}</div>
	<div class="form-group col-sm-8 pull">
		<a data-toggle="modal" data-target="#confirm-cancel" class="btn btn-danger" href="#"><spring:message code="be005.label.cancel_booking_btn" /></a>
		<c:choose>
			<c:when test="${bookingForSearch == true}">
				<c:choose>
					<c:when test="${isChangeBookingVaccine}">
						<a class="btn btn-success" href="<c:url value="/booking-manage/change-booking-time-for-search?id=${reservation.reservationId}&vaccineChildId=${bookingInfo.vaccineChildHistoryId}" />" ><spring:message code="be005.label.change_time_btn" /></a>
					</c:when>
					<c:otherwise>
						<a class="btn btn-success" href="<c:url value="/booking-manage/change-booking-time-for-search?id=${reservation.reservationId}" />" ><spring:message code="be005.label.change_time_btn" /></a>
					</c:otherwise>
				</c:choose>	
			</c:when>
			<c:otherwise>
				<a class="btn btn-success" href="<c:url value="/booking-manage/change-booking-time?id=${reservation.reservationId}" />" ><spring:message code="be005.label.change_time_btn" /></a>
			</c:otherwise>
		</c:choose>		
		<c:if test = "${not isKcck}">
		<a class="btn btn-success" href="<c:url value="/booking-manage/booking-change-doctor?id=${reservation.reservationId}" />" ><spring:message code="be005.label.change_doctor" /></a>
		</c:if>
	</div>
</div>
<div id="confirm-cancel" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
	<div class="modal-dialog modal-sm">
		<div class="modal-content">
			<div class="modal-body">
				<button type="button" class="close" data-dismiss="modal">
					<span aria-hidden="true">&times;</span><span class="sr-only"></span>
				</button>
				<p><spring:message code="be005.label.cancel_warning" /></p>
			</div>
			<div class="modal-footer">
				<button type="submit" class="btn btn-success">
					<spring:message code="be005.label.confirm_btn" />
				</button>
				<a href="#" data-dismiss="modal" aria-hidden="true" class="btn btn-default"><spring:message code="popup.label.cancel" /></a>
			</div>
		</div>
	</div>
</div>
</form:form>
<script>
	disableSubmitButtonAfterSubmission(":submit");
</script>

