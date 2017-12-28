//
//  FoodItem.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/30/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface FoodItem : NSObject


@property (nonatomic, strong) NSString *foodID;
@property (nonatomic, strong) NSString *date;
@property (nonatomic, strong) NSString *note;

@property (nonatomic, strong) NSString *calories;
@property (nonatomic, strong) NSString *carbohydrates;
@property (nonatomic, strong) NSString *totalFat;

@property (nonatomic, strong) NSString *ratingSatisfied;
@property (nonatomic) int type;

- (id)initFoodWithCalories:(NSString*)calories carbohydrates:(NSString*)carbohydrates totalFat:(NSString*)totalFat atingSatisfied:(NSString*)ratingSatisfied type:(int)type date:(NSString*)date note:(NSString*)note;
+ (instancetype)initWithObj:(NSDictionary *)obj;
- (void)updateWithDictionary:(NSDictionary*)data;
+ (PHRSample*)sampleFromDict:(NSDictionary*)dict type:(FoodType)type;
- (instancetype)initFromSample:(PHRSample*)sample;

@end
