<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>

<c:url var="logoutURL" value="/back/logout"/>
<!-- ========== START HEADER ========== -->
	<li class="header-btn"><a href="${logoutURL}" class="logout-text"><i class="fa fa-sign-out"></i> <spring:message code="general.button.logout"/></a></li>
<!-- ========== END HEADER ========== -->