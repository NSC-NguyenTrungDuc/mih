//
//  PHRFitnessChart.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/17/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRFitnessChart.h"

@implementation PHRFitnessChart{
    float average;
    float maxLineYAxis;
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
    self.arrayChartBackgroundColor = @[[UIColor colorWithRed:137./255. green:187./255. blue:88./255. alpha:1],
                                       [UIColor colorWithRed:55./255. green:156./255. blue:210./255. alpha:1]];
    if (self.chartContentType == ChartFitnessTypeSteps) {
        chartUnit = kLocalizedString(kSteps);
        chartTitle = kLocalizedString(kChartStepCount);
        self.backgroundColor = [self.arrayChartBackgroundColor objectAtIndex:self.chartContentType];
    } else if (self.chartContentType == ChartFitnessTypeWalkRun) {
        chartUnit = kLocalizedString(kUnitKm);
        chartTitle = kLocalizedString(kChartWalkingRunDistance);
        self.backgroundColor = [self.arrayChartBackgroundColor objectAtIndex:self.chartContentType];
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

- (void)setChartUnit:(NSString*)unit {
    chartUnit = unit;
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
    
    if (self.chartContentType == ChartFitnessTypeSteps) {
        if (self.arrayAllData.count > 0) {
            for (FitnessModel *obj in self.arrayAllData){
                if (self.maxAxisValue < [obj.step floatValue]) {
                    self.maxAxisValue = [obj.step floatValue];
                    maxLineYAxis= self.maxAxisValue;
                }
                if (self.minAxisValue > [obj.step floatValue]) {
                    self.minAxisValue = [obj.step floatValue];
                }
                average += [obj.step floatValue];
            }
            average /= self.arrayAllData.count;
        }
    } else if (self.chartContentType == ChartFitnessTypeWalkRun) {
        if (self.arrayAllData.count > 0) {
            for (FitnessModel *obj in self.arrayAllData){
                if (self.maxAxisValue < [obj.walkrun floatValue]) {
                    self.maxAxisValue = [obj.walkrun floatValue];
                    maxLineYAxis= self.maxAxisValue;
                }
                if (self.minAxisValue > [obj.walkrun floatValue]) {
                    self.minAxisValue = [obj.walkrun floatValue];
                }
                average += [obj.walkrun floatValue];
            }
            average /= self.arrayAllData.count;
        }
    }
    
    self.minAxisValue = self.minAxisValue * 0.75;
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
    if (self.chartContentType == ChartFitnessTypeSteps) {
        if (self.arrayAllData.count > 0) {
            for (FitnessModel *obj in self.arrayAllData) {
                dateTime = [UIUtils dateFromServerTimeString:obj.date];
                if(dateTime != nil)
                    [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"MM/dd"]];
            }
            
            for (int i = 0; i < self.arrayAllData.count ; i++) {
                FitnessModel *obj = (FitnessModel*) self.arrayAllData[i];
                ChartDataEntry *chartData = [[ChartDataEntry alloc] initWithValue:[obj.step floatValue] xIndex:i];
                [self.arrayYData addObject:chartData];
            }
        }
    } else if (self.chartContentType == ChartFitnessTypeWalkRun) {
        if (self.arrayAllData.count > 0) {
            for (FitnessModel *obj in self.arrayAllData) {
                dateTime = [UIUtils dateFromServerTimeString:obj.date];
                if(dateTime != nil)
                    [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"MM/dd"]];
            }
            
            for (int i = 0; i < self.arrayAllData.count ; i++) {
                FitnessModel *obj = (FitnessModel*) self.arrayAllData[i];
                ChartDataEntry *chartData = [[ChartDataEntry alloc] initWithValue:[obj.walkrun floatValue] xIndex:i];
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
        [self addLimitLineOnRightAxisWithoutText:(CGFloat)((maxLineYAxis + self.minAxisValue) / 2) lineWidth:1.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor]];
        //Add top left line
        [self addLimitLineOnRightAxis:maxLineYAxis * 1.1f lineWidth:1.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor] andText:chartTitle andFont:[FontUtils montserratRegularWithSize:12.0]];
        //Add top right line
        if (self.showAvarage) {
            [self addLimitLineOnRightAxis:maxLineYAxis * 1.1f lineWidth:self.limitLineWidth * 2.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor] andText:[NSString stringWithFormat:@"%@ %0.1f %@",kLocalizedString(kTitleAverage),average,chartUnit] withFont:[FontUtils montserratRegularWithSize:8.0] andTextDirection:ChartLimitLabelPositionRightTop];
        };
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

- (void)chartValueSelected:(ChartViewBase * __nonnull)chartView entry:(ChartDataEntry * __nonnull)entry dataSetIndex:(NSInteger)dataSetIndex highlight:(ChartHighlight * __nonnull)highlight{
    NSLog(@"chartValueSelected");
}

- (void)chartValueNothingSelected:(ChartViewBase * __nonnull)chartView{
    NSLog(@"chartValueNothingSelected");
}


@end
