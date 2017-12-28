<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>

<script type="text/javascript" src="<c:url value='/assets/js/Constants.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/lib/culture-info.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/lib/date.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/Util.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/EventDriven.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/UIComponent.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/BookingUtils.js' />"></script>

<script type="text/javascript" src="<c:url value='/assets/js/control/table/Table.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/control/table/Row.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/control/table/ColumnHeader.js' />"></script>

<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/CellData.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/RatioData.js' />"></script>

<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/BaseScheduler.js' />"></script>

<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/CalendarRow.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/MssCalendar.js' />"></script>

<div id="dateTitle" style="display:none"><spring:message code="general.table.header.date" /></div>
<div id="dayTitle" style="display:none"><spring:message code="general.table.header.day" /></div>
<c:url var="backUrl" value="select-department"/>
<div id="curDate" style="display:none">${curDate}</div>
<div id="isBookingVaccine" style="display:none">${isBookingVaccine}</div>
<div id="doctor-schedule" class="text-content">
	<div class="row">
		<div class="col-xs-12 col-sm-12">
			<spring:message code="be003.label.select_date" />
		</div>
	</div>
	<div class="row">
		<div class="col-xs-12 col-sm-12">
			<div>
				${hospitalName} ${departmentName}
			</div>
			<div align="left" class="row col-xs-5">
				<form:select id="booking-slt-doctor" class="form-control input-sm" path="doctorList">
					<form:option value=""><spring:message code="general.select.all"/></form:option>
					<form:options items="${doctorList}" itemValue="doctorId" itemLabel="name"/>
				</form:select> 
			</div> 
		</div>
	</div>
	<div class="row">
		<div class="col-xs-12 col-sm-12">
			<p><spring:message code="be003.label.schedule_status" /></p>
		</div>
	</div>
</div>
<div class="schedule-content">
	<div>
		<p>
			<a class="btn btn-danger" href="${backUrl}"><spring:message code="general.button.back" /></a>
			<button type="button" class="btn btn-primary" id="btn-current-week"><spring:message code="general.nav.button.current"/></button>
			<button type="button" class="btn btn-default" id="btn-previous-week"><spring:message code="general.nav.button.previous"/></button>
			<button type="button" class="btn btn-default" id="btn-next-week"><spring:message code="general.nav.button.next"/></button>
		</p>
	</div>
	<div id="doctor-schedule-table"></div>
	<div id="doctor-reservations" class="col-sm-12"></div>
</div>
<div id="confirm-cancel" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
	<div class="modal-dialog modal-sm">
		<div class="modal-content">
			<div class="modal-body">
				<button type="button" class="close" data-dismiss="modal">
					<span aria-hidden="true">&times;</span><span class="sr-only"></span>
				</button>
				<p><spring:message code="be003.label.cancel_warning" /></p>
			</div>
			<div class="modal-footer">
				<button id="btn-cancel-booking" class="btn btn-success btn-90"><spring:message code="be003.label.confirm_btn" /></button>
				<button data-dismiss="modal" aria-hidden="true" class="btn btn-default btn-120"><spring:message code="popup.label.cancel" /></button>
			</div>
		</div>
	</div>
</div>
<script id="reservations-list" type="text/x-handlebars-template">
	<sec:authorize ifAnyGranted="ROLE_RESERVATION">
	{{#each lstReservations}}
	<div data-id="{{reservationDate}}{{reservationTime}}">
		<p><a data-date="{{reservationDate}}" data-time="{{reservationTime}}" data-doctorid="{{doctorId}}" class="btn btn-primary pull-right new-booking-btn"><spring:message code="be003.label.new_booking_btn" /></a></p>
		</sec:authorize>
		<span>{{doctorName}}&nbsp;&nbsp;&nbsp;&nbsp;<spring:message code="be003.label.reservation_time" /> {{formattedReservationDate}} {{formattedReservationTime}}</span>
		<table class="table table-striped">
			<tbody>
 				{{#each reservationModels}}
				<tr>
					<td width="30%">{{patientName}}</td>
					<td style="word-break: break-all;">{{email}}</td>
					<td style="word-break: break-all;">{{phoneNumber}}</td>
					<sec:authorize ifAnyGranted="ROLE_RESERVATION">
					<td width="74px" style="padding-left:2px;padding-right:2px"><a class="btn btn-sm btn-primary btn-70 btn-change-reservation" data-id="{{reservationId}}"><spring:message code="be003.label.change_btn" /></a></td>
					<td width="50px" style="padding-left:2px;padding-right:2px"><a class="btn btn-sm btn-danger cancel-bk-btn btn-70" data-id="{{reservationId}}" data-date="{{reservationDate}}" data-time="{{reservationTime}}" href="#" ><spring:message code="be003.label.cancel_btn" /></a></td>
					</sec:authorize>
				</tr>
    			{{/each}}
			</tbody>
		</table>
	</div>
	{{/each}}
</script>
<script type="text/javascript" src="<c:url value='/assets/js/booking-manage/DateTimeSelect.js' />"></script>