	/**
	 * @author Le thanh tung
	 *  Function relate module vital
	 */

	/**
	 * @summary Short description : function relate module vital
	 * @since 18.8.06
	 * @access private
	 * @param type $varUrl : url request from server
	 * @param type $varContainer : area data fillup from server
	 * @param type $type : type vital
	 * @param type $typeDuration : type duration call from api include daily, weekly, monthly, yearly
	 * @return void.
	 */
  var roundNum = 2;
 function bindDataToChart(varUrl,varContainer,type,typeDuration,lang)
 {
	 var legendXaxis = setLabellegendXaxis(typeDuration,lang);
	 var average = 0;
	 var lastest = 0;
	 var url = varUrl;
     var options = {
    	title:{
    	    text:''
    		},
    		tooltip: {
    			  formatter: function() {
    			    return  this.y
    			  }
    			},
    	credits: {
            enabled: false
        },
        chart: {
            renderTo: varContainer,
            type: 'line',
            events: {
                redraw: function() {

                }
            }
        },
        xAxis: {
        	title: {
                style: {
                  fontWeight: 'bold'
                },
                text: legendXaxis
              },
              min : 0.5,
              startOnTick: false,
              endOnTick: false,
              minPadding: 0,
              maxPadding: 0,
              align: "left"
            },
        yAxis: [{
            lineWidth: 1,
            opposite: false,
            title: {
                text: ''
                        }
        }],
        series: [{}]
    };
     $.ajax({
		url: url,
		type: 'GET',
		dataType: 'json',
		success: function(json) {
			if(type == '03')
				{
					var data = covertDataToSeriesTemperature(json,typeDuration,lang);
					var time = new Array();
					var dataChart = new Array();
					if(data.length > 0){
						for(var i = 0 ; i < data.length ; i++ )
							{
							time[i] = data[i][0];
							dataChart[i] = data[i][1];
							}
					}
					options.series[0].data = dataChart;
					if(time.length == 1)
						{
						options.xAxis.min = 0;
						}
					options.xAxis.categories = time;
				}
			else if(type == '04')
			{
				var data = covertDataToSeriesRespiration(json,typeDuration,lang);
				var time = new Array();
				var dataChart = new Array();
				if(data.length > 0){
					for(var i = 0 ; i < data.length ; i++ )
						{
						time[i] = data[i][0];
						dataChart[i] = data[i][1];
						}
				}
				options.series[0].data = dataChart;
				if(time.length == 1)
					{
					options.xAxis.min = 0;
					}
				options.xAxis.categories = time;
			}
			var length = options.series[0].data.length;
			var minData = 0.00;
			var maxData = 0.00;
			if(length > 0){
			   minData = options.series[0].data[0];
			   maxData = options.series[0].data[0];
			}
			for ( var i = 0 ; i < length ; i++)
				{
				average = average + options.series[0].data[i];
				if(minData >= options.series[0].data[i])
					{
					minData = options.series[0].data[i];
					}
				if(maxData <= options.series[0].data[i])
					{
					maxData = options.series[0].data[i];
					}
				}
			if (length > 0){
			average = average/length;
			lastest = options.series[0].data[length - 1];
			}
 			options.series[0].showInLegend = false;
 			new Highcharts.Chart(options);
 			$('.chart-action.temperature').find('.min').click(function() {
 		 			var chart = $('#container3').highcharts();
 		 			fillTooltipEvent(chart,'min');
 			    });
 			$('.chart-action.temperature').find('.max').click(function() {
		 			var chart = $('#container3').highcharts();
		 			fillTooltipEvent(chart,'max');
			    });
 			$('.chart-action.temperature').find('.lastest').click(function() {
		 			var chart = $('#container3').highcharts();
		 			fillTooltipEvent(chart,'lastest');
			    });
 			$('.chart-action.respirationRate').find('.min').click(function() {
		 			var chart = $('#container4').highcharts();
		 			fillTooltipEvent(chart,'min');
			    });
			$('.chart-action.respirationRate').find('.max').click(function() {
	 			var chart = $('#container4').highcharts();
	 			fillTooltipEvent(chart,'max');
		    });
			$('.chart-action.respirationRate').find('.lastest').click(function() {
	 			var chart = $('#container4').highcharts();
	 			fillTooltipEvent(chart,'lastest');
		    });

 			fillSummary(parseFloat(average).toFixed(roundNum),parseFloat(lastest).toFixed(roundNum),parseFloat(minData).toFixed(roundNum),parseFloat(maxData).toFixed(roundNum),type);
		},
         error:function()
         {
        	 fillSummary(parseFloat(average).toFixed(roundNum),parseFloat(lastest).toFixed(roundNum),0.00,0.00,type);
         }
	});
 }
 // Draw chart for bloodpressure
 function bindDataBloodPressureToChart(varUrl,varContainer,type,typeDuration,lang)
 {
	 var minLowBloodPressure = {"en":"Min Low blood pressure","ja" : "最小  低い  血圧","vi" : "Huyết áp thấp nhỏ nhất"};
	 var maxLowBloodPressure = {"en":"Max Low blood pressure","ja" : "最大  低い  血圧","vi" : "Huyết áp thấp lớn nhất"};
	 var minHighBloodPressure = {"en":"Min High blood pressure","ja" : "最小  高い  血圧","vi" : "Huyết áp cao nhỏ nhất"};
	 var maxHighBloodPressure = {"en":"Max High blood pressure","ja" : "最大  高い  血圧","vi" : "Huyết áp cao lớn nhất"};
	 var legendXaxis = setLabellegendXaxis(typeDuration,lang);
	 var average = 0;
	 var lastest = 0;
	 var url = varUrl;
	 var options = {
		    	title:{
		    	    text:''
		    		},
		    		tooltip: {
		    			  formatter: function() {
		    			    return  this.y
		    			  }
		    			},
		    	credits: {
		            enabled: false
		        },
		        chart: {
		            renderTo: varContainer,
		            type: 'scatter',
		            events: {
		                redraw: function() {

		                }
		            }
		        },
		        xAxis: {
		        	title: {
		                style: {
		                  fontWeight: 'bold'
		                },
		                text: legendXaxis
		              },
		              min : 0.5,
		              startOnTick: false,
		              endOnTick: false,
		              minPadding: 0,
		              maxPadding: 0,
		              align: "left"
		            },
		        yAxis: [{
		            lineWidth: 1,
		            opposite: false,
		            title: {
		                text: ''
		                        }
		        }],
		        series: [{name: minLowBloodPressure[lang],data:[null],marker: {
                    symbol: 'triangle-down',fillColor: '#3481d1'}},
                    {name: maxLowBloodPressure[lang],data:[null],marker: {
                    symbol: 'triangle',fillColor: '#3481d1'}},
                    {name: minHighBloodPressure[lang],data:[null],marker: {
                    symbol: 'triangle-down',fillColor: '#d9534f'}},
                    {name: maxHighBloodPressure[lang],data:[null],marker: {
                    symbol: 'triangle',fillColor: '#d9534f'}}]
		    };
	 $.ajax({
			url: url,
			type: 'GET',
			dataType: 'json',
			success: function(json) {
				if(type == '01')
					{
						var data = covertDataToSeriesBloodPressure(json,typeDuration,lang);
						var time = new Array();
						var dataMinLow = new Array();
						var dataMaxLow = new Array();
						var dataMinHigh = new Array();
						var dataMaxHigh = new Array();
						if(data.length > 0){
							for(var i = 0 ; i < data.length ; i++ )
								{
								time[i] = data[i][0];
								dataMinLow[i] = data[i][1];
								dataMaxLow[i] = data[i][2];
								dataMinHigh[i] = data[i][3];
								dataMaxHigh[i] = data[i][4];
								}
						}
						options.series[0].data = dataMinLow;
						options.series[1].data = dataMaxLow;
						options.series[2].data = dataMinHigh;
						options.series[3].data = dataMaxHigh;

						if(time.length == 1)
							{
							options.xAxis.min = 0;
							}
						options.xAxis.categories = time;
						// Calculate data from box summary
						minLow = getMinMaxAverageArray(dataMinLow)[0];
						maxLow = getMinMaxAverageArray(dataMaxLow)[1];
						averageLow = getMinMaxAverageArray(dataMinLow)[2] + " - " + getMinMaxAverageArray(dataMaxLow)[2];
						minHigh = getMinMaxAverageArray(dataMinHigh)[0];
						maxHigh = getMinMaxAverageArray(dataMaxHigh)[1];
						averageHigh = getMinMaxAverageArray(dataMinHigh)[2] + " - " + getMinMaxAverageArray(dataMaxHigh)[2];
						fillSummaryBloodPressure(averageLow,minLow,maxLow,'low');
						fillSummaryBloodPressure(averageHigh,minHigh,maxHigh,'high');
					}

	 			new Highcharts.Chart(options);

			},
	         error:function()
	         {
	        	 fillSummaryBloodPressure('0 - 0','0','0','low');
				fillSummaryBloodPressure('0 - 0','0','0','high');
	         }
		});
 }
//Draw chart for heartRate
 function bindDataHeartrateToChart(varUrl,varContainer,type,typeDuration,lang)
 {
	 var minPulse = {"ja":"最小  パルス","vi" : "Xung/phút nhỏ nhất","en" : "Min Pulse" };
	 var maxPulse = {"ja":"最大  パルス","vi" : "Xung/phút lớn nhất","en" : "Max Pulse" };
	 var legendXaxis = setLabellegendXaxis(typeDuration,lang);
	 var average = 0;
	 var lastest = 0;
	 var url = varUrl;
	 var options = {
		    	title:{
		    	    text:''
		    		},
		    		tooltip: {
		    			  formatter: function() {
		    			    return  this.y
		    			  }
		    			},
		    	credits: {
		            enabled: false
		        },
		        chart: {
		            renderTo: varContainer,
		            type: 'scatter',
		            events: {
		                redraw: function() {

		                }
		            }
		        },
		        xAxis: {
		        	title: {
		                style: {
		                  fontWeight: 'bold'
		                },
		                text: legendXaxis
		              },
		              min : 0.5,
		              startOnTick: false,
		              endOnTick: false,
		              minPadding: 0,
		              maxPadding: 0,
		              align: "left"
		            },
		        yAxis: [{
		            lineWidth: 1,
		            opposite: false,
		            title: {
		                text: ''
		                        }
		        }],
		        series: [{name: minPulse[lang],data:[null],marker: {
                    symbol: 'triangle-down',fillColor: '#3481d1'}},
                    {name: maxPulse[lang] ,data:[null],marker: {
                    symbol: 'triangle',fillColor: '#d9534f'}}]
		    };
	 $.ajax({
			url: url,
			type: 'GET',
			dataType: 'json',
			success: function(json) {
				if(type == '02')
					{
						var data = covertDataToSeriesHeartrate(json,typeDuration,lang);
						var time = new Array();
						var dataMinPulse = new Array();
						var dataMaxPulse = new Array();
						if(data.length > 0){
							for(var i = 0 ; i < data.length ; i++ )
								{
								time[i] = data[i][0];
								dataMinPulse[i] = data[i][1];
								dataMaxPulse[i] = data[i][2];
								}
						}
						options.series[0].data = dataMinPulse;
						options.series[1].data = dataMaxPulse;

						if(time.length == 1)
							{
							options.xAxis.min = 0;
							}
						options.xAxis.categories = time;
						min = getMinMaxAverageArray(dataMinPulse)[0];
						max = getMinMaxAverageArray(dataMaxPulse)[1];
						average = getMinMaxAverageArray(dataMinPulse)[2] + " - " + getMinMaxAverageArray(dataMaxPulse)[2];
						fillSummaryHeartRate(average,min,max);
					}
	 			new Highcharts.Chart(options);

			},
	         error:function()
	         {
	        	 fillSummary(parseFloat(average).toFixed(roundNum),parseFloat(lastest).toFixed(roundNum),0.00,0.00,type);
	         }
		});
 }


	 /**
	  * @summary Short description : function fill data caculate into area summary
	  * @since 18.8.06
	  * @access private
	  * @param type $average
	  * @param type $lastest
	  * @param type $type : type sleep
	  * @return void.
	  */

	function fillSummary(average,lastest,minData,maxData,type)
	{
		if(type == '03'){
				$('.list-summary.temperature').find('.average').text(average);
				$('.list-summary.temperature').find('.min').text(minData);
				$('.list-summary.temperature').find('.max').text(maxData);
				$('.list-summary.temperature').find('.lastest').text(lastest);
		}
		else if(type == '04')
			{
			console.log(average);
			$('.list-summary.respirationRate').find('.average').text(average);
			$('.list-summary.respirationRate').find('.min').text(minData);
			$('.list-summary.respirationRate').find('.max').text(maxData);
			$('.list-summary.respirationRate').find('.lastest').text(lastest);
			}
	}

	function fillSummaryBloodPressure(average,min,max,typeChart)
	{
		if(typeChart == 'low')
			{
			$('.list-summary.bloodPressure').find('.min.low').text(min);
			$('.list-summary.bloodPressure').find('.max.low').text(max);
			$('.list-summary.bloodPressure').find('.average.low').text(average);
			}
		else if(typeChart == 'high')
			{
			$('.list-summary.bloodPressure').find('.min.high').text(min);
			$('.list-summary.bloodPressure').find('.max.high').text(max);
			$('.list-summary.bloodPressure').find('.average.high').text(average);

			}
	}

	function fillSummaryHeartRate(average,min,max)
	{
		$('.list-summary.heartRate').find('.min').text(min);
		$('.list-summary.heartRate').find('.max').text(max);
		$('.list-summary.heartRate').find('.average').text(average);
	}

	//Convert du lieu tu API Respiration trả về theo định dạng array để vẽ đồ thị
	function covertDataToSeriesRespiration(dataInput,typeDuration,lang)
	{
		   var respiration = dataInput.content.respiration_rate_info;
		   var output = [];
		   if(respiration != null){
		   for(var i = 0; i < respiration.length; i++)
			   {
			       var tempX = convertDataUTCToLocalTime(respiration[i].datetime_record,typeDuration,lang);
			       var tempY = parseFloat(respiration[i].breath).toFixed(roundNum);
			       var tempXY = [tempX,parseFloat(tempY)];
			       output.push(tempXY);
			   }
		   }
		   return output;
	}
	//Convert du lieu tu API Temperature trả về theo định dạng array để vẽ đồ thị
	function covertDataToSeriesTemperature(dataInput,typeDuration,lang)
	{
		   var temperature = dataInput.content.temperature_info;
		   var output = [];
		   if(temperature != null){
		   for(var i = 0; i < temperature.length; i++)
			   {
			       var tempX = convertDataUTCToLocalTime(temperature[i].datetime_record,typeDuration,lang);
			       var tempY = parseFloat(temperature[i].temperature).toFixed(roundNum);
			       var tempXY = [tempX,parseFloat(tempY)];
			       output.push(tempXY);
			   }
		   }
		   return output;
	}

	//Convert du lieu tu API bloodPressure trả về theo định dạng array để vẽ đồ thị
	function covertDataToSeriesBloodPressure(dataInput,typeDuration,lang)
	{
		var bloodPress = dataInput.content.blood_pressure_info;
		var output = [];
		if(bloodPress != null)
			{
			for(var i = 0 ; i < bloodPress.length ; i++)
				{
				var dateTime = convertDataUTCToLocalTime(bloodPress[i].datetime_record,typeDuration,lang);
				var minLow = parseFloat(bloodPress[i].min_low_blood_pressure).toFixed(roundNum);
				var maxLow = parseFloat(bloodPress[i].max_low_blood_pressure).toFixed(roundNum);
				var minHigh = parseFloat(bloodPress[i].min_high_blood_pressure).toFixed(roundNum);
				var maxHigh = parseFloat(bloodPress[i].max_high_blood_pressure).toFixed(roundNum);
				output.push([dateTime,parseFloat(minLow),parseFloat(maxLow),parseFloat(minHigh),parseFloat(maxHigh)]);
				}
			}
		return output;
	}

	//Convert du lieu tu API heartRate trả về theo định dạng array để vẽ đồ thị
	function covertDataToSeriesHeartrate(dataInput,typeDuration,lang)
	{
		var heartRate = dataInput.content.heartrate_info;
		var output = [];
		if(heartRate != null)
			{
			for(var i = 0 ; i < heartRate.length ; i++)
				{
				var dateTime = convertDataUTCToLocalTime(heartRate[i].datetime_record,typeDuration,lang);
				var minPluse = parseFloat(heartRate[i].min_pulse).toFixed(roundNum);
				var maxPluse = parseFloat(heartRate[i].max_pulse).toFixed(roundNum);
				output.push([dateTime,parseFloat(minPluse),parseFloat(maxPluse)]);
				}
			}
		return output;
	}
