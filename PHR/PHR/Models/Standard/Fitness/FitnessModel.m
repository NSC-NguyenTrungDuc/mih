//
//  FitnessModel.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/17/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "FitnessModel.h"
#import "PHRSample.h"

@implementation FitnessModel

- (id)initFitnessWithStep:(NSString*)step type:(int)type date:(NSString*)date note:(NSString*)note walkrun:(NSString*)walkrun{
    self = [super init];
    if (self) {
        self.step = step;
        self.date = date;
        self.note = note;
        self.type = type;
        self.walkrun = walkrun;
    }
    return self;
}

- (instancetype)initWithDictionary:(NSDictionary *)data{
    self = [super init];
    if (self) {
        [self updateWithDictionary:data];
    }
    
    return self;
}

+ (instancetype)initWithObj:(NSDictionary *)obj {
    FitnessModel *result = [[FitnessModel alloc] initWithDictionary:obj];
    return result;
}

- (void)updateWithDictionary:(NSDictionary*)data{
    self.fitnessID = [Validator getSafeString:data[KEY_Fitness_ID]];
    self.step = [Validator getSafeString:data[KEY_Step_Count]];
    self.date = [Validator getSafeString:data[KEY_Fitness_Date]];
    self.note = [Validator getSafeString:data[KEY_Note]];
    self.walkrun = [Validator getSafeString:data[KEY_Walking_Run]];
}

- (instancetype)initFromSample:(PHRSample*)sample {
    if (self = [super init]) {
        if ([sample.type isEqualToString:HKQuantityTypeIdentifierStepCount]) {
            self.step = [@(sample.value) stringValue];
        }
        else if ([sample.type isEqualToString:HKQuantityTypeIdentifierDistanceWalkingRunning]) {
            self.walkrun = [@(sample.value) stringValue];
        }
        self.date = [UIUtils stringUTCDate:sample.record_date withFormat:PHR_SERVER_DATE_TIME_FORMAT];
    }
    return self;
}

+ (PHRSample*)sampleFromDict:(NSDictionary*)dict type:(ChartFitnessType)type{
    PHRSample *sample = [[PHRSample alloc] init];
    sample.profile_id = PHRAppStatus.currentStandard.profileId;
    sample.type = [PHRSample healthkitTypeFromType:type fromScreen:StandardHomeTypeFitness];
    switch (type) {
        case ChartFitnessTypeSteps:
            sample.value = [[Validator getSafeString:dict[KEY_Step_Count]] doubleValue];
            break;
        case ChartFitnessTypeWalkRun:
            sample.value = [[Validator getSafeString:dict[KEY_Walking_Run]] doubleValue];
            break;
    }
    sample.record_date = [UIUtils dateFromServerTimeString:[Validator getSafeString:dict[KEY_Fitness_Date]]];
    sample.source_bundle = [PHRSample bundlePHRServer];
    
    return sample;
}

@end
