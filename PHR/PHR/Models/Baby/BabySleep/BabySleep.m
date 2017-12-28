
//
//  BabySleep.m
//  PHR
//
//  Created by DEV-MinhNN on 11/4/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "BabySleep.h"

@implementation BabySleep

+ (BabySleep *)initializeBabySleepFromObj:(NSDictionary *)dict {
    BabySleep *objSleep = [BabySleep new];
    
    NSDate  *dateTime   = [UIUtils dateFromServerTimeString:[dict objectForKey:KEY_LifeStyleNote_Time_Sleep]];

    objSleep.time_start_sleep       = dateTime;
    objSleep.time_wake_up           = [dict objectForKey:KEY_LifeStyleNote_Time_WakeUp];
    objSleep.morning_time_sleep     = [dict objectForKey:KEY_BabySleep_Morning];
    objSleep.afternoon_time_sleep   = [dict objectForKey:KEY_BabySleep_Afternoon];
    objSleep.night_time_sleep       = [dict objectForKey:KEY_BabySleep_Night];
    objSleep.id_babySleep           = [dict objectForKey:KEY_Id];
    objSleep.isShow                 = NO;
    
    return objSleep;
}

+ (BabySleep *)initializeBabySleepFromModel:(BabySleepModel *)model andDate:(NSString *)date {
    BabySleep *objSleep = [BabySleep new];
    
    objSleep.dateTime               = date;
    objSleep.time_start_sleep       = [UIUtils dateFromServerTimeString:model.time_start_sleep];
    objSleep.time_wake_up           = model.time_wake_up;
    objSleep.morning_time_sleep     = model.morning_time_sleep;
    objSleep.afternoon_time_sleep   = model.afternoon_time_sleep;
    objSleep.night_time_sleep       = model.night_time_sleep;
    
    return objSleep;
}

@end
