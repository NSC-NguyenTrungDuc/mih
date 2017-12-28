<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/security/tags" prefix="sec"%>
<%@ page import="nta.mss.misc.common.MssConfiguration"%>
<script async=""  src="//www.google-analytics.com/analytics.js"></script>

 <script type="text/javascript">
 	var isActive = true;
 	function onBlur() {
     isActive = false; 
 	};
 	
 	function onFocus(){
     isActive = true; 	
 	};

 	if (/*@cc_on!@*/false) { // check for Internet Explorer
     document.onfocusin = onFocus;
     document.onfocusout = onBlur;
 	} else {
     window.onfocus = onFocus;
     window.onblur = onBlur;
 	}
 	
	//PeerJS object
	var peer ;
	var theirid=1;
	var isCalling =false;
	var connectedPeers = {};	
	$(document).ready(function() {
		//var userAgentString = navigator.userAgent;
	   // alert(userAgentString);
		function checkcookie()
		{
			var name = "Videosetting=";
		    var ca = document.cookie.split(';');
		    for(var i=0; i<ca.length; i++) {
		        var c = ca[i];
		        while (c.charAt(0)==' ') {
		            c = c.substring(1);
		        }
		        if (c.indexOf(name) == 0) {
		            return c.substring(name.length, c.length);
		        }
		    }
		}
		
		if(checkcookie()!="true")
		{
			start();
			document.getElementById("videosetting").click();
			}	
		navigator.getUserMedia = navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia;
		
		var today = getCurrentDate();
		$('#selected_date_waiting').html(today);
		
		// Patient waiting list
		var messagesKey = {
		    "patientCode": '<spring:message code="be006.label.form.patientCode"/>'
		}
		fillDataToTablePatientExamination(today, messagesKey);		
		/**
			[END]-GET DATA FROM KCCK API
		*/
		
		// Prev Date
		$( "#prev_date_waiting" ).click(function() {
			var selected_date = $('#selected_date_waiting').html();
			var prevDate = getPreDate(selected_date);;
			$('#selected_date_waiting').html(prevDate);
			
			// Call to load a new ajax
			fillDataToTablePatientExamination(prevDate, messagesKey);
		});
		//Enter text
		$('#text').keydown(function (e) {
		    if (e.keyCode == '13') {		    	
		    	  document.getElementById("btn-sendMessage").click();
		    }
		});
		// Next Date
		$( "#next_date_waiting" ).click(function() {
			var selected_date = $('#selected_date_waiting').html();
			var nextDate = getNextDate(selected_date);;
			$('#selected_date_waiting').html(nextDate);
			
			// Call to load a new ajax
			fillDataToTablePatientExamination(nextDate, messagesKey);
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

		// Open movie call
		$('.movie-talk-header .action .item-close').click(function() 
		{		
			if ($('.movie-talk-overlay').css('display') == 'block') 
			{
				$('.movie-talk-overlay').fadeOut('0.5');
			}
			var reservationCode = $('#hd_reservation_code').val();
			//reservationCode = "4426";
			// Update mt-calling-id
			updateMtCallingId(reservationCode, "");
			if(window.localStream)
			  {window.localStream.getTracks().forEach(function(track) {							    	
			      track.stop();
			    });
			}
			isCalling = false;
			
			
			// TODO FIX VALUE
			//var reservationCode = jQuery(this).attr("id");
		
			
			if($("#pauseVideo").hasClass('disable')){
				  $("#pauseVideo").removeClass('disable');}
			  if($("#pauseAudio").hasClass('disable')){
				  $("#pauseAudio").removeClass('disable');}
			  if (window.existingCall) {
			  window.existingCall.close();
			  }
		});
		
		$('.noti-waiting').click(function() {
			if ($('#patient_movietalk').css('top') !== '0') {
				$('#patient_movietalk').css({'top' : '0','width' : '100%'
				});
				
				$('#patient_movietalk .panel-movie-talk').css('visibility','visible');
				$(this).addClass('selected');
			} else {
				$(this).removeClass('selected');
			}
		});
		
		$('#patient_movietalk .movie-talk-header .action .item.item-minimize').click(function() {
			$('#patient_movietalk').css({'top' : '100%','width' : '0'
			});
			$('#patient_movietalk .panel-movie-talk').css('visibility', 'hidden');
			$('.noti-waiting').removeClass('selected');
		});		
		
		
	});
	$(document).delegate("#btn-endcall","click",function(e)
	 {
		$("#patient_movietalk").removeAttr("style").hide();
		isCalling =false;
		var reservationCode = $('#hd_reservation_code').val();
		updateMtCallingId(reservationCode, "");
		if(window.localStream)
		{ if (window.existingCall) {
			  window.existingCall.close();
		  }				
		    window.localStream.getTracks().forEach(function(track) {							    	
		      track.stop();
		    });
		}
		
		if($("#pauseVideo").hasClass('disable'))
		{
			  $("#pauseVideo").removeClass('disable');
		}
		if($("#pauseAudio").hasClass('disable'))
		{			  
			  $("#pauseAudio").removeClass('disable');
		}		
	});	
	
	//full green	
	$(document).delegate("#fullScreen","click",function(e)
	{
		$(".movie-talk-area").addClass("fullscreen");
						
	});
	$(document).delegate(".ready_openmovie","click",function(e)
			{
		
		if($("#pauseVideo").hasClass('disable')){
			  $("#pauseVideo").removeClass('disable');}
		  if($("#pauseAudio").hasClass('disable')){
			  $("#pauseAudio").removeClass('disable');}
		
				// TODO FIX VALUE
				var id = jQuery(this).attr("id");
				var arr = id.split('*');
				var reservationCode = arr[0];
				var patientCode = arr[1];
				
				//var reservationCode = jQuery(this).attr("id");
				//alert(reservationCode);
				$('#hd_reservation_code').val(reservationCode);
				//reservationCode = "4426";
				
				//alert(reservationCode);
				//var peer = new Peer({ host: 'uat.karte.clinic', port: 443, path:'/peerjs', secure: true});
				//peer= new Peer({host:'10.1.20.162',port:9000,path:'/myapp'});
				peer= new Peer({<%=MssConfiguration.getInstance().getPeerjsUrl()%>});
				peer.on('open', function(){
					
					$('#my-id').text(peer.id);
					// Update mt-calling-id
					updateMtCallingId(reservationCode, peer.id);
				});
				
				/**
				* GET PATIENT INFO TO DISPLAY POPUP
				*/
				var contextPath='<%=request.getContextPath()%>';
			    getPatientInfo(contextPath + '/doctor/movie-talk/get-patient-by-patient-code', patientCode);
			    
				//start();
				
				 navigator.getUserMedia({audio: true, video: true}, function(stream){
				        // Set your video displays
				        $('#video').prop('src', URL.createObjectURL(stream));

				        window.localStream = stream;
				        //step2();
				      }, function(){ $('#step1-error').show(); });
		

				// Receiving a call
				peer.on('call', function(call){
					// Answer the call automatically (instead of prompting user) for demo purposes
					call.answer(window.localStream);
					isCalling =true;
					step3(call);	
					
				});
				peer.on('connection', connect);
				  // Close a connection.
				  $('#close').click(function() {
				    eachActiveConnection(function(c) {
				      c.close();
				    });	 
				});		
		
				if ($('.movie-talk-overlay').css('display') == 'none')
				{
					$('.movie-talk-overlay').fadeIn('0.5');
				}
			});

	//chat
function connect(c) {
	//active tab
if(!isActive)
{
	setTimeout(function(){
		alert('<spring:message code="fe616.message.have.a.call"/>');	
	},0);						
} 
  // Handle a chat connection.
  if (c.label === 'chat') {    	
	  var chatbox = $("#chatbox");
	    var header = $('<h1></h1>').html('Chat with <strong>' + c.peer + '</strong>');
	    var messages =$("#messages"); 	   
    //chatbox.append(header);
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
	      messages.append('<div class="chat-row you"><div class="ava"><i class="fa fa-user"></i></div><div class="chat-pop"><span class="peer"></span>' + data +
	        '</div></div>');
	      messages.animate({
	        	scrollTop:messages.get(0).scrollHeight},100);
	        });
	  	
	        c.on('close', function() {
	          //alert(c.peer + ' has left the chat.');
	          //chatbox.remove();
	          if ($('.connection').length === 0) {
	            $('.filler').show();
	          }
	          delete connectedPeers[c.peer];
	        });
	  } else if (c.label === 'file') {
	    c.on('data', function(data) {
	      // If we're getting a file, create a URL for it.
	      if (data.constructor === ArrayBuffer) {
	        var dataView = new Uint8Array(data);
	        var dataBlob = new Blob([dataView]);
	        var url = window.URL.createObjectURL(dataBlob);
	        $("#chatbox").find('.messages').append('<div class="chat-row you"><div class="ava"><i class="fa fa-user"></i></div><div class="chat-pop"><span class="peer">has sent you a <a target="_blank" href="' + url + '">file</a>.</span></div></div>')  }
	    });
	  }
	  connectedPeers[c.peer] = 1;
}
	
// Send a chat message to all active connections.
$(document).delegate("#btn-sendMessage","click",function(e)
{		 
  if(window.existingCall)
  // For each active connection, send the message.
  { var msg = $('#text').val();
  eachActiveConnection(function(c, $c) {
    if (c.label === 'chat') {
      c.send(msg);
      $("#chatbox").find('.messages').append('<div class="chat-row me"><div class="chat-pop"><span class="you"></span>' + msg
        + '</div></div>');
      //$("#chatbox").scrollTop= $("#chatbox").scrollHeight;
      $("#chatbox").find('.messages').animate({
      	scrollTop:$("#chatbox").find('.messages').get(0).scrollHeight},100);
    } 
  });
  $('#text').val('');
  $('#text').focus();}
});
	// Goes through each active peer and calls FN on its connections.
	  function eachActiveConnection(fn) {
	    var actives = $('.active');
	    var checkedIds = {};	  
	    actives.each(function() {	    
	      //var peerId = $("#chatbox");
	     
	      if (!checkedIds[theirid]) {
	        var conns = peer.connections[theirid];
	       
	        for (var i = 0, ii = conns.length; i < ii; i += 1) {
	          var conn = conns[i];
	          fn(conn, $(this));
	        }
	      }
	      checkedIds[theirid] = 1;
	    });
	  }	  
	

	function step3 (call) {
		// Hang up on an existing call if present
		if (window.existingCall) {
		 window.existingCall.close();
		}
	
		// Wait for stream on the call, then set peer video display
		call.on('stream', function(stream){
		 $('#their-video').prop('src', URL.createObjectURL(stream));
			//alert('<spring:message code="fe616.message.have.a.call"/>');
		});
	
		// UI stuff
		window.existingCall = call;
		theirid = call.peer;
		/*if(theirid==1)
		{
			theirid = call.peer;
		}
		else
		{
			if(theirid!=call.peer)
			{						
			
				$("div").remove('.chat-row you');
				$("div").remove('.chat-row me');
			}	
			else
			{
				theirid = call.peer;
			}
		} */
		  
	}
var statusVideo;
var statusAudio;

var tracks;
$(document).delegate("#pauseVideo","click",function(e)
	{
	if(isCalling==true)
	 { 
    	if($(this).hasClass('disable'))
    	{    	 
        $(this).removeClass('disable'); 
        if(window.localStream)
  	  {
  			window.localStream.getTracks()[1].enabled= true;
  			
	  	  }
    }else{    	  
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
$(document).delegate("#pauseAudio","click",function(e)
		  { 
		 if(isCalling==true)
		  {		
			  if($(this).hasClass('disable')){				 
				  $(this).removeClass('disable');	
				  if(window.localStream)
		    	  {
		    			window.localStream.getTracks()[0].enabled= true;
		    			
			  	  }
			  }else
			  { 
				 
				 $(this).addClass('disable');		
				 if(window.localStream)
		    	  {
		    			window.localStream.getTracks()[0].enabled= false;
		    			
			  	  }			
			  	}
			  }
		  })
  //Get doctor Info
  function getPatientInfo(url, patientCode)
	{
		 $.ajax({
			    type: "GET",
			    url: url,
			    data: 'patientCode=' + patientCode,
			    dataType: "json",
			    success: function (data) {
			    	if((data.name == null && data.nameFurigana == null) || (data.name == '' && data.nameFurigana == ''))
			    		{
			    			$(".movie-talk-header .movie-talk-title").css("color", "#FFFFFF");
			    		}
			    	$( "#popup_doctor_name" ).text(data.name + " (" + data.nameFurigana + ")");
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
			    	if((data.age == null && data.gender == null && data.phoneNumber == null) || (data.age == '' && data.gender == '' && data.phoneNumber == ''))
			    		{
			    			$(".movie-talk-header .movie-talk-meta").css("color", "#FFFFFF");
			    		}			    		
			    	$( "#popup_doctor_ext_info" ).text(data.age + '<spring:message code="fe616.field.yearsold"/>'+ "-"+ gender_text+" - " +'<spring:message code="fe616.field.phone"/>'+":" + data.phoneNumber );
			    },
		 	   error: function(err)
		 	    {
		 		    $(".movie-talk-header .movie-talk-title").css("color", "#FFFFFF");
		 		 	$(".movie-talk-header .movie-talk-meta").css("color", "#FFFFFF");
		 	    }
		 });
	}
//Alert

$(document).delegate("#alert-calling","click",function(event){
	  event.preventDefault();
	  if($("#border-alert").hasClass('fa-angle-double-right')){
          $("#alert-text").hide();
          $("#border-alert").removeClass('fa-angle-double-right').addClass('fa-angle-double-left')
      }
	  else{
          $("#alert-text").fadeIn(200);
          $("#border-alert").removeClass('fa-angle-double-left').addClass('fa-angle-double-right')
      }
    
});
setTimeout(function() {
	 $("#alert-text").hide();
     $("#border-alert").removeClass('fa-angle-double-right').addClass('fa-angle-double-left')
}, 5000);
  </script>
<script type="text/javascript" src="<c:url value='/assets/js/doctor/PatientMovieTalkWaitingList.js'/>" ></script>  
	<div class="calendar-header clearfix">
		<h3 class="title pull-left">
			<spring:message code="fe616.title.calendar"/> <strong class="date" id="selected_date_waiting"></strong>					  				
		</h3>
		<div class="action pull-right">
			<span class="btn" id="prev_date_waiting"><i class="fa fa-angle-left"></i><spring:message code="fe616.button.prevDate"/></span>
			<span class="btn" id="next_date_waiting"><spring:message code="fe616.button.nextDate"/> <i class="fa fa-angle-right"></i></span>
		</div>
	</div>
	
	<div class="event-group">		
			<h3 class="title"><span><spring:message code="fe616.title.movietalkUpcoming"/></span>			   		
			</h3>
		<div class="alert alert-success inline-block pull-right " role="alert" id="alert-calling" style="margin-top: -55px;padding: 10px;">
				<i class=" fa fa-angle-double-right alert-toggle" id="border-alert" ></i>
					<span style="font-size: 14px" id="alert-text"><spring:message code="fe616.message.guild.calling"/></span>				
				</div>    
		<div class="row" id="list_examination_upcoming">
		</div>		
	</div>
	<div class="event-group">
		<h3 class="title"><span><spring:message code="fe616.title.movietalkCompleted"/></span></h3>
		<div class="row" id="list_examination_completed">
		</div>
	</div>
	<div class="event-group">
		<h3 class="title"><span><spring:message code="fe616.title.movietalkExpired"/></span></h3>
		<div class="row" id="list_examination_expired">
		</div>
	</div>




<!-- Popup -->
<div id="patient_movietalk" class="overlay movie-talk-overlay">
	<div class="content-table">
		<div class="content-cell">
			<!-- BEGIN Movie Talk -->
			<div class="panel-movie-talk">
				<!-- BEGIN Movie Talk Area -->
				<div class="movie-talk-area">
					<div class="movie-talk-header">
						<h3 class="movie-talk-title" id="popup_doctor_name">Doctor Tung</h3>
						<input type="hidden" id="my-id" value="">
						<div class="movie-talk-meta" id="popup_doctor_ext_info">Bach Mai Hospital</div>

						<div class="action">
							<input type="hidden" id="hd_reservation_code" value=""/>	
							<span class="item item-expand" id="fullScreen"><i class="fa fa-expand"></i><spring:message code="fe616.button.fullscreen"/></span>						
							<span class="item item-close"><i class="fa fa-close"></i><spring:message code="fe616.button.close"/></span>
						</div>
					</div>
					<div class="movie-area">
						<div class="video-thumb">
							<video class="input gradient input-block" id="video" autoplay muted="true"></video>
						</div>
					
						<video id="their-video" autoplay="" style="width:100%;height:100%;"></video>
						
						<div class="bleft">
							<button class="icon-action icon-video" id="pauseVideo">
								<i class="fa fa-video-camera"></i>
							</button>
							<button class="icon-action icon-mic" id="pauseAudio">
								<i class="fa fa-microphone"></i>
							</button>
						</div>
						<div class="bright">
							<button class="icon-action icon-endcall" id="btn-endcall">
								<i class="fa fa-phone"></i>
							</button>
						</div>
					</div>
				</div>
				<!-- END Movie Talk Area -->
				<!-- BEGIN Movie Talk Chatbox -->
				 <div class="movie-talk-chatbox">
                            <header class="chatbox-header">
                               <spring:message code="fe616.title.chatbox"/>
                            </header>
                            <div class="chat-view" id="wrap" style="position: relative;">
                           
                            <div id="connections">
                            
    						<div class="clear"></div>
    						<div class="connection active" id="chatbox" >
                               <div style="overflow: scroll; overflow-x:hidden;height: 490px;" id="messages" class="messages">
                               	<div class="alert alert-success" role="alert"> <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><spring:message code="fe616.message.guild.chatbox"/></div>
                               </div>  
                                
                               </div> 
                            </div>                            
                            <div class="chat-input" style="position:absolute;bottom:0;width:100%" >
                             <input type="text" id="text" value="" class="input input-block" placeholder=<spring:message code="fe616.placeholder.textchat"/>>                              
     						 <button class="btn btn-send" id="btn-sendMessage"><spring:message code="fe616.button.send"/></button>
    						
                            </div>
                        </div><!-- END Movie Talk Chatbox -->
                    </div><!-- END Movie Talk -->
				<!-- END Movie Talk Chatbox -->
			</div>
			<!-- END Movie Talk -->
		</div>
	</div>
</div>

	<div class="modal fade" id="patient-setting" tabindex="-1" role="dialog"aria-labelledby="videosettinglabel" aria-hidden="true"
		style="display:none;"data-backdrop="static" >
		<div class="modal-dialog" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<button type="button" class="close" data-dismiss="modal"
						aria-label="Close" onclick="closePopup();">
						<span aria-hidden="true"><spring:message code="fe616.button.close"/></span>
					</button>
					<h4 class="modal-title" id="videosettinglabel">
						<i class="fa fa-cog"></i> <spring:message code="fe616.button.videoSetting"/>
					</h4>
				</div>
				<div class="modal-body">
					<!-- BEGIN Block -->
					<div class="block">
						<div class="block-header">
							<h3 class="block-title">
								<i class="fa fa-microphone"></i> <spring:message code="fe616.button.microphone"/>
							</h3>
							<span class="toggle opened">&nbsp;</span>
						</div>
						<div class="block-content">
							<!-- BEGIN Row -->
							<div class="cgroup">
								<label for="audioSource" class="label"><spring:message code="fe616.button.microphone"/></label> <select
									class="input gradient input-block" id="audioSource">

								</select>
							</div>
							<!-- END Row -->
							<!-- BEGIN Row -->
							<div class="cgroup">
								<label class="label"><spring:message code="fe616.button.volume"/></label></label>
							</div>
							<!-- END Row -->
						</div>
					</div>
					<!-- END Block -->
					<!-- BEGIN Block -->
					<div class="block">
						<div class="block-header">
							<h3 class="block-title">
								<i class="fa fa-headphones"></i> <spring:message code="fe616.button.speakers"/>
							</h3>
							<span class="toggle opened">&nbsp;</span>
						</div>
						<div class="block-content">
							<!-- BEGIN Row -->
							<div class="cgroup">
								<label for="audioOutput" class="label"><spring:message code="fe616.button.speakers"/></label> <select
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
								<i class="fa fa-video-camera"></i>  <spring:message code="fe616.button.intergratedWebcam"/>
							</h3>
							<span class="toggle opened">&nbsp;</span>
						</div>
						<div class="block-content">
							<!-- BEGIN Row -->
							<div class="cgroup">
								<label for="videoSource" class="label"><spring:message code="fe616.button.webcam"/></label> <select
									class="input gradient input-block" id=videoSource>

								</select>
									<video class="input gradient input-block" id="testvideo" autoplay=""></video>
							</div>
							<!-- END Row -->
						</div>
					</div>
					<!-- END Block -->
				</div>
				<div class="modal-footer">
					<button type="button" class="btn btn-orange" data-dismiss="modal" onclick="saveSetting();"><spring:message code="fe616.button.savechanges"/></button>
				</div>
			</div>
		</div>
	</div>
	<script>
	 $("#videosetting").click(function(){
				start();
				//alert(localStorage.getItem("audioSource"));
				if(sessionStorage.getItem("audioSource")!=null)
				{
					document.getElementById("audioSource").selectedIndex = sessionStorage.getItem("audioSource");
				document.getElementById("audioOutput").selectedIndex = sessionStorage.getItem("audioOutput");
				document.getElementById("videoSource").selectedIndex = sessionStorage.getItem("videoSource");
				}
			});
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
				var now = new Date()
				 var time = now.getTime();
				 var expireTime = time + 100000*36000;
				 now.setTime(expireTime);
				sessionStorage.clear();
				document.cookie="Videosetting=true;expires="+now.toGMTString();
			sessionStorage.setItem("audioSource",$("#audioSource").prop('selectedIndex'));

			sessionStorage.setItem("audioOutput",$("#audioOutput").prop('selectedIndex'))
			sessionStorage.setItem("videoSource",$("#videoSource").prop('selectedIndex'))
				  if (window.stream) {
					    window.stream.getTracks().forEach(function(track) {
					      track.stop();
					    });
					  }
			}
			function closePopup()


			{
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
		         //var chat_view_height = window_height - (60 + chatbox_input_height);

		         $('.panel-movie-talk.fullpage .movie-talk-chatbox .chat-view').css('height', chat_view_height);

		         //Set height movie Area
		         var movie_talk_header_height = $('.panel-movie-talk.fullpage .movie-talk-area .movie-talk-header').height();
		         $("#messages").css('height',window_height -  40 - chatbox_input_height);
		         var movie_area_height = window_height - movie_talk_header_height - 40;

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
		             $(this).html('<i class="fa fa-expand"></i>  <spring:message code="fe616.button.fullscreen"/>');
		         }else{
		             $(this).parents('.panel-movie-talk').addClass('fullpage');
		             movie_talk_fullpage();

		             $(this).html('<i class="fa fa-compress"></i>  <spring:message code="fe616.button.Ese.FullScreen"/>');
		         }
		     });
</script>
<script type="text/javascript"
src="<c:url value='/assets/js/doctor/adapter.js'/>"></script>
<script type="text/javascript"
src="<c:url value='/assets/js/doctor/common.js'/>"></script>
<script type="text/javascript"
src="<c:url value='/assets/js/doctor/main.js'/>"></script>
<script type="text/javascript"
src="<c:url value='/assets/js/doctor/ga.js'/>"></script>