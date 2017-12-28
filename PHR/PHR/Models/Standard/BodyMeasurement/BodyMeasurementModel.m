//
//  BodyMeasurementModel.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/25/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BodyMeasurementModel.h"
#import "PHRSample.h"

@implementation BodyMeasurementModel

- (id)initWithBodyMeasurement:(NSString*)height weight:(NSString*)weight percentFat:(NSString*)percentFat bmi:(NSString*)bmi type:(int)type date:(NSString*)date note:(NSString*)note {
    self = [super init];
    if (self) {
        self.height = height;
        self.weight = weight;
        self.percentFat = percentFat;
        self.bmi = bmi;
        self.date = date;
        self.note = note;
        self.type = type;
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

- (instancetype)initFromSample:(PHRSample*)sample{
    if (self = [super init]) {
        
        if ([sample.type isEqualToString:HKQuantityTypeIdentifierHeight]){
            self.height = [@(roundf (100 * sample.value) / 100.0) stringValue];
        }
        else if ([sample.type isEqualToString:HKQuantityTypeIdentifierBodyMass]){
            self.weight = [@(roundf (100 * sample.value) / 100.0) stringValue];
        }
        else if ([sample.type isEqualToString:HKQuantityTypeIdentifierBodyFatPercentage]){
            self.percentFat = [@(roundf (100 * sample.value) / 100.0) stringValue];
        }
        else if ([sample.type isEqualToString:HKQuantityTypeIdentifierBodyMassIndex]){
            self.bmi = [@(roundf (100 * sample.value) / 100.0) stringValue];
        }
        self.date = [UIUtils stringUTCDate:sample.record_date withFormat:PHR_SERVER_DATE_TIME_FORMAT];
    }
    return self;
}

+ (instancetype)initWithObj:(NSDictionary *)obj {
    BodyMeasurementModel *result = [[BodyMeasurementModel alloc] initWithDictionary:obj];
    return result;
}

- (void)updateWithDictionary:(NSDictionary*)data{
    self.bodyMeasurementID = [Validator getSafeString:data[KEY_HEALTH_ID]];
    self.height = [Validator getSafeString:data[KEY_Height]];
    self.weight = [Validator getSafeString:data[KEY_Weight]];
    self.percentFat = [Validator getSafeString:data[KEY_PercentageFat]];
    self.bmi = [Validator getSafeString:data[KEY_BMI]];
    self.date = [Validator getSafeString:data[KEY_DateRecord]];
    self.note = [Validator getSafeString:data[KEY_Note]];
    self.healthType = [Validator getSafeString:data[KEY_HEALTH_TYPE]];
}

+ (PHRSample*)sampleFromDict:(NSDictionary*)dict type:(BodyMeasurementType)type{
    PHRSample *sample = [[PHRSample alloc] init];
    sample.profile_id = PHRAppStatus.currentStandard.profileId;
    sample.type = [PHRSample healthkitTypeFromType:type fromScreen:StandardHomeTypeBodyMeasurement];
    switch (type) {
        case BodyMeasurementTypeHeight:
            sample.value = [[Validator getSafeString:dict[KEY_Height]] doubleValue];
            break;
        case BodyMeasurementTypeWeight:
            sample.value = [[Validator getSafeString:dict[KEY_Weight]] doubleValue];
            break;
        case BodyMeasurementTypeBodyFat:
            sample.value = [[Validator getSafeString:dict[KEY_PercentageFat]] doubleValue];
            break;
        case BodyMeasurementTypeBMI:
            sample.value = [[Validator getSafeString:dict[KEY_BMI]] doubleValue];
            break;
    }
    sample.record_date = [UIUtils dateFromServerTimeString:[Validator getSafeString:dict[KEY_DateRecord]]];
    sample.source_bundle = [PHRSample bundlePHRServer];
    
    return sample;
}

@end
