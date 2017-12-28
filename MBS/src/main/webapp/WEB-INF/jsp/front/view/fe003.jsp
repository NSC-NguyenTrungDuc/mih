<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

<c:choose>
	<c:when test="${bookingVaccine}">
		<c:url var="confirmUrl" value="/booking/booking-vaccine-info" />
	</c:when>
	<c:otherwise>
		<c:url var="confirmUrl" value="/booking/booking-info" />
	</c:otherwise>
</c:choose>

<form:form method="post" action="${confirmUrl}" modelAttribute="patient"  enctype="multipart/form-data">
	<form:input type="hidden" id= "patientIconPath" path="patientIconPath" value=""/>
	<h3>
		<spring:message code="fe003.label.please.input" />
	</h3>
	<div id="main-booking-name" class="form-horizontal">
		<div class="row">
			<spring:message code="fe003.place.holder.name" var="labelName" />
			<label class="col-xs-4 col-md-3 control-label"> <spring:message
					code="fe003.label.name" /><font color="red">*</font>
			</label>
			<div class="col-xs-8 col-md-8">
		<form:input class="form-control" path="name" maxlength="64"
						placeholder="${labelName}" />
						<form:errors path="name" cssClass="alert-danger" />
			</div>
		</div>
		<br>

		<%
			if (HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale())) {
		%>
		<div class="row">
			<spring:message code="fe003.place.holder.furigana"
				var="labelFurigana" />
			<label class="col-xs-4 col-md-3 control-label"> <spring:message
					code="fe003.label.furigana" /><font color="red">*</font>
			</label>
			<div class="col-xs-8 col-md-8">
			<form:input class="form-control" path="nameFurigana"
				maxlength="64" placeholder="${labelFurigana}" />
			
				<form:errors path="nameFurigana" cssClass="alert-danger" />
			</div>
		</div>
		<br>
		<%
			} else {
		%>
		<form:hidden path="nameFurigana" class="form-control" value="ベトナムフリガナ"
			autocomplete="off" maxlength="64" />
		<%
			}
		%>
	<c:if test="${hideSomeFields}">
		<div style="display:none;">
			<div class="row">
				<spring:message code="fe003.place.holder.phone" var="labelPhone" />
				<label class="col-xs-4 col-md-3 control-label"> <spring:message
						code="fe003.label.phone" /><font color="red">*</font>
				</label>
				<div class="col-xs-8 col-md-8">
					<form:input class="form-control" path="phoneNumber" maxlength="32"
								placeholder="${labelPhone}" />
					<form:errors path="phoneNumber" cssClass="alert-danger" />
				</div>
			</div>
			<br>
			<div class="row">
				<spring:message code="fe003.place.holder.email" var="labelEmail" />
				<label class="col-xs-4 col-md-3 control-label"> <spring:message
						code="fe003.label.email" /><font color="red">*</font>
				</label>
				<div class="col-xs-8 col-md-8">
										<form:input class="form-control" path="email" maxlength="128"
								placeholder="${labelEmail}" />
								<form:errors path="email" cssClass="alert-danger" />
				</div>
			</div>
			<br>
			<div class="col-sm-8 form-control-static" hidden="true">
	   	  			<form:radiobutton path="gender" value="M" checked="checked" /><spring:message code="general.label.sex.male" /> 
					<form:radiobutton path="gender" value="F"/><spring:message code="general.label.sex.female" />
					<form:errors path="gender" cssClass="alert-danger" />
	   		 </div>
	   	</div>
   	</c:if>
   	<c:if test="${!hideSomeFields}">
			<div class="row">
				<spring:message code="fe003.place.holder.phone" var="labelPhone" />
				<label class="col-xs-4 col-md-3 control-label"> <spring:message
						code="fe003.label.phone" /><font color="red">*</font>
				</label>
				<div class="col-xs-8 col-md-8">
					<form:input class="form-control" path="phoneNumber" maxlength="32"
								placeholder="${labelPhone}" />
					<form:errors path="phoneNumber" cssClass="alert-danger" />
				</div>
			</div>
			<br>
			<div class="row">
				<spring:message code="fe003.place.holder.email" var="labelEmail" />
				<label class="col-xs-4 col-md-3 control-label"> <spring:message
						code="fe003.label.email" /><font color="red">*</font>
				</label>
				<div class="col-xs-8 col-md-8">
										<form:input class="form-control" path="email" maxlength="128"
								placeholder="${labelEmail}" />
								<form:errors path="email" cssClass="alert-danger" />
				</div>
			</div>
			<br>
			<div class="col-sm-8 form-control-static" hidden="true">
	   	  			<form:radiobutton path="gender" value="M" checked="checked" /><spring:message code="general.label.sex.male" /> 
					<form:radiobutton path="gender" value="F"/><spring:message code="general.label.sex.female" />
					<form:errors path="gender" cssClass="alert-danger" />
	   		 </div>
   	</c:if>
   	
	<c:if test="${not bookingVaccine and not isBookingNewBorns}">
	   <c:if test="${hideSomeFields}">
	   		<div style="display:none;">	
				<div class="row">
					<label class="col-xs-4 col-md-3 control-label">
		   	  			<spring:message code="general.label.sex"/><font color="red">*</font>
		   	  		</label>
		   	  		<div class="col-sm-8 form-control-static">
		   	  			<form:radiobutton path="gender" value="M" checked="checked" /><spring:message code="general.label.sex.male" /> 
						<form:radiobutton path="gender" value="F"/><spring:message code="general.label.sex.female" />
						<form:errors path="gender" cssClass="alert-danger" />
		   		    </div>
				</div>
				<br>
				<div class="row">
					<spring:message code="fe003.place.holder.dob" var="labelDob" />
						<label class="col-xs-4 col-md-3 control-label">
		   	  			<spring:message code="fe003.label.birthday"/>
		   	  		</label>
		   	  		<div class="col-sm-8">
						<form:input class="form-control"  path="dob" placeholder="${labelDob}"/>
						<form:errors path="dob" cssClass="alert-danger" />
		   		    </div>
				</div>
			</div>
		</c:if>
		
		<c:if test="${!hideSomeFields}">
				<div class="row">
					<label class="col-xs-4 col-md-3 control-label">
		   	  			<spring:message code="general.label.sex"/><font color="red">*</font>
		   	  		</label>
		   	  		<div class="col-sm-8 form-control-static">
		   	  			<form:radiobutton path="gender" value="M" checked="checked" /><spring:message code="general.label.sex.male" /> 
						<form:radiobutton path="gender" value="F"/><spring:message code="general.label.sex.female" />
						<form:errors path="gender" cssClass="alert-danger" />
		   		    </div>
				</div>
				<br>
				<div class="row">
					<spring:message code="fe003.place.holder.dob" var="labelDob" />
						<label class="col-xs-4 col-md-3 control-label">
		   	  			<spring:message code="fe003.label.birthday"/>
		   	  		</label>
		   	  		<div class="col-sm-8">
						<form:input class="form-control"  path="dob" placeholder="${labelDob}"/>
						<form:errors path="dob" cssClass="alert-danger" />
		   		    </div>
				</div>
		</c:if>
		<c:if test="${needUpdateInsurance}">
		<br>
				<div class="row">
					<label class="col-xs-4 col-md-3 control-label">
						<spring:message code="fe003.label.updateInsurance"/>
					</label>
					<div class="col-sm-8">					
						<form:input  id="BSbtnsuccess" type ="file"  path="file" />
						<div id = "error_text_upload" style="display:none"><span style="color:red">Loi upload file</span></div>
					</div>
				</div>
				
		</c:if>
			
			<c:choose>
				<c:when test="${patient.isNewBooking()}">
					<c:if test="${not isKcck}">
						<div class="row">
							<spring:message code="fe003.place.holder.card" var="labelTicket" />
							<label class="col-xs-4 col-md-3 control-label"> <spring:message
									code="fe003.label.ticket" />
							</label>
							<div class="col-xs-8 col-md-8">
								<form:input class="form-control" path="cardNumber"
									maxlength="32" placeholder="${labelTicket}" />
								<form:errors path="cardNumber" cssClass="alert-danger" />
							</div>
						</div>
					</c:if>
				</c:when>
				<c:otherwise>
					<div class="row">
						<label class="col-xs-4 col-md-3 control-label"> <spring:message
								code="fe003.label.ticket" />
						</label>
						<div class="col-xs-8 col-md-8">
							<p class="form-control-static">${patient.cardNumber}</p>
						</div>
						<form:hidden path="cardNumber" />
					</div>
				</c:otherwise>
			</c:choose>
		</c:if>
		<c:if test="${bookingVaccine}">
			<br />
			<div class="row">
				<label class="col-xs-4 col-md-3 control-label"> <spring:message
						code="fe003.label.childName" />
				</label>
				<div class="col-xs-8 col-md-8">
					<p class="form-control-static">${childName}</p>
				</div>
				<form:hidden path="childId" />
			</div>
		</c:if>

		<c:if test="${isBookingNewBorns}">
			<br />
			<div class="row">
				<label class="col-xs-4 col-md-3 control-label"> <spring:message
						code="fe00302.label.choose.child" /><font color="red">*</font>
				</label>
				<div class="col-xs-8 col-md-8">
					<form:select id="slt-child" path="childId" cssClass="form-control"
						items="${lstChild}" />
					<form:errors path="childId" cssClass="alert-danger" />
				</div>
			</div>
		</c:if>
		<br />
		<div class="row">
			<label class="col-xs-4 col-md-3 control-label"> <spring:message
					code="fe003.label.time.reminder" />
			</label>
			<div class="col-xs-8 col-md-8 btn-group">
				<p class="form-control-static">
					<form:select  path="reminderTime">
						<form:options items="${patient.mapReminderTime}" />
					</form:select>
					<span><spring:message code="fe003.label.before.reminder" /></span>
				</p>
			</div>
		</div>
		<div class="row">
			<div class="col-xs-12 col-md-12">
				<%-- 			<spring:message code="fe003.label.booking.at" />&nbsp;${bookingTime} &nbsp; <spring:message code="fe003.label.department" />&nbsp;${deptName} --%>
				<spring:message code="fe003.lable.booking.and.dept"
					arguments="${bookingDate},${bookingTime},${deptName}" />
			</div>
		</div>
		<br />
		<div class="row col-sm-offset-3 col-sm-5">
			<input type="submit" id = "submit-booking" class="btn btn-success btn-sm"
				value="<spring:message code="general.button.confirm"/>" />
			<c:choose>
				<c:when test="${bookingVaccine}">
					<input type="button" id="btnBackBookingVaccine"
						class="btn btn-default btn-sm"
						value="<spring:message code="general.button.back"/>" />
				</c:when>
				<c:otherwise>
					<input type="button" id="btnBack" class="btn btn-default btn-sm"
						value="<spring:message code="general.button.back"/>" />
				</c:otherwise>
			</c:choose>
		</div>
	</div>
</form:form>

<script type="text/javascript">
	$(document)
			.ready(
					function() {
						$("#btnBack")
								.click(
										function() {
											window.location.href = '<c:url value="/booking/booking-time?deptId=${deptId}" />';
										});

						$("#nameFurigana").keydown(function() {
							return furiganaCheck();
						});

						$("#btnBackBookingVaccine")
								.click(
										function() {
											window.location.href = '<c:url value="/booking/booking-vaccine-select-time?vaccineId=${vaccineId}&childId=${childId}&timesUsing=${timesUsing}" />';
										});
						var nameChooseFile = "<spring:message code="be202.choose.file"/>";
						$('#BSbtnsuccess').filestyle({
							buttonName : 'btn-success',
			                buttonText : nameChooseFile
						});
						$('#patientIconPath').val('');
						var urlUpload =  '${urlUpload}';
						var needUpdateInsurance = '${needUpdateInsurance}';
						console.log("Need update insurance " + needUpdateInsurance);
						$('#BSbtnsuccess').on('change',function(e){
							var files = e.target.files;
							    if (files.length > 0) {
							       if (window.FormData !== undefined) {							      					   
									var fa = new FormData();
									fa.append("file", files[0]);
									var allowTypeFile = ["image/jpeg","image/jpg","image/png"];
									console.log(files[0].type);
									var errorText = $("#error_text_upload");
									if(parseInt(files[0].size) > 2000000)
										{
										var textErrorUpload =  '<spring:message code="fe003.label.updateInsurance.errorSize" />';
										errorText.find("span").text(textErrorUpload);
										errorText.show();
									    setTimeout(function() {
									    	errorText.hide();
									    	$(".bootstrap-filestyle").find("input").val('');
									    }, 2000); 
										}
									else if(!(allowTypeFile.indexOf(files[0].type.toLowerCase()) > -1))
										{									
										var textErrorUpload = '<spring:message code="fe003.label.updateInsurance.errorType" />';
										errorText.find("span").text(textErrorUpload);
										errorText.show();
									    setTimeout(function() {
									    	errorText.hide();
									    	$(".bootstrap-filestyle").find("input").val('');
									    }, 2000); 
										}
									else{
										if(needUpdateInsurance == "true")
										{
										$("#submit-booking").prop("disabled", true);
										}
										$.ajax({
							               type: "POST",
							               url:  urlUpload,
							               contentType: false,
							               processData: false, 
										   crossDomain: true,
							               data: fa,
										    dataType: 'json',
							               success: function(result) {
							            	   $('#patientIconPath').val(result.content);
							               },							       
							               error: function (xhr, status, p3, p4){
							            	   var err = "Error " + " " + status + " " + p3 + " " + p4;
							                   if (xhr.responseText && xhr.responseText[0] == "{")
							                       err = JSON.parse(xhr.responseText).Message;
							                       console.log(err);
							                    },
							               complete: function(result)
							               {
							            	   $("#submit-booking").prop("disabled", false);
							               }
							                });
							           }
							        } else {
							            alert("This browser doesn't support HTML5 file uploads!");
							          }
							     }
						});
					});

	function furiganaCheck() {
		var str = document.iform.FuriganaText.value;
		if (str.match(/[^ぁ-んァ-ン　\s]+/)) {
			alert("ふりがなは、「ひらがな」・「カタカナ」のみで入力して下さい。");
			return true;
		}
		return false;
	}
</script>
 <script type="text/javascript">

	$(document).ready(function(){
		initPage();
		var isMobile = MssUtils.detectmob();
		if(isMobile)
		{
			MssUtils.focusIncaseMobile('#patient');
		}
		function initPage() {
			$("#dob").datepicker({ 
				beforeShow: function() {
			        setTimeout(function(){
			            $('.ui-datepicker').css('z-index', 99999999999999);
			        }, 0);
			    },
				dateFormat: 'yy/mm/dd',
				maxDate: 0
			});
			
			/* if (dobCurrent != "") {
				$("#dob").val(dobCurrent);
			} else {
				$("#dob").val(getCurrentDate());
			} */
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
