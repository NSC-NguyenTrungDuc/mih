$(document).ready(function() {
	var latestData = [];
	initPage();
	
	// action button search
	$("#searchBtn").click(function() {
		var patientSex = null;
		var totalRecordFromSV = 0;
		var arraySex = document.getElementsByName('patientSex');
		for (var int = 0; int < arraySex.length; int++) {
			var sex = arraySex.item(int);
			if(sex.checked){
				patientSex = sex.value;
			}
		}
		
		var patientContact = '';
        var chks = document.getElementsByName('patientContact');
        var isEmail;
        var isPhone;
        for ( var i = 0; i < chks.length; i++) {
        	var contact = chks.item(i);
            if (contact.checked) {
                patientContact += contact.value;
            }
        }
        
		$("#tblCrmList").dataTable().fnDestroy();
		$('#tblCrmList').DataTable({
			"serverSide": true, // for process server side
			"filter": false, // this is for disable filter (search box)
			"sPaginationType": "full_numbers",
			"ajax": function(data, callback, settings) {
				var info = $('#tblCrmList').DataTable().page.info();
				// make a regular ajax request using data.start and data.length
				$.ajax({
					"url": "ajax-search-crm-list",
					"type": "POST",
					"dataType": "json",
					"contentType": "application/json",
					"data": JSON.stringify({
						"diseaseName": $("#diseaseName").val(),
						"statusOfDisease": $("#statusOfDisease").val(),
						"fromLastestGoHospital": $("#fromLastestGoHospital").val(),
						"toLastestGoHospital": $("#toLastestGoHospital").val(),
						"fromPatientAge": $("#fromPatientAge").val(),
						"toPatientAge": $("#toPatientAge").val(),
						"patientSex": patientSex,
						"patientContact": patientContact,
						"pageSize": info.length,
						"pageIndex": info.page + 1,
						"orderField": data.order.length > 0 ? data.columns[data.order[0].column].data : null,
						"orderValue": data.order.length > 0 ? data.order[0].dir : null
					}),
					"success": function(res){
						latestData = res.data.listCrmPatientModel;
						callback({
							recordsTotal: res.data.totalRecords,
							recordsFiltered: res.data.totalRecords,
							data: res.data.listCrmPatientModel
						})
					}
				});
			},
			"language": {
				"sProcessing":   "???...",
				"sLengthMenu":   "_MENU_ " + be405_table_record_each_page,
				"sZeroRecords":  be405_table_empty,
				"sInfo":         be405_s_info,
				"sInfoEmpty":    be405_table_info_empty,
				"sInfoFiltered": "(? _MAX_ ?????)",
				"sInfoPostFix":  "",
				"sSearch":       "??:",
				"sUrl":          "",
				"oPaginate": {
					"sFirst":    false,
					"sPrevious": be405_table_previous,
					"sNext":     be405_table_next,
					"sLast":     be405_table_last
				}
			},
			/*"aoColumnDefs": [{
			 'bSortable': false,
			 'aTargets': ['nosort']
			 }],*/
			"aoColumnDefs": [
				{ 'bSortable': false, 'aTargets': [ 0 ] }
			],
			"aaSorting": [[ 3, "desc" ]],
			"columns": [
				{
					"data": "check",
					render: function ( data, type, row ) {
						return '<input type="checkbox" class="chk-send-email" ' + (data ? 'checked' : '') + '>';
					},
				},
				{ "data": "patientName" },
				{ "data": "diseaseName" },
				{ "data": "lastestGoHospital" },
				{ "data": "patientAge" },
				{ "data": "patientSex" },
				{ "data": "patientTel" },
				{ "data": "patientEmail" }
			]
		});

		/*$('#tblCrmList').on( 'change', 'input.editor-active', function () {
		} );*/
	});
	
	// action button confirm email
	$("#btn-send-email").click(function() {
		$('#selectMailTemp').text("");
		var mailListSends = [];
		$("table tbody tr").each(function(index, el) {
			if($(this).find("input.chk-send-email").is(":checked")) {
				//mailListSends.push(latestData[index]);

				mailListSends.push({
					'patientName' : latestData[index].patientName,
					'diseaseName' : latestData[index].diseaseName,
					'lastestGoHospital' : latestData[index].lastestGoHospital,
					'patientAge' : latestData[index].patientAge,
					'patientSex' : latestData[index].patientSex,
					'patientEmail' : latestData[index].patientEmail,
					'isSentEmail' : true,
				});
			}
			
		});
		
		$.ajax({
			type: "post",
			url: "ajax-crm-send-mail-list-confirm",
			data: JSON.stringify(mailListSends),
			dataType: "json",
			beforeSend: function(xhr) {
	            xhr.setRequestHeader("Accept", "application/json");
	            xhr.setRequestHeader("Content-Type", "application/json");
	        },
			success: function(response) {
				if (response.status == 200) {
					var templateId = $('select#slt-mail-template').val();
					if(templateId == "" || templateId == null) {
						$('#selectMailTemp').text(be043_email_template_required);
					} else {
						window.location.href = response.data + "?templateId=" + templateId;
					}
				} else {
					alertResponseMessage(response);
				}
			},
			error: function(){		
				alert('Error while setting session');
			}
		});
	});
	
	// onchange check box all
	$("#check-all").click(function(event) {
			var check = this.checked;
			// Iterate each checkbox
			$('tbody :checkbox').each(function() {
					this.checked = check;
			});
			event.stopImmediatePropagation();
	});
	
	// init load page
	function getCurrentDate() {
		var now = new Date();
	    var day = ("0" + now.getDate()).slice(-2);
	    var month = ("0" + (now.getMonth() + 1)).slice(-2);
	    var today = now.getFullYear() +"/"+ month +"/"+ day+"";
	    return today;
	}
	
	function getCurrentDate2() {
		var now = new Date();
	    var day = ("0" + now.getDate()).slice(-2);
	    var month = ("0" + (now.getMonth())).slice(-2);
	    var today = now.getFullYear() +"/"+ month +"/"+ day+"";
	    return today;
	}
	
	function insertString(index, sourceString, addString) {
		  if (index > 0)
		    return sourceString.substring(0, index) + addString + sourceString.substring(index, sourceString.length);
		  else
		    return addString + sourceString;
	}; 
	
	function initPage() {
		
		$("#fromLastestGoHospital").datepicker({ 
			dateFormat: 'yy/mm/dd',
			onClose: function( selectedDate ) {
		        // $( "#reservationToDate" ).datepicker( "option", "minDate", selectedDate );
		      }
		});
		
		$("#toLastestGoHospital").datepicker({ 
			dateFormat: 'yy/mm/dd',
			onClose: function( selectedDate ) {
		        // $( "#reservationToDate" ).datepicker( "option", "minDate", selectedDate );
		      }
		});
		
		$("#fromLastestGoHospital").val(getCurrentDate2());
		$("#toLastestGoHospital").val(getCurrentDate());
//		$("#pageSize").val(10);
//		$("#pageIndex").val(1);
	}
});


