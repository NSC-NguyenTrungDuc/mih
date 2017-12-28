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
					  					<spring:message code="fed09.calories" />
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
							  						<ul class="tabs calories" >
							  							<li class="item" id="Daily"><a class="/standard_food/food_type/01/duration_type/01?token="><spring:message code="general.chart.button.daily" /></a></li>
							  							<li class="item" id="Weekly"><a class="/standard_food/food_type/01/duration_type/02?token="><spring:message code="general.chart.button.weekly" /></a></li>
							  							<li class="item" id="Monthly"><a class="/standard_food/food_type/01/duration_type/03?token="><spring:message code="general.chart.button.monthly" /></a></li>
							  							<li class="item" id="Yearly"><a class="/standard_food/food_type/01/duration_type/04?token="><spring:message code="general.chart.button.yearly" /></a></li>
							  						</ul>
							  					</div>
						  						 <div id = "container1" class="chart-inner">

   												 </div>    												
							  					<div class="chart-action text-center calories">
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
							  					<ul class="list-summary calories">
							  						<li class="item">
							  							<div><spring:message code="fed09.lastestCalo" /></div>
							  							<div>
							  								<span class="value lastest">130</span><span class="unit"><spring:message code="fed09.cal" /></span>
							  							</div>
							  						</li>
							  						<li class="item">
                                                        <div><spring:message code="fed09.minCalo" /></div>
                                                        <div>
                                                            <span class="value min">150-95</span><span class="unit"><spring:message code="fed09.cal" /></span>
                                                        </div>
                                                    </li>
                                                    <li class="item">
                                                        <div><spring:message code="fed09.maxCalo" /></div>
                                                        <div>
                                                            <span class="value max">120-70</span><span class="unit"><spring:message code="fed09.cal" /></span>
                                                        </div>
                                                    </li>
							  						<li class="item">
							  							<div><spring:message code="fed09.averageCalo" /> </div>
							  							<div>
							  								<span class="value average">150</span><span class="unit"><spring:message code="fed09.cal" /></span>
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
					  					<spring:message code="fed09.carbohydrate" />
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
							  						<ul class="tabs carbohydrate">
							  							<li class="item" id="Daily"><a class="/standard_food/food_type/02/duration_type/01?token="><spring:message code="general.chart.button.daily" /></a></li>
							  							<li class="item" id="Weekly"><a class="/standard_food/food_type/02/duration_type/02?token="><spring:message code="general.chart.button.weekly" /></a></li>
							  							<li class="item" id="Monthly"><a class="/standard_food/food_type/02/duration_type/03?token="><spring:message code="general.chart.button.monthly" /></a></li>
							  							<li class="item" id="Yearly"><a class="/standard_food/food_type/02/duration_type/04?token="><spring:message code="general.chart.button.yearly" /></a></li>
							  						</ul>
							  					</div>
						  						<div id = "container2" class="chart-inner">

   												 </div>
							  					<div class="chart-action text-center carbohydrate">
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
							  					<ul class="list-summary carbohydrate">
							  						<li class="item">
							  							<div><spring:message code="fed09.lastestCarbo" /></div>
							  							<div>
							  								<span class="value lastest">130-80</span><span class="unit"><spring:message code="fed09.gam" /></span>
							  							</div>
							  						</li>
							  						<li class="item">
                                                        <div><spring:message code="fed09.minCarbo" /></div>
                                                        <div>
                                                            <span class="value min">150-95</span><span class="unit"><spring:message code="fed09.gam" /></span>
                                                        </div>
                                                    </li>
                                                    <li class="item">
                                                        <div><spring:message code="fed09.maxCarbo" /></div>
                                                        <div>
                                                            <span class="value max">120-70</span><span class="unit"><spring:message code="fed09.gam" /></span>
                                                        </div>
                                                    </li>
							  						<li class="item">
							  							<div><spring:message code="fed09.averageCarbo" /></div>
							  							<div>
							  								<span class="value average">150-95</span><span class="unit"><spring:message code="fed09.gam" /></span>
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
	 					<spring:message code="fed09.totalFat" />
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
		  						<ul class="tabs totalfat">
		  							<li class="item" id="Daily"><a class="/standard_food/food_type/03/duration_type/01?token="><spring:message code="general.chart.button.daily" /></a></li>
		  							<li class="item" id="Weekly"><a class="/standard_food/food_type/03/duration_type/02?token="><spring:message code="general.chart.button.weekly" /></a></li>
		  							<li class="item" id="Monthly"><a class="/standard_food/food_type/03/duration_type/03?token="><spring:message code="general.chart.button.monthly" /></a></li>
		  							<li class="item" id="Yearly"><a class="/standard_food/food_type/03/duration_type/04?token="><spring:message code="general.chart.button.yearly" /></a></li>
		  						</ul>
		  					</div>
	  						<div id = "container3" class="chart-inner">

							</div>
		  					<div class="chart-action text-center totalfat">
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
		  					<ul class="list-summary totalfat">
		  						<li class="item">
		  							<div><spring:message code="fed09.lastestTotalFat" /></div>
		  							<div>
		  								<span class="value lastest">130-80</span><span class="unit"><spring:message code="fed09.gam" /></span>
		  							</div>
		  						</li>
		  						<li class="item">
	                                                  <div><spring:message code="fed09.minTotalFat" /></div>
	                                                  <div>
	                                                      <span class="value min">150-95</span><span class="unit"><spring:message code="fed09.gam" /></span>
	                                                  </div>
	                                              </li>
	                                              <li class="item">
	                                                  <div><spring:message code="fed09.maxTotalFat" /></div>
	                                                  <div>
	                                                      <span class="value max">120-70</span><span class="unit"><spring:message code="fed09.gam" /></span>
	                                                  </div>
	                                              </li>
		  						<li class="item">
		  							<div><spring:message code="fed09.averageTotalFat" /></div>
		  							<div>
		  								<span class="value average">150-95</span><span class="unit"><spring:message code="fed09.gam" /></span>
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
		bindDataToChart(URL + '/standard_food/food_type/01/duration_type/02?token='+ prhToken,'container1','01','02',lang);
		bindDataToChart(URL + '/standard_food/food_type/02/duration_type/02?token='+ prhToken,'container2','02','02',lang);
		bindDataToChart(URL + '/standard_food/food_type/03/duration_type/02?token='+ prhToken,'container3','03','02',lang);	
	})
	var caloriesAverage = $('.chart-action.calories').find('.average');
	var carbohydrateAverage = $('.chart-action.carbohydrate').find('.average');
	var totalfatAverage = $('.chart-action.totalfat').find('.average');
	caloriesAverage.click(function() {
		  var chart = $('#container1').highcharts();
		  drawAverage(chart);		 
	    });
	carbohydrateAverage.click(function(){
		var chart = $('#container2').highcharts();
		drawAverage(chart);
	});
	totalfatAverage.click(function(){
		var chart = $('#container3').highcharts();
		drawAverage(chart);
	});
	 $('ul.tabs.calories li').click(function(e) 
			   {
		 		$('ul.tabs.calories').children().removeClass("active");
		 		$(this).addClass("active");
			    var url = $(this).children().attr("class");		    
			    var typeDuration = getTypeDuration($(this).attr('id'));
				bindDataToChart(URL + url + prhToken,'container1','01',typeDuration,lang);
			   });
	 $('ul.tabs.carbohydrate li').click(function(e) 
			   {
		 		$('ul.tabs.carbohydrate').children().removeClass("active");
		 		$(this).addClass("active");
		 	   	var url = $(this).children().attr("class");
		 	    var typeDuration = getTypeDuration($(this).attr('id'));
				bindDataToChart(URL + url + prhToken,'container2','02',typeDuration,lang);
			   });
	 $('ul.tabs.totalfat li').click(function(e) 
			   {
		 		$('ul.tabs.totalfat').children().removeClass("active");
		 		$(this).addClass("active");
		 	   	var url = $(this).children().attr("class");
		 	    var typeDuration = getTypeDuration($(this).attr('id'));
				bindDataToChart(URL + url + prhToken,'container3','03',typeDuration,lang);
			   });
	</script>	  		
	<script type="text/javascript" src="<c:url value='/assets/js/doctor/Food.js'/>" ></script>  
					  		