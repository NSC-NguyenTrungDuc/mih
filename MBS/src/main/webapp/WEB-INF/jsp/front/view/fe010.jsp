<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>

<c:url var="confirmUrl" value="/booking/re-examination-confirm" />
<div id="main-booking-name" class="col-md-10">
	<form:form class="form-horizontal" role="form" method="post" action="${confirmUrl}">
		<h2>
			<spring:message code="fe010.label.please.input" />
		</h2>
		<div class="col-sm-10">
			<c:if test="${error != null && notExist!=null}">
				<label class="alert-danger"> <span>${error} ${cardNumber} ${notExist}</span></label>
			</c:if>
		</div>
		<div class="form-group">
			<spring:message code="fe010.label.card.number" var="cardNumber"/>
			<label class="col-sm-3 control-label"> 
				${cardNumber}	
			</label>
			<div class="col-sm-7">
				<input type="text" name="cardNumber" style="width: 100%" placeholder="${cardNumber}" class="form-control" maxlength="32"/>
				<%-- 			<form:input class="form-control"  path="cardNumber"/> --%>
				<%-- 			<form:errors path="error" cssClass="alert-danger" /> --%>
			</div>
		</div>

		<div class="form-group" >
			<div class="col-sm-offset-3 col-sm-5">
				<input type="submit" class="btn btn-success btn-sm"
					value="<spring:message code="general.button.confirm"/>" />
			</div>
		</div>
	</form:form>
</div>
<script type="text/javascript">
var isMobile = MssUtils.detectmob();
	if(isMobile)
	{
		MssUtils.focusIncaseMobile('#main-booking-name');
	}
</script>