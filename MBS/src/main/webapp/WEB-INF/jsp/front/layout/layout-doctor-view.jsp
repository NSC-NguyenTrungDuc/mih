<%@ taglib uri="http://tiles.apache.org/tags-tiles" prefix="tiles"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/functions" prefix="fn"%>
<%@ page import="nta.mss.misc.common.MssContextHolder"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta name="google-translate-customization"
	content="5f5f232222df11a9-d9e1df4798ed98e7-gba759a68952e18eb-11"></meta>
<c:set var="titleKey">
	<tiles:insertAttribute name="title" ignore="true" />
</c:set>
<title><c:if test="${titleKey != ''}">
		<spring:message code="${titleKey}" />
	</c:if></title>
<link
	href="<c:url value='/assets/bootstrap/css/doctor-vendor/bootstrap.min.css' />"
	rel="stylesheet">
<link
	href="<c:url value='/assets/bootstrap/css/doctor-vendor/bootstrap-theme.min.css' />"
	rel="stylesheet">
<link
	href="<c:url value='/assets/bootstrap/css/doctor-vendor/font-awesome.min.css'/>"
	rel="stylesheet">
<link href="<c:url value='/assets/css/jquery.dataTables.min.css'/>"
	rel="stylesheet">
<link href="<c:url value='/assets/css/main-doctor.css' />"
	rel="stylesheet">
<link href="<c:url value='/assets/images/MBS_favico.ico' />"
	type="image/x-icon" rel="icon">

<script type="text/javascript"
	src="<c:url value='/assets/js/lib/doctor-vender/modernizr-2.8.3-respond-1.4.2.min.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/lib/doctor-vender/jquery-1.11.2.min.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/lib/jquery.nicescroll.min.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/lib/jquery-ui.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/bootstrap/js/bootstrap.min.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/lib/jquery.dataTables.min.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/lib/highcharts.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/lib/handlebars-v1.3.0.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/lib/placeholders.jquery.min.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/HandlebarsHelpers.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/CookiesUtils.js' />"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/MssUtils.js'/>"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/Constants.js'/>"></script>
<link href='//fonts.googleapis.com/css?family=Open+Sans'
	rel='stylesheet' type='text/css'>
<script type="text/javascript"
	src="<c:url value='/assets/js/doctor/CommonDoctor.js'/>"></script>
	 <script type="text/javascript"
	src="<c:url value='/assets/js/doctor/RecordRTC.js'/>"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/lib/fnReloadAjax.js' />"></script>
<script type="text/javascript" src="<c:url value='/assets/js/doctor/peer.js' />" ></script>
<script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min.js"></script>
<link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.css">
<script src="https://www.promisejs.org/polyfills/promise-6.1.0.js"></script>
</head>
<style>
div.select {
	display: inline-block;
	margin: 0 0 1em 0;
}

p.small {
	font-size: 0.7em;
}

label {
	width: 12em;
	display: inline-block;
}
</style>
<body>
	<header class="header">
		<tiles:insertAttribute name="header-doctor" />
	</header>
	<nav class="nav">
		<div class="container">
			<div class="row">
				<div class="col-md-3 col-sm-6">
					<span class="menu-toggle"><i class="fa fa-bars"></i> <spring:message
							code="general.button.main_menu" /></span>
				</div>
				<div class="col-md-9 col-sm-6">
					<!-- BEGIN Breadcrumbs -->
					<div class="breadcrumbs">
						<a href="<c:url value='/doctor/profile-info' />" class="home"><i
							class="fa fa-home"></i> <spring:message code="general.button.home" /></a>
					</div>
					<!-- END Breadcrumbs -->
					<!-- BEGIN User Panel -->
					<div class="user-panel">
						<!-- BEGIN User Info -->
						<div class="user-info">
							<span class="view"><spring:message code="fe15.field.viewing" /></span><span class="icon"><i
								class="fa fa-user"></i></span> <a  class="name"><%=MssContextHolder.getPatientName()%>
							    </a> <span class="small">(<%=MssContextHolder.getPatientCode()%>)</span>
						</div>
						<!-- END User Info -->
						<!-- BEGIN Search  -->
						<button class="btn btn-search" data-toggle="modal"
							data-target="#modalSearch">
							<i class="fa fa-search"></i>
						</button>
						<!-- END Search  -->
					</div>
					<!-- END User Panel -->
				</div>
			</div>
		</div>
	</nav>
	<jsp:include page="alerts.jsp" />
	<div class="main">
		<div class="container">
			<div class="row">
				<div class="col-md-3">
					<tiles:insertAttribute name="menu" />
				</div>
				<div class="col-md-9">
					<div class="section">
						<div class="section-header tab">
							<c:if test="${titleKey != ''}">
								<div class="section-title">
									<spring:message code="${titleKey}" />
								</div>
							</c:if>
						</div>
						<tiles:insertAttribute name="body" />
					</div>
				</div>
			</div>
		</div>
	</div>
	<tiles:insertAttribute name="footer-doctor" />
	
	<script>
		$(document).ready(
				function() {
					

					$('.col-pull').click(function() {
						$('.menu.list-group').slideToggle("fast");
					});
					var url = $(location).attr('protocol') + '//'
							+ $(location).attr('host') + '/landingpage/';
					$(".landingpage-url").attr("href", url);
					
				});
		$(".nicescroll").niceScroll({
			cursorcolor : "rgba(0,0,0,0.2)"
		});
		
	</script>
	
</body>
</html>
