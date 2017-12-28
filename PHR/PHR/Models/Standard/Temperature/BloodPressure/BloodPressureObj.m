//
//  BloodPressureObj.m
//  PHR
//
//  Created by BillyMobile on 5/26/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BloodPressureObj.h"

@implementation BloodPressureObj

- (id)initWithBloodPressure:(float)bloodPressure andDate:(NSString *)date{
    self = [super init];
    if (self) {
        self.bloodPressure = bloodPressure;
        self.date = date;
    }
    return self;
}

@end
