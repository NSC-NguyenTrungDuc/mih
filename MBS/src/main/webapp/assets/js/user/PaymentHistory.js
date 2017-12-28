/**
 * @author TUNGLT
 *  Patient view movie talk history
 */

//Config table

var iDisplayLength = 10;
var targets = 0;
var iDisplayStart = 0;
var order = 1;

 var roundNum = 2;
  /**
  * @summary Short description : function fill dataAjax table
  * @since 18.8.06
  * @access private
  * @return void.
  */

  $(document).ready(function() {
	  $("#searchBtn").click(function() {

		  var paymentFromDate = $("#paymentFromDate").val();
		  var paymentToDate = $("#paymentToDate").val();
		  var invoice_no = $("#frmInvoiceNo").val();
		  var examFromDate = $("#examFromDate").val();
		  var examToDate = $("#examToDate").val();
		  var transactionId = $("#transactionId").val();
		  var amountFrom = $("#amountFrom").val();
		  var amountTo = $("#amountTo").val();
		  var paymentStatus = $("#frmPaymentStatus").val();

		  oTable = $("#tableAjax").dataTable();
		  var oSettings = oTable.fnSettings();
		  oSettings.sAjaxSource  = "get-history-payment?patient_from_date="+ paymentFromDate+"&payment_to_date="+paymentToDate+"&invoice_no="+invoice_no
		  +"&exam_from_date="+examFromDate+"&exam_to_date="+examToDate+"&transaction_id="+transactionId+"&amount_from="+amountFrom
			  +"&amount_to="+amountTo+"&status="+paymentStatus;
		  $('#tableAjax').DataTable().ajax.reload();

	  });
  });
function initPage() {

	$("#paymentFromDate").datepicker({
		dateFormat: 'yy/mm/dd',
		onClose: function( selectedDate ) {
			//$( "#paymentFromDate" ).datepicker( "option", "minDate", selectedDate );
		}
	});

	$("#paymentToDate").datepicker({
		dateFormat: 'yy/mm/dd',
		onClose : function( selectedDate ) {
			//$( "#paymentToDate" ).datepicker( "option", "maxDate", selectedDate );
		}
	});


	$("#examFromDate").datepicker({
		dateFormat: 'yy/mm/dd',
		onClose: function( selectedDate ) {
		//	$( "#examFromDate" ).datepicker( "option", "minDate", selectedDate );
		}
	});

	$("#examToDate").datepicker({
		dateFormat: 'yy/mm/dd',
		onClose : function( selectedDate ) {
			//$( "#examToDate" ).datepicker( "option", "maxDate", selectedDate );
		}
	});

	$("#paymentFromDate").val(getDate(new Date()));
	$("#paymentToDate").val(getDate(new Date()));
}
function getDate(date) {
	var day = ("0" + date.getDate()).slice(-2);
	var month = ("0" + (date.getMonth() + 1)).slice(-2);
	var result = date.getFullYear() +"/"+ month +"/"+ day+"";
	return result;
}
 function fillDataToTable(language)
 {
	 var statusObj = {"1":be901_status_finish,"2":be901_status_fail,"3":be901_status_force_finish,"4":be901_status_force_cancel,"5":be901_status_requesting,"6":be901_status_inprogress,"7":be901_status_cancel,"8":"","9":be901_status_other};
	 var paymentFromDate = $("#paymentFromDate").val();
	 var paymentToDate = $("#paymentToDate").val();
	 var table = $("#tableAjax").dataTable({
	      "bProcessing": false,
	      "bServerSide": true,
	      "sort": true,
	      "bFilter": false,
	      "bStateSave": false,
	      "sScrollY": "100%",
	      "scrollX": true,
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
	        	    },
	        	  "oAria": {
	        	        "sSortAscending":  ": 列を昇順に並べ替えるにはアクティブにする",
	        	        "sSortDescending": ": 列を降順に並べ替えるにはアクティブにする"
	        	    }
	        	},
	       "pagingType": "full_numbers",
	       "error"     : language.error,
	      //Default: Page display length
	      "iDisplayLength": iDisplayLength,

	      //We will use below variable to track page number on server side(For more information visit: http://legacy.datatables.net/usage/options#iDisplayStart)
	      "iDisplayStart": iDisplayStart,
	      "sDom": '<"top"flp>rt<"bottom"ip><"clear">',
	      "fnDrawCallback": function () {
	      },
	      "sAjaxSource": "get-history-payment?patient_from_date="+ paymentFromDate+"&payment_to_date="+paymentToDate,
	      "aoColumns": [
            { "mData": "rowNum" ,
	        	  render: function (data, type, row, meta) {
	        	        return meta.row + meta.settings._iDisplayStart + 1;
	        	    }},
			  { "mData": "transactionIdShort", "bSortable": true,"render" : function(data, type, row, meta){
					var text = row.transactionIdShort;
					var textTooltip = row.transactionId;
        		    var temp =  $('<span class="tooltip-transaction" title=' + textTooltip + '>'+ text + '</span>')
        		    	.wrap('<div></div>')
                        .parent()
                        .html();
                     return temp;
			  }},
			  { "mData": "amount","bSortable": false ,"render" : function(data, type, row, meta){
					var text = row.amount;
					var currency = be901_status_currency;
        		    var temp =  $('<span>'+ '  '+ text + '' + be901_status_currency + '</span>')
                     .wrap('<div></div>')
                        .parent()
                        .html();
                     return temp;
			  }},
			  { "mData": "examDate"},
			  { "mData": "invoiceNo","bSortable": false ,
				  "render" : function(data, type, row, meta){
	        		    var id = row.transactionId + "," + row.status + "," + row.patientCode + "," +  row.invoiceNo + "," + row.fkOut + "," + row.orderId;
	        		    var temp =  $('<a  href="" data-toggle="modal" class="transaction_show_popup" data-target="#pop-up-01" data-id= '+id+' style="text-decoration: none !important">'+ row.invoiceNo + '</a>')
	                     .wrap('<div></div>')
	                        .parent()
	                        .html();
	                     return temp;
	               }},
			  { "mData": "transactionDateTime",},
			  { "mData": "paymentDateTime","bSortable": false },
			  { "mData": "status","bSortable": false,"render" : function(data, type, row, meta){
					var status = row.status;
					var text = statusObj[status];
      		    var temp =  $('<span>'+ text + '</span>')
                   .wrap('<div></div>')
                      .parent()
                      .html();
                   return temp;
			  }},
			  {	"mData": "valueStatus","bSortable": false,
				  "render" : function(data, type, row, meta){
	        		    var status = row.status;
	        		    var patientCode = row.patientCode;
	        		    var fkOut = row.fkOut;
	        		    var invoiceNo = row.invoiceNo;
	        		    var text = '-';
	        		    if(status === '5')
	        		    {
	        		    text = be901_title_pay;
	        		    return  $('<a  href="/mss-web/payment-process/index?patient_code='+patientCode + '&fk_out='+fkOut + '&order_id=' +row.orderId +'"' + 'style="text-decoration: none !important">'+ text + '</a>')
	                     .wrap('<div></div>')
	                        .parent()
	                        .html();
	        		    }
	        		    else
	        		    {
	        		    	return  $('<a style="text-decoration: none !important">'+ text + '</a>')
		                     .wrap('<div></div>')
		                        .parent()
		                        .html();
		        		    
	        		    }
	               }  
			  }
	      ]
	  } );
 }
 
 $('#pop-up-01').on('shown.bs.modal', function(event) {
	 	var id = $(event.relatedTarget).attr('data-id').split(',');
	 	var objSendserver = {
	 			"transaction_id" : id[0],
	 			"status" : id[1],
	 			"patient_code" : id[2],
	 			"invoice_no" : id[3],
	 			"fk_out" : id[4],
	 			"order_id" : id[5]
	 	};
	 	console.log("Object send server" +objSendserver);
	    //Call two ajax 
	 	var error = true;
	 	var p = new Promise(function(resolve,reject){
	 		$.ajax({
				type: "post",
				url: "ajax-detail_payment",
				data: JSON.stringify(objSendserver),
				dataType: 'json',
				beforeSend: function(xhr) {
					xhr.setRequestHeader("Accept", "application/json");
					xhr.setRequestHeader("Content-Type", "application/json");
				},
				success: function(response) {
					if (response.status == 200) {
						resolve(response.data);				
					}
					else
					{
					   reject(error);	
					}
				},
				error: function(error) {
					// TODO: handle errors
					reject(error);
					console.log('error');
				},
				complete:function()
				{
					$("#tableAjax1").dataTable().fnDestroy(); 
				}
			});
	 	});
	 	p.then(function(response){
	 		fillOrderMedicine();
	 		fillPaymentInfo(response);
	 		},function(err){
	 			console.log("Error get data");
	 		})
	})
	function fillPaymentInfo(data)
 	{
	 var statusObj = {"1":be901_status_finish,"2":be901_status_fail,"3":be901_status_force_finish,"4":be901_status_force_cancel,"5":be901_status_requesting,"6":be901_status_inprogress,"7":be901_status_cancel,"8":"","9":be901_status_other};
	 $.each(data, function(index, value) {
		 if(value===null||value==='null'||value === 'undefined')
			 {
			 $('.' + index +'').text('');
			 }
		 else{
			 if(index === 'status')
				 $('.' + index +'').text(statusObj[value]);
			 else{
				 $('.' + index +'').text(value);
				 console.log(index + "---" + value);
			 }
		 }
		}); 
 	}
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
	function fillOrderMedicine()
 	{
	 var table = $("#tableAjax1").dataTable({
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
	          { "bSortable": false, "mData": "hangmogName" ,  sWidth: '40%' ,
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
 
 
