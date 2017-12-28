//
//  LifeStyleNoteModel.m
//  PHR
//
//  Created by DEV-MinhNN on 1/29/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "LifeStyleNoteModel.h"

@implementation LifeStyleNoteModel

- (PHRSample*)sampleFromModel:(LifeStyleNoteModel*)model{
    PHRSample *sample = [[PHRSample alloc] init];
    sample.profile_id = PHRAppStatus.currentStandard.profileId;
    sample.type = HKCategoryTypeIdentifierSleepAnalysis;
    sample.record_date = [UIUtils dateFromServerTimeString:model.time_start_sleep];
    sample.value2 = [[UIUtils dateFromServerTimeString:model.time_wake_up] timeIntervalSinceDate:sample.record_date];
    sample.value = [model.total_hour_sleep doubleValue] / 3600.0;   
    sample.source_bundle = [PHRSample bundlePHRServer];
    
    return sample;
}

- (instancetype)initFromSample:(PHRSample*)sample {
    if (self = [super init]) {
        self.total_hour_sleep = [@(sample.value2) stringValue];
        self.time_start_sleep = [UIUtils stringUTCDate:sample.record_date withFormat:PHR_SERVER_DATE_TIME_FORMAT];
        self.time_wake_up = [UIUtils stringUTCDate:[sample.record_date dateByAddingTimeInterval:sample.value2] withFormat:PHR_SERVER_DATE_TIME_FORMAT];
    }
    return self;
}


@end
