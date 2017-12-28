<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib prefix="sec"
	uri="http://www.springframework.org/security/tags"%>
<form:form class="form-horizontal" role="form" method="POST"
	commandName="defaultSchedule">
	<div class="form-group">
		<table id="tblDefaultSchedule" class="table table-bordered" style="margin-top: 20px;">
			<thead>
				<tr style="background-color: #4f6070; color: white; font-weight: bold;">
					<th style="text-align: center; width: 100px;"><spring:message code="be027.label.form.departmentCode" /></th>
					<th style="text-align: center;"><spring:message code="be027.label.form.departmentName" /></th>
					<th style="text-align: center;"><spring:message code="be027.label.form.departmentTimeSlot" /></th>
				</tr>
			</thead>
			<tbody id="tblDefaultSchedule-body">
				<c:forEach var="item" items="${departmentList}">
					<tr>
						<td align="center">${item.deptCode}</td>
						<td align="center">${item.deptName}</td>
						<td align="center">
					      <%-- <form:select class="form-control dept dept-${item.deptCode}" path="doctorId" items="${item.timeSlot}"/> --%>
					      	<form:select class="form-control dept dept-${item.deptCode}" data-dept-code="${item.deptCode}" data-dept-id="${item.deptId}" path="defaultTimeSlot">
								<c:forEach var="itemTimSlot" items="${item.timeSlot}">
									<c:if test="${itemTimSlot == item.defaultTimeSlot}">
										<c:set var="selected" value="true" />
									</c:if>
									<option value="${itemTimSlot}"
									<c:if test="${selected}">selected="selected"</c:if>>
										${itemTimSlot}</option>
									<c:remove var="selected" />
								</c:forEach>
						  	</form:select>
					    </td>
					</tr>
				</c:forEach>
			</tbody>
		</table>
	</div>

	<div class="form-group">
		<div class="col-sm-4">
		</div>
		<div class="col-sm-4">
			<button type="button" id="updateDefaultSchedule"
				class="btn btn-primary pull-left btn-120">
				<spring:message code="general.button.confirm" />
			</button>
		</div>
		<div class="col-sm-4">
			<button type="reset" id="resetDefaultSchedule"
					class="btn btn-primary pull-left btn-120">
				<spring:message code="be027.button.reset" />
			</button>
		</div>
	</div>
</form:form>


<script type="text/javascript"
	src="<c:url value='/assets/js/schedule/ScheduleDefault.js' />"></script>

