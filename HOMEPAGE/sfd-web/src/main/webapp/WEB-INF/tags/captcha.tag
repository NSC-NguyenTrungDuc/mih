<%@ tag import="net.tanesha.recaptcha.ReCaptcha" %>
<%@ tag import="net.tanesha.recaptcha.ReCaptchaImpl"%>
<%@ tag import="net.tanesha.recaptcha.ReCaptchaFactory" %>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<c:set var="lang"><spring:message code='captcha.lang'/></c:set>
 
<script type="text/javascript">var RecaptchaOptions = {lang : "${lang}", theme : 'clean'};</script> 
<%
	ReCaptcha c;
	c = ReCaptchaFactory.newSecureReCaptcha("6LfRLwkTAAAAADdLBMDQvu8-T75Ib1eX4ukq6Lg4", "6LfRLwkTAAAAAMoB8X05jZWIGs4IVmpcH3PANrf-", true);
	((ReCaptchaImpl) c).setRecaptchaServer("https://www.google.com/recaptcha/api");
	out.print(c.createRecaptchaHtml(null, null));
%>