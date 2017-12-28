<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

<c:url var="bookingNewUrl" value="/booking-manage/booking-new" />
<form:form method="post" action="${bookingNewUrl}" modelAttribute="patient" class="form-horizontal">
	<div id="validation" style="display:none">${validation}</div>
	<div id="main-booking-name" style="padding-top: 10px">
		<div class="form-group">
			<div class="col-sm-5">
				<spring:message code="fe003.label.please.input" />
			</div>
		</div>
		<div class="form-group">
			<spring:message code="fe003.place.holder.name" var="labelName"/>
			<label for="name" class="col-sm-3 control-label"><spring:message code="fe003.label.name" /><font color="red">*</font></label>
			<div class="col-sm-5">
				<form:input class="form-control" path="name" maxlength="64" placeholder="${labelName}" />
				<form:errors path="name" cssClass="alert-danger" />
			</div>
		</div>
		<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
		<div class="form-group">
			<spring:message code="fe003.place.holder.furigana" var="labelFurigana"/>
			<label for="nameFurigana" class="col-sm-3 control-label"><spring:message code="fe003.label.furigana" /><font color="red">*</font></label>
			<div class="col-sm-5">
				
				<form:input class="form-control" path="nameFurigana" maxlength="64" placeholder="${labelFurigana}" />
				<form:errors path="nameFurigana" cssClass="alert-danger" />
			</div>
		</div>
		<% } else { %>
		<form:hidden path="nameFurigana" class="form-control" value="ベトナムフリガナ" autocomplete="off" maxlength="64"/>
		<% } %>
		<div class="form-group">
			<spring:message code="fe003.place.holder.phone" var="labelPhone"/>
			<label for="phoneNumber" class="col-sm-3 control-label"><spring:message code="fe003.label.phone" /><font color="red">*</font></label>
			<div class="col-sm-5">
				<form:input class="form-control" path="phoneNumber" maxlength="32" placeholder="${labelPhone}"/>
				<form:errors path="phoneNumber" cssClass="alert-danger" />
			</div>
		</div>
		<div class="form-group">
			<spring:message code="fe003.place.holder.email" var="labelEmail"/>
			<label for="email" class="col-sm-3 control-label"><spring:message code="fe003.label.email" /></label>
			<div class="col-sm-5">
				<form:input class="form-control" path="email" placeholder="${labelEmail}" maxlength="128"/>
				<form:errors path="email" cssClass="alert-danger" />
			</div>
		</div>
		<div class="form-group">
			<label class="col-xs-4 col-md-3 control-label">
   	  			<spring:message code="general.label.sex"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-5 form-control-static">
   	  			<form:radiobutton path="gender" value="M" checked="checked"/><spring:message code="general.label.sex.male" /> 
				<form:radiobutton path="gender" value="F"/><spring:message code="general.label.sex.female" />
   		    </div>
		</div>
		<div class="form-group">
				<label class="col-xs-4 col-md-3 control-label">
   	  			<spring:message code="re008.label.birthday"/>
   	  		</label>
   	  		<div class="col-sm-5">
				<form:input class="form-control"  path="dob"/>
				<form:errors path="dob" cssClass="alert-danger" />
   		    </div>
		</div>
		
		<div class="form-group">
			<spring:message code="fe003.place.holder.card" var="labelTicket"/>
			<label for="cardNumber" class="col-sm-3 control-label"><spring:message code="fe003.label.ticket" /></label>
			<div class="col-sm-5">
				<form:input class="form-control" path="cardNumber" placeholder="${labelTicket}" />
				<form:errors path="cardNumber" cssClass="alert-danger" />
			</div>
		</div>
		<c:if test="${isBookingVaccine}">
			<form:hidden path="userId"/>
			<form:hidden path="vaccineId"/>
			<form:hidden path="childId"/>
			<form:hidden path="timeUsing"/>
			<div class="form-group">
				<label class="col-sm-3 control-label"><spring:message code="fe003.label.childrenInfo" /></label>
				<div class="col-sm-7">
					<table id="dataTable" class="table table-bordered">
						<thead>
							<tr>
								<th width="" style="text-align: center;"><spring:message code="fe003.label.child.name" /></th>
								<th width="" style="text-align: center;"><spring:message code="fe003.label.child.dob" /></th>
								<th width="" style="text-align: center;"><spring:message code="general.label.sex" /></th>
							</tr>
						</thead>
						<tbody>
							<tr>
								<td>${child.childName}</td>
								<td>${child.dob}</td>
								<td>
									<c:choose>
										<c:when test="${child.sex == '1'}">
											<spring:message code="general.label.male"/>
										</c:when>
										<c:otherwise>
											<spring:message code="general.label.female"/>
										</c:otherwise>
									</c:choose>
								</td>
							</tr>
						</tbody>
					</table>
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label"><spring:message code="fe003.label.vaccineName" /></label>
				<div class="col-sm-3">
					${vaccine.vaccineName}
				</div>
			</div>
		</c:if>
		
		<div class="form-group">
			<label for="reminderTime" class="col-sm-3 control-label"><spring:message code="fe003.label.time.reminder" /></label>
			<div class="col-sm-5">
				<p class="form-control-static">
					<form:radiobuttons path="reminderTime" items="${patient.mapReminderTime}" />
				</p>
			</div>
		</div>
		<div class="form-group">
			<div class="col-sm-12" >
<%-- 				<spring:message code="fe003.label.booking.at" /> --%>
<%-- 				&nbsp;${bookingDate} &nbsp; ${bookingTime} &nbsp; --%>
<%-- 				<spring:message code="fe003.label.department" /> --%>
<%-- 				&nbsp;${deptName} --%>
				<spring:message code="fe003.lable.booking.and.dept" arguments="${bookingDate},${bookingTime},${deptName}"/>
			</div>
		</div>
		<div class="form-group">
			<div class="col-sm-10" align="center">
				<input type="submit" value="<spring:message code="general.button.confirm" />" class="btn btn-success btn-sm btn-120" name="validate" />
				<a id="btnBack" class="btn btn-danger btn-sm btn-120" href="<c:url value="/booking-manage/select-time" />">
					<spring:message code="general.button.back" />
				</a>
			</div>
		</div>
	</div>
	<div id="confirm-booking" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
		<div class="modal-dialog modal-sm">
			<div class="modal-content">
				<div class="modal-body">
					<button type="button" class="close" data-dismiss="modal">
						<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message code="be031.modal.close" /></span>
					</button>
					<p>
						<spring:message code="be004.label.booking_confirm_msg" />
					</p>
				</div>
				<div class="modal-footer">
					<button type="submit" id="btnYes" class="btn btn-success btn-90"><spring:message code="be004.label.ok_btn" /></button>
					<button type="button" data-dismiss="modal" aria-hidden="true" class="btn btn-default btn-90">
						<spring:message code="be004.label.cancel_btn" />
					</button>
				</div>
			</div>
		</div>
	</div>
</form:form>
<script type="text/javascript" src="<c:url value='/assets/js/booking-manage/BookingNew.js' />"></script>
<script type="text/javascript">

	$(document).ready(function(){
		initPage();
		function initPage() {
			$("#dob").datepicker({ 
				dateFormat: 'yy/mm/dd',
				maxDate: 0
			});
			
			if (dobCurrent != "") {
				$("#dob").val(dobCurrent);
			} else {
				$("#dob").val(getCurrentDate());
			}
		}
		
		function getCurrentDate() {
			var now = new Date();
		    var day = ("0" + now.getDate()).slice(-2);
		    var month = ("0" + (now.getMonth() + 1)).slice(-2);
		    var today = now.getFullYear() +"/"+ month +"/"+ day+"";
		    return today;
		}
	});
</script>