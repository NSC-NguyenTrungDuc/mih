/**
 * @author HoanPC
 *  Function relate module profile information
 */
//Config table
var iDisplayLength = 10;
var targets = 0;
var iDisplayStart = 0;

 function fillDataToTableExamination(date, language){
	 
	 $("#tableExaminationAjax").dataTable( {
		 "language" : {
	       	  "sEmptyTable":     language.emptyTable,
	       	  "sInfo":           language.info,
	       	    "sInfoEmpty":    language.infoEmpty,
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
		  "info":     false,
		  "bPaginate": false,
	      "bProcessing": false,
	      "bServerSide": true,
	      "sort": "position",
	      "bFilter": false, 
	      "bStateSave": true,
	      "columnDefs": [ {
	            "searchable": false,
	            "orderable": false,
	            "targets": targets
	        } ],
	       "pagingType": "full_numbers",
	      //Default: Page display length
	      "iDisplayLength": iDisplayLength,
	      //We will use below variable to track page number on server side(For more information visit: http://legacy.datatables.net/usage/options#iDisplayStart)
	      "iDisplayStart": iDisplayStart,
	      "sDom": '<"top"flp>rt<"bottom"ip><"clear">',
	      "fnDrawCallback": function () {
	      },         
	      "sAjaxSource": "get-waiting-list?examinationDate="+$('#selected_date_waiting').html(),
	      "aoColumns": [
			  { "mData": null,"bSortable": false, 
	        		 "render" : function(data, type, row, meta){
	        		     var src = row.isOnline;
	        		     if(src=='1') {
	 			      		return $('<div class="icon-ava available"><i class="fa fa-user"></i></div>')
	 			              .wrap('<div></div>')
	 			              .parent()
	 			              .html();
	 			      	 } else {
	 			      		return $('<div class="icon-ava"><i class="fa fa-user"></i></div>')
	 				      	  .wrap('<div></div>')
	 			              .parent()
	 			              .html();
	 			      	 }
	               }  	 
	          },
			  { "mData": "examinationTime" },
	          { "mData": "departmentName" },
	          { "mData": "patientName" },
	          { "mData": "patientCode",
				  "render" : function(data, type, row, meta){
			        if(type === 'display'){
			        	return $('<strong>' + data + '</strong>')
			              .wrap('<div></div>')
			              .parent()
			              .html();
			        } else {
			           return data;
			        }
			     }  
			  },
	          { "mData": "patientNameKana" },
	          { "mData": "receiptedTime",
	        	  "render" : function(data, type, row, meta){
	                  if(type === 'display'){
	                	 if(data==null)
	                		 data='';
	                     return data;
	                  } else {
	                     return data;
	                  }
	               }  
	          },
	          { "mData": null,"bSortable": false, 
	        		 "render" : function(data, type, row, meta){
	        		     var src = row.isOnline;
	        		     if(src=='1') {
	                		 return $('<button class="btn btn-round btn-green btn-opmt" id="' + row.patientCode + '*' + row.mtCallingId + '*' + row.examinationDate +'*' + row.examinationTime +'*' + row.reservationCode+'*' + row.reservationId+'"><i class="fa fa-video-camera"></i></button>')
		                        .wrap('<div></div>')
		                        .parent()
		                        .html();
	                	 } else {
	                		 {
	                			if(row.hasTokenDevice === "true" || row.hasTokenDevice === true)
	                				{
	                				 return $('<button class="btn btn-round btn-green btn-opmt" id="' + row.patientCode + '*' + row.mtCallingId + '*' + row.examinationDate +'*' + row.examinationTime +'*' + row.reservationCode+'*' + row.reservationId+'"><i class="fa fa-video-camera"></i></button>')
	 		                        .wrap('<div></div>')
	 		                        .parent()
	 		                        .html();
	                				 }
	                			else{
	                			 return $('<button class="btn btn-round btn-lightgray disabled" id="' + row.patientCode + '"><i class="fa fa-video-camera"></i></button>')
			                        .wrap('<div></div>')
			                        .parent()
			                        .html();
	                			}
	                		 }
	                	 }

	               }  	 
	          },
	  		           
	      ]
	  } );
 }
