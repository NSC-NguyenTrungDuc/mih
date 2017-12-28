<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%> 

<c:url var="changePasswordUrl" value="/booking/change-password" ></c:url>

<div class="col-md-10">
	<h2>
		<spring:message code="fe109.message.header" />
	</h2>
	<form:form method="post" action="${changePasswordUrl}" class="form-horizontal" modelAttribute="passwordInfo">
		<form:hidden path="email"/>
   		<div class="form-group">
   	  		<label class="col-sm-3 control-label">
   	  			<spring:message code="fe109.label.pass" /><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-7">
				<form:password class="form-control" path="password" maxlength="128" />
				<form:errors path="password" cssClass="alert-danger" />
   		    </div>
   		</div>
   		<div class="form-group">   	  		
   	  		<label class="col-sm-3 control-label">
   	  			<spring:message code="fe109.label.pass.confirm" /><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-7">
				<form:password class="form-control" path="passwordConfirm" maxlength="128" />
				<form:errors path="passwordConfirm" cssClass="alert-danger" />
   		    </div>
   		</div>
   		<div class="form-group">	    	    
    		<div class="col-sm-offset-3 col-sm-7">
    			<button type="submit" class="btn btn-success btn-sm" id="btnSubmit"><spring:message code="general.button.confirm"/></button>
    		</div>
    	</div>
	</form:form>
</div>