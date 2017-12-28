//
//  PHRStandardFoodChart.m
//  PHR
//
//  Created by NextopHN on 4/26/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRStandardFoodChart.h"


@implementation PHRStandardFoodChart

/*
 // Only override drawRect: if you perform custom drawing.
 // An empty implementation adversely affects performance during animation.
 - (void)drawRect:(CGRect)rect {
 // Drawing code
 }
 */

- (void)doCustomize{
    [self setLeftAxisEnable:NO rightAxisEnable:YES];
    [self setLeftAxisDrawGrid:NO rightAxisDrawGrid:NO];
    [self setRightAxisMin:0 max:100];
}

- (void)setMarker{
    BalloonMarker *marker = [[BalloonMarker alloc] initWithColor:[PHRUIColor colorFromHex:@"#ffc602" alpha:1.0] font:[UIFont systemFontOfSize:9.0] insets: UIEdgeInsetsMake(2.0, 2.0, 5.0, 2.0)];
    marker.minimumSize = CGSizeMake(25.0, 15.0);
    self.chartView.marker = marker;
}

- (void)updateChartData {
    [super updateChartData];
    [self processData];
    [self.chartView animateWithXAxisDuration:2.5 easingOption:ChartEasingOptionEaseInOutQuart];
}

- (void)calculateMinMax {
    if (self.arrayYData.count > 0) {
        for (FoodModel *obj in self.arrayAllData){
            if (self.maxAxisValue < (CGFloat) [obj.kcal floatValue]) {
                self.maxAxisValue = (CGFloat) [obj.kcal floatValue];
            }
        }
        for (FoodModel *obj in self.arrayAllData){
            if (self.minAxisValue > (CGFloat) [obj.kcal floatValue]) {
                self.minAxisValue = (CGFloat) [obj.kcal floatValue];
            }
        }
    }
}
- (void)processData {
    NSMutableArray *yVals = [[NSMutableArray alloc] init];
    
    
    if (self.arrayAllData > 0){
        for (FoodModel *obj in self.arrayAllData) {
            [self.arrayXData addObject:[UIUtils formatDateMonthStyle:[UIUtils dateFromServerTimeString:obj.eating_time]]];
        }
        [self.arrayXData addObject:@"TODAY"];
        
        for (int i = 0; i < self.arrayAllData.count ; i++) {
            FoodModel *obj = (FoodModel*) self.arrayAllData[i];
            ChartDataEntry *chartData = [[ChartDataEntry alloc] initWithValue:[obj.kcal doubleValue] xIndex:i];
            [self.arrayYData addObject:chartData];
        }
    }
    
    [self calculateMinMax];
    [self setRightAxisMin:self.minAxisValue max:(CGFloat)(self.maxAxisValue*1.25)];
    [self.rightAxis removeAllLimitLines];
    [self addLimitLineOnRightAxis:(CGFloat)(self.maxAxisValue*1.25) lineWidth:1.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor]];
    [self addLimitLineOnRightAxis:(CGFloat)(self.maxAxisValue*0.625) lineWidth:0.5 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor]];
    
    NSMutableArray *ydataSMA = [[NSMutableArray alloc]init];
    for (int i = 0; i < self.arrayYData.count; i++) {
        if (i < self.SMA_PERIOD - 1) {
            //[self.ydataSMA addObject:@0];
        } else {
            double total = 0;
            int index = i - (self.SMA_PERIOD - 1);
            int maxIndex = index + (self.SMA_PERIOD - 1);
            
            for (int j = index; j <= maxIndex ; j++) {
                double n1 = [(ChartDataEntry*)[yVals objectAtIndex:j] value];
                total += n1;
            }
            
            double average = total / (double) self.SMA_PERIOD;
            [ydataSMA addObject:[[ChartDataEntry alloc] initWithValue:average xIndex:i]];
        }
    }
    
    LineChartDataSet *set1 = [[LineChartDataSet alloc] initWithYVals:self.arrayYData label:nil];
    LineChartDataSet *setSMA1 = [[LineChartDataSet alloc] initWithYVals:ydataSMA label:nil];
    
    //set1.lineDashLengths = @[@5.f, @2.5f];
    //set1.highlightLineDashLengths = @[@5.f, @2.5f];
    [set1 setColor:[PHRUIColor colorFromHex:@"#ffc602" alpha:1.0]];
    [set1 setCircleColor:[[UIColor whiteColor] colorWithAlphaComponent:0.6]];
    set1.lineWidth = 1.5;
    set1.circleRadius = 5.0;
    set1.drawCircleHoleEnabled = YES;
    set1.circleHoleColor = [PHRUIColor colorFromHex:@"#ffc602" alpha:1.0];
    set1.circleHoleRadius = 4.0;
    set1.valueFont = [UIFont systemFontOfSize:9.f];
    set1.drawValuesEnabled = NO;
    set1.drawHorizontalHighlightIndicatorEnabled = NO;
    set1.axisDependency = AxisDependencyRight;
    set1.drawVerticalHighlightIndicatorEnabled = NO;
    //set1.drawFilledEnabled = YES;
    //set1.fillAlpha = 65/255.0;
    //set1.fillColor = UIColor.blueColor;
    
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
    //setSMA1.fillFormatter = [[CubicLineSampleFillFormatter alloc] init];
    
    //NSArray *gradientColors = @[(id)[[UIColor orangeColor] colorWithAlphaComponent:0.05].CGColor,(id)[[UIColor orangeColor] colorWithAlphaComponent:0.5].CGColor];
    //CGGradientRef gradient = CGGradientCreateWithColors(nil, (CFArrayRef)gradientColors, nil);
    
    set1.fillAlpha = 1.f;
    //set1.fill = [ChartFill fillWithLinearGradient:gradient angle:90.f];
    set1.drawFilledEnabled = NO;
    
    //CGGradientRelease(gradient);
    
    [yVals addObject:set1];
    //[yVals addObject:setSMA1];
    
    LineChartData *data = [[LineChartData alloc] initWithXVals:self.arrayXData dataSets:yVals];
    self.chartView.data = data;
}

- (void)chartValueSelected:(ChartViewBase * __nonnull)chartView entry:(ChartDataEntry * __nonnull)entry dataSetIndex:(NSInteger)dataSetIndex highlight:(ChartHighlight * __nonnull)highlight
{
    NSLog(@"chartValueSelected");
}

- (void)chartValueNothingSelected:(ChartViewBase * __nonnull)chartView
{
    NSLog(@"chartValueNothingSelected");
}
@end
