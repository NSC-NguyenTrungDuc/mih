$(document).ready(function(){
	loadLanguageForDataTable();
    
    function loadLanguageForDataTable(){
		$('#vaccine-info-table').dataTable({
			"language": {
				"sProcessing":   "処理中...",
				"sLengthMenu":   "_MENU_ " + fe000_table_record_each_page,
				"sZeroRecords":  fe000_table_empty,
				"sInfo":         fe000_s_info,
				"sInfoEmpty":    fe000_table_info_empty,
				"sInfoFiltered": "（全 _MAX_ 件より抽出）",
				"sInfoPostFix":  "",
				"sSearch":       "検索:",
				"sUrl":          "",
				"oPaginate": {
					"sFirst":    "先頭",
					"sPrevious": fe000_table_previous,
					"sNext":     fe000_table_next,
					"sLast":     fe000_table_last
				}
			},
			"bSort": false
	    });
		$("#vaccine-info-table_filter").hide();
	}
});
		