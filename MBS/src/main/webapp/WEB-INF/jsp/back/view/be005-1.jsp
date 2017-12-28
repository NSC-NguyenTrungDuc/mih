<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<script type="text/javascript"
	src="<c:url value='/assets/js/Constants.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/lib/culture-info.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/lib/date.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/Util.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/EventDriven.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/UIComponent.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/BookingUtils.js' />"></script>

<script type="text/javascript"
	src="<c:url value='/assets/js/control/table/Table.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/control/table/Row.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/control/table/ColumnHeader.js' />"></script>

<script type="text/javascript"
	src="<c:url value='/assets/js/control/mss-calendar/CellData.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/control/mss-calendar/RatioData.js' />"></script>

<script type="text/javascript"
	src="<c:url value='/assets/js/control/mss-calendar/BinaryData.js' />"></script>

<script type="text/javascript"
	src="<c:url value='/assets/js/control/mss-calendar/BaseScheduler.js' />"></script>

<script type="text/javascript"
	src="<c:url value='/assets/js/control/mss-calendar/CalendarRow.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/control/mss-calendar/MssCalendar.js' />"></script>

<div id="dateTitle" style="display: none">
	<spring:message code="general.table.header.date" />
</div>
<div id="dayTitle" style="display: none">
	<spring:message code="general.table.header.day" />
</div>
<div id="doctorId" style="display: none">${reservation.doctorId}</div>
<div id="bookingForSearch" style="display: none">${bookingForSearch}</div>
<div id="vaccineChildId" style="display: none">${bookingInfo.vaccineChildHistoryId}</div>
<div id="booking-info">
	<div class="row extend-row extend-row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="fe003.label.name" />
		</div>
		<div class="col-xs-8 col-md-8">${reservation.patientName}</div>
	</div>
	<%
		if (HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale())) {
	%>
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="fe003.label.furigana" />
		</div>
		<div class="col-xs-8 col-md-8">${reservation.nameFurigana}</div>
	</div>
	<%
		}
	%>
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
			<spring:message code="general.label.sex" />
		</div>
		<div class="col-xs-8 col-md-8">${patient.genderText}</div>
	</div>
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="re008.label.birthday" />
		</div>
		<div class="col-xs-8 col-md-8">${patient.formattedBirthDay}</div>
	</div>
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="fe003.label.ticket" />
		</div>
		<div class="col-xs-8 col-md-8">${patient.cardNumber}</div>
	</div>
	<div class="row extend-row">
		<div class="col-xs-4 col-md-4">
			<spring:message code="fe003.label.time.reminder" />
		</div>
		<div class="col-xs-8 col-md-8">${mapReminderTime.get(reservation.reminderTime)}</div>
	</div>
	<c:if test="${isChangeBookingVaccine}">
		<!-- 	<div class="row extend-row"> -->
		<%-- 		<label class="col-xs-12 col-md-3 control-label"> <spring:message code="fe003.label.detail.bookingVaccine" /></label> --%>
		<!-- 	</div> -->
		<div class="row extend-row">
			<div class="col-xs-12 ">
				<table id="dataTable" class="table table-bordered">
					<thead>
						<tr>
							<th width="" style="text-align: center;"><spring:message
									code="fe003.label.child.name" /></th>
							<th width="" style="text-align: center;"><spring:message
									code="fe003.label.child.dob" /></th>
							<th width="" style="text-align: center;"><spring:message
									code="general.label.sex" /></th>
							<th width="" style="text-align: center;"><spring:message
									code="fe003.label.vaccine" /></th>
							<th width="" style="text-align: center;"><spring:message
									code="fe003.label.dateTimeUsing" /></th>
						</tr>
					</thead>
					<tbody>
						<tr>
							<td style="text-align: center;">${bookingInfo.childName}</td>
							<td style="text-align: center;">${bookingInfo.dob}</td>
							<td style="text-align: center;"><c:choose>
									<c:when test="${bookingInfo.sex == '1'}">
										<spring:message code="general.label.sex.male" />
									</c:when>
									<c:otherwise>
										<spring:message code="general.label.sex.female" />
									</c:otherwise>
								</c:choose></td>
							<td style="text-align: center;">${bookingInfo.vaccineName}</td>
							<td style="text-align: center;">${bookingInfo.timesUsing}</td>
						</tr>
					</tbody>
				</table>
			</div>
		</div>
	</c:if>
	<div class="row extend-row">
		<div class="col-xs-10 col-md-10">
			${reservation.deptName}&nbsp;&nbsp;${reservation.doctorName}&nbsp;&nbsp;${reservation.formattedReservationDate}&nbsp;&nbsp;${reservation.formattedReservationTime}</div>
	</div>
	<div class="row extend-row">
		<div class="col-md-10 schedule-content" id="doctor-table">
			<div>
				<p>
					<button type="button" class="btn btn-primary" id="btn-current-week">
						<spring:message code="general.nav.button.current" />
					</button>
					<button type="button" class="btn btn-default"
						id="btn-previous-week">
						<spring:message code="general.nav.button.previous" />
					</button>
					<button type="button" class="btn btn-default" id="btn-next-week">
						<spring:message code="general.nav.button.next" />
					</button>
				</p>

			</div>
			<div id="doctor-schedule-table" class="booking-time-s"></div>
			<div id="doctor-schedule-table-noKcck" ></div>
		</div>
		<div id="no-table" style="display: none;">
			<span class="lead" style="font-weight: bold;"><spring:message
					code="fe002.no.schedule" /></span>
		</div>
	</div>
	<c:choose>
		<c:when test="${isKcck}">
			<script type="text/javascript"
				src="<c:url value='/assets/js/booking-manage/KcckBookingChange.js' />"></script>
		</c:when>
		<c:otherwise>
			<script type="text/javascript"
				src="<c:url value='/assets/js/booking-manage/ChangeBookingTime.js' />"></script>
		</c:otherwise>
	</c:choose>