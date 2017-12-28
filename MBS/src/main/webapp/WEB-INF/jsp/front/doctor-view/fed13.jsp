<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/security/tags" prefix="sec" %>

<!----modal starts here--->

<div class="modal fade bs-example-modal-sm" id="confirmation" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-sm">
    <div class="modal-content">
      <div class="modal-header">        
        <h4 class="modal-title" id="myModalLabel"><spring:message code="general.confirm.delete" /></h4>  
      </div>
      <div class="modal-body">
      <button type="submit" class="btn btn-success " id="yes"><spring:message code="be011.modal.confirm" /></button> 
      <button type="submit" class="btn btn-danger " data-dismiss="modal"><spring:message code="be011.modal.close" /></button>
      </div>     
    </div>
  </div>
</div>
<!--Modal ends here--->
             <div class="block">                         
                                <div class="block-content">
                                	 <div class="table-responsive">
			                                <table id="tableAjax"  class="table table-bordered table-striped table-green">
			                                    <thead>
			                                      <tr>
			                                      	<th></th>
			                                        <th style="width: 15%"><spring:message code="fed13.movieTalkHistory.department" /></th>
			                                        <th style="width: 25%"><spring:message code="fed13.movieTalkHistory.dateExam" /></th>
			                                        <th style="width: 12%"><spring:message code="fed13.movieTalkHistory.duration" /></th>
			                                        <th></th>
			                                        <th></th>
			                                        <th></th>
			                                      </tr>
			                                    </thead>
			                                </table>
                              		 </div>
                                </div>                                
               			</div> 
    
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

$(document).ready(function() {
	
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
			    }
			}
	 
	 fillDataToTable(language);	
	 $('.dataTables_scrollBody').css({'overflow' : 'hidden',"height": "100%","width": "100%"});
		});
	var isChrome = !!window.chrome && !!window.chrome.webstore;
	if(!isChrome)
	{
		setTimeout(function(){
		 $('#tableAjax').css({"width" : "99.8%"});	 
	},500);
	}
  </script>
   <script type="text/javascript" src="<c:url value='/assets/js/doctor/MovietalkHistory.js'/>" ></script>
                     