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
			${paymentInfo.patientName} <spring:message code="fe903.title.personal" />
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
	<br/>
	<div class="block-content">
        <div class="table-responsive">
            <table id="tableAjax"  class="table table-bordered table-striped table-green">
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
	<br/>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="fe903.card.type" />
		</label>
		<div class="col-xs-9 col-md-9">
			<spring:message code="fe903.card.value" />
		</div>
	</div>
	<div class="row">
		<label class="col-xs-3 col-md-3 control-label">
			<spring:message code="fe903.payment.total" />
		</label>
		<div class="col-xs-9 col-md-9">
			${paymentInfo.totalPayment} <spring:message code="fe903.currency.title" />
		</div>
	</div>	

<form:form method="post" action="${redirectURL}" modelAttribute="paymentInput" id="frmLogin" enctype="multipart/form-data">
<table  id = "submit-payment">
	<tbody>
	<tr>
		<td>ShopID</td>
		<td><input type="text" name="ShopID" value="${paymentInput.shopId}"></td> 
	</tr>
	<tr>
		<td>OrderID</td>
		<td><input type="text" name="OrderID" value="${paymentInput.orderId}"></td>
	</tr>	
	<tr>
		<td>Amount</td>
		<td><input type="text" name="Amount" value="${paymentInput.amount}"></td>
	</tr>
	
	<tr>
		<td>Tax</td>
		<td><input type="text" name="Tax" value="${paymentInput.tax}"></td>
	</tr>		
	<tr>
		<td>Currency</td>
		<td><input type="text" name="Currency" value="${paymentInput.currency}"></td>
	</tr>
	<tr>
		<td>DateTime</td>
		<td><input type="text" name="DateTime" value="${paymentInput.dateTime}"></td>
	</tr>	
	<tr>
		<td>ShopPassString</td>
		<td><input type="text" name="ShopPassString" value="${paymentInput.shopPassString}"></td>
	</tr>	
	<tr>
		<td>RetURL</td>
		<td><input type="text" name="RetURL" value="${paymentInput.retURL}"></td>
	</tr>	
	<tr>
		<td>CancelURL</td>
		<td><input type="text" name="CancelURL" value="${paymentInput.cancelURL}"></td>
	</tr>	
	<tr>
		<td>UserInfo</td>
		<td><input type="text" name="UserInfo" value="${paymentInput.userInfo}"></td>
	</tr>	
	<tr>
		<td>RetryMax</td>
		<td><input type="text" name="RetryMax" value="${paymentInput.retryMax}"></td>
	</tr>	
	<tr>
		<td>SessionTimeout</td>
		<td><input type="text" name="SessionTimeout" value="${paymentInput.sessionTimeout}"></td>
	</tr>	
	<tr>
		<td>Lang</td>
		<td><input type="text" name="Lang" value="${paymentInput.lang}"></td>
	</tr>	
	<tr>
		<td>Confirm</td>
		<td><input type="text" name="Confirm" value="${paymentInput.confirm}"></td>
	</tr>	
	<tr>
		<td>UseCredit</td>
		<td><input type="text" name="UseCredit" value="${paymentInput.userCredit}"></td>
	</tr>	
	<tr>
		<td>TemplateNo</td>
		<td><input type="text" name="TemplateNo" value="${paymentInput.templateNo}"></td>
	</tr>
	<tr>
		<td>JobCd</td>
		<td><input type="text" name="JobCd" value="${paymentInput.jobCd}"></td>
	</tr>			
	</tbody></table>
	<div id = "submit-payment">
	  <button type="submit"  class= "btn btn-success btn-sm" style="float: right;width:11%"><spring:message code="be005.label.confirm_btn" /></button>
	</div>
</form:form>

<!-- Note : Move to file javascript after  -->
<script type = "text/javascript">
	$("#submit-payment").hide();
	function editCssTable()
	{
			$('.table').css( { margin : "20px 0 0"});
			$('table.dataTable thead th').css("border-bottom","none");
			$('table.dataTable.no-footer').css("border-bottom","none");
			 var thx = $("#tableAjax").find('th');
			 
		       $.each(thx,function(i,j){
		           $(this).css('background-color', '#e8f9f9');
		       });
	}
	function multiLanguage()
	{
		 var language = {
				    "emptyTable":    '<spring:message code="general.not.data.found" />',
				    "info":           '<spring:message code="general.info.info" />',
				    "infoEmpty":      '<spring:message code="general.info.infoEmpty" />',
				    "infoFiltered":   "(filtered from _MAX_ total entries)",
				    "error"		  :   '<spring:message code="general.error.system" />',
				    "infoPostFix":    "",
				    "thousands":      ",",
				    "lengthMenu":     '<spring:message code="general.info.sLengthMenu" />',
				    "loadingRecords": "Loading...",
				    "processing":     "Processing...",
				    "search":         "Search:",
				    "zeroRecords":    "No matching records found",
				    "paginate": {
				        "first":      '<spring:message code="general.nav.button.first" />',
				        "last":       '<spring:message code="general.nav.button.last" />',
				        "next":       '<spring:message code="general.nav.button.next" />',
				        "previous":   '<spring:message code="general.nav.button.previous" />'
				    },
				    "aria": {
				        "sortAscending":  ": activate to sort column ascending",
				        "sortDescending": ": activate to sort column descending"
				    },
				    "minute" : '<spring:message code="fe003.label.before.reminder" />'
				}
		 return language;
	}
	var iDisplayLength = 8;
	var targets = 0;
	var iDisplayStart = 0;
	var order = 1;
	var roundNum = 2;
	var language = multiLanguage();
	var orderId = "${paymentInput.orderId}";
	if(orderId !== "")
		{
		 var table = $("#tableAjax").dataTable( {
			  scrollCollapse: true,
		      "bProcessing": false,
		      "bServerSide": false,
		      "bSort": false,
		      "sort": "position",
		      "bFilter": false,
		      "bStateSave": false,
		      "columnDefs": [ {
		            "searchable": false,
		            "orderable": false,
		            "targets": targets,
	
		        }
		        ],
		        "language" : {
		        	  "sEmptyTable":     language.emptyTable,
		        	  "sInfo":           language.info,
		        	    "sInfoEmpty":      language.infoEmpty,
		        	    "sInfoFiltered":   "（全 _MAX_ 件より抽出）",
		        	  "sInfoPostFix":    "",
		        	  "sInfoThousands":  ",",
		        	    "sLengthMenu":    language.lengthMenu,
		        	  "sLoadingRecords": "読み込み中...",
		        	    "sProcessing":     "処理中...",
		        	  "sSearch":         "検索:",
		        	    "sZeroRecords":    "一致するレコードがありません",
		        	    "oPaginate": {
		        	        "sFirst":    language.paginate.first,
		        	        "sLast":     language.paginate.last,
		        	        "sNext":     language.paginate.next,
		        	        "sPrevious": language.paginate.previous
		        	    }},
		       "bLengthChange": false,
		       "paging":         false,
		       "info":     false,
		      //Default: Page display length
		      "iDisplayLength": iDisplayLength,
		      "iDisplayStart": iDisplayStart,
		      "sDom": 'rt<"bottom"ip><"clear">',
		      "fnDrawCallback": function () {
		      },
		      "sAjaxSource": "get-order-medicine",
		      "columnDefs": [
		                     { className: "doctor-name", "targets": [ 1 ] }
		                   ],
		      "aoColumns": [
		          { "bSortable": false, "mData": "hangmogName" , sWidth: '40%' ,
		        	  render: function (data, type, row, meta) {     		  	
		        	        return data;
		        	   }
		          } ,
		          { "bSortable": false, "mData": "codeName",sWidth: '15%'},
		          { "bSortable": false, "mData": "price",sClass: "alignRight",sWidth: '15%'},
		          { "bSortable": false, "mData": "quantity",sClass: "alignRight",sWidth: '15%'},
		          { "bSortable": false, "mData": "calPrice",sClass: "alignRight",sWidth: '15%'}
		      ]
		  });
			
	}
</script>