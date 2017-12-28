<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

<div class="row">
	<div class="col-sm-12">
		<p class="lead">
			<span class="hospital-content">${hospitalName}&nbsp;${deptName}</span>
		</p>
	</div>			
	<div class="col-sm-12">
		<c:set var="headerLabelExist" value="true"/>
		<c:forEach var="doctorScheduleList" items="${doctorSchedule}" varStatus="status">
			<c:if test="${not empty doctorScheduleList.value[0]}">
				<table class="table table-hover">
					<thead>
						<tr>
							<td colspan="3">
								<div>${doctorScheduleList.value[0].formattedReservationDate}</div>
								<input type="hidden" class="checkDate" value="${doctorScheduleList.value[0].reservationDate}"/>		
								<spring:message code="be022.label.doctor" /><div class="doctorName">${doctorScheduleList.value[0].doctorName}</div>
								<input type="hidden" class="doctorId" value="${doctorScheduleList.value[0].doctorId}"/>
								<div>${doctorScheduleList.value[0].formattedReservationTime}</div>
								<input type="hidden" class="startTime" value="${doctorScheduleList.value[0].reservationTime}"/>
							</td>
							<td style="vertical-align:middle;">
								<c:if test="${headerLabelExist eq true}"><spring:message code="be026.label.choose_doctor"/></c:if>
							</td>
							<td style="vertical-align:middle;">
								<c:if test="${headerLabelExist eq true}"><spring:message code="be026.label.send_email"/></c:if>
							</td>
							<c:set var="headerLabelExist" value="false"/>
						</tr>
					</thead>
					<tbody>
						<c:forEach var="reservationList" items="${doctorScheduleList.value}">
							<tr>
								<td width="18%">${reservationList.patientName}</td>
								<td width="30%">${reservationList.email}</td>
								<td width="18%">${reservationList.phoneNumber}</td>
								<td width="22%">
									<select id="slt-doctor" class="form-control">
										<option value="${doctorScheduleList.value[0].doctorId}">${doctorScheduleList.value[0].doctorName}</option>
									</select>
								</td>
								<td class="chk-send-email" width="12%" style="text-align:center;">
								<input data-id="${reservationList.reservationId}" type="checkbox"/>
								</td>
							</tr>
						</c:forEach>
					</tbody>
				</table>
			</c:if>
		</c:forEach>
	</div>
    <label class="col-sm-12 control-label"><spring:message code="be026.label.email_template"/></label>
    <div class="col-sm-6">
    	<p>
		    <form:select id="slt-mail-template" class="form-control" path="mailTemplateList">
				<form:options items="${mailTemplateList}" itemValue="mailTemplateId" itemLabel="subject"/>
			</form:select>
		</p>
    </div>
    <div class="col-sm-12">
		<p>
			<button type="button" class="btn btn-primary" id="btn-send-email"><spring:message code='be026.button.inform_patient'/></button>
		</p>
	</div>
</div><!-- End .row -->
    
<script type="text/javascript" src="<c:url value='/assets/js/schedule/ScheduleSendingSetting.js'/>" ></script>