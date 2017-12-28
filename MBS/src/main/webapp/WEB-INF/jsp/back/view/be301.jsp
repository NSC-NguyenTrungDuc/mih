<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>

<form:form role="form" method="POST" commandName="user">
	<div class="form-group row">
		<label class="col-sm-2 control-label"> <spring:message code="be301.label.name" />
		</label>
		<div class="col-sm-4">
			<form:input class="form-control" id="name" path="name" />
		</div>
		<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
		<label class="col-sm-2 control-label"> <spring:message code="be301.label.nameFurigana" />
		</label>
		<div class="col-sm-4">
			<form:input class="form-control" id="nameFurigana" path="nameFurigana" />
		</div>
		<%} %>
	</div>
	<div class="form-group row">
		<label class="col-sm-2 control-label"> <spring:message code="be301.label.phone" />
		</label>
		<div class="col-sm-4">
			<form:input class="form-control" id="phoneNumber" path="phoneNumber" />
		</div>
		<label class="col-sm-2 control-label"> <spring:message code="be301.label.email" />
		</label>
		<div class="col-sm-4">
			<form:input class="form-control" id="email" path="email" />
		</div>
	</div>
	<div class="form-group row">
		<div class="col-sm-3">
			<input id="btnSearch" type="button" class="btn btn-primary pull-left btn-120" value="<spring:message code="be301.label.search.button" />">
		</div>
	</div>
	<div class="form-group row">
		<table id="tblUserSchedule"
			class="table table-bordered display">
			<thead>
				<tr
					style="background-color: #4f6070; color: white; font-weight: bold;">
					<th><spring:message code="be301.header.userId" /></th>
					<th><spring:message code="be301.header.name" /></th>
					<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
					<th><spring:message code="be301.header.furiganaName" /></th>
					<%} %>
					<th><spring:message code="be301.header.phone" /></th>
					<th><spring:message code="be301.header.sex" /></th>
					<th><spring:message code="be301.header.birthday" /></th>
					<th><spring:message code="be301.header.choose" /></th>
				</tr>
			</thead>
			<tbody id="user-info-body">

			</tbody>
		</table>
	</div>
	<div class="form-group row">
		<label class="col-sm-4 control-label"> <spring:message code="be301.label.choose.children" /><font color="red">*</font></label>
	</div>
	<div class="form-group row">
		<table id="tblChildSchedule"
			class="table table-bordered display">
			<thead>
				<tr
					style="background-color: #4f6070; color: white; font-weight: bold;">
					<th><spring:message code="be301.header.childId" /></th>
					<th><spring:message code="be301.header.name" /></th>
					<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
					<th><spring:message code="be301.header.furiganaName" /></th>
					<%} %>
					<th><spring:message code="be301.header.sex" /></th>
					<th><spring:message code="be301.header.birthday" /></th>
					<th><spring:message code="be301.header.choose" /></th>
				</tr>
			</thead>
			<tbody id="child-info-body">
	
			</tbody>
		</table>
	</div>
	<div class="form-group row">
		<label class="col-sm-3 control-label"> <spring:message code="be301.label.vaccine" /><font color="red">*</font>
		</label>
		<div class="col-sm-4">
			<select id="slt-vaccine" class="form-control">
				<option value=""><spring:message code="be301.select.vaccine"/></option>
				<c:forEach  var="vaccine" items="${vaccineModels}">
					<option value="${vaccine.vaccineId}">${vaccine.vaccineName}</option>
				</c:forEach>
			</select>
		</div>
	</div>
	<div id="info-vaccine" style="display: none;">
		<div class="form-group row">
			<label class="col-sm-4 control-label"> <spring:message code="be301.label.info.vaccine" /></label>
		</div>	
		<div class="form-group row">
			<label class="col-sm-3 control-label"> <spring:message code="be301.label.limit.age.using" /></label>
			<label class="col-sm-2 control-label"> <spring:message code="be301.label.from" /></label>
			<div class="col-sm-2">
				<input type="text" class="form-control" id="fromAge" readonly="readonly" value=""/>
			</div>
			<label class="col-sm-2 control-label"> <spring:message code="be301.label.to" /></label>
			<div class="col-sm-2">
				<input type="text" class="form-control" id="toAge" readonly="readonly" value=""/>
			</div>
		</div>
		<div class="form-group row">
			<label class="col-sm-3 control-label"> <spring:message code="be301.label.time.using.vaccine" /></label>
			<div class="col-sm-4">
				<input type="text" class="form-control" id="timeUsing" readonly="readonly" value=""/>
				<input type="hidden" id="timeUsingValue" value="">
			</div>
		</div>
		<div class="form-group row">
			<label class="col-sm-3 control-label"> <spring:message code="be301.label.can.booking.date" /></label>
			<div class="col-sm-4">
				<input type="text" class="form-control" id="bookingDateFormat" readonly="readonly" value=""/>
				<input type="text" style="display: none;" id="bookingDate" value="" />
			</div>
		</div>
		<div class="form-group row">
			<div class="row col-sm-5">
				<sec:authorize ifAnyGranted="ROLE_RESERVATION">
					<button id="btnSubmit" type="button" class="btn btn-success btn-sm"><spring:message code='be301.button.booking.vaccine'/></button>
				</sec:authorize>
			</div>
		</div>
	</div>
</form:form>
<script id="search-result" type="text/x-handlebars-template">
	{{#each userModels}}
		<tr>
			<td>{{userId}}</td>
			<td>{{name}}</td>
			<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
			<td>{{nameFurigana}}</td>
			<%}%>
			<td>{{phoneNumber}}</td>
			<td>
				{{#compare sex '==' '1'}}
					<spring:message code="general.label.sex.male" />
				{{/compare}}
				{{#compare sex '==' '0'}}
					<spring:message code="general.label.sex.female" />
				{{/compare}}
			</td>
			<td>{{dob}}</td>
			<td style="text-align: center;" >
				<input class="select-user" name="selectUser" value="{{userId}}" type="radio"></input>
			</td>
		</tr>
    {{/each}}
</script>

<script id="list-child-result" type="text/x-handlebars-template">
	{{#each lstChild}}
	<tr>
		<td>{{childId}}</td>
		<td>{{childName}}</td>
		<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
		<td>{{childNameFurigana}}</td>
		<%}%>
		<td>
			{{#compare sex '==' '1'}}
				<spring:message code="general.label.sex.male" />
			{{/compare}}
			{{#compare sex '==' '0'}}
				<spring:message code="general.label.sex.female" />
			{{/compare}}
		</td>
		<td>{{dob}}</td>
		<td style="text-align: center;" >
			<input class="select-child" name="selectChild" value="{{childId}}" type="radio"></input>
		</td>
	</tr>
	{{/each}}
</script>

<script>
	var be301_table_record_each_page = '<spring:message code="table.record.each.page" />'
	var be301_table_previous = '<spring:message code="table.previous" />'
	var be301_table_next = '<spring:message code="table.next" />'
	var be301_table_last = '<spring:message code="table.last" />'
	var be301_table_empty = '<spring:message code="table.empty" />'
	var be301_table_info_empty = '<spring:message code="table.info.empty" />'
	var be301_table_info_total = '<spring:message code="table.info.total" />'
	var be301_table_info_start = '<spring:message code="table.info.start" />'
	var be301_table_info_end = '<spring:message code="table.info.end" />'
	var be301_s_info = '<spring:message code="table.s.info" />'
</script>

<script>
	var md_table_record_each_page = '<spring:message code="table.record.each.page" />'
	var md_table_previous = '<spring:message code="table.previous" />'
	var md_table_next = '<spring:message code="table.next" />'
	var md_table_last = '<spring:message code="table.last" />'
	var md_table_empty = '<spring:message code="table.empty" />'
	var md_table_info_empty = '<spring:message code="table.info.empty" />'
	var md_table_info_total = '<spring:message code="table.info.total" />'
	var md_table_info_start = '<spring:message code="table.info.start" />'
	var md_table_info_end = '<spring:message code="table.info.end" />'
	var md_s_info = '<spring:message code="table.s.info" />'
</script>

<script type="text/javascript" src="<c:url value='/assets/js/vaccine/BackendBookingVaccine.js' />"></script>