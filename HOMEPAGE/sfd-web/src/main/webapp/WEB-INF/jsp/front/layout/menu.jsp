<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ include file="/WEB-INF/jsp/front/includes/taglibs.jsp"%>

<nav id="off-canvas-menu">
  <ul>
	<li>
	  <a href="#"><spring:message code="general.menu.service"/></a>
	  <ul>
		  <li><a href="${ctx}/service/function-intro"><spring:message code="hp101.menu.sub.title" /></a></li>
	      <li><a href="${ctx}/service/method-procedure-intro"><spring:message code="hp102.menu.sub.title" /></a></li>
		  <li><a href="${ctx}/service/manual-guide"><spring:message code="hp103.menu.sub.title" /></a></li>
		  <li>
			 <a href="${ctx}/service/about-connected-peripheral-equipment"><spring:message code="hp104.menu.sub.title" /></a>
			  <ul>
			  	  <li><a href="${ctx}/service/about-connected-peripheral-equipment"><spring:message code="hp104.menu.sub.title" /></a></li>
				  <li><span><spring:message code="general.menu.service.accounting-connection"/></span></li>
				  <li><span><spring:message code="general.menu.service.test-acquisition"/></span></li>
			  </ul>
		  </li>
		  <li>
		     <a href="${ctx}/service/registration-for-test"><spring:message code="hp105.menu.sub.title" /></a>
			  <ul>
			      <li><a href="${ctx}/service/registration-for-test"><spring:message code="hp105.menu.sub.title" /></a></li>
				  <li><a href="${ctx}/service/manual-for-test"><spring:message code="hp106.menu.sub.title" /></a></li>
				  <li><a href="${ctx}/service/manual-for-test2"><spring:message code="hp107.menu.sub.title" /></a></li>
			  </ul>
		  </li>
	  </ul>
	</li>
	<li>
	  <a href="#"><spring:message code="general.menu.it-organization"/></a>
	  <ul>
		 <li>
		 	<a href="${ctx}/it-organization/related-medical-agent"><spring:message code="hp201.menu.sub.title" /></a>
		 	<ul>
		 		<li><a href="${ctx}/it-organization/related-medical-agent"><spring:message code="hp201.menu.sub.title" /></a></li>
		 		<li><span><spring:message code="hp202.menu.sub.title" /></span></li>
		 		<li><span><spring:message code="hp203.menu.sub.title" /></span></li>
		 		<li><span><spring:message code="hp204.menu.sub.title" /></span></li>		 		
		 	</ul>
		 </li>
		 <li><a href="${ctx}/it-organization/contact-us"><spring:message code="hp205.menu.sub.title" /></a></li>
	  </ul>
	</li>
	<li>
	  <a href="#"><spring:message code="general.menu.to-patient"/></a>
	  <ul>
		<li><a href="${ctx}/to-patient/about-electronic-medical-record"><spring:message code="hp301.menu.sub.title" /></a></li>
		<li><a href="${ctx}/to-patient/patient-register"><spring:message code="hp302.menu.sub.title" /></a></li>
	  </ul>
	</li>
	<li><a href="${ctx}/about-us"><spring:message code="hp401.menu.sub.title" /></a></li>
	<li>
	  <a href="#"><spring:message code="general.menu.sign-up"/></a>
	  <ul>
		<li><a href="${ctx}/service/registration-for-test"><spring:message code="general.menu.sign-up.registration-for-test"/></a></li>
		<li><a href="${ctx}/it-organization/contact-us"><spring:message code="general.menu.sign-up.contact-us"/></a></li>
		<li><a href="${ctx}/to-patient/patient-register"><spring:message code="general.menu.sign-up.patient-register"/></a></li>
	  </ul>
	</li>
  </ul>
</nav>