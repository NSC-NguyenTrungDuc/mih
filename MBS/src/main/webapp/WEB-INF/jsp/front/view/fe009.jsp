<%@ page import="nta.mss.misc.common.MssContextHolder"%>
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
		<c:otherwise>
			<c:if test="${ not isKcck}">
				<c:url var="bookingChangeUrl" value="/booking/booking-change-info?token=${token}" />
				<h4 class="lead">
					<spring:message code="fe006.label.thanks" arguments="${hospitalName}"/><br/>
					<spring:message code="fe006.label.thanks.complete" arguments="${hospitalName}"/>
				</h4>
				<br/>
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
			</c:if>
		    <c:if test="${isKcck}">
			    <div class="row">
			    	<div id = "loading">
			    		<h class="lead"> <spring:message code="fe006.label.loading"/> </h></br>
			    		<div class="loader-special">Loading...</div>
						<!-- <button id = "loading" class="btn btn-default btn-lg"><i class="fa fa-spinner fa-spin"></i> Cu doi tao o day</button> -->
					</div>
			    </div>
			    <div id = "notSuccess">
					<span id = "not-success" ></span>
					<spring:message code="general.msg.new.not.success"/>
				</div>
				<div id = "cancel-authorization-result">
					<h class="lead">
						<%-- <span id = "booking-was-cancel"><spring:message code="gmo.booking.was.cancel"/></span><br/> --%>
						<span id = "authorization-amount-will-cancel"><spring:message code="gmo.authorization.amount.will.cancel"/></span>
					</h>
					<br/>
					<div class="row">
						<label class="col-xs-4 col-md-4 control-label">
							<spring:message code="gmo.orderid" />
						</label>
						<div class="col-xs-8 col-md-8">
							<span id = "order-id"></span>
						</div>
					</div>
					<div class="row">
						<label class="col-xs-4 col-md-4 control-label">
							<spring:message code="gmo.execute_date_time" /> 
						</label>
						<div class="col-xs-8 col-md-8">
							<span id = "execute-date-time" ></span>
						</div>
					</div>
				 </div>
			    <div id = "content-after-loading">
					<h class="lead">
						<span id = "thanks"></span><br/>
						<span id = "thanks-complete"></span>
					</h>
					<br/>
					<div class="row">
						<label class="col-xs-4 col-md-4 control-label">
							<spring:message code="fe005.label.patient.code" />
						</label>
						<div class="col-xs-8 col-md-8">
							<span id = "patient-code"></span>
						</div>
					</div>
					<br/>
					<div class="row">
						<label class="col-xs-4 col-md-4 control-label">
							<spring:message code="fe003.label.department" /> 
						</label>
						<div class="col-xs-8 col-md-8">
							<span id = "dept-name" ></span>
						</div>
					</div>
					<br/>
					<div class="row">
						<label class="col-xs-4 col-md-4 control-label">
							<spring:message code="fe005.label.reservation.time" /> 
						</label>
						<div class="col-xs-8 col-md-8">
							<span id = "booking-time"></span>
						</div>
					</div>
					<br/>
					<div class="row">
						<label class="col-xs-4 col-md-4 control-label">
							<spring:message code="fe003.label.time.reminder" /> 
						</label>
						<div class="col-xs-8 col-md-8 btn-group">
							<span id = "reminder-time" ></span>
						</div>
					</div>
					<br/>
					<div class="row">
						<div class="col-xs-12 col-md-12">
						    <span id = "note" ></span>
						</div>
					</div>
					<br/>
					<div id = "more-text">
						<div class="row">
							<div class="col-xs-12 col-md-12">
							    <span id = "note-static" ></span>
							</div>
						</div>
						<br/>
					</div>
					<div class="row">
						<div class="col-xs-12 col-md-12">
							<div id = "booking-change-url"></div>
						</div>	
					</div>
					<br/>
					<div class="row">
						<div class="col-xs-12 col-md-12">
							<div id = "link-servey"></div>
						</div>	
					</div>
				 </div>
			</c:if>	 
		</c:otherwise> 
</c:choose>
<script type="text/javascript">
$(document).ready(function(){
	$("#notSuccess").hide();
	$("#cancel-authorization-result").hide();
	$("#content-after-loading").hide();
	$("#loading").show();
	var isMobile = MssUtils.detectmob();
	if(isMobile)
	{
		MssUtils.focusIncaseMobile('.tabs_content');
	}
	/*Css for loading icon into between breadcum*/
	if(!isMobile)
	{
		var width = 0;
		$('.nav-wizard li').each(function() {
		    width += $(this).outerWidth( true );
		});
		$("#loading").width(width);	
	}
	/*Css for loading icon into between breadcum*/
	var quickMode = '${quick_mode}';
	var bookingMode = '${bookingMode}';
	var isKcck = '<%=MssContextHolder.isKcck()%>';	
	var hospitalName = '';
	 if(isKcck){
		    var requestBody = {
				   		      "sysId" : '${sysId}' ,
				   			  "master_profile" : '${master_profile}' ,
				   			  "patient_code_re" : '${patient_code_re}' ,
				   			  "user_token" : '${user_token}',
				   			  "bookingMode" : '${bookingMode}',
				   			  "token" : '${token}',
				   			  "quick_mode" : '${quick_mode}'
				   			  };
		   var interval = 1000*7;
		   var result = false;
		   var count = 0;
		   var refresh = setInterval(function(){
			if(count < 6 && result == false )
				{
				showResultBookingComplete(requestBody);
				count++;
				}
			if(result == true || count >= 6)
			    {
				clearInterval(refresh);
				}
			if(result == false && count >= 6)
			{
				// booking movie-talk
				if(bookingMode == "3" || bookingMode == "4") {
					cancelAuthorizationTransaction(requestBody)
				}
				
				$("#notSuccess").show();
				$("#content-after-loading").hide();
				$("#loading").hide();
				var thanks = '<spring:message code="fe006.label.thanks"/>';
				$("#not-success").html(replaceText(thanks , "{0}" , hospitalName));
			}
			}, interval); 
	   }
 function showResultBookingComplete(requestBody)
	{
		$.ajax({
			type : "post",
			url : "ajax-booking-after-asyn",
			data: JSON.stringify(requestBody),
			dataType: 'json',
			beforeSend : function(xhr)
			{
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type","application/json");
			},
			success:function(response)
			{
				if(response.status == 200)
					{
					var notSuccess = response.data.isNotSuccess;
					console.log(response.data);
					hospitalName = response.data.hospitalName;
					if(notSuccess == "false")
						{
							result = true;
							bindDataWhenBookingComplete(response.data);
							if(quickMode == "1")
							{						
							window.location.href = "/movie-talk/index";
							$("#notSuccess").hide();
							$("#content-after-loading").hide();
							$("#cancel-authorization-result").hide();
							$("#loading").hide();
							}
							else{ 
							$("#notSuccess").hide();
							$("#content-after-loading").show();
							$("#loading").hide();
							} 
						}
						
					}
			},
			error:function()
			{
				console.log("Error");
			}  
		});
	}
 
 function cancelAuthorizationTransaction(requestBody) {
		$.ajax({
			type : "post",
			url : "cancel-authorization-transaction",
			data: JSON.stringify(requestBody),
			dataType: 'json',
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type","application/json");
			},
			success:function(response) {
				if(response.status == 200) {
					var isSuccess = response.data.isSuccess;
					console.log(response.data);
					//hospitalName = response.data.hospitalName;
					if(isSuccess == "true") {
						result = true;
						
						$("#order-id").html(response.data.orderId);
						$("#execute-date-time").html(response.data.executeDateTime);
						$("#cancel-authorization-result").show();
						
						//bindDataWhenBookingComplete(response.data);
						/* if(quickMode == "1") {						
							window.location.href = "/movie-talk/index";
							$("#notSuccess").hide();
							$("#content-after-loading").hide();
							$("#loading").hide();
						} else { 
							$("#notSuccess").hide();
							$("#content-after-loading").show();
							$("#loading").hide();
						}  */
					}
					
				}
			}, error:function() {
				console.log("Error");
			}  
		});
	}
 
function bindDataWhenBookingComplete(data)
{
	var thankText = '<spring:message code="fe006.label.thanks" />';
    $('#thanks').text(replaceText(thankText , "{0}" , data.hospitalName));
    var thankComText = '<spring:message code="fe006.label.thanks.complete" />';
	$('#thanks-complete').text(replaceText(thankComText , "{0}" , data.hospitalName));
	$('#patient-code').text(data.patientCode);
	$('#dept-name').text(data.deptName);
	$('#booking-time').text(data.bookingTime);
	 var note = '<spring:message code="fe006.label.note" />';
	 $('#note').text(replaceText(replaceText(note, "{0}", data.deptName) , "{1}" , data.hospitalName));
	 $('#reminder-time').text(data.reminderTime);
	 var bookingChangeUrl = '<spring:message code="fe006.label.link.change.booking" />';
	 var bookingChangeUrlLink = '${pageContext.request.contextPath}/booking/booking-change-info?token=' + data.token;
	 var hiperLink = replaceText(bookingChangeUrl , "{0}" , bookingChangeUrlLink) + " ";
	 $('#booking-change-url').html('<span>'+hiperLink+'</span>');
	 var linkSurvey = '<spring:message code="fe006.label.link.survey" />';
	 if(data.linkSurvey != "" && data.linkSurvey != null ){
	 var realLinkSurvey = replaceText(linkSurvey , "{0}" , data.linkSurvey) + " ";
	 $('#link-servey').html('<span>'+realLinkSurvey+'</span>');
	 }
	 $('#more-text').hide();
	 if(data.isBookingOnline == "true")
	 {
		 $('#more-text').show();
		 $('#note-static').text('<spring:message code="fe009.label.online.booking.note" />');
	 }
	 
}	
 function replaceText(str,in_put,out_put)
	{
		if(str.indexOf(in_put) == -1)
			return str;
		return str.replace(in_put,out_put);
	}
});
</script>
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