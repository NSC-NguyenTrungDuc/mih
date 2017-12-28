<%@ page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<script type="text/javascript"
	src="<c:url value='/assets/js/Constants.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/lib/culture-info.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/lib/date.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/Util.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/EventDriven.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/UIComponent.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/BookingUtils.js' />"></script>

<script type="text/javascript"
	src="<c:url value='/assets/js/control/table/Table.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/control/table/Row.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/control/table/ColumnHeader.js' />"></script>

<script type="text/javascript"
	src="<c:url value='/assets/js/control/mss-calendar/CellData.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/control/mss-calendar/BinaryData.js' />"></script>

<script type="text/javascript"
	src="<c:url value='/assets/js/control/mss-calendar/BaseScheduler.js' />"></script>

<script type="text/javascript"
	src="<c:url value='/assets/js/control/mss-calendar/CalendarRow.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/control/mss-calendar/MssCalendar.js' />"></script>
<script>
	var currDD = '${currDD}';
	var currHH = '${currHH}';
	var currMM = '${currMM}';
	var curDate = '${curDate}';
	var isVaccine = '${isVaccine}';
</script>

<div id="dateTitle" style="display: none">
	<spring:message code="general.table.header.date" />
</div>
<div id="dayTitle" style="display: none">
	<spring:message code="general.table.header.day" />
</div>
<div class="text-content">
	<div class="row">
		<div class="col-xs-12 col-md-12 col-sm-12">
			<spring:message code="fe002.label.choose_booking_time" />
			<div class="row form-horizontal">
				<c:if test="${reexaminationMode}">
					<div class="col-xs-12 col-md-1">
						<p class="form-control-static">
							<spring:message code="fe002.label.doctor" />
						</p>
					</div>
					<div class="col-xs-12 col-md-4">
						<%-- <form:select id="booking-slt-doctor" class="form-control input-sm" path="doctorList" itemValue="${nearestDoctorId}">
							<form:options items="${doctorList}" itemValue="doctorId" itemLabel="name"/>
						</form:select> --%>
						<form:select id="booking-slt-doctor" class="form-control input-sm" path="doctorList">
							<c:forEach items="${doctorList}" var="doctor" varStatus="status">
								<c:choose>
									<c:when test="${doctor.doctorId eq nearestDoctorId}">
										<option value="${doctor.doctorId}" selected="true">${doctor.name}</option>
									</c:when>
									<c:otherwise>
										<option value="${doctor.doctorId}">${doctor.name}</option>
									</c:otherwise>
								</c:choose>
							</c:forEach>
						</form:select>
					</div>
				</c:if>
			</div>
			<p>${departmentName}
				:
				<spring:message code="fe002.label.booking_time_status" />
			</p>
		</div>
	</div>
	<div class="row"></div>
</div>

<div class="schedule-content" id="table">
	<div>
		<p>
			<button type="button" class="btn btn-primary" id="btn-current-week">
				<spring:message code="general.nav.button.current" />
			</button>
			<button type="button" class="btn btn-default" id="btn-previous-week">
				<spring:message code="general.nav.button.previous" />
			</button>
			<button type="button" class="btn btn-default" id="btn-next-week">
				<spring:message code="general.nav.button.next" />
			</button>
			<c:if test="${!isVaccine}">
				<button type="button" class="btn btn-primary speacial-button" id="btn-reception" data-toggle="modal" data-target="#pop-up-01">
				<i class="fa fa-bolt" aria-hidden="true"></i> すぐ予約
				</button>
			</c:if>
		</p>
	</div>
	<div id="pop-up-01" class="modal fade" role="dialog" aria-hidden="true" style="display: none;">
		  <div class="modal-dialog">

			<!-- Modal content-->
			<div class="modal-content ">
			  <div class="modal-header">
				<button type="button" class="close" data-dismiss="modal">×</button>
				<h4 class="modal-title"><spring:message code="fe002.lable.popup.waiting.selectdoctor" /></h4>
			  </div>
			  <div class="modal-body pop-up-01-body table-responsive">
				
				<table class="table table-hover table-bordered scroll" id="tableAjax">
					<thead id="tblHead">
		              <tr>
		                <th class="table-header"></th>
		                <th class="table-header"><spring:message code="be012.label.doctor.name" /></th>            
		                <th class="table-header"><spring:message code="fe002.lable.popup.waiting.patient" /></th> 
		                <th class="table-header"><spring:message code="fe002.lable.popup.waiting.time" /></th> 
		              </tr>
           		 	</thead>
				 </table>
			  </div>
			  <div class="modal-footer">
				<button type="button" class="btn btn-default" data-dismiss="modal"><spring:message code="fe022.modal.close" /></button> 
			  </div>
			</div>

		  </div>
		</div>
	<div id="booking-time" class="booking-time-s"></div>
</div>
<div id="no-table" style="display: none;">
	<span class="lead" style="font-weight: bold;"><spring:message
			code="fe002.no.schedule" /></span>
</div>
<div id="time-slot-list" class="dropdown" style="position: absolute">
	<button class="btn btn-primary dropdown-toggle" style="display: none" type="button" data-toggle="dropdown">Dropdown Example
		<span class="caret"></span></button>
	<ul id="mn-time-slot-list" class="dropdown-menu">
	</ul>
</div>

<script type="text/javascript">
	$(document).ready(function(){
		
		if(!(isVaccine === "true" || isVaccine === true)){
			var btnTitleAutoRecept = '<spring:message code="fe002.special.button.auto.recept" />';
			var btnTitleFaster = '<spring:message code="fe002.special.button.faster" />';
			var autoRecept = '<%=MssContextHolder.getAutoRecept()%>';
			var bookingMode = '<%=MssContextHolder.getReservationMode()%>';
			if(autoRecept == "1" && ( bookingMode == "3" || bookingMode == "4"))
				{
				$('.speacial-button').text(btnTitleAutoRecept);
				$('.speacial-button').css('background','#2783ae');
				$('.speacial-button').css('border-color','#2783ae');
				}
			else
				{
				$('.speacial-button').text(btnTitleFaster);
				$('.speacial-button').css('background','#27ae61');
				$('.speacial-button').css('border-color','#27ae61');
				}
			$('#pop-up-01').on('shown.bs.modal', function() {			
				var count = $("#tableAjax").dataTable().fnGetData().length;
				$("#tblHead tr").children().first().removeClass('sorting_asc');
				if(parseInt(count) <= 8)
					$('#tableAjax_paginate').hide();
			})
		}
	});
	function multiLanguage()
	{
		 var language = {
				    "emptyTable":    '<spring:message code="general.not.data.found" />',
				    "info":           '<spring:message code="general.info.info" />',
				    "infoEmpty":      '<spring:message code="general.info.infoEmpty" />',
				    "infoFiltered":   "(filtered from _MAX_ total entries)",
				    "error"		  :   '<spring:message code="general.error.system" />',
				    "infoPostFix":    "",
				    "thousands":      ",",
				    "lengthMenu":     '<spring:message code="general.info.sLengthMenu" />',
				    "loadingRecords": "Loading...",
				    "processing":     "Processing...",
				    "search":         "Search:",
				    "zeroRecords":    "No matching records found",
				    "paginate": {
				        "first":      '<spring:message code="general.nav.button.first" />',
				        "last":       '<spring:message code="general.nav.button.last" />',
				        "next":       '<spring:message code="general.nav.button.next" />',
				        "previous":   '<spring:message code="general.nav.button.previous" />'
				    },
				    "aria": {
				        "sortAscending":  ": activate to sort column ascending",
				        "sortDescending": ": activate to sort column descending"
				    },
				    "minute" : '<spring:message code="fe003.label.before.reminder" />',
				    "currMM":currMM,
				    "currHH":currHH,
				    "currDD":currDD
				}
		 return language;
	}
	
</script>
<script type="text/javascript"
	src="<c:url value='/assets/js/booking/BookingTimeSelect.js' />"></script>
	


