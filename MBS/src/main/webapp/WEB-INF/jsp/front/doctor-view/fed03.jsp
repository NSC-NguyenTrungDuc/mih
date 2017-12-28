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

   						 <div class="panel red">
					  			<div class="panel-header">
					  				<h3 class="panel-title">
					  					<spring:message code="fed03.bloodPressure" />
					  				</h3>
					  				<div class="action">
					  					<span class="toggle opened"></span>
					  				</div>
					  			</div>
					  			<div class="panel-content border">
					  				<div class="chart-area chart-full">
					  					<div class="clearfix">
						  					<div class="chart-view">
							  					<div class="cheader">
							  						<ul class="tabs bloodPressure" >
							  							<li class="item" id="Daily"><a class="/standard_temperature/temperature_type/04/duration_type/01?token="><spring:message code="general.chart.button.daily" /></a></li>
							  							<li class="item" id="Weekly"><a class="/standard_temperature/temperature_type/04/duration_type/02?token="><spring:message code="general.chart.button.weekly" /></a></li>
							  							<li class="item" id="Monthly"><a class="/standard_temperature/temperature_type/04/duration_type/03?token="><spring:message code="general.chart.button.monthly" /></a></li>
							  							<li class="item" id="Yearly"><a class="/standard_temperature/temperature_type/04/duration_type/04?token="><spring:message code="general.chart.button.yearly" /></a></li>
							  						</ul>
							  					</div>
						  						 <div id = "container1" class="chart-inner">
   												 </div>
							  				</div>
							  				<div class="info">
							  					<div class="cheader content-table">
							  						<div class="content-cell" style="width:50%">
                                                        <h3 class="title"><spring:message code="summary" /></h3>
                                                    </div>
													<div class="content-cell" style="width:25%">
                                                        <h5><spring:message code="fed03.lowbloodPressure" /></h5> 
                                                    </div>
                                                    <div class="content-cell" style="width:25%">
                                                        <h5><spring:message code="fed03.highbloodPressure" /></h5> 
                                                    </div> 
							  					</div>
							  					<ul class="list-summary bloodPressure">
							  						<li class="item content-table">
                                                        <div class="content-cell" style="width:50%"><spring:message code="fed03.minBloodPressure" /></div>
                                                        <div class="content-cell" style="width:25%">
                                                            <span class="value min low">150</span><span class="unit"><spring:message code="fed03.mmHg" /></span>
                                                        </div>
                                                        <div class="content-cell" style="width:25%">
                                                            <span class="value min high">150</span><span class="unit"><spring:message code="fed03.mmHg" /></span>
                                                        </div>
                                                    </li>
                                                    <li class="item content-table">
                                                        <div class="content-cell" style="width:50%"><spring:message code="fed03.maxBloodPressure" /></div>
                                                        <div class="content-cell" style="width:25%">
                                                            <span class="value max low">120</span><span class="unit"><spring:message code="fed03.mmHg" /></span>
                                                        </div>
                                                        <div class="content-cell" style="width:25%">
                                                            <span class="value max high">120</span><span class="unit"><spring:message code="fed03.mmHg" /></span>
                                                        </div>
                                                    </li>
							  						<li class="item content-table">
							  							<div class="content-cell" style="width:50%"><spring:message code="fed03.averageBloodPressure" /> </div>
							  							<div class="content-cell" style="width:25%">
							  								<span class="value average low">150-130</span><span class="unit"><spring:message code="fed03.mmHg" /></span>
							  							</div>
							  							<div class="content-cell" style="width:25%">
							  								<span class="value average high">150-90</span><span class="unit"><spring:message code="fed03.mmHg" /></span>
							  							</div>
							  						</li>
							  					</ul>
							  				</div>
						  				</div>
					  				</div>					  				
					  			</div>
					  		</div>
					  	 <div class="panel orange">
					  			<div class="panel-header">
					  				<h3 class="panel-title">
					  					<spring:message code="fed03.heartRate" />
					  				</h3>
					  				<div class="action">
					  					<span class="toggle opened"></span>
					  				</div>
					  			</div>
					  			<div class="panel-content border">
					  				<div class="chart-area chart-full">
					  					<div class="clearfix">
						  					<div class="chart-view">
							  					<div class="cheader">
							  						<ul class="tabs heartRate" >
							  							<li class="item" id="Daily"><a class="/standard_temperature/temperature_type/02/duration_type/01?token="><spring:message code="general.chart.button.daily" /></a></li>
							  							<li class="item" id="Weekly"><a class="/standard_temperature/temperature_type/02/duration_type/02?token="><spring:message code="general.chart.button.weekly" /></a></li>
							  							<li class="item" id="Monthly"><a class="/standard_temperature/temperature_type/02/duration_type/03?token="><spring:message code="general.chart.button.monthly" /></a></li>
							  							<li class="item" id="Yearly"><a class="/standard_temperature/temperature_type/02/duration_type/04?token="><spring:message code="general.chart.button.yearly" /></a></li>
							  						</ul>
							  					</div>
						  						 <div id = "container2" class="chart-inner">

   												 </div>
							  				</div>
							  				<div class="info">
							  					<div class="cheader content-table">
							  						<div class="content-cell" style="width:50%">
                                                        <h3 class="title"><spring:message code="summary" /></h3>
                                                    </div>
													<div class="content-cell" style="width:25%">
                                                        <h5><spring:message code="fed03.heartRate" /></h5>
                                                    </div>
							  					</div>
							  					<ul class="list-summary heartRate">
							  						<li class="item content-table">
                                                        <div class="content-cell" style="width:50%"><spring:message code="fed03.minHeartRate" /></div>
                                                        <div class="content-cell" style="width:25%">
                                                            <span class="value min">150-95</span><span class="unit"><spring:message code="fed03.pulse" /></span>
                                                        </div>
                                                    </li>
                                                    <li class="item content-table">
                                                        <div class="content-cell" style="width:50%"><spring:message code="fed03.maxHeartRate" /></div>
                                                        <div class="content-cell" style="width:25%">
                                                            <span class="value max">120-70</span><span class="unit"><spring:message code="fed03.pulse" /></span>
                                                        </div>
                                                    </li>
							  						<li class="item content-table">
							  							<div class="content-cell" style="width:50%"><spring:message code="fed03.averageHeartRate" /> </div>
							  							<div class="content-cell" style="width:25%">
							  								<span class="value average">150</span><span class="unit"><spring:message code="fed03.pulse" /></span>
							  							</div>
							  						</li>
							  					</ul>
							  				</div>
						  				</div>
					  				</div>
					  				
					  			</div>
					  		</div>	
					  		
					<div class="panel lightblue">
					  			<div class="panel-header">
					  				<h3 class="panel-title">
					  					<spring:message code="fed03.temperature" />
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
							  						<ul class="tabs temperature">
							  							<li class="item" id="Daily"><a class="/standard_temperature/temperature_type/01/duration_type/01?token="><spring:message code="general.chart.button.daily" /></a></li>
							  							<li class="item" id="Weekly"><a class="/standard_temperature/temperature_type/01/duration_type/02?token="><spring:message code="general.chart.button.weekly" /></a></li>
							  							<li class="item" id="Monthly"><a class="/standard_temperature/temperature_type/01/duration_type/03?token="><spring:message code="general.chart.button.monthly" /></a></li>
							  							<li class="item" id="Yearly"><a class="/standard_temperature/temperature_type/01/duration_type/04?token="><spring:message code="general.chart.button.yearly" /></a></li>
							  						</ul>
							  					</div>
						  						<div id = "container3" class="chart-inner">

   												</div>
							  					<div class="chart-action text-center temperature">
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
							  					<ul class="list-summary temperature">
							  						<li class="item">
							  							<div><spring:message code="fed03.lastestTemperature" /></div>
							  							<div>
							  								<span class="value lastest">130</span><span class="unit"><spring:message code="fed03.degree" /></span>
							  							</div>
							  						</li>
							  						<li class="item">
                                                        <div><spring:message code="fed03.minTemperature" /></div>
                                                        <div>
                                                            <span class="value min">150-95</span><span class="unit"><spring:message code="fed03.degree" /></span>
                                                        </div>
                                                    </li>
                                                    <li class="item">
                                                        <div><spring:message code="fed03.maxTemperature" /></div>
                                                        <div>
                                                            <span class="value max">120-70</span><span class="unit"><spring:message code="fed03.degree" /></span>
                                                        </div>
                                                    </li>
							  						<li class="item">
							  							<div><spring:message code="fed03.averageTemperature" /> </div>
							  							<div>
							  								<span class="value average">150</span><span class="unit"><spring:message code="fed03.degree" /></span>
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
					  					<spring:message code="fed03.respirationRate" />
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
							  						<ul class="tabs respirationRate">
							  							<li class="item" id="Daily"><a class="/standard_temperature/temperature_type/03/duration_type/01?token="><spring:message code="general.chart.button.daily" /></a></li>
							  							<li class="item" id="Weekly"><a class="/standard_temperature/temperature_type/03/duration_type/02?token="><spring:message code="general.chart.button.weekly" /></a></li>
							  							<li class="item" id="Monthly"><a class="/standard_temperature/temperature_type/03/duration_type/03?token="><spring:message code="general.chart.button.monthly" /></a></li>
							  							<li class="item" id="Yearly"><a class="/standard_temperature/temperature_type/03/duration_type/04?token="><spring:message code="general.chart.button.yearly" /></a></li>
							  						</ul>
							  					</div>
						  						<div id = "container4" class="chart-inner">

   												 </div>
							  					<div class="chart-action text-center respirationRate">
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
							  					<ul class="list-summary respirationRate">
							  						<li class="item">
							  							<div><spring:message code="fed03.lastestRespirationRate" /></div>
							  							<div>
							  								<span class="value lastest">130</span><span class="unit"><spring:message code="fed03.breathMin" /></span>
							  							</div>
							  						</li>
							  						<li class="item">
                                                        <div><spring:message code="fed03.minRespirationRate" /></div>
                                                        <div>
                                                            <span class="value min">150-95</span><span class="unit"><spring:message code="fed03.breathMin" /></span>
                                                        </div>
                                                    </li>
                                                    <li class="item">
                                                        <div><spring:message code="fed03.maxRespirationRate" /></div>
                                                        <div>
                                                            <span class="value max">120-70</span><span class="unit"><spring:message code="fed03.breathMin" /></span>
                                                        </div>
                                                    </li>
							  						<li class="item">
							  							<div><spring:message code="fed03.averageRespirationRate" /> </div>
							  							<div>
							  								<span class="value average">150</span><span class="unit"><spring:message code="fed03.breathMin" /></span>
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
		bindDataBloodPressureToChart(URL + '/standard_temperature/temperature_type/04/duration_type/02?token='+ prhToken,'container1','01','02',lang);
		bindDataHeartrateToChart(URL + '/standard_temperature/temperature_type/02/duration_type/02?token='+ prhToken,'container2','02','02',lang);
	    bindDataToChart(URL + '/standard_temperature/temperature_type/01/duration_type/02?token='+ prhToken,'container3','03','02',lang);		
		bindDataToChart(URL + '/standard_temperature/temperature_type/03/duration_type/02?token='+ prhToken,'container4','04','02',lang);			
	})
	
	var temperature = $('.chart-action.temperature').find('.average');
	var reprirationRate = $('.chart-action.respirationRate').find('.average');
	temperature.click(function() {
		  var chart = $('#container3').highcharts();
		  drawAverage(chart);		 
	    });
	reprirationRate.click(function(){
		var chart = $('#container4').highcharts();
		drawAverage(chart);
	});
	 $('ul.tabs.bloodPressure li').click(function(e) 
			   {
		 		$('ul.tabs.bloodPressure').children().removeClass("active");
		 		$(this).addClass("active");
			    var url = $(this).children().attr("class");		    
			    var typeDuration = getTypeDuration($(this).attr('id'));
			    bindDataBloodPressureToChart(URL + url + prhToken,'container1','01',typeDuration,lang);
			   });
	 $('ul.tabs.heartRate li').click(function(e) 
			   {
		 		$('ul.tabs.heartRate').children().removeClass("active");
		 		$(this).addClass("active");
		 	   	var url = $(this).children().attr("class");
		 	    var typeDuration = getTypeDuration($(this).attr('id'));
		 	   bindDataHeartrateToChart(URL + url + prhToken,'container2','02',typeDuration,lang);
			   });
	 $('ul.tabs.temperature li').click(function(e) 
			   {
		 		$('ul.tabs.temperature').children().removeClass("active");
		 		$(this).addClass("active");
		 	    var url = $(this).children().attr("class");
		 	    var typeDuration = getTypeDuration($(this).attr('id'));
				bindDataToChart(URL + url + prhToken,'container3','03',typeDuration,lang);
			   });
	 $('ul.tabs.respirationRate li').click(function(e) 
			   {
		 		$('ul.tabs.respirationRate').children().removeClass("active");
		 		$(this).addClass("active");
		 	    var url = $(this).children().attr("class");
		 	    var typeDuration = getTypeDuration($(this).attr('id'));
				bindDataToChart(URL + url + prhToken,'container4','04',typeDuration,lang);
			   });
	</script>	  		
	<script type="text/javascript" src="<c:url value='/assets/js/doctor/Vital.js'/>" ></script>  
