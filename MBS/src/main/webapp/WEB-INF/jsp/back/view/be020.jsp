<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<c:url var="registerComaURL" value="schedule-register-default-coma" />
<c:url var="addComaURL" value="schedule-adding-coma" />
<c:url var="deleteComaURL" value="schedule-delete-coma-info" />
<h3 class="hospital-content">
	<spring:message code="be020.title.inform" />
</h3>
<c:forEach items="${hospitalInfoList}" var="hospitalInfo">
	<p class="lead">
		<span class="hospital-content">${hospitalInfo.hospital.hospitalName}</span>
	</p>
	<div class="row">
		<div class="col-md-4">
			<c:if test="${not isKcck }">
				<span><spring:message
						code="general.label.internal_department" /></span>
			</c:if>
			<c:if test="${hospitalInfo.internalDepts.size() > 0}">
				<ul class="list-group">
					<c:forEach items="${hospitalInfo.internalDepts}" var="department"
						varStatus="row">
						<li class="list-group-item">
							<div style="overflow: hidden;">
								<div style="float: left; clear: right;">${department.deptName}</div>
								<div style="float: right; clear: left;">
									<a class="link-dept"
										href="${registerComaURL}?deptId=${department.deptId}"><spring:message
											code="be020.label.register" /></a>&nbsp;&nbsp; <a
										class="link-dept"
										href="${addComaURL}?deptId=${department.deptId}"><spring:message
											code="be020.label.add" /></a>&nbsp;&nbsp; <a class="link-dept"
										href="${deleteComaURL}?deptId=${department.deptId}"><spring:message
											code="be020.label.delete" /></a>
								</div>
							</div>
						</li>
					</c:forEach>
				</ul>
			</c:if>
		</div>
		<div class="col-md-4">
			<c:if test="${not isKcck }">
				<span><spring:message code="general.label.surgery_department" /></span>
			</c:if>
			<c:if test="${hospitalInfo.surgeryDepts.size() > 0}">
				<ul class="list-group">
					<c:forEach items="${hospitalInfo.surgeryDepts}" var="department"
						varStatus="row">
						<li class="list-group-item">
							<div style="overflow: hidden;">
								<div style="float: left; clear: right;">${department.deptName}</div>
								<div style="float: right; clear: left;">
									<a class="link-dept"
										href="${registerComaURL}?deptId=${department.deptId}"><spring:message
											code="be020.label.register" /></a>&nbsp;&nbsp; <a
										class="link-dept"
										href="${addComaURL}?deptId=${department.deptId}"><spring:message
											code="be020.label.add" /></a>&nbsp;&nbsp; <a class="link-dept"
										href="${deleteComaURL}?deptId=${department.deptId}"><spring:message
											code="be020.label.delete" /></a>
								</div>
							</div>
						</li>
					</c:forEach>
				</ul>
			</c:if>
		</div>
		<div class="col-md-4">
			<c:if test="${not isKcck }">
				<span><spring:message code="general.label.other" /></span>
			</c:if>
			<c:if test="${hospitalInfo.vaccineDepts.size() > 0 || hospitalInfo.newBorns.size() > 0 }">
				<ul class="list-group">
					<c:forEach items="${hospitalInfo.vaccineDepts}" var="department"
						varStatus="row">
						<li class="list-group-item">
							<div style="overflow: hidden;">
								<div style="float: left; clear: right;">${department.deptName}</div>
								<div style="float: right; clear: left;">
									<a class="link-dept"
										href="${registerComaURL}?deptId=${department.deptId}"><spring:message
											code="be020.label.register" /></a>&nbsp;&nbsp; <a
										class="link-dept"
										href="${addComaURL}?deptId=${department.deptId}"><spring:message
											code="be020.label.add" /></a>&nbsp;&nbsp; <a class="link-dept"
										href="${deleteComaURL}?deptId=${department.deptId}"><spring:message
											code="be020.label.delete" /></a>
								</div>
							</div>
						</li>
					</c:forEach>
					<c:forEach items="${hospitalInfo.newBorns}" var="department"
						varStatus="row">
						<li class="list-group-item">
							<div style="overflow: hidden;">
								<div style="float: left; clear: right;">${department.deptName}</div>
								<div style="float: right; clear: left;">
									<a class="link-dept"
										href="${registerComaURL}?deptId=${department.deptId}"><spring:message
											code="be020.label.register" /></a>&nbsp;&nbsp; <a
										class="link-dept"
										href="${addComaURL}?deptId=${department.deptId}"><spring:message
											code="be020.label.add" /></a>&nbsp;&nbsp; <a class="link-dept"
										href="${deleteComaURL}?deptId=${department.deptId}"><spring:message
											code="be020.label.delete" /></a>
								</div>
							</div>
						</li>
					</c:forEach>
				</ul>
			</c:if>
		</div>
	</div>
</c:forEach>