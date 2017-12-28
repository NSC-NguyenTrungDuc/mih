<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%> 
 
 <c:choose>
 	<c:when test="${bookingVaccine}">
 		<c:url var="submitUrl" value="/booking/booking-vaccine-accept" />
 	</c:when>
 	<c:otherwise>
 		<c:url var="submitUrl" value="/booking/booking-accept" />
 	</c:otherwise>
 </c:choose>
 
 <c:url var="cancelUrl" value="/booking/booking-info" />
<form:form method="post" action="${submitUrl}" modelAttribute="patient" >
<div id="main-booking-name" class="">
	<div class="row">
		<label class="col-xs-4 col-md-3 control-label">
			<spring:message code="fe003.label.name" />
		</label>
		<div class="col-xs-8 col-md-8">
			<p class="form-control-static">
				${patient.name}
			</p>
		</div>
	</div>
	<br/>
	<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
	<div class="row">
		<label class="col-xs-4 col-md-3 control-label">
			<spring:message code="fe003.label.furigana" />
		</label>
		<div class="col-xs-8 col-md-8">
			<p class="form-control-static">
				${patient.nameFurigana}
			</p>
		</div>
	</div>
	<br/>
	<%} %>
	<c:if test="${hideSomeFields}">
		<div style="display:none;">
			<div class="row">
				<label class="col-xs-4 col-md-3 control-label">
					<spring:message code="fe003.label.phone" />
				</label>
				<div class="col-xs-8 col-md-8">
					<p class="form-control-static">
						${patient.phoneNumber}
					</p>
				</div>
			</div>
			<br/>
			<div class="row">
				<label class="col-xs-4 col-md-3 control-label">
					<spring:message code="fe003.label.email" />
				</label>
				<div class="col-xs-8 col-md-8">
					<p class="form-control-static">
						${patient.email}
					</p>
				</div>
			</div>
			<br/>
			<div class="row">
				<label class="col-xs-4 col-md-3 control-label">
					<spring:message code="general.label.sex" />
				</label>
				<div class="col-xs-8 col-md-8">
					<p class="form-control-static">
						${patient.genderText}
					</p>
				</div>
			</div>
			<br/>
			<div class="row">
				<label class="col-xs-4 col-md-3 control-label">
					<spring:message code="re008.label.birthday" />
				</label>
				<div class="col-xs-8 col-md-8">
					<p class="form-control-static">
						${patient.dob}
					</p>
				</div>
			</div>
		</div>
	</c:if>
	<c:if test="${!hideSomeFields}">
			<div class="row">
				<label class="col-xs-4 col-md-3 control-label">
					<spring:message code="fe003.label.phone" />
				</label>
				<div class="col-xs-8 col-md-8">
					<p class="form-control-static">
						${patient.phoneNumber}
					</p>
				</div>
			</div>
			<br/>
			<div class="row">
				<label class="col-xs-4 col-md-3 control-label">
					<spring:message code="fe003.label.email" />
				</label>
				<div class="col-xs-8 col-md-8">
					<p class="form-control-static">
						${patient.email}
					</p>
				</div>
			</div>
			<br/>
			<div class="row">
				<label class="col-xs-4 col-md-3 control-label">
					<spring:message code="general.label.sex" />
				</label>
				<div class="col-xs-8 col-md-8">
					<p class="form-control-static">
						${patient.genderText}
					</p>
				</div>
			</div>
			<br/>
			<div class="row">
				<label class="col-xs-4 col-md-3 control-label">
					<spring:message code="re008.label.birthday" />
				</label>
				<div class="col-xs-8 col-md-8">
					<p class="form-control-static">
						${patient.dob}
					</p>
				</div>
			</div>
	</c:if>
	<c:if test="${not bookingVaccine and not isBookingNewBorns and not isKcck}">
		<br/>
		<div class="row">
			<label class="col-xs-4 col-md-3 control-label">
				<spring:message code="fe003.label.ticket" />
			</label>
			<div class="col-xs-8 col-md-8">
				<p class="form-control-static">
					${patient.cardNumber}
				</p>
			</div>
		</div>
	</c:if>
	<c:if test="${bookingVaccine}">
		<br/>
		<div class="row">
<!-- 			<label class="col-xs-4 col-md-3 control-label"> -->
<%-- 				<spring:message code="fe003.label.detail.bookingVaccine" /> --%>
<!-- 			</label> -->
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
								<td style="text-align: center;">${childModel.childName}</td>
								<td style="text-align: center;">${childModel.dob}</td>
								<td style="text-align: center;">
									<c:choose>
										<c:when test="${childModel.sex == '1'}">
											<spring:message code="general.label.sex.male" />
										</c:when>
										<c:otherwise>
											<spring:message code="general.label.sex.female" />
										</c:otherwise>
									</c:choose>
									
								</td>
								<td style="text-align: center;">${vaccineModel.vaccineName}</td>
								<td style="text-align: center;">${timeUsing}</td>
							</tr>
						</tbody>
					</table>
			</div>
		</div>
	</c:if>
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
	<c:if test="${imageInsurance}">
	<br/>
		<div class="row">
			<label class="col-xs-4 col-md-3 control-label">
				<spring:message code="fe004.label.linkInsurance" />
			</label>
			<div class="col-xs-8 col-md-8">
				<img id = "image-insurance" src="http://imageurl" style="width: auto; height: auto;max-width: 120px;max-height: 100px">
			</div>
			<!-- The Modal -->
			<div id="myModal" class="modal-img-insurance">
			
			  <!-- The Close Button -->
			  <span class="close-img-insurance" onclick="document.getElementById('myModal').style.display='none'">&times;</span>
			
			  <!-- Modal Content (The Image) -->
			  <img class="modal-content" id="img-modal">
			
			  <!-- Modal Caption (Image Text) -->
			  <div id="caption"></div>
			</div>
		</div>
	</c:if>
	<br/>
	<div class="row">
		<label class="col-xs-4 col-md-3 control-label">
			<spring:message code="fe003.label.time.reminder" /> 
		</label>
		<div class="col-xs-8 col-md-8">
			<p class="form-control-static">
				<spring:message code="${patient.mapReminderTime.get(patient.reminderTime)}" />
			</p>
		</div>
	</div>
	<br/>
	<div class="row">
		<div class="col-xs-12 col-md-12">
<%-- 			<spring:message code="fe003.label.booking.at" />&nbsp;${bookingDate}&nbsp;&nbsp;${bookingTime} &nbsp; <spring:message code="fe003.label.department" />&nbsp;${deptName} --%>
			<spring:message code="fe004.lable.booking.and.dept.confirm" arguments="${bookingDate},${bookingTime},${deptName}"/>
		</div>
	</div>
	<br/>
	<div class="row col-sm-offset-3 col-sm-5">
		<%-- <button type="submit" class="btn btn-success btn-sm" ><spring:message code="fe004.button.submit.booking"/></button> --%>
		<c:if test="${authorizationInfo.use_auth == 'N'}">
			<input type="submit" id = "submit-booking" class="btn btn-success btn-sm" value="<spring:message code="fe004.button.submit.booking"/>" />
		</c:if>
		<c:if test="${authorizationInfo.use_auth == 'Y'}">
			<input type="button" id = "submit-booking" class="btn btn-success btn-sm"
				value="<spring:message code="fe004.button.submit.booking"/>" data-toggle="modal" data-target="#payment-info" />
		</c:if>
		<button type="button" class="btn btn-default btn-sm" onclick="window.history.back()"><spring:message code="be005.label.back_btn"/></button>
	</div>
</div>
</form:form>

<script type="text/javascript">
	disableSubmitButtonAfterSubmission(":submit");
	$(document).ready(function(){
		var isMobile = MssUtils.detectmob();
		if(isMobile)
		{
			
			MssUtils.focusIncaseMobile('#patient');
		}
		var imageInsurance = '${imageInsurance}';
		var linkInsurance = '${linkInsurance}';
		if(imageInsurance != '' && imageInsurance != null)
			{

			$('#image-insurance').attr("src",linkInsurance);
			}
		
		/*Code java script show popup image insurance*/
		// Get the modal
		var modal = document.getElementById('myModal');

		// Get the image and insert it inside the modal - use its "alt" text as a caption
		var img = document.getElementById('image-insurance');
		var modalImg = document.getElementById("img-modal");
		var captionText = document.getElementById("caption");
		img.onclick = function(){
		    modal.style.display = "block";
		    modalImg.src = this.src;
		    captionText.innerHTML = this.alt;
		}

		// Get the <span> element that closes the modal
		var span = document.getElementsByClassName("close-img-insurance")[0];

		// When the user clicks on <span> (x), close the modal
		span.onclick = function() {
		  modal.style.display = "none";
		  
		}
	});
</script>

<div class="modal fade" id="payment-info" tabindex="-1" role="dialog" aria-labelledby="videosettinglabel" aria-hidden="true" style="display:none;"data-backdrop="static" >
	<div class="modal-dialog" role="document">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="closePopup();">
					<span aria-hidden="true"><spring:message code="fe616.button.close"/></span>
				</button>
				<h4 class="modal-title" id="videosettinglabel">
					<i class="fa fa-cog"></i> <!-- Payment info -->
				</h4>
			</div>
			<div class="modal-body">
				<!-- BEGIN Block -->
				<div class="block">
					<!-- <div class="block-header">
						<h3 class="block-title">
							<i class="fa fa-microphone"></i> Payment info
						</h3>
						<span class="toggle opened">&nbsp;</span>
					</div> -->
					<div class="block-content">
						<p>
							<c:if test="${authorizationInfo.locale == 'ja'}">
								<jsp:include page="online-payment/confirm-jp.jsp" />
							</c:if>
							<c:if test="${authorizationInfo.locale == 'en'}">
								<jsp:include page="online-payment/confirm-en.jsp" />
							</c:if>
						</p>
						
						<button type="button" class="btn btn-orange" data-dismiss="modal" onclick="sentPay();">
							<spring:message code="be003.label.confirm_btn"/>
						</button>
						
						<!-- BEGIN Row -->
						<%-- <div class="cgroup">
							<label for="audioSource" class="label"><spring:message code="fe616.button.microphone"/></label> 
							<select class="input gradient input-block" id="audioSource"></select>
						</div> --%>
						<!-- END Row -->
						<!-- BEGIN Row -->
						<%-- <div class="cgroup">
							<label class="label"><spring:message code="fe616.button.volume"/></label></label>
						</div> --%>
						<!-- END Row -->
					</div>
				</div>
				<!-- END Block -->
			</div>
			<%-- <div class="modal-footer">
				<button type="button" class="btn btn-orange" data-dismiss="modal" onclick="saveSetting();"><spring:message code="fe616.button.savechanges"/></button>
			</div> --%>
		</div>
	</div>
</div>

<form style= "display:none;" method="post" id="myRedirectForm" name="myRedirectForm" action="${authorizationInfo.gmoPayUrlResquestion}" id="frmLogin">
	<table style="display:none;">
		<tr>
			<td>ShopID</td>
			<td><input type="text" name="ShopID" id="ShopID" value="${authorizationInfo.shop_id}"></td>
		</tr>
		<tr>
			<td>OrderID</td>
			<td><input type="text" name="OrderID" id="OrderID" value="${authorizationInfo.order_id}"></td>
		</tr>	
		<tr>
			<td>Amount</td>
			<td><input type="text" name="Amount" id="Amount" value="${authorizationInfo.auth_amt}"></td>
		</tr>
		
		<tr>
			<td>Tax</td>
			<td><input type="text" name="Tax" id="Tax" value="${authorizationInfo.tax}"></td>
		</tr>		
		<tr>
			<td>Currency</td>
			<td><input type="text" name="Currency" value="${authorizationInfo.currency}"></td>
		</tr>
		<tr>
			<td>DateTime</td>
			<td><input type="text" name="DateTime" id="DateTime" value="${authorizationInfo.date_time}"></td>
		</tr>	
		<tr>
			<td>ShopPassString</td>
			<td><input type="text" name="ShopPassString" id="ShopPassString" value="${authorizationInfo.shop_pass_string}"></td>
		</tr>	
		<tr>
			<td>RetURL</td>
			<td><input type="text" name="RetURL" value="${authorizationInfo.ret_url}"></td>
		</tr>	
		<tr>
			<td>CancelURL</td>
			<td><input type="text" name="CancelURL" value="${authorizationInfo.cancel_url}"></td>
		</tr>	
		<tr>
			<td>UserInfo</td>
			<td><input type="text" name="UserInfo" value="${authorizationInfo.user_info}"></td>
		</tr>	
		<tr>
			<td>RetryMax</td>
			<td><input type="text" name="RetryMax" value="${authorizationInfo.retry_max}"></td>
		</tr>	
		<tr>
			<td>SessionTimeout</td>
			<td><input type="text" name="SessionTimeout" value="${authorizationInfo.session_timeout}"></td>
		</tr>	
		<tr>
			<td>UseCredit</td>
			<td><input type="text" name="UseCredit" value="${authorizationInfo.use_credit}"></td>
		</tr>	
		<tr>
			<td>TemplateNo</td>
			<td><input type="text" name="TemplateNo" value="${authorizationInfo.template_no}"></td>
		</tr>	
		<tr>
			<td>JobCd</td>
			<!-- <td><input type="text" name="JobCd" value="CAPTURE"></td> -->
			<td><input type="text" name="JobCd" value="${authorizationInfo.job_cd}"></td>
		</tr>	
	</table>
   	<input type="submit" value="Comfirm"/>
</form>
	
<script>
	function sentPay() {
		$("#myRedirectForm").submit();
	}
</script>