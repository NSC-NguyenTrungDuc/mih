<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

${authorizationInfo.patientname}様へ <br/> <br/>

当院では遠隔診療で受診される患者様に対して、${authorizationInfo.auth_amt}
<c:if test="${authorizationInfo.currencyDisplay == 'JPY'}">
	円
</c:if>
<c:if test="${authorizationInfo.currencyDisplay == 'USD'}">
	$
</c:if>
のクレジット与信枠を確保させて頂いております。<br/> <br/>

クレジット与信枠の確保とは、カードのご利用限度額枠内から当院が優先的に決済可能な金額を確保をする事を指します。<br/> <br/>

診察後、請求金額が確定しクレジットカード決済が完了してから薬剤（または処方箋）をお送りさせて頂きます。<br/>

お支払い手続き後にお送りされるメールに記載されているリンクをクリックすると予約が完了いたします。