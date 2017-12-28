<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/security/tags"
	prefix="sec"%>





<div class="tabs_content">
	<p class="text-center">
		<button class="btn-opmt" id="openmovie">Open Movie Talk</button>
	</p>
</div>

<div id="patient_movietalk" class="overlay movie-talk-overlay">
	<div class="content-table">
		<div class="content-cell">
			<!-- BEGIN Movie Talk -->
			<div class="panel-movie-talk">
				<!-- BEGIN Movie Talk Area -->
				<div class="movie-talk-area">
					<div class="movie-talk-header">
						<h3 class="movie-talk-title">John Smith</h3>
						<div class="movie-talk-meta">27 years old (04/04/1992) -
							Patient Code : 01688521111 - Your id :<span id="my-id">...</span></div>
							
						<div class="action">
							<span class="item item-expand"><i class="fa fa-expand"></i>
								Full Screen</span> <span class="item item-close"><i
								class="fa fa-close"></i> Close</span>
						</div>
					</div>
					<div class="movie-area">
						<div class="video-thumb">
							<video class="input gradient input-block" name="streamvideo" id ="video" autoplay=""></video>
						</div>
						<div class=" 	">
                                    Waiting Dr John Doe<br>
                                    <span class="text-loading"></span>
                                </div>
						<div class="bleft">
							<button class="icon-action icon-video">
								<i class="fa fa-video-camera"></i>
							</button>
							<button class="icon-action icon-mic">
								<i class="fa fa-microphone"></i>
							</button>
						</div>
						<div class="bright">
							<button class="icon-action icon-endcall">
								<i class="fa fa-phone"></i>
							</button>
						</div>
					</div>
				</div>
				<!-- END Movie Talk Area -->
				<!-- BEGIN Movie Talk Chatbox -->
				<div class="movie-talk-chatbox">
					<div class="chatbox-header">Chatbox</div>
					<div class="chat-view">
						<div class="chat-row me">
							<div class="chat-pop">
								<div>Hello, how are you?</div>
								<div class="meta">10:30 AM</div>
							</div>
						</div>
						<div class="chat-row you">
							<div class="ava">
								<i class="fa fa-user"></i>
							</div>
							<div class="chat-pop">
								<div>Hello, Dr 321</div>
								<div class="meta">10:31 AM</div>
							</div>
						</div>
						<div class="typing">John Smith is typing ...</div>
					</div>
					<div class="chat-input">
						<input type="text" placeholder="Are you ready?"
							class="input input-block" value="">
						<button class="btn btn-send">SEND</button>
					</div>
				</div>
				<!-- END Movie Talk Chatbox -->
			</div>
			<!-- END Movie Talk -->
		</div>
	</div>
</div>

<script>
	$(document).ready(function() {
		$("#openmovie").click(function(){	
			
			var peer = new Peer({host:'10.1.20.247',port:9000,path:'/myapp'});
			peer.on('open',function(){
				alert(peer.id);
				$('#my-id').text(peer.id);
			})
			start();				
			
		});
		$('.btn-opmt').click(function() {
			if ($('.movie-talk-overlay').css('display') == 'none') {
				$('.movie-talk-overlay').fadeIn('0.5');
			}
		});

		$('.movie-talk-header .action .item-close').click(function() {
			
			 if (window.stream) {
				    window.stream.getTracks().forEach(function(track) {
				      track.stop();
				    });
				  }
			if ($('.movie-talk-overlay').css('display') == 'block') {
				$('.movie-talk-overlay').fadeOut('0.5');
			}
		});
		
		$('.noti-waiting').click(function(){
            if( $('#patient_movietalk').css('top') !== '0'){
                $('#patient_movietalk').css({'top':'0','width':'100%'});
                $('#patient_movietalk .panel-movie-talk').css('visibility','visible'); 
                $(this).addClass('selected');
            }else{
                $(this).removeClass('selected');
            }                       
        });
        $('#patient_movietalk .movie-talk-header .action .item.item-minimize').click(function(){  
           $('#patient_movietalk').css({'top':'100%','width':'0'});
           $('#patient_movietalk .panel-movie-talk').css('visibility','hidden');
           $('.noti-waiting').removeClass('selected');
        });
	});
</script>