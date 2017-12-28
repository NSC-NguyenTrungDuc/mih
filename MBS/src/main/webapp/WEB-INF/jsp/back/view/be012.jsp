<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 

<!-- Confirm add department -->
<c:url var="confirmUrl" value="/schedule/add-doctor" />

<div id="schedule-add-doctor-wrapper" class="col-md-10" class="form-horizontal">
	
		<form:form class="form-horizontal" action="${confirmUrl}" role="form" method="POST" commandName="doctor">
			<!-- <h2>
				<spring:message code="be012.title.messages" />
			</h2>  -->
			<div id="validation" style="display:none">${validation}</div>
			<div id="schedule-add-doctor-info">
				<div class="remind">
					<ul>
						<li><span class="hospital-name">${hospitalName}</span></li>
						<li><spring:message code="be012.title.messages" /></li>
					</ul>
				</div>
				<br />
				<div class="form-group">
					<label for="name" class="col-sm-3 control-label"><spring:message code="be012.label.doctor.name"/><font color="red">*</font></label>
					<div class="col-sm-7">
						<form:input id="inputDoctorName" path="name" class="form-control" maxlength="64" />
						<form:errors path="name" cssClass="error" cssStyle="color:red" />
					</div>
				</div>
				
				<div class="form-group">
	 				<label for="orderPriority" class="col-sm-3 control-label"><spring:message code="be012.label.order.priority"/><font color="red">*</font></label>
					<div class="col-sm-7">
						<form:input id="inputOrderPriority" path="orderPriority" class="form-control" maxlength="9"/>
						<form:errors path="orderPriority" cssClass="error" cssStyle="color:red" />
						<p style="color: red;">
							${message}
						</p>
					</div>
				</div>
				
				<div class="form-group">
	 				<label class="col-sm-3 control-label"><spring:message code="be012.label.copy.schedule"/></label>
					<div class="col-sm-7">
						<form:select class="form-control" path="copyDoctorId">
							<form:option value="-1"><spring:message code="be012.label.select.none" /></form:option>
							<form:options items="${doctorList}" itemValue="doctorId" itemLabel="name"/>
						</form:select>
					</div>
				</div>
				
				<div class="form-group">
					<div class="col-sm-12" align="center">
						<input type="submit" value="<spring:message code="be012.label.add.doctor" />" class="btn btn-primary" name="validate" />
					</div>
				</div>
	
				<div class="col-sm-offset-3 col-sm-10" align="center">
					<c:if test="${isOK == true}">
						<p style="color: blue;">
							<spring:message code="be012.msg.add.doctor.succ" arguments="${doctor.name}" />
						</p>
					</c:if>
					<c:if test="${isOK == false}">
						<p style="color: red;">
							<spring:message code="be012.msg.add.doctor.error" />
						</p>
					</c:if>
					<p style="color: red;">
						${message}
					</p>
				</div>
			</div>
			<!-- [Start] Show dialog confirm -->
			<div class="modal fade" id="confirmAddDoctor">
				<div class="modal-dialog modal-sm">
					<div class="modal-content">
						<!-- [Start] Header dialong -->
						<div class="modal-body">
							<button type="button" class="close" data-dismiss="modal">
								<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message code="popup.label.close" /></span>
							</button>
							<p>
								<spring:message code="be012.modal.title.add_doctor" />
							</p>
						</div>
		
						<div class="modal-footer" align="center">
							<input id="confirm-add-doctor" type="submit" value="<spring:message code="popup.label.comfirm" />" class="btn btn-success" name="confirm" />
							<button type="button" class="btn btn-default" data-dismiss="modal"> <spring:message code="popup.label.cancel" />
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
		$('#confirmAddDoctor').modal('show');
	}
});
</script>