<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib prefix="sec"
	uri="http://www.springframework.org/security/tags"%>

<c:forEach items="${hospitalInfoList}" var="hospitalInfo">
	<div class="text-content">
		<%-- <p>
			<spring:message code="fe001.label.urgent_case"
				arguments="${hospitalInfo.hospital.hospitalName}" />
		</p> --%>
		<p>
			<spring:message code="fe001.label.unknown_department" />
		</p>
	</div>
	<p class="lead">
		<span class="hospital-name">${hospitalInfo.hospital.hospitalName}</span>
	</p>
	<div class="row" id = "department">
		<c:choose>
			<c:when test="${isKcck}">
				<div class="col-md-4">
			</c:when>
			<c:when test="${not isReExamMode}">
				<div class="col-md-4">
					<div class="department-content">
						<span><spring:message
								code="general.label.internal_department" /></span>
					</div>
			</c:when>
			<c:otherwise>
				<div class="col-md-6">
					<div class="department-content">
						<span><spring:message
								code="general.label.internal_department" /></span>
					</div>
			</c:otherwise>
		</c:choose>
		<c:if test="${hospitalInfo.internalDepts.size() > 0 }">
			<ul class="list-group">
				<c:forEach items="${hospitalInfo.internalDepts}" var="department">
					<li class="list-group-item"><a
							href="<c:url value='/booking/booking-time?deptId=${department.deptId}' > <c:param name="deptType" value="${department.deptType}"/></c:url>">${department.deptName}</a></li>
				</c:forEach>
			</ul>
		</c:if>

	</div>
	<c:choose>
		<c:when test="${isKcck}">
			<div class="col-md-4">
		</c:when>
		<c:when test="${not isReExamMode}">
			<div class="col-md-4">
				<div class="department-content">
					<span><spring:message
							code="general.label.surgery_department" /></span>
				</div>
		</c:when>
		<c:otherwise>
			<div class="col-md-6">
				<div class="department-content">
					<span><spring:message
							code="general.label.surgery_department" /></span>
				</div>
		</c:otherwise>
	</c:choose>
	<c:if test="${hospitalInfo.surgeryDepts.size() > 0 }">
		<ul class="list-group">
			<c:forEach items="${hospitalInfo.surgeryDepts}" var="department">
				<c:choose>
					<c:when test="${department.deptType == 3 }">
						<sec:authorize ifAnyGranted="ROLE_FRONT_END">
							<li class="list-group-item"><a
								href="<c:url value='/booking/booking-time?deptId=${department.deptId}'  > <c:param name="deptType" value="${department.deptType}"/></c:url>">${department.deptName}</a></li>
						</sec:authorize>
						<sec:authorize ifNotGranted="ROLE_FRONT_END">
							<li class="list-group-item"><a
								href="<c:url value='/booking/login?deptId=${department.deptId}'  > <c:param name="deptType" value="${department.deptType}"/></c:url>">${department.deptName}</a></li>
						</sec:authorize>
					</c:when>
					<c:otherwise>
						<li class="list-group-item"><a
							href="<c:url value='/booking/booking-time?deptId=${department.deptId}' > <c:param name="deptType" value="${department.deptType}"/></c:url>">${department.deptName}</a></li>
					</c:otherwise>
				</c:choose>
			</c:forEach>
		</ul>
	</c:if>
	</div>
	<c:choose>
		<c:when test="${not isReExamMode}">
			<div class="col-md-4">

				<c:choose>
					<c:when test="${not isKcck}">
						<div class="department-content">
							<span><spring:message code="general.label.other" /></span>
						</div>
						<c:if test="${hospitalInfo.vaccineDepts.size() > 0 || hospitalInfo.newBorns.size() > 0 }">
							<ul class="list-group">
								<c:forEach items="${hospitalInfo.vaccineDepts}" var="department">
									<sec:authorize ifAnyGranted="ROLE_FRONT_END">
										<li class="list-group-item"><a
											href="<c:url value='/booking/booking-time?deptId=${department.deptId}' />">${department.deptName}</a></li>
									</sec:authorize>
									<sec:authorize ifNotGranted="ROLE_FRONT_END">
										<li class="list-group-item"><a
											href="<c:url value='/booking/login?deptId=${department.deptId}' />">${department.deptName}</a></li>
									</sec:authorize>
								</c:forEach>
								<c:forEach items="${hospitalInfo.newBorns}" var="department">
									<sec:authorize ifAnyGranted="ROLE_FRONT_END">
										<li class="list-group-item"><a
											href="<c:url value='/booking/booking-time?deptId=${department.deptId}' />">${department.deptName}</a></li>
									</sec:authorize>
									<sec:authorize ifNotGranted="ROLE_FRONT_END">
										<li class="list-group-item"><a
											href="<c:url value='/booking/login?deptId=${department.deptId}' />">${department.deptName}</a></li>
									</sec:authorize>
								</c:forEach>
							</ul>
						</c:if>
					</c:when>
					<c:otherwise>
						<c:if test="${hospitalInfo.vaccineDepts.size() > 0 }">
							<ul class="list-group">
								<c:forEach items="${hospitalInfo.vaccineDepts}" var="department">
									<c:choose>
										<c:when test="${department.deptType == 2 || department.deptType == 3}">
											<sec:authorize ifAnyGranted="ROLE_FRONT_END">
												<li class="list-group-item"><a
														href="<c:url value='/booking/booking-time?deptId=${department.deptId}'  > <c:param name="deptType" value="${department.deptType}"/></c:url>">${department.deptName}</a></li>
											</sec:authorize>
											<sec:authorize ifNotGranted="ROLE_FRONT_END">
												<li class="list-group-item"><a
														href="<c:url value='/booking/login?deptId=${department.deptId}'  > <c:param name="deptType" value="${department.deptType}"/></c:url>">${department.deptName}</a></li>
											</sec:authorize>
										</c:when>
										<c:otherwise>
											<li class="list-group-item"><a
													href="<c:url value='/booking/booking-time?deptId=${department.deptId}'  > <c:param name="deptType" value="${department.deptType}"/></c:url>">${department.deptName}</a></li>
										</c:otherwise>
									</c:choose>

								</c:forEach>
							</ul>
						</c:if>
					</c:otherwise>
				</c:choose>

			</div>
		</c:when>
		<c:otherwise>
			<c:if test="${isKcck}">
				<div class="col-md-4">
					<c:if test="${hospitalInfo.vaccineDepts.size() > 0 }">
						<ul class="list-group">
							<c:forEach items="${hospitalInfo.vaccineDepts}" var="department">
								<li class="list-group-item"><a href="<c:url value='/booking/booking-time?deptId=${department.deptId}' ><c:param name="deptType" value="${department.deptType}"/></c:url>">${department.deptName}</a></li>
							</c:forEach>
						</ul>
					</c:if>
			</c:if>
		</c:otherwise>
	</c:choose>
	</div>
</c:forEach>

<c:if test="${latestReservations != null}">
	<div class="col-md-10">
	<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
		<span>${patientCode} <spring:message code="fe001.label.latest_reservation" />
		</span>
		<% } else { %>
		<span><spring:message code="fe001.label.latest_reservation" />:
		${patientCode}
		</span>
		<% } %>
		<c:forEach items="${latestReservations}" var="res">
			<div>
				<%-- <div>
					<span><spring:message code="fe001.label.reservation_code" />:
						${res.reservationCode}</span>
				</div> --%>
				<div>
					<span> <spring:message code="fe001.label.department" />: <a
						href="<c:url value='/booking/booking-time?deptId=${res.deptId}&deptType=${res.deptType}' />">${res.deptName}</a>
					</span>
				</div>
				<div>
					<span><spring:message code="fe001.label.reservation_date" />:
						${res.formattedReservationDate} </span> <span> <spring:message
							code="fe001.label.reservation_time" />:
						${res.formattedReservationTime}
					</span>
				</div>
				<div>
					<spring:message code="fe001.label.doctor" />
					: ${res.doctorName}
				</div>
			</div>
			<br />
			<br />
		</c:forEach>
	</div>
</c:if>
<script type = "text/javascript">
	$(document).ready(function(){
		var isMobile = MssUtils.detectmob();
		if(isMobile)
			{ 
			MssUtils.focusIncaseMobile('#department');
			}
	});
	
</script>
