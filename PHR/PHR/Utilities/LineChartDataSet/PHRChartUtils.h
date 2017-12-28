//
//  PHRLineChartDataSet.h
//  PHR
//
//  Created by BillyMobile on 6/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Charts/Charts.h>
#import <HealthKit/HealthKit.h>

@interface PHRChartUtils : NSObject

+ (void)setGradient:(LineChartDataSet*)line isShow:(BOOL)isShow;
+ (void)setStyleMainLine:(LineChartDataSet*)line withColor:(UIColor *)lineChartColor;
+ (void)setStyleMainLine:(LineChartDataSet*)line;
+ (void)setStyleSecondLine:(LineChartDataSet*)line withColor:(UIColor *)lineChartColor;
+ (void)setStyleSecondLine:(LineChartDataSet*)line;
+ (void)setStyleSMALine:(LineChartDataSet*)line withColor:(UIColor *)lineChartColor;
+ (void)setStyleSMALine:(LineChartDataSet*)line;
+ (void)setStyleSecondLineCustomColor:(LineChartDataSet*)line color:(UIColor*)color;
+ (NSString*)getChartType:(int)screen andIndex:(int)index;
+ (void)setStyleMainLine:(LineChartDataSet*)line withLineColor:(UIColor*)lineColor;

+ (NSArray*)calculateAverage:(NSArray*)arrayData andSample:(PHRSample*)databaseSample duration:(ButtonTimeIntervalClick) duration;
+ (void)calculateSum:(NSMutableArray*)arrayData andSample:(PHRSample*)databaseSample duration:(ButtonTimeIntervalClick) durations;
+ (NSArray*)calculateMinMax:(NSArray*)arrayData andSample:(PHRSample*)databaseSample duration:(ButtonTimeIntervalClick) duration;
@end
