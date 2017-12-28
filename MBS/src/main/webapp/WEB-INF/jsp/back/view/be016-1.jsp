<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
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
<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/SchedulerData.js'/>"></script>

<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/BaseScheduler.js'/>"></script>

<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/CalendarRow.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/SchedulerRow.js'/>"></script>
<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/MssScheduler.js'/>"></script>
<c:url var="saveMonthlyComaUrl" value="schedule-save-monthly-coma"/>

<div id="dateTitle" style="display:none"><spring:message code="general.table.header.date" /></div>
<div id="doctorTitle" style="display:none"><spring:message code="general.table.header.doctor" /></div>
<div id="dayTitle" style="display:none"><spring:message code="general.table.header.day" /></div>
<div id="editableTitle" style="display:none"><spring:message code="general.editable_popup.title" /></div>
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
			<sec:authorize ifAnyGranted="ROLE_SCHEDULE">
				<button id="btn-save" type="button" class="btn btn-primary" data-toggle="modal" data-target="#saveMonthlyComa"><spring:message code="be016-1.button.register_coma_save_monthly" arguments="${nextMonth}"/></button>
			</sec:authorize>
			<button type="button" class="btn btn-success" onclick="window.history.back()"><spring:message code="be016-1.button.register_coma_default"/></button>
		</p>
	</div>
	<div>
		<p>
			<button type="button" class="btn btn-primary" id="btn-first-week"><spring:message code="general.nav.button.first"/></button>
			<button type="button" class="btn btn-default" id="btn-previous-week"><spring:message code="general.nav.button.previous"/></button>
			<button type="button" class="btn btn-default" id="btn-next-week"><spring:message code="general.nav.button.next"/></button>
			<button type="button" class="btn btn-primary" id="btn-last-week"><spring:message code="general.nav.button.last"/></button>
		</p>
	</div>
	<div id="schedule-monthly-coma-table"></div>
</div>
<div class="modal fade" id="saveMonthlyComa">
	<div class="modal-dialog modal-sm">
		<div class="modal-content">
			<div class="modal-body">
				<button type="button" class="close" data-dismiss="modal">
					<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message code="be016-1.modal.close" /></span>
				</button>
				<p>
					<spring:message code="be016-1.modal.register_coma.title" arguments="${nextMonth}" />
				</p>
			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-success" id="btn-save-monthly-coma">
					<spring:message code="be016-1.modal.confirm" />
				</button>
				<button type="button" class="btn btn-default" data-dismiss="modal">
					<spring:message code="be016-1.modal.close" />
				</button>
			</div>
		</div>
	</div>
</div>
<script type="text/javascript" src="<c:url value='/assets/js/schedule/ScheduleMonthlyComa.js'/>" ></script>