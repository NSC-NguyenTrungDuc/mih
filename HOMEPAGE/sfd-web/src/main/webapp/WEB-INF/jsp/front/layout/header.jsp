<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ include file="/WEB-INF/jsp/front/includes/taglibs.jsp"%>
<h1 class="logo"><a href="${ctx}/"><img src="<c:url value='/assets/img/logo.png'/>" alt=""></a></h1>
<div class="container">
	<div class="row">
	  <div class="col-md-12">
		<span id="nav-toggle" class="nav-toggle"><i class="fa fa-bars"></i></span>                
		<!-- BEGIN Nav Left -->
		<nav id="nav-left" class="header-nav pull-left">
		  <span class="nav-toggle"><i class="fa fa-bars"></i></span>
		  <ul class="menu">
			<li class="dropdown full-width">
			  <a href="#" class="dropdown-toggle" data-toggle="dropdown"><spring:message code="general.menu.service"/> <span class="caret"></span></a>
			  <!-- BEGIN Dropdown Menu -->
			  <ul class="dropdown-menu">
				<li class="col-sm-4">
				  <h3><spring:message code="general.menu.service.info.header"/></h3>
				  <p><spring:message code="general.menu.service.info.content"/></p>
				</li>
				<li class="col-sm-4">
				  <ul class="sub-dmenu">
					  <li><a href="${ctx}/service/function-intro"><i class="fa fa-caret-right"></i> <spring:message code="hp101.menu.sub.title" /></a></li>
					  <li><a href="${ctx}/service/method-procedure-intro"><i class="fa fa-caret-right"></i> <spring:message code="hp102.menu.sub.title" /></a></li>
					  <li><a href="${ctx}/service/manual-guide"><i class="fa fa-caret-right"></i> <spring:message code="hp103.menu.sub.title" /></a></li>
					  <li><a href="${ctx}/service/about-connected-peripheral-equipment"><i class="fa fa-caret-right"></i> <spring:message code="hp104.menu.sub.title" /></a>
						  <ul>
							  <li><span style="display:block; line-height: 20px; padding: 6px 0;"><i class="fa fa-angle-right"></i> <spring:message code="general.menu.service.accounting-connection"/></span></li>
							  <li><span style="display:block; line-height: 20px; padding: 6px 0;"><i class="fa fa-angle-right"></i> <spring:message code="general.menu.service.test-acquisition"/></span></li>
						  </ul>
					  </li>
					  <li><a href="${ctx}/service/registration-for-test"><i class="fa fa-caret-right"></i> <spring:message code="hp105.menu.sub.title" /></a>
						  <ul>
							  <li><a href="${ctx}/service/manual-for-test"><i class="fa fa-angle-right"></i> <spring:message code="hp106.menu.sub.title" /></a></li>
							  <li><a href="${ctx}/service/manual-for-test2"><i class="fa fa-angle-right"></i> <spring:message code="hp107.menu.sub.title" /></a></li>
						  </ul>
					  </li>
				  </ul>
				</li>                        
			  </ul><!-- BEGIN Dropdown Menu -->
			</li> 
			<li class="dropdown full-width">
			  <a href="#" class="dropdown-toggle" data-toggle="dropdown"><spring:message code="general.menu.it-organization"/> <span class="caret"></span></a>
			  <!-- BEGIN Dropdown Menu -->
			  <ul class="dropdown-menu">
				<li class="col-sm-4">
				  <h3><spring:message code="general.menu.it-organization.info.header"/></h3>
				  <p><spring:message code="general.menu.it-organization.info.content"/></p>
				</li>
				<li class="col-sm-4">
				  <ul class="sub-dmenu">
					<li><a href="${ctx}/it-organization/related-medical-agent"><i class="fa fa-caret-right"></i> <spring:message code="hp201.menu.sub.title" /></a>
						<ul>
							<li><span style="display:block; line-height: 20px; padding: 6px 0;"><i class="fa fa-angle-right"></i> <spring:message code="hp202.menu.sub.title" /></span></li>
							<li><span style="display:block; line-height: 20px; padding: 6px 0;"><i class="fa fa-angle-right"></i> <spring:message code="hp203.menu.sub.title" /></span></li>
							<li><span style="display:block; line-height: 20px; padding: 6px 0;"><i class="fa fa-angle-right"></i> <spring:message code="hp204.menu.sub.title" /></span></li>
						</ul>
					</li>
					<li><a href="${ctx}/it-organization/contact-us"><i class="fa fa-caret-right"></i> <spring:message code="hp205.menu.sub.title" /></a></li>
				  </ul>
				</li>                        
			  </ul><!-- BEGIN Dropdown Menu -->
			</li> 
			<li class="dropdown full-width">
			  <a href="#" class="dropdown-toggle" data-toggle="dropdown"><spring:message code="general.menu.to-patient"/> <span class="caret"></span></a>
			  <!-- BEGIN Dropdown Menu -->
			  <ul class="dropdown-menu">
				<li class="col-sm-4">
				  <h3><spring:message code="general.menu.to-patient.info.header"/></h3>
				  <p><spring:message code="general.menu.to-patient.info.content"/></p>
				</li>
				<li class="col-sm-4">
				  <ul class="sub-dmenu">
					<li><a href="${ctx}/to-patient/about-electronic-medical-record"><i class="fa fa-caret-right"></i> <spring:message code="hp301.menu.sub.title" /></a>
					</li>
					 <li><a href="${ctx}/to-patient/patient-register"><i class="fa fa-caret-right"></i> <spring:message code="hp302.menu.sub.title" /></a>
					</li>
				  </ul>
				</li>                        
			  </ul><!-- BEGIN Dropdown Menu -->
			</li> 
		  </ul>
		</nav><!-- END Nav Left -->
		<!-- BEGIN Nav Right -->
		<nav id="nav-right" class="header-nav pull-right">
		  <ul class="menu">
			<li><a href="${ctx}/about-us"> <spring:message code="hp401.menu.sub.title" /></a></li>
			<li class="dropdown">
			  <a href="#" id="signin" data-toggle="dropdown" class="dropdown-toggle" ><spring:message code="general.menu.sign-up"/> <span class="fa fa-sign-in"></span></a>
			  <ul class="dropdown-menu" aria-labelledby="signin">
				<li><a href="${ctx}/service/registration-for-test"><i class="fa fa-caret-right"></i> <spring:message code="general.menu.sign-up.registration-for-test"/></a></li>
				<li><a href="${ctx}/it-organization/contact-us"><i class="fa fa-caret-right"></i> <spring:message code="general.menu.sign-up.contact-us"/></a></li>
				<li><a href="${ctx}/to-patient/patient-register"><i class="fa fa-caret-right"></i> <spring:message code="general.menu.sign-up.patient-register"/></a></li>
			  </ul>
			</li>                     
		  </ul>
		</nav><!-- END Nav Left -->
	  </div>
	</div>
</div>