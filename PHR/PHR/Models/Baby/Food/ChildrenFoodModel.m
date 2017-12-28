//
//  ChildrenFoodModel.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "ChildrenFoodModel.h"

@implementation ChildrenFoodModel

- (id)initWithCalories:(NSString*)calories food:(NSString*)food imageUrl:(NSString*)imageUrl mealType:(NSString*)mealType date:(NSString*)date note:(NSString*)note {
    self = [super init];
    if (self) {
        self.kcal = calories;
        self.food = food;
        self.imageUrl = imageUrl;
        self.date = date;
        self.note = note;
        self.mealType = mealType;
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
    ChildrenFoodModel *result = [[ChildrenFoodModel alloc] initWithDictionary:obj];
    return result;
}

- (void)updateWithDictionary:(NSDictionary*)data {
    self.childrenFoodID = [Validator getSafeString:data[KEY_Baby_Food_Id]];
    self.kcal = [Validator getSafeString:data[KEY_BabyFood_Kcal]];
    self.food = [Validator getSafeString:data[KEY_BabyFood]];
    self.mealType = [Validator getSafeString:data[KEY_BabyFood_Meal_Type]];
    self.imageUrl = [Validator getSafeString:data[KEY_BabyFood_ImgURL]];
    self.date = [Validator getSafeString:data[KEY_Eating_Time]];
    self.note = [Validator getSafeString:data[KEY_Note]];
}

- (BabyFoodModel*)getBabyFoodModel {
    BabyFoodModel *babyFoodModel = [[BabyFoodModel alloc] init];
    babyFoodModel.food_id = self.childrenFoodID;
    babyFoodModel.calories = self.kcal;
    babyFoodModel.food = self.food;
    babyFoodModel.meal_type = self.mealType;
    babyFoodModel.eating_time = self.date;
    babyFoodModel.note = self.note;
    return babyFoodModel;
}

- (PHRSample*)sampleFromModel {
    PHRSample *sample = [[PHRSample alloc] init];
    sample.profile_id = PHRAppStatus.currentBaby.profileId;
    sample.type = HKQuantityTypeIdentifierDietaryEnergyConsumed;
    sample.record_date = [UIUtils dateFromServerTimeString:self.date];
    sample.value = [self.kcal doubleValue];
    sample.source_bundle = [PHRSample bundlePHRServer];
    
    return sample;
}
@end
