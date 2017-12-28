<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>

<!-- Confirm add department -->
<c:url var="confirmUrl" value="/schedule/add-department" />

<div id="schedule-add-dept-wrapper" class="col-md-10">
		<form:form class="form-horizontal" action="${confirmUrl}" role="form"
			method="POST" commandName="department">
			<h2>
				<spring:message code="be011.title.messages" />
			</h2>
			<div id="validation" style="display:none">${validation}</div>
			<div id="schedule-add-dept-info">
				<div class="remind">
					<ul>
						<li><span class="hospital-name">${hospitalName}</span></li>
						<li><spring:message code="be011.label.add.department" /></li>
					</ul>
				</div>
				<br />
				<div class="form-group">
					<div class="col-sm-3">
						<spring:message code="be011.label.dept.name" /><font color="red">*</font>
					</div>
					<div class="col-sm-7">
						<form:input id="inputDeptName" path="deptName" class="form-control"
							maxlength="256" />
						<form:errors path="deptName" cssClass="error" cssStyle="color:red" />
					</div>
				</div>
	
				<div class="form-group">
					<div class="col-sm-3">
						<spring:message code="be011.label.display.order" /><font color="red">*</font>
					</div>
					<div class="col-sm-7">
						<form:input id="inputDisplayOrder" path="displayOrder"
							class="form-control" maxlength="9" />
						<form:errors path="displayOrder" cssClass="error"
							cssStyle="color:red" />
					</div>
				</div>
				<div class="form-group">
					<div class="col-sm-3">
						<spring:message code="be011.label.dept.code" /><font color="red">*</font>
					</div>
					<div class="col-sm-7">
						<form:input id="inputDeptCode" path="deptCode"
							class="form-control" maxlength="11" cssStyle="" />
						<form:errors path="deptCode" cssClass="error"
							cssStyle="color:red" />
					</div>
				</div>
				
				<div class="form-group">
					<div class="col-sm-3">
						<spring:message code="be011.label.dept.type" /><font color="red">*</font>
					</div>
					<div class="col-sm-7">
						<form:select id="inputDeptType" path="deptType" cssClass="form-control" items="${deptTypes}" />
						<form:errors path="deptType" cssClass="error" cssStyle="color:red" />
					</div>
				</div>
				<div class="form-group">
					<div class="col-sm-offset-4 col-sm-10">
						<input type="submit" value="<spring:message code="be011.label.add.department" />" class="btn btn-primary" name="validate" />
					</div>
					<br />
					<div class="col-sm-offset-3 col-sm-10">
						<c:if test="${isOK == true}">
							<p style="color: blue;">
								<spring:message code="be011.msg.add.dept.succ"
									arguments="${department.deptName}" />
							</p>
						</c:if>
						<c:if test="${isOK == false}">
							<p style="color: red;">
								<spring:message code="be011.msg.add.dept.error" />
							</p>
						</c:if>
						<p style="color: red;">
							${message}
						</p>
					</div>
				</div>
			</div>
			<%-- [End] schedule-add-dept-info --%>
			<!-- [Start] Show dialog confirm -->
			<div class="modal fade" id="confirmAddDept">
				<div class="modal-dialog modal-sm">
					<div class="modal-content">
						<!-- [Start] Header dialong -->
						<div class="modal-body">
							<button type="button" class="close" data-dismiss="modal">
								<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message code="popup.label.close" /></span>
							</button>
							<p>
								<spring:message code="be011.modal.addDept.title" />
							</p>
						</div>
		
						<div class="modal-footer" align="center">
							<input id="confirm-add-dept" type="submit" value="<spring:message code="popup.label.comfirm" />" class="btn btn-success" name="confirm" />
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
$(document).ready(function() {
	if (!$("#validation").is(":empty")) {
		$('#confirmAddDept').modal('show');
	}
});
</script>