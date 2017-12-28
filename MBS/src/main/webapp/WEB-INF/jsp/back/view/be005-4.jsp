<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

<c:url var="saveChangeDoctorUrl" value="/booking-manage/booking-change-doctor-save" />

<form:form method="post" action="${saveChangeDoctorUrl}" modelAttribute="bookingTimeModel" class="form-horizontal">
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="fe003.label.name" />
		</div>
		<div class="col-xs-8 col-md-8">${reservation.patientName}</div>
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
	<div class="row extend-row">
		<div class="col-xs-8 col-md-8">
		${reservation.deptName}&nbsp;&nbsp;${reservation.doctorName}&nbsp;&nbsp;${reservation.formattedReservationDate}&nbsp;&nbsp;${reservation.formattedReservationTime}
		</div>
	</div>
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="be005.label.doctor.name" /> 
		</div>
		<div class="col-xs-8 col-md-8">${bookingTimeModel.doctorName}</div>
	</div>
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="be005.label.mail.template.name" /> 
		</div>
		<div class="col-xs-8 col-md-8">${bookingTimeModel.templateName}</div>
	</div>
	<form:hidden path="reservationId" />
	<form:hidden path="doctorId"/>
	<form:hidden path="templateCode" />
	
	<div class="row extend-row">
		<div class="col-sm-5">
			<button type="submit" class="btn btn-success btn-sm btn-120"><spring:message code="be005.label.submit.change.doctor"/></button>
			<button type="button" class="btn btn-default" onclick="window.history.back()"><spring:message code="be005.label.back_btn"/></button>
		</div>
	</div>
</form:form>
