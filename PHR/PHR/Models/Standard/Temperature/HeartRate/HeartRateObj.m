//
//  HeartRateObj.m
//  PHR
//
//  Created by BillyMobile on 5/26/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "HeartRateObj.h"

@implementation HeartRateObj

- (id)initWithHeartRate:(float)heartRate andDate:(NSString *)date{
    self = [super init];
    if (self) {
        self.heartRate = heartRate;
        self.date = date;
    }
    return self;
    
}

@end
