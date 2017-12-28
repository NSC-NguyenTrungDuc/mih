<%@ taglib uri="http://tiles.apache.org/tags-tiles" prefix="tiles"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<meta name="google-translate-customization" content="5f5f232222df11a9-d9e1df4798ed98e7-gba759a68952e18eb-11"></meta>
	<c:set var="titleKey">
        <tiles:insertAttribute name="title" ignore="true" />
    </c:set>
	<title><c:if test="${titleKey != ''}"><spring:message code="${titleKey}" /></c:if></title>
	<link href="<c:url value='/assets/bootstrap/css/bootstrap.min.css' />" rel="stylesheet">
	<link href="<c:url value='/assets/bootstrap/css/bootstrap-editable.css'/>" rel="stylesheet">
	<link href="<c:url value='/assets/bootstrap/css/bootstrapValidator.css'/>" rel="stylesheet">
	<link href="<c:url value='/assets/bootstrap/css/font-awesome.min.css'/>" rel="stylesheet">
	<link href="<c:url value='/assets/css/booking-scroll.css' />" rel="stylesheet">
	<link href="<c:url value='/assets/css/main-back.css' />" rel="stylesheet">
	<link href="<c:url value='/assets/css/custom.css' />" rel="stylesheet">
	<link href="<c:url value='/assets/css/jquery-ui.css' />" rel="stylesheet">
	<link href="<c:url value='/assets/css/jquery.dataTables.css' />" rel="stylesheet">
	<link href="<c:url value='/assets/css/jquery.multiselect2side.css' />" rel="stylesheet">
	<link href="<c:url value='/assets/images/MBS_favico.ico' />" type="image/x-icon" rel="icon">
	
	<script type="text/javascript" src="<c:url value='/assets/js/lib/jquery-1.8.0.min.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/lib/jquery-ui.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/lib/jquery.dataTables.min.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/bootstrap/js/bootstrap.min.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/lib/handlebars-v1.3.0.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/lib/placeholders.jquery.min.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/HandlebarsHelpers.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/CookiesUtils.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/MssUtils.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/lib/jquery.multiselect2side.js' />" ></script>
</head>
<body>
	<header>
		<tiles:insertAttribute name="header" />
	</header>
	<div class="breadcrumbs">
		<div class="container">
			<div class="row">
				<div class="col-md-3 pull">
					<div class="col-pull"></div>
				</div>
				<div class="col-md-9 home-right"> 
					<div class="col-md-2 home"><a href="<c:url value='/booking-manage/search-booking' />" ><i class="fa fa-home"></i><spring:message code="general.button.home" /></a></div>
					<div class="col-md-9 home-right">
<%-- 						<ul><li class="arrow_box"><a href="" >${hospitalName}</a></li></ul> --%>
					</div>
				</div>
			</div>
		</div>
	</div>
	<jsp:include page="alerts.jsp" />
	<div class="wr-content">
		<div class="container">
			<div class="row">
				<div class="col-md-3 pull-r">
					<tiles:insertAttribute name="menu" />
				</div>
				<div class="col-md-9">
					<div class="content">
						<div class="tabs_container">
							<div class="tabs_title">
								<c:if test="${titleKey != ''}">
									<div class="tabs-one"><spring:message code="${titleKey}" /></div>
								</c:if>
							</div>
							<div class="tabs_content">
								<tiles:insertAttribute name="body" />
							</div>
						</div>
					</div>
				</div>
			</div>
			<hr>
		</div>
	</div>
	<tiles:insertAttribute name="footer" />
</body>
</html>