<%@page import="nta.mss.misc.enums.BookingMode"%>
<%@ page import="nta.mss.misc.common.MssContextHolder"%>
<%@ taglib uri="http://tiles.apache.org/tags-tiles" prefix="tiles"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/functions" prefix="fn" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<% Integer bookingMode = MssContextHolder.getReservationMode();%>
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
	<link href="<c:url value='/assets/bootstrap/css/bootstrapValidator.css'/>" rel="stylesheet">
	<% if((bookingMode!=null) && (bookingMode.equals(BookingMode.NEW_BOOKING_ONLINE.toInt()) || bookingMode.equals(BookingMode.RE_EXAMINATION_ONLINE.toInt()))){ %>
		<link href="<c:url value='/assets/css/main-front-movietalk.css' />" rel="stylesheet">
	    <link href="<c:url value='/assets/css/booking-scroll-movietalk.css' />" rel="stylesheet">
	<% }else{ %>
		<link href="<c:url value='/assets/css/booking-scroll.css' />" rel="stylesheet">
		<link href="<c:url value='/assets/css/main-front.css' />" rel="stylesheet">
	<% }%>
	<link href="<c:url value='/assets/css/custom.css' />" rel="stylesheet">
	<link href="<c:url value='/assets/css/jquery-ui.css' />" rel="stylesheet">
	<link href="<c:url value='/assets/css/jquery.dataTables.min.css' />" rel="stylesheet">
	<link href="<c:url value='/assets/images/MBS_favico.ico' />" type="image/x-icon" rel="icon">

<script type="text/javascript"
	src="<c:url value='/assets/js/lib/doctor-vender/modernizr-2.8.3-respond-1.4.2.min.js' />"></script>
	<script type="text/javascript" src="<c:url value='/assets/js/lib/jquery-1.8.0.min.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/lib/bootstrap-filestyle.min.js'/>" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/lib/jquery-ui.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/bootstrap/js/bootstrap.min.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/lib/jquery.dataTables.min.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/lib/handlebars-v1.3.0.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/lib/placeholders.jquery.min.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/HandlebarsHelpers.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/CookiesUtils.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/MssUtils.js' />" ></script>
	<script type="text/javascript" src="<c:url value='/assets/js/doctor/peer.js' />" ></script>
</head>
<body>
	<header>
		<tiles:insertAttribute name="header" />
	</header>
	<div class="breadcrumbs">
		<div class="container">
			<div class="row">
				<div class="col-md-3 pull">
					<div class="col-pull">
						<i class="fa fa-bars"></i><spring:message code="general.button.main_menu" />
					</div>
				</div>
				<div class="col-md-9 home-right">
					<div class="col-md-2 home"><a href="<c:url value='/booking/index' />"><i class="fa fa-home"></i><spring:message code="general.button.home" /></a></div>
					<c:choose>
						<c:when test="${pageContext.request.userPrincipal.name != null}">
							<div class="col-md-2 profile"><a href="<c:url value='/booking/profile-management' />"><i class="fa fa-cog"></i><spring:message code="general.button.profile" /></a></div>
						</c:when>
					</c:choose>
					<div class="col-md-9 home-right">
						<ul>
<%-- 							<li class="arrow_box"><a href="#" >${hospitalName}</a></li> --%>
						</ul>
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
						<%--Processing for multi tab index booking--%>
						<c:if test="${urlRequestIndexBooking != '/mss-web/booking/index'}">
							<div class="tabs_container">
								<div class="tabs_title">
									<c:if test="${titleKey != ''}">


										<div class="tabs-one"><spring:message code="${titleKey}" /></div>
									</c:if>
								</div>
								<c:if test="${breadcrumb != null}">
								<div class="steps-container">
									<ul class="nav nav-pills nav-wizard">
										<c:set var="activePos" value="${fn:length(breadcrumb)}" />
										<c:forEach items="${breadcrumb}" var="item" varStatus="status">
											<c:if test="${item.active}"><c:set var="activePos" value="${status.index}" /></c:if>
											<li <c:if test="${item.active}">class="active"</c:if>>
												<c:if test="${status.index != 0}"><div class="nav-wedge"></div></c:if>
												<a <c:if test="${status.index < activePos}">href='<c:url value="${item.link}" />'</c:if>>
													<span style="font-size:14px;"><spring:message code="general.step.label" arguments="${status.index + 1}" /></span>
													<br />
													<spring:message code="${item.label}" />
												</a>
												<div class="nav-arrow"></div>
											</li>
										</c:forEach>
					                </ul>
					            </div>
								</c:if>
								<div class="tabs_content">
						</c:if>
									<tiles:insertAttribute name="body" />
								</div>
							</div>
				</div>
			</div>
		</div>
	</div>
	<tiles:insertAttribute name="footer" />
	
	<script>
	    $(document).ready(function() {
	        $('.col-pull').click(function() {
	                $('.menu.list-group').slideToggle("fast");
	        });
	        var url = $(location).attr('protocol') + '//' + $(location).attr('host') + '/landingpage/';
	        $(".landingpage-url").attr("href", url);
	        
	       <%-- 
	        Ignore temporary , may be use it in near future
	        var isChrome = !!window.chrome && !!window.chrome.webstore;
		    var isFirefox = typeof InstallTrigger !== 'undefined';
		    var isIE = !!navigator.userAgent.match(/Trident/g) || !!navigator.userAgent.match(/MSIE/g);
		    var isEdge = !isIE && !!window.StyleMedia;
		    var bookingMode = '<%=MssContextHolder.getReservationMode()%>';
		    if(isChrome || isFirefox)
		    	{
				    if(bookingMode == "1" || bookingMode == "2")
				    {
				    	document.documentElement.style.setProperty('--main-breadcum-color', '#27ae61');
				    	document.documentElement.style.setProperty('--main-schedule-color', '#27ae61'); 
				    }
				    else if(bookingMode == "3" || bookingMode == "4"){
				    	
				    	document.documentElement.style.setProperty('--main-breadcum-color', '#2783ae');
				    	document.documentElement.style.setProperty('--main-schedule-color', '#2783ae');
				    }
		    	}
		    else if(isEdge || isIE){
		    	}
 			--%>
		});
	    </script>

</body>
</html>
