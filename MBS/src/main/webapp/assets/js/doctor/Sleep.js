/**
 * @author Le thanh tung
 *  Function relate module sleep
 */

/**
 * @summary Short description : function relate module Sleep
 * @since 18.8.06
 * @access private
 * @param type $varUrl : url request from server
 * @param type $varContainer : area data fillup from server
 * @param type $type : type sleep
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
			if(type == '01')
				{
					var data = covertDataToSeriesSleep(json,typeDuration,lang);
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
 			$('.chart-action.sleep').find('.min').click(function() {
 		 			var chart = $('#container1').highcharts();
 		 			fillTooltipEvent(chart,'min');
 			    });
 			$('.chart-action.sleep').find('.max').click(function() {
		 			var chart = $('#container1').highcharts();
		 			fillTooltipEvent(chart,'max');
			    });
 			$('.chart-action.sleep').find('.lastest').click(function() {
		 			var chart = $('#container1').highcharts();
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
	if(type == '01'){
			$('.list-summary.sleep').find('.average').text(average);
			$('.list-summary.sleep').find('.min').text(minData);
			$('.list-summary.sleep').find('.max').text(maxData);
			$('.list-summary.sleep').find('.lastest').text(lastest);
	}
}

function covertDataToSeriesSleep(dataInput,typeDuration,lang)
{
	   var sleep_info = dataInput.content;
	   var output = [];
	   if(sleep_info != null){
	   for(var i = 0; i < sleep_info.length; i++)
	   {
	       var tempX = convertDataUTCToLocalTime(sleep_info[i].time_start_sleep,typeDuration,lang);
	       var tempY = parseFloat((sleep_info[i].total_hour_sleep/3600)).toFixed(roundNum);
	       var tempXY = [tempX,parseFloat(tempY)];
	       output.push(tempXY);
	   }
	   }
	   return output;
}
