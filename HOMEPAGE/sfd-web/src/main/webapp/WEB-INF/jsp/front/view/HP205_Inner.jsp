<%@ page language="java" contentType="text/html;charset=UTF-8" %>
<%@ include file="/WEB-INF/jsp/front/includes/taglibs.jsp"%>
<%@ taglib tagdir='/WEB-INF/tags' prefix='sc'%>
<style>
	.form-group1 {
		margin-bottom: 35px;
	}
</style>
<%--<div class="form-register">--%>

	<%--<div class="col-md-12 right-form">--%>
		<%--<h4><spring:message code="hp205.form.header"/></h4>--%>
		<form:form action="contact-us-inner" method="post" modelAttribute="contactUsInfo">
			<div class="row form-group1">
				<div class="col-xs-4">
					<label><spring:message code="hp205.form.label.company-name"/></label>
				</div>
				<div class="col-xs-8">
					<input type="text" class="form-control" value="${contactUsInfo.companyName}" name="companyName" maxlength="256">
					<span class="mss-validate-fr"><form:errors path="companyName" cssClass="input-error"/><form:errors/></span>
				</div>
			</div>
			<div class="row form-group1">
				<div class="col-xs-4">
					<label><spring:message code="hp205.form.label.pic-name"/></label>
				</div>
				<div class="col-xs-8">
					<input type="text" class="form-control" value="${contactUsInfo.picName}" name="picName" maxlength="256">
					<span class="mss-validate-fr"><form:errors path="picName" cssClass="input-error"/></span>
				</div>
			</div>
			<div class="row form-group1">
				<div class="col-xs-4">
					<label><spring:message code="hp205.form.label.email"/></label>
				</div>
				<div class="col-xs-8">
					<input type="text" class="form-control" value="${contactUsInfo.mailAddress}" name="mailAddress" maxlength="128">
					<span class="mss-validate-fr"><form:errors path="mailAddress" cssClass="input-error"/></span>
				</div>
			</div>
			<div class="row form-group1">
				<div class="col-xs-4">
					<label><spring:message code="hp205.form.label.content"/></label>
				</div>
				<div class="col-xs-8">
					<textarea height="145px" class="form-control" width="100%" name="content" maxlength="1000">${contactUsInfo.content}</textarea>
					<span class="mss-validate-fr" style="top:147px"><form:errors path="content" cssClass="input-error"/></span>
				</div>
			</div>
			<div class="row form-group1">
				<div class="col-xs-4">
					<label><spring:message code="hp205.form.label.captcha"/></label>
				</div>
				<div class="col-xs-8">
					<sc:captcha/>
					<span class="mss-validate-fr" style="top:135px"><c:if test="${not empty captchaError}"><span class="input-error">${captchaError}</span></c:if></span>
				</div>
			</div>
			<div class="row form-group1">
				<div class="col-xs-4"></div>
				<div class="col-xs-4">
					<button class="btn-commit"><spring:message code="hp205.form.btn.submit"/></button>
				</div>
			</div>
		</form:form>
	<%--</div>--%>
<%--</div>--%>