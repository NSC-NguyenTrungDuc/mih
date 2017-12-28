<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 
<%@ taglib uri="http://www.springframework.org/security/tags" prefix="sec" %>

<c:url var="addHistoryUrl" value="/booking/add-history-vaccine" />
<c:url var="vaccineHistoryChangeUrl" value="/booking/change-history-vaccine?vaccineChildId=" />
<c:url var="vaccineHistoryDeleteUrl" value="/booking/delete-history-vaccine?vaccineChildId=" />
<c:url var="backUrl" value="/booking/vaccine-history?childId=" />

<div class="col-md-10">
	<form:form method="post" action="${addHistoryUrl}"
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
				<form:select id="slt-vaccine" class="form-control" path="vaccineId"
					items="${vaccines}" />
				<form:errors path="vaccineId" cssClass="alert-danger" />
			</div>
		</div>
		<div class="form-group">
			<label class="col-sm-3 control-label"> <spring:message
					code="re011.label.times.using" /><font color="red">*</font>
			</label>
			<div class="col-sm-7">
				<form:select id="slt-injectedNo" class="form-control" path="injectedNo" >
				</form:select>
				<form:errors path="injectedNo" cssClass="alert-danger" />
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

		<div class="form-group">
			<div class="col-sm-offset-3 col-sm-7">
				<sec:authorize ifAnyGranted="ROLE_FRONT_END">
				<button type="submit" class="btn btn-success" id="btnSubmit">
					<spring:message code="re011.btn.add.history" />
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
					<th></th>
					<th></th>
				</tr>
			</thead>
			<tbody id="vaccine-child-history-body">

			</tbody>
		</table>
	</div>

	<!-- [Start] Show dialog confirm delete -->
	<div class="modal fade" id="deleteVaccineChildHistory">
		<div class="modal-dialog modal-sm">
			<div class="modal-content">
				<!-- [Start] Header dialong -->
				<div class="modal-body">
					<button type="button" class="close" data-dismiss="modal">
						<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message
								code="popup.label.close" /></span>
					</button>
					<p>
						<spring:message code="re011.delete.child.confirm" />
					</p>
				</div>

				<div class="modal-footer" align="center">
					<sec:authorize ifAnyGranted="ROLE_FRONT_END">
					<button id="delete-vaccine-history" type="button" class="btn btn-success">
						<spring:message code="popup.label.comfirm" />
					</button>
					</sec:authorize>
					<button type="button" class="btn btn-default" data-dismiss="modal">
						<spring:message code="popup.label.cancel" />
					</button>
				</div>
			</div>
		</div>
	</div>
	<!-- [End] Show dialog  -->
</div>



<script id="vaccine-child-history-list" type="text/x-handlebars-template">
	{{#each vaccineChildHistoryList}}
		<tr data-id = {{vaccineChildId}}>
			<td>{{injectedDateStr}}</td>
			<td>{{dayAge}}</td>
			<td>{{hospitalName}}</td>
			<td>{{vaccineName}}</td>
			<td>{{injectedNo}}<spring:message code="general.vaccine.label.inject.unit" /></td>
			<td>
				{{#compare reservationId '==' NULL}}
					<a class="btn btn-primary btn-xs btn-change btn-70" href="${vaccineHistoryChangeUrl}{{vaccineChildId}}" ><spring:message code="general.button.Edit" /></a>
				{{/compare}}
			</td>
			<td>
				{{#compare reservationId '==' NULL}}
					<a class="btn btn-danger btn-xs btn-delete btn-70" data-toggle="modal" data-target="#deleteVaccineChildHistory"><spring:message code="general.button.delete" /></a>
				{{/compare}}
			</td>
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

<script type="text/javascript" src="<c:url value='/assets/js/booking/HistoryVaccineManagement.js' />" ></script>
