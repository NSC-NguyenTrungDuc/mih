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
    
    <div class="all"> <!-- BEGIN the wrapper for Menu Off Canvas -->   
		<!-- BEGIN HEADER -->
		<header id="header">
			<tiles:insertAttribute name="header" />
		</header>
		<!-- END HEADER --> 
		<!-- BEGIN Page Section -->
		<div class="page-section">
		  <!-- BEGIN Page Header -->
		  <header class="page-header">
			<div class="container">
			  <div class="row">
				<div class="col-md-12">
				  <c:set var="mainTitle"><tiles:insertAttribute name="menu-main-title" ignore="true" /></c:set>
				  <h3 class="page-title"><c:if test="${not empty mainTitle}"><spring:message code="${mainTitle}"/></c:if></h3>
				</div>
			  </div>
			</div>
		  </header><!-- END Page Header -->
		  <!-- BEGIN Nav Tabs -->
		  <nav class="nav-tabs">
			<div class="container">
			  <div class="row">
				<div class="col-md-12">
				  <ul class="nav-tabs-list clearfix">
					<c:set var="subTitle"><tiles:insertAttribute name="menu-sub-title" ignore="true" /></c:set>
					<c:choose>
						<c:when test="${subTitle != ''}">
							<li class="active"><a href="javascript:void(0)"><spring:message code="${subTitle}" /></a></li>
						</c:when>
						<c:otherwise>
							<c:set var="menuSubCurrent"><tiles:insertAttribute name="menu-sub-current" ignore="true" /></c:set>
							<li class="${menuSubCurrent == '1' ? 'active' : ''}"><a href="${ctx}/service/registration-for-test"><spring:message code="general.menu.sign-up.registration-for-test"/></a></li>
							<li class="${menuSubCurrent == '2' ? 'active' : ''}"><a href="${ctx}/it-organization/contact-us"><spring:message code="general.menu.sign-up.contact-us"/></a></li>
							<li class="${menuSubCurrent == '3' ? 'active' : ''}"><a href="${ctx}/to-patient/patient-register"><spring:message code="general.menu.sign-up.patient-register"/></a></li>
						</c:otherwise>
					</c:choose>
				  </ul>
				</div>
			  </div>
			</div>  
		  </nav><!-- END Nav Tabs -->
		  <!-- BEGIN Page Main -->
		  <div class="page-main">
			<div class="container">
			  <div class="row">
				<tiles:insertAttribute name="body" />
			  </div>
			</div>
		  </div><!-- END Page Main -->
		</div><!-- END Page Section -->
		
		<tiles:insertAttribute name="footer" />
	</div> <!-- END the wrapper for Menu Off Canvas -->
	
	<tiles:insertAttribute name="menu" />
	
	<tiles:importAttribute name="js"/>
	<c:forEach var="item" items="${js}">
		<script src="<c:url value='${item}'/>" type="text/javascript"></script>
	</c:forEach>
</body>
</html>
