<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<c:url var="loginAction" value="/back/j_spring_security_check_for_backend"/>
<!-- CONTENT-->
<script>
$(document).ready(function(){
	$("#loginUsername").focus();
});
</script>
<div class="wr-content">
	<div class="container">
		<div class="row">
        	<!-- Login Form -->
            <div class="col-md-4"></div>
            <div class="col-md-4">
            	<div class="panel panel-default ">
			  	<div class="panel-heading">
			    	<h3 class="panel-title"><spring:message code="general.login.title" /></h3>
                    
			 	</div>
			  	<div class="panel-body">
			  		<c:if test="${not empty param['error_login']}">     
			  			<div class="alert alert-danger" role="alert"><spring:message code="general.login.invalid" /></div>  			
		  			 </c:if>
			    	<form method="post" action="${loginAction}" id= "frmLogin" autocomplete="off" accept-charset="UTF-8" role="form">
                    <fieldset>
			    	  	<div class="form-group">
			    	  		<spring:message code="general.login.placeholder.loginId" var="loginId" />
			    		    <input id="loginUsername" class="form-control" placeholder="${loginId}" name="j_username" type="text" autocomplete="off" maxlength="128">
			    		</div>
			    		<div class="form-group">
			    			<spring:message code="general.login.placeholder.password" var="password" />
			    			<input id="loginUserPassword" class="form-control" placeholder="${password}" name="j_password" type="password" autocomplete="off">
			    		</div>
			    		<div class="checkbox">
			    	    	<label>
			    	    		<input name="remember-me" type="checkbox" value="Remember Me"><spring:message code="general.login.remember" />
			    	    	</label>
			    	    </div>
			    	    <input id="loginUserHospitalId" placeholder="${hospitalId}" class="form-control" name="j_hospital_id" type="hidden" autocomplete="off" value="${hospitalId}">
			    		<p><input class="btn btn-lg btn-success btn-block" type="submit" value="<spring:message code="general.login.btn.submit" />"></p>
			    		<br/>
			    	</fieldset>
			      	</form>
			    </div>
			</div>
            
            </div>
            <div class="col-md-4"></div>		
		</div>
	</div>
</div>
<!-- END CONTENT-->

