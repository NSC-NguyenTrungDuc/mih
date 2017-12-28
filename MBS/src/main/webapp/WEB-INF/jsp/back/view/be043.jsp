<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/security/tags" prefix="sec" %>

<div id="save-mail-list" class="col-md-12">
	<h2>
		<spring:message code="be043.label.list.name" />
			${mailList.mailListName}
	</h2>
	<div class="row">
		<label class="col-sm-12 control-label"><spring:message code="be043.label.choose.mail.send" /></label>
	</div>
	
	<div class="row">
		<div class="col-sm-12">
			<table id="dataTable" class="table table-bordered">
				<thead>
					<tr>
						<td width="25%" style="text-align: center;"><spring:message code="be041.table.header.name"/></td>
						<td width="20%" style="text-align: center;"><spring:message code="be041.table.header.phone"/></td>
						<td width="38%" style="text-align: center;"><spring:message code="be041.table.header.email"/></td>
						<td width="12%" style="text-align: center;"><spring:message code="be043.choose.email.to.send"/></td>
					</tr>
				</thead>
				<tbody>
					<c:forEach items="${mailListDetails}" var="mailListDetail">
						<tr>
							<td width="25%" class="name"><span>${mailListDetail.name}</span></td>
							<td width="20%" id="phone"><span>${mailListDetail.phone}</span></td>
							<td width="38%" class="email"><span id="email">${mailListDetail.email}</span></td>
							<td width="12%" class="chk-send-email" style="text-align: center;">
								<input value="${mailList.mailListId}" type="checkbox" checked="checked"/></td>
						</tr>
					</c:forEach>
				</tbody>
			</table>
		</div>
	</div>
	<div class="row">
		<label class="col-sm-10 control-label"><spring:message code="be043.label.email_template"/></label>
	</div>
	<div class="row">
		<div class="col-sm-6">
			<select id="slt-mail-template" class="form-control" name="mailTmp">
				<option value=""><spring:message code="be043.title.selectBox.temp.mail"/></option>
				<c:forEach  var="mailTmp" items="${mailTemplate}">
					<option value="${mailTmp.mailTemplateId}">${mailTmp.subject}</option>
				</c:forEach>
			</select>
		</div>
		<label id="selectMailTemp" style="color: red;"></label>
	</div>
	<br/>
	<div class="row">
		<label class="col-sm-10 control-label"><spring:message code="be043.label.option.select.doctor"/></label>
	</div>
	<div class="row">
			<div class="col-sm-4">
				<select id="slt-department" class="form-control" name="department">
					<option value=""><spring:message code="be004.label.search.department.all"/></option>
					<c:forEach  var="department" items="${departmentList}">
						<option value="${department.deptId}">${department.deptName}</option>
					</c:forEach>
				</select>
			</div>
			<div class="col-sm-4">
				<select id="slt-doctor" class="form-control" name="doctor">
				</select>
			</div>
	</div>
	<br/>
	<div class="row">
		<div class="col-sm-10">
			<sec:authorize ifAnyGranted="ROLE_MAIL_SENDING">
				<button id="btn-send-email" type="button" class="btn btn-primary"><spring:message code='be043.button.confirm.send'/></button>
			</sec:authorize>
	    </div>
    </div>
</div>
<script>
	var be043_email_template_required = '<spring:message code="be043.email.template.required" />'
</script>

<script type="text/javascript" src="<c:url value='/assets/js/schedule/ScheduleSendMailList.js'/>">
</script>