/**
 * @author Le thanh tung
 *  Function relate module body measurement
 */

/**
 * @summary Short description : function relate module Body measurement
 * @since 18.8.06
 * @access private
 * @param type $varUrl : url request from server
 * @param type $varContainer : area data fillup from server
 * @param type $type : type body measurement
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
					var data = covertDataToSeriesHeight(json,typeDuration,lang);
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
					var data = covertDataToSeriesWeight(json,typeDuration,lang);
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
					var data = covertDataToSeriesBodyFat(json,typeDuration,lang);
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
				var data = covertDataToSeriesBodyMass(json,typeDuration,lang);
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
 			$('.chart-action.height').find('.min').click(function() {
 		 			var chart = $('#container1').highcharts();
 		 			fillTooltipEvent(chart,'min');
 			    });
 			$('.chart-action.height').find('.max').click(function() {
		 			var chart = $('#container1').highcharts();
		 			fillTooltipEvent(chart,'max');
			    });
 			$('.chart-action.height').find('.lastest').click(function() {
		 			var chart = $('#container1').highcharts();
		 			fillTooltipEvent(chart,'lastest');
			    });
 			$('.chart-action.weight').find('.min').click(function() {
		 			var chart = $('#container2').highcharts();
		 			fillTooltipEvent(chart,'min');
			    });
			$('.chart-action.weight').find('.max').click(function() {
	 			var chart = $('#container2').highcharts();
	 			fillTooltipEvent(chart,'max');
		    });
			$('.chart-action.weight').find('.lastest').click(function() {
	 			var chart = $('#container2').highcharts();
	 			fillTooltipEvent(chart,'lastest');
		    });
			$('.chart-action.bodyfat').find('.min').click(function() {
	 			var chart = $('#container4').highcharts();
	 			fillTooltipEvent(chart,'min');
		    });
			$('.chart-action.bodyfat').find('.max').click(function() {
 			var chart = $('#container4').highcharts();
 			fillTooltipEvent(chart,'max');
		    });
			$('.chart-action.bodyfat').find('.lastest').click(function() {
	 			var chart = $('#container4').highcharts();
	 			fillTooltipEvent(chart,'lastest');
		    });
			$('.chart-action.bodymass').find('.min').click(function() {
	 			var chart = $('#container3').highcharts();
	 			fillTooltipEvent(chart,'min');
		    });
			$('.chart-action.bodymass').find('.max').click(function() {
 			var chart = $('#container3').highcharts();
 			fillTooltipEvent(chart,'max');
		    });
			$('.chart-action.bodymass').find('.lastest').click(function() {
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
			$('.list-summary.height').find('.average').text(average);
			$('.list-summary.height').find('.min').text(minData);
			$('.list-summary.height').find('.max').text(maxData);
			$('.list-summary.height').find('.lastest').text(lastest);
	}
	else if(type == '02')
	{
		    $('.list-summary.weight').find('.average').text(average);
		    $('.list-summary.weight').find('.min').text(minData);
			$('.list-summary.weight').find('.max').text(maxData);
		    $('.list-summary.weight').find('.lastest').text(lastest);
	}
	else if(type == '04')
	{
			$('.list-summary.bodyfat').find('.average').text(average);
		    $('.list-summary.bodyfat').find('.min').text(minData);
			$('.list-summary.bodyfat').find('.max').text(maxData);
		    $('.list-summary.bodyfat').find('.lastest').text(lastest);
	}
	else if(type == '03')
	{
			$('.list-summary.bodymass').find('.average').text(average);
		    $('.list-summary.bodymass').find('.min').text(minData);
			$('.list-summary.bodymass').find('.max').text(maxData);
		    $('.list-summary.bodymass').find('.lastest').text(lastest);
	}
}


function covertDataToSeriesHeight(dataInput,typeDuration,lang)
     {
        var step_count_info = dataInput.content.height_info;
        var output = [];
        if(step_count_info != null){
        for(var i = 0; i < step_count_info.length; i++)
        {
            var tempX = convertDataUTCToLocalTime(step_count_info[i].datetime_record,typeDuration,lang);
            var tempY = parseFloat(step_count_info[i].height).toFixed(roundNum);
            var tempXY = [tempX,parseFloat(tempY)];
            output.push(tempXY);
        }
        }
      /*  output.sort(function(a, b){
            return a[0]-b[0];
        })*/
        return output;
     }
 function covertDataToSeriesWeight(dataInput,typeDuration,lang)
 {
    var step_count_info = dataInput.content.weight_info;
          console.log(step_count_info);
    var output = [];
    if(step_count_info != null){
    for(var i = 0; i < step_count_info.length; i++)
      {
          var tempX = convertDataUTCToLocalTime(step_count_info[i].datetime_record,typeDuration,lang);
          var tempY = parseFloat(step_count_info[i].weight).toFixed(roundNum);
          var tempXY = [tempX,parseFloat(tempY)];

          output.push(tempXY);
      }
    }
    return output;
 }
 function covertDataToSeriesBodyFat(dataInput,typeDuration,lang)
 {
    var step_count_info = dataInput.content.perc_fat_info;
    var output = [];
    if(step_count_info != null){
    for(var i = 0; i < step_count_info.length; i++)
      {
          var tempX = convertDataUTCToLocalTime(step_count_info[i].datetime_record,typeDuration,lang);
          var tempY = parseFloat(step_count_info[i].perc_fat).toFixed(roundNum);
          var tempXY = [tempX,parseFloat(tempY)];
          output.push(tempXY);
      }
    }
    return output;
 }

 function covertDataToSeriesBodyMass(dataInput,typeDuration,lang)
 {
    var step_count_info = dataInput.content.bmi_info;
    var output = [];
    if(step_count_info != null){
      for(var i = 0; i < step_count_info.length; i++)
      {
          var tempX = convertDataUTCToLocalTime(step_count_info[i].datetime_record,typeDuration,lang);
          var tempY = parseFloat(step_count_info[i].bmi).toFixed(roundNum);
          var tempXY = [tempX,parseFloat(tempY)];
          output.push(tempXY);
      }
    }

    return output;
 }
