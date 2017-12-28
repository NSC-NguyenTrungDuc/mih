//
//  PHRScatterChart.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/29/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRScatterChartViewBase.h"

@interface PHRScatterChart : PHRScatterChartViewBase
- (void)setMarker;
- (void)doCustomize;
- (void)setChartBackgroundColor:(UIColor*)color;
- (void)setIsShowGradient:(BOOL)isShow andIsDetailChart:(BOOL)isDetail;
- (void)setIsBabyProfile:(BOOL) isBabyProfile;
- (void)setLineChartColor:(UIColor*)color andFillBallColor:(UIColor*)fillColor ;
- (void)addNewDataChart:(PHRSample*)sample;
- (void)setDuration:(int) duration;
@end
