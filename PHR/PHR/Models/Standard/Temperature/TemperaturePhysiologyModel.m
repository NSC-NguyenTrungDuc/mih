//
//  TemperaturePhysiologyModel.m
//  PHR
//
//  Created by BillyMobile on 6/2/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "TemperaturePhysiologyModel.h"

@implementation TemperaturePhysiologyModel
- (id)initWithTemperature:(NSString*)temperature respiratory:(NSString*)respiratory heartRate:(NSString*)heartRate lowBloodPressure:(NSString*)lowBloodPressure highBloodPressure:(NSString*)highBloodPressure type:(int)type date:(NSString*)date note:(NSString*)note{
    self = [super init];
    if (self) {
        self.temperature = temperature;
        self.respiratory = respiratory;
        self.heartRate = heartRate;
        self.lowBloodPressure = lowBloodPressure;
        self.highBloodPressure = highBloodPressure;
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

+ (instancetype)initWithObj:(NSDictionary *)obj {
    TemperaturePhysiologyModel *result = [[TemperaturePhysiologyModel alloc] initWithDictionary:obj];
    return result;
}

- (void)updateWithDictionary:(NSDictionary*)data{
    self.TemperaturePhysiologyID = [Validator getSafeString:data[KEY_TEMPERATURE_ID]];
    self.temperature = [Validator getSafeString:data[KEY_TEMPERATURE]];
    self.heartRate = [Validator getSafeString:data[KEY_HEART_RATE]];
    
    self.heartRateMax = [Validator getSafeString:data[KEY_HEART_RATE_MAX]];
    self.respiratory = [Validator getSafeString:data[KEY_RESPIRATORY]];
    self.lowBloodPressure = [Validator getSafeString:data[KEY_LOW_BLOOD_PRESSURE]];
    self.highBloodPressure = [Validator getSafeString:data[KEY_HIGH_BLOOD_PRESSURE]];
    self.date = [Validator getSafeString:data[KEY_DateRecord]];
    self.note = [Validator getSafeString:data[KEY_Note]];
}

- (instancetype)initFromSample:(PHRSample*)sample {
    if (self = [super init]) {
        if ([sample.type isEqualToString:HKQuantityTypeIdentifierBodyTemperature]) {
            self.temperature = [@(roundf (100 * sample.value) / 100.0) stringValue];
        }
        else if ([sample.type isEqualToString:HKQuantityTypeIdentifierHeartRate]) {
            self.heartRate = [@(sample.value) stringValue];
        }
        else if ([sample.type isEqualToString:HKQuantityTypeIdentifierRespiratoryRate]) {
            self.respiratory = [@(sample.value) stringValue];
        }
        else if ([sample.type isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]) {
            self.lowBloodPressure = [@(sample.value) stringValue];
            self.highBloodPressure = [@(sample.value2) stringValue];
        }
        self.date = [UIUtils stringUTCDate:sample.record_date withFormat:PHR_SERVER_DATE_TIME_FORMAT];
    }
    return self;
}

+ (PHRSample*)sampleFromDict:(NSDictionary*)dict type:(PHRTemperatureChartType)type{
    PHRSample *sample = [[PHRSample alloc] init];
    sample.profile_id = PHRAppStatus.currentStandard.profileId;
    sample.type = [PHRSample healthkitTypeFromType:type fromScreen:StandardHomeTypeTemprature];
    switch (type) {
        case PHRChartTemperature:
            sample.value = [[Validator getSafeString:dict[KEY_TEMPERATURE]] doubleValue];
            break;
        case PHRChartHeartRate:
            sample.value = [[Validator getSafeString:dict[KEY_HEART_RATE_MIN]] doubleValue];
            sample.value2 = [[Validator getSafeString:dict[KEY_HEART_RATE_MAX]] doubleValue];
            break;
        case PHRChartPrespiratory:
            sample.value = [[Validator getSafeString:dict[KEY_RESPIRATORY]] doubleValue];
            break;
        case PHRChartBloodPressure:
            sample.value = [[Validator getSafeString:dict[KEY_MIN_LOW_BLOOD_PRESSURE]] doubleValue];
            sample.value2 = [[Validator getSafeString:dict[KEY_MIN_HIGH_BLOOD_PRESSURE]] doubleValue];
            sample.valueMaxHigh = [[Validator getSafeString:dict[KEY_MAX_HIGH_BLOOD_PRESSURE]] doubleValue];
            sample.valueMaxLow = [[Validator getSafeString:dict[KEY_MAX_LOW_BLOOD_PRESSURE]] doubleValue];

            break;
        case PHRChartBloodPressureHigh:
            break;
        default:
            break;
            
    }
    sample.record_date = [UIUtils dateFromServerTimeString:[Validator getSafeString:dict[KEY_DateRecord]]];
    sample.source_bundle = [PHRSample bundlePHRServer];
    
    return sample;
}

- (NSString*)serverType{
    switch (self.type) {
        case PHRChartTemperature:
            return @"01";
        case PHRChartBloodPressure:
            return @"04";
        case PHRChartHeartRate:
            return @"02";
        case PHRChartPrespiratory:
            return @"03";
    }
    return nil;
}


@end
