<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<c:url var="submit" value="crm-mail-send-mail-list-submit" />
<div id="save-mail-list" class="col-md-10">
<form:form action="${submit}">
	<div class="row">
		<h4 class="section-heading"><spring:message code="be204.label.list.patient" /></h4>
		<table id="dataTable" class="table table-bordered display">
				<thead>
					<tr style="background-color: #4f6070;color: white;font-weight: bold;">
						<th><spring:message code="be204.label.form.patientName" /></th>
						<th><spring:message code="be204.label.form.diseaseName" /></th>
						<th><spring:message code="be204.label.form.lastest.go.hospital" /></th>
						<th><spring:message code="be204.label.form.age" /></th>
						<th><spring:message code="be204.label.form.sex" /></th>
						<th><spring:message code="be204.label.form.email" /></th>
					</tr>
				</thead>
				<tbody>
					<c:forEach items="${mailListDetails}" var="mailListDetail">
						<tr>
							<td><span>${mailListDetail.patientName}</span></td>
							<td><span>${mailListDetail.diseaseName}</span></td>
							<td><span>${mailListDetail.lastestGoHospital}</span></td>
							<td><span>${mailListDetail.patientAge}</span></td>
							<td><span>${mailListDetail.patientSex}</span></td>
							<td><span>${mailListDetail.patientEmail}</span></td>
						</tr>
					</c:forEach>
				</tbody>
			</table>
	</div>
	<br/>
	<div class="row">
    	<h4 class="section-heading"><spring:message code="be204.label.mail.template" /></h4>
    </div>
	<div class="row">
		<label class="col-sm-10 control-label"><spring:message
			code="be204.label.mail.template.name" /><strong> ${mailTemplate.subject}</strong></label>
    </div>
    
    
	<br/>
	<div class="row">
		<div class="col-sm-10">
			<button type="button" class="btn btn-primary" data-toggle="modal"
							data-target="#confirmSendMailList">
				<spring:message code='be204.button.confirm.send'/>
			</button>
			<button type="button" class="btn btn-default" onclick="window.history.back()"><spring:message code="be204.button.confirm.cancel"/></button>
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
