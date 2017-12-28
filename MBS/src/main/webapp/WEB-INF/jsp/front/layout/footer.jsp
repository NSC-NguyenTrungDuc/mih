<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>

<footer class="footer hidden-print" id="footer">
	<div class="container text-center">
    	<%-- <div><i class="fa fa-hospital-o"></i> <a class="landingpage-url" href="#">${hospitalName}</a>. Copyright ©. All Rights Reserved</div> --%>
    	<% if ( HospitalLocale.JA_LOCALE.equals(MssContextHolder.getHospitalLocale()) ) { %>
    	<div><i class="fa fa-hospital-o"></i> <a href="#">${hospitalName}</a>. Copyright <a href="https://www.karte.clinic/">Sofiamedix</a> ©. All Rights Reserved</div>
    	<%}else{ %>
    	<div><i class="fa fa-hospital-o"></i> <a href="#">${hospitalName}</a>. Copyright <a href="https://www.sofiamedix.vn/">Sofiamedix</a> ©. All Rights Reserved</div>
    	<%} %>
  	</div>
</footer>