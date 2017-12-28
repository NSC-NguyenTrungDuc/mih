//
//  FoodSummaryDataChart.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/30/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "FoodItem.h"

@interface FoodSummaryDataChart : PHRChartViewBase
@property (strong,nonatomic) NSArray *arrayChartBackgroundColor;
- (void)setMarker;
- (void)doCustomize;
- (void)setChartTitle:(NSString*)title;
- (void)setLineChartColor:(UIColor*)color;
- (void)setIsShowGradient:(BOOL)isShow;
- (void)setFillBalloonColor:(UIColor*)color;
- (void)setIsShowValueLimitLine:(BOOL)isShowValue;

@end
