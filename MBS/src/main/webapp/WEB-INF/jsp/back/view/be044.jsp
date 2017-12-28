<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<c:url var="submit" value="mail-send-mail-list-submit" />
<div id="save-mail-list" class="col-md-10">
<form:form action="${submit}">
	<h2>
		<spring:message code="be044.label.send.mail" />
	</h2>
	<div class="row">
		<label class="col-sm-10 control-label"><spring:message
			code="be044.label.mail.template.name" /> ${mailTemplate.subject} </label>
	</div>
	<div class="row">
		<label class="col-sm-10 control-label"><spring:message code="be044.label.mail.list" /> </label>
	</div>
	<div class="row">
		<div class="col-sm-10">
			<table id="dataTable" class="table table-bordered">
				<thead>
					<tr>
						<th width="25%" style="text-align: center;"><spring:message code="be041.table.header.name"/></th>
						<th width="20%" style="text-align: center;"><spring:message code="be041.table.header.phone"/></th>
						<th width="55%"style="text-align: center;"><spring:message code="be041.table.header.email"/></th>
					</tr>
				</thead>
				<tbody>
					<c:forEach items="${mailListDetails}" var="mailListDetail">
						<tr>
							<td width="25%" class="name"><span>${mailListDetail.name}</span></td>
							<td width="20%"><span>${mailListDetail.phone}</span></td>
							<td width="55%" class="email"><span id="email">${mailListDetail.email}</span></td>
						</tr>
					</c:forEach>
				</tbody>
			</table>
		</div>
	</div>
	<br/>
	<div class="row">
		<div class="col-sm-10">
			<sec:authorize ifAnyGranted="ROLE_MAIL_SENDING">
			<button type="button" class="btn btn-primary" data-toggle="modal"
							data-target="#confirmSendMailList">
				<spring:message code='be044.button.confirm.send'/>
			</button>
			</sec:authorize>
			<button type="button" class="btn btn-default" onclick="window.history.back()"><spring:message code="be044.button.cancel.send"/></button>
		</div>
	</div>
	
	<!-- [Start] Show dialog confirm -->
		<div class="modal fade" id="confirmSendMailList">
			<div class="modal-dialog modal-sm">
				<div class="modal-content">
					<!-- [Start] Header dialong -->
					<div class="modal-body">
						<button type="button" class="close" data-dismiss="modal">
							<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message
									code="popup.label.close" /></span>
						</button>
						<p>
							<spring:message code="be044.label.send.mail"/>
						</p>
					</div>

					<div class="modal-footer" align="center">
						<button id="accept-send-mail-list" type="submit"
							class="btn btn-success">
							<spring:message code="popup.label.comfirm" />
						</button>
						<button type="button" class="btn btn-default" data-dismiss="modal">
							<spring:message code="popup.label.cancel" />
						</button>
						
					</div>
				</div>
			</div>
		</div>
		<!-- [End] Show dialog  -->
		</form:form>
</div>
<script>
	disableSubmitButtonAfterSubmission(":submit");
</script>
