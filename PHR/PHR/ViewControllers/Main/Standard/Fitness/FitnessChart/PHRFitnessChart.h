//
//  PHRFitnessChart.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/17/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRChartViewBase.h"
#import "FitnessModel.h"

@interface PHRFitnessChart : PHRChartViewBase
@property (strong,nonatomic) NSArray *arrayChartBackgroundColor;
- (void)setMarker;
- (void)doCustomize;
- (void)setChartTitle:(NSString*)title;
- (void)setLineChartColor:(UIColor*)color;
- (void)setIsShowGradient:(BOOL)isShow;
- (void)setFillBalloonColor:(UIColor*)color;
- (void)setIsShowValueLimitLine:(BOOL)isShowValue;
@end
