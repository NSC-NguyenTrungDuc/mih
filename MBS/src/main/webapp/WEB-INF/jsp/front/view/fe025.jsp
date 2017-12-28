<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

<div id="booking-change-accept-wrapper" class="form-horizontal">
	<div id="booking-change-accept-info">
		<div class="form-group">
			<div class="col-xs-12">
				<p class="form-control-static"><spring:message code="fe025.message.header" /></p>
			</div>
		</div>
		<div class="form-group">
			<label class="col-xs-12 col-sm-4"> <spring:message code="fe025.label.booking.number" />
			</label>
			<div class="col-xs-12 col-sm-8">
				${reservation.reservationCode}
			</div>
		</div>
		<div class="form-group">
			<label class="col-xs-4 col-md-4">
				<spring:message code="fe003.label.time.reminder" /> 
			</label>
			<div class="col-xs-8 col-md-8">
				<spring:message code="${reminderTime}" />
			</div>
		</div>
		<div class="form-group">
			<div class="col-xs-12 col-md-12">
				<p class="form-control-static">${reservation.deptName} ${reservation.formattedReservationTime} ${reservation.formattedReservationDate}</p>
			</div>
		</div>
	</div><!-- End #booking-change-accept-info -->
</div><!-- End #booking-change-accept-wrapper -->