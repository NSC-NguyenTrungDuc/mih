<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<c:url var="submitURL" value="schedule-delete-coma-submit" />
<c:url var="backURL" value="schedule-delete-coma-info?deptId=${deptId}" />
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
								<div><spring:message code="be022.label.doctor" /> ${doctorScheduleList.value[0].doctorName}</div>
								<input type="hidden" class="doctorId" value="${doctorScheduleList.value[0].doctorId}"/>
								<div>${doctorScheduleList.value[0].formattedReservationTime}</div>
								<input type="hidden" class="startTime" value="${doctorScheduleList.value[0].reservationTime}"/>
							</td>
							<td style="vertical-align:middle;">
								<c:if test="${headerLabelExist eq true}"><spring:message code="be023.label.choose_doctor"/></c:if>
							</td>
							<td style="vertical-align:middle;">
								<c:if test="${headerLabelExist eq true}"><spring:message code="be023.label.send_email"/></c:if>
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
									<select class="form-control" disabled>
										<option>${deletingComa.get(reservationList.reservationId).doctorName}</option>
									</select>
								</td>
								<td class="chk-send-email" width="12%" style="text-align:center;">
									<input data-id="${reservationList.reservationId}" type="checkbox" <c:if test="${deletingComa.get(reservationList.reservationId).isSentEmail}">checked</c:if> disabled/>
								</td>
							</tr>
						</c:forEach>
					</tbody>
				</table>
			</c:if>
		</c:forEach>
	</div>

    <label class="col-sm-12 control-label"><spring:message code="be023.label.email_template"/></label>
    <div class="col-sm-6">
	    <p>
		    <select class="form-control" disabled>
				<option>${mailTemplate.subject}</option>
			</select>
		</p>
    </div>

    <div class="col-sm-12">
	    <p class="form-control-static">
		    <a class="btn btn-primary" href="${submitURL}"><spring:message code='be023.button.send'/></a>
			<a class="btn btn-primary" href="${backURL}"><spring:message code="be023.button.cancel"/></a>
		</p>
    </div>
</div><!-- End .row -->
