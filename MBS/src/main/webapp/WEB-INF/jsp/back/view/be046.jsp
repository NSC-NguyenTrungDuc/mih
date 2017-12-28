<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

<c:url var="updateUrl" value="mail-update-mail-list-detail"/>
<c:url var="backUrl" value="mail-reminder-mail-list-check" />
<c:url var="addNewDetail" value="mail-add-new-mailDetail" />

<form:form action="mail-update-mail-list-accept" commandName="mailList" method="POST">
	<div class="row">
		<div class="col-sm-12">
			<label class="col-sm-4 control-label">
				<spring:message code="be046.label.mail.list.detail" />
			</label>
		</div>
		<div class="col-sm-12">
			<form:hidden id="mailListId" path="mailListId"/>
			<table class="table table-hover">
				<thead>
					<tr>
						<th>#</th>
						<th><spring:message code="be046.table.header.name"/></th>
						<th><spring:message code="be046.table.header.email"/></th>
						<th><spring:message code="be046.button.edit"/></th>
						<th><spring:message code="be046.button.delete"/></th>
					</tr>
				</thead>
				<tbody>
					<c:forEach var="mailListDetail" items="${mailList.mailListDetailModels}" varStatus="i">
						<tr data-id="${mailListDetail.email}">
							<td width="5%">${i.index + 1}</td>
							<td width="25%">${mailListDetail.name}</td>
							<td width="60%">${mailListDetail.email}</td>
							<td width="5%"><a href="${updateUrl}?mailListId=${mailListDetail.mailListId}&email=${mailListDetail.email}" class="btn btn-primary btn-xs btn-change btn-60"><spring:message code="be046.button.edit" /></a></td>
							<td width="5%"><button type="button" class="btn btn-danger btn-xs btn-delete-mail-confirm btn-60" data-toggle="modal" data-target="#deleteMailListDetail"><spring:message code="be046.button.delete" /></button></td>
						</tr>
					</c:forEach>
				</tbody>
			</table>
		</div>
	</div>
	<div class="row">
		<div class="col-sm-12">
			<label for="inputMailListName" class="col-sm-4 control-label">
				<spring:message code="be046.label.mail.list.name" />
			</label>
			<div class="col-sm-8">
				<form:input id="inputMailListName" path="mailListName"
					class="form-control" maxlength="256" />
				<form:errors path="mailListName" cssClass="error"
					cssStyle="color:red" />
			</div>
		</div>
	</div>
	<div class="row">
		<div class="col-sm-12">
			<button type="button" class="btn btn-primary"
				id="btn-update-mail-list" data-toggle="modal" data-target="#confirmUpdateMailList">
				<spring:message code="be046.update.mail.list.confirm" />
			</button>
			<button type="button" id="btn-add-new-detail" class="btn btn-primary">
				<spring:message code="be046.add.mail.list.detail" />
			</button>
			<button type="button" id="btn-Back" class="btn btn-danger" onclick="location.href='${backUrl}'" >
					<spring:message code="general.button.back" />
			</button>
		</div>
	</div>
	
	<!-- [Start] Show dialog confirm update mail list -->
	<div class="modal fade" id="confirmUpdateMailList">
		<div class="modal-dialog modal-sm">
			<div class="modal-content">
				<!-- [Start] Header dialong -->
				<div class="modal-body">
					<button type="button" class="close" data-dismiss="modal">
						<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message
								code="popup.label.close" /></span>
					</button>
					<p>
						<spring:message code="be046.update.mail.list.confirm" />
					</p>
				</div>

				<div class="modal-footer" align="center">
					<button id="update-mail-list" type="submit" class="btn btn-primary">
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
	
	<!-- [Start] Show dialog confirm delete mail list -->
	<div class="modal fade" id="deleteMailListDetail">
		<div class="modal-dialog modal-sm">
			<div class="modal-content">
				<!-- [Start] Header dialong -->
				<div class="modal-body">
					<button type="button" class="close" data-dismiss="modal">
						<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message
								code="popup.label.close" /></span>
					</button>
					<p>
						<spring:message code="be046.delete.mail.list.detail.confirm" />
					</p>
				</div>

				<div class="modal-footer" align="center">
					<button id="delete-mail" type="button" class="btn btn-primary">
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

<script type="text/javascript" src="<c:url value='/assets/js/schedule/ScheduleUpdateMailListDetail.js'/>">
</script>

