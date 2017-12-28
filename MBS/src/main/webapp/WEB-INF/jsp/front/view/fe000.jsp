<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@page import="nta.mss.model.HospitalTrackingModel"%>
<%@page import="java.util.List"%>
<%@page import="nta.med.common.util.Strings"%>
<%@page import="org.apache.commons.collections.CollectionUtils"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/security/tags" prefix="sec" %>
<script>
	var fe000_table_record_each_page = '<spring:message code="table.record.each.page" />'
	var fe000_table_previous = '<spring:message code="table.previous" />'
	var fe000_table_next = '<spring:message code="table.next" />'
	var fe000_table_last = '<spring:message code="table.last" />'
	var fe000_table_empty = '<spring:message code="table.empty" />'
	var fe000_table_info_empty = '<spring:message code="table.info.empty" />'
	var fe000_table_info_total = '<spring:message code="table.info.total" />'
	var fe000_table_info_start = '<spring:message code="table.info.start" />'
	var fe000_table_info_end = '<spring:message code="table.info.end" />'
	var fe000_s_info = '<spring:message code="table.s.info" />'
</script>
<c:url value="/booking/booking-new" var="bookingNewUrl" />
<c:url value="/booking/re-examination" var="reexamUrl" />
<c:url value="/booking/authorized-email" var="authorizedUrl" />
<c:url value="/booking/pending-status" var="pendingStatusUrl" />
<c:url value="/booking/register" var="registerUrl" />
<c:url value="/booking/login" var="loginUrl" />
<c:url value="/booking/profile-management" var="profileUrl" />
<c:url value="/booking/vaccine?id=" var="vaccineInfoUrl" />

<c:url value="/booking/online-booking-new" var="bookingNewUrlOnline" />
<c:url value="/booking/online-re-examination" var="reexamUrlOnline" />
<c:url value="/booking/authorized-email" var="bookingNewUrlChange" />
<c:url value="/movie-talk/index" var="doctorCall" />
<div class="tabs_container">
	<div class="tabs_title">
				<div id = "normal-service-title" class="tabs-one-booking-index" style="cursor: pointer"><spring:message code="fe000.title" /></div>
			<c:if test="${isMovieTalk}">
					<div id = "normal-service-title-online" class="tabs-two-booking-index" style="cursor: pointer"><spring:message code="fe000.title.online" /></div>
			</c:if>
	</div>
	<div class="tabs_content">
		<div class="text-content" id = "normal-service-text">
			<h3><spring:message code="fe000.label.thanks" /></h3>
			<p><spring:message code="fe000.label.booking_new" arguments="${bookingNewUrl}" /></p>
			<p><spring:message code="fe000.label.reexamination" arguments="${reexamUrl}" /></p>
			<p><spring:message code="fe000.label.booking_change" arguments="${authorizedUrl}" /></p>
			<p><spring:message code="fe000.label.booking_pending_status" arguments="${pendingStatusUrl}" /></p>
		</div>
		<c:if test="${isMovieTalk}">
				<div class="text-content" id = "normal-service-online-text">
					<c:if test="${userLogin}">
						<h3><spring:message code="fe000.label.thanks.online" /></h3>
						<p><spring:message code="fe000.label.booking_new.online" arguments="${bookingNewUrlOnline}" /></p>
						<p><spring:message code="fe000.label.reexamination.online" arguments="${reexamUrlOnline}" /></p>
						<p><spring:message code="fe000.label.booking_change.online" arguments="${bookingNewUrlChange}" /></p>
						<p><spring:message code="fe000.label.doctorcall.online" arguments="${doctorCall}" /></p>
					</c:if>
					<c:if test = "${!userLogin}">
						<p><spring:message code="fe000.label.warning.online" arguments="${registerUrl},${loginUrl}" /></p>
					</c:if>
				</div>
		</c:if>
	</div> <!-- End .tabs_content -->
</div> <!-- End .tabs_container -->
<div class="tabs_container">
	<div class="tabs_title">
		<div class="tabs-one"><spring:message code="fe000.label.vaccine_newborn" /></div>
	</div>
	<div class="tabs_content">
		<sec:authorize ifAnyGranted="ROLE_FRONT_END">
		<c:choose>
			<c:when test="${userChildList.size() > 0}">
				<c:url var="newbornUrl" value="/booking/booking-time?deptId=${newbornDeptId}" />
				<c:url var="vaccineBookingUrl" value="/booking/booking-vaccine-select-time?deptId=${vaccineDeptId}&" />
				<c:url var="bookingChangeUrl" value="/booking/booking-change-info?resId=" />
				<c:url var="bookingTimeUrl" value="/booking/booking-time?deptId=" />
				<script>
					var deptId = '${deptId}';
					if (deptId != '') {
						location.href= '${bookingTimeUrl}' + deptId;
					}
				</script>
				<div class="row">
					<label class="col-sm-3 control-label"><spring:message code="fe00302.label.choose.child"/></label>
					<div class="col-sm-5">
						<select id="slt-child" class="form-control" name="mailTmp">
							<c:forEach  var="child" items="${userChildList}">
								<option value="${child.childId}">${child.childName}</option>
							</c:forEach>
						</select>
					</div>
				</div>
				<div>
				  	<span id="child-name"></span> - <span id="gender"></span>(<span id="birthday"></span>)
				</div>
				<br/>
				<table id="vaccine-schedule-table" class="vaccine-table table table-bordered display">
					<thead>
							<tr style="background-color: #27ae61;color: white;font-weight: bold;">
								<th><spring:message code="general.vaccine.table.vaccine"/></th>
								<th><spring:message code="general.vaccine.table.limit.inject.age"/></th>
								<th><spring:message code="general.vaccine.table.support.fee.age"/></th>
								<th><spring:message code="general.vaccine.table.advice.age"/></th>
								<th><spring:message code="general.vaccine.table.injected.no"/></th>
								<th><spring:message code="general.vaccine.table.start.booking.date"/></th>
								<th><spring:message code="general.vaccine.table.note"/></th>
								<th><spring:message code="general.vaccine.table.action"/></th>
							</tr>
						</thead>
					<tbody id="vaccine-schedule-body">
					</tbody>
				</table>
				<script id="vaccine-schedule-list" type="text/x-handlebars-template">
					{{#each vaccineScheduleList}}
						<tr>
							<td><a href="${vaccineInfoUrl}{{vaccineId}}">{{vaccineName}}</a><i class="fa fa-circle" style="color:#{{color}}"></i></td>
							<td>{{formattedLimitAge}}</td>
							<td>
								{{#each formattedSupportFeeDate}}
								<div>{{this}}</div>
								{{/each}}
							</td>
							<td>
								{{#each formattedRecommendAge}}
								<div>{{this}}</div>
								{{/each}}
							</td>
							<td>{{injectedNo}} <spring:message code="general.vaccine.label.inject.unit" /></td>
							<td>{{formattedDateCanBooking}}</td>
							<td>
								{{#compare status '==' 0}}{{warningDaysText}}{{/compare}}
								{{#compare status '==' 1}}<spring:message code="general.vaccine.label.note.booked" />{{/compare}}
								{{#compare status '==' 2}}<spring:message code="general.vaccine.label.note.booked" />{{/compare}}
								{{#compare status '==' 3}}<spring:message code="general.vaccine.label.note.completed" />{{/compare}}
							</td>
							<td>
								{{#compare status '==' 1}}
									<a class="btn btn-sm btn-danger btn-70" href="${bookingChangeUrl}{{reservationId}}" ><spring:message code="general.vaccine.label.button.cancel" /></a>
								{{/compare}}
								{{#compare status '==' 0}}
									<a class="btn btn-sm btn-primary btn-70" href="${vaccineBookingUrl}vaccineId={{vaccineId}}&childId={{childId}}&timesUsing={{injectedNo}}&date={{dateCanBookingStr}}" ><spring:message code="general.vaccine.label.button.book" /></a>
								{{/compare}}
							</td>
						</tr>
					{{/each}}
				</script>
				<script type="text/javascript" src="<c:url value='/assets/js/user/VaccineSchedule.js' />"></script>
			</c:when>
			<c:otherwise>
				<spring:message code="fe000.label.profile.register_child" arguments="${profileUrl}"/>
				<table id="vaccine-info-table" class="vaccine-table table table-bordered display">
						<thead>
							<tr style="background-color: #27ae61;color: white;font-weight: bold;">
								<th><spring:message code="general.vaccine.table.vaccine"/></th>
								<th><spring:message code="general.vaccine.table.limit.inject.age"/></th>
								<th><spring:message code="general.vaccine.table.advice.age"/></th>
							</tr>
						</thead>
						<tbody id="vaccine-info-body">
							<c:forEach items="${vaccineInfoList}" var="vaccineInfo">
							<tr>
								<td><a href="${vaccineInfoUrl}${vaccineInfo.vaccineId}">${vaccineInfo.vaccineName}</a><i class="fa fa-circle" style="color:#${vaccineInfo.color}"></i></td>
								<td>${vaccineInfo.formattedLimitAge}</td>
								<td>
									<c:forEach items="${vaccineInfo.formattedRecommendAge}" var="recommendAge">
									<div>${recommendAge}</div>
									</c:forEach>
								</td>
							</tr>
							</c:forEach>
						</tbody>
					</table>
				<script type="text/javascript" src="<c:url value='/assets/js/user/VaccineInfo.js' />"></script>
			</c:otherwise>
		</c:choose>
		</sec:authorize>

		<sec:authorize ifNotGranted="ROLE_FRONT_END">
			<div class="text-content">
				<p><spring:message code="fe000.label.register_or_login" arguments="${registerUrl}, ${loginUrl}"/></p>
			</div>
		</sec:authorize>
<script>
	var isMovieTalk = '${isMovieTalk}';
  $(document).ready(function(){
		if(isMovieTalk)
		{
			$('#normal-service-online-text').hide();
			$('#normal-service-title').click(function(){
				 if ($('#normal-service-title').hasClass('tabs-two-booking-index'))
				   {
					 	$('#normal-service-title').removeClass('tabs-two-booking-index');
						$('#normal-service-title').addClass('tabs-one-booking-index');
						$('#normal-service-title-online').removeClass('tabs-one-booking-index');
						$('#normal-service-title-online').addClass('tabs-two-booking-index');
						$('#normal-service-online-text').hide();
						$('#normal-service-text').show();
					 }
			});
			$('#normal-service-title-online').click(function(){
				 if ($('#normal-service-title-online').hasClass('tabs-two-booking-index'))
				   {
					 	$('#normal-service-title-online').removeClass('tabs-two-booking-index');
						$('#normal-service-title-online').addClass('tabs-one-booking-index');
						$('#normal-service-title').removeClass('tabs-one-booking-index');
						$('#normal-service-title').addClass('tabs-two-booking-index');
						$('#normal-service-online-text').show();
						$('#normal-service-text').hide();
					 }
			});
		}
	});
</script>
				<%
	if(request.getParameter("register_account_facebook") != null &&
			request.getParameter("register_account_facebook").equals("true" ))
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
