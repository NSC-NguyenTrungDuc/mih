<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%> 
<c:url var="forgetPasswordUrl" value="/booking/forget-password" />
<div class="col-md-10">
   	<form:form method="post" action="${forgetPasswordUrl}" class="form-horizontal" modelAttribute="mail">
   		<h2>
			<spring:message code="re00101.message.header" />
		</h2>
   		<div class="form-group">
   	  		<spring:message code="re002.place.holder.email" var="labelEmail" />
   	  		<label class="col-sm-3 control-label">
   	  			<spring:message code="re002.label.email"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-7">
				<form:input class="form-control" path="email" maxlength="128" placeholder="${labelEmail}" />
				<form:errors path="email" cssClass="alert-danger" />
				<c:if test="${not empty message}">
					<div class="alert-danger">${message}</div>
				</c:if>
   		    </div>
   		</div>
   		<div class="form-group">	    	    
    		<div class="col-sm-offset-3 col-sm-7">
    			<button type="submit" class="btn btn-success btn-sm" id="btnSubmit"><spring:message code="general.button.confirm"/></button>
    		</div>
    	</div>
	</form:form>
</div>
<script>
$(document).ready(function() {
	disableSubmitButtonAfterSubmission("#btnSubmit");
});
</script>