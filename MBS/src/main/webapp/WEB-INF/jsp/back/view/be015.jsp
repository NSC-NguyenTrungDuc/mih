<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>
<c:url var="submitUrl" value="/schedule/execute-import-department-schedule" />

<form:form class="form-horizontal" role="form" method="POST"
	action="${submitUrl}" enctype="multipart/form-data"
	commandName="uploadFile">
	<sec:authorize ifAnyGranted="ROLE_SCHEDULE">
		<div class="form-group">
			<label for="file" class="col-sm-2 control-label"><spring:message code="be015.label.file" /></label>
			<div class="col-sm-5">
			<label for="be013"> <span class="btn" style="border-color: black; background-color: buttonhighlight; position: absolute; width: 93px;"><spring:message code="be040.choose.file"/></span></label> 
						<input type="file" name="file" id="be013" style="top: 0px;"/>
			</div>
		</div>
		<div class="form-group">
			<label for="patientName" class="col-sm-2 control-label"><spring:message
					code="be015.label.applyDate" /></label>
			<div class="col-sm-4">
				<form:input class="form-control" path="applyDate" />
				<form:errors path="applyDate" cssClass="error"
					cssStyle="color:red" />
			</div>
		</div>
		<div class="form-group">
			<label class="col-sm-2 control-label">
				<spring:message code="be015.label.overwrite_schedule" />
			</label>
			<div class="col-sm-4" style="padding-top:5px;">
				<form:checkbox path="overwriteSchedule" />
			</div>
		</div>
		<div class="form-group">
			<div class="col-sm-8" align="center">
				<input id="searchBtn" type="submit" class="btn btn-primary" value="<spring:message code="be015.label.upload" />">
			</div>
		</div>
		<div class="form-group">
		<div class="col-sm-8 alert-danger" align="center">
			${msgError}</div>
		<div class="col-sm-8 alert-success" align="center">
			${msgSuccess}</div>
	</div>
	</sec:authorize>
	<sec:authorize ifNotGranted="ROLE_SCHEDULE">
		<div class="form-group">
			<div class="col-sm-8 alert-danger" align="center"><spring:message code="be015.label.not.have.permission" /></div>
		</div>
	</sec:authorize>
</form:form>

<script type="text/javascript">
$(document).ready(function() {
	initPage();
	function initPage() {
		$("#applyDate").datepicker({ dateFormat: 'yy/mm/dd'});
		$("#applyDate").val(getCurrentDate());
	}
	
	function getCurrentDate() {
		var now = new Date();
	    var day = ("0" + now.getDate()).slice(-2);
	    var month = ("0" + (now.getMonth() + 1)).slice(-2);
	    var today = now.getFullYear() + "/"+month +"/"+ day+"";
	    return today;
	}
});
</script>
