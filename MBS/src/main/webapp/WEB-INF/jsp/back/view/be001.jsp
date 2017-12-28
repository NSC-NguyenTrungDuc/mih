<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>

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
					<span><spring:message
							code="general.label.internal_department" /></span>
			</c:otherwise>
		</c:choose>
		<c:if test="${hospitalInfo.internalDepts.size() > 0}">
			<ul class="list-group">
				<c:forEach items="${hospitalInfo.internalDepts}" var="department">
					<li class="list-group-item"><a class="link-dept"
						href="<c:url value='/booking-manage/select-time?deptId=${department.deptId}' />">${department.deptName}</a></li>
				</c:forEach>
			</ul>
		</c:if>
	</div>
	<div class="row">
		<c:choose>
			<c:when test="${isKcck}">
				<div class="col-md-4">
			</c:when>
			<c:otherwise>
				<div class="col-md-4">
					<span><spring:message
							code="general.label.surgery_department" /></span>
			</c:otherwise>
		</c:choose>
		<c:if test="${hospitalInfo.surgeryDepts.size() > 0}">
			<ul class="list-group">
				<c:forEach items="${hospitalInfo.surgeryDepts}" var="department">
					<li class="list-group-item"><a class="link-dept"
						href="<c:url value='/booking-manage/select-time?deptId=${department.deptId}' />">${department.deptName}</a></li>
				</c:forEach>
			</ul>
		</c:if>
	</div>
	<div class="row">
		<c:choose>
			<c:when test="${isKcck}">
				<div class="col-md-4">
					<c:if test="${hospitalInfo.vaccineDepts.size() > 0 }">
						<ul class="list-group">
							<c:forEach items="${hospitalInfo.vaccineDepts}" var="department">
								<li class="list-group-item"><a class="link-dept"
									href="<c:url value='/booking-manage/select-time?deptId=${department.deptId}' />">${department.deptName}</a></li>
							</c:forEach>
						</ul>
					</c:if>
				</div>
			</c:when>
			<c:otherwise>
				<div class="col-md-4">
					<span><spring:message code="general.label.other" /></span>
					<c:if test="${hospitalInfo.vaccineDepts.size() > 0 || hospitalInfo.newBorns.size() > 0 }">
						<ul class="list-group">
							<c:forEach items="${hospitalInfo.vaccineDepts}" var="department"
								varStatus="row">
								<li class="list-group-item"><a class="link-dept"
									href="<c:url value='/booking-manage/booking-vaccine' />">${department.deptName}</a></li>
							</c:forEach>
							<c:forEach items="${hospitalInfo.newBorns}" var="department"
								varStatus="row">
								<li class="list-group-item"><a class="link-dept"
									href="<c:url value='/booking-manage/select-time?deptId=${department.deptId}' />">${department.deptName}</a></li>
							</c:forEach>
						</ul>
					</c:if>
				</div>
			</c:otherwise>
		</c:choose>
</c:forEach>
<script>
	$(document).ready(function() {
		localStorage.removeItem("currentDate");
		localStorage.removeItem("selectedDoctor");
	});
</script>