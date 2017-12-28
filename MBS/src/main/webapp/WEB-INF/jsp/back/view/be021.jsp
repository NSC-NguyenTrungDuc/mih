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
<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/AddRatioSchedulerData.js'/>"></script>

<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/BaseScheduler.js'/>"></script>

<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/CalendarRow.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/AddRatioSchedulerRow.js'/>"></script>
<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/MssAddRatioScheduler.js'/>"></script>

<div id="dateTitle" style="display:none"><spring:message code="general.table.header.date" /></div>
<div id="doctorTitle" style="display:none"><spring:message code="general.table.header.doctor" /></div>
<div id="dayTitle" style="display:none"><spring:message code="general.table.header.day" /></div>
<div id="editableTitle" style="display:none"><spring:message code="general.editable_popup.title" /></div>
<div class="text-content">
	<div class="row">
		<div class="col-xs-12 col-sm-12">
				<p>${hospitalName}&nbsp;${deptName}</p>
		</div>
	</div>
</div>
<sec:authorize ifAnyGranted="ROLE_SCHEDULE">
	<div id="hidden-field"></div>
</sec:authorize>
<div class="schedule-content">
	<div>
		<p>
			<button type="button" class="btn btn-primary" id="btn-current-week"><spring:message code="general.nav.button.current"/></button>
			<button type="button" class="btn btn-default" id="btn-previous-week"><spring:message code="general.nav.button.previous"/></button>
			<button type="button" class="btn btn-default" id="btn-next-week"><spring:message code="general.nav.button.next"/></button>
		</p>
	</div>
	<div id="schedule-adding-coma" class="scrollview"></div>
</div>
<script type="text/javascript" src="<c:url value='/assets/js/schedule/SchedulerAddComa.js'/>" ></script>
