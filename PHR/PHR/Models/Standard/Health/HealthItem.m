//
//  HealthItem.m
//  PHR
//
//  Created by Luong Le Hoang on 10/26/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "HealthItem.h"

@implementation HealthItem
+ (instancetype)initHealthWithObj:(NSDictionary *)objHealth {
    HealthItem *result = [[HealthItem alloc] initWithDictionary:objHealth];
    return result;
}

- (instancetype)initWithDictionary:(NSDictionary *)data{
    self = [super init];
    if (self) {
        [self updateWithDictionary:data];
    }
    
    return self;
}

- (void)updateFromHealth:(HealthItem*)health{
    self.profileId = health.profileId;
    self.healthId = health.healthId;
    self.lowBloodPress = health.lowBloodPress;
    self.highBloodPress = health.highBloodPress;
    self.dateRecord = health.dateRecord;
    self.height = health.height;
    self.weight = health.weight;
    self.waistLine = health.waistLine;
    self.chestSize = health.chestSize;
    self.bmi = health.bmi;
    self.healthType = health.healthType;
}

- (void)updateWithDictionary:(NSDictionary*)data{
    self.profileId = [Validator getSafeString:data[KEY_ProfileId]];
    self.healthId = [Validator getSafeString:data[KEY_Id]];
    self.dateRecord = [Validator getSafeString:data[KEY_DateRecord]];
    self.highBloodPress = [Validator getSafeString:data[KEY_HighBloodPress]];
    self.lowBloodPress = [Validator getSafeString:data[KEY_LowBloodPress]];
    self.height = [Validator getSafeString:data[KEY_Height]];
    self.weight = [Validator getSafeString:data[KEY_Weight]];
    self.chestSize = [Validator getSafeString:data[KEY_ChestSize]];
    self.waistLine = [Validator getSafeString:data[KEY_WaistLine]];
    self.bmi = [Validator getSafeString:data[KEY_BMI]];
}

+ (HealthItem *)initializeHealthFromModel:(StandardHealthModel *)model andDate:(NSString *)date {
    HealthItem *result = [HealthItem new];
    result.healthId          = model.id;
    result.dateTime          = date;
    result.chestSize         = model.chest_size;
    result.waistLine         = model.waist_line;
    result.dateRecord        = model.datetime_record;
    result.highBloodPress    = model.high_blood_press;
    result.lowBloodPress     = model.low_blood_press;
    result.height            = model.height;
    result.weight            = model.weight;
    result.bmi               = model.bmi;
    return result;
}
@end
