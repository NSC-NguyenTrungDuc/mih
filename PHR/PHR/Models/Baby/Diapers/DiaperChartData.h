//
//  DiaperChartData.h
//  PHR
//
//  Created by BillyMobile on 6/9/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface DiaperChartData : NSObject
@property (nonatomic, strong) NSString *time_pee_poo;
@property (nonatomic) int numberOfPee;
@property (nonatomic) int numberOfPoo;
- (PHRSample*)sampleFromDiaperChartData ;
@end
