/**
 * @author TUNGLT
 *  Function relate module profile information
 */

//Config table
var roundNum = 2;
var iDisplayLength = 10;
var targets = 0;
var iDisplayStart = 0;

/**
 * @summary Short description : function get Profile Information
 * @since 18.8.06
 * @access private
 * @param type $varUrl : url request from API Server
 * @return void.
 */

 function getBasicProfileInformation(url,labelMale,labelFemale)
 {
	 var basicInfo = $('.info-text');
	 $.ajax({
		 url: url,
		 type: 'GET',
		 dataType: 'json',
		 success: function(json) {
			 basicInfo[0].innerText =  checkValueIsNotNull(json.content.full_name)?json.content.full_name:'';
			 basicInfo[1].innerText =  checkValueIsNotNull(json.content.full_name_kana)?json.content.full_name_kana:'';
			 var gender = json.content.gender;
			 if(gender == "M")
				 basicInfo[2].innerHTML = labelMale ;
			 else
				 basicInfo[2].innerHTML = labelFemale;
			 var birthDay = json.content.birthday.split("/");
			 basicInfo[3].innerHTML = birthDay[2] + ' <span class="nofocus">/ </span> ' + birthDay[1] +  ' <span class="nofocus">/</span> ' + birthDay[0];
			 basicInfo[4].innerText = checkValueIsNotNull(json.content.prefecture)?json.content.prefecture:'';
			 basicInfo[5].innerText = checkValueIsNotNull(json.content.city)?json.content.city:'';
			 basicInfo[6].innerText = checkValueIsNotNull(json.content.address)?json.content.address:'';
			 basicInfo[7].innerText = checkValueIsNotNull(json.content.occupation)?json.content.occupation:'';
		  },
         error:function()
         {
        	 console.log("Get profile information error");
         }

		 });
 }
 
 function checkValueIsNotNull(value)
 {
	 return value!=='null'&&value!==null&&value!=='undefine';
 }
 

  /**
  * @summary Short description : function fill dataAjax table
  * @since 18.8.06
  * @access private
  * @return void.
  */

 function fillDataToTable(language)
 {

	 $("#tableAjax").dataTable( {
		 /*"language": {
	            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Japanese.json"
	        },*/
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
	       "error"     : language.error,
	      //Default: Page display length
	      "iDisplayLength": iDisplayLength,
	      //We will use below variable to track page number on server side(For more information visit: http://legacy.datatables.net/usage/options#iDisplayStart)
	      "iDisplayStart": iDisplayStart,
	      "sDom": '<"top"flp>rt<"bottom"ip><"clear">',
	      "fnDrawCallback": function () {
	      },
	      "sAjaxSource": "get-history-insurance",
	      "aoColumns": [
	          { "mData": "rowNum" ,"bSortable": false,
	        	  render: function (data, type, row, meta) {
	        	        return meta.row + meta.settings._iDisplayStart + 1;
	        	    }},
	          { "mData": "reservationDateTime" },
	          { "mData": "referLink",
	        	  "render" : function(data, type, row, meta){
	                  if(type === 'display'){
	                	 if(data==null)
	                		 data='';
	                     return $('<a style="color:#337ab7">')
	                        .attr('href', data).attr('download','filename')
	                        .text(data)
	                        .wrap('<div></div>')
	                        .parent()
	                        .html();

	                  } else {
	                     return data;
	                  }
	               }
	          }

	      ]
	  } );
 }
