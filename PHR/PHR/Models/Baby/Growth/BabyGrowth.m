//
//  BabyGrowth.m
//  PHR
//
//  Created by DEV-MinhNN on 10/30/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "BabyGrowth.h"

@implementation BabyGrowth {
    
}

+ (instancetype)initBabyGrowthWithObj:(NSDictionary *)objbaby {
    BabyGrowth *result = [[BabyGrowth alloc] initWithDictionary:objbaby];
    return result;
}

- (instancetype)initWithDictionary:(NSDictionary *)data{
    self = [super init];
    if (self) {
        [self updateWithDictionary:data];
    }
    
    return self;
}

- (void)updateFromGrowth:(BabyGrowth*)growth{
    self.profileId = growth.profileId;
    self.growthId = growth.growthId;
    self.doctorNote = growth.doctorNote;
    self.headSize = growth.headSize;
    self.medicalRecordUrl = growth.medicalRecordUrl;
    self.parentNote = growth.parentNote;
    self.timeMeasure = growth.timeMeasure;
    self.height = growth.height;
    self.weight = growth.weight;
}

- (void)updateWithDictionary:(NSDictionary*)data{
    if(data == nil || data == (id)[NSNull null]) {
        return;
    }
    self.profileId = [Validator getSafeString:data[KEY_ProfileId]];
    self.growthId = [Validator getSafeString:data[KEY_Growth_ID]];
    self.doctorNote = [Validator getSafeString:data[KEY_DoctorNote]];
    self.headSize = [Validator getSafeString:data[KEY_HeadSize]];
    self.medicalRecordUrl = [Validator getSafeString:data[KEY_MedicalRecordUrl]];
    self.parentNote = [Validator getSafeString:data[KEY_ParentNote]];
    self.timeMeasure = [Validator getSafeString:data[KEY_TimeMeasure]];
    self.height = [Validator getSafeString:data[KEY_Height]];
    self.weight = [Validator getSafeString:data[KEY_Weight]];
    self.dateTime = [Validator getSafeString:data[KEY_datetime_record]];
}

- (void)updateWithDictionaryHeight:(NSDictionary*)data{
    if(data == nil || data == (id)[NSNull null]) {
        return;
    }
    self.profileId = [Validator getSafeString:data[KEY_ProfileId]];
    self.growthId = [Validator getSafeString:data[KEY_Growth_ID]];
    self.doctorNote = [Validator getSafeString:data[KEY_DoctorNote]];
    self.headSize = [Validator getSafeString:data[KEY_HeadSize]];
    self.medicalRecordUrl = [Validator getSafeString:data[KEY_MedicalRecordUrl]];
    self.parentNote = [Validator getSafeString:data[KEY_ParentNote]];
    self.timeMeasure = [Validator getSafeString:data[KEY_TimeMeasure]];
    self.height = [Validator getSafeString:data[KEY_Height]];
    self.dateTime = [Validator getSafeString:data[KEY_datetime_record]];
}

- (void)updateWithDictionaryWeight:(NSDictionary*)data{
    if(data == nil || data == (id)[NSNull null]) {
        return;
    }
    self.profileId = [Validator getSafeString:data[KEY_ProfileId]];
    self.growthWeightId = [Validator getSafeString:data[KEY_Growth_ID]];
    self.doctorNote = [Validator getSafeString:data[KEY_DoctorNote]];
    self.headSize = [Validator getSafeString:data[KEY_HeadSize]];
    self.medicalRecordUrl = [Validator getSafeString:data[KEY_MedicalRecordUrl]];
    self.parentNote = [Validator getSafeString:data[KEY_ParentNote]];
    self.timeMeasure = [Validator getSafeString:data[KEY_TimeMeasure]];
    self.weight = [Validator getSafeString:data[KEY_Weight]];
    self.dateTime = [Validator getSafeString:data[KEY_datetime_record]];
}

- (instancetype)initFromSample:(PHRSample*)sample {
    if (self = [super init]) {
        if ([sample.type isEqualToString:HKQuantityTypeIdentifierHeight]) {
            self.height = [@(roundf (100 * sample.value) / 100.0) stringValue];
        }
        else if ([sample.type isEqualToString:HKQuantityTypeIdentifierBodyMass]) {
            self.weight = [@(roundf (100 * sample.value) / 100.0) stringValue];
        }
        self.dateTime = [UIUtils stringUTCDate:sample.record_date withFormat:PHR_SERVER_DATE_TIME_FORMAT];
    }
    return self;
}

+ (PHRSample*)sampleFromDict:(NSDictionary*)dict type:(BabyGrowthType)type{
    PHRSample *sample = [[PHRSample alloc] init];
    sample.profile_id = PHRAppStatus.currentBaby.profileId;
    sample.type = [PHRSample healthkitTypeFromType:type fromScreen:PHRBabyGroupTypeGrowth];
    switch (type) {
        case BabyGrowthHeight:
            sample.value = [[Validator getSafeString:dict[KEY_Height]] doubleValue];
            break;
        case BabyGrowthWeight:
            sample.value = [[Validator getSafeString:dict[KEY_Weight]] doubleValue];
            break;
        default:
            break;
    }
    sample.record_date = [UIUtils dateFromServerTimeString:[Validator getSafeString:dict[KEY_datetime_record]]];
    sample.source_bundle = [PHRSample bundlePHRServer];
    
    return sample;
}


+ (BabyGrowth *)initializeBabySleepFromModel:(BabyGrowthModel *)model andDate:(NSString *)date {
    BabyGrowth *result = [BabyGrowth new];
    
    result.dateTime          = date;
    result.timeMeasure       = model.time_measure;
    result.headSize          = model.head_size;
    result.height            = model.height;
    result.weight            = model.weight;
    result.doctorNote        = model.doctor_note;
    result.parentNote        = model.parent_note;
    result.medicalRecordUrl  = model.medical_record_url;
    
    
    return result;
}

- (BabyGrowthModel*)getBabyGrowthModel {
    BabyGrowthModel *babyFoodModel = [[BabyGrowthModel alloc] init];
    babyFoodModel.growth_id = self.growthId;
    if (self.type == BabyGrowthHeight) {
        babyFoodModel.height = self.height;
        babyFoodModel.weight = nil;
    } else {
        babyFoodModel.height = nil;
         babyFoodModel.weight = self.weight;
    }


    babyFoodModel.time_measure = self.dateTime;
    babyFoodModel.type = [NSNumber numberWithInt:self.type];
    babyFoodModel.parent_note = @"";
    babyFoodModel.doctor_note = @"";
    return babyFoodModel;
}
@end
