<%@ page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://tiles.apache.org/tags-tiles" prefix="tiles"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<script type="text/javascript"
	src="<c:url value='/assets/js/lib/culture-info.js' />"></script>


<!-- ========== START HEADER ========== -->
<div class="container">
	<div class="row">

		<div class="col-md-12">
			<div class="site">
				<h1>
					 <img src="<c:url value="${hospitalIconPath}" />" alt=""
						class="logo-image"> <span class="name">
						${hospitalName}</span>
				</h1>
			</div>
			<nav class="top-nav">
				<div class="welcome">
					Hello, <strong><%=MssContextHolder.getDoctorName()%></strong>
				</div>
				<button class="btn btn-setting" data-toggle="modal" id="videosetting"
					data-target="#video-setting">
					<i class="fa fa-cog"></i> <spring:message code="fe616.button.videoSetting"/>
				</button>
			</nav>
		</div>
	</div>
	<!-- /.navbar-collapse -->
</div>

<!-- /.container -->

<!-- ========== END HEADER ========== -->

<script type="text/javascript">

	var hospitalLocale = '<%=MssContextHolder.getHospitalLocale()%>';
	$(document).ready(
			function() {
				if(document.URL.indexOf("movies-talk")>-1)
					
				{
					$("#videosetting").show();
				}
			else
				{
				$("#videosetting").hide();
				}
				setLocale(hospitalLocale)

			});
	function setLocale(lang) {
		if (lang == "en") {
			Date.CultureInfo = CultureInfoEn;
		} else if (lang == "vi") {
			Date.CultureInfo = CultureInfoVi;
		} else {
			Date.CultureInfo = CultureInfoJa;
		}
	}
</script>
