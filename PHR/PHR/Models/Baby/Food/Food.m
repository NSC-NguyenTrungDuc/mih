//
//  Food.m
//  PHR
//
//  Created by DEV-MinhNN on 11/13/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "Food.h"

@implementation Food

+ (Food *)initializeBabyFoodFromModel:(BabyFoodModel *)model andDate:(NSString *)date {
    Food *food = [Food new];
    
    food.dateTime       = date;
    food.eating_time    = model.eating_time;
    food.food           = model.food;
    food.image_url      = model.image_url;
    food.kcal           = model.calories;
    food.meal_type      = model.meal_type;
    food.note           = model.note;
    
    return food;
}

@end
