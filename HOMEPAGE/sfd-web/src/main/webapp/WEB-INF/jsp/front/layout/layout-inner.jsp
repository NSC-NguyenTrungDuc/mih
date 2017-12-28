<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://tiles.apache.org/tags-tiles" prefix="tiles"%>
<%@ include file="/WEB-INF/jsp/front/includes/taglibs.jsp"%>
<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7" lang=""> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8" lang=""> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9" lang=""> <![endif]-->
<!--[if gt IE 8]><!--> <html class="no-js" lang=""> <!--<![endif]-->
<head>
	<meta charset="utf-8" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	<title><spring:message code="general.title"/></title>
	<meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">

	<tiles:importAttribute name="css"/>
	<c:forEach var="item" items="${css}">
		<link rel="stylesheet" href="<c:url value='${item}'/>" type="text/css" media="all" />
	</c:forEach>

	<link rel="shortcut icon" href="<c:url value='/assets/img/favicon.ico'/>" type="image/x-icon">
	<link rel="icon" href="<c:url value='/assets/img/favicon.ico'/>" type="image/x-icon">
	<link rel="apple-touch-icon" href="<c:url value='/assets/img/apple-touch-icon.png'/>">
</head>
<body>
	<!--[if lt IE 8]>
        <p class="browserupgrade">You are using an <strong>outdated</strong> browser. Please <a href="http://browsehappy.com/">upgrade your browser</a> to improve your experience.</p>
    <![endif]-->

    <%--<div class="all"> <!-- BEGIN the wrapper for Menu Off Canvas -->--%>

		  <%--<div class="page-main">--%>
			<%--<div class="container">--%>
			  <%--<div class="row">--%>
				<tiles:insertAttribute name="body" />
			  <%--</div>--%>
			<%--</div>--%>
		  <%--</div><!-- END Page Main -->--%>
		<%--</div><!-- END Page Section -->--%>


	<%--</div> <!-- END the wrapper for Menu Off Canvas -->--%>



	<tiles:importAttribute name="js"/>
	<c:forEach var="item" items="${js}">
		<script src="<c:url value='${item}'/>" type="text/javascript"></script>
	</c:forEach>
</body>
</html>
