//
//  FoodItem.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/30/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "FoodItem.h"
#import "PHRSample.h"

@implementation FoodItem

- (id)initFoodWithCalories:(NSString*)calories carbohydrates:(NSString*)carbohydrates totalFat:(NSString*)totalFat atingSatisfied:(NSString*)ratingSatisfied type:(int)type date:(NSString*)date note:(NSString*)note {
    self = [super init];
    if (self) {
        self.calories = calories;
        self.carbohydrates = carbohydrates;
        self.totalFat = totalFat;
        self.date = date;
        self.note = note;
        self.type = type;
        self.ratingSatisfied = ratingSatisfied;
    }
    return self;
}

- (instancetype)initWithDictionary:(NSDictionary *)data {
    self = [super init];
    if (self) {
        [self updateWithDictionary:data];
    }
    return self;
}

+ (instancetype)initWithObj:(NSDictionary *)obj {
    FoodItem *result = [[FoodItem alloc] initWithDictionary:obj];
    return result;
}

- (void)updateWithDictionary:(NSDictionary*)data {
    self.foodID = [Validator getSafeString:data[KEY_Food_ID]];
    self.calories = [Validator getSafeString:data[KEY_Calories]];
    self.carbohydrates = [Validator getSafeString:data[KEY_Carbohydrate]];
    self.totalFat = [Validator getSafeString:data[KEY_Total_Fat]];
    self.date = [Validator getSafeString:data[KEY_Eating_Time]];
    self.note = [Validator getSafeString:data[KEY_Note]];
    self.ratingSatisfied = [Validator getSafeString:data[KEY_Rating_Satisfied]];
}

- (instancetype)initFromSample:(PHRSample*)sample {
    if (self = [super init]) {
        if ([sample.type isEqualToString:HKQuantityTypeIdentifierDietaryEnergyConsumed]) {
            self.calories = [@(roundf (100 * sample.value) / 100.0) stringValue];
        }
        else if ([sample.type isEqualToString:HKQuantityTypeIdentifierDietaryCarbohydrates]) {
            self.carbohydrates = [@(roundf (100 * sample.value) / 100.0) stringValue];
        }
        else if ([sample.type isEqualToString:HKQuantityTypeIdentifierDietaryFatTotal]) {
            self.totalFat = [@(roundf (100 * sample.value) / 100.0) stringValue];
        }
        self.date = [UIUtils stringUTCDate:sample.record_date withFormat:PHR_SERVER_DATE_TIME_FORMAT];
    }
    return self;
}

+ (PHRSample*)sampleFromDict:(NSDictionary*)dict type:(FoodType)type{
    PHRSample *sample = [[PHRSample alloc] init];
    sample.profile_id = PHRAppStatus.currentStandard.profileId;
    sample.type = [PHRSample healthkitTypeFromType:type fromScreen:StandardHomeTypeFood];
    switch (type) {
        case ChartFoodTypeCalories:
            sample.value = [[Validator getSafeString:dict[KEY_Calories]] doubleValue];
            break;
        case ChartFoodTypeTotalFat:
            sample.value = [[Validator getSafeString:dict[KEY_Total_Fat]] doubleValue];
            break;
        case ChartFoodTypeCarbohydrates:
            sample.value = [[Validator getSafeString:dict[KEY_Carbohydrate]] doubleValue];
            break;
    }
    sample.record_date = [UIUtils dateFromServerTimeString:[Validator getSafeString:dict[KEY_Eating_Time]]];
    sample.source_bundle = [PHRSample bundlePHRServer];
    
    return sample;
}


@end
