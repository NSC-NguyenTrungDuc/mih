<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ page import="nta.mss.misc.common.MssContextHolder"%>
<%@page import="nta.mss.model.HospitalTrackingModel"%>
<%@page import="java.util.List"%>
<%@page import="nta.med.common.util.Strings"%>
<%@page import="org.apache.commons.collections.CollectionUtils"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

<div id="booking-change-complete-wrapper" class="form-horizontal">
	<div id="booking-change-complete-info">
		<c:choose>
			<c:when test="${isAlreadyCompleted == true}">
				<div class="form-group">
					<div class="col-xs-12">
						<p class="form-control-static"><spring:message code="general.msg.change.is_already_completed"/></p>
					</div>
				</div>
			</c:when>
			<c:when test="${isDoctorScheduleFull == true}">
				<div class="form-group">
					<div class="col-xs-12">
						<p class="form-control-static"><spring:message code="general.msg.change.full_schedule"/></p>
					</div>
				</div>
			</c:when>
			<c:when test="${isNotSuccess == true}">
				<div class="form-group">
					<div class="col-xs-12">
						<p class="form-control-static"><spring:message code="general.msg.new.not.success"/></p>
					</div>
				</div>
			</c:when>
			<c:otherwise>
				<div class="form-group">
					<div class="col-xs-12">
						<p class="form-control-static"><spring:message code="fe026.message.header" /></p>
					</div>
				</div>
				<div class="form-group">
					<label class="col-xs-12 col-sm-4"> <spring:message code="fe026.label.booking.number" />
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
						<p class="form-control-static">${reservation.deptName} ${reservation.doctorName} ${reservation.formattedReservationDate} ${reservation.formattedReservationTime}</p>
					</div>
				</div>
			</c:otherwise>
		</c:choose>
	</div><!-- End #booking-change-complete-info -->
</div><!-- End #booking-change-complete-wrapper -->

<script type="text/javascript" src="<c:url value='/assets/js/booking/RemoveFirstStepBooking.js'/>">
</script>
<%	List<HospitalTrackingModel> lst = MssContextHolder.getTrackingScript();

	if(CollectionUtils.isNotEmpty(lst))
	{
		String trackingCode = "" ;
		for (int i = 0; i < lst.size(); i++) {
			String pageCode= lst.get(i).getPage_code();
			if(pageCode.equals("fe026"))
			{
				trackingCode = trackingCode + lst.get(i).getTracking_scripts();
			}
		}
		if(!Strings.isEmpty(trackingCode))
			out.println(trackingCode);
	}
%>