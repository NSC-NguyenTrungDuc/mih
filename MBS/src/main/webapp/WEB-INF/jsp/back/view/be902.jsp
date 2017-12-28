<%@page import="nta.mss.misc.enums.HospitalLocale"%>
<%@page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
	<style >
    .alignRight { text-align: right; }
	</style>
	<br/>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="fe903.date.exam" />
		</label>
		<div class="col-xs-9 col-md-9 datetimeExamination">
			
		</div>
	</div>
	<br/>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="fe903.patient.id" />
		</label>
		<div class="col-xs-9 col-md-9 patientCode-detail">
		
		</div>
	</div>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="be006.label.form.patientName" />
		</label>
		<div class="col-xs-9 col-md-9 patientName-detail">
			
		</div>
	</div>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="be202.label.hospital.address" />
		</label>
		<div class="col-xs-9 col-md-9 address-detail">
			
		</div>
	</div>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="be204.patient.contact.phone" />
		</label>
		<div class="col-xs-9 col-md-9 phone-detail">
			
		</div>
	</div>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="be204.label.form.email" />
		</label>
		<div class="col-xs-9 col-md-9 email-detail">
			
		</div>
	</div>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="fe902.title.transaction" />
		</label>
		<div class="col-xs-9 col-md-9 transaction-detail">
			
		</div>
	</div>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="fe903.card.type" />
		</label>
		<div class="col-xs-9 col-md-9 cardType123">
			<spring:message code="fe903.card.value" />
		</div>
	</div>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="fe903.payment.total" />
		</label>
		<div class="col-xs-9 col-md-9 ">
			    <span class="totalPayment"></span> <spring:message code="fe903.currency.title" />
		</div>
	</div>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="be006.label.form.status" />
		</label>
		<div class="col-xs-3 col-md-3" id="frmPaymentStatus1">
        </div> 
	</div>
	<br/>
 	<div class="row" id = "commentInputRow">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="fe903.title.comment" />
		</label>
		<div class="col-xs-6 col-md-6 ">
			<input class="form-control" id="commentInput"/>
		</div>
	</div>
	<div class="row" id = "comment" hidden>
		<label class="col-xs-3 col-md-3 control-label">
		</label>
		<div class="col-xs-6 col-md-6 ">
			<span style="color:red"><spring:message code="be902.comment.required" /></span>
		</div>
	</div>
	<br/>
	<div class="form-group row">
		<table id="tblDetailPayment"
			class="table table-bordered display">
			<thead>
				<tr
					style="background-color: #4f6070; color: white; font-weight: bold;">
					<th><spring:message code="fe903.content.title" /></th>
					<th><spring:message code="fe903.unit.title" /></th>
					<th style="text-align: right"><spring:message code="fe903.price.title" /></th>
					<th style="text-align: right"><spring:message code="fe903.quantity.title" /></th>
					<th style="text-align: right"><spring:message code="fe903.total.title" /></th>
				</tr>
			</thead>
			<tbody id="detail-payment-body">
			</tbody>
		</table>
	</div>	
	
<script id="payment-detail-list" type="text/x-handlebars-template">
	{{#each orderMedicines}}
		<tr>
			<td style="width: 40%">{{hangmogName}}</td>
			<td style="width: 15%">{{codeName}}</td>
			<td style="width: 15% ; text-align: right">{{price}}</td>
			<td style="width: 15% ; text-align: right">{{quantity}}</td>
			<td style="width: 15% ; text-align: right">{{calPrice}}</td>
		</tr>
    {{/each}}
</script>
<script>
	var vm_table_record_each_page = '<spring:message code="table.record.each.page" />'
	var vm_table_previous = '<spring:message code="table.previous" />'
	var vm_table_next = '<spring:message code="table.next" />'
	var vm_table_last = '<spring:message code="table.last" />'
	var vm_table_empty = '<spring:message code="table.empty" />'
	var vm_table_info_empty = '<spring:message code="table.info.empty" />'
	var vm_table_info_total = '<spring:message code="table.info.total" />'
	var vm_table_info_start = '<spring:message code="table.info.start" />'
	var vm_table_info_end = '<spring:message code="table.info.end" />'
	var vm_s_info = '<spring:message code="table.s.info" />'
	$('.dataTables_scrollBody').css({'overflow' : 'hidden',"height": "100%","width": "100%" ,'border-color' : '#27ae61'});
    var isChrome = !!window.chrome && !!window.chrome.webstore;
    if(!isChrome)
    {
        setTimeout(function(){
            $('#tblDetailPayment').css({"width" : "99%"});
        },500);
    }
</script>
