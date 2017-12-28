<%@ page import="nta.mss.misc.common.MssConfiguration" %>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@page import="nta.mss.model.HospitalTrackingModel"%>
<%@page import="java.util.List"%>
<%@page import="nta.med.common.util.Strings"%>
<%@page import="org.apache.commons.collections.CollectionUtils"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<c:url var="loginAction" value="/booking/j_spring_security_check_for_frontend"/>
<c:url var="registerUrl" value="/booking/register" />
<c:url var="forgetPasswordUrl" value="/booking/forget-password" />
<script>
$(document).ready(function(){
	$("#loginUsername").focus();

	if('${isLoginFaceBook}' == 'true')
	{
		document.getElementById("frmLogin").submit();

	}
	var isMobile = MssUtils.detectmob();
	if(isMobile)
	{
		MssUtils.focusIncaseMobile('#frmLogin');
	}	
});
</script>
<div class="col-md-12">
   	<form method="post" action="${loginAction}" id= "frmLogin" class="form-horizontal" autocomplete="off" accept-charset="UTF-8" role="form">

		<div class="form-group" action="#">
			<div class="col-sm-12">
				<div class="box-highlight text-center">
					<a href="https://www.facebook.com/dialog/oauth?client_id=<%=MssConfiguration.getInstance().getFaceBookAppId()%>&redirect_uri=<%=MssConfiguration.getInstance().getFaceBookLoginUrlRedirect() %>&scope=email" class="btn btn-facebook btn-lg"><i class="fa fa-facebook-official "></i><spring:message code="general.btn.signin.facebook"/></a>
				</div>
			</div>
		</div>


		<div class="col-sm-12">
    		<c:if test="${not empty param['error_login']}">
	  			<div class="alert alert-danger" role="alert"><spring:message code="general.login.invalid" /></div>
			</c:if>
    	</div>
   	  	<div class="form-group">
   	  		<spring:message code="re002.place.holder.email" var="loginId" />
   	  		<label class="col-sm-3 control-label"><spring:message code="be204.label.form.email"/></label>
   	  		<div class="col-sm-9">
				<input id="loginUsername" value="${user}" class="form-control" placeholder="${loginId}" name="j_username" type="text" autocomplete="off" maxlength="128" >
   		    </div>
   		</div>
   		<div class="form-group">
   			<spring:message code="general.login.placeholder.password" var="password" />
   			<label class="col-sm-3 control-label">${password}</label>
			<c:if test="${isLoginFaceBook == 'false' }">
				<div class="col-sm-9">
					<input id="loginUserPassword" class="form-control" placeholder="${password}" name="j_password" type="password" autocomplete="off">
				</div>
			</c:if>

			<c:if test="${isLoginFaceBook == 'true' }">
				<div class="col-sm-9">
					<input id="loginUserPassword1" class="form-control" value="<%=MssConfiguration.getInstance().getDefaultPassword()%>" name="j_password" type="password" autocomplete="off">
				</div>
			</c:if>
   		</div>
   		<div class="form-group">	    	    
    		<div class="col-sm-offset-5 col-sm-7">
    			<button class="btn btn-success btn-sm" type="submit" ><spring:message code="general.login.btn.submit" /></button>
    		</div>
    	</div>
    	<div class="form-group">	    	    
    		<div class="col-sm-offset-3 col-sm-9">
    			<spring:message code="re001.label.link.register" arguments="${registerUrl},${forgetPasswordUrl}"/>
    		</div>
    	</div>
		<input type="hidden" name="isLoginFaceBook" value="${isLoginFaceBook}">
		<input type="hidden" name="accessToken" value="${accessToken}">
    	<input id="loginUserHospitalId" placeholder="${hospitalId}" class="form-control" name="j_hospital_id" type="hidden" autocomplete="off" value="${hospitalId}">
	</form>
</div>
<%
	if(request.getParameter("verify_account") != null &&
			request.getParameter("verify_account").equals("true" ))
	{
		List<HospitalTrackingModel> lst = MssContextHolder.getTrackingScript();

		if(CollectionUtils.isNotEmpty(lst))
		{
			String trackingCode = "" ;
			for (int i = 0; i < lst.size(); i++) {
				String pageCode= lst.get(i).getPage_code();
				if(pageCode.equals("re001"))
				{
					trackingCode = trackingCode + lst.get(i).getTracking_scripts();
				}
			}
			if(!Strings.isEmpty(trackingCode))
				out.println(trackingCode);
		}
	}
%>
