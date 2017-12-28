function changeDimension(width, height){
    $('#container').height(height);
    // window.location = "phr-js-log:" + height;
    // $(window).resize();
}

/*
 content =     (
 {
 "doctor_note" = "<null>";
 "head_size" = "<null>";
 height = 120;
 id = 33;
 "medical_record_url" = "<null>";
 "parent_note" = "<null>";
 "profile_id" = 197;
 "time_measure" = "2015-11-19T09:24:44Z";
 weight = 20;
 });
 message = "message.success";
 status = SUCCESS;
 
 */

/*
 [
 [Date.UTC(1970, 9, 21), 0],
 [Date.UTC(1970, 10, 4), 0.28],
 [Date.UTC(1970, 10, 9), 0.25]
 ]
 */


function drawGraph(base64Data) {
    var data = Base64.decode(base64Data);
    var json = JSON.parse(data);
    var arrayGrowth = json['content'];
    var arrayWeight = [];
    var arrayHeight = [];
    for(i = 0; i < arrayGrowth.length; i++){
        var growth = arrayGrowth[i];
        // get time
        var s = growth['time_measure'];
        var a = s.split(/[^0-9]/);
        var time_measure = Date.UTC(a[0],a[1] - 1,a[2],a[3],a[4],a[5]);
        // WEIGHT
        arrayWeight.push([time_measure, growth['weight']]);
        // HEIGHT
        arrayHeight.push([time_measure, growth['height']]);
    };
    
    $('#container').highcharts({
                               chart: {
                               zoomType: 'xy',
                               backgroundColor: 'rgba(255, 255, 255, 0)',
                               },
                               title: {
                               text: ''
                               },
                               subtitle: {
                               text: ''
                               },
                               xAxis: [{
                                       type: 'datetime',
                                       dateTimeLabelFormats: { // don't display the dummy year
                                       month: '%e. %b',
                                       year: '%b'
                                       },
                                       }],
                               yAxis: [
                                       {
                                       // Primary yAxis
                                       labels: {
                                       format: 'kg',
                                       style: {
                                       color: Highcharts.getOptions().colors[2]
                                       }
                                       },
                                       title: {
                                       text: 'weight',
                                       style: {
                                       color: Highcharts.getOptions().colors[2]
                                       }
                                       },
                                       opposite: true
                                       },
                                       {
                                       // Tertiary yAxis
                                       gridLineWidth: 0,
                                       title: {
                                       text: 'height',
                                       style: {
                                       color: Highcharts.getOptions().colors[1]
                                       }
                                       },
                                       labels: {
                                       format: 'cm',
                                       style: {
                                       color: Highcharts.getOptions().colors[1]
                                       }
                                       },
                                       opposite: false
                                       }],
                               tooltip: {
                               shared: false
                               },
                               legend: {
                               enabled: false,
                               layout: 'vertical',
                               align: 'left',
                               x: 80,
                               verticalAlign: 'top',
                               y: 0,
                               floating: true,
                               backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'
                               },
                               series: [
                                        {
                                        name: 'Weights',
                                        type: 'spline',
                                        yAxis: 1,
                                        data: [],
                                        marker: {
                                        enabled: false
                                        },
                                        dashStyle: 'shortdot',
                                        tooltip: {
                                        valueSuffix: 'kg'
                                        }
                                        },
                                        {
                                        name: 'Heights',
                                        type: 'spline',
                                        yAxis: 0,
                                        data: [],
                                        tooltip: {
                                        valueSuffix: 'cm'
                                        }
                                        }],
                               exporting:{
                               enabled: false
                               },
                               credits: {
                               enabled: false
                               },
                               legend:{
                               enabled: false
                               }
                               });
};