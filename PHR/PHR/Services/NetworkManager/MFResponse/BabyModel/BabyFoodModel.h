//
//  BabyFoodModel.h
//  PHR
//
//  Created by DEV-MinhNN on 11/16/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <JSONModel/JSONModel.h>

@protocol BabyFoodModel
@end

@interface BabyFoodModel : JSONModel

@property (nonatomic, strong) NSString<Optional> *food_id;
@property (nonatomic, strong) NSString<Optional> *eating_time;
@property (nonatomic, strong) NSString<Optional> *food;
@property (nonatomic, strong) NSString<Optional> *image_url;
@property (nonatomic, strong) NSString<Optional> *calories;
@property (nonatomic, strong) NSString<Optional> *meal_type;
@property (nonatomic, strong) NSString<Optional> *note;
@property (nonatomic, strong) NSString<Optional> *profile_id;

@end
