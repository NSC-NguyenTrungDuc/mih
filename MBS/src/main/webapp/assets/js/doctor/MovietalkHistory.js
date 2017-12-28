/**
 * @author TUNGLT
 *  Function relate module profile information
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

	 var table = $("#tableAjax").dataTable( {
	      "bProcessing": false,
	      "bServerSide": true,
	      "sort": "position",
	      "bFilter": false,
	      "bStateSave": true,
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
	          { "mData": "examinationDateTime","width": "25%" },
	          { "mData": "duration" },
	          { "mData": null, "bSortable": false,
	        	  "render" : function(data, type, row, meta){
	        		     var src = row.mtHistoryUrl;
	        		     var temp = $('<a style="color:#337ab7 ; width:100%;" href='+src+' type="audio/mpeg" codecs="mp3" download="true"><i class="fa fa-2x fa-download" aria-hidden="true"></i></a>');
	                     return temp.wrap('<div></div>')
	                        .parent()
	                        .html();
	               }
	          },
	          { "mData": null,"bSortable": false,
		        		 "render" : function(data, type, row, meta){
		        		     var src = row.mtHistoryUrl;
		        		     var temp = $('<audio controls preload="none"><source src='+src+'></audio>');
		                     return temp.wrap('<div></div>')
		                        .parent()
		                        .html();

		               }
		          },
	          { "mData": "duration","bSortable": false,
	        	  "render" : function(data, type, row, meta){
	        		     var id = row.mtHistoryId;
	        		     var temp =  $('<a  href="" style="color:#337ab7" class="delete"  data-toggle="modal" data-target="#confirmation" data-id= '+id+' ><i class="fa fa-2x fa-trash-o" aria-hidden="true"></i></a>')
	                     .wrap('<div></div>')
	                        .parent()
	                        .html();
	                     return temp;

	               }
	          }

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
	//hide the modal when click yes
	}) ;