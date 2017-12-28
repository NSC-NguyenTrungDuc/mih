<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/security/tags" prefix="sec" %>

<c:url var="submitUrl" value="/booking/profile-management" />
<c:url var="bookingTimeUrl" value="/booking/booking-time?deptId=${deptId}&deptType=${deptType}&childId=" />
<c:url var="vaccineHistoryUrl" value="/booking/vaccine-history?childId=" />
<c:url var="addChildUrl" value="/booking/add-child" />
<c:url var="editChildUrl" value="/booking/change-user-child?childId=" />
<c:url var="backUrl" value="/booking/index" />
<c:url var="bookingVaccineUrl" value="/booking/booking-vaccine-recommendation?childId=" />
<div class="col-md-12">
	<form:form method="post" action="${submitUrl}" class="form-horizontal" role="form" modelAttribute="user" >
		<form:hidden path="userId"/>
   	  	<div class="form-group row">
   	  		<spring:message code="re002.place.holder.name" var="labelName" />
   	  		<label class="col-sm-4 control-label">
   	  			<spring:message code="re002.label.name"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-8">
				<form:input class="form-control" path="name" maxlength="64" placeholder="${labelName}" />
				<form:errors path="name" cssClass="alert-danger" />
   		    </div>
   		</div>
   		<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
   		<div class="form-group row">
   	  		<spring:message code="re002.place.holder.name.furigana" var="labelNameFurigana" />
   	  		<label class="col-sm-4 control-label">
   	  			<spring:message code="re002.label.name.furigana"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-8">
   	  			<form:input class="form-control" path="nameFurigana" maxlength="64" placeholder="${labelNameFurigana}" />
				<form:errors path="nameFurigana" cssClass="alert-danger" />
   		    </div>
   		</div>
   		<% } else { %>
		<form:hidden path="nameFurigana" class="form-control" value="ベトナムフリガナ" autocomplete="off" maxlength="64"/>
		<% } %>
   		<div class="form-group row">
   	  		<label class="col-sm-4 control-label">
   	  			<spring:message code="general.label.sex"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-8 form-control-static">
   	  			<form:radiobutton path="sex" value="1" checked="checked"/><spring:message code="general.label.sex.male" />
				<form:radiobutton path="sex" value="0"/><spring:message code="general.label.sex.female" />
   		    </div>
   		</div>
   		<div class="form-group row">
   	  		<spring:message code="re002.place.holder.phone" var="labelPhone" />
   	  		<label class="col-sm-4 control-label">
   	  			<spring:message code="re002.label.phone"/><font color="red">*</font>
   	  		</label>
   	  		<div class="col-sm-8">
				<form:input class="form-control" path="phoneNumber" maxlength="32" placeholder="${labelPhone}" />
				<form:errors path="phoneNumber" cssClass="alert-danger" />
   		    </div>
   		</div>

   			<div class="form-group row">
   	  		<label class="col-sm-4 control-label">
   	  			<spring:message code="fe010.label.card.number"/>
   	  		</label>
   	  		<div class="col-sm-8">
				<form:input class="form-control" path="patientCode" maxlength="32" readonly="true" />
				<form:errors path="patientCode" cssClass="alert-danger" />
   		    </div>
   		</div>
  <c:if test="${!isFacebookId}">
	   	<div class="form-group row" id="passWordOld">
	   		<label class="col-sm-4 control-label">
	   			<spring:message code="re002.label.pass" /><font color="red">*</font>
	   		</label>
	   		<div class="col-sm-8">
				<input type="text" class="form-control" id="changePassword" maxlength="128" />
<%-- 				<form:errors path="password" cssClass="alert-danger" /> --%>
   		    </div>
	   	</div>
	   	<div id="divShowChangePass" style="display: none;">
		   	<div class="form-group row">
		   		<label class="col-sm-4 control-label">
		   			<spring:message code="re002.label.pass" /><font color="red">*</font>
		   		</label>
		   		<div class="col-sm-8">
					<form:password class="form-control" id="changePassword" path="password" maxlength="128" />
					<form:errors path="password" cssClass="alert-danger" />
	   		  </div>
		   	</div>
		   	<div class="form-group row">
		   		<label class="col-sm-4 control-label">
		   			<spring:message code="re002.label.pass.confirm" /><font color="red">*</font>
		    	</label>
		   	  	<div class="col-sm-8">
					<form:password class="form-control" path="passwordConfirm" maxlength="128" />
					<form:errors path="passwordConfirm" cssClass="alert-danger" />
		   		</div>
		   	</div>
	   	</div>
  </c:if>
   		<div class="form-group row">
    		<div class="col-sm-offset-4 col-sm-8">
    			<button type="submit" class="btn btn-success" id="btnSubmit"><spring:message code="general.button.submit.edit"/></button>
				<button type="button" class="btn btn-default" onclick="location.href='${backUrl}'"><spring:message code="general.button.cancel"/></button>
    		</div>
    	</div>
    	<form:hidden id="isChangePass" path="changePass"/>
	</form:form>

	<div class="form-group row">
    	<label class="col-sm-4 control-label">
			<spring:message code="re005.label.member.list" />
		</label>
    </div>
	<div class="form-group row">
		<div class="col-sm-12">
					<table id="dataTable" class="table table-bordered">
						<thead>
							<tr style="background-color: #27ae61; color: white; font-weight: bold;" role="row">
								<th width="" style="text-align: center;"><spring:message code="re005.label.child.name" /></th>
								<th width="" style="text-align: center;"><spring:message code="re005.label.child.dob" /></th>
								<th width="" style="text-align: center;"><spring:message code="general.label.sex" /></th>
								<th width="" style="text-align: center;"><spring:message code="fe010.label.card.number" /></th>
								<th width="" style="text-align: center;"></th>
								<th width="" style="text-align: center;"></th>
								<th width="" style="text-align: center;"></th>
								<c:if test="${not empty deptId}">
								<th width="" style="text-align: center;"></th>
								</c:if>
							</tr>
						</thead>
						<tbody>
							<c:forEach  items="${user.userChilds}" var="childItem">
								<tr data-id = "${childItem.childId}">
									<td style="text-align: center;"><a href="${vaccineHistoryUrl}${childItem.childId}">${childItem.childName}</a></td>
									<td style="text-align: center;">${childItem.dob}</td>

									<td style="text-align: center;">
										<c:choose>
											<c:when test="${childItem.sex == 1}">
												<spring:message code="general.label.sex.male" />
											</c:when>
											<c:otherwise>
												<spring:message code="general.label.sex.female" />
											</c:otherwise>
										</c:choose>
									</td>
									<td style="text-align: center;">${childItem.patientCode}</td>
									<td style="text-align: center;"><button type="button" class="btn btn-primary btn-xs btn-change btn-60" id="btnEdit" onclick="location.href='${editChildUrl}${childItem.childId}'"><spring:message code="re005.label.btn-edit" /></button></td>
									<td style="text-align: center;"><button type="button" class="btn btn-danger btn-xs btn-delete btn-60" id="btnDelete" data-toggle="modal" data-target="#deleteNewborns"><spring:message code="re005.label.btn-delete" /></button></td>
									<c:if test="${not empty deptId}">
									<td style="text-align: center;"><button type="button" class="btn btn-success btn-xs btn-120" id="btnBooking2" onclick="location.href='${bookingTimeUrl}${childItem.childId}'"><spring:message code="re005.label.exam-newborns" /></button></td>
									</c:if>
									<td style="text-align: center;"><button type="button" class="btn btn-success btn-xs btn-120" id="btnBookingVaccine" onclick="location.href='${bookingVaccineUrl}${childItem.childId}'"><spring:message code="re005.label.booking-vaccine" /></button></td>
								</tr>
							</c:forEach>
						</tbody>
					</table>
			</div>
		</div>
		<div class="form-group row">
			<div class="col-sm-12">
    			<button type="button" class="btn btn-primary btn-change" id="btnBooking" onclick="location.href='${addChildUrl}'"><spring:message code="re005.label.btn.add.children" /></button>
    		</div>
    	</div>

    	<!-- [Start] Show dialog confirm -->
			<div class="modal fade " id="confirmChangePassword">
				<div class="modal-dialog modal-sm">
					<div class="modal-content">
						<!-- [Start] Header dialong -->
						<div class="modal-body">
							<button type="button" class="close" data-dismiss="modal">
								<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message code="popup.label.close" /></span>
							</button>
							<p>
								<spring:message code="re005.modal.title.change.password" />
							</p>
						</div>

						<div class="modal-footer" align="center">
							<button id="confirm-change-password" type="button" value="" class="btn btn-success">
								<spring:message code="popup.label.comfirm" />
							</button>
							<button type="button" class="btn btn-default" data-dismiss="modal"> <spring:message code="popup.label.cancel" />
							</button>
						</div>
					</div>
				</div>
			</div>
			<!-- [End] Show dialog  -->
			<!-- [Start] Show dialog confirm delete newborns -->
				<div class="modal fade" id="deleteNewborns">
					<div class="modal-dialog modal-sm">
						<div class="modal-content">
							<!-- [Start] Header dialong -->
							<div class="modal-body">
								<button type="button" class="close" data-dismiss="modal">
									<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message
											code="popup.label.close" /></span>
								</button>
								<p>
									<spring:message code="re005.delete.child.confirm" />
								</p>
							</div>

							<div class="modal-footer" align="center">
								<sec:authorize ifAnyGranted="ROLE_FRONT_END">
									<button id="delete-borns" type="button" class="btn btn-success">
										<spring:message code="popup.label.comfirm" />
									</button>
								</sec:authorize>
								<button type="button" class="btn btn-default" data-dismiss="modal">
									<spring:message code="popup.label.cancel" />
								</button>
							</div>
						</div>
					</div>
				</div>
				<!-- [End] Show dialog  -->
</div>

<script>
	$(document).ready(function() {

		if ($("#isChangePass").val() == 'true') {
			document.getElementById("divShowChangePass").style.display = "block";
			document.getElementById("passWordOld").style.display = "none";
		}

		$("#changePassword").click(function() {
			$('#confirmChangePassword').modal('show');
		});

		$("#confirm-change-password").click(function() {
			$('#isChangePass').val('true');
			$('#confirmChangePassword').modal('hide');
// 			$('#divInputPassnew').removeAttr('style');
// 			$('#divConfirmChangePass').removeAttr('style');
			document.getElementById("divShowChangePass").style.display = "block";
			document.getElementById("passWordOld").style.display = "none";

		});

		$(".btn-delete").on("click", function(event) {
			var $target = $(event.currentTarget);
			var childId = $target.closest("tr").attr('data-id');
			var $confirmDialog = $('#deleteNewborns');
			$confirmDialog.attr('data-id', childId);
		});

		$("#delete-borns").click(function() {
			var childId = $('#deleteNewborns').attr('data-id');
			$.ajax({
				type : "post",
				url : "ajax-delete-child",
				data : JSON.stringify({
					'childId' : childId,
				}),
				dataType : "json",
				async : false,
				beforeSend: function(xhr) {
		            xhr.setRequestHeader("Accept", "application/json");
		            xhr.setRequestHeader("Content-Type", "application/json");
		        },
				success: function(response) {
					$('#deleteNewborns').modal('hide');
					if(response.status == 200) {
						$("table tbody tr[data-id='" + childId + "']").remove();
					}
					alertResponseMessage(response);

				},
				error: function(){
					// TODO: handle errors
					alert('Error while setting session');
				}
			});
		});
	});
</script>
