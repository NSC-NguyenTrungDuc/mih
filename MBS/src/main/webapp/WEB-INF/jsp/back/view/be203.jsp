<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<script type="text/javascript" src="<c:url value='/assets/js/Constants.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/lib/culture-info.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/lib/date.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/Util.js' />"></script>

<div id="undisplayedLabel" style="display:none"><spring:message code="be203.setting.vaccine.undisplay" /></div>
<div id="displayedLabel" style="display:none"><spring:message code="be203.setting.vaccine.display" /></div>
<div id="sortLabel" style="display:none"><spring:message code="be203.setting.sort" /></div>
<div id="topLabel" style="display:none"><spring:message code="be203.setting.top" /></div>
<div id="upLabel" style="display:none"><spring:message code="be203.setting.up" /></div>
<div id="downLabel" style="display:none"><spring:message code="be203.setting.down" /></div>
<div id="bottomLabel" style="display:none"><spring:message code="be203.setting.bottom" /></div>
<div id="dateLabel" style="display:none"><spring:message code="be203.table.label.date" /></div>
<div id="dayLabel" style="display:none"><spring:message code="general.table.header.day" /></div>
<%-- MED-8228 --%>
<%--<div id="bookingLabel" style="display:none"><spring:message code="be203.table.label.booking" /></div> --%>
<div id="searchUrl" style="display:none">${searchUrl}</div>

<c:url var='searchUrl' value='/booking-manage/search-booking?date=' />
<c:url var='exportCsvUrl' value = '/vaccine/export-vaccine-report-csv' />
<div id="deptId" style="display:none">${deptId}</div>

<form:form class="form-horizontal" role="form" method="POST" commandName="searchBooking"  >
	<div class="form-group">
		<div class="col-sm-2">
	    	<input class="form-control" id="fromDate" />
    	</div>
    	<label class="col-sm-1 control-label" style="text-align:center">～</label>
    	<div class="col-sm-2">
			<input class="form-control" id="toDate" />
		</div>
		<div class="col-sm-7">
			<input id="generateBtn" type="button" class="btn btn-primary btn-120" value="<spring:message code="be203.label.btn.generate" />">
			<input id="settingBtn" type="button" class="btn btn-primary btn-120" value="<spring:message code="be203.label.btn.setting" />">
			<a id="exportBtn" class="btn btn-primary btn-120" href="${exportCsvUrl}" ><spring:message code="be203.label.btn.export" /></a>
		</div>
	</div>
	
</form:form>
<div class="modal fade" id="setting-vaccine">
	<div class="modal-dialog modal-md">
		<div class="modal-content">
			<div class="modal-body">
				<button type="button" class="close" data-dismiss="modal">
					<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message code="fe022.modal.close" /></span>
				</button>  	
		      	<h4 class="modal-title"><spring:message code="be203.setting.title"/></h4>
				<form:select class="form-control" path="vaccineList" name="cbo-setting[]" id='cbo-setting' multiple='true'>
					<c:forEach items="${vaccineList}" var="vaccineList">
			            <option selected="selected" value="${vaccineList.vaccineId}">${vaccineList.vaccineName} </option>
			        </c:forEach>
				</form:select>
			</div>
			<div class="modal-footer">
				<button id="saveBtn" type="button" value="" class="btn btn-success btn-90">
					<spring:message code="general.button.save" />
				</button>
				<button type="button" class="btn btn-default btn-90" data-dismiss="modal">
					<spring:message code="general.button.cancel" />
				</button>
			</div>
		</div>
	</div>
</div>
<div id="vaccine-report-list">
	<table class='table table-bordered display' id='tblVaccineReport'>
	</table>
</div>

<script>
	var md_table_record_each_page = '<spring:message code="table.record.each.page" />'
	var md_table_previous = '<spring:message code="table.previous" />'
	var md_table_next = '<spring:message code="table.next" />'
	var md_table_last = '<spring:message code="table.last" />'
	var md_table_empty = '<spring:message code="table.empty" />'
	var md_table_info_empty = '<spring:message code="table.info.empty" />'
	var md_table_info_total = '<spring:message code="table.info.total" />'
	var md_table_info_start = '<spring:message code="table.info.start" />'
	var md_table_info_end = '<spring:message code="table.info.end" />'
	var md_s_info = '<spring:message code="table.s.info" />'
</script>

<script type="text/javascript" src="<c:url value='/assets/js/vaccine/VaccineReport.js' />"></script>