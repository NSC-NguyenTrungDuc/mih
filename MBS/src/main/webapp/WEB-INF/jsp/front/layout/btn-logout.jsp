<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<c:url var="logoutURL" value="/booking/logout"/>
<c:url var="loginURL" value="/booking/login"/>
<c:url var="registerUrl" value="/booking/register"/>

<c:choose>
	<c:when test="${pageContext.request.userPrincipal.name != null}">
		<li class="header-btn"><a href="${logoutURL}" class="header-btn-text"><i class="fa fa-sign-out"></i> <spring:message code="general.button.logout"/></a></li>
	</c:when>
	<c:otherwise>
		<li class="header-btn"><a href="${loginURL}" class="header-btn-text"><i class="fa fa-sign-in"></i> <spring:message code="general.button.login"/></a></li>
		<li class="header-btn"><a href="${registerUrl}" class="header-btn-text"><i class="fa fa-user"></i> <spring:message code="general.button.register"/></a></li>
	</c:otherwise>
</c:choose>