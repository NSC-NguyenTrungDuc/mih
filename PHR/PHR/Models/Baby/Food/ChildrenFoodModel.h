//
//  ChildrenFoodModel.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface ChildrenFoodModel : NSObject

@property (nonatomic, strong) NSString *childrenFoodID;
@property (nonatomic, strong) NSString *date;
@property (nonatomic, strong) NSString *food;
@property (nonatomic, strong) NSString *imageUrl;
@property (nonatomic, strong) NSString *kcal;
@property (nonatomic, strong) NSString *mealType;
@property (nonatomic, strong) NSString *note;

- (id)initWithCalories:(NSString*)calories food:(NSString*)food imageUrl:(NSString*)imageUrl mealType:(NSString*)mealType date:(NSString*)date note:(NSString*)note;
+ (instancetype)initWithObj:(NSDictionary *)obj;
- (void)updateWithDictionary:(NSDictionary*)data;
- (BabyFoodModel*)getBabyFoodModel;
- (PHRSample*)sampleFromModel;
@end
