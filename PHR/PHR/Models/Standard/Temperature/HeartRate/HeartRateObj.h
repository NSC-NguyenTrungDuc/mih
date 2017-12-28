//
//  HeartRateObj.h
//  PHR
//
//  Created by BillyMobile on 5/26/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface HeartRateObj : NSObject

- (id)initWithHeartRate:(float)heartRate andDate:(NSString *)date;

@property (nonatomic) float heartRate;
@property (nonatomic, strong) NSString *date;

@end
