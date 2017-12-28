<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>

<h2><spring:message code="fe031.title.messages" /></h2>
<p class="lead">
	<span class="hospital-name">${hospitalName}</span>, 
	<span class="department-name">${department.deptName}</span>
</p>
<p><span><spring:message code="fe031.info.label.status.today" /></span></p>
<p><span><spring:message code="fe031.info.label.time.now" /> ${currentTime} </span></p>
<p>
	<c:choose>
		<c:when test="${timePending != null && timePending != ''}">
			<span><spring:message code="fe031.info.label.status.receive.now" /> : </span>
			<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
			<span> ${timePending} <spring:message code="fe031.info.label.checking.health.now" /></span>	
			<% } else { %>
			<span><spring:message code="fe031.info.label.checking.health.now" /> ${timePending} </span>	
			<% } %>
		</c:when>
		<c:otherwise>
			<span><spring:message code="fe031.info.label.checking.no.pending" /></span>	
		</c:otherwise>
	</c:choose>
</p>
<p>
	<c:choose>
		<c:when test="${lateStr != null}">
			<span><spring:message code="fe031.info.label.late.status.now" /> : </span><span>${lateStr}</span><spring:message code="fe031.info.label.late.status.minute" />
		</c:when>
	</c:choose>
</p>
