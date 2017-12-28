
$(document).ready(function(){

		/*-----------------------------------------------------------------------------------*/
		/*  FUNCTION: CONTENT MIDDLE 
		/*-----------------------------------------------------------------------------------*/

		function content_middle(wrap,content){
			var wrapHeight = wrap.height();
			var contentHeight = content.height();

			var middle_top = (wrapHeight - contentHeight)/2;

			content.css('margin-top',middle_top);
		}

		/* Slide Middle Text */
		$('.home-slider .slide .middle-text').each(function(){
			content_middle($(this).parents('.slide'),$(this));
		});

		/*-----------------------------------------------------------------------------------*/
		/*  ScrollReveal
		/*-----------------------------------------------------------------------------------*/

		window.sr = new scrollReveal();

		/*-----------------------------------------------------------------------------------*/
		/*  MENU OFF CANVAS
		/*-----------------------------------------------------------------------------------*/

		$("#off-canvas-menu").mmenu({
			navbar: {
		        title: "Karte Clinic"
		    }
		});

		var API = $("#off-canvas-menu").data( "mmenu" );

		$("#nav-toggle").click(function() {
        	 API.open();
      	});

		

		/*-----------------------------------------------------------------------------------*/
		/*  OPEN mMENU
		/*-----------------------------------------------------------------------------------*/

		function close_bg_blur(){
			/* Close Mmenu */
			$('.mapz-wrap .bg-blur .close').click(function(){
				$('.bg-blur').remove();
				$('.mmenu').fadeIn();
			});
		}
		
		$('.mmenu.topleft .mmenu-toggle').click(function(){

			if($(window).width()<992){
				$('.mapz-wrap').append('<div class="bg-blur"><span class="close"><i class="fa fa-close"></i></span></div>');
				$('.mmenu.topleft').clone().appendTo('.bg-blur');
				$('.bg-blur .mmenu.topleft').removeClass('mmenu');
				$('.mmenu').hide();

				close_bg_blur();
			}		
			
		});	

		$('.mmenu.topright .mmenu-toggle').click(function(){
			if($(window).width()<992){
				$('.mapz-wrap').append('<div class="bg-blur"><span class="close"><i class="fa fa-close"></i></span></div>');
				$('.mmenu.topright').clone().appendTo('.bg-blur');
				$('.bg-blur .mmenu.topright').removeClass('mmenu');
				$('.mmenu').hide();
				
				close_bg_blur();
			}
		});				

		$('.mmenu.bottomleft .mmenu-toggle').click(function(){
			if($(window).width()<992){
				$('.mapz-wrap').append('<div class="bg-blur"><span class="close"><i class="fa fa-close"></i></span></div>');
				$('.mmenu.bottomleft').clone().appendTo('.bg-blur');
				$('.bg-blur .mmenu.bottomleft').removeClass('mmenu');
				$('.mmenu').hide();
				
				close_bg_blur();
			}
		});

		$('.mmenu.bottomright .mmenu-toggle').click(function(){
			if($(window).width()<992){
				$('.mapz-wrap').append('<div class="bg-blur"><span class="close"><i class="fa fa-close"></i></span></div>');
				$('.mmenu.bottomright').clone().appendTo('.bg-blur');
				$('.bg-blur .mmenu.bottomright').removeClass('mmenu');
				$('.mmenu').hide();
				
				close_bg_blur();
			}
		});	


		/*-----------------------------------------------------------------------------------*/
		/*  WINDOW RESIZE 
		/*-----------------------------------------------------------------------------------*/
		$(window).resize(function() {
			
	  		/* Slide Middle Text */
			$('.home-slider .slide .middle-text').each(function(){
				content_middle($(this).parents('.slide'),$(this));
			});	  

		});

});
