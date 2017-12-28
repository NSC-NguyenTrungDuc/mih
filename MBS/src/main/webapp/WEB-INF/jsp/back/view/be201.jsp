<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/security/tags" prefix="sec" %>
<c:url var="backUrl" value="/vaccine/vaccine-management" />

<c:choose>
	<c:when test="${isUpdate}">
		<c:url var="addChildUrl" value="/vaccine/edit-vaccine-management" />
	</c:when>
	<c:otherwise>
		<c:url var="addChildUrl" value="/vaccine/vaccine-management" />
	</c:otherwise>
</c:choose>
<div class="col-sm-12">
	<form:form role="form" method="POST" action="${addChildUrl}" commandName="vaccineHospital" class="form-horizontal">
		<c:if test="${isUpdate}">
			<form:hidden path="vaccineHospitalId"/>
			<form:hidden path="hospitalId"/>
			<form:hidden path="vaccineId"/>
		</c:if>

		<div class="form-group">
			<label for="vaccineName" class="col-sm-2 control-label"><spring:message code="be201.label.form.vaccineName" /></label>
			<div class="col-sm-7">
				<form:select id="slt-vaccine" class="form-control input-sm" path="vaccineId" disabled="${isUpdate}">
					<form:option value=""><spring:message code="be201.select.vaccine"/></form:option>
					<form:options items="${vaccineModels}"/>
				</form:select> 
				<form:errors path="vaccineId" cssClass="error" cssStyle="color:red" />
			</div>
		</div>	
		<div class="form-group">
			<label for="fromDate" class="col-sm-2 control-label"><spring:message code="be201.label.form.fromDate" /></label>
			<div class="col-sm-3">
				<form:input class="form-control" path="strFromDate" />
				<form:errors path="strFromDate" cssClass="error" cssStyle="color:red" />
			</div>
			<label for="toDate" class="col-sm-1 control-label" style="text-align:center;"><spring:message code="be201.label.form.toDate" /></label>
			<div class="col-sm-3">
				<form:input class="form-control" path="strToDate"/>
				<form:errors path="strToDate" cssClass="error" cssStyle="color:red" />
			</div>
		</div>
		<div class="form-group" >
			<label for="vaccineStatus" class="col-sm-2 control-label"><spring:message code="be201.label.form.vaccineStatus" /></label>
			<div class="col-sm-3 form-control-static">
				<form:radiobutton path="vaccineStatus" value="1" checked="checked"/><spring:message code="be201.label.form.receivingBooking" />
			</div>
			<label class="col-sm-1 control-label" style="text-align:center;"></label>
			<div class="col-sm-3 form-control-static">
				<form:radiobutton path="vaccineStatus" value="0"/><spring:message code="be201.label.form.stopReceivingBooking" />
			</div>
			<form:errors path="vaccineStatus" cssClass="error" cssStyle="color:red" />
		</div>
		<div class="form-group">
			<label for="warningDay" class="col-sm-2 control-label"><spring:message code="be201.label.form.warningDay" /></label>
			<div class="col-sm-7">
				<form:input class="form-control" path="warningDays" maxlength="11"/>
				<form:errors path="warningDays" cssClass="error" cssStyle="color:red" />
			</div>
		</div>
		
		<div class="form-group">
			<div class="col-sm-5">
				<c:choose>
					<c:when test="${isUpdate}">
						<input id="btnUpdate" type="submit" class="btn btn-primary pull-left btn-120" value="<spring:message code="general.button.Edit" />">
					</c:when>
					<c:otherwise>
						<input id="btnAdd" type="submit" class="btn btn-primary pull-left btn-120" value="<spring:message code="general.button.search" />">	
					</c:otherwise>
				</c:choose>
				<button type="button" class="btn btn-default" onclick="location.href='${backUrl}'"><spring:message code="general.button.cancel"/></button>
			</div>
			
		</div>
		
	</form:form>
	
	<div class="modal fade" id="confirm-delete-vaccine">
		<div class="modal-dialog modal-sm">
			<div class="modal-content">
				<div class="modal-body">
					<button type="button" class="close" data-dismiss="modal">
						<span aria-hidden="true">&times;</span><span class="sr-only"></span>
					</button>
					<p>
						<spring:message code="be201.modal.deleteVaccineHospital" />
					</p>
				</div>
				<div class="modal-footer">
					<button id="btn-delete-vaccineHospital" type="button" value="" class="btn btn-success btn-90">
						<spring:message code="general.vaccine.modal.confirm" />
					</button>
					<button type="button" class="btn btn-default btn-90" data-dismiss="modal">
						<spring:message code="general.vaccine.modal.close" />
					</button>
				</div>
			</div>
		</div>
	</div>
	
	<div class="form-group row">
		<table id="tblVaccineHospital"
			class="table table-bordered display">
			<thead>
				<tr
					style="background-color: #4f6070; color: white; font-weight: bold;">
					<th><spring:message code="be201.header.vaccineName" /></th>
					<th><spring:message code="be201.header.fromDate" /></th>
					<th><spring:message code="be201.header.toDate" /></th>
					<th><spring:message code="be201.header.vaccineStatus" /></th>
					<th></th>
					<th></th>
				</tr>
			</thead>
			<tbody id="vaccine-hospital-schedule-body">

			</tbody>
		</table>
	</div>
	
</div>

<script id="vaccine-hospital-schedule-list" type="text/x-handlebars-template">
	{{#each vaccineHospitals}}
		<tr data-id="{{vaccineHospitalId}}">
			<td>{{vaccineName}}</td>
			<td>{{strFromDate}}</td>
			<td>{{strToDate}}</td>
			<td>
				{{#compare vaccineStatus '==' '1'}}
					<spring:message code="be201.label.form.receivingBooking" />
				{{/compare}}
				{{#compare vaccineStatus '==' '0'}}
					<spring:message code="be201.label.form.stopReceivingBooking" />
				{{/compare}}
			</td>
			<sec:authorize ifAnyGranted="ROLE_RESERVATION">
				<td><a class="btn btn-sm btn-primary btn-70" href="<c:url value="/vaccine/vaccine-management?vaccineHospitalId={{vaccineHospitalId}}" />"><spring:message code="general.button.Edit" /></a></td>
				<td><a class="btn btn-sm btn-danger delete-vaccineHospital-btn btn-70" data-id="{{vaccineHospitalId}}" href="#" ><spring:message code="general.button.delete" /></a></td>
			</sec:authorize>
		</tr>
    {{/each}}
</script>

<script>
	var vm_table_record_each_page = '<spring:message code="table.record.each.page" />'
	var vm_table_previous = '<spring:message code="table.previous" />'
	var vm_table_next = '<spring:message code="table.next" />'
	var vm_table_last = '<spring:message code="table.last" />'
	var vm_table_empty = '<spring:message code="table.empty" />'
	var vm_table_info_empty = '<spring:message code="table.info.empty" />'
	var vm_table_info_total = '<spring:message code="table.info.total" />'
	var vm_table_info_start = '<spring:message code="table.info.start" />'
	var vm_table_info_end = '<spring:message code="table.info.end" />'
	var vm_s_info = '<spring:message code="table.s.info" />'
</script>

<script type="text/javascript" src="<c:url value='/assets/js/vaccine/VaccineManagement.js' />"></script>