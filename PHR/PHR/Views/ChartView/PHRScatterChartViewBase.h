//
//  PHRScatterChartViewBase.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/29/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface PHRScatterChartViewBase : UIView

@property (nonatomic, assign) NSInteger chartContentType;
@property (nonatomic, assign) NSString* chartType;
@property (nonatomic, assign) int SMA_PERIOD;
@property (nonatomic, assign) CGFloat maxAxisValue;
@property (nonatomic, assign) CGFloat minAxisValue;
@property (strong, nonatomic) ScatterChartView *chartView;
@property (strong, nonatomic) ChartXAxis *xAxis;
@property (strong, nonatomic) ChartYAxis *leftAxis;
@property (strong, nonatomic) ChartYAxis *rightAxis;
@property (strong, nonatomic) NSMutableArray *arrayXData;
@property (strong, nonatomic) NSMutableArray *arrayYData;
@property (strong, nonatomic) NSMutableArray *arrayAllData;
@property (nonatomic, assign) CGFloat limitLineWidth;
@property (nonatomic, assign) BOOL showAvarage;
@property (nonatomic, assign)  ButtonTimeIntervalClick chartDuration;

- (void)initializeChart:(id)delegate;

- (void)updateChartData;

- (void)addLimitLineOnRightAxisWithIcon:(CGFloat)value andText:(NSString*)text lineWidth:(CGFloat)lineWidth lineColor:(UIColor*)color textColor:(UIColor*)textColor;
- (void)addLimitLineOnRightAxis:(CGFloat)value lineWidth:(CGFloat)lineWidth lineColor:(UIColor*)color textColor:(UIColor*)textColor;
- (void)addLimitLineOnRightAxis:(CGFloat)value lineWidth:(CGFloat)lineWidth lineColor:(UIColor*)color textColor:(UIColor*)textColor andText: (NSString*)text andFont:(UIFont*) font;
- (void)addLimitLineOnRightAxis:(CGFloat)value lineWidth:(CGFloat)lineWidth lineColor:(UIColor*)color textColor:(UIColor*)textColor andText: (NSString*)text withFont:(UIFont*) font andTextDirection:(ChartLimitLabelPosition) position;
- (void)addLimitLineOnRightAxisWithoutText:(CGFloat)value lineWidth:(CGFloat)lineWidth lineColor:(UIColor*)color textColor:(UIColor*)textColor;
- (void)setLeftAxisEnable:(BOOL)enableLeft rightAxisEnable:(BOOL)enableRight;
- (void)setLeftAxisMin:(CGFloat)min max:(CGFloat)max;
- (void)setRightAxisMin:(CGFloat)min max:(CGFloat)max;
- (void)setLeftAxisDrawGrid:(BOOL)gridLeft rightAxisDrawGrid:(BOOL)gridRight;
- (void)setYData:(NSMutableArray*)arrayInput;
- (void)setXData:(NSMutableArray*)arrayInput;
- (void)setData:(NSMutableArray*)arrayInput;
- (void)calculateMinMax;
- (void)setXAxisLineColor:(UIColor*)color;
- (void)setupInView:(UIView*)view;



@end
