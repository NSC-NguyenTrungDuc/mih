<%@ taglib uri="http://tiles.apache.org/tags-tiles" prefix="tiles"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/functions" prefix="fn" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<meta name="google-translate-customization" content="5f5f232222df11a9-d9e1df4798ed98e7-gba759a68952e18eb-11"></meta>
	<link href="<c:url value='/assets/bootstrap/css/bootstrap.min.css' />" rel="stylesheet">
	<link href="<c:url value='/assets/bootstrap/css/bootstrapValidator.css'/>" rel="stylesheet">
	<link href="<c:url value='/assets/bootstrap/css/font-awesome.min.css'/>" rel="stylesheet">
	<link href="<c:url value='/assets/css/main-front.css' />" rel="stylesheet">
	<link href="<c:url value='/assets/css/custom.css' />" rel="stylesheet">
	<link href="<c:url value='/assets/plugins/fullcalendar/fullcalendar.css' />" rel="stylesheet">
	<link href="<c:url value='/assets/images/MBS_favico.ico' />" type="image/x-icon" rel="icon">
	
	<script type="text/javascript" src="<c:url value='/assets/js/lib/jquery-1.8.0.min.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/bootstrap/js/bootstrap.min.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/Constants.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/lib/handlebars-v1.3.0.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/HandlebarsHelpers.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/CookiesUtils.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/lib/culture-info.js' />"></script>
	<script type="text/javascript" src="<c:url value='/assets/js/lib/date.js' />"></script>
</head>
<body>
	<tiles:insertAttribute name="body" />
</body>
</html>