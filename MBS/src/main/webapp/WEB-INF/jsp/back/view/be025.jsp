<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib prefix="sec"
	uri="http://www.springframework.org/security/tags"%>
<form:form class="form-horizontal" role="form" method="POST"
	commandName="scheduleMailHistory"
	action="${pageContext.request.contextPath}/schedule/schedule-mail-history-search">
	<div class="row">
		<div class="form-group">
			<div class="col-sm-2" align="left">
				<label for="department" class="control-label"><spring:message
						code="be025.label.choose.department" /></label>
			</div>
			<div class="col-sm-4">
				<form:select class="form-control" path="department">
					<form:option value="-1">
						<spring:message code="be005.label.search.department.all" />
					</form:option>
					<form:options items="${departmentList}" />
				</form:select>
			</div>
		</div>
		<div class="form-group">
			<div class="col-sm-2" align="left">
				<label for="fromDate" class="control-label"><spring:message
						code="be025.label.fromDate" /></label>
			</div>
			<div class="col-sm-4">
				<form:input class="form-control" path="fromDate" />
				<form:errors path="fromDate" cssClass="error" cssStyle="color:red" />
			</div>
			<div class="col-sm-2" align="left">
				<label for="toDate" class="control-label"><spring:message
						code="be025.label.toDate" /></label>
			</div>
			<div class="col-sm-4">
				<form:input class="form-control" path="toDate" />
				<form:errors path="toDate" cssClass="error" cssStyle="color:red" />
			</div>
		</div>
	</div>
	<div class="form-group">
		<div class="col-sm-3">
			<button type="button" id="searchBtn"
				class="btn btn-primary pull-left btn-120">
				<spring:message code="be025.label.search.button" />
			</button>
		</div>
	</div>
</form:form>
<div id="search-result"></div>
<div id="no-result" style="display: none;">
	<span class="lead" style="font-weight: bold;"><spring:message code="be025.label.no.result" /></span>
</div>

<script id="list-mail-history" type="text/x-handlebars-template">
{{#each model}}
	<table class="table table-bordered">
		<tr class="success">
			<td colspan="7" style="text-align: left;">
				{{doctorName}}
			</td>
		</tr>
		<tr class="success">
			{{#if tempModel.length}}
				<td style="width:20%;" align="center"><spring:message code="be025.label.item.patientName"/></td>
				<td style="min-width:90px;" align="center"><spring:message code="be025.label.item.checkDate"/></td>
				<td style="min-width:73px;" align="center"><spring:message code="be025.label.item.checkTime"/></td>
				<td style="width:25%;" align="center"><spring:message code="be025.label.item.email"/></td>
				<td style="width:15%;" align="center"><spring:message code="be025.label.item.phone"/></td>
				<td style="width:15%;" align="center"><spring:message code="be025.label.item.subject"/></td>
				<%-- <td align="center"><spring:message code="be025.label.item.send" /></td> --%>
				<td style="min-width:83px;" align="center"><spring:message code="be025.label.item.confirm.email" /></td>
			 {{/if}}
		</tr>

		{{#each  tempModel}}
			<tr>
				<td style="word-break: break-all;">{{patientName}}</td>
				<td>{{checkDate}}</td>
				<td class="timeSlot">{{timeSlot}}</td>
				<td style="word-break: break-all;">{{email}}</td>
				<td style="word-break: break-all;">{{phoneNumber}}</td>
				<td>{{subject}}</td>
				<td class="readingFlg">{{#compare readingFlg '==' 1}}<spring:message code="be025.label.item.confirm" />{{/compare}}{{#compare readingFlg '!=' 1}}<spring:message code="be025.label.item.not.yet" />{{/compare}}</td>
			</tr>
		{{/each}}

	</table>
{{/each}}
</script>

<script type="text/javascript"
	src="<c:url value='/assets/js/schedule/SheduleMailHistory.js' />"></script>

