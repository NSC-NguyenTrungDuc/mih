<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ page session="true"%>

		  <%-- <nav class="main-nav">
                      <ul class="main-menu">
                          <li><a href="<c:url value='/doctor/movies-talk'/>"><i class="fa fa-video-camera icon"></i> Movies Talk</a></li>
                          <li class="parrent current">
                              <a href="#"><i class="fa fa-heart-o icon"></i> Personal Health Data</a>
                              <ul class="sub-menu">
                                  <li><a href="<c:url value='/doctor/profile-info'/>"><i class="fa fa-caret-right icon"></i> Profile Infomation</a></li>
                                  <li><a href="<c:url value='/doctor/body-measurement'/>"><i class="fa fa-caret-right icon"></i> Body Measurement</a></li>
                                  <li><a href="<c:url value='/doctor/vital'/>"><i class="fa fa-caret-right icon"></i> Vitals</a></li>
                                  <li><a href="<c:url value='/doctor/fitness'/>"><i class="fa fa-caret-right icon"></i> Fitness</a></li>
                                  <li><a href="<c:url value='/doctor/food'/>"><i class="fa fa-caret-right icon"></i> Food</a></li>
                                  <li><a href="<c:url value='/doctor/sleep'/>"><i class="fa fa-caret-right icon"></i> Sleep</a></li>
                                  <li><a href="<c:url value='/doctor/movietalk-history'/>"><i class="fa fa-caret-right icon"></i> Movies Talk History</a></li>
                              </ul>
                          </li>
                      </ul>
                  </nav>  --%>
                  
	  <nav class="main-nav">
	     <ul class="main-menu">
	          <c:forEach items="${leftMenuItems}" var="item" varStatus="counter">
	          	  <c:choose>
		          	  <c:when test="${item.children == null || empty item.children}">
		          	  		<li class="<c:if test="${item.active}"> current</c:if>">
		          	  			<a href= "<c:if test = "${item.link != null}"> <c:url value="${item.link}"/></c:if>"
		          	  				><i  class="${item.iconClass}" ></i>  <spring:message code="${item.label}"/>
		          	  			</a>
		          	  		</li> 
		          	  </c:when>
		             <c:otherwise>
		          	  		<li class="parrent <c:if test="${item.active}"> current</c:if>">
									<a href="#"><i class="${item.iconClass}"></i> <spring:message code="${item.label}" />
									</a>
								<ul class="sub-menu">
			          	  			<c:forEach items = "${item.children}" var = "itemChild">
			          	  				<li class="<c:if test="${itemChild.active}"> current</c:if>"><a href= "<c:if test = "${itemChild.link != null}"> <c:url value="${itemChild.link}"/></c:if>"
			          	  				><i  class="${itemChild.iconClass}" ></i>  <spring:message code="${itemChild.label}"/></a></li>
			          	  			</c:forEach>
		          	  			</ul>           	  		
		          	  		</li>
		          	  </c:otherwise> 
	          	  </c:choose>
	          </c:forEach>
	     </ul>       
      </nav>
     
                  

                      
                        
                        
                        
