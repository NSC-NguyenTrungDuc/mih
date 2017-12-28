<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 
<%@ taglib uri="http://www.springframework.org/security/tags" prefix="sec" %>

<c:url var="submitEditUrl" value="/booking/submit-change-history-vaccine" />
<c:url var="backUrl" value="/booking/add-history-vaccine?childId=" />

<div class="col-md-10">
	<form:form method="post" action="${submitEditUrl}"
		class="form-horizontal" modelAttribute="vaccineChildHistory">
		<div class="form-group">
			<label class="col-sm-3 control-label"> <spring:message
					code="re011.label.using.vaccine.day" /><font color="red">*</font>
			</label>
			<div class="col-sm-7">
				<form:input class="form-control" path="injectedDateStr" />
				<form:errors path="injectedDateStr" cssClass="alert-danger" />
			</div>
		</div>
		<div class="form-group">
			<label class="col-sm-3 control-label"> <spring:message
					code="re011.label.vaccine.name" /><font color="red">*</font>
			</label>
			<div class="col-sm-7">
				${vaccineName}
			</div>
		</div>
		<div class="form-group">
			<label class="col-sm-3 control-label"> <spring:message
					code="re011.label.times.using" /><font color="red">*</font>
			</label>
			<div class="col-sm-7">
				${vaccineChildHistory.injectedNo}<spring:message code="general.vaccine.label.inject.unit" />
			</div>
		</div>
		<div class="form-group">
			<label class="col-sm-3 control-label"> <spring:message
					code="re011.label.medical.name" /><font color="red">*</font>
			</label>
			<div class="col-sm-7">
				<form:input path="hospitalName" class="form-control" maxlength="128"
					cssStyle="" />
				<form:errors path="hospitalName" cssClass="error"
					cssStyle="color:red" />
			</div>
		</div>
		<form:input type="hidden" id="childId" path="childId" />
		<form:input type="hidden" id="vaccineChildId" path="vaccineChildId" />
		<form:input type="hidden" id="reservationId" path="reservationId" />
		<form:input type="hidden" id="vaccineId" path="vaccineId" />
		<form:input type="hidden" id="injectedNo" path="injectedNo" />
		<div class="form-group">
			<div class="col-sm-offset-3 col-sm-7">
				<sec:authorize ifAnyGranted="ROLE_FRONT_END">
				<button type="submit" class="btn btn-success" id="btnSubmit">
					<spring:message code="re011.btn.edit.history" />
				</button>
				</sec:authorize>
				<button type="button" class="btn btn-default" onclick="location.href='${backUrl}${vaccineChildHistory.childId}'">
					<spring:message code="general.button.back" />
				</button>
			</div>
		</div>
		<div class="form-group">
			<div class="col-sm-offset-3 col-sm-7">
				<c:if test="${isDuplicate}">
					<p style="color: red;"><spring:message code="re011.msg.is.duplicate" /></p>
				</c:if>
			</div>
		</div>
	</form:form>
	<div class="form-group">
		<table id="tblVaccineChildHistory"
			class="table table-bordered display">
			<thead>
				<tr
					style="background-color: #27ae61;color: white;font-weight: bold;">
					<th><spring:message code="re011.header.dateUsing" /></th>
					<th><spring:message code="re011.header.dayAge" /></th>
					<th><spring:message code="re011.header.hospitalName" /></th>
					<th><spring:message code="re011.header.vaccineName" /></th>
					<th><spring:message code="re011.header.timeUsing" /></th>
				</tr>
			</thead>
			<tbody id="vaccine-child-history-body">
				<tr>	
					<td>${vaccineChildHistory.injectedDateStr}</td>
					<td>${vaccineChildHistory.dayAge}</td>
					<td>${vaccineChildHistory.hospitalName}</td>
					<td>${vaccineChildHistory.vaccineName}</td>
					<td>${vaccineChildHistory.injectedNo}<spring:message code="general.vaccine.label.inject.unit" /></td>
				</tr>
			</tbody>
		</table>
	</div>
</div>

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

<script type="text/javascript" src="<c:url value='/assets/js/booking/HistoryVaccineManagement.js' />" ></script>



