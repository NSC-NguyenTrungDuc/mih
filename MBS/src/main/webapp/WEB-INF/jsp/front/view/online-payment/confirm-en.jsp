<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

Dear ${authorizationInfo.patientname},<br/><br/>

To booking online exam, please agree with authorization amount of clinic.<br/><br/>

Authorization amount: ${authorizationInfo.auth_amt} 
<c:if test="${authorizationInfo.currencyDisplay == 'JPY'}">
	円
</c:if>
<c:if test="${authorizationInfo.currencyDisplay == 'USD'}">
	$
</c:if>
<br/><br/>

This amount will be paid via credit card on Settlement date.<br/><br/>

On case actual amount lower than authorization amount, credit card only auto pay actual amount Settlement date.<br/><br/>

On case actual amount more than authorization amount, we will send again Invoice.<br/><br/>

If patient don't confirm this actual amount, credit card only auto pay examination fees, don't send drug.<br/><br/>

After inputed credit card info by click [Input credit card] system will send confirm mail, please click to URL to finish booking.<br/><br/>

Thank you!