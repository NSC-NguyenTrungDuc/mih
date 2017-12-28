<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<c:url var="backUrl" value="../booking-manage/select-department"/>
<c:url var="confirmUrl" value="hospital-manage-detail"/>
<form:form method="post" class="form-horizontal" action="${confirmUrl}" modelAttribute="hospitalModel" enctype="multipart/form-data">
	<form:input type="hidden" path="hospitalId" class="form-control" value="${hospitalModel.hospitalId}"/>
	<form:input type="hidden" path="hospitalCode" class="form-control" value="${hospitalModel.hospitalCode}"/>
	<form:input type="hidden" path="hospitalIconPath" class="form-control" value="${hospitalModel.hospitalIconPath}"/>
	<form:errors cssClass="alert-danger"></form:errors>
	<div id="validation" style="display:none">${validation}</div>
	<div class="form-group">
		<label class="col-xs-12 col-sm-2 control-label"><spring:message code="be202.label.hospital.code"/></label>
		<div class="col-xs-12 col-sm-10">
			<label class="control-label">${hospitalModel.hospitalCode}</label>
		</div>
	</div>
	<div class="form-group">
		<label class="col-xs-12 col-sm-2 control-label"><spring:message code="be202.label.hospital.name"/><sup class="highlight-red">*</sup></label>
		<div class="col-xs-12 col-sm-10">
			<form:input type="text" path="hospitalName" class="form-control" value="${hospitalModel.hospitalName}" autocomplete="off" maxlength="128" readonly="true"/>
			<form:errors path="hospitalName" cssClass="text-danger error-msg"/>
		</div>
	</div>
	<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
	<div class="form-group">
		
		<label class="col-xs-12 col-sm-2 control-label"><spring:message code="be202.label.hospital.furi.name"/><sup class="highlight-red">*</sup></label>
		<div class="col-xs-12 col-sm-10">
			<form:input type="text" path="hospitalNameFurigana" class="form-control" value="${hospitalModel.hospitalNameFurigana}" autocomplete="off" maxlength="128" readonly="true"/>
			<form:errors path="hospitalNameFurigana" cssClass="text-danger error-msg" />
		</div>
	</div>
	<% } else { %>
		<form:hidden path="hospitalNameFurigana" class="form-control" value="ベトナムフリガナ" autocomplete="off" maxlength="128"/>
	<% } %>
	
	<div class="form-group">
		<label class="col-xs-12 col-sm-2 control-label"><spring:message code="be202.label.hospital.address"/><sup class="highlight-red">*</sup></label>
		<div class="col-xs-12 col-sm-10">
			<form:input type="text" path="address" class="form-control" value="${hospitalModel.address}" autocomplete="off" maxlength="128" readonly="true"/>
			<form:errors path="address" cssClass="text-danger error-msg"/>
		</div>
	</div>
	<div class="form-group">
		<label class="col-xs-12 col-sm-2 control-label"><spring:message code="be202.label.hospital.email"/><sup class="highlight-red">*</sup></label>
		<div class="col-xs-12 col-sm-10">
			<form:input type="text" path="email" class="form-control" value="${hospitalModel.email}" autocomplete="off" maxlength="128" readonly="true"/>
			<form:errors path="email" cssClass="text-danger error-msg"/>
		</div>
	</div>
	<div class="form-group">
		<label class="col-xs-12 col-sm-2 control-label"><spring:message code="be202.label.hospital.phone"/><sup class="highlight-red">*</sup></label>
		<div class="col-xs-12 col-sm-10">
			<form:input type="text" path="phoneNumber" class="form-control" value="${hospitalModel.phoneNumber}" autocomplete="off" maxlength="20" readonly="true"/>
			<form:errors path="phoneNumber" cssClass="text-danger error-msg"/>
		</div>
	</div>
	<div class="form-group">
		<label class="col-xs-12 col-sm-2 control-label"><spring:message code="be202.label.hospital.logo"/></label>
		<div class="col-xs-12 col-sm-10">
		 <label for="img"> <span class="btn" style="border-color: black; background-color: buttonhighlight;"><spring:message code="be202.choose.file"/></span></label> 
             <input type="file" name="file" size="40" id="img" accept="image/*" onchange="loadFile(event)" class="hidden">
             <br/>
             <div class="logo-wrap">
               <img id="output" src="<c:url value="${hospitalModel.hospitalIconPath}" />" alt="" style="max-width: 400px; max-height: 80px; border: none;"/>
             </div>
		</div>
	</div>
	
	
	<!-- button action save or back -->
	<div class="form-group">
		<div class="col-xs-12 col-sm-2"></div>
		<div class="col-xs-12 col-sm-10">
			<button type="submit" class="btn btn-primary" name="validate">
				<spring:message code="be202.button.save"/>
			</button>

		</div>
	</div>
	
	<!-- Alter confirmation -->
	<div class="modal fade" id="saveHospital">
		<div class="modal-dialog modal-sm">
			<div class="modal-content">
				<div class="modal-body">
					<button type="button" class="close" data-dismiss="modal">
						<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message code="be202.modal.close" /></span>
					</button>
					<p>
						<spring:message code="be202.modal.hospital.edit.title" />	
					</p>
				</div>
				<div class="modal-footer">
					<input type="submit" value="<spring:message code="be202.modal.confirm" />" class="btn btn-success" name="confirm" />
					<button type="button" class="btn btn-default" data-dismiss="modal">
						<spring:message code="be202.modal.close" />
					</button>
				</div>
			</div>
		</div>
	</div>
</form:form>
<script type="text/javascript" src="<c:url value='/assets/js/hospital-manage/EditHospital.js' />"></script>