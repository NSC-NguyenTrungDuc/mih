
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%-- <div class="list-group">
	<c:forEach items="${leftMenuItems}" var="item">
		<a <c:if test="${item.link != null}">href="<c:url value='${item.link}' />"</c:if> class='list-group-item <c:if test="${item.active}">active</c:if>'>
			<i class="${item.iconClass}"></i>
			<spring:message code="${item.label}" />
		</a>
	</c:forEach>
</div> --%>
<%--Author : TungLT --%>
<div class="list-group">
	 <c:set var="counter" value="0" />
	<c:forEach items="${leftMenuItems}" var = "item">
			<c:if test="${!item.notIsMovieTalk}">
				<c:choose>
					<c:when test="${item.children == null || empty item.children}">
				          	  			<a class='list-group-item <c:if test="${item.active}">active</c:if>' href= "<c:if test = "${item.link != null}"> <c:url value="${item.link}"/></c:if>"
				          	  				><i  class="${item.iconClass}" ></i>  <spring:message code="${item.label}"/>
				          	  			</a>
				    </c:when>
				    <c:otherwise>
				    	<div class=" no-padding" id="accordion">
			    			<div class="panel-default">
			    				<div href="#collapse${counter}" data-parent="#accordion${counter}" data-toggle="collapse" class="panel-heading accordion-toggle collapsed">
										<a href="#collapse${counter}"  class='list-group-item <c:if test="${item.active}">active</c:if>'><i class="${item.iconClass}"></i><spring:message code="${item.label}"/><i class="fa minus"></i></a>
							    </div>
							    	<div id="collapse${counter}" class=" collapse-border">
							    	<c:forEach items = "${item.children}" var = "itemChild">
											<c:if test="${!itemChild.notIsMovieTalk}">
									    		<div class="panel-body">
									    			<a href= "<c:if test = "${itemChild.link != null}"> <c:url value="${itemChild.link}"/></c:if>" class='<c:if test="${itemChild.active}">active</c:if>'><i class="${itemChild.iconClass}"></i><spring:message code="${itemChild.label}"/></a>
									    		</div>
											</c:if>
							    	</c:forEach>
									</div>
			    			</div>
				    	</div>
				    </c:otherwise>
				</c:choose>
			</c:if>
		  <c:set var="counter" value="${counter+1}" />
	</c:forEach>
</div>
