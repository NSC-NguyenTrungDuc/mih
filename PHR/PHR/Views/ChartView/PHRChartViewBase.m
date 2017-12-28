//
//  PHRChartViewBase.m
//  PHR
//
//  Created by NextopHN on 4/26/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRChartViewBase.h"
#import <PureLayout/PureLayout.h>

@implementation PHRChartViewBase


- (void)initializeChart:(id)delegate {
    self.chartView = [[LineChartView alloc] initWithFrame:self.frame];
    [self addSubview:self.chartView];
    [self.chartView autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0];
    [self.chartView autoPinEdgeToSuperviewEdge:ALEdgeBottom withInset:0];
    [self.chartView autoPinEdgeToSuperviewEdge:ALEdgeLeading withInset:0];
    [self.chartView autoPinEdgeToSuperviewEdge:ALEdgeTrailing withInset:0];
    
    self.chartDuration = ButtonTimeIntervalWeekly;
    self.chartView.layer.cornerRadius = 6.0;

    self.chartView.delegate = delegate;
    
    self.chartView.descriptionText = @"";
    self.chartView.noDataTextDescription = @"";
    
    self.chartView.dragEnabled = NO;
    [self.chartView setScaleEnabled:NO];
    self.chartView.pinchZoomEnabled = NO;
    self.chartView.drawGridBackgroundEnabled = NO;
    self.chartView.drawBordersEnabled = NO;
    [self setBackgroundColor:[UIColor clearColor]];
    [self.chartView setBackgroundColor:[UIColor clearColor]];
    
    _xAxis = self.chartView.xAxis;
    _xAxis.labelPosition = XAxisLabelPositionBottom;
    _xAxis.labelFont = [FontUtils aileronRegularWithSize:9.0f];
    _xAxis.drawGridLinesEnabled = NO;
    _xAxis.spaceBetweenLabels = 5.0;
    _xAxis.labelTextColor = [UIColor whiteColor];
    _xAxis.xOffset = -20.0;
    _xAxis.avoidFirstLastClippingEnabled = true;
    
    
    _leftAxis = self.chartView.leftAxis;
    [_leftAxis removeAllLimitLines];
    _leftAxis.axisMaxValue = 100.0;
    _leftAxis.axisMinValue = 0.0;
    _leftAxis.drawZeroLineEnabled = NO;
    _leftAxis.gridLineCap = YES;
    _leftAxis.drawGridLinesEnabled = YES;
    _leftAxis.labelTextColor = [UIColor whiteColor];
    _leftAxis.rangeViewMax = 65;
    _leftAxis.rangeViewMin = 0;
    _leftAxis.rangeViewColor = [[UIColor yellowColor] colorWithAlphaComponent:0.];
    _leftAxis.drawRangeViewColor = true;
    _leftAxis.labelPosition = YAxisLabelPositionInsideChart;
    _leftAxis.forceLabelsEnabled = YES;
    
    _rightAxis = self.chartView.rightAxis;
    [_rightAxis removeAllLimitLines];
    _rightAxis.axisMaxValue = 100.0;
    _rightAxis.axisMinValue = 0.0;
    _rightAxis.drawZeroLineEnabled = NO;
    _rightAxis.gridLineCap = YES;
    _rightAxis.drawGridLinesEnabled = YES;
    _rightAxis.labelTextColor = [[UIColor whiteColor] colorWithAlphaComponent:0.7];
    _rightAxis.drawLabelsEnabled = YES;
    _rightAxis.axisLineColor = [UIColor clearColor];
    _rightAxis.rangeViewMax = 65;
    _rightAxis.rangeViewMin = 0;
    _rightAxis.rangeViewColor = [[UIColor yellowColor] colorWithAlphaComponent:0.];
    _rightAxis.drawRangeViewColor = YES;
    _rightAxis.labelFont = [FontUtils aileronRegularWithSize:10.0f];
    _rightAxis.labelPosition = YAxisLabelPositionInsideChart;
    _rightAxis.forceLabelsEnabled = YES;
    
    [self.chartView.viewPortHandler setMaximumScaleY: 2.f];
    [self.chartView.viewPortHandler setMaximumScaleX: 2.f];
    self.chartView.minOffset = 0;
    self.chartView.extraLeftOffset = 10;
    self.chartView.extraRightOffset = 10;
    self.chartView.extraTopOffset = 10;
    self.chartView.legend.form = ChartLegendFormNone;
    self.chartView.legend.textColor = [UIColor clearColor];

    self.SMA_PERIOD = 10;
    
    self.arrayXData = [NSMutableArray new];
    self.arrayYData = [NSMutableArray new];
    self.arrayAllData = [NSMutableArray new];
    self.maxAxisValue = 0;
    self.minAxisValue = 0;
    self.chartView.noDataText =  @"";
   
}

- (void)layoutSubviews {
    [super layoutSubviews];
     [self initIndicator];
}

- (void)initIndicator {
    self.indicator = [[UIActivityIndicatorView alloc]initWithActivityIndicatorStyle:UIActivityIndicatorViewStyleGray];
    self.indicator.frame = CGRectMake(self.frame.size.width / 2 - 15, self.frame.size.height / 2, 30.0, 30.0);
    self.indicator.color = [UIColor whiteColor];
    [self addSubview:self.indicator];
}

- (void)showIndicator {
     [self.indicator startAnimating];
}

- (void)hideIndicator {
     [self.indicator stopAnimating];
}

- (void)updateChartData {
    [self.arrayXData removeAllObjects];
    [self.arrayYData removeAllObjects];
    [self.rightAxis removeAllLimitLines];
    if (self.arrayAllData.count == 0) {
        self.chartView.noDataTextDescription = kLocalizedString(kNoData);
        self.chartView.isShowNoDataText = true;
    } else {
         self.chartView.isShowNoDataText = false;
    }
}

- (void)addLimitLineOnRightAxis:(CGFloat)value lineWidth:(CGFloat)lineWidth lineColor:(UIColor*)color textColor:(UIColor*)textColor{
    ChartLimitLine *limitLine = [[ChartLimitLine alloc] initWithLimit:value label:[NSString stringWithFormat:@"%0.0f",value]];
    limitLine.lineWidth = lineWidth;
    limitLine.lineColor = [color colorWithAlphaComponent:0.6];
    limitLine.valueTextColor = textColor;
    limitLine.labelPosition = ChartLimitLabelPositionRightBottom;
    limitLine.valueFont = [FontUtils aileronRegularWithSize:9.0];
    limitLine.xOffset = 1.0;
    [_rightAxis addLimitLine:limitLine];
}

- (void)addLimitLineOnRightAxisWithoutText:(CGFloat)value lineWidth:(CGFloat)lineWidth lineColor:(UIColor*)color textColor:(UIColor*)textColor{
    ChartLimitLine *limitLine = [[ChartLimitLine alloc] initWithLimit:value label:@""];
    limitLine.lineWidth = lineWidth;
    limitLine.lineColor = [color colorWithAlphaComponent:1];
    limitLine.valueTextColor = textColor;
    limitLine.labelPosition = ChartLimitLabelPositionRightTop;
    limitLine.valueFont = [FontUtils aileronRegularWithSize:9.0];
    limitLine.xOffset = 1.0;
    [_rightAxis addLimitLine:limitLine];
}

- (void)addLimitLineOnRightAxisWithIcon:(CGFloat)value andText:(NSString*)text lineWidth:(CGFloat)lineWidth lineColor:(UIColor*)color textColor:(UIColor*)textColor {
    ChartLimitLine *limitLine = [[ChartLimitLine alloc] initWithLimit:value label:text];
    limitLine.lineWidth = lineWidth;
    limitLine.lineColor = color;
    limitLine.valueTextColor = textColor;
    //limitLine.labelPosition = ChartLimitLabelPositionLeft;
    limitLine.valueFont = [FontUtils aileronRegularWithSize:12];
    limitLine.xOffset = 1.0;
    limitLine.lineDashLengths = @[@5.f, @2.f];
    [_rightAxis addLimitLine:limitLine];
}

- (void)addLimitLineOnRightAxis:(CGFloat)value lineWidth:(CGFloat)lineWidth lineColor:(UIColor*)color textColor:(UIColor*)textColor andText: (NSString*)text andFont:(UIFont*) font{
    ChartLimitLine *limitLine = [[ChartLimitLine alloc] initWithLimit:value label:text];
    limitLine.lineWidth = lineWidth;
    limitLine.lineColor = [color colorWithAlphaComponent:1];
    limitLine.valueTextColor = textColor;
    limitLine.labelPosition = ChartLimitLabelPositionLeftTop;
    limitLine.valueFont = font;
    limitLine.xOffset = 1.0;
    
    [_rightAxis addLimitLine:limitLine];
}

- (void)addLimitLineOnRightAxis:(CGFloat)value lineWidth:(CGFloat)lineWidth lineColor:(UIColor*)color textColor:(UIColor*)textColor andText: (NSString*)text withFont:(UIFont*) font andTextDirection:(ChartLimitLabelPosition) position{
    ChartLimitLine *limitLine = [[ChartLimitLine alloc] initWithLimit:value label:text];
    limitLine.lineWidth = lineWidth;
    limitLine.lineColor = [color colorWithAlphaComponent:1];
    limitLine.valueTextColor = textColor;
    limitLine.labelPosition = position;
    limitLine.valueFont = font;
    limitLine.xOffset = 1.0;
    [_rightAxis addLimitLine:limitLine];
}

- (void)setLeftAxisEnable:(BOOL)enableLeft rightAxisEnable:(BOOL)enableRight{
    self.chartView.leftAxis.enabled = enableLeft;
    self.chartView.rightAxis.enabled = enableRight;
}

- (void)setLeftAxisMin:(CGFloat)min max:(CGFloat)max{
    _leftAxis.axisMaxValue = max;
    _leftAxis.axisMinValue = min;
}

- (void)setRightAxisMin:(CGFloat)min max:(CGFloat)max{
    _rightAxis.axisMaxValue = max;
    _rightAxis.axisMinValue = min;
}

- (void)setLeftAxisDrawGrid:(BOOL)gridLeft rightAxisDrawGrid:(BOOL)gridRight{
    _leftAxis.drawGridLinesEnabled = gridLeft;
    _rightAxis.drawGridLinesEnabled = gridRight;
}

- (void)setXAxisLineColor: (UIColor*) color {
    _xAxis.axisLineColor = color;
}

- (void)setYData:(NSMutableArray*)arrayInput{
    _arrayYData = arrayInput;
}

- (void)setXData:(NSMutableArray*)arrayInput{
    _arrayXData = arrayInput;
}

- (void)setData:(NSMutableArray*)arrayInput{
    _arrayAllData = arrayInput;
}

- (void)calculateMinMax{
    //Overrided
}

- (LineChartDataSet*)drawSMA {
    LineChartDataSet *setSMA1 = nil;
    
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
            averageSMA = round (100 * averageSMA) / 100;
            [ydataSMA addObject:[[ChartDataEntry alloc] initWithValue:averageSMA xIndex:i]];
        }
    }
    
    //SMA
        setSMA1 = [[LineChartDataSet alloc] initWithYVals:ydataSMA label:nil];
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
    return setSMA1;
}

- (void)setupInView:(UIView*)view {
    [view addSubview:self];
    [self autoPinEdgeToSuperviewEdge:ALEdgeLeft withInset:0.0];
    [self autoPinEdgeToSuperviewEdge:ALEdgeRight withInset:0.0];
    [self autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0.0];
    [self autoPinEdgeToSuperviewEdge:ALEdgeBottom withInset:0.0];
}
#pragma mark - ChartViewDelegate

- (void)chartValueSelected:(ChartViewBase * __nonnull)chartView entry:(ChartDataEntry * __nonnull)entry dataSetIndex:(NSInteger)dataSetIndex highlight:(ChartHighlight * __nonnull)highlight
{
    NSLog(@"chartValueSelected");
}

- (void)chartValueNothingSelected:(ChartViewBase * __nonnull)chartView
{
    NSLog(@"chartValueNothingSelected");
}
@end
