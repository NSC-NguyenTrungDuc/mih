<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@ taglib prefix="sec"
	uri="http://www.springframework.org/security/tags"%>

<h2>
	<spring:message code="fe030.title.messages" />
</h2>
<c:forEach items="${hospitalInfoList}" var="hospitalInfo">
	<p class="lead">
		<span class="hospital-name">${hospitalInfo.hospital.hospitalName}</span>
	</p>
	<div class="row">
		<c:choose>
			<c:when test="${isKcck}">
				<div class="col-md-4">
			</c:when>
			<c:otherwise>
				<div class="col-md-4">
					<div class="department-content">
						<span><spring:message
								code="general.label.internal_department" /></span>
					</div>
			</c:otherwise>
		</c:choose>
		<ul class="list-group">
			<c:forEach items="${hospitalInfo.internalDepts}" var="department">
				<li class="list-group-item"><a
					href="<c:url value='/booking/pending-status-detail?deptId=${department.deptId}' />">${department.deptName}</a></li>
			</c:forEach>
		</ul>
	</div>
	<div class="row">
		<c:choose>
			<c:when test="${isKcck}">
				<div class="col-md-4">
			</c:when>
			<c:otherwise>
				<div class="col-md-4">
					<div class="department-content">
						<span><spring:message
								code="general.label.surgery_department" /></span>
					</div>
			</c:otherwise>
		</c:choose>
		<ul class="list-group">
			<c:forEach items="${hospitalInfo.surgeryDepts}" var="department">
				<li class="list-group-item"><a
					href="<c:url value='/booking/pending-status-detail?deptId=${department.deptId}' />">${department.deptName}</a></li>
			</c:forEach>
		</ul>
	</div>
	<div class="row">
		<c:choose>
			<c:when test="${not isKcck}">
				<div class="col-md-4">
					<div class="department-content">
						<span><spring:message code="general.label.other" /></span>
					</div>
					<ul class="list-group">
						<c:forEach items="${hospitalInfo.vaccineDepts}" var="department">
							<sec:authorize ifAnyGranted="ROLE_FRONT_END">
								<li class="list-group-item"><a
									href="<c:url value='/booking/pending-status-detail?deptId=${department.deptId}' />">${department.deptName}</a></li>
							</sec:authorize>
							<sec:authorize ifNotGranted="ROLE_FRONT_END">
								<li class="list-group-item"><a
									href="<c:url value='/booking/login' />">${department.deptName}</a></li>
							</sec:authorize>
						</c:forEach>
						<c:forEach items="${hospitalInfo.newBorns}" var="department">
							<sec:authorize ifAnyGranted="ROLE_FRONT_END">
								<li class="list-group-item"><a
									href="<c:url value='/booking/pending-status-detail?deptId=${department.deptId}' />">${department.deptName}</a></li>
							</sec:authorize>
							<sec:authorize ifNotGranted="ROLE_FRONT_END">
								<li class="list-group-item"><a
									href="<c:url value='/booking/login' />">${department.deptName}</a></li>
							</sec:authorize>
						</c:forEach>
					</ul>
			</c:when>
			<c:otherwise>
				<div class="col-md-4">
					<ul class="list-group">
						<c:forEach items="${hospitalInfo.vaccineDepts}" var="department">
							<li class="list-group-item"><a
								href="<c:url value='/booking/pending-status-detail?deptId=${department.deptId}' />">${department.deptName}</a></li>
						</c:forEach>
					</ul>
			</c:otherwise>
		</c:choose>
	</div>
	</div>
</c:forEach>
