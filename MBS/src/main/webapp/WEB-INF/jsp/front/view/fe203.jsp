<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>

<c:url var="vaccineBookingUrl" value="/booking/booking-vaccine-select-time?deptId=${vaccineDeptId}&" />
<c:url value="/booking/vaccine?id=" var="vaccineInfoUrl" />
<c:url value="/booking/booking-new" var="selectDeptUrl" />

<div id="save-mail-list" class="" >
	<input type="hidden" id="deptId" value="${deptId}"/>
	<div class="row">
		<h3 >
			<label class="control-label"><spring:message code="fe00302.title.booking.vaccine.recommendation" /></label>
		</h3>
	</div>
	<div class="row">
		<label class="col-sm-3 control-label"><spring:message code="fe00302.label.choose.child"/></label>
		<div class="col-sm-5">
			<select id="slt-child" class="form-control" name="mailTmp">
				<c:forEach  var="child" items="${lstChild}">
					<option value="${child.childId}">${child.childName}</option>
				</c:forEach>
			</select>
		</div>
	</div>
	<div class="row">
		<label class="col-sm-12 control-label"><spring:message code="fe00302.label.choose.vaccine" /></label>
	</div>
	<div class="row">
		<table id="vaccine-schedule-table" class="vaccine-table table table-bordered">
			<thead>
					<tr style="background-color: #27ae61; color: white; font-weight: bold; margin:0px; padding:0px;" role="row">
						<th style="display: table-cell; vertical-align: middle; text-align: center;"><spring:message code="general.vaccine.table.vaccine.type"/></th>
						<th style="display: table-cell; vertical-align: middle; text-align: center;"><spring:message code="general.vaccine.table.vaccine"/></th>
						<th style="display: table-cell; vertical-align: middle; text-align: center;"><spring:message code="general.vaccine.table.limit.inject.age"/></th>
						<th style="display: table-cell; vertical-align: middle; text-align: center;"><spring:message code="general.vaccine.table.support.fee.age"/></th>
						<th style="display: table-cell; vertical-align: middle; text-align: center;"><spring:message code="general.vaccine.table.advice.age"/></th>
						<th style="display: table-cell; vertical-align: middle; text-align: center;"><spring:message code="general.vaccine.table.injected.no"/></th>
						<th style="display: table-cell; vertical-align: middle; text-align: center;"><spring:message code="general.vaccine.table.date.inject"/></th>
						<th style="display: table-cell; vertical-align: middle; text-align: center;"><spring:message code="general.vaccine.table.start.booking.date"/></th>
						<th style="display: table-cell; vertical-align: middle; text-align: center;"><spring:message code="general.vaccine.table.note"/></th>
						<th style="display: table-cell; vertical-align: middle; text-align: center;"><spring:message code="general.vaccine.table.action"/></th>
					</tr>
				</thead>
			<tbody id="vaccine-schedule-body">
			</tbody>
		</table>	
	</div>
	<br/>
	<div class="row col-sm-5">
			<button id="btnSubmit" type="button" class="btn btn-success btn-sm"><spring:message code='fe00302.button.submit'/></button>
			<a id="btnBack" class="btn btn-default btn-sm" href="${selectDeptUrl}" style="color:#333;"><spring:message code='fe00302.button.back'/></a>
	</div>
</div>
<script id="vaccine-schedule-list" type="text/x-handlebars-template">
			{{#each vaccineScheduleList}}
				<tr>
					<td>
						{{#compare typeSupport '==' 1}}<spring:message code="general.vaccine.label.support.fee.yes" />{{/compare}}
						{{#compare typeSupport '!=' 1}}<spring:message code="general.vaccine.label.support.fee.no" />{{/compare}}
						/
						{{#compare vaccineType '==' 'I'}}<spring:message code="general.vaccine.label.vaccine.type.inject" />{{/compare}}
						{{#compare vaccineType '==' 'D'}}<spring:message code="general.vaccine.label.vaccine.type.drink" />{{/compare}}
						({{totalInject}})
					</td>
					<td><a href="${vaccineInfoUrl}{{vaccineId}}">{{vaccineName}}</a><i class="fa fa-circle" style="color:#{{color}}"></i></td>
					<td>{{formattedLimitAge}}</td>
					<td>
						{{#each formattedSupportFeeDate}}
						<div>{{this}}</div>
						{{/each}}
					</td>
					<td>
						{{#each formattedRecommendAge}}
						<div>{{this}}</div>
						{{/each}}
					</td>
					<td class="Time-Using">{{injectedNo}}<spring:message code="general.vaccine.label.inject.unit" /></td>
					<td>{{formattedInjectedDate}}</td>
					<td>{{formattedDateCanBooking}}</td>
					<td>
						{{#compare status '==' 0}}{{warningDaysText}}{{/compare}}
						{{#compare status '==' 1}}<spring:message code="general.vaccine.label.note.booked" />{{/compare}}
						{{#compare status '==' 2}}<spring:message code="general.vaccine.label.note.booked" />{{/compare}}
						{{#compare status '==' 3}}<spring:message code="general.vaccine.label.note.completed" />{{/compare}}
					</td>
					<td style="text-align: center;" class="select-vaccine">
							<input name="selectVaccine" value="{{vaccineId}}" type="radio"></input>
					</td>
					<td style="display: none;" class="date-canBooking"> 
						<input name="dateCanBooking" value="{{dateCanBookingStr}}" type="hidden"></input> 
					</td>
				</tr>
			{{/each}}
			
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

<script type="text/javascript" src="<c:url value='/assets/js/booking/BookingVaccine.js' />"></script>