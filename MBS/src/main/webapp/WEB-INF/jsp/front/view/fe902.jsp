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
		<div class="col-xs-9 col-md-9 status">
			
		</div>
	</div>
	<br/>
	  <div class="block-content">
        <div class="table-responsive">
            <table id="tableAjax1"  class="table table-bordered table-striped table-green">
					<thead id="tblHead">
		              <tr>
		                <th class="table-header"><spring:message code="fe903.content.title" /></th>            
		                <th class="table-header"><spring:message code="fe903.unit.title" /></th> 
		                <th class="table-header" style="text-align: right"><spring:message code="fe903.price.title" /></th>
		                <th class="table-header" style="text-align: right"><spring:message code="fe903.quantity.title" /></th>            
		                <th class="table-header" style="text-align: right"><spring:message code="fe903.total.title" /></th>  
		              </tr>
           		 	</thead>
				 </table>
		 </div>
	</div>
	<script>
	   $('.dataTables_scrollBody').css({'overflow' : 'hidden',"height": "100%","width": "100%" ,'border-color' : '#27ae61'});
       var isChrome = !!window.chrome && !!window.chrome.webstore;
       if(!isChrome)
       {
           setTimeout(function(){
               $('#tableAjax1').css({"width" : "99%"});
           },500);
       }
	</script>	
	