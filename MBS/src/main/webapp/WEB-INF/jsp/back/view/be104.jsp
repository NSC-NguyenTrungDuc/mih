<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/security/tags" prefix="sec" %>

<div class="col-sm-12">
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
						<th></th>
					</tr>
				</thead>
				<tbody id="user-info-body">
	
				</tbody>
			</table>
		</div>
	</form:form>
	<!-- [Start] Show dialog confirm delete newborns -->
	<div class="modal fade" id="deleteAccount">
		<div class="modal-dialog modal-sm">
			<div class="modal-content">
				<!-- [Start] Header dialong -->
				<div class="modal-body">
					<button type="button" class="close" data-dismiss="modal">
						<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message
								code="popup.label.close" /></span>
					</button>
					<p>
						<spring:message code="be104.delete.account" />
					</p>
				</div>
	
				<div class="modal-footer" align="center">
					<sec:authorize ifAnyGranted="ROLE_BACK_END">
						<button id="delete-account" type="button" class="btn btn-success">
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

<script id="search-result" type="text/x-handlebars-template">
	{{#each userModels}}
		<tr data-id = {{userId}}>
			<td>{{userId}}</td>
			<td>{{name}}</td>
			<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
			<td>{{nameFurigana}}</td>
			<%} %>
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
				<button type="button" class="btn btn-danger btn-xs btn-delete btn-70" id="btnDelete" data-toggle="modal" data-target="#deleteAccount"><spring:message code="general.button.delete" /></button>
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

<script type="text/javascript" src="<c:url value='/assets/js/account-manage/AccountManage.js' />"></script>