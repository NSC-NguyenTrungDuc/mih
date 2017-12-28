//
//  CPLineChartView.h
//  PHR
//
//  Created by NextopHN on 4/25/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <CorePlot/ios/CorePlot-CocoaTouch.h>

@interface CPLineChartView : UIView
@property (strong, nonatomic) CPTGraphHostingView *chartHostingView;
@property (nonatomic, strong) CPTGraph *graph;

@property (strong, nonatomic) NSMutableArray *xdata;
@property (strong, nonatomic) NSMutableArray *ydata;

@property (strong, nonatomic) NSMutableArray *xdataSMA;
@property (strong, nonatomic) NSMutableArray *ydataSMA;

@property (strong, nonatomic) NSMutableArray *arrayPlotIdentifier;

@property (nonatomic) CGFloat titleSize;
@property (nonatomic) BOOL isSMAShowed;
@property (strong, nonatomic) CPTScatterPlot *basicScatterPlot;
@property (strong, nonatomic) CPTScatterPlot *SMAScatterPlot;

- (void)initPlot;

- (void)setXRange:(NSDecimal)xRange andYRange:(NSDecimal)yRange withXMin:(NSDecimal)xMin andYMin:(NSDecimal)yMin;
- (void)setXRange:(NSDecimal)xRange andYRange:(NSDecimal)yRange;
- (void)setXMin:(NSDecimal)xMin andYMin:(NSDecimal)yMin;
- (void)addScatterPlot:(CPTScatterPlot*)newPlot withIdentifier:(NSString*)plotIdentifier lineColor:(CPTColor*)lineColor lineWith:(CGFloat)lineWidth andGradientFill:(CPTColor*)areaBeginColor endingColor:(CPTColor*)areaEndingColor;
- (void)calculateSMAData;
- (void)reloadData;

- (void)setData:(NSMutableArray*)allData withSubData:(NSMutableArray*)subData;

- (void)customizeSMAScatterPlot:(CPTColor*)color lineWith:(CGFloat)lineWidth andGradientFill:(CPTColor*)areaBeginColor endingColor:(CPTColor*)areaEndingColor;
@end
