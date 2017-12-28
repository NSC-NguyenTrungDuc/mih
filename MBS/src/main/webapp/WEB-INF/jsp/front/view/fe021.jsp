<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>

<div class="text-content">
	<c:choose>
		<c:when test="${notReservation == true}">
			<p><spring:message code="fe021.message.notReservation" /></p>
		</c:when>
		<c:otherwise>
			<p><spring:message code="fe021.message.inform.one" /></p>
			<p><spring:message code="fe021.message.inform.two" /></p>
			<p><spring:message code="fe021.message.inform.three" /></p>
			<p><spring:message code="fe021.message.inform.four" /></p>
		</c:otherwise>
	</c:choose>
</div>