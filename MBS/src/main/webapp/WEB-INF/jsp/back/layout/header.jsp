<%@ page import="nta.mss.misc.common.MssContextHolder" %>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://tiles.apache.org/tags-tiles" prefix="tiles"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%--<script type="text/javascript" src="<c:url value='/assets/js/CookiesUtils.js' />"></script>--%>
<script type="text/javascript" src="<c:url value='/assets/js/lib/culture-info.js' />"></script>

<!-- ========== START HEADER ========== -->
<div class="container">
	<div class="row">
		<div class="col-md-2">
			<h1> <a href="#"><img src="<c:url value="${hospitalIconPath}" />" alt="" style="max-width: 400px; max-height: 80px; border: none;"/></a></h1>
		</div>
		<div class="col-md-6">
		<h1 style="margin-top: 30px; color: white; font-weight: bold; font-family:inherit;">${hospitalName}</h1>
		</div>
		<div class="col-md-4">
			<ul>
		        <tiles:insertAttribute name="btnLogout" />
			</ul>
		</div>
	</div>
</div>
<script type="text/javascript">
	var hospitalLocale = '<%=MssContextHolder.getHospitalLocale()%>';
	$(document).ready(function() {
		setLocale(hospitalLocale)

	});
	function setLocale(lang) {
		if (lang == "en") {
			Date.CultureInfo = CultureInfoEn;
		}
		else if (lang == "vi") {
			Date.CultureInfo = CultureInfoVi;
		}
		else {
			Date.CultureInfo = CultureInfoJa;
		}
	}
</script>
<!-- /.container -->
<!-- ========== END HEADER ========== -->