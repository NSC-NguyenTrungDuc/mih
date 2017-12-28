//
//  BodyMeasurementChart.m
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BodyMeasurementChart.h"

@implementation BodyMeasurementChart {
    float maxLineYAxis;
    float average;
    NSString *chartUnit;
    NSString *chartTitle;
    UIColor *lineChartColor;
    UIColor *fillBalloonColor;
    BOOL isShowGradient;
    BOOL isShowValueLimitLine;
}

- (void)doCustomize{
    [self setLeftAxisEnable:NO rightAxisEnable:YES];
    [self setLeftAxisDrawGrid:NO rightAxisDrawGrid:NO];
    [self setRightAxisMin:0 max:100];
    [self setXAxisLineColor:[UIColor whiteColor]];
    self.arrayChartBackgroundColor = @[[UIColor colorWithRed:175./255. green:159./255. blue:89./255. alpha:1],
                                       [UIColor colorWithRed:140./255. green:191./255. blue:153./255. alpha:1],
                                       [UIColor colorWithRed:170./255. green:143./255. blue:208./255. alpha:1],
                                       [UIColor colorWithRed:178/255. green:149/255. blue:49/255. alpha:1]
                                       ];
    if (self.chartContentType == ChartContentTypeHeight) {
        chartUnit = kLocalizedString(kUnitCm);
        chartTitle = kLocalizedString(kPHHeight);
        self.backgroundColor = [self.arrayChartBackgroundColor objectAtIndex:0];
    }
    if (self.chartContentType == ChartContentTypeWeight) {
         chartUnit = kLocalizedString(kUnitKg);
        chartTitle = kLocalizedString(kPHWeight);
        self.backgroundColor = [self.arrayChartBackgroundColor objectAtIndex:1];
    }
    if (self.chartContentType == ChartContentTypeBodyFat) {
         chartUnit = kLocalizedString(kUnitPercent);
        chartTitle = kLocalizedString(kBodyFatPercentage);
        self.backgroundColor = [self.arrayChartBackgroundColor objectAtIndex:2];
    }
    if (self.chartContentType == ChartContentTypeBMI) {
        chartUnit = kLocalizedString(kUnitKgM);
        chartTitle = kLocalizedString(kBMI);
        self.backgroundColor = [self.arrayChartBackgroundColor objectAtIndex:3];
    }

    [self setMarker];
}

- (void)setChartTitle:(NSString*)title {
    chartTitle = title;
}

- (void)setLineChartColor:(UIColor*)color {
    lineChartColor = color;
}

- (void)setIsShowGradient:(BOOL)isShow {
    isShowGradient = isShow;
}

- (void)setFillBalloonColor:(UIColor*)color {
    fillBalloonColor = color;
}

- (void)setIsShowValueLimitLine:(BOOL)isShowValue {
    isShowValueLimitLine = isShowValue;
}

- (void)setMarker{
    BalloonMarker *marker = [[BalloonMarker alloc] initWithColor:lineChartColor fillColor:fillBalloonColor font:[UIFont systemFontOfSize:9.0] insets: UIEdgeInsetsMake(2.0, 2.0, 5.0, 2.0)];
    marker.minimumSize = CGSizeMake(25.0, 15.0);
    self.chartView.marker = marker;
}

- (void)updateChartData {
    [super updateChartData];
    [self processData];
    [self.chartView animateWithXAxisDuration:1.5 easingOption:ChartEasingOptionEaseInOutQuart];
}

- (void)calculateMinMax {
    self.minAxisValue = 0;
    self.maxAxisValue = 0;
    
    average = 0;
    // HEIGHT
    if (self.chartContentType == ChartContentTypeHeight) {
        if (self.arrayAllData.count > 0) {
            for (BodyMeasurementModel *obj in self.arrayAllData){
                if (self.maxAxisValue < [obj.height floatValue]) {
                    self.maxAxisValue = [obj.height floatValue];
                    maxLineYAxis= self.maxAxisValue;
                }
                if (self.minAxisValue > [obj.height floatValue]) {
                    self.minAxisValue = [obj.height floatValue];
                }
                average += [obj.height floatValue];
            }
            average /= self.arrayAllData.count;
        }
    }
    // WEIGHT
    if (self.chartContentType == ChartContentTypeWeight) {
        if (self.arrayAllData.count > 0) {
            for (BodyMeasurementModel *obj in self.arrayAllData){
                if (self.maxAxisValue < [obj.weight floatValue]) {
                    self.maxAxisValue = [obj.weight floatValue];
                    maxLineYAxis= self.maxAxisValue;
                }
                if (self.minAxisValue > [obj.weight floatValue]) {
                    self.minAxisValue = [obj.weight floatValue];
                }
                average += [obj.weight floatValue];
            }
            average /= self.arrayAllData.count;
        }
    }
    // BODY FAT
    if (self.chartContentType == ChartContentTypeBodyFat) {
        if (self.arrayAllData.count > 0) {
            for (BodyMeasurementModel *obj in self.arrayAllData){
                if (self.maxAxisValue < [obj.percentFat floatValue]) {
                    self.maxAxisValue = [obj.percentFat floatValue];
                    maxLineYAxis= self.maxAxisValue;
                }
                if (self.minAxisValue > [obj.percentFat floatValue]) {
                    self.minAxisValue = [obj.percentFat floatValue];
                }
                average += [obj.percentFat floatValue];
            }
            average /= self.arrayAllData.count;
         
        }
    }
    // BMI
    if (self.chartContentType == ChartContentTypeBMI) {
        if (self.arrayAllData.count > 0) {
            for (BodyMeasurementModel *obj in self.arrayAllData){
                if (self.maxAxisValue < [obj.bmi floatValue]) {
                    self.maxAxisValue = [obj.bmi floatValue];
                    maxLineYAxis= self.maxAxisValue;
                }
                if (self.minAxisValue > [obj.bmi floatValue]) {
                    self.minAxisValue = [obj.bmi floatValue];
                }
                average += [obj.bmi floatValue];
            }
            average /= self.arrayAllData.count;
        }
    }
    self.minAxisValue = self.minAxisValue * 0.75;
//    if (self.minAxisValue < 0) {self.minAxisValue = 0;}
    self.maxAxisValue = self.maxAxisValue * 1.25;
}

- (void)processData {
    LineChartDataSet *set1 = [LineChartDataSet new];
    LineChartDataSet *setSMA1 = nil;
    NSMutableArray *yVals = [[NSMutableArray alloc] init];
    
    [self calculateMinMax];
    if (self.arrayAllData.count > 0) {
        [self setRightAxisMin:self.minAxisValue max:self.maxAxisValue];
    } else {
        [self setRightAxisMin:0 max:100];
    }
    NSDate  *dateTime;
    // HEIGHT
    if (self.chartContentType == ChartContentTypeHeight) {
        if (self.arrayAllData.count > 0) {
            for (BodyMeasurementModel *obj in self.arrayAllData) {
                dateTime = [UIUtils dateFromServerTimeString:obj.date];
                if(dateTime != nil)
                    [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"MM/dd"]];
            }
            
            for (int i = 0; i < self.arrayAllData.count ; i++) {
                BodyMeasurementModel *obj = (BodyMeasurementModel*) self.arrayAllData[i];
                ChartDataEntry *chartData = [[ChartDataEntry alloc] initWithValue:[obj.height floatValue] xIndex:i];
                [self.arrayYData addObject:chartData];
            }
        }
    }
    // WEIGHT
    if (self.chartContentType == ChartContentTypeWeight) {
        if (self.arrayAllData.count > 0) {
            for (BodyMeasurementModel *obj in self.arrayAllData) {
                dateTime = [UIUtils dateFromServerTimeString:obj.date];
                if(dateTime != nil)
                    [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"MM/dd"]];
            }
            
            for (int i = 0; i < self.arrayAllData.count ; i++) {
                BodyMeasurementModel *obj = (BodyMeasurementModel*) self.arrayAllData[i];
                ChartDataEntry *chartData = [[ChartDataEntry alloc] initWithValue:[obj.weight floatValue] xIndex:i];
                [self.arrayYData addObject:chartData];
            }
        }
    }
    // BODY FAT
    if (self.chartContentType == ChartContentTypeBodyFat) {
        if (self.arrayAllData.count > 0) {
            for (BodyMeasurementModel *obj in self.arrayAllData) {
                dateTime = [UIUtils dateFromServerTimeString:obj.date];
                if(dateTime != nil)
                    [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"MM/dd"]];
            }
            
            for (int i = 0; i < self.arrayAllData.count ; i++) {
                BodyMeasurementModel *obj = (BodyMeasurementModel*) self.arrayAllData[i];
                ChartDataEntry *chartData = [[ChartDataEntry alloc] initWithValue:[obj.percentFat floatValue] xIndex:i];
                [self.arrayYData addObject:chartData];
            }
        }
    }
    // BMI
    if (self.chartContentType == ChartContentTypeBMI) {
        if (self.arrayAllData.count > 0) {
            for (BodyMeasurementModel *obj in self.arrayAllData) {
                dateTime = [UIUtils dateFromServerTimeString:obj.date];
                if(dateTime != nil)
                    [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"MM/dd"]];
            }
            
            for (int i = 0; i < self.arrayAllData.count ; i++) {
                BodyMeasurementModel *obj = (BodyMeasurementModel*) self.arrayAllData[i];
                ChartDataEntry *chartData = [[ChartDataEntry alloc] initWithValue:[obj.bmi floatValue] xIndex:i];
                [self.arrayYData addObject:chartData];
            }
        }
    }

    [self addLimitLine];
    setSMA1 = [self drawSMA];
    
    if (self.chartView.data.dataSetCount > 0)
    {
        set1 = (LineChartDataSet *)self.chartView.data.dataSets[0];
        set1._yVals = self.arrayYData;
        
        self.chartView.data.xValsObjc = self.arrayXData;
        [self.chartView notifyDataSetChanged];
    } else {
        set1 = [[LineChartDataSet alloc] initWithYVals:self.arrayYData label:nil];
        [set1 setColor:lineChartColor];
        [set1 setCircleColor:[UIColor clearColor]];
        set1.lineWidth = 1.;
        set1.circleRadius = .0;
        set1.drawCircleHoleEnabled = YES;
        set1.circleHoleColor = lineChartColor;
        set1.circleHoleRadius = 4.0;
        set1.valueFont = [UIFont systemFontOfSize:9.f];
        set1.drawValuesEnabled = NO;
        set1.drawHorizontalHighlightIndicatorEnabled = NO;
        set1.axisDependency = AxisDependencyRight;
        set1.drawVerticalHighlightIndicatorEnabled = NO;
        if(isShowGradient) {
            NSArray *gradientColors = @[
                                        (id)[ChartColorTemplates colorFromString:@"#00FFFFFF"].CGColor,
                                        (id)[ChartColorTemplates colorFromString:@"#99FFFFFF"].CGColor
                                        ];
            CGGradientRef gradient = CGGradientCreateWithColors(nil, (CFArrayRef)gradientColors, nil);
            
            set1.fillAlpha = 1.0f;
            set1.fill = [ChartFill fillWithLinearGradient:gradient angle:90.f];
            set1.drawFilledEnabled = YES;
            
            CGGradientRelease(gradient);
        }
        
        [yVals addObject:set1];
        
        //Add data set
        [yVals addObject:setSMA1];
        
        LineChartData *data = [[LineChartData alloc] initWithXVals:self.arrayXData dataSets:yVals];
        self.chartView.data = data;
    }
}

- (void)addLimitLine {
    if(!isShowValueLimitLine) {
        if(self.arrayAllData.count == 0){
            maxLineYAxis = 80;
        }
        //Middle line
        [self addLimitLineOnRightAxisWithoutText:(CGFloat)((maxLineYAxis + self.minAxisValue) / 2) lineWidth:self.limitLineWidth * 2.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor]];
        //Add top left line
        [self addLimitLineOnRightAxis:maxLineYAxis * 1.1f lineWidth:self.limitLineWidth * 2.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor] andText:chartTitle andFont:[FontUtils montserratRegularWithSize:12.0]];
        //Add top right line
        if (self.showAvarage) {
        [self addLimitLineOnRightAxis:maxLineYAxis * 1.1f lineWidth:self.limitLineWidth * 2.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor] andText:[NSString stringWithFormat:@"%@ %0.0f %@",kLocalizedString(kTitleAverage),average, chartUnit] withFont:[FontUtils montserratRegularWithSize:8.0] andTextDirection:ChartLimitLabelPositionRightTop];
        }
    } else {
        //Middle line
        [self addLimitLineOnRightAxis:(CGFloat)((maxLineYAxis + self.minAxisValue) / 2) lineWidth:1.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor]];
        //Add top left line
        [self addLimitLineOnRightAxis:maxLineYAxis lineWidth:1.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor] andText:chartTitle andFont:[FontUtils montserratRegularWithSize:12.0]];
        //Add top right line
        [self addLimitLineOnRightAxis:maxLineYAxis lineWidth:1.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor] andText:@"Average: 1200" withFont:[FontUtils montserratRegularWithSize:8.0] andTextDirection:ChartLimitLabelPositionRightTop];
        [self addLimitLineOnRightAxis:maxLineYAxis lineWidth:1.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor] andText:[NSString stringWithFormat:@"%d",(int)maxLineYAxis] withFont:[FontUtils montserratRegularWithSize:8.0] andTextDirection:ChartLimitLabelPositionRightBottom];
        [self addLimitLineOnRightAxis:self.minAxisValue lineWidth:1.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor] andText:[NSString stringWithFormat:@"%d",(int)self.minAxisValue] withFont:[FontUtils montserratRegularWithSize:8.0] andTextDirection:ChartLimitLabelPositionRightTop];
    }
}

- (void)chartValueSelected:(ChartViewBase * __nonnull)chartView entry:(ChartDataEntry * __nonnull)entry dataSetIndex:(NSInteger)dataSetIndex highlight:(ChartHighlight * __nonnull)highlight
{
    NSLog(@"chartValueSelected");
}

- (void)chartValueNothingSelected:(ChartViewBase * __nonnull)chartView
{
    NSLog(@"chartValueNothingSelected");
}


/*
 // Only override drawRect: if you perform custom drawing.
 // An empty implementation adversely affects performance during animation.
 - (void)drawRect:(CGRect)rect {
 // Drawing code
 }
 */

@end
