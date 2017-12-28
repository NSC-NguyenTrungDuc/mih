//
//  MilkChart.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRChartViewBase.h"


@interface MilkChart : PHRChartViewBase
- (void)setMarker;
- (void)doCustomize;
- (void)setChartTitle:(NSString*)title;
- (void)setLineChartColor:(UIColor*)color;
- (void)setIsShowGradient:(BOOL)isShow;
- (void)setFillBalloonColor:(UIColor*)color;
- (void)setIsShowValueLimitLine:(BOOL)isShowValue;
@end
