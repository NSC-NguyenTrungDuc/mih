//
//  FoodSummaryDataChart.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/30/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "FoodSummaryDataChart.h"

@implementation FoodSummaryDataChart {
    float maxLineYAxis;
    float average;
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
    self.arrayChartBackgroundColor = @[[UIColor colorWithRed:55./255. green:156./255. blue:210./255. alpha:1],
                                       [UIColor colorWithRed:137./255. green:187./255. blue:88./255. alpha:1],
                                       [UIColor colorWithRed:235/255. green:186/255. blue:91/255. alpha:1]];
    if (self.chartFoodType == ChartFoodTypeCalories) {
        chartTitle = kLocalizedString(kCalories);
        self.backgroundColor = [self.arrayChartBackgroundColor objectAtIndex:self.chartFoodType];
    } else if (self.chartFoodType == ChartFoodTypeCarbohydrates) {
        chartTitle = kLocalizedString(kCarbohydrate);
        self.backgroundColor = [self.arrayChartBackgroundColor objectAtIndex:self.chartFoodType];
    } else if (self.chartFoodType == ChartFoodTypeTotalFat) {
        chartTitle = kLocalizedString(kTotalFat);
        self.backgroundColor = [self.arrayChartBackgroundColor objectAtIndex:self.chartFoodType];
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

    if (self.chartFoodType == ChartFoodTypeCalories) {
        if (self.arrayAllData.count > 0) {
            for (FoodItem *obj in self.arrayAllData){
                if (self.maxAxisValue < [obj.calories floatValue]) {
                    self.maxAxisValue = [obj.calories floatValue];
                    maxLineYAxis= self.maxAxisValue;
                }
                if (self.minAxisValue > [obj.calories floatValue]) {
                    self.minAxisValue = [obj.calories floatValue];
                }
                average += [obj.calories floatValue];
            }
            average /= self.arrayAllData.count;
        }
    } else if (self.chartFoodType == ChartFoodTypeCarbohydrates) {
        if (self.arrayAllData.count > 0) {
            for (FoodItem *obj in self.arrayAllData){
                if (self.maxAxisValue < [obj.carbohydrates floatValue]) {
                    self.maxAxisValue = [obj.carbohydrates floatValue];
                    maxLineYAxis= self.maxAxisValue;
                }
                if (self.minAxisValue > [obj.carbohydrates floatValue]) {
                    self.minAxisValue = [obj.carbohydrates floatValue];
                }
                average += [obj.carbohydrates floatValue];
            }
            average /= self.arrayAllData.count;
        }
    } else if (self.chartFoodType == ChartFoodTypeTotalFat) {
        if (self.arrayAllData.count > 0) {
            for (FoodItem *obj in self.arrayAllData){
                if (self.maxAxisValue < [obj.totalFat floatValue]) {
                    self.maxAxisValue = [obj.totalFat floatValue];
                    maxLineYAxis= self.maxAxisValue;
                }
                if (self.minAxisValue > [obj.totalFat floatValue]) {
                    self.minAxisValue = [obj.totalFat floatValue];
                }
                average += [obj.totalFat floatValue];
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
    [self setRightAxisMin:self.minAxisValue max:self.maxAxisValue];
    
    NSDate  *dateTime;

    if (self.chartFoodType == ChartFoodTypeCalories) {
        if (self.arrayAllData.count > 0) {
            for (FoodItem *obj in self.arrayAllData) {
                dateTime = [UIUtils dateFromServerTimeString:obj.date];
                [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"MM/dd"]];
            }
            
            for (int i = 0; i < self.arrayAllData.count ; i++) {
                FoodItem *obj = (FoodItem*) self.arrayAllData[i];
                ChartDataEntry *chartData = [[ChartDataEntry alloc] initWithValue:[obj.calories floatValue] xIndex:i];
                [self.arrayYData addObject:chartData];
            }
        }
    } else if (self.chartFoodType == ChartFoodTypeCarbohydrates) {
        if (self.arrayAllData.count > 0) {
            for (FoodItem *obj in self.arrayAllData) {
                dateTime = [UIUtils dateFromServerTimeString:obj.date];
                [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"MM/dd"]];
            }
            
            for (int i = 0; i < self.arrayAllData.count ; i++) {
                FoodItem *obj = (FoodItem*) self.arrayAllData[i];
                ChartDataEntry *chartData = [[ChartDataEntry alloc] initWithValue:[obj.carbohydrates floatValue] xIndex:i];
                [self.arrayYData addObject:chartData];
            }
        }
    } else if (self.chartFoodType == ChartFoodTypeTotalFat) {
        if (self.arrayAllData.count > 0) {
            for (FoodItem *obj in self.arrayAllData) {
                dateTime = [UIUtils dateFromServerTimeString:obj.date];
                [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"MM/dd"]];
            }
            
            for (int i = 0; i < self.arrayAllData.count ; i++) {
                FoodItem *obj = (FoodItem*) self.arrayAllData[i];
                ChartDataEntry *chartData = [[ChartDataEntry alloc] initWithValue:[obj.totalFat floatValue] xIndex:i];
                [self.arrayYData addObject:chartData];
            }
        }
    }
    
    //SMA line
    NSMutableArray *ydataSMA = [[NSMutableArray alloc] init];
    
    for (int i = 0; i < self.arrayYData.count; i++) {
        if (i >= self.SMA_PERIOD - 1) {
            double total = 0;
            int index = i - (self.SMA_PERIOD - 1);
            int maxIndex = index + (self.SMA_PERIOD - 1);
            
            for (int j = index; j <= maxIndex ; j++) {
                double n1 = [(ChartDataEntry*)[self.arrayYData objectAtIndex:j] value];
                total += n1;
            }
            
            double averageSMA = total / (double) self.SMA_PERIOD;
            [ydataSMA addObject:[[ChartDataEntry alloc] initWithValue:averageSMA xIndex:i]];
        }
    }
    
    [self addLimitLine];
    
    if (self.chartView.data.dataSetCount > 0)
    {
        set1 = (LineChartDataSet *)self.chartView.data.dataSets[0];
        set1._yVals = self.arrayYData;
        
        //SMA
        setSMA1 = (LineChartDataSet *)self.chartView.data.dataSets[1];
        setSMA1._yVals = ydataSMA;
        
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
        
        //SMA
        setSMA1 = [[LineChartDataSet alloc] initWithYVals:ydataSMA label:nil];
        [set1 setColor:lineChartColor];
        setSMA1.drawCubicEnabled = YES;
        setSMA1.cubicIntensity = 0;
        setSMA1.drawCirclesEnabled = NO;
        setSMA1.lineWidth = 1.5;
        setSMA1.circleRadius = 4.0;
        [setSMA1 setCircleColor:UIColor.whiteColor];
        setSMA1.highlightColor = [UIColor colorWithRed:244/255.f green:117/255.f blue:117/255.f alpha:1.f];
        [setSMA1 setColor:UIColor.blueColor];
        setSMA1.fillColor = UIColor.blueColor;
        setSMA1.fillAlpha = 1.f;
        setSMA1.drawValuesEnabled = NO;
        setSMA1.drawHorizontalHighlightIndicatorEnabled = NO;
        setSMA1.axisDependency = AxisDependencyRight;
        
        //Add data set
        [yVals addObject:setSMA1];
        
        LineChartData *data = [[LineChartData alloc] initWithXVals:self.arrayXData dataSets:yVals];
        self.chartView.data = data;
    }
}

- (void)addLimitLine {
    if(!isShowValueLimitLine) {
        //Middle line
        [self addLimitLineOnRightAxisWithoutText:(CGFloat)((maxLineYAxis + self.minAxisValue) / 2) lineWidth:self.limitLineWidth lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor]];
        //Add top left line
        [self addLimitLineOnRightAxis:maxLineYAxis lineWidth:self.limitLineWidth * 2.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor] andText:chartTitle andFont:[FontUtils montserratRegularWithSize:12.0]];
        //Add top right line
        if (self.showAvarage) {
            [self addLimitLineOnRightAxis:maxLineYAxis lineWidth:self.limitLineWidth * 2.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor] andText:[NSString stringWithFormat:@"%@ %0.0f",kLocalizedString(kTitleAverage),average] withFont:[FontUtils montserratRegularWithSize:8.0] andTextDirection:ChartLimitLabelPositionRightTop];
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

- (void)chartValueSelected:(ChartViewBase * __nonnull)chartView entry:(ChartDataEntry * __nonnull)entry dataSetIndex:(NSInteger)dataSetIndex highlight:(ChartHighlight * __nonnull)highlight {
    NSLog(@"chartValueSelected");
}

- (void)chartValueNothingSelected:(ChartViewBase * __nonnull)chartView {
    NSLog(@"chartValueNothingSelected");
}
@end
