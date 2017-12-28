//
//  BabySleep.h
//  PHR
//
//  Created by DEV-MinhNN on 11/4/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "BabySleepModel.h"

@interface BabySleep : NSObject

@property (nonatomic, strong) NSDate *time_start_sleep;
@property (nonatomic, strong) NSString *time_wake_up;
@property (nonatomic, strong) NSString *morning_time_sleep;
@property (nonatomic, strong) NSString *afternoon_time_sleep;
@property (nonatomic, strong) NSString *night_time_sleep;
@property (nonatomic, strong) NSString *id_babySleep;
@property (nonatomic) BOOL isShow;
@property (nonatomic, strong) NSString *dateTime;

+ (BabySleep *)initializeBabySleepFromObj:(NSDictionary *)dict;
+ (BabySleep *)initializeBabySleepFromModel:(BabySleepModel *)model andDate:(NSString *)date;

@end
