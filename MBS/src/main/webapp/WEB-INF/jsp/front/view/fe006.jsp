<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ page import="nta.mss.misc.common.MssContextHolder"%>
<%@page import="nta.mss.model.HospitalTrackingModel"%>
<%@page import="java.util.List"%>
<%@page import="nta.med.common.util.Strings"%>
<%@page import="org.apache.commons.collections.CollectionUtils"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
 <c:url var="submitUrl" value="/booking/booking-accept" />
 <c:url var="bookingChangeUrl" value="/booking/booking-change-info?token=${token}" />
<form:form method="post" action="${submitUrl}" modelAttribute="patient" >
<div id="main-booking-name">
	<c:choose>
		<c:when test="${isDeletedBooking == true}">
			<spring:message code="fe006.label.thanks" arguments="${hospitalName}"/><br/>
			<spring:message code="general.msg.booking.failed"/>
		</c:when>
		<c:when test="${isAlreadyCompleted == true}">
			<spring:message code="fe006.label.thanks" arguments="${hospitalName}"/><br/>
			<spring:message code="general.msg.new.is_already_completed"/>
		</c:when>
		<c:when test="${isDoctorScheduleFull == true}">
			<spring:message code="fe006.label.thanks" arguments="${hospitalName}"/><br/>
			<spring:message code="general.msg.new.full_schedule"/>
		</c:when>
		<c:when test="${isNotSuccess == true}">
			<spring:message code="fe006.label.thanks" arguments="${hospitalName}"/><br/>
			<spring:message code="general.msg.new.not.success"/>
		</c:when>
		<c:when test="${successBookingVaccine==false}">
		<spring:message code="fe006.label.thanks.not.complete" arguments="${hospitalName}"/><br/>
		</c:when>
		<c:otherwise>
			<h class="lead">
				<spring:message code="fe006.label.thanks" arguments="${hospitalName}"/><br/>
				<spring:message code="fe006.label.thanks.complete" arguments="${hospitalName}"/>
			</h>
			<br/>
			<%-- <br/>
			<div class="row">
				<label class="col-xs-4 col-md-4 control-label">
					<spring:message code="fe005.label.booking.number" />
				</label>
				<div class="col-xs-8 col-md-8">
					${reservationCode}
				</div>
			</div>
			<br/> --%>
			<div class="row">
				<label class="col-xs-4 col-md-4 control-label">
					<spring:message code="fe005.label.patient.code" />
				</label>
				<div class="col-xs-8 col-md-8">
					${patientCode}
				</div>
			</div>
			<br/>
			<div class="row">
				<label class="col-xs-4 col-md-4 control-label">
					<spring:message code="fe003.label.department" /> 
				</label>
				<div class="col-xs-8 col-md-8">
					${deptName}
				</div>
			</div>
			<br/>
			<div class="row">
				<label class="col-xs-4 col-md-4 control-label">
					<spring:message code="fe005.label.reservation.time" /> 
				</label>
				<div class="col-xs-8 col-md-8">
					${bookingTime}
				</div>
			</div>
			<c:if test="${childName != null}">
			<br/>
				<div class="row">
					<label class="col-xs-4 col-md-3 control-label">
						<spring:message code="fe003.label.child.name" />
					</label>
					<div class="col-xs-8 col-md-8">
						<p class="form-control-static">
							${childName}
						</p>
					</div>
				</div>
			</c:if>
			<c:if test="${bookingVaccine}">
			<br/>
				<div class="row">
<!-- 					<label class="col-xs-4 col-md-3 control-label"> -->
<%-- 						<spring:message code="fe003.label.detail.bookingVaccine" /> --%>
<!-- 					</label> -->
					<div class="col-sm-12">
							<table id="dataTable" class="table table-bordered">
								<thead>
									<tr>
										<th width="" style="text-align: center;"><spring:message code="fe003.label.child.name" /></th>
										<th width="" style="text-align: center;"><spring:message code="fe003.label.child.dob" /></th>
										<th width="" style="text-align: center;"><spring:message code="general.label.sex" /></th>
										<th width="" style="text-align: center;"><spring:message code="fe003.label.vaccine" /></th>
										<th width="" style="text-align: center;"><spring:message code="fe003.label.dateTimeUsing" /></th>
									</tr>
								</thead>
								<tbody>
									<tr>
										<td style="text-align: center;">${userChildModel.childName}</td>
										<td style="text-align: center;">${userChildModel.dob}</td>
										<td style="text-align: center;">
											<c:choose>
												<c:when test="${userChildModel.sex == '1'}">
													<spring:message code="general.label.sex.male" />
												</c:when>
												<c:otherwise>
													<spring:message code="general.label.sex.female" />
												</c:otherwise>
											</c:choose>
											
										</td>
										<td style="text-align: center;">${vaccineModel.vaccineName}</td>
										<td style="text-align: center;">${injectedNo}</td>
									</tr>
								</tbody>
							</table>
					</div>
				</div>
			</c:if>
			<br/>
			<div class="row">
				<label class="col-xs-4 col-md-4 control-label">
					<spring:message code="fe003.label.time.reminder" /> 
				</label>
				<div class="col-xs-8 col-md-8 btn-group">
					<spring:message code="${reminderTime}"/>
				</div>
			</div>
			<br/>
			<div class="row">
				<div class="col-xs-12 col-md-12">
					<spring:message code="fe006.label.note" arguments="${deptName},${hospitalName}"/>
				</div>
			</div>
			<br/>
			<div class="row">
				<div class="col-xs-12 col-md-12">
					<spring:message code="fe006.label.link.change.booking" arguments="${bookingChangeUrl}"/>
				</div>	
			</div>
		</c:otherwise>
	</c:choose>
</div>


</form:form>

<script type="text/javascript" src="<c:url value='/assets/js/booking/RemoveFirstStepBooking.js'/>">
</script>
<%
	List<HospitalTrackingModel> lst = MssContextHolder.getTrackingScript();

	if(CollectionUtils.isNotEmpty(lst))
	{
		String trackingCode = "" ;
		for (int i = 0; i < lst.size(); i++) {
			String pageCode= lst.get(i).getPage_code();
			if(pageCode.equals("fe009"))
			{
				trackingCode = trackingCode + lst.get(i).getTracking_scripts();
			}
		}
		if(!Strings.isEmpty(trackingCode))
			out.println(trackingCode);
	}
%>