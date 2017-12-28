<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ taglib uri="http://www.springframework.org/security/tags" prefix="sec" %>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>

<link href="<c:url value='/assets/css/tooltipster.bundle.min.css'/>" rel="stylesheet">
<script type="text/javascript" src="<c:url value='/assets/js/tooltipster.bundle.min.js' />" ></script>
<style >
.table.table-green tr td{
	 padding: 10px 10px; 
}
.tooltip-transaction {
    position: relative;
    z-index: 1030;
    display: block;
    visibility: visible;
    font-size: 12px;
    line-height: 1.4;
    filter: alpha(opacity=0);
}
	</style>
<form:form class="form-horizontal" role="form" method="POST" commandName="searchBooking">
    <div class="form-group">

        <label class="col-sm-2 control-label" style="text-align:left"><spring:message code="be901.title.paymentdate" /></label>
        <div class="col-sm-2">
            <input class="form-control" id="paymentFromDate"/>
        </div>
        <label class="col-sm-1 control-label" style="text-align:left">~</label>

        <div class="col-sm-2">
            <input class="form-control" id="paymentToDate"/>
        </div>
        <label class="col-sm-2 control-label" style="text-align:left"><spring:message code="be901.title.invoiceno" /></label>

        <div class="col-sm-3">
            <input class="form-control" id="frmInvoiceNo"/>
        </div>
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" style="text-align:left"><spring:message code="fe903.date.exam" /></label>
        <div class="col-sm-2">
            <input class="form-control " id="examFromDate"/>
        </div>
        <label class="col-sm-1 control-label" style="text-align:left">~</label>

        <div class="col-sm-2">
            <input class="form-control" id="examToDate"/>
        </div>
        
        <label class="col-sm-2 control-label" style="text-align:left"><spring:message code="be006.label.form.status" /></label>
        <div class="col-sm-3">
            <select class="form-control" id="frmPaymentStatus">
                <option value=""><spring:message code="general.select.all" /></option>
                <option value="1"><spring:message code="be901.title.status.finish" /></option>
                <option value="2"><spring:message code="be901.title.status.fail" /></option>
                <option value="3"><spring:message code="be901.title.status.fore.finish" /></option>
                <option value="4"><spring:message code="be901.title.status.fore.cancel" /></option>
                <option value="5"><spring:message code="be901.title.status.requesting" /></option>
                <option value="6"><spring:message code="be901.title.status.inprogress" /></option>
                <option value="7"><spring:message code="be901.title.status.cancel" /></option>
                <option value="9"><spring:message code="be901.title.status.other" /></option>
            </select>
        </div>
        
    </div>

    <div class="form-group">
        <label class="col-sm-2 control-label" style="text-align:left"><spring:message code="be901.title.amount" /></label>
        <div class="col-sm-2">
            <input class="form-control " id="amountFrom"/>
        </div>
        <label class="col-sm-1 control-label" style="text-align:left">~</label>

        <div class="col-sm-2">
            <input class="form-control" id="amountTo"/>
        </div>        
    </div>
    <div class="form-group">
        <label class="col-sm-2 control-label" style="text-align:left"><spring:message code="fe902.title.transaction" /></label>

        <div class="col-sm-5">
            <input class="form-control" id="transactionId"/>
        </div>
        
    </div>
    <div class="form-group">
        <div class="col-sm-10" align="left">
            <input id="searchBtn" type="button" class="btn btn-primary pull-left btn-120" value="<spring:message code="be025.label.search.button" />">
        </div>
    </div>
</form:form>

<!--Modal ends here--->
<div class="block">
    <div class="block-content">
        <div class="table-responsive">

            <table id="tableAjax"  class="table table-bordered table-striped table-green" >
                <thead>
                <tr>
                	<th ></th>
                    <th ><spring:message code="fe902.title.transaction" /></th>
                    <th ><spring:message code="be901.title.amount" /></th>
                    <th ><spring:message code="fe903.date.exam" /></th>
                    <th ><spring:message code="be901.title.invoiceno" /></th>
                    <th ><spring:message code="be901.title.transaction.datetime" /></th>
                    <th ><spring:message code="be901.title.payment.datetime" /></th>
                    <th ><spring:message code="be006.label.form.status" /></th>
                    <th ><spring:message code="general.vaccine.table.action" /></th> 
                </tr>
                </thead>
            </table>

        </div>
    </div>
</div>
<div id="pop-up-01" class="modal fade" role="dialog" aria-hidden="true" style="display: none;">
		 <div class="modal-dialog" style="width: 1000px">				
			<div class="modal-content ">
			  <div class="modal-header">
			  		<button type="button" class="close" data-dismiss="modal">×</button>
					<h4 class="modal-title"><spring:message code="be203.table.label.booking" /></h4>
			  </div>
			  <div class="modal-body pop-up-01-body table-responsive">
			  	<jsp:include page="fe902.jsp"></jsp:include>
 			 </div>
			  <div class="modal-footer">
				<button type="button" class="btn btn-default" data-dismiss="modal"><spring:message code="be005.label.back_btn" /></button> 
			  </div>
			</div>
		</div>
</div>
<script type="text/javascript" src="<c:url value='/assets/js/user/PaymentHistory.js'/>" ></script>
<script>
    jQuery.fn.dataTableExt.oApi.fnPagingInfo = function ( oSettings )
    {
        return {
            "iStart":         oSettings._iDisplayStart,
            "iEnd":           oSettings.fnDisplayEnd(),
            "iLength":        oSettings._iDisplayLength,
            "iTotal":         oSettings.fnRecordsTotal(),
            "iFilteredTotal": oSettings.fnRecordsDisplay(),
            "iPage":          oSettings._iDisplayLength === -1 ?
                    0 : Math.ceil( oSettings._iDisplayStart / oSettings._iDisplayLength ),
            "iTotalPages":    oSettings._iDisplayLength === -1 ?
                    0 : Math.ceil( oSettings.fnRecordsDisplay() / oSettings._iDisplayLength )
        };
    };
    var be901_status_currency = '<spring:message code="fe903.currency.title" />';
    var be901_status_all = '<spring:message code="general.select.all" />';
	var be901_status_finish = '<spring:message code="be901.title.status.finish" />';
	var be901_status_fail = '<spring:message code="be901.title.status.fail" />';
	var be901_status_force_finish = '<spring:message code="be901.title.status.fore.finish" />';
	var be901_status_force_cancel = '<spring:message code="be901.title.status.fore.cancel" />';
	var be901_status_requesting = '<spring:message code="be901.title.status.requesting" />';
	var be901_status_inprogress = '<spring:message code="be901.title.status.inprogress" />';
	var be901_status_cancel = '<spring:message code="be901.title.status.cancel" />';
	var be901_status_other = '<spring:message code="be901.title.status.other" />';
	var be901_title_pay =  '<spring:message code="be901.title.pay" />';
    $(document).ready(function() {
    	$('.tooltip-transaction').tooltipster();
        //Catch event when show modal confirm delete record movie talk history
        $('#confirmation').on('shown.bs.modal', function (e) {
            var cssBackDrop = $('.modal-backdrop');
            cssBackDrop.css("z-index","0");
        }); 
        function multiLanguage()
    	{
    		 var language = {
    				    "emptyTable":     '<spring:message code="general.not.data.found" />',
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
        initPage();
        fillDataToTable(multiLanguage());                
    });

</script>
 <script  type="text/javascript">
	  $(document).ready(function() {
		  var isMobile = MssUtils.detectmob();
			if(isMobile)
			{
				MssUtils.focusIncaseMobile('#searchBooking');
			}
		  var isFirefox = typeof InstallTrigger !== 'undefined';
	        var isChrome = !!window.chrome && !!window.chrome.webstore;
	        if(isChrome || isFirefox)
	        {	
	        	var header = $('.dataTables_scrollBody').width();
	        	$('.dataTables_scrollBody').css({'overflow' : 'hidden',"height": "100%","width": "100%" ,'border-color' : '#27ae61'});
	            setTimeout(function(){
	                $('#tableAjax').css({"width" : header});
	                $('.dataTables_scrollHeadInner .table-bordered').css({"width" : header });
	            },1000);
	            
	        }
		});
</script>
