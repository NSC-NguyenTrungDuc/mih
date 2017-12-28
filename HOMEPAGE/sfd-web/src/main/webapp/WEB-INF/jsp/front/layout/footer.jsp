<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ include file="/WEB-INF/jsp/front/includes/taglibs.jsp"%>

<!-- BEGIN Footer -->
<footer id="footer">
  <div class="container">
	<div class="row">
	  <div class="col-md-12">
		<div class="connect">
		  <h3 class="title"><spring:message code="general.footer.title"/></h3>  
		  <div class="clearfix connect-act">  
			<!-- BEGIN Contact -->              
			<a class="act-contact" href="${ctx}/it-organization/contact-us">
			  <div class="mblock">
				<div class="icon">
				  <i class="fa fa-envelope-o"></i>
				</div>
				<span class="sub-title"><spring:message code="general.footer.it-organization"/></span>
				<span class="main-title"><spring:message code="general.footer.it-organization.contact-us"/></span>
			  </div>
			</a><!-- END Contact -->  
			<!-- BEGIN Account -->  
			<a class="act-account" href="${ctx}/service/registration-for-test">
			  <div class="mblock">
				<div class="icon">
				  <i class="fa fa-hand-o-right"></i>
				</div>
				<span class="sub-title"><spring:message code="general.footer.service"/></span>
				<span class="main-title"><spring:message code="genearl.footer.service.registration-for-test"/></span>
			  </div>
			</a><!-- END Account -->  
		  </div>
		</div>
		<!-- BEGIN Credit -->
		<div class="credit">
		  <!-- BEGIN Copyright Text -->
		  <p class="copyright-text">
			KARTE.CLINIC © 2015 All Rights Reserved
		  </p><!-- END Copyright Text -->
		  <!-- BEGIN Footer Menu -->
		  <ul class="footer-menu">
			<li><a href="${ctx}/term-of-service"><spring:message code="hp603.menu.sub.title"/></a></li>
			<li><a href="${ctx}/privacy-policy"><spring:message code="hp601.menu.sub.title"/></a></li>
			<li><a href="${ctx}/guidelines"><spring:message code="hp602.menu.sub.title"/></a></li>
		  </ul><!-- END Footer Menu -->
		</div><!-- END Credit -->
	  </div>
	</div>
  </div>
</footer><!-- END Footer -->