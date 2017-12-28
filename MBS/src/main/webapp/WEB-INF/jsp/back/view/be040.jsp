<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>
<c:url var="updateUrl" value="mail-update-mail-list-accept"/>
<c:url var="importCSV" value="mail-import-csv"/>
<div id="promotion-mail-remainder-mailling" class="col-md-12">
	<div id="remainder-mailling-info">
		<form:form class="form-horizontal" role="form" action="mail-send-email" method="GET" commandName="mailList"> 
			<h2>
				<spring:message code="be040.label.remainder.mailling" />
			</h2>
			<div class="row">
				<div class="form-group">
					<div class="col-sm-2 control-label">
						<label><spring:message code="be040.label.list.name" /></label>
					</div>
					<div class="col-sm-8">
						<form:select path="mailListId" cssClass="form-control"
							items="${mailListNames}" />
						<form:errors path="mailListId" cssClass="error"
							cssStyle="color:red" />
						<label style="color: red;" id="message">${message}</label>
					</div>
					<div class="col-sm-2">
						<sec:authorize ifAnyGranted="ROLE_MAIL_SENDING">
						<a href="<c:url value='/mail/mail-add-new-mail-list'/>" class="btn btn-primary btn-change"> 
							<spring:message code="be040.label.add.new.mail.list" />
						</a>
						</sec:authorize>
					</div>
				</div>
			</div>
			<br />
			<div class="row">
					<div class="col-sm-offset-1 col-sm-2">
						<sec:authorize ifAnyGranted="ROLE_MAIL_SENDING">
						<button type="submit" class="btn btn-primary btn-change">
							<spring:message code="be040.label.send.email" />
						</button>
						</sec:authorize>
					</div>
					<div class="col-sm-offset-1 col-sm-2">
						<sec:authorize ifAnyGranted="ROLE_MAIL_SENDING">
						<button type="button" id="update-mail-list" class="btn btn-primary btn-change">
							<spring:message code="be040.label.update.list" />
						</button>
						</sec:authorize>
					</div>
					<div class="col-sm-offset-1 col-sm-2">
						<sec:authorize ifAnyGranted="ROLE_MAIL_SENDING">
						<button type="button" class="btn btn-primary btn-change" data-toggle="modal"
								data-target="#confirmDeleteMailList">
							<spring:message code="be040.label.delete.list" />
						</button>
						</sec:authorize>
					</div>
					
					<div class="col-sm-offset-1 col-sm-2">
						<sec:authorize ifAnyGranted="ROLE_MAIL_SENDING">
							<button type="button" id="export-csv" class="btn btn-primary btn-change">
							<spring:message code="be040.label.csv.exmport" />
						</button>
						</sec:authorize>
					</div>
			</div>
		</form:form>
		
		<!-- [Start] Show dialog confirm -->
		<div class="modal fade" id="confirmDeleteMailList">
			<div class="modal-dialog modal-sm">
				<div class="modal-content">
					<!-- [Start] Header dialong -->
					<div class="modal-body">
						<button type="button" class="close" data-dismiss="modal">
							<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message
									code="popup.label.close" /></span>
						</button>
						<p>
							<spring:message code="be040.label.delete.list" />
						</p>
					</div>

					<div class="modal-footer" align="center">
						<button id="delete-mail-list" type="button" class="btn btn-success" >
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
	</div>
</div>
<sec:authorize ifAnyGranted="ROLE_MAIL_SENDING">
	<%@ include file="../view/be040-1.jsp" %>
</sec:authorize>

<script>
	var be040_email_group_invalid = '<spring:message code="be040.email.group.invalid" />'
</script>

<script type="text/javascript" src="<c:url value='/assets/js/schedule/ScheduleDeleteMailList.js'/>">
</script>