<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ page session="true"%>

<div class="list-group">
	<c:forEach items="${leftMenuItems}" var="item" varStatus="counter">
		<c:choose>
			<c:when test="${not sessionScope.isHide}">
				<c:choose>
					<c:when test="${item.children == null || empty item.children}">
						<a
							<c:if test="${item.link != null}">href="<c:url value='${item.link}' />"</c:if>
							class="list-group-item<c:if test="${item.active}"> active</c:if>"><i
							class="${item.iconClass}"></i> <spring:message
								code="${item.label}" /></a>
					</c:when>
					<c:otherwise>
						<div id="accordion${counter.index}" class="no-padding">
							<div class="panel-default">
								<div
									class="panel-heading accordion-toggle<c:if test="${item.active}"> active</c:if> collapsed"
									data-toggle="collapse" data-parent="#accordion${counter.index}"
									href="#collapse${counter.index}">
									<a href="#" class="list-group-item"><i
										class="${item.iconClass}"></i> <spring:message
											code="${item.label}" /><i class="fa minus"></i></a>

								</div>
								<div class="collapse<c:if test="${item.active}"> in</c:if>"
									id="collapse${counter.index}">
									<c:forEach items="${item.children}" var="child">
										<div
											class="panel-body<c:if test="${child.active}"> active</c:if>">
											<a
												<c:if test="${child.link != null}">href="<c:url value='${child.link}' />"</c:if>><span
												class="icon-angle-right"></span> <spring:message
													code="${child.label}" /></a>
										</div>
									</c:forEach>
								</div>
							</div>
						</div>
					</c:otherwise>
				</c:choose>
			</c:when>
			<c:otherwise>	
				<c:choose>			
					<c:when test="${item.hideOnKcck eq true}">
					</c:when>			
					<c:when test="${item.children == null || empty item.children}">
								<a
									<c:if test="${item.link != null}">href="<c:url value='${item.link}' />"</c:if>
									class="list-group-item<c:if test="${item.active}"> active</c:if>"><i
									class="${item.iconClass}"></i> <spring:message
										code="${item.label}" /></a>
					</c:when>
					<c:otherwise>				
						<div id="accordion${counter.index}" class="no-padding">
							<div class="panel-default">
								<div
									class="panel-heading accordion-toggle<c:if test="${item.active}"> active</c:if> collapsed"
									data-toggle="collapse" data-parent="#accordion${counter.index}"
									href="#collapse${counter.index}">
									<a href="#" class="list-group-item"><i
										class="${item.iconClass}"></i> <spring:message
											code="${item.label}" /><i class="fa minus"></i></a>

								</div>
								<div class="collapse<c:if test="${item.active}"> in</c:if>"
									id="collapse${counter.index}">
									<c:forEach items="${item.children}" var="child">
										<c:if test="${child.hideOnKcck eq false}">
											<div
												class="panel-body<c:if test="${child.active}"> active</c:if>">
												<a
													<c:if test="${child.link != null}">href="<c:url value='${child.link}' />"</c:if>><span
													class="icon-angle-right"></span> <spring:message
														code="${child.label}" /></a>
											</div>
										</c:if>
									</c:forEach>
									
									
									
								</div>
							</div>
						</div>
					</c:otherwise>
				</c:choose>
			</c:otherwise>
		</c:choose>
	</c:forEach>
</div>

