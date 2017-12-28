<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page import="nta.mss.misc.common.MssConfiguration" %>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%> 
<c:url var="indexUrl" value="/index" />
<c:url var="registerUrl" value="/booking/register" />
<c:url var="backUrl" value="/booking/index" />
<na" class="col-md-12">
	<form:form method="post" action="${registerUrl}" class="form-horizontal" modelAttribute="user" >
		<div class="form-group" action="#">
			<div class="col-sm-12">
				<div class="box-highlight text-center">
					<a href="https://www.facebook.com/dialog/oauth?client_id=<%=MssConfiguration.getInstance().getFaceBookAppId()%>&redirect_uri=<%=MssConfiguration.getInstance().getFaceBookRegisterUrlRedirect() %>&scope=email" class="btn btn-facebook btn-lg"><i class="fa fa-facebook-official "></i><spring:message code="general.btn.register.facebook"/></a>
				</div>
			</div>
		</div>
		<hr class="line">
		<div class="form-group">
   	  		<spring:message code="re002.place.holder.name" var="labelName" />
   	  		<label class="col-sm-3 control-label">
   	  			<spring:message code="re002.label.name"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-9">
				<form:input class="form-control" path="name" maxlength="64" placeholder="${labelName}" />
				<form:errors path="name" cssClass="alert-danger" />
   		    </div>
   		</div>
   		<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
		<c:if test="${user.isFaceBook == 'false' }">
   		<div class="form-group">
   	  		<spring:message code="re002.place.holder.name.furigana" var="labelNameFurigana" />
   	  		<label class="col-sm-3 control-label">
   	  			<spring:message code="re002.label.name.furigana"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-9">
   	  			<form:input class="form-control" path="nameFurigana" maxlength="64" placeholder="${labelNameFurigana}" />
				<form:errors path="nameFurigana" cssClass="alert-danger" />
   		    </div>
   		</div>
		</c:if>
		<c:if test="${user.isFaceBook == 'true' }">
			<form:hidden path="nameFurigana" class="form-control" value="ニチイ　イチ" autocomplete="off" maxlength="64"/>
		</c:if>
   		<% } else { %>
		<form:hidden path="nameFurigana" class="form-control" value="ベトナムフリガナ" autocomplete="off" maxlength="64"/>
		<% } %>
   		<div class="form-group">
   	  		<label class="col-sm-3 control-label">
   	  			<spring:message code="general.label.sex"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-9 form-control-static">
   	  			<form:radiobutton path="sex" value="1" checked="checked"/><spring:message code="general.label.sex.male" /> 
				<form:radiobutton path="sex" value="0"/><spring:message code="general.label.sex.female" />
   		    </div>
   		</div>
   		
   		<div class="form-group" >
   	  		<spring:message code="re002.place.holder.dob" var="labelDob" />
   	  		<label class="col-sm-3 control-label">
   				<spring:message code="re002.label.dob"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-9">
				<form:input class="form-control"  path="dob" maxlength="32" placeholder="${labelDob}" />
				<form:errors path="dob" cssClass="alert-danger" />
   		    </div>
   		</div>
   		<div class="form-group" style="display: none">
   	  		<spring:message code="re002.place.holder.address" var="labelAddress" />
   	  		<label class="col-sm-3 control-label">
   				<spring:message code="re002.place.holder.address"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-9">
				<form:input class="form-control" path="address" maxlength="32" placeholder="${labelAddress}" />
				<form:errors path="address" cssClass="alert-danger" />
   		    </div>
   		</div>
   		<div class="form-group">
   	  		<spring:message code="re002.place.holder.phone" var="labelPhone" />
   	  		<label class="col-sm-3 control-label">
   	  			<spring:message code="re002.label.phone"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-9">
				<form:input class="form-control" path="phoneNumber" maxlength="32" placeholder="${labelPhone}" />
				<form:errors path="phoneNumber" cssClass="alert-danger" />
   		    </div>
   		</div>
   		<div class="form-group">
   	  		<spring:message code="re002.place.holder.email" var="labelEmail" />
   	  		<label class="col-sm-3 control-label">
   	  			<spring:message code="re002.label.email"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-9">
				<c:if test="${user.isFaceBook == 'false' }">

				<form:input class="form-control" path="email" maxlength="128" placeholder="${labelEmail}" />
				</c:if>
				<c:if test="${user.isFaceBook == 'true' }">
					<form:input class="form-control" path="email" maxlength="128" placeholder="${labelEmail}" />
				</c:if>
				<form:errors path="email" cssClass="alert-danger" />
   		    </div>
   		</div>
   		<%--<div class="form-group">
   	  		<spring:message code="re002.label.loginId" var="labelLoginId" />
   	  		<label class="col-sm-3 control-label">
   	  			${labelLoginId}<font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-7">
				<form:input class="form-control" path="loginId" maxlength="128" placeholder="${labelLoginId}" />
				<form:errors path="loginId" cssClass="alert-danger" />
   		    </div>
   		</div>--%>

		<c:if test="${user.isFaceBook == 'false' }">
			<div class="form-group">
				<label class="col-sm-3 control-label">
					<spring:message code="re002.label.pass" /><font color="red">*</font>
				</label>
				<div class="col-sm-9">
					<form:password class="form-control" path="password" maxlength="128" />
					<form:errors path="password" cssClass="alert-danger" />
				</div>
			</div>

			<div class="form-group">
				<label class="col-sm-3 control-label">
					<spring:message code="re002.label.pass.confirm" /><font color="red">*</font>
				</label>
				<div class="col-sm-9">
					<form:password class="form-control" path="passwordConfirm" maxlength="128" />
					<form:errors path="passwordConfirm" cssClass="alert-danger" />
				</div>
			</div>

		</c:if>
		<form:hidden class="form-control" path="isFaceBook" maxlength="128"/>
		<form:hidden class="form-control" path="loginId" maxlength="128"  />
		<form:hidden class="form-control" path="token" maxlength="128"   />

   		<div class="form-group">	    	    
    		<div class="col-sm-offset-5 col-sm-7">
    			<button type="submit" class="btn btn-success btn-sm" id="btnSubmit"><spring:message code="general.login.btn.register"/></button>
				<button type="button" class="btn btn-default btn-back" onclick="location.href='${backUrl}'"><spring:message code="general.button.cancel"/></button>
    		</div>
    	</div>
	</form:form>
</div>
<script>
$(document).ready(function() {
	var isMobile = MssUtils.detectmob();
	if(isMobile)
	{
		MssUtils.focusIncaseMobile('#user');
	}
	disableSubmitButtonAfterSubmission("#btnSubmit");
	$("#dob").datepicker({
		beforeShow: function() {
			setTimeout(function(){
				$('.ui-datepicker').css('z-index', 99999999999999);
			}, 0);
		},
		dateFormat: 'yy/mm/dd',
		maxDate: 0
	});

});
</script>