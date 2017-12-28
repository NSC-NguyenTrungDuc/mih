<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>

<c:url var="updateUrl" value="mail-update-mail-list-detail"/>
<c:url var="backUrl" value="mail-reminder-mail-list-check" />
<c:url var="addNewDetail" value="mail-add-new-mailDetail" />
<div id="add-new-email-list" class="col-md-12">
	<h2>
		<spring:message code="be041.label.add.new.email" />
	</h2>
	<c:choose>
		<c:when test="${mailListModel.mailListId != null}">
			<form:form action="mail-update-mail-list-accept" commandName="mailList" method="POST">
				<div class="row">
					<div class="col-sm-12">
						<label class="col-sm-4 control-label">
							<spring:message code="be046.label.mail.list.detail" />
						</label>
					</div>
					<div class="col-sm-12">
						<form:hidden id="mailListId" path="mailListId"/>
						<table id="tblMailListDetail" class="table table-hover"> 
							<thead>
								<tr>
									<th width="30%" style="text-align: center;"><spring:message code="be041.table.header.name"/></th>
									<th width="20%" style="text-align: center;"><spring:message code="be041.table.header.phone"/></th>
									<th width="45%" style="text-align: center;"><spring:message code="be041.table.header.email"/></th>
									<th width="5%" />
								</tr>
							</thead>
							<tbody>
								<c:forEach var="mailListDetail" items="${mailList.mailListDetailModels}" varStatus="i">
									<tr data-id="${mailListDetail.email}">
										<td width="30%"><input type="text" name="name" value="${mailListDetail.name}" class="form-control" maxlength="64"/></td>
										<td width="25%"><input type="text" name="phone" value="${mailListDetail.phone}" class="form-control" maxlength="32"/></td>
										<td width="45%"><input type="text" readonly="readonly" name="email" class="form-control" value="${mailListDetail.email}"/></td>
										<td><input type="hidden" name="emailOld" value="${mailListDetail.email}"/></td>
										<sec:authorize ifAnyGranted="ROLE_MAIL_SENDING">
											<td width="5%" ><button type="button" class="btn btn-danger btn-delete-mail-confirm btn-60" data-toggle="modal" data-target="#deleteMailListDetail"><spring:message code="be046.button.delete"/></button></td>
										</sec:authorize>
									</tr>
								</c:forEach>
							</tbody>
						</table>
					</div>
				</div>

				<div class="row">
					<div class="col-sm-12">
						
						<table id="tblAddMailListDetail" class="table table-hover">
							<thead>
								<tr>
									<th width="5%"><input type="button"  class="btn btn-primary " value="<spring:message code="be041.label.add.new.row" />" onclick="addRow('tblAddMailListDetail')" /></th>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td width="30%"><input type="text" name="name" class="form-control" placeholder="<spring:message code="be041.place.holder.input.name"/>" maxlength="64"/></td>
									<td width="20%"><input type="text" name="phone" class="form-control" placeholder="<spring:message code="be041.place.holder.input.phone"/>" maxlength="32"/></td>
									<td width="45%"><input type="text" name="email" class="form-control" placeholder="<spring:message code="be041.place.holder.input.email"/>" maxlength="128"/></td>
									<td width="5%"><input type="button" class="btn btn-danger btn-delete-mail-confirm btn-60" value="<spring:message code="be046.button.delete"/>" onclick="deleteRow('tblAddMailListDetail', this)" /></td>
								</tr>
							</tbody>
						</table>
					</div>
				</div>
				<div class="row">
					<label id="errorMsgUpdate" style="color: red;"></label> 
				</div>
				<div class="row">
					<div class="col-sm-12">
						<sec:authorize ifAnyGranted="ROLE_MAIL_SENDING">
							<button type="button" class="btn btn-primary" id="btn-update-mail-list">
								<spring:message code="be041.update.mail.list.confirm" />
							</button>
						</sec:authorize>
						<button type="button" id="btn-Back" class="btn btn-default" onclick="location.href='${backUrl}'" >
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
								<sec:authorize ifAnyGranted="ROLE_MAIL_SENDING">
									<button id="update-mail-list" type="submit" class="btn btn-success">
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
				<!-- [End] Show dialog -->
				
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
								<sec:authorize ifAnyGranted="ROLE_MAIL_SENDING">
									<button id="delete-mail" type="button" class="btn btn-success">
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
			</form:form>
		</c:when>
		
		<c:otherwise>
			<div class="row">
				<div class="col-md-12">
						<table id="dataTable" class="table table-hover">
							<thead>
								<tr>
									<th width="30%" style="text-align: center;"><spring:message code="be041.table.header.name"/></th>
									<th width="20%" style="text-align: center;"><spring:message code="be041.table.header.phone"/></th>
									<th width="45%"style="text-align: center;"><spring:message code="be041.table.header.email"/></th>
									<th width="5%"><input type="button"  class="btn btn-primary " value="<spring:message code="be041.label.add.new.row"/>" onclick="addRow('dataTable')" /></th>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td width="30%"><input type="text" name="name" class="form-control" placeholder="<spring:message code="be041.place.holder.input.name"/>" maxlength="64"/></td>
									<td width="20%"><input type="text" name="phone" class="form-control" placeholder="<spring:message code="be041.place.holder.input.phone"/>" maxlength="32"/></td>
									<td width="45%"><input type="text" name="email" class="form-control" placeholder="<spring:message code="be041.place.holder.input.email"/>" maxlength="128"/></td>
									<td width="5%"><input type="button" class="btn btn-danger" value="<spring:message code="be041.label.delete.row"/>" onclick="deleteRow('dataTable', this)" /></td>
								</tr>
							</tbody>
						</table>
				</div>
			</div>
			<div>
				<label id="errorMessage" style="color: red;"></label>
			</div>
			<div class="row">
				<div class="col-md-8">
					<sec:authorize ifAnyGranted="ROLE_MAIL_SENDING">
						<input type="button" id="create-and-save" class="btn btn-primary btn-change" value="<spring:message code="be041.label.create.name.and.save"/>" />
					</sec:authorize>
				</div>
			</div>
		</c:otherwise>
	</c:choose>
</div>

<script>
	var be041_name_email_invalid = '<spring:message code="be041.name.email.invalid" />';
</script>
<script>
	var be041_error_delete_rows = '<spring:message code="be041.error.delete.rows" />';
</script>

<script type="text/javascript"
 	src="<c:url value='/assets/js/schedule/ScheduleAddMailList.js'/>">
</script>
<!-- <script type="text/javascript"  -->
<%-- 	src="<c:url value='/assets/js/schedule/ScheduleUpdateMailListDetail.js'/>"> --%>
<!-- </script> -->