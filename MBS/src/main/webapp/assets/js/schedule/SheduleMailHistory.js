$(document).ready(function() {

		initPage();

		$(".timeSlot").each(function() {
			var val = $(this).text();
			$(this).text(insertString(2, val, ":"));
		});

		$(".readingFlg").each(function() {
			var val = $(this).html();
			if (val != null && val == "1") {
				$(this).html('<spring:message code="be025.label.item.confirm" />');
			} else {
				$(this).html('<spring:message code="be025.label.item.not.yet" />');
			}
		});

		function initPage() {
			$("#search-result").empty();
			$("#fromDate").datepicker({ 
				dateFormat: 'yy/mm/dd',
				onClose: function( selectedDate ) {
			        $( "#toDate" ).datepicker( "option", "minDate", selectedDate );
			      }
			});
			
			$("#toDate").datepicker({ 
				dateFormat: 'yy/mm/dd', 
				onClose : function( selectedDate ) {
			        $( "#fromDate" ).datepicker( "option", "maxDate", selectedDate );
			    }
			});
			
			var date = new Date();
			var currentMonth = date.getMonth();
			var currentDate = date.getDate();
			var currentYear = date.getFullYear();
			$("#toDate" ).datepicker( "option", "maxDate", new Date(currentYear, currentMonth, currentDate));
			
			$("#toDate").val(getCurrentDate());
			$("#fromDate").val(getCurrentDate());
		};

		function getCurrentDate() {
			var now = new Date();
			var day = ("0" + now.getDate()).slice(-2);
			var month = ("0" + (now.getMonth() + 1)).slice(-2);
			var today = now.getFullYear() +"/"+ month +"/"+ day + "";
			return today;
		};

		function insertString(index, sourceString, addString) {
			if (index > 0)
				return sourceString.substring(0, index) + addString+ sourceString.substring(index,sourceString.length);
			else
				return addString + sourceString;
		};
		
		$("#searchBtn").click(function() {
			$("#search-result").empty();
			var hospital = $("#hospital").val();
			var department = $("#department").val();
			var fromDate = $("#fromDate").val();
			var toDate = $("#toDate").val();
			
			var data = {"hospital":hospital,"department":department,"fromDate":fromDate,"toDate":toDate};
			
			var source = $("#list-mail-history").html();
			var template = Handlebars.compile(source); 
			
			$('#tblMailListHistory').dataTable().fnDestroy();
			$.ajax({
				type : "post",
				url : "ajax-search-schedule-mail-history",
				data : JSON.stringify(data),
				dataType : "json",
				async : false,
				beforeSend : function(xhr) {
					xhr.setRequestHeader("Accept", "application/json");
					xhr.setRequestHeader("Content-Type","application/json");
				},
				success : function(response) {
					if (response.status == 200 && response.data) {
						$('#search-result').show();
						$('#no-result').hide();	
					$('#search-result').append(template({'model': response.data}));
					}
					if (response.status == 500) {
						$('#search-result').hide();
						$('#no-result').show();	
					}
				},
				error : function() {
					alert('Error while request..');
				}
			});
		});
	});