<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>

<div id="schedule-dept-and-doctor-wrapper" class="col-md-12"
	class="form-horizontal">
	<h2></h2>
	<div align="center">
		<p style="color: red;">${message}</p>
		<c:if test="${deleteHospital == true}">
			<p style="color: blue;">
				<spring:message code="be010.msg.delete.hospital.succ" />
			</p>
		</c:if>
		<c:if test="${deleteHospital == false}">
			<p style="color: red;">
				<spring:message code="be010.msg.error.delete.hospital" />
			</p>
		</c:if>
		<c:if test="${deleteDepartment == true}">
			<p style="color: blue;">
				<spring:message code="be010.msg.delete.dept.succ" />
			</p>
		</c:if>
		<c:if test="${deleteDepartment == false}">
			<p style="color: red;">
				<spring:message code="be010.msg.error.delete.dept" />
			</p>
		</c:if>
		<c:if test="${updateJuniorDoctor == true}">
			<p style="color: blue;">
				<spring:message code="be010.msg.update.junior.doctor.succ" />
			</p>
		</c:if>
		<c:if test="${updateJuniorDoctor == false}">
			<p style="color: red;">
				<spring:message code="be010.msg.error.update.junior.doctor" />
			</p>
		</c:if>
		<c:if test="${deleteDoctor == true}">
			<p style="color: blue;">
				<spring:message code="be014.msg.delete.doctor.success" />
			</p>
		</c:if>
		<c:if test="${deleteDoctor == false}">
			<p style="color: red;">
				<spring:message code="be014.msg.delete.doctor.fail" />
			</p>
		</c:if>
		<c:if test="${existReservation == true}">
			<p style="color: red;">
				<spring:message code="be010.msg.error.exist_reservation" />
			</p>
		</c:if>
	</div>
	<div id="divViewDeptAndDoctor">
	<table id="tblContent" class="table table-bordered">
		<c:forEach items="${listHospitalModel}" var="hospital" varStatus="status">
			<tr class="info">
				<td>
					<span class="hospital-name">${hospital.hospitalName}</span>
				</td>
				<td align="center">
					<c:if test="${status.index == 0}">
						<span><spring:message code="be010.title.deptCode" /></span>
					</c:if>		
				</td>
				<td align="center">
					<c:if test="${status.index == 0}">
						<span><spring:message code="be010.title.kpi" /></span>
					</c:if>		
				</td>
				<td align="center">
					<c:if test="${status.index == 0}">
						<spring:message code="be010.title.new" />
					</c:if>	
				</td>
				<td align="center">
					<sec:authorize ifAnyGranted="ROLE_SCHEDULE">
					<a href="<c:url value='/schedule/add-department?hospitalId=${hospital.hospitalId}'/>" class="btn btn-default extend-btn">
						<spring:message code="be010.add.dept" />
					</a>
					</sec:authorize>
				</td>
				<td align="center">
					<sec:authorize ifAnyGranted="ROLE_SCHEDULE">
					<a class="btn btn-default extend-btn hospital-delete" data-id="${hospital.hospitalId}">
						<spring:message code="be010.delete.hospital" />
					</a>
					</sec:authorize>
				</td>
			</tr>
			<c:forEach items="${hospital.departments}" var="department">
				<tr class="success">
					<td class="tdDepartment"> 
						<span class="department-name">${department.deptName}</span>
					</td>
					<td class=""><span class="department-name">${department.deptCode}</td>
					<td></td>
					<td></td>
					<td align="center">
						<sec:authorize ifAnyGranted="ROLE_SCHEDULE">
						<a class="btn btn-default extend-btn department-delete" data-id="${department.deptId}">
							<spring:message code="be010.delete.dept" />
						</a>
						</sec:authorize>
					</td>
					<td align="center">
						<sec:authorize ifAnyGranted="ROLE_SCHEDULE">
						<a href="<c:url value='/schedule/add-doctor?hospitalId=${hospital.hospitalId}&deptId=${department.deptId}'/>" class="btn btn-default extend-btn">
							<spring:message code="be010.add.doctor" />
						</a>
						</sec:authorize>
					</td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td></td>
					<td></td>
					<td></td>
					<td></td>
				</tr>
				<c:set var="listDoctor" value="${hospital.mapDeptIdWithListDoctor.get(department.deptId)}" />
				<c:forEach items="${listDoctor}" var="doctor">
					<tr class="active">
						<td class="tdDoctor"><span class="doctor-name">${doctor.name}</span></td>
						<td></td>
						<td align="center">${doctor.kpiAvg}</td>
						<td align="center">
							<sec:authorize ifAnyGranted="ROLE_SCHEDULE">
								<c:if test="${doctor.juniorFlg == 1}">
									<input class="update-junior-flg-doctor" type="checkbox" checked="checked" data-id="${doctor.doctorId}" />
								</c:if>
								<c:if test="${doctor.juniorFlg == 0}">
									<input class="update-junior-flg-doctor" type="checkbox" data-id="${doctor.doctorId}" />
								</c:if>
							</sec:authorize>
						</td>
						<td align="center">
							<sec:authorize ifAnyGranted="ROLE_SCHEDULE">
							<a class="btn btn-default extend-btn deleteDoctor">
								<span style="display: none">${doctor.doctorId}</span>&nbsp;
								<spring:message code="be010.delete.doctor" />
							</a>
							</sec:authorize>
						</td>
						<td></td>
					</tr>
				</c:forEach>
			</c:forEach>
		</c:forEach>
	</table>
	</div>
	<sec:authorize ifAnyGranted="ROLE_SCHEDULE">
	<div class="form-group" align="center">
		<p></p>
		<a href="<c:url value="/schedule/add-doctor-csv" />" class="btn btn-success"><spring:message code="be010.import.dept.doctor" /></a>
		<a href="<c:url value="/schedule/export-doctor-csv" />" class="btn btn-success"><spring:message code="be010.export.dept.doctor" /></a>
	</div>
	</sec:authorize>
	<!-- [Start] Show dialog confirm delete hospital -->
	<div class="modal fade" id="confirmDeleteHospital">
		<div class="modal-dialog modal-sm">
			<div class="modal-content">
				<!-- [Start] Header dialong -->
				<div class="modal-body">
					<button type="button" class="close" data-dismiss="modal">
						<span aria-hidden="true">&times;</span><span class="sr-only"></span>
					</button>
					<p>
						<spring:message code="be010.modal.delete.hospital" />
					</p>
				</div>

				<div class="modal-footer" align="center">
					<button id="deleteHospitalId" onclick="doDeleteHospital()"
						class="btn btn-success">
						<spring:message code="popup.label.comfirm" />
					</button>
					<button type="button" class="btn btn-default"
						data-dismiss="modal">
						<spring:message code="popup.label.cancel" />
					</button>
				</div>
			</div>
		</div>
	</div>
	<!-- [End] Show dialog  -->

	<!-- [Start] Show dialog confirm delete department -->
	<div class="modal fade" id="confirmDeleteDepartment">
		<div class="modal-dialog modal-sm">
			<div class="modal-content">
				<!-- [Start] Header dialong -->
				<div class="modal-body">
					<button type="button" class="close" data-dismiss="modal">
						<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message
								code="popup.label.close" /></span>
					</button>
					<p>
						<spring:message code="be010.modal.delete.dept" />
					</p>
				</div>

				<div class="modal-footer" align="center">
					<button id="deleteDepartmentId" onclick="doDeleteDepartment()"
						class="btn btn-success">
						<spring:message code="popup.label.comfirm" />
					</button>
					<button type="button" class="btn btn-default"
						data-dismiss="modal">
						<spring:message code="popup.label.cancel" />
					</button>
				</div>
			</div>
		</div>
	</div>
	<!-- [End] Show dialog  -->

	<!-- [Start] Show dialog confirm update junior for dortor -->
	<div class="modal fade" id="confirmUpdateJuniorFlgForDoctor">
		<div class="modal-dialog modal-sm">
			<div class="modal-content">
				<!-- [Start] Header dialong -->
				<div class="modal-body">
					<button type="button" class="close" data-dismiss="modal">
						<span aria-hidden="true">&times;</span><span class="sr-only"></span>
					</button>
					<p>
						<spring:message code="be010.set.new.doctor" />
					</p>
				</div>

				<div class="modal-footer" align="center">
					<button id="updateFlgForDoctor" onclick="doUpdateFlgForDoctor()"
						class="btn btn-success">
						<spring:message code="popup.label.comfirm" />
					</button>
					<button type="button" class="btn btn-default cancle-select"
						data-dismiss="modal">
						<spring:message code="popup.label.cancel" />
					</button>
				</div>
			</div>
		</div>
	</div>
	<!-- [End] Show dialog  -->
</div>
<script type="text/javascript"
	src="<c:url value='/assets/js/schedule/ScheduleDeptAndDoctorList.js'/>">
</script>