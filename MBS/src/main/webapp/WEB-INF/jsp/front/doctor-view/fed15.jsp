<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page import="nta.mss.misc.common.MssContextHolder"%>
<%@ page import="nta.mss.misc.common.MssConfiguration"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/security/tags"
	prefix="sec"%>

<!-- BEGIN Waiting List -->
<div class="panel panel-waiting-list">
	<div class="panel-header">
		<h3 class="panel-title">
			<spring:message code="fe15.title.waitinglist" />
		</h3>
		<div class="action">
			<div class="datetime-select-wrap">
				<button class="btn btn-prev" id="prev_date_waiting">
					<i class="fa fa-angle-left"></i>
				</button>
				<div class="datetime-select">
					<input type="text"
						style="height: 25px; background-color: #27ae61; border-style: hidden; text-align: center;"
						id="selected_date_waiting" />
				</div>
				<button class="btn btn-next" id="next_date_waiting">
					<i class="fa fa-angle-right"></i>
				</button>
			</div>
		</div>
	</div>
	<div class="panel-content border">
		<input type=hidden id="my-id-doctor" name="my-id-doctor">
		<table id="tableExaminationAjax" class="table table-hover">
			<thead>
				<tr>
					<th width="60">&nbsp;</th>
					<th><spring:message code="fe15.title.time" /></th>
					<th><spring:message code="fe15.title.department" /></th>
					<th><spring:message code="fe15.title.name" /></th>
					<th><spring:message code="fe15.title.patientcode" /></th>
					<th><spring:message code="fe15.title.namekana" /></th>
					<th class="text-right"><spring:message
							code="fe15.title.receiptedtime" /></th>
					<th width="60">&nbsp;</th>
				</tr>
			</thead>
		</table>
	</div>
</div>
<!-- END Waiting List -->
<style>
.loading {
	display: none; /* Hidden by default */
	position: fixed; /* Stay in place */
	z-index: 1; /* Sit on top */
	padding-top: 100px; /* Location of the box */
	left: 0;
	top: 0;
	width: 100%; /* Full width */
	height: 100%; /* Full height */
	overflow: auto; /* Enable scroll if needed */
	background-color: rgb(0, 0, 0); /* Fallback color */
	background-color: rgba(0, 0, 0, 0.4); /* Black w/ opacity */
}

.loading-content {
	margin-top: 10%;
	margin-left: 50%
}
</style>
<script>
 	var phr_token ='<%=session.getAttribute("phr_token")%>';
  	var connectedPeers = {};
	var doctorCode ='<%=MssContextHolder.getDoctorCode()%>';	
	var patientCode ;
	var reservationId;
	var reservationDate;
	var reservationTime;
	
    //Compatibility shim
    jQuery.fn.dataTableExt.oApi.fnPagingInfo = function ( oSettings )
	{
		return {
			"iStart":         oSettings._iDisplayStart,
			"iEnd":           oSettings.fnDisplayEnd(),
			"iLength":        oSettings._iDisplayLength,
			"iTotal":         oSettings.fnRecordsTotal(),
			"iFilteredTotal": oSettings.fnRecordsDisplay(),
			"iPage":          oSettings._iDisplayLength === -1 ?
				0 : Math.ceil( oSettings._iDisplayStart / oSettings._iDisplayLength ),
			"iTotalPages":    oSettings._iDisplayLength === -1 ?
				0 : Math.ceil( oSettings.fnRecordsDisplay() / oSettings._iDisplayLength )
		};
	};

	var isCalling = false;
	$(document).ready(function()
	{
		$("#selected_date_waiting").datepicker({
			 onSelect: function(dateText) {
				 $('#tableExaminationAjax').dataTable().fnReloadAjax( 'get-waiting-list?examinationDate=' + dateText);
				   // alert("Selected date: " + dateText + "; input's current value: " + this.value);
				  }
		});		
		function updateTable() {
			$('#tableExaminationAjax').dataTable().fnReloadAjax( 'get-waiting-list?examinationDate='+$("#selected_date_waiting").val());
			setTimeout(updateTable, 20000);
		}
		$('#text').keydown(function (e) {
		    if (e.keyCode == '13') {		    	
		    	  document.getElementById("btn-sendMessage").click();
		    }
		});
		// Auto refresh page after 30s
		setTimeout(function(){			
			updateTable();
		}, 30000);
		
		// Set current date
		var phrDeviceToken = '<%=MssContextHolder.getPhrDeviceToken()%>';
		var currentPatientCode = '<%=MssContextHolder.getPatientCode()%>';
		var today = getCurrentDate();
		$("#selected_date_waiting").val(today);
		
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
		    }
		}
		// Patient waiting list
		fillDataToTableExamination(today, language);
		
		$( "#prev_date_waiting" ).click(function() {
			var selected_date=$("#selected_date_waiting").val();	
			var prevDate = getPreDate(selected_date);			
			$("#selected_date_waiting").val(prevDate);
			// Call to load a new ajax
			$('#tableExaminationAjax').dataTable().fnReloadAjax( 'get-waiting-list?examinationDate='+prevDate);
			
		});
		
		$( "#next_date_waiting" ).click(function() {
			var selected_date = $("#selected_date_waiting").val();		
			var nextDate = getNextDate(selected_date);
			$("#selected_date_waiting").val(nextDate);
			// Call to load a new ajax			
			$('#tableExaminationAjax').dataTable().fnReloadAjax( 'get-waiting-list?examinationDate=' + nextDate);
		});
		
		function getNextDate(dateStr) {
			var d = new Date(dateStr.replace(/(\d{2})(\d{2})(\d{4})/, '$1/$2/$3'));
			d.setDate(d.getDate() + 1);
			return $.datepicker.formatDate('mm/dd/yy', d);
		}
		
		function getPreDate(dateStr) {
			var d = new Date(dateStr.replace(/(\d{2})(\d{2})(\d{4})/, '$1/$2/$3'));
			d.setDate(d.getDate() -1);
			return $.datepicker.formatDate('mm/dd/yy', d);
		}
		
		function getCurrentDate() {
			var d = new Date();
			return $.datepicker.formatDate('mm/dd/yy', d);
		}
		
	} );
	
	// PeerJS object
	var peer;
	var recordRTC ;
	
    // TODO
    var call_to_id = "";
    var call;
    /* Chat */
    
    var statusAudio ;
    var statusVideo;
    
    function connect(c) {
    	  // Handle a chat connection.
    	  if (c.label === 'chat') {
    	    var chatbox = $("#chatbox");
    	    var header = $('<h1></h1>').html('Chat with <strong>' + c.peer + '</strong>');
    	    var messages =$("#messages"); 	   
    	    $("#messages").css('height','490px');
    	    chatbox.append(messages);
    	 
    	    // Select connection handler.
    	    chatbox.on('click', function() {
    	      if ($(this).attr('class').indexOf('active') === -1) {
    	        $(this).addClass('active');
    	      } else {
    	        $(this).removeClass('active');
    	      }
    	    });
    	
    	    $('.filler').hide();
    	    $('#connections').append(chatbox);
    	    c.on('data', function(data) {
    	    	messages.append('<div class="chat-row you"><div class="ava"><i class="fa fa-user"></i></div><div class="chat-pop"><span class="peer"></span> ' + data +
    	        '</div></div>');
    	    	messages.animate({
    	        	scrollTop:messages.get(0).scrollHeight},100);
    	        });
    	        c.on('close', function() {    	         
    	          	c.close();   	      
    	         	if ($('.connection').length === 0) {
    	            $('.filler').show();
    	            }    	          
    	          delete connectedPeers[c.peer];
    	          connectedPeers={};
    	        });
    	  } else if (c.label === 'file') {
    	    c.on('data', function(data) {
    	      // If we're getting a file, create a URL for it.
    	      if (data.constructor === ArrayBuffer) {
    	        var dataView = new Uint8Array(data);
    	        var dataBlob = new Blob([dataView]);
    	        var url = window.URL.createObjectURL(dataBlob);
    	        $('#' + c.peer).find('.messages').append('<div><span class="file">' +
    	            c.peer + ' has sent you a <a target="_blank" href="' + url + '">file</a>.</span></div>');
    	      }
    	    });
    	  }
    	  connectedPeers[c.peer] = 1;
    	}
  
    var arr;
    var timevideo;
    var duration;
	$(document).delegate(".btn-opmt","click",function(e)
	{
		peer= new Peer({<%=MssConfiguration.getInstance().getPeerjsUrl()%>});

		$("#endcall-popup").hide(); 		
		//start();.
		
		navigator.getUserMedia({audio: true, video: true}, function(stream){
		   // Set your video displays
		   $('#video').prop('src', URL.createObjectURL(stream));
		   window.localStream = stream;		   
		   }, 
		   function(){ 
			   $('#step1-error').show(); 
		   });
		 peer.on('connection', connect);
		// Receiving a call
		peer.on('call', function(call){
			// Answer the call automatically (instead of prompting user) for demo purposes
			call.answer(window.localStream);
			isCalling = true;
			step3(call);
			$("#btn-Call").hide();
     		$("#btn-endCall").show();
      		
     	
	    	call_to_id = call.peer;
	    	connectedPeers[call.peer] = 1; 
	    	
		});
		
		var id = jQuery(this).attr("id");
		arr = id.split('*');
		patientCode = arr[0];
		call_to_id=arr[1];
		
		reservationDate= arr[2];
		reservationTime= arr[3];
		reservationCode= arr[4];
		reservationId  = arr[5];
		
		 // Get Patient info
	    getPatientInfo('movie-talk/get-patient-by-patient-code', patientCode);
		// getPatientInfo('get-patient-by-patient-code', patientCode);
			 $("#messages").css('height','490px');
		 if($('.movie-talk-overlay').css('display') == 'none'){
             $('.movie-talk-overlay').fadeIn('0.5');
         }		 
		// Get movie-talk-id of doctor	
		 $("#btn-endCall").hide();
	     $("#btn-Call").show();	    
	});  	
	  // Send a chat message to all active connections.	  
  $(document).delegate("#btn-sendMessage","click",function(e)
		{				 
	    e.preventDefault();
	    // For each active connection, send the message.
	    if( window.existingCall)
	    { 
	    	var msg = $('#text').val();
	    	var msg2 ="";
	    	if(msg==null || msg=="")
    		{ 
	    		$('#text').focus();
	    	}
    	else
    		{
    		
	    eachActiveConnection(function(c, $c) {
	      if (c.label === 'chat') {
	    	 
	        c.send(msg);	      
	        $c.find('.messages').append('<div class="chat-row me"><div class="chat-pop"><span class="you"></span>' + msg
	                + '</div></div>');
	        //$c.find('.messages').scrollTop($c.find('.messages').height());
	        $c.find('.messages').animate({
	        	scrollTop:$('.messages').get(0).scrollHeight
	        },100);	        
	      }
	    });
	    $('#text').val('');
	    $('#text').focus();}
	  	}
	  });
	  // Goes through each active peer and calls FN on its connections.
	  function eachActiveConnection(fn) {
	    var actives = $('.active');
	    var checkedIds = {};	    
	    actives.each(function() {	    	
	      //var peerId = $(this).attr('id');
	    
	      if (!checkedIds[call_to_id]) {

	        var conns = peer.connections[call_to_id];
	        if(!(typeof conns === "undefined" || conns === null))
	        {
	        	 for (var i = 0, ii = conns.length; i < ii; i += 1) {	        	
	   	          var conn = conns[i];	        
	   	          fn(conn, $(this));
	   	          
	   	        }
	        }
	       
	      }
	      checkedIds[call_to_id] = 1;
	    });
	  }	 
	$(document).delegate("#btn-Call","click",function(e)
			{
			$.ajax({
				url :"get-mtcalling-id-mt",
				data : "reservationId=" + reservationId ,
				type : "GET",
			
			success : function(data) {
				 call_to_id=data;
				var listId =null;				
			 /*  $.get( listId_URL, function( data,status ) {
		 			  listId=data;
				if(listId.includes(call_to_id,0)) */
				if(!(typeof call_to_id === "undefined" || call_to_id === null))
				{
	    	 		call = peer.call(call_to_id, window.localStream);
		     		step3(call);
		     		peer.on('open',function(){
		 				$('#my-id-doctor').text(peer.id);		
		 			})
		 		
		     		$("#btn-Call").hide();
		     		$("#btn-endCall").show();
		     		isCalling=true;
		     		statusAudio=true;
		     		statusVideo =true;
		     		peer.on('connection', connect);
		     		
		     		//chat  		     
			    	if (!connectedPeers[call_to_id]) {			    	
			      		// Create 2 connections, one labelled chat and another labelled file.			      
			      		var c = peer.connect(call_to_id, {
			        	label: 'chat',
			        	serialization: 'none',
			        	metadata: {message: 'hi i want to chat with you!'}
			      	});
			      	c.on('open', function() {
			      		connect(c);			        
			      	});    
			    	}
			    	connectedPeers[call_to_id] = 1;
			    }
			else
				{
					var url =location.protocol +"//"+location.host+"/mss-web/movie-talk/update-mt-calling-id" ;
					$.ajax({
						url : url,
						data : "reservationCode=" + reservationCode + "&mtCallingId=" + "",
						type : "GET",

						success : function(data) {
						
					},
					error : function(xhr, status, error) {
						//alert(xhr.responseText);
					}
					
				});
				var doctorName = '<%=MssContextHolder.getDoctorName()%>';
			    var requestBody = {"doctor_name" : doctorName , "doctor_code" : doctorCode , "patient_code" : patientCode , "calling_id" : peer.id };
			    console.log(requestBody);
			    sendDataToPhr(requestBody);
				$('#tableExaminationAjax').dataTable().fnReloadAjax( 'get-waiting-list?examinationDate=' +$("#selected_date_waiting").val());
				  
				 }
			 /*   }); */
			},
		error : function(xhr, status, error) {
			//alert(xhr.responseText);
		}
	});
	});
	
	$(document).delegate(".movie-talk-header .action .item-close","click",function(e)
	{
		if($('.movie-talk-overlay').css('display') == 'block'){
            $('.movie-talk-overlay').fadeOut('0.5');
        }
		isCalling=false;		
		// Close a connection.
		 if (window.existingCall) {
			  window.existingCall.close();
			  eachActiveConnection(function(c) {
			      c.close();
			  });	
		 }
		    
		 if (window.localStream) {
			  window.localStream.getTracks().forEach(function(track) {
			  track.stop();
			  });
		 }
		 if($("#pauseVideo").hasClass('disable')){
			  $("#pauseVideo").removeClass('disable');
		}
		if($("#pauseAudio").hasClass('disable')){
			  $("#pauseAudio").removeClass('disable');}
		
		closePopupandUpLoad();
	});
	function getPatientInfo(url, patientCode)
	{
		 $.ajax({
			    type: "GET",
			    url: url,
			    data: 'patientCode=' + patientCode,
			    dataType: "json",
			    success: function (data) {
			    	var gender_text = "";
			    	if(data.gender != null)
			    	{
			    		if(data.gender == 'M')
				    	{
			    			gender_text = '<spring:message code="fe616.field.male"/>';
				    	}
			    		else
			    		{
			    			gender_text = '<spring:message code="fe616.field.female"/>';
			    		}
			    	}
			    	$( "#popup_patient_name" ).text(data.name + " (" + data.nameFurigana + ")");
			    	if((data.name == null && data.nameFurigana == null) || (data.name == '' && data.nameFurigana == ''))
		    		{
		    			$(".movie-talk-header .movie-talk-title").css("color", "#FFFFFF");
		    		}
			    	if((data.age == null && data.gender == null && data.phoneNumber == null) || (data.age == '' && data.gender == '' && data.phoneNumber == ''))
		    		{
		    			$(".movie-talk-header .movie-talk-meta").css("color", "#FFFFFF");
		    		}
			    	//$( "#popup_patient_ext_info" ).text(data.age + " years old - " + data.gender + " - Phone : "  + data.phoneNumber );
			    	$( "#popup_patient_ext_info" ).text(data.age + '<spring:message code="fe616.field.yearsold"/>'+ "-"+ gender_text+" - " +'<spring:message code="fe616.field.phone"/>'+":" + data.phoneNumber );
			    },
		 	error: function(err)
		 	    {
		 		    $(".movie-talk-header .movie-talk-title").css("color", "#FFFFFF");
		 		 	$(".movie-talk-header .movie-talk-meta").css("color", "#FFFFFF");
		 	    }
		 });
	}
	
	function step3 (call)
	{
	      // Hang up on an existing call if present
	      if (window.existingCall) {
	        window.existingCall.close();
	      }	
	      // Wait for stream on the call, then set peer video display	    
	      call.on('stream', function(stream){
	        $('#their-video').prop('src', URL.createObjectURL(stream));	        
	      	recordRTC = RecordRTC(stream, {
	    	  type: 'audio',
	    	  recorderType: StereoAudioRecorder // Force Web Audio API
			});
			recordRTC.startRecording();
			timevideo= new Date().getTime();
			
		});
	      window.existingCall = call;
	     
	}
	$(document).delegate("#btn-endCall","click",function(e)
			{
				isCalling=false;				
		  		$('.endcall-popup').show(); 
				closePopupandUpLoad();
			});	
	var modal;
	$(document).delegate("#btn-save","click",function(e)
			{
				modal= document.getElementById('loading');	
				modal.style.display = "block";
				UploadToServer();
				//Check if exist calling_id then closed connection
				if(!(typeof call_to_id === "undefined" || call_to_id === null || call_to_id === "" ))
				{
					
					eachActiveConnection(function(c) {
			      	c.close();
			    	});
				}
				$("#popup").removeAttr("style").hide();			
			});	
	function closePopupandUpLoad()	{
		if (window.localStream) {
		    window.localStream.getTracks().forEach(function(track) {
		      track.stop();
		    });
		}		  
		isCalling = false;		
		if (window.existingCall) {
			  window.existingCall.close();
	        if(recordRTC!=null)
			{recordRTC.stopRecording(function(audioUrl) {
				duration = secondsToHms((new Date().getTime() - timevideo)/1000); 
				document.getElementById("duration").innerHTML =duration;
			});}
		}
	}
	function secondsToHms(d) {
	    var sec_num = parseInt(d, 10); // don't forget the second param
	    var hours   = Math.floor(sec_num / 3600);
	    var minutes = Math.floor((sec_num - (hours * 3600)) / 60);
	    var seconds = sec_num - (hours * 3600) - (minutes * 60);

	    if (hours   < 10) {hours   = "0"+hours;}
	    if (minutes < 10) {minutes = "0"+minutes;}
	    if (seconds < 10) {seconds = "0"+seconds;}
	    return hours+':'+minutes+':'+seconds;
	}
	
	function UploadToServer()
	{
		var recordedBlob = recordRTC.getBlob();
		var blob;
	    recordRTC.getDataURL(function(audioUrl) {	    	

	    	blob= dataURItoBlob(audioUrl);
	    	var size = bytesToSize(blob.size);	    
	    	if(size>300)
	    	{
	    		alert('<spring:message code="fed16.audio.volume.too.much"/>');
	    		modal= document.getElementById('loading');	
	    		modal.style.display = "none";
	    	}
	    	else
	    	{
	    	var fd = new FormData();
			var url ='${urlUpload}';
			var videoUrl;
			/* var modal = document.getElementById('loading');
			modal.style.display = "block"; */
			fd.append('file', blob,"audio.mp3");			
			$.ajax({
			    type: 'POST',
			    url: url,
			    data: fd,
			    enctype: 'multipart/form-data',
			    processData: false,
			    contentType: false,
			    crossDomain: true,
			    dataType: 'json',
			    success: function(data) {
			    	videoUrl= data.content;			    
			    	var urlInser='movie-talk/uploadvideo';			    	
			     	 $.ajax({
			     		type: 'GET',
					    url: urlInser,
					    data: 'duration='+duration+'&patientCode='+patientCode+'&doctorCode='+doctorCode+'&reservationId='+reservationId+'&reservationCode='+reservationCode+'&reservationTime='+reservationTime+'&reservationDate='+reservationDate+'&videoUrl='+videoUrl,
					    dataType: 'json',
					    success: function(data) { 
					    	 modal= document.getElementById('loading');	
						       modal.style.display = "none";			
						     
					    	},    
					        error: function(error) { 
					           modal= document.getElementById('loading');	
						       modal.style.display = "none";
						       alert('<spring:message code="be013.label.upload.fail"/>')
					        }
					}).done(function(data) {						
					       console.log(data);
						 modal= document.getElementById('loading');
						 modal.style.display = "none";
					});    
			        },    
			        error: function() {
			        	 modal= document.getElementById('loading');	
					       modal.style.display = "none";
			        }
			}).done(function(data) {				
			       console.log(data);
			       modal= document.getElementById('loading');				      
			       modal.style.display = "none";
			});	
			}		    
	    }); 
	}
	function dataURItoBlob(dataURI) {
	    // convert base64 to raw binary data held in a string
	    var byteString = atob(dataURI.split(',')[1]);

	    // separate out the mime component
	    var mimeString = dataURI.split(',')[0].split(':')[1].split(';')[0];

	    // write the bytes of the string to an ArrayBuffer
	    var arrayBuffer = new ArrayBuffer(byteString.length);
	    var _ia = new Uint8Array(arrayBuffer);
	    for (var i = 0; i < byteString.length; i++) {
	        _ia[i] = byteString.charCodeAt(i);
	    }

	    var dataView = new DataView(arrayBuffer);
	    var blob = new Blob([dataView], { type: mimeString });
	    return blob;
	}
	function getParameterByName(name, url) {
	    if (!url) url = window.location.href;
	    name = name.replace(/[\[\]]/g, "\\$&");
	    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
	        results = regex.exec(url);
	    if (!results) return null;
	    if (!results[2]) return '';
	    return decodeURIComponent(results[2].replace(/\+/g, " "));
	}
	
  </script>
<script type="text/javascript"
	src="<c:url value='/assets/js/doctor/DoctorMovieTalkWaitingList.js'/>"></script>
<div class="loading" id="loading">
	<div class="loading-content">
		<img src="http://i.stack.imgur.com/FhHRx.gif">
	</div>
</div>
<!-- BEGIN Modal Video -->
<div class="modal fade modal-video" id="modalVideo" tabindex="-1"
	role="dialog" aria-labelledby="modalVideoLabel">
	<div class="modal-dialog" role="document">
		<div class="modal-content">
			<div class="modal-body">
				<button type="button" class="close" data-dismiss="modal"
					aria-label="Close">
					<span aria-hidden="true"><i class="fa fa-close"></i></span>
				</button>
				<div class="videoWrapper">
					<iframe width="560" height="315"
						src="https://www.youtube.com/embed/smiFk6KHr_8?rel=0&amp;showinfo=0"
						frameborder="0" allowfullscreen></iframe>
				</div>
			</div>
		</div>
	</div>
</div>
<!-- END Modal Video -->
<div class="overlay movie-talk-overlay" id="popup">
	<div class="content-table">
		<div class="content-cell">
			<!-- BEGIN Movie Talk -->
			<div class="panel-movie-talk">
				<!-- BEGIN Movie Talk Area -->
				<div class="movie-talk-area">
					<header class="movie-talk-header">
						<h3 class="movie-talk-title" id="popup_patient_name">Doctor
							Tung</h3>
						<div class="movie-talk-meta" id="popup_patient_ext_info">
							Hospital Tung <span id="my-id-doctor"></span>
						</div>
						<div class="action">
							<span class="item item-expand"><i class="fa fa-expand"></i>
							<spring:message code="fe616.button.fullscreen" /></span> <span
								class="item item-close" id="btn_close_call_popup"><spring:message
									code="fe616.button.close" /></span>
						</div>
					</header>
					<div class="movie-area">
						<div class="video-thumb">
							<%-- <img src="<c:url value='/assets/images/movie-talk/video-doctor.png'/>" alt=""> --%>
							<video id="video" class="input gradient input-block" muted="true"
								autoplay style="display: flex;"></video>
						</div>
						<%-- <img src="<c:url value='/assets/images/movie-talk/video-patient.png'/>" alt=""> --%>
						<video id="their-video" autoplay=""
							style="width: 100%; height: 100%;"></video>
						<div class="bleft">

							<button class="icon-action icon-video" id="pauseVideo">
								<i class="fa fa-video-camera"></i>
							</button>

							<button class="icon-action icon-mic" id="pauseAudio">
								<i class="fa fa-microphone"></i>
							</button>

						</div>

						<div class="bright">
							<button class="icon-action icon-call" id="btn-Call">
								<i class="fa fa-phone"></i>
							</button>
							<button class="icon-action icon-endcall" id="btn-endCall">
								<i class="fa fa-phone"></i>
							</button>
						</div>
						<div class="popup endcall-popup" id="endcall-popup">
							<div class="content-table">
								<div class="content-cell">
									<div class="endcall-notice text-center">
										<h3 class="title">
											<spring:message code="fe15.title.callended" />
										</h3>
										<div class="video-duration">
											<span id="duration"></span>
										</div>
										<hr class="line">
										<p>
											<spring:message code="fe15.message.savevideo" />
										</p>
										<p>
											<button type="button" id="btn-save" class="btn btn-save">
												<i class="fa fa-save"></i>
												<spring:message code="fe15.button.savevideo" />
											</button>
										</p>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<!-- END Movie Talk Area -->
				<!-- BEGIN Movie Talk Chatbox -->
				<div class="movie-talk-chatbox">
					<header class="chatbox-header">
						<spring:message code="fe616.title.chatbox" />
					</header>
					<div class="chat-view" id="wrap" style="position: relative;">
						<div id="connections">
							<div class="clear"></div>
							<div class="connection active" id="chatbox">
								<div
									style="overflow: scroll; overflow-x: hidden; height: 490px;"
									id="messages" class="messages"></div>
							</div>
						</div>
						<div class="chat-input"
							style="position: absolute; bottom: 0; width: 100%">
							<input type="text" id="text" value="" class="input input-block"
								placeholder=<spring:message code="fe616.placeholder.textchat"/>>
							<button class="btn btn-send" id="btn-sendMessage">
								<spring:message code="fe15.button.send" />
							</button>

						</div>
					</div>
					<!-- END Movie Talk Chatbox -->
				</div>
				<!-- END Movie Talk -->
			</div>
		</div>
	</div>
</div>

<!-- <div id="step1-error" style="display:none;">
    <p>Failed to access the webcam and microphone. Make sure to run this demo on an http server and click allow when asked for permission by the browser.</p>
    <a href="#" class="pure-button pure-button-error" id="step1-retry">Try again</a>
  </div> -->

<script>

  var tracks;
  $('.movie-talk-area .movie-area .icon-action.icon-video').click(function(){
	  if(isCalling==true)
	  {
		 
      if($(this).hasClass('disable')){
    	  
          $(this).removeClass('disable');   
          if(window.localStream)
    	  {
    			window.localStream.getTracks()[1].enabled= true;
    			
	  	  }
     }else
     {    	  
    	  if($(this).hasClass('disable')==false)
          {
          $(this).addClass('disable');
          if(window.localStream)
        	  {
        			window.localStream.getTracks()[1].enabled= false;
        			
		  	  }
		  }
    	}
      }
     
});
  $('.movie-talk-area .movie-area .icon-action.icon-mic').click(function()
  { 
	  if(isCalling==true)
  {
	  if($(this).hasClass('disable')){
		  $(this).removeClass('disable');	
		  if(window.localStream)
    	  {
    			window.localStream.getTracks()[0].enabled= true;    			
	  	  }
		  }else{ 
		  if($(this).hasClass('disable')==false)
		  {$(this).addClass('disable');	
		  if(window.localStream)
    	  {
    		window.localStream.getTracks()[0].enabled= false;
    			
	  	  }		
		  };
	  }}
  })
  </script>
<div class="modal fade" id="video-setting" tabindex="-1" role="dialog"
	aria-labelledby="videosettinglabel" aria-hidden="true"
	style="display: none;" data-backdrop="static">
	<div class="modal-dialog" role="document">
		<div class="modal-content">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal"
					aria-label="Close" onclick="saveSetting() ">
					<span aria-hidden="true"><spring:message
							code="fe616.button.close" /></span>
				</button>
				<h4 class="modal-title" id="videosettinglabel">
					<i class="fa fa-cog"></i>
					<spring:message code="fe616.button.videoSetting" />
				</h4>
			</div>
			<div class="modal-body">
				<!-- BEGIN Block -->
				<div class="block">
					<div class="block-header">
						<h3 class="block-title">
							<i class="fa fa-microphone"></i>
							<spring:message code="fe616.button.microphone" />
						</h3>
						<span class="toggle opened">&nbsp;</span>
					</div>
					<div class="block-content">
						<!-- BEGIN Row -->
						<div class="cgroup">
							<label for="audioSource" class="label"><spring:message
									code="fe616.button.microphone" /> </label> <select
								class="input gradient input-block" id="audioSource">

							</select>
						</div>
						<!-- END Row -->
						<!-- BEGIN Row -->
						<div class="cgroup">
							<label class="label"><spring:message
									code="fe616.button.volume" /></label>
						</div>
						<!-- END Row -->
					</div>
				</div>
				<!-- END Block -->
				<!-- BEGIN Block -->
				<div class="block">
					<div class="block-header">
						<h3 class="block-title">
							<i class="fa fa-headphones"></i>
							<spring:message code="fe616.button.speakers" />
						</h3>
						<span class="toggle opened">&nbsp;</span>
					</div>
					<div class="block-content">
						<!-- BEGIN Row -->
						<div class="cgroup">
							<label for="audioOutput" class="label"><spring:message
									code="fe616.button.speakers" /></label> <select
								class="input gradient input-block" id="audioOutput">

							</select>
						</div>
						<!-- END Row -->
					</div>
				</div>
				<!-- END Block -->
				<!-- BEGIN Block -->
				<div class="block">
					<div class="block-header">
						<h3 class="block-title">
							<i class="fa fa-video-camera"></i>
							<spring:message code="fe616.button.intergratedWebcam" />
						</h3>
						<span class="toggle opened">&nbsp;</span>
					</div>
					<div class="block-content">
						<!-- BEGIN Row -->
						<div class="cgroup">
							<label for="videoSource" class="label"><spring:message
									code="fe616.button.webcam" /></label> <select
								class="input gradient input-block" id=videoSource>

							</select>
							<video class="input gradient input-block" id="testvideo"
								autoplay=""></video>
						</div>
						<!-- END Row -->
					</div>
				</div>
				<!-- END Block -->

			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-orange" data-dismiss="modal"
					onclick="saveSetting();">
					<spring:message code="fe616.button.savechanges" />
				</button>
			</div>
		</div>
	</div>
</div>


<script>
  $("#videosetting").click(function(){
		start();
		//alert(localStorage.getItem("audioSource"));
		//document.getElementById("audioSource").selectedIndex = sessionStorage.getItem("audioSource");
		//document.getElementById("audioOutput").selectedIndex = sessionStorage.getItem("audioOutput");
		//document.getElementById("videoSource").selectedIndex = sessionStorage.getItem("videoSource");
	});
	//Panel Toggle
	$('.panel .panel-header .action .toggle').click(
			function(event) {
				event.preventDefault();
				if ($(this).hasClass('opened')
						&& ($(this).parents('.panel').find(
								'.panel-content')
								.css('display') == 'block')) {
					$(this).removeClass('opened');
					$(this).parents('.panel').find(
							'.panel-content').hide();
				} else {
					$(this).addClass('opened');
					$(this).parents('.panel').find(
							'.panel-content').show();
				}
			});

	//Block Toggle
	$('.block .block-header .toggle').click(
			function(event) {
				event.preventDefault();
				if ($(this).hasClass('opened')
						&& ($(this).parents('.block').find(
								'.block-content')
								.css('display') == 'block')) {
					$(this).removeClass('opened');
					$(this).parents('.block').find(
							'.block-content').hide();
				} else {
					$(this).addClass('opened');
					$(this).parents('.block').find(
							'.block-content').show();
				}
			});

	//Advanced Search Toggle
	$('.advanced-toggle').click(
			function(event) {
				event.preventDefault();
				if ($(this).hasClass('opened')
						&& $(this).next('.advanced-search')
								.hasClass('opened')) {
					$(this).removeClass('opened');
					$(this).next('.advanced-search')
							.removeClass('opened');
				} else {
					$(this).addClass('opened');
					$(this).next('.advanced-search').addClass(
							'opened');
				}
			});
	function saveSetting()
	{	
	sessionStorage.clear();

	sessionStorage.setItem("audioSource",$("#audioSource").prop('selectedIndex'));

	sessionStorage.setItem("audioOutput",$("#audioOutput").prop('selectedIndex'))
	sessionStorage.setItem("videoSource",$("#videoSource").prop('selectedIndex'))
		  if (window.stream) {
			    window.stream.getTracks().forEach(function(track) {
			      track.stop();
			    });
			  }
	}
	 function movie_talk_fullpage(){
         //Full Page
         var window_height = $(window).height();
         $('.panel-movie-talk.fullpage').css('height',window_height);
         $('.panel-movie-talk.fullpage .movie-talk-area').css('height',window_height);

         //Set height Chat view

         var chatbox_input_height = $('.panel-movie-talk.fullpage .movie-talk-chatbox .chat-input').outerHeight();
         var message_height = $("#messages").height();
         
         var chat_view_height = window_height -  40;


         $('.panel-movie-talk.fullpage .movie-talk-chatbox .chat-view').css('height', chat_view_height);

         //Set height movie Area
         var movie_talk_header_height = $('.panel-movie-talk.fullpage .movie-talk-area .movie-talk-header').height();

         var movie_area_height = window_height - movie_talk_header_height - 40;
         $("#messages").css('height',window_height -  40 - chatbox_input_height);
         $('.panel-movie-talk.fullpage .movie-talk-area .movie-area').css('height', movie_area_height);
     }

     function reset_movie_talk_fullpage(){
         //Full Page
         
         $('.panel-movie-talk.fullpage').css('height','');
         $('.panel-movie-talk.fullpage .movie-talk-area').css('height','');
         $("#messages").css('height','490px');
         $('.panel-movie-talk.fullpage .movie-talk-chatbox .chat-view').css('height', '');

         //Set height movie Area

         $('.panel-movie-talk.fullpage .movie-talk-area .movie-area').css('height','');
     }

     movie_talk_fullpage();

     $(window).resize(function() {
         movie_talk_fullpage();
     });

     //Fullscreen

     $('.movie-talk-header .action .item-expand').click(function(){
         if($(this).parents('.panel-movie-talk').hasClass('fullpage')){reset_movie_talk_fullpage();
             $(this).parents('.panel-movie-talk').removeClass('fullpage');
             $(this).html('<i class="fa fa-expand"></i> <spring:message code="fe616.button.fullscreen"/>');
         }else{
             $(this).parents('.panel-movie-talk').addClass('fullpage');
             movie_talk_fullpage();

             $(this).html('<i class="fa fa-compress"></i>  <spring:message code="fe616.button.Ese.FullScreen"/>');
         }
     });
    <%--  var doctorName = <%=MssContextHolder.getDoctorName()%>;
	 var requestBody = {"doctor_name" : doctorName , "doctor_code" : doctorCode , "patient_code" : patientCode , "calling_id" : "" , "patient_name" : patientName};
	 sendDataToPhr(requestBody); --%>
     function sendDataToPhr(requestBody)
     {
    	 $.ajax({
    		type : 'post',
    		url : 'send-noti-to-phr',
    		data: JSON.stringify(requestBody),
    		dataType : 'json',
    		beforeSend : function(xhr)
    		{
    			xhr.setRequestHeader("Accept", "application/json");
				xhr.setRequestHeader("Content-Type","application/json");
    		},
    		success:function(response){
    			if(response.status == 200)
    				{
    				console.log("Send noti succcess");
    				}
    			else 
    				{
    				console.log("Send noti failed");
    				}
    		},
    		error:function()
    		{
    			console.log("ERROR SEND NOTI");
    		}
    	 });
     }
     
  </script>


<script  src="//www.google-analytics.com/analytics.js"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/doctor/adapter.js'/>"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/doctor/common.js'/>"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/doctor/main.js'/>"></script>
<script type="text/javascript"
	src="<c:url value='/assets/js/doctor/ga.js'/>"></script>