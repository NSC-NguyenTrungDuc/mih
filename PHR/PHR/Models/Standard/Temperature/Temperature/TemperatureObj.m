//
//  TemperatureObj.m
//  PHR
//
//  Created by BillyMobile on 5/25/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "TemperatureObj.h"

@implementation TemperatureObj


- (id)initWithTemperature:(float)temperature andDate:(NSString *)date{
    self = [super init];
    if (self) {
        self.temperature = temperature;
        self.date = date;
    }
    return self;

}

@end
