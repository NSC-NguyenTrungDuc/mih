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
					  					<spring:message code="fed02.height" />
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
							  						<ul class="tabs height" >
							  							<li class="item" id="Daily"><a class="/standard_health/health_type/01/duration_type/01?token="><spring:message code="general.chart.button.daily" /></a></li>
							  							<li class="item" id="Weekly"><a class="/standard_health/health_type/01/duration_type/02?token="><spring:message code="general.chart.button.weekly" /></a></li>
							  							<li class="item" id="Monthly"><a class="/standard_health/health_type/01/duration_type/03?token="><spring:message code="general.chart.button.monthly" /></a></li>
							  							<li class="item" id="Yearly"><a class="/standard_health/health_type/01/duration_type/04?token="><spring:message code="general.chart.button.yearly" /></a></li>
							  						</ul>
							  					</div>
						  						 <div id = "container1" class="chart-inner">

   												 </div>
							  					<div class="chart-action text-center height">
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
							  					<ul class="list-summary height">
							  						<li class="item">
							  							<div><spring:message code="fed02.lastestHeight" /></div>
							  							<div>
							  								<span class="value lastest">130</span><span class="unit"><spring:message code="fed02.cm" /></span>
							  							</div>
							  						</li>
							  						<li class="item">
                                                        <div><spring:message code="fed02.minHeight" /></div>
                                                        <div>
                                                            <span class="value min">150-95</span><span class="unit"><spring:message code="fed02.cm" /></span>
                                                        </div>
                                                    </li>
                                                    <li class="item">
                                                        <div><spring:message code="fed02.maxHeight" /></div>
                                                        <div>
                                                            <span class="value max">120-70</span><span class="unit"><spring:message code="fed02.cm" /></span>
                                                        </div>
                                                    </li>
							  						<li class="item">
							  							<div><spring:message code="fed02.averageHeight" /> </div>
							  							<div>
							  								<span class="value average">150</span><span class="unit"><spring:message code="fed02.cm" /></span>
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
					  					<spring:message code="fed02.weight" />
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
							  						<ul class="tabs weight" >
							  							<li class="item" id="Daily"><a class="/standard_health/health_type/02/duration_type/01?token="><spring:message code="general.chart.button.daily" /></a></li>
							  							<li class="item" id="Weekly"><a class="/standard_health/health_type/02/duration_type/02?token="><spring:message code="general.chart.button.weekly" /></a></li>
							  							<li class="item" id="Monthly"><a class="/standard_health/health_type/02/duration_type/03?token="><spring:message code="general.chart.button.monthly" /></a></li>
							  							<li class="item" id="Yearly"><a class="/standard_health/health_type/02/duration_type/04?token="><spring:message code="general.chart.button.yearly" /></a></li>
							  						</ul>
							  					</div>
						  						 <div id = "container2" class="chart-inner">

   												 </div>
							  					<div class="chart-action text-center weight">
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
							  					<ul class="list-summary weight">
							  						<li class="item">
							  							<div><spring:message code="fed02.lastestWeight" /></div>
							  							<div>
							  								<span class="value lastest">130</span><span class="unit"><spring:message code="fed02.kg" /></span>
							  							</div>
							  						</li>
							  						<li class="item">
                                                        <div><spring:message code="fed02.minWeight" /></div>
                                                        <div>
                                                            <span class="value min">150-95</span><span class="unit"><spring:message code="fed02.kg" /></span>
                                                        </div>
                                                    </li>
                                                    <li class="item">
                                                        <div><spring:message code="fed02.maxWeight" /></div>
                                                        <div>
                                                            <span class="value max">120-70</span><span class="unit"><spring:message code="fed02.kg" /></span>
                                                        </div>
                                                    </li>
							  						<li class="item">
							  							<div><spring:message code="fed02.averageWeight" /> </div>
							  							<div>
							  								<span class="value average">150</span><span class="unit"><spring:message code="fed02.kg" /></span>
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
					  					<spring:message code="fed02.bodyMassIndex" />
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
							  						<ul class="tabs bodymass">
							  							<li class="item" id="Daily"><a class="/standard_health/health_type/03/duration_type/01?token="><spring:message code="general.chart.button.daily" /></a></li>
							  							<li class="item" id="Weekly"><a class="/standard_health/health_type/03/duration_type/02?token="><spring:message code="general.chart.button.weekly" /></a></li>
							  							<li class="item" id="Monthly"><a class="/standard_health/health_type/03/duration_type/03?token="><spring:message code="general.chart.button.monthly" /></a></li>
							  							<li class="item" id="Yearly"><a class="/standard_health/health_type/03/duration_type/04?token="><spring:message code="general.chart.button.yearly" /></a></li>
							  						</ul>
							  					</div>
						  						<div id = "container3" class="chart-inner">

   												 </div>
							  					<div class="chart-action text-center bodymass">
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
							  					<ul class="list-summary bodymass">
							  						<li class="item">
							  							<div><spring:message code="fed02.lastestBodyMassIndex" /></div>
							  							<div>
							  								<span class="value lastest">130</span><span class="unit"><spring:message code="fed02.kg.m2" /></span>
							  							</div>
							  						</li>
							  						<li class="item">
                                <div><spring:message code="fed02.minBodyMassIndex" /></div>
                                <div>
                                    <span class="value min">150-95</span><span class="unit"><spring:message code="fed02.kg.m2" /></span>
                                </div>
                            </li>
                            <li class="item">
                                <div><spring:message code="fed02.maxBodyMassIndex" /></div>
                                <div>
                                    <span class="value max">120-70</span><span class="unit"><spring:message code="fed02.kg.m2" /></span>
                                </div>
                            </li>
							  						<li class="item">
							  							<div><spring:message code="fed02.averageBodyMassIndex" /> </div>
							  							<div>
							  								<span class="value average">150</span><span class="unit"><spring:message code="fed02.kg.m2" /></span>
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
					  					<spring:message code="fed02.bodyFat" />
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
							  						<ul class="tabs bodyfat">
							  							<li class="item" id="Daily"><a class="/standard_health/health_type/04/duration_type/01?token="><spring:message code="general.chart.button.daily" /></a></li>
							  							<li class="item" id="Weekly"><a class="/standard_health/health_type/04/duration_type/02?token="><spring:message code="general.chart.button.weekly" /></a></li>
							  							<li class="item" id="Monthly"><a class="/standard_health/health_type/04/duration_type/03?token="><spring:message code="general.chart.button.monthly" /></a></li>
							  							<li class="item" id="Yearly"><a class="/standard_health/health_type/04/duration_type/04?token="><spring:message code="general.chart.button.yearly" /></a></li>
							  						</ul>
							  					</div>
						  						<div id = "container4" class="chart-inner">

   												 </div>
							  					<div class="chart-action text-center bodyfat">
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
							  					<ul class="list-summary bodyfat">
							  						<li class="item">
							  							<div><spring:message code="fed02.lastestBodyFat" /></div>
							  							<div>
							  								<span class="value lastest">130</span><span class="unit"><spring:message code="fed02.percen" /></span>
							  							</div>
							  						</li>
							  						<li class="item">
                                                        <div><spring:message code="fed02.minBodyFat" /></div>
                                                        <div>
                                                            <span class="value min">150-95</span><span class="unit"><spring:message code="fed02.percen" /></span>
                                                        </div>
                                                    </li>
                                                    <li class="item">
                                                        <div><spring:message code="fed02.maxBodyFat" /></div>
                                                        <div>
                                                            <span class="value max">120-70</span><span class="unit"><spring:message code="fed02.percen" /></span>
                                                        </div>
                                                    </li>
							  						<li class="item">
							  							<div><spring:message code="fed02.averageBodyFat" /> </div>
							  							<div>
							  								<span class="value average">150</span><span class="unit"><spring:message code="fed02.percen" /></span>
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
		bindDataToChart(URL + '/standard_health/health_type/01/duration_type/02?token='+prhToken,'container1','01','02',lang);
		bindDataToChart(URL +'/standard_health/health_type/02/duration_type/02?token='+prhToken,'container2','02','02',lang);
	    bindDataToChart(URL +'/standard_health/health_type/03/duration_type/02?token='+prhToken,'container3','03','02',lang);
		bindDataToChart(URL +'/standard_health/health_type/04/duration_type/02?token='+prhToken,'container4','04','02',lang);
	})
	var height = $('.chart-action.height').find('.average');
	var weight = $('.chart-action.weight').find('.average');
	var bodyfat = $('.chart-action.bodyfat').find('.average');
	var bodymass = $('.chart-action.bodymass').find('.average');
	height.click(function() {
		  var chart = $('#container1').highcharts();
		  drawAverage(chart);
	    });
	weight.click(function() {
		  var chart = $('#container2').highcharts();
		  drawAverage(chart);
	    });
	bodyfat.click(function() {
		  var chart = $('#container4').highcharts();
		  drawAverage(chart);
	    });
	bodymass.click(function() {
		  var chart = $('#container3').highcharts();
		  drawAverage(chart);
	    });

	 $('ul.tabs.height li').click(function(e)
			   {
		 		$('ul.tabs.height').children().removeClass("active");
		 		$(this).addClass("active");
			    var url = $(this).children().attr("class");
			    var typeDuration = getTypeDuration($(this).attr('id'));
				bindDataToChart(URL + url + prhToken,'container1','01',typeDuration,lang);
			   });
	 $('ul.tabs.weight li').click(function(e)
			   {
		 		$('ul.tabs.weight').children().removeClass("active");
		 		$(this).addClass("active");
		 	   	var url = $(this).children().attr("class");
		 	    var typeDuration = getTypeDuration($(this).attr('id'));
				bindDataToChart(URL + url + prhToken,'container2','02',typeDuration,lang);
			   });
	 $('ul.tabs.bodyfat li').click(function(e)
			   {
		 		$('ul.tabs.bodyfat').children().removeClass("active");
		 		$(this).addClass("active");
		 	    var url = $(this).children().attr("class");
		 	    var typeDuration = getTypeDuration($(this).attr('id'));
				bindDataToChart(URL + url + prhToken,'container4','04',typeDuration,lang);
			   });
	 $('ul.tabs.bodymass li').click(function(e)
			   {
		 		$('ul.tabs.bodymass').children().removeClass("active");
		 		$(this).addClass("active");
		 	    var url = $(this).children().attr("class");
		 	    var typeDuration = getTypeDuration($(this).attr('id'));
				bindDataToChart(URL + url + prhToken,'container3','03',typeDuration,lang);
			   });
	</script>
	<script type="text/javascript" src="<c:url value='/assets/js/doctor/BodyMeasurement.js'/>" ></script>
