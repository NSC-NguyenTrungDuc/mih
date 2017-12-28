<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>

<form:form class="form-horizontal" role="form" method="POST" commandName="userRole">
	<sec:authorize ifAnyGranted="ROLE_USER">
		<div class="form-group">
			<div class="col-sm-4">
				 <div class="input-group">
				      <div class="input-group-addon"><spring:message code="be092.label.form.loginId" /></div>
				      <form:input class="form-control" path="loginId" maxlength="64" />
				  </div>
			</div>
			<div class="col-sm-4">
				<div class="input-group">
				      <div class="input-group-addon"><spring:message code="be092.label.form.roleName" /></div>
				      <form:select class="form-control" path="roleId" items="${roles}" itemValue="roleId" itemLabel="roleName"/>
				  </div>
			</div>
			<div class="col-sm-4">
				<div class="input-group">
				      <div class="input-group-addon"><spring:message code="be092.label.form.password" /></div>
				      <form:password class="form-control" path="loginPass" maxlength="128" />
				  </div>
			</div>
		</div>
		<div class="form-group">
			<div class="col-sm-4">
				<input id="btnNewUser" type="button" class="btn btn-primary pull-left btn-90" data-toggle="modal" data-target="#divAddNewUser" value="<spring:message code="be092.label.form.addnew" />">
			</div>
		</div>
	</sec:authorize>
	<table id="tblIdManagement" style="table-layout: fixed;" class="table table-bordered display">
		<thead>
			<tr style="background-color: #4f6070; color: white; font-weight: bold;">
				<th style="width: 100px;"><spring:message code="be092.label.form.id" /></th>
				<th style="width: 100px;"><spring:message code="be092.label.form.role" /></th>
				<sec:authorize ifAnyGranted="ROLE_USER"><th style="width: 80px;"><spring:message code="be092.label.form.delete" /></th></sec:authorize>
				<sec:authorize ifAnyGranted="ROLE_USER"><th><spring:message code="be092.label.form.changePass" /></th></sec:authorize>
			</tr>
		</thead>
		<tbody id="tblIdManagement-body">
			<c:forEach varStatus="status" var="temp" items="${users}">
				<tr>
					<td style="width: 100px; word-wrap: break-word;">${temp.loginId}</td>
					<td style="width: 100px;">
						<sec:authorize ifAnyGranted="ROLE_USER">
							<form:select class="form-control roleSelect" path="roleIdList[${status.index}]">
									<c:forEach var="role" items="${roles}">
										<c:if test="${role.roleId == temp.role.roleId}">
											<c:set var="selected" value="true" />
										</c:if>
										<option value="${role.roleId}"
											<c:if test="${selected}">selected="selected"</c:if>>
											${role.roleName}</option>
										<c:remove var="selected" />
									</c:forEach>
							</form:select>
						</sec:authorize>
						<sec:authorize ifNotGranted="ROLE_USER">
							<form:select class="form-control" path="roleIdList[${status.index}]" disabled="true">
									<c:forEach var="role" items="${roles}">
										<c:if test="${role.roleId == temp.role.roleId}">
											<c:set var="selected" value="true" />
										</c:if>
										<option value="${role.roleId}"
											<c:if test="${selected}">selected="selected"</c:if>>
											${role.roleName}</option>
										<c:remove var="selected" />
									</c:forEach>
							</form:select>
						</sec:authorize>
					</td>
					<sec:authorize ifAnyGranted="ROLE_USER">
						<td style="width: 100px;">
							<input type="button" class="btn btn-default pull-left btn-90 deleteBtn" data-toggle="modal" data-target="#deleteUser" onclick="setUserToDelete(this)" value="<spring:message code="be092.label.form.delete" />">
						</td>
					</sec:authorize>
					<sec:authorize ifAnyGranted="ROLE_USER">
						<td>
							<input type="button" class="btn btn-default pull-left changePassBtn" value="<spring:message code="be092.label.form.changePass" />">
							<div class="col-sm-4 divInputPass" style="display: none;">
								<form:password class="form-control inputPass" maxlength="128" path="newPass[${status.index}]" />
							</div>
							<div class="col-sm-3 divSavePass " style="display: none;">
								<input type="button" class="btn btn-default pull-left btn-90 savePassBtn" value="<spring:message code="be092.label.form.change" />">
							</div>
						</td>
					</sec:authorize>
				</tr>
			</c:forEach>
		</tbody>
	</table>
	
	<table id="tblRole" class="table table-bordered" style="margin-top: 20px;">
		<thead>
			<tr style="background-color: #4f6070; color: white; font-weight: bold;">
				<th><spring:message code="be092.label.form.loginId" /></th>
				<th><spring:message code="be092.label.form.roleUser" /></th>
				<th><spring:message code="be092.label.form.roleSchedule" /></th>
				<th><spring:message code="be092.label.form.roleMailSending" /></th>
				<th><spring:message code="be092.label.form.roleReservation" /></th>
			</tr>
		</thead>
		<tbody id="tblRole-body">
			<c:forEach var="item" items="${roles}">
				<tr>
					<td>${item.roleName}</td>
					<td align="center"><c:if test="${item.userFlg == 1}">〇</c:if></td>
					<td align="center"><c:if test="${item.scheduleFlg == 1}">〇</c:if></td>
					<td align="center"><c:if test="${item.mailSendingFlg == 1}">〇</c:if></td>
					<td align="center"><c:if test="${item.reservationFlg == 1}">〇</c:if></td>
				</tr>
			</c:forEach>
		</tbody>
	</table>
</form:form>

<div class="modal fade" id="deleteUser">
	<div class="modal-dialog modal-sm">
		<div class="modal-content">
			<div class="modal-body">
				<button type="button" class="close" data-dismiss="modal">
					<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message code="fe022.modal.close" /></span>
				</button>
				<p>
					<spring:message code="fe092.modal.delete.user.title" />
				</p>
			</div>
			<div class="modal-footer">
				<button id="btnExecuteDelete" type="button" value="" class="btn btn-success btn-90">
					<spring:message code="fe022.modal.confirm" />
				</button>
				<button type="button" class="btn btn-default btn-90" data-dismiss="modal">
					<spring:message code="fe022.modal.close" />
				</button>
			</div>
		</div>
	</div>
</div>

<div class="modal fade" id="divAddNewUser">
	<div class="modal-dialog modal-sm">
		<div class="modal-content">
			<div class="modal-body">
				<button type="button" class="close" data-dismiss="modal">
					<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message code="fe022.modal.close" /></span>
				</button>
				<h4 class="modal-title">
					<spring:message code="fe092.modal.add.user.body" />
				</h4>
			</div>
			<div class="modal-footer">
				<button id="btnExecuteAddUser" type="button" value="" class="btn btn-success btn-90">
					<spring:message code="fe022.modal.confirm" />
				</button>
				<button type="button" class="btn btn-default btn-90" data-dismiss="modal">
					<spring:message code="fe022.modal.close" />
				</button>
			</div>
		</div>
	</div>
</div>

<script type="text/javascript">
$(document).ready(function() {
	$(".changePassBtn").click(function(){
		if($(this).parent().find(".divInputPass").css("display") == "none") {
			$(this).parent().find(".divInputPass").show();
			$(this).parent().find(".divInputPass input").val("");
			$(this).parent().find(".divSavePass").show();
			$(this).val('<spring:message code="be030.modal.close" />');
		}else {
			$(this).val('<spring:message code="be092.label.form.changePass" />');
			$(this).parent().find(".divInputPass").hide();
			$(this).parent().find(".divSavePass").hide();
		}
	});
	
	$(".savePassBtn").click(function() {
		var loginId = $(this).parent().parent().parent().find("td:first").text();
		var newPass = $(this).parent().parent().find(".inputPass").val();
		var model = {"loginId":loginId,"loginPass":newPass};
		var temp = $(this).parent().parent();
		$.ajax({
			type : "post",
			url : "ajax-update-password-for-user",
			data : JSON.stringify(model),
			dataType : "json",
			async : false,
			beforeSend : function(xhr) { 
				xhr.setRequestHeader("Accept","application/json");
				xhr.setRequestHeader("Content-Type","application/json");
			},
			success : function(response) {
				if(response.status == 200) {
					temp.find(".divInputPass").hide();
					temp.find(".divSavePass").hide();
					temp.find(".changePassBtn").val('<spring:message code="be092.label.form.changePass" />');
				}
				alertResponseMessage(response);
			},
			error : function() {
				alert('Error while request..');
			}
		}); 
	});

});
</script>
<script>
	var re007_table_record_each_page = '<spring:message code="table.record.each.page" />'
	var re007_table_previous = '<spring:message code="table.previous" />'
	var re007_table_next = '<spring:message code="table.next" />'
	var re007_table_last = '<spring:message code="table.last" />'
	var re007_table_empty = '<spring:message code="table.empty" />'
	var re007_table_info_empty = '<spring:message code="table.info.empty" />'
	var re007_table_info_total = '<spring:message code="table.info.total" />'
	var re007_table_info_start = '<spring:message code="table.info.start" />'
	var re007_table_info_end = '<spring:message code="table.info.end" />'
	var re007_s_info = '<spring:message code="table.s.info" />'
</script>
<script type="text/javascript" src="<c:url value='/assets/js/user-manage/IdManagement.js' />"></script>