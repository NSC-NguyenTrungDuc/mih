<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>

<c:url var="importCSV" value="mail-import-csv"/>
<div id="upload-file" class="col-md-12"> 
	<form:form class="form-horizontal" action="${importCSV}" method="POST" enctype="multipart/form-data" modelAttribute="uploadedFile">
		<form:errors cssClass="alert-danger"></form:errors>
		<div class="row">
			<div class="form-group">
				<div class="col-sm-8" style="color: red;">
					${successMsg}
				</div>
			</div>
		</div>
		<div class="row">
				<div class="form-group">
					<div class="col-sm-2 control-label">
						<label for="file" ><spring:message code="be040.label.csv.upload" /></label>
					</div>
					<div class="col-sm-6">
						<input class="form-control" type="file" name="file" id="be013" style="top: 0px;"/>
					</div>
				</div>
		</div>
		<div class="row">
			<div class="form-group">
				<div class="col-sm-6" align="center">
					<input type="submit" id="btnUpload" class="btn btn-primary btn-change" value="<spring:message code="general.button.upload"/>" />
				</div>
			</div>
		</div>
	</form:form>
</div>