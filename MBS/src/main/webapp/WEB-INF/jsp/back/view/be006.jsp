<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>

<div id="searchDate" style="display:none">${searchDate}</div>
<div id="vaccineDeptId" style="display:none">${vaccineDeptId}</div>
<h2><spring:message code="be006.title.search.booking" /></h2>

<form:form class="form-horizontal" role="form" method="POST" commandName="searchBooking"  >
	<div id="allValue" style="display:none"><spring:message code="be006.label.search.department.all" /></div>
	<div class="form-group">
	<spring:message code="be006.place.holder.mail" var="labelEmail" />
		<label for="email" class="col-sm-2 control-label"><spring:message code="be006.label.form.email" /></label>
		<div class="col-sm-5">
			<form:input class="form-control" path="email" maxlength="128" placeholder="${labelEmail}"/>
			<form:errors path="email" cssClass="error" cssStyle="color:red" />
		</div>
	</div>
	<div class="form-group">
	<spring:message code="be006.place.holder.name" var="labelName" />
		<label for="patientName" class="col-sm-2 control-label"><spring:message code="be006.label.form.patientName" /></label>
		<div class="col-sm-5">
			<form:input class="form-control" path="patientName" placeholder="${labelName}"/>
			<form:errors path="patientName" cssClass="error" cssStyle="color:red" />
		</div>
	</div>
	<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
	<div class="form-group">
	<spring:message code="be006.place.holder.furigana" var="labelFurigana" />
		<label for="nameFurigana" class="col-sm-2 control-label"><spring:message code="be006.label.form.nameFurigana" /></label>
		<div class="col-sm-5">
			<form:input class="form-control" path="nameFurigana" maxlength="64" placeholder="${labelFurigana}"/>
			<form:errors path="nameFurigana" cssClass="error" cssStyle="color:red" />
		</div>
	</div>
	<%} %>
	<%-- <div class="form-group">
		<label for="hospitalId" class="col-sm-2 control-label"><spring:message code="be006.label.form.hospital" /></label>
		<div class="col-sm-5">
			<form:select class="form-control" path="hospitalId">
				<form:option value="-1"><spring:message code="be006.label.search.department.all" /></form:option>
    			<form:options items="${hospitalList}"/>
			</form:select>
		</div>
	</div> --%>
	<div class="form-group">
		<label for="deptId" class="col-sm-2 control-label"><spring:message code="be006.label.form.department" /></label>
		<div class="col-sm-5">
			<form:select class="form-control" path="deptId">
				<form:option value="-1"><spring:message code="be006.label.search.department.all" /></form:option>
    			<form:options items="${departmentList}"/>
			</form:select>
			<%-- <span id="deptTemp" style="display: none;">${scheduleMailHistory.department}</span> --%>
		</div>
	</div>
	<div class="form-group">
		<label for="reservationFromDate" class="col-sm-2 control-label"><spring:message code="be006.label.form.fromDate" /></label>
		<div class="col-sm-3">
			<form:input class="form-control" path="reservationFromDate" />
			<form:errors path="reservationFromDate" cssClass="error" cssStyle="color:red" />
			<%-- <span id="dateTemp" style="display: none;">${scheduleMailHistory.date}</span> --%>
		</div>
		<label for="reservationToDate" class="col-sm-1 control-label" style="text-align:center;"><spring:message code="be006.label.form.toDate" /></label>
		<div class="col-sm-3">
			<form:input class="form-control" path="reservationToDate"/>
			<form:errors path="reservationToDate" cssClass="error" cssStyle="color:red" />
			<%-- <span id="dateTemp" style="display: none;">${scheduleMailHistory.date}</span> --%>
		</div>
	</div>
	<div class="form-group">
		<div class="col-sm-10" align="center">
				<input id="searchBtn" type="button" class="btn btn-primary pull-left btn-120" value="<spring:message code="be025.label.search.button" />">
		</div>
	</div>
	
</form:form>


<div class="modal fade" id="confirm-cancel">
	<div class="modal-dialog modal-sm">
		<div class="modal-content">
			<div class="modal-body">
				<button type="button" class="close" data-dismiss="modal">
					<span aria-hidden="true">&times;</span><span class="sr-only"></span>
				</button>
				<p>
					<spring:message code="fe022.modal.cancelBooking.body" />
				</p>
			</div>
			<div class="modal-footer">
				<button id="btn-cancel-booking" type="button" value="" class="btn btn-success btn-90">
					<spring:message code="fe022.modal.confirm" />
				</button>
				<button type="button" class="btn btn-default btn-90" data-dismiss="modal">
					<spring:message code="fe022.modal.close" />
				</button>
			</div>
		</div>
	</div>
</div>
<table id="tblSearchBooking" class="table table-bordered display">
	<thead>
		<tr style="background-color: #4f6070;color: white;font-weight: bold;">
			<th><spring:message code="be006.label.form.email" /></th>
			<th><spring:message code="be006.label.form.patientName" /></th>
			<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
			<th><spring:message code="be006.label.form.nameFurigana" /></th>
			<%} %>
			<th><spring:message code="be006.label.form.patientCode" /></th>
			<th><spring:message code="be006.label.form.department" /></th>
			<th><spring:message code="be006.label.form.bookingDate" /></th>
			<th><spring:message code="be006.label.form.bookingTime" /></th>
			<th><spring:message code="be006.label.form.status" /></th>
			<th><spring:message code="be006.label.form.description" /></th>
			<sec:authorize access="hasRole('ROLE_RESERVATION')">
			<th><spring:message code="be006.label.form.change" /></th>
			<th><spring:message code="be006.label.form.cancel" /></th>
			</sec:authorize>
		</tr>
	</thead>
	<tbody id="search-result-body">
	</tbody>
</table>
<script id="search-result" type="text/x-handlebars-template">
	{{#each reservations}}
		<tr>
			<td>{{email}}</td>
			<td>{{patientName}}</td>
			<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
			<td>{{nameFurigana}}</td>
			<%} %>
			<td>{{patientCode}}</td>
			<td>{{deptName}}</td>
			<td>{{reservationDate}}</td>
			<td class='timeSlot'>{{reservationTime}}</td>
			<td class='reservationStatus' >
				<sec:authorize ifAnyGranted="ROLE_RESERVATION">
				    <input class="rsi" type="hidden" value="{{reservationId}}"/>
				    <input class="stt" type="hidden" value="{{reservationStatus}}"/>
					<c:if test="${isKcck}">
						<select class="rsvStatus" disabled>
					</c:if>
					<c:if test="${!isKcck}">
						<select class="rsvStatus" >
					</c:if>
					<c:forEach var="status" items="${lstStatus}">
						<option value="${status.key}"> ${status.value}</option>
					</c:forEach>
					</select>
				</sec:authorize>
				<sec:authorize ifNotGranted="ROLE_RESERVATION">
						{{reservationStatusString}}
				</sec:authorize>
			</td>
			<td class='reservationInfoBooking' >{{infoBooking}}</td>
			<sec:authorize ifAnyGranted="ROLE_RESERVATION">
				<td><a class="btn btn-sm btn-primary btn-70" href="<c:url value="/booking-manage/booking-info-for-search?id={{reservationId}}&vaccineChildId={{vaccineChildId}}" />"><spring:message code="be006.label.change_btn" /></a></td>
				<td><a class="btn btn-sm btn-danger cancel-bk-btn btn-70" data-id="{{reservationId}}" data-date="{{reservationDate}}" data-time="{{reservationTime}}" data-vaccineChildId="{{vaccineChildId}}" href="#" ><spring:message code="be006.label.cancel_btn" /></a></td>
			</sec:authorize>
		</tr>
    {{/each}}
</script>

<script>
	var be006_table_record_each_page = '<spring:message code="table.record.each.page" />'
	var be006_table_previous = '<spring:message code="table.previous" />'
	var be006_table_next = '<spring:message code="table.next" />'
	var be006_table_last = '<spring:message code="table.last" />'
	var be006_table_empty = '<spring:message code="table.empty" />'
	var be006_table_info_empty = '<spring:message code="table.info.empty" />'
	var be006_table_info_total = '<spring:message code="table.info.total" />'
	var be006_table_info_start = '<spring:message code="table.info.start" />'
	var be006_table_info_end = '<spring:message code="table.info.end" />'
	var be006_s_info = '<spring:message code="table.s.info" />'
</script>

<script type="text/javascript" src="<c:url value='/assets/js/booking-manage/SearchBooking.js' />"></script>