<%@ taglib uri="http://tiles.apache.org/tags-tiles" prefix="tiles"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><spring:message code="error.404.title" /></title>
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta name="google-translate-customization" content="5f5f232222df11a9-d9e1df4798ed98e7-gba759a68952e18eb-11"></meta>
<link href="<c:url value='/assets/bootstrap/css/bootstrap.min.css' />" rel="stylesheet">
<link href="<c:url value='/assets/bootstrap/css/bootstrap-theme.min.css' />" rel="stylesheet">
<link href="<c:url value='/assets/bootstrap/css/bootstrapValidator.css'/>" rel="stylesheet">
<link href="<c:url value='/assets/bootstrap/css/font-awesome.min.css'/>" rel="stylesheet">
<link href="<c:url value='/assets/css/main-back.css' />" rel="stylesheet">
<%-- <link href="<c:url value='/assets/css/custom.css' />" rel="stylesheet"> --%>
	
<!-- <link rel="stylesheet" href="css/bootstrap.min.css">
<link rel="stylesheet" href="css/bootstrapValidator.css"/>
<link rel="stylesheet" href="css/bootstrap-theme.min.css">
<link rel="stylesheet" href="css/font-awesome.min.css">
<link rel="stylesheet" href="css/main.css"> -->
</head>
<body>
<!-- HEADER-->
<header>
	<div class="container">
		<div class="row">
			<div class="col-md-4">
				<%--<h1> <a href=""><img src="<c:url value="/assets/images/logo.png" />" alt="" /></a></h1>--%>
					<h1 style="height: 39px"> </h1>
			</div>
            
		</div>
	</div>
</header>

<!-- END HEADER-->
<!-- CONTENT-->

<div class="wr-content">
	<div class="container">
		<div class="row">
        	<!-- Error Page -->
            <div class="col-md-5 col-xs-offset-4">
            	<div class="error-page" align="center">  
                	<p class="error-sorry"><spring:message code="general.error.500.label"/></p>  
                    <h1 class="error-type">404<span><spring:message code="general.error.500.msg"/></span></h1>   
                    
                    <%--<p class="error-reason"><spring:message code="general.error.500.error.reason"/><br /><a href="#"><spring:message code="general.error.500.home.page"/></a><spring:message code="general.error.500.go.our"/><a href="#"><spring:message code="general.error.500.previours"/></a><spring:message code="general.error.500.go.previours"/></p>     --%>
                </div>                                
            </div>
		</div>
	</div>
</div>
<!-- END CONTENT-->

<!-- FOOTER-->
<footer class="footer hidden-print" id="footer">
	<div class="container text-center">
    	<div><!--<i class="fa fa-hospital-o"></i> <a href="#">Kobari Hospital</a>.--> Copyright <a href="https://www.sofiamedix.vn/">Sofiamedix</a> ©. All Rights Reserved</div>
  	</div>
</footer>
<!-- END FOOTER-->
<script type="text/javascript" src="<c:url value='/assets/js/lib/jquery-1.8.0.min.js' />" ></script>
<script type="text/javascript" src="<c:url value='/assets/bootstrap/js/bootstrap.min.js' />" ></script>
</body>
</html>
