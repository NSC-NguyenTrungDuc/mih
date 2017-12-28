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
					  					<spring:message code="fed07.stepCount" />
					  				</h3>
					  				<div class="action">
					  					<span class="toggle opened"></span>
					  				</div>
					  			</div>
					  			<div class="panel-content border">
					  				<div class="chart-area">
					  					<div class="clearfix">
						  					<div class="chart-view">
							  					<div class="cheader">
							  						<ul class="tabs step-count" >
							  							<li class="item" id="Daily"><a class="/standard_fitness/fitness_type/01/duration_type/01?token="><spring:message code="general.chart.button.daily" /></a></li>
							  							<li class="item" id="Weekly"><a class="/standard_fitness/fitness_type/01/duration_type/02?token="><spring:message code="general.chart.button.weekly" /></a></li>
							  							<li class="item" id="Monthly"><a class="/standard_fitness/fitness_type/01/duration_type/03?token="><spring:message code="general.chart.button.monthly" /></a></li>
							  							<li class="item" id="Yearly"><a class="/standard_fitness/fitness_type/01/duration_type/04?token="><spring:message code="general.chart.button.yearly" /></a></li>
							  						</ul>
							  					</div>
							  						 <div id = "container1" class="chart-inner">

    												 </div>
							  					<div class="chart-action text-center step-count">
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
							  					<ul class="list-summary step-count">
							  						<li class="item">
							  							<div><spring:message code="fed07.lastestStepCount" /></div>
							  							<div>
							  								<span class="value lastest">130</span><span class="unit"><spring:message code="fed07.step" /></span>
							  							</div>
							  						</li>
							  						<li class="item">
                                                        <div><spring:message code="fed07.minStepCount" /></div>
                                                        <div>
                                                            <span class="value min">150-95</span><span class="unit"><spring:message code="fed07.step" /></span>
                                                        </div>
                                                    </li>
                                                    <li class="item">
                                                        <div><spring:message code="fed07.maxStepCount" /></div>
                                                        <div>
                                                            <span class="value max">120-70</span><span class="unit"><spring:message code="fed07.step" /></span>
                                                        </div>
                                                    </li>
							  						<li class="item">
							  							<div><spring:message code="fed07.averageStepCount" /> </div>
							  							<div>
							  								<span class="value average">150</span><span class="unit"><spring:message code="fed07.step" /></span>
							  							</div>
							  						</li>
							  					</ul>
							  				</div>
						  				</div>
					  				</div>

					  			</div>
					  		</div>
<div class="panel">
					  			<div class="panel-header">
					  				<h3 class="panel-title">
					  					<spring:message code="fed07.walkingRunning" />
					  				</h3>
					  				<div class="action">
					  					<span class="toggle opened"></span>
					  				</div>
					  			</div>
					  			<div class="panel-content border">
					  				<div class="chart-area">
					  					<div class="clearfix">
						  					<div class="chart-view">
							  					<div class="cheader">
							  						<ul class="tabs walking-running">
							  							<li class="item" id="Daily"><a class="/standard_fitness/fitness_type/02/duration_type/01?token="><spring:message code="general.chart.button.daily" /></a></li>
							  							<li class="item" id="Weekly"><a class="/standard_fitness/fitness_type/02/duration_type/02?token="><spring:message code="general.chart.button.weekly" /></a></li>
							  							<li class="item" id="Monthly"><a class="/standard_fitness/fitness_type/02/duration_type/03?token="><spring:message code="general.chart.button.monthly" /></a></li>
							  							<li class="item" id="Yearly"><a class="/standard_fitness/fitness_type/02/duration_type/04?token="><spring:message code="general.chart.button.yearly" /></a></li>
							  						</ul>
							  					</div>
							  						<div id = "container2" class="chart-inner">

    												 </div>
							  					<div class="chart-action text-center walking-running">
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
							  					<ul class="list-summary walking-running">
							  						<li class="item">
							  							<div><spring:message code="fed07.lastestWalkingRunning" /></div>
							  							<div>
							  								<span class="value lastest">130-80</span><span class="unit"><spring:message code="fed07.km" /></span>
							  							</div>
							  						</li>
							  						<li class="item">
                                                        <div><spring:message code="fed07.minWalkingRunning" /></div>
                                                        <div>
                                                            <span class="value min">150-95</span><span class="unit"><spring:message code="fed07.km" /></span>
                                                        </div>
                                                    </li>
                                                    <li class="item">
                                                        <div><spring:message code="fed07.maxWalkingRunning" /></div>
                                                        <div>
                                                            <span class="value max">120-70</span><span class="unit"><spring:message code="fed07.km" /></span>
                                                        </div>
                                                    </li>
							  						<li class="item">
							  							<div><spring:message code="fed07.averageWalkingRunning" /></div>
							  							<div>
							  								<span class="value average">150-95</span><span class="unit"><spring:message code="fed07.km" /></span>
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
		bindDataToChart(URL + '/standard_fitness/fitness_type/01/duration_type/02?token='+ prhToken,'container1','01','02',lang);
		bindDataToChart(URL + '/standard_fitness/fitness_type/02/duration_type/02?token='+ prhToken,'container2','02','02',lang);
	})
	var stepAccountAverage = $('.chart-action.step-count').find('.average');
	var walkingRunningAverage = $('.chart-action.walking-running').find('.average');
	stepAccountAverage.click(function() {
		  var chart = $('#container1').highcharts();
		  drawAverage(chart);
	    });
	walkingRunningAverage.click(function(){
		var chart = $('#container2').highcharts();
		drawAverage(chart);
	});
	 $('ul.tabs.step-count li').click(function(e)
			   {
		 		$('ul.tabs.step-count').children().removeClass("active");
		 		$(this).addClass("active");
			    var url = $(this).children().attr("class");		    
			    var typeDuration = getTypeDuration($(this).attr('id'));
				bindDataToChart(URL + url + prhToken,'container1','01',typeDuration,lang);
			   });
	 $('ul.tabs.walking-running li').click(function(e)
			   {
		 		$('ul.tabs.walking-running').children().removeClass("active");
		 		$(this).addClass("active");
		 	   	var url = $(this).children().attr("class");
		 	    var typeDuration = getTypeDuration($(this).attr('id'));
				bindDataToChart(URL + url + prhToken,'container2','02',typeDuration,lang);
			   });
	</script>
	<script type="text/javascript" src="<c:url value='/assets/js/doctor/Fitness.js'/>" ></script>
