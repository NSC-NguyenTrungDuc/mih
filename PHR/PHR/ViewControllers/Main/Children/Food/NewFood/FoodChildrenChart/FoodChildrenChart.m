//
//  FoodChildrenChart.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "FoodChildrenChart.h"

@implementation FoodChildrenChart {
    float maxLineYAxis;
    float average;
    NSString *chartTitle;
    UIColor *lineChartColor;
    UIColor *fillBalloonColor;
    BOOL isShowGradient;
    BOOL isShowValueLimitLine;
    NSString *chartUnit;
}

- (void)doCustomize{
    [self setLeftAxisEnable:NO rightAxisEnable:YES];
    [self setLeftAxisDrawGrid:NO rightAxisDrawGrid:NO];
    [self setRightAxisMin:0 max:100];
    [self setXAxisLineColor:[UIColor whiteColor]];
    
    chartTitle = kLocalizedString(kCalories);
    chartUnit = kLocalizedString(kUnitKcal);
    self.backgroundColor = [UIColor clearColor];
   
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
    
    if (self.arrayAllData.count > 0) {
        for (ChildrenFoodModel *obj in self.arrayAllData){
            if (self.maxAxisValue < [obj.kcal floatValue]) {
                self.maxAxisValue = [obj.kcal floatValue];
                maxLineYAxis= self.maxAxisValue;
            }
            if (self.minAxisValue > [obj.kcal floatValue]) {
                self.minAxisValue = [obj.kcal floatValue];
            }
            average += [obj.kcal floatValue];
        }
        average /= self.arrayAllData.count;
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
    if (self.arrayAllData.count > 0) {
        for (ChildrenFoodModel *obj in self.arrayAllData) {
            dateTime = [UIUtils dateFromServerTimeString:obj.date];
            if(dateTime != nil)
                [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"MM/dd"]];
        }
            
        for (int i = 0; i < self.arrayAllData.count ; i++) {
            ChildrenFoodModel *obj = (ChildrenFoodModel*) self.arrayAllData[i];
            ChartDataEntry *chartData = [[ChartDataEntry alloc] initWithValue:[obj.kcal floatValue] xIndex:i];
            [self.arrayYData addObject:chartData];
        }
    }
    
    [self addLimitLine];
    
    setSMA1 = [self drawSMA];
    
    if (self.chartView.data.dataSetCount > 0) {
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
        [self addLimitLineOnRightAxisWithoutText:(CGFloat)((maxLineYAxis + self.minAxisValue) / 2) lineWidth:self.limitLineWidth lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor]];
        //Add top left line
        [self addLimitLineOnRightAxis:maxLineYAxis * 1.1f lineWidth:self.limitLineWidth * 2.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor] andText:chartTitle andFont:[FontUtils montserratRegularWithSize:12.0]];
        //Add top right line
        if (self.showAvarage) {
            [self addLimitLineOnRightAxis:maxLineYAxis * 1.1f lineWidth:self.limitLineWidth * 2.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor] andText:[NSString stringWithFormat:@"%@ %0.0f %@",kLocalizedString(kTitleAverage),average, chartUnit] withFont:[FontUtils montserratRegularWithSize:8.0] andTextDirection:ChartLimitLabelPositionRightTop];
        }
    }
}

- (void)chartValueSelected:(ChartViewBase * __nonnull)chartView entry:(ChartDataEntry * __nonnull)entry dataSetIndex:(NSInteger)dataSetIndex highlight:(ChartHighlight * __nonnull)highlight {
    NSLog(@"chartValueSelected");
}

- (void)chartValueNothingSelected:(ChartViewBase * __nonnull)chartView {
    NSLog(@"chartValueNothingSelected");
}
@end
