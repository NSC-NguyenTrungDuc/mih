//
//  BabyMilkModel.m
//  PHR
//
//  Created by DEV-MinhNN on 11/16/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "BabyMilkModel.h"

@implementation BabyMilkModel

+ (PHRSample*)sampleFromBabyMilkModel:(BabyMilkModel*)babyMilkModel{
    PHRSample *sample = [[PHRSample alloc] init];
    sample.profile_id = PHRAppStatus.currentBaby.profileId;
    sample.type = HKQuantityTypeIdentifierDietaryEnergyConsumed;
    sample.value = [babyMilkModel.calories intValue];
    sample.record_date = [UIUtils dateFromServerTimeString:babyMilkModel.time_drink_milk];
    sample.source_bundle = [PHRSample bundlePHRServer];
    
    return sample;
}

@end
