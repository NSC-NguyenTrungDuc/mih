<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

<form:form class="form-horizontal" role="form" method="POST" commandName="mailHistory">

	<div class="form-group">
		<div class="col-sm-3">
			<form:select class="form-control" path="mailListId" items="${mailList}" />
		</div>
		<div class="col-sm-3">
			<form:input class="form-control" path="fromDate" />
			<form:errors path="fromDate" cssClass="error" cssStyle="color:red" />
		</div>
		<div class="col-sm-3">
			<form:input class="form-control" path="toDate" />
			<form:errors path="toDate" cssClass="error" cssStyle="color:red" />
		</div>
		<div class="col-sm-3">
			<input id="searchBtn" type="button" class="btn btn-primary pull-left btn-120" value="<spring:message code="be025.label.search.button" />">
		</div>
	</div>
</form:form>

<table id="tblMailListHistory" class="table table-bordered display">
	<thead>
		<tr style="background-color: #4f6070;color: white;font-weight: bold;">
			<th><spring:message code="be006.label.form.patientName" /></th>
			<th><spring:message code="be006.label.form.email" /></th>
			<th><spring:message code="be045.label.form.phonenumber" /></th>
			<th><spring:message code="be045.label.form.checkUrl" /></th>
		</tr>
	</thead>
	<tbody id="search-result-body">
	</tbody>
</table>
<script id="search-result" type="text/x-handlebars-template">
	{{#each model}}
		<tr>
			<td>{{patientName}}</td>
			<td>{{email}}</td>
			<td>{{phoneNumber}}</td>
			<td class="readingFlg">{{#compare readingFlg '==' 1}}<spring:message code="be025.label.item.confirm" />{{/compare}}{{#compare readingFlg '!=' 1}}<spring:message code="be025.label.item.not.yet" />{{/compare}}</td>
		</tr>
    {{/each}}



</script>
<script>

	var be405_table_record_each_page = '<spring:message code="table.record.each.page" />'
	var be405_table_previous = '<spring:message code="table.previous" />'
	var be405_table_next = '<spring:message code="table.next" />'
	var be405_table_last = '<spring:message code="table.last" />'
	var be405_table_empty = '<spring:message code="table.empty" />'
	var be405_table_info_empty = '<spring:message code="table.info.empty" />'
	var be405_table_info_total = '<spring:message code="table.info.total" />'
	var be405_table_info_start = '<spring:message code="table.info.start" />'
	var be405_table_info_end = '<spring:message code="table.info.end" />'
	var be405_s_info = '<spring:message code="table.s.info" />'
</script>
<script type="text/javascript" src="<c:url value='/assets/js/mail-manage/MailListHistory.js' />"></script>