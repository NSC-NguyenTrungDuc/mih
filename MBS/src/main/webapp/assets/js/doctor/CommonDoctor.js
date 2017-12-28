/**
 * @author Le thanh tung Common function for doctor view
 */
var roundNum = 2;

Array.prototype.max = function() {
	  return Math.max.apply(null, this);
	};

Array.prototype.min = function() {
	  return Math.min.apply(null, this);
	};
// Ham chuyen doi thoi gian tu gio UTC ra gio local
function convertDataUTCToLocalTime(input,type,lang)
     {
		var mapMonth = {"en" : " Month ", "vi" : " Tháng " , "ja" : " 月 "};
       /*
		 * var mapMonthName = {"en" : {"1" : "Jan" , "2" : "Feb" , "3" : "Mar" ,
		 * "4" : "Apr" , "5" : "May" , "6" : "June", "7" : "Jul" , "8" : "Aug" ,
		 * "9" : "Sep" , "10" : "Oct" , "11" : "Nov" , "12" : "Dec" }, "ja" :
		 * {"1" : "一月" , "2" : "二月" , "3" : "三月" , "4" : "四月" , "5" : "五月" , "6" :
		 * "六月", "7" : "七月" , "8" : "八月" , "9" : "九月" , "10" : "十月" , "11" :
		 * "十一月" , "12" : "十二月" }, "vi" : {"1" : "Tháng 1" , "2" : "Tháng hai" ,
		 * "3" : "Tháng ba" , "4" : "Tháng bốn" , "5" : "Tháng năm" , "6" :
		 * "Tháng sáu", "7" : "Tháng bảy" , "8" : "Tháng tám" , "9" : "Tháng
		 * chín" , "10" : "Tháng mười" , "11" : "Tháng mười một" , "12" : "Tháng
		 * mười hai" }};
		 */
        var d = new Date();
        var currentMonth =  d.getMonth() + 1;
        var currentYear = d.getFullYear();
        var result;
        var  dateTimeGMT = (new Date(input)).getTime();
      // var dateLocal = new Date(dateTimeGMT).toLocaleDateString();
        var  dateLocal = new Date(dateTimeGMT);
        var  timeLocal = new Date(dateTimeGMT).toLocaleTimeString();
        if(type == '01')
        {
            result = dateLocal.getHours();
        }
        else if(type == '02')
        {
             temp = dateLocal.getMonth()+1;
			 result = dateLocal.getDate();
             if(temp != currentMonth)
                {
            	  if(lang == 'ja')
            		  result = temp + mapMonth[lang] + result;
            	  else
            		  result =  result + mapMonth[lang] + temp;
                }
        }
        else
        {
        	tempYear = dateLocal.getFullYear();
			result = dateLocal.getMonth()+1;
			if(tempYear != currentYear)
				{
				result = tempYear + "/" + result;
				}
        }
        return result;

     }
function convertUTCDateToLocalDate(date) {
	var newDate = new Date(date.getTime()+date.getTimezoneOffset()*60*1000);

	var offset = date.getTimezoneOffset() / 60;
	var hours = date.getHours();

	newDate.setHours(hours - offset);

	return newDate;
}
// Get duration type
 function getTypeDuration(inputText)
 {

	 var typeDuration = '00';
	    if(inputText=='Daily'){
	    	typeDuration = '01';

	    }
	    else if(inputText=='Weekly' || inputText=='Monthly')
	    	{
	    	typeDuration = '02';
	    	}
	    else if(inputText =='Yearly')
	    	{
	    	typeDuration = '03';
	    	}

	 return typeDuration;
 }

 // Ve do thi duong trung binh
 function drawAverage(chart)
 {

	 if(chart.series[1] != undefined)
		  chart.series[1].remove();
	  var tempSeries = chart.options.series[0].data;
	  var valuesSeries =  new Array();
	  var sum = 0;
	  for(var i = 0 ; i < tempSeries.length; i++)
		  {
		    sum = sum + tempSeries[i];
		  }
	  var dataCommon = [];
	  var length = tempSeries.length;
	  if(length > 0)
	  for(var j = 0 ; j < length ; j++)
		  {
		  var dataRound = parseFloat((sum/length).toFixed(roundNum));
		  dataCommon.push(dataRound);
		  }
	  chart.addSeries({data : dataCommon , showInLegend: false});

 }
 // Get min,max,lastest
 function getMinMaxLastest(chart)
 	{
	 var min = 0;
	 var max = 0;
	 var lastest = 0;
	 var dataSeries = chart.options.series[0].data;
	 var valuesSeries =  new Array();
	  for(var i = 0 ; i < dataSeries.length; i++)
	  {
	    valuesSeries.push(dataSeries[i]);
	  }
	  //min = valuesSeries.indexOf(Math.min(...valuesSeries));
	  //max = valuesSeries.indexOf(Math.max(...valuesSeries));
	  min =  valuesSeries.indexOf(valuesSeries.min());
	  max =  valuesSeries.indexOf(valuesSeries.max());
	  lastest = dataSeries.length - 1;
	  return [min,max,lastest];
 	}


 // Fill tooltip chart
 function fillTooltipEvent(chart,label)
 {
	    var data = chart.series[0].data;
	 	if(data.length > 0)
	 	{
		    if(label == 'min'){
			    chart.series[0].data[getMinMaxLastest(chart)[0]].setState('hover');
			    chart.tooltip.refresh(chart.series[0].data[getMinMaxLastest(chart)[0]]);
		    }
		    else if(label == 'max' )
		    	{
		    	chart.series[0].data[getMinMaxLastest(chart)[1]].setState('hover');
			    chart.tooltip.refresh(chart.series[0].data[getMinMaxLastest(chart)[1]]);
		    	}
		    else if(label == 'lastest')
		    	{
		    	chart.series[0].data[getMinMaxLastest(chart)[2]].setState('hover');
			    chart.tooltip.refresh(chart.series[0].data[getMinMaxLastest(chart)[2]]);
		    	}
	 	}
 }

 function drawInitChart(data)
 {
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
		options.xAxis.categories = time;
 }
function setLabellegendXaxis(typeDuration,lang)
{
  var legendXaxis = 'Hour';
  if(typeDuration == '01'){
        if (lang == "en"){
        legendXaxis = 'Time';
        }
        else if (lang == "vi")
        {
        legendXaxis = "giờ"
        }
        else {
        legendXaxis = "時間";
        }
    }
  else if(typeDuration == '02')
    {
        if (lang == "en"){
        legendXaxis = 'Day';
        }
        else if (lang == "vi")
        {
        legendXaxis = "Ngày"
        }
        else {
          legendXaxis = "日";
        }
    }
  else if(typeDuration == '03')
  {
      if (lang == "en"){
        legendXaxis = 'Month';
      }
      else if (lang == "vi")
      {
      legendXaxis = "Tháng"
      }
      else {
      legendXaxis = "月";
      }
  }
  return legendXaxis;
}
function getMinMaxAverageArray(arrayInput)
{
  var output = [];
  var min = 0;
  var max = 0;
  var average = 0;
  var length = arrayInput.length;
  if(length > 0)
	  {
	  var sum = 0;
	  for(var i = 0 ; i < length ; i++)
		  {
		  sum = sum + arrayInput[i];
		  }
	  average = parseFloat((sum/length).toFixed(roundNum))
	  min =  arrayInput.min();
	  max =  arrayInput.max();
	  }
  return [min,max,average];
}



