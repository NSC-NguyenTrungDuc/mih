<%@ page language="java" contentType="text/html;charset=UTF-8" %>
<%@ include file="/WEB-INF/jsp/front/includes/taglibs.jsp"%>
<%@ taglib tagdir='/WEB-INF/tags' prefix='sc'%>

<div class="form-register">
	<div class="col-md-4 left-form">
		<h4><spring:message code="hp205.desc.header"/></h4>
		<div class="map">
			<iframe height="450" frameborder="0" width="100%"
				allowfullscreen="" style="border: 0; pointer-events: none;"
				src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3241.99705877164!2d139.73624880000003!3d35.652444100000004!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x60188ba1693b8a81%3A0xc43bfc691599774c!2zSmFwYW4sIOOAkjEwNi0wMDQ3IFTFjWt5xY0tdG8sIE1pbmF0by1rdSwgTWluYW1pYXphYnUsIDEgQ2hvbWXiiJI24oiSOCDljZfpurvluIPlj6Tlt53jg5Pjg6s!5e0!3m2!1svi!2s!4v1436045358266"></iframe>
		</div>
		<h4><spring:message code="hp205.desc.info.header"/></h4>
		<div class="contact-add">
			<p>
				<span><spring:message code="hp205.desc.info.label.ja-name"/></span>: <spring:message code="hp205.desc.info.ja-name"/>
			</p>
			<p>
				<span><spring:message code="hp205.desc.info.label.en-name"/></span>: <spring:message code="hp205.desc.info.en-name"/>
			</p>
			<p>
				<span><spring:message code="hp205.desc.info.label.location"/></span>: <spring:message code="hp205.desc.info.location"/>
			</p>
			<p>
				<span><spring:message code="hp205.desc.info.label.contact"/></span> <spring:message code="hp205.desc.info.phone"/><br>
				<span class="fax"><spring:message code="hp205.desc.info.fax"/></span>
			</p>
		</div>
	</div>
	<div class="col-md-8 right-form">
		<h4><spring:message code="hp205.form.header"/></h4>
		<form:form action="contact-us" method="post" modelAttribute="contactUsInfo">
			<div class="row">
				<div class="col-md-4">
					<label><spring:message code="hp205.form.label.company-name"/></label>
				</div>
				<div class="col-md-8">
					<input type="text" class="form-control" value="${contactUsInfo.companyName}" name="companyName" maxlength="256">
					<span class="mss-validate-fr"><form:errors path="companyName" cssClass="input-error"/><form:errors/></span>
				</div>
			</div>
			<div class="row">
				<div class="col-md-4">
					<label><spring:message code="hp205.form.label.pic-name"/></label>
				</div>
				<div class="col-md-8">
					<input type="text" class="form-control" value="${contactUsInfo.picName}" name="picName" maxlength="256">
					<span class="mss-validate-fr"><form:errors path="picName" cssClass="input-error"/></span>
				</div>
			</div>
			<div class="row">
				<div class="col-md-4">
					<label><spring:message code="hp205.form.label.email"/></label>
				</div>
				<div class="col-md-8">
					<input type="text" class="form-control" value="${contactUsInfo.mailAddress}" name="mailAddress" maxlength="128">
					<span class="mss-validate-fr"><form:errors path="mailAddress" cssClass="input-error"/></span>
				</div>
			</div>
			<div class="row">
				<div class="col-md-4">
					<label><spring:message code="hp205.form.label.content"/></label>
				</div>
				<div class="col-md-8">
					<textarea height="145px" class="form-control" width="100%" name="content" maxlength="1000">${contactUsInfo.content}</textarea>
					<span class="mss-validate-fr" style="top:147px"><form:errors path="content" cssClass="input-error"/></span>
				</div>
			</div>
			<div class="row">
				<div class="col-md-4">
					<label><spring:message code="hp205.form.label.captcha"/></label>
				</div>
				<div class="col-md-8">
					<sc:captcha/>
					<span class="mss-validate-fr" style="top:135px"><c:if test="${not empty captchaError}"><span class="input-error">${captchaError}</span></c:if></span>
				</div>
			</div>
			<div class="row">
				<div class="col-md-4"></div>
				<div class="col-md-4">
					<button class="btn-commit"><spring:message code="hp205.form.btn.submit"/></button>
				</div>
			</div>
		</form:form>
	</div>
</div>