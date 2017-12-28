<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%> 
<c:url var="addChildUrl" value="/booking/add-child" />
<c:url var="backUrl" value="/booking/profile-management" />
<script>
	var dobCurrent = '${dobCurrent}';
</script>
<div class="col-md-12">
	<form:form method="post" action="${addChildUrl}" class="form-horizontal" modelAttribute="userChildModel" >
		<form:hidden path="childId"/>
    	<form:hidden path="userId"/>
    	<form:hidden path="patientId"/>
		<div class="form-group">
   	  		<spring:message code="re008.place.holder.name" var="labelName" />
   	  		<label class="col-sm-4 control-label">
   	  			<spring:message code="re008.label.name"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-8">
				<form:input class="form-control" path="childName" maxlength="64" placeholder="${labelName}" />
				<form:errors path="childName" cssClass="alert-danger" />
   		    </div>
   		</div>
   		<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
   		<div class="form-group">
   	  		<spring:message code="re008.place.holder.furigana" var="labelName" />
   	  		<label class="col-sm-4 control-label">
   	  			<spring:message code="re008.label.furigana"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-8">
				<form:input class="form-control" path="childNameFurigana" maxlength="64" placeholder="${labelName}" />
				<form:errors path="childNameFurigana" cssClass="alert-danger" />
   		    </div>
   		</div>
   		<% } else { %>
		<form:hidden path="childNameFurigana" class="form-control" value="ベトナムフリガナ" autocomplete="off" maxlength="64"/>
		<% } %>
   		<div class="form-group">
   	  		<label class="col-sm-4 control-label">
   	  			<spring:message code="general.label.sex"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-8 form-control-static">
   	  			<form:radiobutton path="sex" value="1" checked="checked"/><spring:message code="general.label.sex.male" /> 
				<form:radiobutton path="sex" value="0"/><spring:message code="general.label.sex.female" />
   		    </div>
   		</div>
   		<div class="form-group">
   	  		<label class="col-sm-4 control-label">
   	  			<spring:message code="re008.label.birthday"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-8">
				<form:input class="form-control"  path="dob"/>
				<form:errors path="dob" cssClass="alert-danger" />
   		    </div>
   		</div>
   		<div class="form-group">	    	    
    		<div class="col-sm-offset-4 col-sm-8">
    			<c:choose>
    				<c:when test="${isChange}">
	    				<button type="submit" class="btn btn-success btn-sm" id="btnSubmit"><spring:message code="re008.btn.change.child"/></button>	
    				</c:when>
    				<c:otherwise>
    					<button type="submit" class="btn btn-success btn-sm" id="btnSubmit"><spring:message code="re008.btn.add.child"/></button>
    				</c:otherwise>
    			</c:choose>
				<button type="button" class="btn btn-default" onclick="location.href='${backUrl}'"><spring:message code="general.button.cancel"/></button>
    		</div>
    	</div>
	</form:form>
</div>

<script type="text/javascript">

	$(document).ready(function(){
		initPage();
		function initPage() {
			$("#dob").datepicker({ 
				dateFormat: 'yy/mm/dd',
				maxDate: 0
			});
			
			if (dobCurrent != "") {
				$("#dob").val(dobCurrent);
			} else {
				$("#dob").val(getCurrentDate());
			}
		}
		
		function getCurrentDate() {
			var now = new Date();
		    var day = ("0" + now.getDate()).slice(-2);
		    var month = ("0" + (now.getMonth() + 1)).slice(-2);
		    var today = now.getFullYear() +"/"+ month +"/"+ day+"";
		    return today;
		}
	});
</script>