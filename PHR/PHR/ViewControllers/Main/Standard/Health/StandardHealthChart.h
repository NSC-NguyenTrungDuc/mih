//
//  StandardHealthChart.h
//  PHR
//
//  Created by NextopHN on 4/6/16.
//  Copyright © 2016 Sofia. All rights reserved.
//
#import "LineChartView.h"

@interface StandardHealthChart : LineChartView
    
- (void)startCharting;
- (void)setData:(NSMutableArray*)allData withSubData:(NSMutableArray*)subData;
@end
