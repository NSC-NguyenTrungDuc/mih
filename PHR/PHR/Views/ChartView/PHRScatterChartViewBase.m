//
//  PHRScatterChartViewBase.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/29/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRScatterChartViewBase.h"
#import <PureLayout/PureLayout.h>

@implementation PHRScatterChartViewBase

- (void)initializeChart:(id)delegate {
    self.chartView = [[ScatterChartView alloc] initWithFrame:self.frame];
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
    _xAxis.labelFont = [FontUtils aileronRegularWithSize:10.0f];
    _xAxis.drawGridLinesEnabled = NO;
    _xAxis.spaceBetweenLabels = 1.0;
    _xAxis.labelTextColor = [UIColor whiteColor];
    _xAxis.xOffset = -20.0;
    _xAxis.avoidFirstLastClippingEnabled = true;
    
    _leftAxis = self.chartView.leftAxis;
    [_leftAxis removeAllLimitLines];
    _leftAxis.axisMaxValue = 100.0;
    _leftAxis.axisMinValue = 0.0;
    _leftAxis.axisLineColor = [UIColor clearColor];
    _leftAxis.drawZeroLineEnabled = NO;
    _leftAxis.gridLineCap = YES;
    _leftAxis.drawGridLinesEnabled = YES;
    _leftAxis.labelTextColor = [UIColor whiteColor];
    _leftAxis.rangeViewMax = 65;
    _leftAxis.rangeViewMin = 0;
    _leftAxis.rangeViewColor = [[UIColor yellowColor] colorWithAlphaComponent:0.];
    _leftAxis.drawRangeViewColor = true;
    
    _leftAxis.labelPosition = YAxisLabelPositionOutsideChart;
    _leftAxis.forceLabelsEnabled = YES;
    _leftAxis.enabled = NO;
    
    _rightAxis = self.chartView.rightAxis;
    [_rightAxis removeAllLimitLines];
    _rightAxis.drawZeroLineEnabled = NO;
    _rightAxis.gridLineCap = YES;
    _rightAxis.drawGridLinesEnabled = YES;
    _rightAxis.labelTextColor = [[UIColor whiteColor] colorWithAlphaComponent:0.7];
    _rightAxis.drawLabelsEnabled = YES;
    _rightAxis.axisLineColor = [UIColor clearColor];
    _rightAxis.labelPosition = YAxisLabelPositionInsideChart;
    _rightAxis.rangeViewMax = 65;
    _rightAxis.rangeViewMin = 0;
    _rightAxis.rangeViewColor = [[UIColor yellowColor] colorWithAlphaComponent:0.];
    _rightAxis.drawRangeViewColor = YES;
    _rightAxis.labelFont = [FontUtils aileronRegularWithSize:10.0f];
    _rightAxis.labelPosition = YAxisLabelPositionInsideChart;
    _rightAxis.forceLabelsEnabled = YES;
     _rightAxis.enabled = YES;
    
    [self.chartView.viewPortHandler setMaximumScaleY: 2.f];
    [self.chartView.viewPortHandler setMaximumScaleX: 2.f];
    self.chartView.minOffset = 0;
    self.chartView.extraLeftOffset = 10;
    self.chartView.extraRightOffset = 10;
    self.chartView.extraTopOffset = 10;
    self.chartView.legend.form = ChartLegendFormNone;
    self.chartView.legend.textColor = [UIColor clearColor];
    self.chartView.data.highlightEnabled = NO;
    self.chartView.maxVisibleValueCount = 200;
    
    self.SMA_PERIOD = 10;
    
    self.arrayXData = [NSMutableArray new];
    self.arrayYData = [NSMutableArray new];
    self.arrayAllData = [NSMutableArray new];
    self.maxAxisValue = 0;
    self.minAxisValue = 0;
    self.chartView.noDataText =  @"";
}

- (void)updateChartData {
    [self.arrayXData removeAllObjects];
    [self.arrayYData removeAllObjects];
    [self.rightAxis removeAllLimitLines];
    [self.leftAxis removeAllLimitLines];
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

- (void)setupInView:(UIView*)view {
    [view addSubview:self];
    [self autoPinEdgeToSuperviewEdge:ALEdgeLeft withInset:0.0];
    [self autoPinEdgeToSuperviewEdge:ALEdgeRight withInset:0.0];
    [self autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0.0];
    [self autoPinEdgeToSuperviewEdge:ALEdgeBottom withInset:0.0];
}

@end
