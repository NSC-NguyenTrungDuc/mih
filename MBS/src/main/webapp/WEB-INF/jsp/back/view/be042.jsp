<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>

<c:url var="confirmUrl" value="/mail/mail-save-mail-list-confirm" />
<div id="save-mail-list" class="col-md-10">
	<form:form action="${confirmUrl}" commandName="mailListModel">
		<h2>
			<spring:message code="be042.label.create.mailling.list" />
		</h2>
		<div class="row">
			<div class="col-sm-12">
				<table class="table table-bordered">
					<thead>
								<tr>
									<th width="30%" style="text-align: center;"><spring:message code="be041.table.header.name"/></th>
									<th width="20%" style="text-align: center;"><spring:message code="be041.table.header.phone"/></th>
									<th width="45%"style="text-align: center;"><spring:message code="be041.table.header.email"/></th>
								</tr>
					</thead>
					<tbody>
						<c:forEach items="${mailListModel.reminderMails}" var="reminderMail">
							<tr>
								<td><span class="name">${reminderMail.name}</span></td>
								<td>${reminderMail.phone}</td>
								<td><span class="email">${reminderMail.mail}</span></td>
							</tr>
						</c:forEach>
					</tbody>
				</table>
			</div>
		</div>
		<div class="row">
			<div class="col-sm-3">
				<spring:message code="be042.label.mail.list.name" /><font color="red">*</font>
			</div>
			<div class="col-sm-7">
				<form:input id="inputMailListName" path="mailListName"
					class="form-control" maxlength="256" />
				<form:errors path="mailListName" cssClass="error"
					cssStyle="color:red" />
				<label style="color: red;">${message}</label>
			</div>
		</div>
		<br/>
		<div class="row" align="left">
			<div class="col-sm-10">
				<form:hidden path="mailListId"/>
				<sec:authorize ifAnyGranted="ROLE_MAIL_SENDING">
				<button type="submit" class="btn btn-primary" >
					<spring:message code="be042.confirm.save" />
				</button>
				</sec:authorize>
				<button type="button" class="btn btn-default" onclick="window.history.back()"><spring:message code="be042.go.back"/></button>
			</div>
		</div>

		<!-- [Start] Show dialog confirm -->
		<%-- <div class="modal fade" id="confirmAddMailList">
			<div class="modal-dialog modal-sm">
				<div class="modal-content">
					<!-- [Start] Header dialong -->
					<div class="modal-body">
						<button type="button" class="close" data-dismiss="modal">
							<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message
									code="popup.label.close" /></span>
						</button>
						<p>
							<spring:message code="be042.confirm.save" />
						</p>
					</div>

					<div class="modal-footer" align="center">
						<button id="save-mail-list" type="submit"
							class="btn btn-success">
							<spring:message code="popup.label.comfirm" />
						</button>
						<button type="button" class="btn btn-default" data-dismiss="modal">
							<spring:message code="popup.label.cancel" />
						</button>
						
					</div>
				</div>
			</div>
		</div> --%>
		<!-- [End] Show dialog  -->
	</form:form>
</div>
