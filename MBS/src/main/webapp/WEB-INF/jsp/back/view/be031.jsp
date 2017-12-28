<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<c:url var="backUrl" value="mail-template-list"/>
<c:url var="confirmUrl" value="mail-template-detail"/>
<form:form method="post" class="form-horizontal" action="${confirmUrl}" modelAttribute="mailTemplate" >
	<form:input type="hidden" path="mailTemplateId" class="form-control" value="${mailTemplate.mailTemplateId}" />
	<form:input type="hidden" path="templateType" class="form-control" value="${mailTemplate.templateType}" />
	<form:input type="hidden" path="isNew" class="form-control" value="${mailTemplate.isNew}" />
	<div class="form-group">
		<div  class="col-xs-12 col-sm-2"></div>
		<div class="col-xs-12 col-sm-10" align="right">
			<div style="background-color:transparent; border-color:transparent;" data-toggle="modal" data-target=".bs-parameter-modal-lg"><img class="img-help" src="/assets/images/helpicon.png" /></div>
		</div>
	</div>
	<div id="validation" style="display:none">${validation}</div>
	<div class="form-group">
		<label class="col-xs-12 col-sm-2 control-label"><spring:message code="be031.label.template_code"/></label>
		<div class="col-xs-12 col-sm-10">
		<spring:message code="be031.placeholder.template.code" var="templaceCode"/>
			<c:if test = "${ isUpdate}">
			<form:input type="hidden" path="templateCode" class="form-control" placeholder="${templaceCode}" value="${mailTemplate.templateCode}" />
			</c:if>
			<form:input type="text" path="templateCode" class="form-control" placeholder="${templaceCode}" value="${mailTemplate.templateCode}" disabled="${isUpdate}"/>
			<form:errors path="templateCode" cssClass="text-danger error-msg"/>
		</div>
	</div>
	
	<!-- 
	<div class="form-group">
		<label class="col-xs-12 col-sm-2 control-label"><spring:message code="be031.label.locale"/></label>
		<div class="col-xs-12 col-sm-10">
			<form:select path="locale" class="form-control">
			    <form:option value="ja">ja-JP</form:option>
			    <form:option value="en">en-US</form:option>
			    <form:option value="vi">vi-VN</form:option>
			</form:select>
		</div>
	</div>
	 -->
	<div class="form-group">
		<label class="col-xs-12 col-sm-2 control-label"><spring:message code="be031.label.title"/></label>
		<div class="col-xs-12 col-sm-10">
		<spring:message code="be031.label.title" var="title"/>
			<form:input type="text" path="subject" class="form-control" placeholder="${title}" value="${mailTemplate.subject}"/>
			<form:errors path="subject" cssClass="text-danger error-msg"/>
		</div>
	</div>
	<div class="form-group">
		<label class="col-xs-12 col-sm-2 control-label"><spring:message code="be031.label.content"/></label>
		<div class="col-xs-12 col-sm-10">
			<form:textarea path="content" id="editor" value="${mailTemplate.content}"/>
		</div>
	</div>
	
		<div class="form-group">
			<div class="col-xs-12 col-sm-2"></div>
			<div class="col-xs-12 col-sm-10">
				<button type="submit" class="btn btn-primary" name="validate">
					<c:choose>
						<c:when test="${not empty mailTemplate.mailTemplateId}">
							<spring:message code="be031.button.save"/>
						</c:when>
						<c:otherwise>
							<spring:message code="be031.button.create"/>
						</c:otherwise>
					</c:choose>
				</button>
				<a href="${backUrl}" class="btn btn-default"><spring:message code="be031.button.back"/></a>
			</div>
	</div>
	<div class="modal fade" id="saveMailTemplate">
		<div class="modal-dialog modal-sm">
			<div class="modal-content">
				<div class="modal-body">
					<button type="button" class="close" data-dismiss="modal">
						<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message code="be031.modal.close" /></span>
					</button>
					<p>
						<c:choose>
							<c:when test="${not empty mailTemplate.mailTemplateId}">
								<spring:message code="be031.modal.mail_template.edit.title" />	
							</c:when>
							<c:otherwise>
								<spring:message code="be031.modal.mail_template.create.title" />	
							</c:otherwise>
						</c:choose>
					</p>
				</div>
				<div class="modal-footer">
					<input type="submit" value="<spring:message code="be031.modal.confirm" />" class="btn btn-success" name="confirm" />
					<button type="button" class="btn btn-default" data-dismiss="modal">
						<spring:message code="be031.modal.close" />
					</button>
				</div>
			</div>
		</div>
	</div>
	
	<div id="modal-param-desc" class="modal fade bs-parameter-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  		<div class="modal-dialog modal-lg">
	    	<div class="modal-content" style="height: 5%">
	    		 <div class="modal-header">
					<button type="button" class="close" data-dismiss="modal">
						<span aria-hidden="true">&times;</span><span class="sr-only"></span>
					</button>
					 <h4 class="modal-title" align="left"> 
						<label class="modal-title" align="center"><spring:message code="be030.modal.desc.parameter" /></label>
					</h4>
	    		 </div>
	    		<div class="modal-body" style="height: 600px; overflow: scroll">
		      		<%@ include file="../view/parameterDescription.jsp" %>
				</div>
	    	</div>
  		</div>
	</div>
</form:form>
<script type="text/javascript" src="<c:url value='/assets/plugins/ckeditor/ckeditor.js' />" ></script>
<script type="text/javascript" src="<c:url value='/assets/plugins/ckeditor/adapters/jquery.js' />" ></script>
<script type="text/javascript" src="<c:url value='/assets/js/mail-manage/MailTemplateDetail.js' />"></script>