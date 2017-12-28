//
//  PrespiratoryObj.m
//  PHR
//
//  Created by BillyMobile on 5/26/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PrespiratoryObj.h"

@implementation PrespiratoryObj

- (id)initWithPrespiratory:(float)prespiratory andDate:(NSString *)date{
    self = [super init];
    if (self) {
        self.prespiratory = prespiratory;
        self.date = date;
    }
    return self;
}

@end
