<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

<form:form class="form-horizontal" role="form" method="POST" commandName="crmModel">
	<form:input type="hidden" path="pageSize" class="form-control" value="${crmModel.pageSize}"/>
	<form:input type="hidden" path="pageIndex" class="form-control" value="${crmModel.pageIndex}"/>
	<form:input type="hidden" path="orderField" class="form-control" value="${crmModel.orderField}"/>
	<form:input type="hidden" path="orderValue" class="form-control" value="${crmModel.orderValue}"/>
	<form:input type="hidden" path="totalRecords" class="form-control" value="${crmModel.totalRecords}"/>
	<form:errors cssClass="alert-danger"></form:errors>
	<div id="validation" style="display:none">${validation}</div>
	
	<div class="form-group">
	<spring:message code="be204.place.holder.disease.name" var="labelDiseaseName" />
		<label for="diseaseName" class="col-sm-2 control-label"><spring:message code="be204.disease.name" /></label>
		<div class="col-sm-5">
			<form:input class="form-control" path="diseaseName" placeholder="${labelDiseaseName}" autocomplete="off" maxlength="128"/>
			<form:errors path="diseaseName" cssClass="error" cssStyle="color:red" />
		</div>
	</div>
	<div class="form-group">
		<label for="statusOfDisease" class="col-sm-2 control-label"><spring:message code="be204.status.of.disease" /></label>
		<div class="col-sm-5">
			<form:select class="form-control" path="statusOfDisease">
				<form:option value=""><spring:message code="be204.status.of.disease.all" /></form:option>
    			<form:options items="${listStatusOfDisease}"/>
			</form:select>
			<%-- <span id="deptTemp" style="display: none;">${scheduleMailHistory.department}</span> --%>
		</div>
	</div>
	<div class="form-group">
		<label for="fromLabelGoHospital" class="col-sm-2 control-label"><spring:message code="be204.from.lastest.go.hospital" /></label>
		<div class="col-sm-3">
			<form:input class="form-control" path="fromLastestGoHospital" />
			<form:errors path="fromLastestGoHospital" cssClass="error" cssStyle="color:red" />
			<%-- <span id="dateTemp" style="display: none;">${scheduleMailHistory.date}</span> --%>
		</div>
		<label for="toLabelGoHospital" class="col-sm-2 control-label" style="text-align:center;"><spring:message code="be204.to.lastest.go.hospital" /></label>
		<div class="col-sm-3">
			<form:input class="form-control" path="toLastestGoHospital"/>
			<form:errors path="toLastestGoHospital" cssClass="error" cssStyle="color:red" />
			<%-- <span id="dateTemp" style="display: none;">${scheduleMailHistory.date}</span> --%>
		</div>
	</div>
	<div class="form-group">
	<spring:message code="be204.place.holder.from.age" var="fromAge" />
	<spring:message code="be204.place.holder.to.age" var="toAge" />
		<label for="fromLabelAge" class="col-sm-2 control-label"><spring:message code="be204.from.age" /></label>
		<div class="col-sm-3">
			<form:input class="form-control" path="fromPatientAge" placeholder="${fromAge}"  autocomplete="off" maxlength="3" type="number" />
			<form:errors path="fromPatientAge" cssClass="error" cssStyle="color:red" />
			<%-- <span id="dateTemp" style="display: none;">${scheduleMailHistory.date}</span> --%>
		</div>
		<label for="toLabelAge" class="col-sm-2 control-label" style="text-align:center;"><spring:message code="be204.to.age" /></label>
		<div class="col-sm-3">
			<form:input class="form-control" path="toPatientAge" placeholder="${toAge}" autocomplete="off" maxlength="3" type="number"/>
			<form:errors path="toPatientAge" cssClass="error" cssStyle="color:red" />
			<%-- <span id="dateTemp" style="display: none;">${scheduleMailHistory.date}</span> --%>
		</div>
	</div>
	<div class="form-group">
		<label class="col-sm-2 control-label"><spring:message code="be204.gender"/>
		</label>
		<div class="col-sm-5">
           	<form:radiobutton path="patientSex" value="M"/> <spring:message code="general.label.male" /> &nbsp;&nbsp;&nbsp;
           	<form:radiobutton path="patientSex" value="F"/> <spring:message code="general.label.female" /> &nbsp;&nbsp;&nbsp;
           	<form:radiobutton path="patientSex" value=""/> <spring:message code="general.select.all" />
         </div>
	</div>
	<div class="form-group">
		<label class="col-sm-2 control-label"><spring:message code="be204.patient.contact"/>
		</label>
		<div class="col-sm-5">
           	<form:checkbox path="patientContact" value="P"/> <spring:message code="be204.patient.contact.phone" /> &nbsp;&nbsp;&nbsp;
           	<form:checkbox path="patientContact" value="E"/> <spring:message code="be204.label.form.email" />
         </div>
	</div>
	
	<!-- action -->
	<div class="form-group">
		<div class="col-sm-10" align="center">
				<input id="searchBtn" type="button" class="btn btn-primary pull-left btn-120" value="<spring:message code="be204.label.search.button" />">
		</div>
	</div>
</form:form>

<table id="tblCrmList" class="table table-bordered display">
	<thead>
		<tr style="background-color: #4f6070;color: white;font-weight: bold;">
			<th><input type="checkbox" value="" id="check-all" style="text-align: center;"></th>
			<th><spring:message code="be204.label.form.patientName" /></th>
			<th><spring:message code="be204.label.form.diseaseName" /></th>
			<th><spring:message code="be204.label.form.lastest.go.hospital" /></th>
			<th><spring:message code="be204.label.form.age" /></th>
			<th><spring:message code="be204.label.form.sex" /></th>
			<th><spring:message code="be204.label.form.tel" /></th>
			<th><spring:message code="be204.label.form.email" /></th>
		</tr>
	</thead>
	<tbody id="search-result-body">
	</tbody>
</table>
<br>
<div class="action-bar clearfix">
  <div class="pull-left">
    <div class="label_small"><spring:message code="be204.title.choose.temp.mail"/></div>
    <select id="slt-mail-template" class="form-control" name="mailTmp">
		<option value=""><spring:message code="be043.title.selectBox.temp.mail"/></option>
		<c:forEach  var="mailTmp" items="${mailTemplate}">
			<option value="${mailTmp.mailTemplateId}">${mailTmp.subject}</option>
		</c:forEach>
	</select>
	<label id="selectMailTemp" style="color: red;"></label>
  </div>
  <div class="pull-right">
    <button class="btn btn-primary pull-left btn-120" type = "button" id="btn-send-email"><spring:message code="be204.button.confirm.mail"/></button>
  </div>
</div>
              
              
<script id="search-result" type="text/x-handlebars-template">
	{{#each model}}
		<tr>
			<td class="chk-send-email" style="text-align: center;">
								<input value="" type="checkbox" checked="checked"/></td>
			<td class="patientName">{{patientName}}</td>
			<td class="diseaseName">{{diseaseName}}</td>
			<td class="lastestGoHospital">{{lastestGoHospital}}</td>
			<td class="patientAge">{{patientAge}}</td>
			<td class="patientSex">{{patientSex}}</td>
			<td class="patientEmail">{{patientEmail}}</td>
		</tr>
    {{/each}}



</script>
<script>

	var be405_table_record_each_page = '<spring:message code="table.record.each.page" />'
	var be405_table_previous = '<spring:message code="table.previous" />'
	var be405_table_next = '<spring:message code="table.next" />'
	var be405_table_last = '<spring:message code="table.last" />'
	var be405_table_empty = '<spring:message code="table.empty" />'
	var be405_table_info_empty = '<spring:message code="table.info.empty" />'
	var be405_table_info_total = '<spring:message code="table.info.total" />'
	var be405_table_info_start = '<spring:message code="table.info.start" />'
	var be405_table_info_end = '<spring:message code="table.info.end" />'
	var be405_s_info = '<spring:message code="table.s.info" />'
</script>
<script>
	var be043_email_template_required = '<spring:message code="be043.email.template.required" />'
</script>
<script type="text/javascript" src="<c:url value='/assets/js/crm-manage/CrmManagement.js' />"></script>