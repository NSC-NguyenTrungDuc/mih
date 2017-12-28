<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/security/tags"
	prefix="sec"%>

<div class="text-content">
	<h3>${vaccineInfo.vaccineName}-${vaccineInfo.vaccineType}</h3>
	<c:if test="${not empty vaccineInfo.formattedLimitAge}">
		<div class="row">
			<label class="col-xs-6 col-md-6 control-label"> <spring:message
					code="general.vaccine.table.limit.inject.age" />
			</label>
			<div class="col-xs-6 col-md-6">
				<p class="form-control-static">${vaccineInfo.formattedLimitAge}
				</p>
			</div>
		</div>
		</br>
	</c:if>
	<c:if test="${not empty vaccineInfo.formattedRecommendAge}">
		<div class="row">
			<label class="col-xs-6 col-md-6 control-label"> <spring:message
					code="general.vaccine.table.advice.age" />
			</label>
			<c:forEach items="${vaccineInfo.formattedRecommendAge}"
				var="recommendAge" varStatus="status">
				<div class="col-xs-6 col-md-6">
					<p class="form-control-static">${recommendAge}</p>
				</div>
			</c:forEach>
		</div>
		</br>
	</c:if>


	<c:if test="${not empty vaccineInfo.formattedSupportFeeByMonth}">
		<div class="row">
			<label class="col-xs-6 col-md-6 control-label"> <spring:message
					code="general.vaccine.table.support.fee.age" />
			</label>
			<c:forEach items="${vaccineInfo.formattedSupportFeeByMonth}"
				var="supportFeeByMonth" varStatus="status">
				<div class="col-xs-6 col-md-6">
					<p class="form-control-static">${supportFeeByMonth}</p>
				</div>
			</c:forEach>
		</div>
		</br>
	</c:if>


	<c:if test="${not empty vaccineInfo.formattedExpiredDate}">
		<div class="row">
			<label class="col-xs-6 col-md-6 control-label"> <spring:message
					code="be201.label.form.stopReceivingBooking" />
			</label>
			<div class="col-xs-6 col-md-6">
				<p class="form-control-static">
					${vaccineInfo.formattedExpiredDate}</p>
			</div>
		</div>
	</c:if>
</div>

