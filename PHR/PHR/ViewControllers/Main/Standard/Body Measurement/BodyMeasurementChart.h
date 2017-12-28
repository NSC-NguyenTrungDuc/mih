//
//  BodyMeasurementChart.h
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//
#import "BodyMeasurementModel.h"


@interface BodyMeasurementChart : PHRChartViewBase
@property (strong,nonatomic) NSArray *arrayChartBackgroundColor;
- (void)setMarker;
- (void)doCustomize;
- (void)setChartTitle:(NSString*)title;
- (void)setLineChartColor:(UIColor*)color;
- (void)setIsShowGradient:(BOOL)isShow;
- (void)setFillBalloonColor:(UIColor*)color;
- (void)setIsShowValueLimitLine:(BOOL)isShowValue;
@end
