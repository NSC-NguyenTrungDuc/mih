<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>
<div id="booking-info" data-id="${reservation.reservationId}" data-date="${reservation.reservationDate}" data-time="${reservation.reservationTime}">
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
			<spring:message code="be005.label.selectBox.doctor" /> 
		</div>
		<div class="col-xs-6 col-md-6">
			<select id="slt-doctor" class="form-control">
				<c:forEach var="status" items="${listDoctor}">
					<option value="${status.doctorId}"> ${status.name}</option>
				</c:forEach>
			</select>
		</div>
	</div>
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="be005.label.email_template" /> 
		</div>
		<div class="col-xs-6 col-md-6">
			<select id="slt-mail-template" class="form-control" name="mailTmp">
				<c:forEach  var="mailTmp" items="${mailTemplateList}">
					<option value="${mailTmp.templateCode}">${mailTmp.subject}</option>
				</c:forEach>
			</select>
		</div>
	</div>
	<div class="row extend-row">
		<div class="col-xs-8 col-md-8">
<%-- 			<a data-toggle="modal" data-target="#confirm-change-doctor" class="btn btn-primary" href="#"><spring:message code="be005.label.change_doctor" /></a> --%>
			<button id="confirm-change-doctor-btn" type="button" class="btn btn-primary"><spring:message code="be005.label.change_doctor"/></button>
			<button type="button" class="btn btn-default" onclick="window.history.back()"><spring:message code="be005.label.back_btn"/></button>
		</div>
	</div>
</div>
<div id="confirm-change-doctor" class="modal fade">
	<div class="modal-dialog modal-sm">
		<div class="modal-content">
			<div class="modal-body">
				<button type="button" class="close" data-dismiss="modal">
					<span aria-hidden="true">&times;</span><span class="sr-only"></span>
				</button>
				<p><spring:message code="be005.label.confirm.change_doctor" /></p>
			</div>
			<div class="modal-footer">
				<a id="confirm-change-doctor-btn" href="#" class="btn btn-success"><spring:message code="be005.label.confirm_btn" /></a>
				<a href="#" data-dismiss="modal" aria-hidden="true" class="btn btn-default"><spring:message code="popup.label.cancel" /></a>
			</div>
		</div>
	</div>
</div>
<script type="text/javascript" src="<c:url value='/assets/js/booking-manage/ChangeDoctorConfirm.js' />"></script>