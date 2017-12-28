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

 function fillDataToTable(language)
 {

	 var table = $("#tableAjax").dataTable({
	      "bProcessing": false,
	      "bServerSide": true,
	      "sort": "position",
	      "bFilter": false,
	      "bStateSave": true,
	      "sScrollY": "100%",
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
	      "sAjaxSource": "get-history-movietalk",
	      "aoColumns": [
	          { "mData": "rowNum" ,
	        	  render: function (data, type, row, meta) {
	        	        return meta.row + meta.settings._iDisplayStart + 1;
	        	    }},
	          { "mData": "department" },
	          { "mData": "examinationDateTime" },
	          { "mData": "duration" },
	          { "mData": null, "bSortable": false,
	        	  "render" : function(data, type, row, meta){
	        		     var src = row.mtHistoryUrl;
	        		     var temp = $('<a style="color:#337ab7" href='+src+' class="download" download="filename"><i class="fa fa-2x fa-download" aria-hidden="true"></i></a>');
	                     return temp.wrap('<div></div>')
	                        .parent()
	                        .html();
	               }
	          },
	          { "mData": null,"bSortable": false,
		        		 "render" : function(data, type, row, meta){
		        		     var src = row.mtHistoryUrl;
		        		     var temp = $('<audio src='+src+' controls preload="none"></audio>');
		        		     //var temp =  $('<a  href="" style="color:#337ab7" class="play"  data-id= '+src+'  ><i class="fa fa-2x fa-play" aria-hidden="true"></i></a>');
		                     return temp.wrap('<div></div>')
		                        .parent()
		                        .html();

		               }
		          },
	      ]
	  } );
 }
 //Fix bug just play only audio
 window.addEventListener("play", function(evt)
		 {
		     if(window.$_currentlyPlaying && window.$_currentlyPlaying != evt.target)
		     {
		         window.$_currentlyPlaying.pause();
		     } 
		     window.$_currentlyPlaying = evt.target;
		 }, true);
 $('#yes').click(function (e) {
	  e.preventDefault()
	  var id = $('.delete').data('id');
	    $.ajax({
            url: 'delete-movietalk/' + id,
            type: 'PUT',
            success: function (res) {
            	$('#tableAjax').DataTable().ajax.reload();
                $('#confirmation').modal('hide');
            },
            error: function(e)
            {

            	 $('#confirmation').modal('hide');
            }
        });
	}) ;
