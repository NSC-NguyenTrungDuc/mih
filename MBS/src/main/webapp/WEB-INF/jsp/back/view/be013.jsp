<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>

<c:url var="confirmUrl" value="/schedule/upload-doctor-csv" />

<div id="csv-doctor-adding" class="form-horizontal">
	<form:form class="form-horizontal" action="${confirmUrl}" method="POST" enctype="multipart/form-data" modelAttribute="uploadedFile">
		<form:errors cssClass="alert-danger"></form:errors>
		<div class="alert-success">
			<div class="col-sm-8">${successMsg}</div>
		</div>
		<div class="alert-danger">
			<div class="col-sm-8">${errorMsg}</div>
		</div>
		<div class="form-group">
			<div class="col-sm-8"><spring:message code="be013.label.department.doctor" /></div>
		</div>
		<div class="form-group">
			<label for="file" class="col-sm-4 control-label"><spring:message code="be013.label.csv.upload" /></label>
			<div class="col-sm-5">
			<label for="be013"> <span class="btn" style="border-color: black; background-color: buttonhighlight; position: absolute; width: 93px;"><spring:message code="be040.choose.file"/></span></label> 
						<input type="file" name="file" id="be013" style="top: 0px;"  />
			</div>
		</div>
		<div class="form-group">
			<div class="col-sm-8" align="center">
			<input type="submit" id="btnUpload" class="btn btn-success btn-sm" value="<spring:message code="general.button.upload"/>" /> 
			</div>
		</div>
	</form:form>
</div>