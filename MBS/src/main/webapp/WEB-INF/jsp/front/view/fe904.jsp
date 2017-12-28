<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

	<c:if test="${isSuccess}">
		<div class="row">
			<div class="col-xs-8 col-md-8 ">
				<spring:message code="fe904.title.success" />
			</div>
		</div>
	</c:if>
	<c:if test="${!isSuccess}">
		<div class="row">
			<div class="col-xs-8 col-md-8 ">
				<spring:message code="fe904.title.failed" />
			</div>
		</div>
	</c:if>
	<br/>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="fe903.patient.id" />
		</label>
		<div class="col-xs-9 col-md-9">
			${paymentInfo.patientCode}
		</div>
	</div>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="fe903.patient.name" />
		</label>
		<div class="col-xs-9 col-md-9">
			${paymentInfo.patientName}
		</div>
	</div>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="fe903.date.exam" />
		</label>
		<div class="col-xs-9 col-md-9">
			${paymentInfo.datetimeExamination}
		</div>
	</div>
	<c:if test="${isSuccess}">
		<div class="row">
			<label class="col-xs-3 col-md-3 control-label">
			    <spring:message code="fe902.title.transaction" />
			</label>
			<div class="col-xs-9 col-md-9">
				${transactionIdReturn}
			</div>
		</div>
		<div class="row">
			<label class="col-xs-3 col-md-3 control-label">
			    <spring:message code="be901.title.payment.datetime" />
			</label>
			<div class="col-xs-9 col-md-9">
				${paymentDate}
			</div>
		</div>
	</c:if>
	<br/>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="fe903.payment.total" />
		</label>
		<div class="col-xs-9 col-md-9">
			${paymentInfo.totalPayment} <spring:message code="fe903.currency.title" />
		</div>
	</div>
	<br/>
	<c:if test="${!isSuccess}">
		<div class="row">
			<label class="col-xs-3 col-md-3 control-label">
				<spring:message code="be904.title.reason" />
			</label>
			<div class="col-xs-9 col-md-9">
				${errorCode} 
			</div>
		</div>
		<div class="row">
			<label class="col-xs-3 col-md-3 control-label">
			</label>
			<div class="col-xs-9 col-md-9 ">
				<spring:message code="fe904.again.message" />
			</div>
		</div>
	</c:if>
