<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<c:url var="createUrl" value="sms-template-detail" />
<div class="row">
	<div class="col-sm-12">
		<table class="table table-hover">
			<thead>
				<tr>
					<th>#</th>
					<th><spring:message code="be030.table.header.mail_title"/></th>
					<th></th>
					<td></td>
				</tr>
			</thead>
			<tbody>
				<c:forEach var="mailTemplateList" items="${mailTemplateList}" varStatus="i">
					<tr data-id="${mailTemplateList.mailTemplateId}">
						<td width="5%">${i.index + 1}</td>
						<td width="85%">${mailTemplateList.subject}</td>
						<td width="5%"><a href="${createUrl}?mailTemplateId=${mailTemplateList.mailTemplateId}" class="btn btn-primary btn-xs btn-change btn-60"><spring:message code="be030.button.edit" /></button></td>
						<c:if test="${mailTemplateList.isNew eq 1}">
						<td width="5%"><button type="button" class="btn btn-danger btn-xs btn-cancel btn-60" data-toggle="modal" data-target="#deleteMailTemplate"><spring:message code="be030.button.delete" /></button></td>
						</c:if>
					</tr>
				</c:forEach>
			</tbody>
		</table>
	</div>
	<div class="col-sm-12">
		<p class="form-control-static">
		    <a href="${createUrl}" class="btn btn-primary btn-create-new"><spring:message code='be030.button.create'/></a>
		</p>
	</div>
	<div class="modal fade" id="deleteMailTemplate">
		<div class="modal-dialog modal-sm">
			<div class="modal-content">
				<div class="modal-body">
					<button type="button" class="close" data-dismiss="modal">
						<span aria-hidden="true">&times;</span><span class="sr-only"><spring:message code="be030.modal.close" /></span>
					</button>
					<p class="modal-title">
						<spring:message code="be030.modal.delete_mail_template.title" />
					</p>
				</div>
				<div class="modal-footer">
					<button type="button" class="btn btn-success" id="btn-delete-mail-template">
						<spring:message code="be030.modal.confirm" />
					</button>
					<button type="button" class="btn btn-default" data-dismiss="modal">
						<spring:message code="be030.modal.close" />
					</button>
				</div>
			</div>
		</div>
	</div>
	
</div><!-- End .row -->
<script type="text/javascript" src="<c:url value='/assets/js/mail-manage/MailTemplateList.js' />"></script>