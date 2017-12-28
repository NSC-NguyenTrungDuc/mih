//
//  Food.h
//  PHR
//
//  Created by DEV-MinhNN on 11/13/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "BabyFoodModel.h"

@interface Food : NSObject

@property (nonatomic, strong) NSString *eating_time;
@property (nonatomic, strong) NSString *food;
@property (nonatomic, strong) NSString *image_url;
@property (nonatomic, strong) NSString *kcal;
@property (nonatomic, strong) NSString *meal_type;
@property (nonatomic, strong) NSString *note;
@property (nonatomic, strong) NSString *dateTime;

+ (Food *)initializeBabyFoodFromModel:(BabyFoodModel *)model andDate:(NSString *)date;

@end
