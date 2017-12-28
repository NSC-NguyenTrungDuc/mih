<%@ page language="java" pageEncoding="UTF-8"%>
<%@ page contentType="text/html; charset=UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/security/tags" prefix="sec" %>
<%@ page import="nta.mss.misc.common.MssContextHolder"%>

<script>
		var profileId = '${profile_id}';
		var URL = '${url}'+"api/profiles/" + profileId;
	 	var prhToken = '${phr_token}';
	 	var lang = '<%=MssContextHolder.getHospitalLocale()%>';
</script>

<div class="panel">
					  			<div class="panel-header">
					  				<h3 class="panel-title">
					  					<spring:message code="fed12.sleep" />
					  				</h3>
					  				<div class="action">
					  					<span class="toggle opened"></span>
					  				</div>
					  			</div>
					  			<div class="panel-content sleep">
					  				<div class="chart-area">
					  					<div class="clearfix">
						  					<div class="chart-view">
							  					<div class="cheader">
							  						<ul class="tabs sleep" >
							  							<li class="item" id="Daily"><a class="/standard_life_style/duration_type/01?token="><spring:message code="general.chart.button.daily" /></a></li>
							  							<li class="item" id="Weekly"><a class="/standard_life_style/duration_type/02?token="><spring:message code="general.chart.button.weekly" /></a></li>
							  							<li class="item" id="Monthly"><a class="/standard_life_style/duration_type/03?token="><spring:message code="general.chart.button.monthly" /></a></li>
							  							<li class="item" id="Yearly"><a class="/standard_life_style/duration_type/04?token="><spring:message code="general.chart.button.yearly" /></a></li>
							  						</ul>
							  					</div>
						  						 <div id = "container1" class="chart-inner">

   												 </div>    												
							  					<div class="chart-action text-center sleep">
                                                    <span class="average"><img src="<c:url value="/assets/images/doctor/icon-average.png" />" ><spring:message code="general.chart.average" /></span> 
                                                    <span class="min"><img src="<c:url value="/assets/images/doctor/icon-min.png" />" ><spring:message code="general.chart.min" /></span>
                                                    <span class="max"><img src="<c:url value="/assets/images/doctor/icon-max.png" />" ><spring:message code="general.chart.max" /></span>
                                                    <span class="lastest"><img src="<c:url value="/assets/images/doctor/icon-lastest.png" />" ><spring:message code="general.chart.lastest" /></span>
                                                </div>
							  					
							  				</div>
							  				<div class="info">
							  					<div class="cheader">
							  						<h3 class="title"><spring:message code="summary" /></h3>
							  					</div>
							  					<ul class="list-summary sleep">
							  						<li class="item">
							  							<div><spring:message code="fed12.lastestSleep" /></div>
							  							<div>
							  								<span class="value lastest">130</span><span class="unit"><spring:message code="fed12.hour" /></span>
							  							</div>
							  						</li>
							  						<li class="item">
                                                        <div><spring:message code="fed12.minSleep" /></div>
                                                        <div>
                                                            <span class="value min">150-95</span><span class="unit"><spring:message code="fed12.hour" /></span>
                                                        </div>
                                                    </li>
                                                    <li class="item">
                                                        <div><spring:message code="fed12.maxSleep" /></div>
                                                        <div>
                                                            <span class="value max">120-70</span><span class="unit"><spring:message code="fed12.hour" /></span>
                                                        </div>
                                                    </li>
							  						<li class="item">
							  							<div><spring:message code="fed12.averageSleep" /> </div>
							  							<div>
							  								<span class="value average">150</span><span class="unit"><spring:message code="fed12.hour" /></span>
							  							</div>
							  						</li>
							  					</ul>
							  				</div>
						  				</div>
					  				</div>
					  				
					  			</div>
					  		</div>

<script>
	$(document).ready(function(){
		$('ul.tabs :nth-child(2)').addClass("active");
		$('ul.tabs a').css({cursor:"pointer"});	
		bindDataToChart(URL +'/standard_life_style/duration_type/02?token='+ prhToken,'container1','01','02',lang);		
	})
	var sleep = $('.chart-action.sleep').find('.average');
	sleep.click(function() {
		  var chart = $('#container1').highcharts();
		  drawAverage(chart);		 
	    });
	 $('ul.tabs.sleep li').click(function(e) 
			   {
		 		$('ul.tabs.sleep').children().removeClass("active");
		 		$(this).addClass("active");
			    var url = $(this).children().attr("class");		    
			    var typeDuration = getTypeDuration($(this).attr('id'));	
				bindDataToChart(URL + url + prhToken,'container1','01',typeDuration,lang);
			   });
	</script>	  		
	<script type="text/javascript" src="<c:url value='/assets/js/doctor/Sleep.js'/>" ></script>  
					  		