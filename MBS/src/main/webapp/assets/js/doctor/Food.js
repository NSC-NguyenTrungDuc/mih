/**
 * @author Le thanh tung
 *  Function relate module fitness
 */

/**
 * @summary Short description : function relate module Food
 * @since 18.8.06
 * @access private
 * @param type $varUrl : url request from server
 * @param type $varContainer : area data fillup from server
 * @param type $type : type fitness
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
					var data = covertDataToCalories(json,typeDuration,lang);
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
			else if(type == '02')
				{
					var data = covertDataToCarbohydrate(json,typeDuration,lang);
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
			else if(type == '03')
				{
					var data = covertDataToTotalFat(json,typeDuration,lang);
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
 			$('.chart-action.calories').find('.min').click(function() {
 		 			var chart = $('#container1').highcharts();
 		 			fillTooltipEvent(chart,'min');
 			    });
 			$('.chart-action.calories').find('.max').click(function() {
		 			var chart = $('#container1').highcharts();
		 			fillTooltipEvent(chart,'max');
			    });
 			$('.chart-action.calories').find('.lastest').click(function() {
		 			var chart = $('#container1').highcharts();
		 			fillTooltipEvent(chart,'lastest');
			    });
 			$('.chart-action.carbohydrate').find('.min').click(function() {
		 			var chart = $('#container2').highcharts();
		 			fillTooltipEvent(chart,'min');
			    });
			$('.chart-action.carbohydrate').find('.max').click(function() {
	 			var chart = $('#container2').highcharts();
	 			fillTooltipEvent(chart,'max');
		    });
			$('.chart-action.carbohydrate').find('.lastest').click(function() {
	 			var chart = $('#container2').highcharts();
	 			fillTooltipEvent(chart,'lastest');
		    });
			$('.chart-action.totalfat').find('.min').click(function() {
	 			var chart = $('#container3').highcharts();
	 			fillTooltipEvent(chart,'min');
		    });
			$('.chart-action.totalfat').find('.max').click(function() {
	 			var chart = $('#container3').highcharts();
	 			fillTooltipEvent(chart,'max');
		    });
			$('.chart-action.totalfat').find('.lastest').click(function() {
	 			var chart = $('#container3').highcharts();
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
  * @param type $type : type fitness
  * @return void.
  */

function fillSummary(average,lastest,minData,maxData,type)
{
	if(type == '01'){
			$('.list-summary.calories').find('.average').text(average);
			$('.list-summary.calories').find('.min').text(minData);
			$('.list-summary.calories').find('.max').text(maxData);
			$('.list-summary.calories').find('.lastest').text(lastest);
	}
	else if(type == '02')
	{
		    $('.list-summary.carbohydrate').find('.average').text(average);
		    $('.list-summary.carbohydrate').find('.min').text(minData);
			$('.list-summary.carbohydrate').find('.max').text(maxData);
		    $('.list-summary.carbohydrate').find('.lastest').text(lastest);
	}
	else if(type == '03')
	{
		    $('.list-summary.totalfat').find('.average').text(average);
		    $('.list-summary.totalfat').find('.min').text(minData);
			$('.list-summary.totalfat').find('.max').text(maxData);
		    $('.list-summary.totalfat').find('.lastest').text(lastest);
	}
}

function covertDataToCalories(dataInput,typeDuration,lang)
{
   var calories_info = dataInput.content.calories_info;
   var output = [];
   if(calories_info != null){
   for(var i = 0; i < calories_info.length; i++)
     {
         var tempX = convertDataUTCToLocalTime(calories_info[i].eating_time,typeDuration,lang);
         var tempY = parseFloat(calories_info[i].calories).toFixed(roundNum);
         var tempXY = [tempX,parseFloat(tempY)];
         output.push(tempXY);
     }
   }
   return output;
}


 function covertDataToCarbohydrate(dataInput,typeDuration,lang)
 {
    var carbohydrate_info = dataInput.content.carbohydrate_info;
    var output = [];
    if(carbohydrate_info != null){
    for(var i = 0; i < carbohydrate_info.length; i++)
      {

          var tempX = convertDataUTCToLocalTime(carbohydrate_info[i].eating_time,typeDuration,lang);
          var tempY = parseFloat(carbohydrate_info[i].carbohydrate).toFixed(roundNum);
          var tempXY = [tempX,parseFloat(tempY)];
          output.push(tempXY);
      }
    }
    return output;
 }

 function covertDataToTotalFat(dataInput,typeDuration,lang)
 {
    var total_fat_info = dataInput.content.total_fat_info;
    var output = [];
    if(total_fat_info != null){
    for(var i = 0; i < total_fat_info.length; i++)
	    {

	        var tempX = convertDataUTCToLocalTime(total_fat_info[i].eating_time,typeDuration,lang);
	        var tempY = parseFloat(total_fat_info[i].total_fat).toFixed(roundNum);
	        var tempXY = [tempX,parseFloat(tempY)];
	        output.push(tempXY);
	    }
    }
    return output;
 }
