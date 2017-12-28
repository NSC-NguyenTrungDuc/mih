<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
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
<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/BinaryData.js'/>"></script>

<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/BaseScheduler.js'/>"></script>

<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/CalendarRow.js'/>"></script>
<script type="text/javascript" src="<c:url value='/assets/js/control/mss-calendar/MssCalendar.js'/>"></script>

<div id="dateTitle" style="display:none"><spring:message code="general.table.header.date" /></div>
<div id="dayTitle" style="display:none"><spring:message code="general.table.header.day" /></div>
<div class="text-content">
	<div class="row">
		<div class="col-sm-12"><spring:message code="fe023.message.header" /></div>
	</div>
	<div class="row">
		<div class="col-sm-12"><spring:message code="fe023.label.dept.status"/>:${reservation.hospitalName}</div>
	</div>
	<div class="row">
		<div class="col-sm-12"><p>${reservation.reservationDate} ${reservation.reservationTime} - ${reservation.deptName} - ${reservation.doctorName}</p></div>
	</div>
</div>
<%-- <div class="schedule-content" id="table-schedule-content">
	<div>
		<p>
			<button type="button" class="btn btn-primary" id="btn-current-week"><spring:message code="general.nav.button.current"/></button>
			<button type="button" class="btn btn-default" id="btn-previous-week"><spring:message code="general.nav.button.previous"/></button>
			<button type="button" class="btn btn-default" id="btn-next-week"><spring:message code="general.nav.button.next"/></button>
		</p>
	</div>
	<div id="booking-change-table" class="booking-time-s"></div>
</div>
<div id="no-table" style="display: none;">
	<span class="lead" style="font-weight: bold;"><spring:message
			code="fe002.no.schedule" /></span>
</div>
<div id="time-slot-list" class="dropdown" style="position: absolute">
	<button class="btn btn-primary dropdown-toggle" style="display: none" type="button" data-toggle="dropdown">Dropdown Example
		<span class="caret"></span></button>
	<ul id="mn-time-slot-list" class="dropdown-menu">
	</ul>
</div> --%>
<div class="schedule-content" id="table">
	<div>
		<p>
			<button type="button" class="btn btn-primary" id="btn-current-week">
				<spring:message code="general.nav.button.current" />
			</button>
			<button type="button" class="btn btn-default" id="btn-previous-week">
				<spring:message code="general.nav.button.previous" />
			</button>
			<button type="button" class="btn btn-default" id="btn-next-week">
				<spring:message code="general.nav.button.next" />
			</button>
		</p>
	</div>
	<div id="booking-time" class="booking-time-s"></div>
</div>
<div id="no-table" style="display: none;">
	<span class="lead" style="font-weight: bold;"><spring:message
			code="fe002.no.schedule" /></span>
</div>
<div id="time-slot-list" class="dropdown" style="position: absolute">
	<button class="btn btn-primary dropdown-toggle" style="display: none" type="button" data-toggle="dropdown">Dropdown Example
		<span class="caret"></span></button>
	<ul id="mn-time-slot-list" class="dropdown-menu">
	</ul>
</div>

<script type="text/javascript" src="<c:url value='/assets/js/booking/BookingChange.js'/>" ></script>