//
//  BabySleepModel.h
//  PHR
//
//  Created by DEV-MinhNN on 11/16/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <JSONModel/JSONModel.h>

@protocol BabySleepModel
@end

@interface BabySleepModel : JSONModel

@property (nonatomic, strong) NSString *id;
@property (nonatomic, strong) NSString<Optional> *alert;
@property (nonatomic, strong) NSString<Optional> *note;
@property (nonatomic, strong) NSString<Optional> *profile_id;
@property (nonatomic, strong) NSString<Optional> *time_start_sleep;
@property (nonatomic, strong) NSString<Optional> *time_wake_up;
@property (nonatomic, strong) NSString *total_hour_sleep;
@property (nonatomic, strong) NSString<Optional> *morning_time_sleep;
@property (nonatomic, strong) NSString<Optional> *afternoon_time_sleep;
@property (nonatomic, strong) NSString<Optional> *night_time_sleep;

@property (nonatomic, strong) NSString<Optional> *dateTime;
@property (nonatomic) NSString<Optional> *isShow;

@end
