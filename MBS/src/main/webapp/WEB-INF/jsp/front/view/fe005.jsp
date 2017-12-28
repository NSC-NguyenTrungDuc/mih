<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%> 
 <c:url var="submitUrl" value="/booking/booking-info-submit" />
<form:form method="post" action="${submitUrl}" modelAttribute="patient" >
<div id="main-booking-name">
	<p class="lead">
		<spring:message code="fe005.end.temporary" />
	</p>
	<br/>
	<div class="row">
	<c:if test="${not isKcck}">
		<label class="col-xs-4 col-md-4 control-label">
			<spring:message code="fe005.label.booking.number" />
		</label>
		<div class="col-xs-8 col-md-8">
			${reservationCode}
		</div>
		</c:if>
	</div>
	<br/>
	<div class="row">
		<label class="col-xs-4 col-md-4 control-label">	
			<spring:message code="fe003.label.department" /> 
		</label>
		<div class="col-xs-8 col-md-8">
			${deptName}
		</div>
	</div>
	<div class="row">
		<label class="col-xs-4 col-md-4 control-label">	
			<spring:message code="fe005.label.reservation.time" /> 
		</label>
		<div class="col-xs-8 col-md-8">
			${bookingTime}
		</div>
	</div>
	<div class="row">
		<label class="col-xs-4 col-md-4 control-label">
			<spring:message code="fe003.label.time.reminder" /> 
		</label>
		<div class="col-xs-8 col-md-8">
			<spring:message code="${reminderTime}" />
		</div>
	</div>
</div>
</form:form>
<script type = "text/javascript">
	$(document).ready(function(){
		var isMobile = MssUtils.detectmob();
		if(isMobile)
		{
			MssUtils.focusIncaseMobile('#main-booking-name');
		}
	});
</script>
