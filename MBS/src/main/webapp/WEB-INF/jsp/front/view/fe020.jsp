<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>

<div class="col-md-10">
	<form:form class="form-horizontal" role="form" method="POST" commandName="mail" action="${pageContext.request.contextPath}/booking/confirm-authorized-email" >
		<h2>
			<spring:message code="fe020.label.title" />
		</h2>
		<p class="lead">
			<spring:message code="fe020.message.inform.to.customer" />
		</p>

		<div class="form-group">
			<label for="inputEmail" class="col-sm-3 control-label"><spring:message code="fe020.label.email.address" /></label>
			<div class="col-sm-7">
				<form:input id="inputEmail" path="email" class="form-control" placeholder="Email" maxlength="128" />
				<form:errors path="email" cssClass="error" cssStyle="color:red" />
				<label style="color: red;">${message}</label>
			</div>
		</div>
		
		<div class="form-group">
			<div class="col-sm-offset-5 col-sm-10">
				<button type="submit" class="btn btn-success btn-sm"><spring:message code='fe020.label.submit.button' /></button>
			</div>
		</div>

	</form:form>
</div>
<script>
	disableSubmitButtonAfterSubmission(":submit");
</script>
