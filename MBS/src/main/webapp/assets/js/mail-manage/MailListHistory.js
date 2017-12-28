$(document).ready(function() {
	initPage();
	loadLanguageForDataTable();
	
	$("#searchBtn").click(function() {
		var mailListId = $("#mailListId").val();
		var fromDate = $("#fromDate").val();
		var toDate = $("#toDate").val();
		
		var data = {"mailListId":mailListId,"fromDate":fromDate,"toDate":toDate};
		var dataHtml= "";
		$('#tblMailListHistory').dataTable().fnDestroy();
		$.ajax({
			type : "post",
			url : "ajax-search-mail-list-history",
			data : JSON.stringify(data),
			dataType : "json",
			async : false,
			beforeSend : function(xhr) {
				xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type","application/json");
			},
			success : function(response) {
				var source = $("#search-result").html();
				var template = Handlebars.compile(source);
				dataHtml = template({'model': response.data});
			},
			complete: function() {
				$('#search-result-body').empty().html(dataHtml);
			},
			error : function() {
				alert('Error while request..');
			}
		});
		
//		$("#tblMailListHistory").dataTable({
//			'aoColumnDefs': [{
//		        'bSortable': false,
//		        'aTargets': ['nosort']
//		    }]
//		});
//		$("#tblMailListHistory_filter").hide();
		loadLanguageForDataTable();
	});
	
	function initPage() {
		
		$("#fromDate").datepicker({ 
			dateFormat: 'yy/mm/dd',
			onClose: function( selectedDate ) {
		        $( "#toDate" ).datepicker( "option", "minDate", selectedDate );
		    }
		});
		$("#toDate").datepicker({ 
			dateFormat: 'yy/mm/dd',
			onClose: function( selectedDate ) {
		        $( "#fromDate" ).datepicker( "option", "maxDate", selectedDate );
		    }
		});
		
		$("#fromDate").val(getCurrentDate());
		$("#toDate").val(getCurrentDate());
	}
	
	function getCurrentDate() {
		var now = new Date();
	    var day = ("0" + now.getDate()).slice(-2);
	    var month = ("0" + (now.getMonth() + 1)).slice(-2);
	    var today = now.getFullYear() +"/"+ month +"/"+ day+"";
	    return today;
	}
	
	function insertString(index, sourceString, addString) {
		  if (index > 0)
		    return sourceString.substring(0, index) + addString + sourceString.substring(index, sourceString.length);
		  else
		    return addString + sourceString;
	}; 
	
	function loadLanguageForDataTable(){
		$('#tblMailListHistory').dataTable({
	        "language": {
				"sProcessing":   "処理中...",
				"sLengthMenu":   "_MENU_ " + be405_table_record_each_page,
				"sZeroRecords":  be405_table_empty,
				"sInfo":         be405_s_info,
				"sInfoEmpty":    be405_table_info_empty,
				"sInfoFiltered": "（全 _MAX_ 件より抽出）",
				"sInfoPostFix":  "",
				"sSearch":       "検索:",
				"sUrl":          "",
				"oPaginate": {
					"sFirst":    "先頭",
					"sPrevious": be405_table_previous,
					"sNext":     be405_table_next,
					"sLast":     be405_table_last
				}
	        },
	        "aoColumnDefs": [{
		        'bSortable': false,
		        'aTargets': ['nosort']
		    }]
	    });
		$("#tblMailListHistory_filter").hide();
	}
});


