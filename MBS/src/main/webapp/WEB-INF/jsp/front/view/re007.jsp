<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/security/tags" prefix="sec" %>

<c:url var="backUrl" value="profile-management" />
<c:url var="newbornUrl" value="/booking/booking-time?deptId=${newbornDeptId}" />
<c:url var="vaccineBookingUrl" value="/booking/booking-vaccine-select-time?deptId=${vaccineDeptId}&" />
<c:url var="BookingChangeUrl" value="/booking/booking-change-info?resId=" />
<c:url var="addHistoryVaccineUrl" value="/booking/add-history-vaccine?childId=${userChild.childId}" />
<c:url value="/booking/vaccine?id=" var="vaccineInfoUrl" />
<script>
	var userChildId = '${userChild.childId}';
</script>
<div class="row">
	<div class="col-sm-6">
		${userChild.childName} - ${userChild.genderText}(${userChild.formattedBirthDay})
	</div>
	<div class="col-sm-6" style="float:right">
		<p>
			<button type="button" class="btn btn-success btn-exam-newborns right-btn-align" onclick="location.href='${newbornUrl}'"><spring:message code="re007.button.exam.new.borns"/></button>
			<button type="button" class="btn btn-success btn-update-history right-btn-align" onclick="location.href='${addHistoryVaccineUrl}'" ><spring:message code="re007.button.update.history"/></button>
			<button type="button" class="btn btn-success right-btn-align" onclick="location.href='${backUrl}'" ><spring:message code="general.button.back"/></button>
		</p>
	</div>
</div>

<table id="vaccine-schedule-table${userChild.childId}" data-id="${userChild.childId}" class="vaccine-table table table-bordered display">
	<thead>
			<tr style="background-color: #27ae61;color: white;font-weight: bold;">
				<th><spring:message code="general.vaccine.table.vaccine.type"/></th>
				<th><spring:message code="general.vaccine.table.vaccine"/></th>
				<th><spring:message code="general.vaccine.table.medical"/></th>
				<th><spring:message code="general.vaccine.table.limit.inject.age"/></th>
				<th><spring:message code="general.vaccine.table.support.fee.age"/></th>
				<th><spring:message code="general.vaccine.table.advice.age"/></th>
				<th><spring:message code="general.vaccine.table.injected.no"/></th>
				<th><spring:message code="general.vaccine.table.date.inject"/></th>
				<th><spring:message code="general.vaccine.table.start.booking.date"/></th>
				<th><spring:message code="general.vaccine.table.note"/></th>
				<th><spring:message code="general.vaccine.table.action"/></th>
			</tr>
		</thead>
	<tbody id="vaccine-schedule-body${userChild.childId}">
	</tbody>
</table>
<div class="modal fade" id="choose-hospital">
	<div class="modal-dialog modal-sm">
		<div class="modal-content">
			<div class="modal-body">
				<button type="button" class="close" data-dismiss="modal">
					<span aria-hidden="true">&times;</span><span class="sr-only"></span>
				</button>
				<p>
					<div class="form-group">
				    	<spring:message code="general.vaccine.label.hospital"/><font color="red">*</font>
					    <input class="form-control"  id="hospitalName" maxlength="128" placeholder="${labelHospital}" /> 
				  	</div>
					<div class="form-group">
					    <spring:message code="general.vaccine.label.date"/><font color="red">*</font>
					    <input class="form-control" id="injectedDate" />
					</div> 
					<div class="form-group">
						<div class="alert alert-danger" id="hospitalNameError" role="alert" style="display:none">
						  <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
						  <spring:message code="general.vaccine.hospital.name.error"/>
						</div>
						<div class="alert alert-danger" id="dateError" role="alert" style="display:none">
						  <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
						  <spring:message code="general.vaccine.date.error"/>
						</div>
					</div>
				</p>
			</div>
			<div class="modal-footer">
				<button id="btn-update-hospital" type="button" value="" class="btn btn-success btn-90">
					<spring:message code="general.vaccine.modal.confirm" />
				</button>
				<button type="button" class="btn btn-default btn-90" data-dismiss="modal">
					<spring:message code="general.vaccine.modal.close" />
				</button>
			</div>
		</div>
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
					<td>
						{{#compare hospitalName '!=' NULL}}
							{{hospitalName}}
						{{/compare}}
						{{#compare hospitalName '==' NULL}}
							<a class="choose-hospital-link" data-id="{{vaccineId}}" data-times-inject="{{injectedNo}}" href="#" ><spring:message code="general.vaccine.label.link.choose.hosp" /></a>
						{{/compare}}
					</td>
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
					<td>{{injectedNo}}<spring:message code="general.vaccine.label.inject.unit" /></td>
					<td>{{formattedInjectedDate}}</td>
					<td>{{formattedDateCanBooking}}</td>
					<td>
						{{#compare status '==' 0}}{{warningDaysText}}{{/compare}}
						{{#compare status '==' 1}}<spring:message code="general.vaccine.label.note.booked" />{{/compare}}
						{{#compare status '==' 2}}<spring:message code="general.vaccine.label.note.booked" />{{/compare}}
						{{#compare status '==' 3}}<spring:message code="general.vaccine.label.note.completed" />{{/compare}}
					</td>
					<td>
						{{#compare status '==' 1}}
							<a class="btn btn-sm btn-danger btn-70" href="${BookingChangeUrl}{{reservationId}}" ><spring:message code="general.vaccine.label.button.cancel" /></a>
						{{/compare}}
						{{#compare status '==' 0}}
							<a class="btn btn-sm btn-primary btn-70" href="${vaccineBookingUrl}vaccineId={{vaccineId}}&childId={{childId}}&timesUsing={{injectedNo}}&date={{dateCanBookingStr}}" ><spring:message code="general.vaccine.label.button.book" /></a>
						{{/compare}}
					</td>
				</tr>
			{{/each}}
</script>

<script>
	var re007_table_record_each_page = '<spring:message code="table.record.each.page" />'
	var re007_table_previous = '<spring:message code="table.previous" />'
	var re007_table_next = '<spring:message code="table.next" />'
	var re007_table_last = '<spring:message code="table.last" />'
	var re007_table_empty = '<spring:message code="table.empty" />'
	var re007_table_info_empty = '<spring:message code="table.info.empty" />'
	var re007_table_info_total = '<spring:message code="table.info.total" />'
	var re007_table_info_start = '<spring:message code="table.info.start" />'
	var re007_table_info_end = '<spring:message code="table.info.end" />'
	var re007_s_info = '<spring:message code="table.s.info" />'
</script>
<script type="text/javascript" src="<c:url value='/assets/js/user/VaccineHistory.js' />"></script>