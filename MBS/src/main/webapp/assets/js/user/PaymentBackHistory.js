/**
 * @author TUNGLT
 *  Payment History Backend
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
	  initPage();
	  showDatatable();
	  $("#searchBtn").click(function() {

		  showDatatable();
	  });
var statusObj = {"1":be901_status_finish,"2":be901_status_fail,"3":be901_status_force_finish,"4":be901_status_force_cancel,"5":be901_status_requesting,"6":be901_status_inprogress,"7":be901_status_cancel,"8":"","9":be901_status_other};
function showDatatable()
{
	  var paymentFromDate = $("#paymentFromDate").val();
	  var paymentToDate = $("#paymentToDate").val();
	  var invoiceNo = $("#frmInvoiceNo").val();
	  var examFromDate = $("#examFromDate").val();
	  var examToDate = $("#examToDate").val();
	  var transactionId = $("#transactionId").val();
	  var amountFrom = $("#amountFrom").val();
	  var amountTo = $("#amountTo").val();
	  var paymentStatus = $("#frmPaymentStatus").val();
	  var patientCode = $('#patientCode').val();
	      
		$("#tblPaymentHistory").dataTable().fnDestroy();
		$('#tblPaymentHistory').DataTable({
			"bProcessing": false,
			"serverSide": true, // for process server side
			"filter": false, 
			"bFilter": false,// this is for disable filter (search box)
			"sPaginationType": "full_numbers",
			"ajax": function(data, callback, settings) {
				var info = $('#tblPaymentHistory').DataTable().page.info();
				// make a regular ajax request using data.start and data.length
				$.ajax({
					"url": "ajax-init-payment-history",
					"type": "POST",
					"dataType": "json",
					"contentType": "application/json",
					"data": JSON.stringify({
						"paymentFromDate": paymentFromDate,
						"paymentToDate": paymentToDate,
						"invoiceNo": invoiceNo,
						"examFromDate": examFromDate,
						"examToDate": examToDate,
						"transactionId": transactionId,
						"amountFrom": amountFrom,
						"amountTo": amountTo,
						"paymentStatus": paymentStatus,
						"patientCode": patientCode,
						"pageSize": info.length,
						"pageIndex": info.page + 1,
						"orderField": data.order.length > 0 ? data.columns[data.order[0].column].data : null,
						"orderValue": data.order.length > 0 ? data.order[0].dir : null
					}),
					"success": function(res){
						callback({
							recordsTotal: res.data.totalRecord,
							recordsFiltered: res.data.totalRecord,
							data: res.data.paymentHistories
						})
					}
				});
			},
			"language" : {
	        	  "sEmptyTable":     language.emptyTable,
	        	  "sInfo":           language.info,
	        	  "infoFiltered": " ",
	        	  "sInfoEmpty":      language.infoEmpty,
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
			"aoColumnDefs": [
				{ 'bSortable': true, 'aTargets': [ 0 ] }
			],
			"aaSorting": [[ 0, "desc" ]],
			"columns": [
				{ "mData": "rowNum" ,
					  render: function (data, type, row, meta) {
					        return meta.row + meta.settings._iDisplayStart + 1;
					    }},
				{ "data": "transactionId","bSortable": true, "render" : function(data, type, row, meta){
					var text = row.transactionIdShort;
					var textTooltip = row.transactionId;
        		    var temp =  $('<span class="tooltip-transaction" title=' + textTooltip + '>'+ text + '</span>')
        		    	.wrap('<div></div>')
                        .parent()
                        .html();
                     return temp;
			  }},
				{ 'bSortable': false ,"data": "amount","render" : function(data, type, row, meta){
					var text = row.amount;
					var currency = be901_status_currency;
        		    var temp =  $('<span>'+ text + ' ' + be901_status_currency + '</span>')
                     .wrap('<div></div>')
                        .parent()
                        .html();
                     return temp;
			  } },
				{ "data": "examDate" },
				{ 'bSortable': false,"data": "invoiceNo",
					  "render" : function(data, type, row, meta){
		        		    var id = row.transactionId + "," + row.status + "," + row.patientCode + "," +  row.invoiceNo + "," + row.fkOut + "," + row.orderId + "," + row.transactionDateTime;
		        		    var temp =  $('<a  href="" data-toggle="modal" class="transaction_show_popup" data-target="#pop-up-01" data-id= '+id+' style="text-decoration: none !important ;color:#0086b3;">'+ row.invoiceNo + '</a>')
		                     .wrap('<div></div>')
		                        .parent()
		                        .html();
		                     return temp;
					  } },
				{ "data": "transactionDateTime"},
				{ 'bSortable': false,"data": "paymentDateTime"},
				{ 'bSortable': false,"data": "patientCode" },
				{ 'bSortable': false,"data": "patientName" },
				{'bSortable': false,"data": "status",
					"render" : function(data, type, row, meta){
						var status = row.status;
						var text = statusObj[status];
	        		    var temp =  $('<span>'+ text + '</span>')
	                     .wrap('<div></div>')
	                        .parent()
	                        .html();
	                     return temp;
				  }}	
				
			]
		});

	
}
function initOrderMedicinesPopup(objSendserver) {
	var source = $("#payment-detail-list").html();
	var template = Handlebars.compile(source);
	$('#tblDetailPayment').dataTable().fnDestroy();
	$.ajax({
		type: "post",
		url: "ajax-init-payment-detail-popup",
		dataType: "json",
		data : JSON.stringify(objSendserver),
		async: false,
		beforeSend: function(xhr) {
            xhr.setRequestHeader("Accept", "application/json");
            xhr.setRequestHeader("Content-Type", "application/json");
        },
		success: function(response) {
			if (response.status == 200) {
				var data = {
						'orderMedicines' : response.data,
				};
				$('#detail-payment-body').empty().append(template(data));
				initDetailPopup(objSendserver);
			}
		},
		complete: function() {
			loadLanguageForDataTable();
		},
		error: function() {
			alert('Error while request payment-detail..');
		}
	});
	
};
	  $('#pop-up-01').on('hidden.bs.modal', function () {
		  $("#savePayment").off("click");
	  });
$('#pop-up-01').on('shown.bs.modal', function(event) {
	var check = false;
	var id = $(event.relatedTarget).attr('data-id').split(',');
 	var objSendserver = {
 			"transaction_id" : id[0],
 			"status" : id[1],
 			"patient_code" : id[2],
 			"invoice_no" : id[3],
 			"fk_out" : id[4],
 			"order_id" : id[5],
 			"tran_date" : id[6]
 	};
    $("#commentInput").val('');
 	$('#comment').hide();
 	$("#savePayment").show();
	$("#commentInputRow").show();
 	if(objSendserver.status == '5'){
 	  $('#frmPaymentStatus1').html( '<select class="form-control" >' +
         '<option value="4">'+be901_status_force_cancel+'</option>' +
         '<option value="5" selected >' + be901_status_requesting + '</option>' +
     '</select>');
 	}
 	else if(objSendserver.status == '6')
 		{
 		$('#frmPaymentStatus1').html( '<select class="form-control" >' +
 		         '<option value="3">' + be901_status_force_finish + '</option>' +
 		         '<option value="4">' + be901_status_force_cancel + '</option>' +
 		         '<option value="6" selected>' + be901_status_inprogress + '</option>' +
 		         '<option value="9">' + be901_status_other + '</option>' +
 		     '</select>');
 		}
 	else if(objSendserver.status == '2')
 		{
 		$('#frmPaymentStatus1').html( '<select class="form-control" >' +
		         '<option value="2" selected>' + be901_status_fail + '</option>' +
		         '<option value="7" >' + be901_status_cancel + '</option>' +
		     '</select>');
 		}
 	else
 		{
 		check = true;
 		$('#frmPaymentStatus1').html('<span>'+statusObj[objSendserver.status] + '</span>');
 		$("#savePayment").hide();
 		$("#commentInputRow").hide();		
 		}
 	initOrderMedicinesPopup(objSendserver);
 	$("#savePayment").click(function()
 	{
 		var comment = $("#commentInput").val();
 		if(comment == 'null' || comment == '' || comment == null)
 			{
 			$("#comment").show();
 			setTimeout(function(){
 				$("#comment").hide();
 			},5000);	
 			}
 		else{
			$("#savePayment").off("click");
 			var status_change = $('#frmPaymentStatus1 .form-control').val();
 			if(check == true)
 				{
 				status_change = objSendserver.status;
 				}
 			var objUpdateStatus = {
 					"comment" : comment,
 					"transaction_id" : objSendserver.transaction_id,
 					"fk_out" : objSendserver.fk_out,
 					"status" : status_change,
 					"patient_code": objSendserver.patient_code,
 					"order_id" : objSendserver.order_id,
 					"tran_date" : objSendserver.tran_date
 			}
 			$.ajax({
 				type: "post",
 				url : "update-detail-payment",
 				data : JSON.stringify(objUpdateStatus),
 				dataType:'json',
 				beforeSend: function(xhr) {
 					xhr.setRequestHeader("Accept", "application/json");
 					xhr.setRequestHeader("Content-Type", "application/json");
 				},
 				success: function(response) {
 					if (response.status == 200 && (response.data == "true" || response.data == true)) {
 						 showDatatable();
 					}
 					else
					{
					alert(be901_alert_fail);
					}
 				},
 				error: function(error) {
 					// TODO: handle errors
 					alert(be901_alert_fail);
 				},
 				complete:function()
 				{

 					$('#pop-up-01').modal('hide');

 				}
 			})
 			
 		 }
 	});
});


function initDetailPopup(objSendserver)
{
	$.ajax({
		type: "post",
		url: "ajax-detail-payment",
		data: JSON.stringify(objSendserver),
		dataType: 'json',
		beforeSend: function(xhr) {
			xhr.setRequestHeader("Accept", "application/json");
			xhr.setRequestHeader("Content-Type", "application/json");
		},
		success: function(response) {
			if (response.status == 200) {
				fillPaymentInfo(response.data);
			}
			else
			{
				console.log('error');	
			}
		},
		error: function(error) {
			// TODO: handle errors
			console.log('error');
		}
	});
}

function fillPaymentInfo(data)
	{
	$.each(data, function(index, value) {
	if(value===null||value==='null'||value === 'undefined')
		 {
		 $('.' + index +'').text('');
		 }
	 else{
		 $('.' + index +'').text(value);
	 }
	});
}
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
			//$( "#examFromDate" ).datepicker( "option", "minDate", selectedDate );
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
function loadLanguageForDataTable(){
	$('#tblVaccineHospital').dataTable({
		"language": {
			"sProcessing":   "処理中...",
			//"sLengthMenu":   "_MENU_ 件表示",
			"sLengthMenu":		"_MENU_ " + vm_table_record_each_page,
			//"sZeroRecords":  "データはありません。",
			"sZeroRecords":  vm_table_empty,
			//"sInfo":         " _TOTAL_ 件中 _START_ から _END_ まで表示",
			"sInfo":         vm_s_info,
			//"sInfoEmpty":    " 0 件中 0 から 0 まで表示",
			"sInfoEmpty":    vm_table_info_empty,
			"sInfoFiltered": "（全 _MAX_ 件より抽出）",
			"sInfoPostFix":  "",
			"sSearch":       "検索:",
			"sUrl":          "",
			"oPaginate": {
				"sFirst":    "先頭",
				"sPrevious": vm_table_previous,
        	    "sNext":     vm_table_next,
        	    "sLast":     vm_table_last
			}
		},
		"aoColumnDefs": [{
			'bSortable': false,
			'aTargets': ['nosort']
		}]
	});
	$("#tblVaccineHospital_filter").hide();
}
 });