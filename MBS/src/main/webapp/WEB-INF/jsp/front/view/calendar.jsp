<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<html>
	<body>
		<div id="serverAddress" style="display:none">${serverAddress}</div>
		<div id="hospitalCode" style="display:none">${hospitalCode}</div>
		<div id="deptCode" style="display:none">${deptCode}</div>
		<div id="weekView" style="display:none"><c:url value="calendar-week"/></div>
		<div id='calendar'></div>
		
		<script type="text/javascript" src="<c:url value='/assets/plugins/fullcalendar/fullcalendar.js' />" ></script>
		<script type="text/javascript" src="<c:url value='/assets/js/calendar.js' />" ></script>
		<script type="text/javascript" src="<c:url value='/assets/js/MssUtils.js' />" ></script>
	</body>
</html>