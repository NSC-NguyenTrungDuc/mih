<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>
<script type="text/javascript" src="<c:url value='/assets/js/lib/bootstrap-editable.min.js'/>"></script>

<script type="text/javascript" src="<c:url value='/assets/js/Constants.js'/>"></script>
<script type="text/javascript" src="<c:url value='/assets/js/lib/culture-info.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/lib/date.js'/>"></script>
<script type="text/javascript" src="<c:url value='/assets/js/Util.js'/>"></script>
<script type="text/javascript" src="<c:url value='/assets/js/EventDriven.js'/>"></script>
<script type="text/javascript" src="<c:url value='/assets/js/UIComponent.js'/>"></script>
<script type="text/javascript" src="<c:url value='/assets/js/BookingUtils.js' />"></script>

<script type="text/javascript" src="<c:url value='/assets/js/control/table/Table.js'/>"></script>
<script type="text/javascript" src="<c:url value='/assets/js/control/table/Row.js'/>"></script>
<script type="text/javascript" src="<c:url value='/assets/js/control/table/ColumnHeader.js'/>"></script>

<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/CellData.js'/>"></script>
<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/Doctor.js'/>"></script>
<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/DeleteRatioSchedulerData.js'/>"></script>

<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/BaseScheduler.js'/>"></script>

<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/CalendarRow.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/DeleteRatioSchedulerRow.js'/>"></script>
<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/MssDeleteRatioScheduler.js'/>"></script>
<c:url var="viewDeleteComaPatientListUrl" value="/schedule/schedule-delete-coma-sending-setting"/>

<div id="dateTitle" style="display:none"><spring:message code="general.table.header.date" /></div>
<div id="doctorTitle" style="display:none"><spring:message code="general.table.header.doctor" /></div>
<div id="dayTitle" style="display:none"><spring:message code="general.table.header.day" /></div>
<div class="text-content">
	<div class="row">
		<div class="col-sm-12">
			<p>${hospitalName}&nbsp;${deptName}</p>
		</div>
	</div>
</div>
<div class="schedule-content">
	<div>
		<p>
			<button type="button" class="btn btn-primary" id="btn-current-week"><spring:message code="general.nav.button.current"/></button>
			<button type="button" class="btn btn-default" id="btn-previous-week"><spring:message code="general.nav.button.previous"/></button>
			<button type="button" class="btn btn-default" id="btn-next-week"><spring:message code="general.nav.button.next"/></button>
		</p>
	</div>
	<div id="schedule-delete-coma-table"></div>
	<sec:authorize ifAnyGranted="ROLE_SCHEDULE">
		<div class="row">
			<div class="col-sm-12">
				<button type="button" id="btn-view-patient-list" class="btn btn-primary">
					<spring:message code="be022.button.view_delete_coma_patient_list" />
				</button>
				<br/><br/>
			</div>
		</div>
	</sec:authorize>
	<div class="row">
		<div class="col-sm-12">
			<div class="remove-list"></div>
		</div>
	</div>
</div>
<script id="reservations-list" type="text/x-handlebars-template">
	{{#if reservations.length}}
		<div>{{reservations.[0].formattedReservationDate}}</div>		
		<div><spring:message code="be022.label.doctor" /> {{reservations.[0].doctorName}}</div>
		<div>{{reservations.[0].formattedReservationTime}}</div>
		<table class="table table-bordered">
			<tbody>
 			{{#each reservations}}
				<tr>
					<td width="25%">{{patientName}}</td>
					<td width="50%">{{email}}</td>
					<td width="25%">{{phoneNumber}}</td>
				</tr>
    		{{/each}}
			</tbody>
		</table>
	{{/if}}
</script>
<script type="text/javascript" src="<c:url value='/assets/js/schedule/ScheduleDeleteComa.js'/>" ></script>