<%@ page language="java" contentType="text/html;charset=UTF-8"%>
<%@ include file="/WEB-INF/jsp/front/includes/taglibs.jsp"%>
<%@ taglib tagdir='/WEB-INF/tags' prefix='sc'%>

<c:url var="testRegistrationUrl" value="/service/registration-for-test" />

<div class="col-md-12">
    <div class="entry-content clearfix">
		<div class="form-register">
			<div class="col-md-4 left-form">
				<h3><spring:message code="hp105.desc.header"/></h3>
				<p><spring:message code="hp105.desc.content"/></p>
			</div>
			<div class="col-md-8 right-form">
				<h3><spring:message code="hp105.form.header"/></h3>
				<form:form method="post" action="${testRegistrationUrl}" class="form-horizontal" modelAttribute="hospital">
					<div class="row">
						<div class="col-md-4">
							<label><spring:message code="hp105.form.label.hospital-name"/></label>
						</div>
						<div class="col-md-8">
							<form:input type="text" class="form-control" value="${hospital.hospitalName}" path="hospitalName" maxlength="256"/>
							<span class="mss-validate-fr"><form:errors path="hospitalName" cssClass="input-error"/><form:errors/></span>
						</div>
					</div>
					<div class="row">
						<div class="col-md-4">
							<label><spring:message code="hp105.form.label.register-name"/></label>
						</div>
						<div class="col-md-8">
							<form:input type="text" class="form-control" value="${hospital.registerName}" path="registerName" maxlength="256"/>
							<span class="mss-validate-fr"><form:errors path="registerName" cssClass="input-error"/><form:errors/></span>
						</div>
					</div>
					<div class="row">
						<div class="col-md-4">
							<label><spring:message code="hp105.form.label.register-email"/></label>
						</div>
						<div class="col-md-8">
							<form:input class="form-control" type="text" value="${hospital.registerEmail}" path="registerEmail" maxlength="128"/>
							<span class="mss-validate-fr"><form:errors path="registerEmail" cssClass="input-error"/><form:errors/></span>
						</div>
					</div><div class="row">
						<div class="col-md-4">
							<label><spring:message code="hp105.form.label.captcha"/></label>
						</div>
						<div class="col-md-8">
							<sc:captcha/>
							<span class="mss-validate-fr" style="top:135px"><c:if test="${not empty captchaError}"><span class="input-error">${captchaError}</span></c:if></span>
						</div>
					</div>
					<div class="row">
						<div class="col-md-12">
							<div class="mss-text"><spring:message code="hp105.form.info"/></div>
						</div>
					</div>
					<div class="row">
						<div class="col-md-4"></div>
						<div class="col-md-4 center">
							<input type="submit" value="<spring:message code='hp105.form.btn.submit'/>" class="btn-commit"/>
						</div>
					</div>
				</form:form>
			</div>
		</div>
	</div>
</div>