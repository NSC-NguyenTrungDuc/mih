<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<c:url var="confirmUrl" value="/booking/booking-change" />
<!-- Change URL after cancelling -->
<c:url var="cancelUrl" value="/booking/booking-cancel" />
<form:form method="post" action="${cancelUrl}" class="form-horizontal">
<div id="booking-change-wrapper">
	<div id="booking-change-info">
		<div class="col-xs-12">
			<h3><spring:message code="fe022.message.header" /></h3>
		</div>
		<c:choose>
			<c:when test="${isNotAvailable != true}">
				<div class="form-group">
					<label class="col-xs-12 col-sm-3 control-label"> <spring:message code="fe022.label.name" />
					</label>
					<div class="col-xs-12 col-sm-9">
						<p class="form-control-static">${reservation.patientName}</p>
					</div>
				</div>
				<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
				<div class="form-group">
					<label class="col-xs-12 col-sm-3 control-label"> <spring:message code="fe022.label.furigana" />
					</label>
					<div class="col-xs-12 col-sm-9">
						<p class="form-control-static">${reservation.nameFurigana}</p>
					</div>
				</div>
				<%} %>
				<div class="form-group">
					<label class="col-xs-12 col-sm-3 control-label"> <spring:message code="fe022.label.phone" />
					</label>
					<div class="col-xs-12 col-sm-9">
						<p class="form-control-static">${reservation.phoneNumber}</p>
					</div>
				</div>
				<%-- <div class="form-group">
					<label class="col-xs-12 col-sm-3 control-label"> <spring:message code="fe022.label.booking.number" />
					</label>
					<div class="col-xs-12 col-sm-9">
						<p class="form-control-static">${reservation.reservationCode}</p>
					</div>
				</div> --%>
				<div class="form-group">
					<label class="col-xs-12 col-sm-3 control-label"> <spring:message code="general.label.sex" />
					</label>
					<div class="col-xs-12 col-sm-9">
						<p class="form-control-static">${patient.genderText}</p>
					</div>
				</div>
					<div class="form-group">
					<label class="col-xs-12 col-sm-3 control-label"> <spring:message code="re008.label.birthday" />
					</label>
					<div class="col-xs-12 col-sm-9">
						<p class="form-control-static">${patient.formattedBirthDay}</p>
					</div>
				</div>
				<div class="form-group">
					<label class="col-xs-12 col-sm-3 control-label"> <spring:message code="fe022.label.card.number" />
					</label>
					<div class="col-xs-12 col-sm-9">
						<p class="form-control-static">${reservation.cardNumber}</p>
					</div>
				</div>
					<div class="form-group">
						<label class="col-xs-12 col-sm-3 control-label"> <spring:message
								code="fe022.label.reminder.time" />
						</label>
						<div class="col-xs-12 col-sm-9">
							<p class="form-control-static">
								<spring:message
									code="${reservation.mapReminderTime.get(reservation.reminderTime)}" />
							</p>
						</div>
					</div>
					<c:if test="${bookingVaccine}">
						<div class="form-group">
<%-- 							<label class="col-xs-12 col-md-3 control-label"> <spring:message --%>
<%-- 									code="fe003.label.detail.bookingVaccine" /> --%>
<!-- 							</label> -->
							<div class="col-sm-12">
									<table id="dataTable" class="table table-bordered">
										<thead>
											<tr>
												<th width="" style="text-align: center;"><spring:message
														code="fe003.label.child.name" /></th>
												<th width="" style="text-align: center;"><spring:message
														code="fe003.label.child.dob" /></th>
												<th width="" style="text-align: center;"><spring:message
														code="general.label.sex" /></th>
												<th width="" style="text-align: center;"><spring:message
														code="fe003.label.vaccine" /></th>
												<th width="" style="text-align: center;"><spring:message
														code="fe003.label.dateTimeUsing" /></th>
											</tr>
										</thead>
										<tbody>
											<tr>
												<td style="text-align: center;">${userChildModel.childName}</td>
												<td style="text-align: center;">${userChildModel.dob}</td>
												<td style="text-align: center;"><c:choose>
														<c:when test="${userChildModel.sex == '1'}">
															<spring:message code="general.label.sex.male" />
														</c:when>
														<c:otherwise>
															<spring:message code="general.label.sex.female" />
														</c:otherwise>
													</c:choose></td>
												<td style="text-align: center;">${vaccineModel.vaccineName}</td>
												<td style="text-align: center;">${injectedNo}</td>
											</tr>
										</tbody>
									</table>
							</div>
						</div>
					</c:if>
					<br />
					<div class="form-group">
						<div class="col-xs-12 col-md-12">
							<p class="form-control-static">${reservation.deptName}
								${reservation.doctorName}
								${reservation.formattedReservationDate}
								${reservation.formattedReservationTime}</p>
						</div>
					</div>
					<div class="form-group">
					<div class="col-md-offset-3 col-md-12">
						<button type="button" class="btn btn-danger " data-toggle="modal" data-target="#cancelBooking">
							<spring:message code="fe022.button.cancel"/>
						</button> 
						<button type="button" class="btn btn-success " onclick="location.href='${confirmUrl}'">
							<spring:message code="fe022.button.changeSchedule"/>
						</button>
					</div>
				</div>
				<div class="form-group">
					<div class="col-xs-12">
						<p class="form-control-static"><spring:message code="fe022.message.footer" /></p>
					</div>
				</div>
			</c:when>
			<c:otherwise>
				<p><spring:message code="general.msg.session_timeout"/></p>
			</c:otherwise>
		</c:choose>
	</div><!-- End #booking-change-info -->
</div><!-- End #booking-change-wrapper -->

<div class="modal fade" id="cancelBooking">
	<div class="modal-dialog modal-sm">
		<div class="modal-content">
			<div class="modal-body">
				<button type="button" class="close" data-dismiss="modal">
					<span aria-hidden="true">&times;</span><span class="sr-only"></span>
				</button>
				<h4 class="modal-title">
					<spring:message code="fe022.modal.cancelBooking.title" />
				</h4>
			</div>
			<div class="modal-footer">
				<button type="submit" class="btn btn-success">
					<spring:message code="fe022.modal.confirm" />
				</button>
				<button type="button" class="btn btn-default" data-dismiss="modal">
					<spring:message code="fe022.modal.close" />
				</button>
			</div>
		</div>
	</div>
</div>
</form:form>
<script>
	disableSubmitButtonAfterSubmission(":submit");
</script>