//
//  BabyMilk.m
//  PHR
//
//  Created by DEV-MinhNN on 11/5/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "BabyMilk.h"

@implementation BabyMilk

+ (BabyMilk *)initializeBabyMilkFromObj:(NSDictionary *)dict andDate:(NSString *)date {
    BabyMilk *result = [[BabyMilk alloc] init];

    result.dateTime             = date;
    result.id_milk              = (int)[Validator getSafeInt:[dict objectForKey:KEY_Id]];
    result.alert                = (int)[Validator getSafeInt:[dict objectForKey:KEY_Alert]];
    result.drink_method         = [Validator getSafeString:[dict objectForKey:KEY_BabyMilk_Method]];
    result.time_drink_milk      = [Validator getSafeString:[dict objectForKey:KEY_BabyMilk_Time]];
    result.breast_time          = [Validator getSafeString:[dict objectForKey:KEY_BabyMilk_BreastTime]];
    result.bottle_milk_volume   = [Validator getSafeString:[dict objectForKey:KEY_BabyMilk_Bottle_Milk]];
    result.kcal                 = [Validator getSafeString:[dict objectForKey:KEY_Kcal]];
    result.milk_type            = [Validator getSafeString:[dict objectForKey:KEY_BabyMilk_Type]];
    result.note                 = [Validator getSafeString:[dict objectForKey:KEY_Note]];
    
    return result;
}

+ (BabyMilk *)initializeBabyMilkFromModel:(BabyMilkModel *)model andDate:(NSString *)date {
    BabyMilk *result = [[BabyMilk alloc] init];
    
    result.dateTime             = date;
    result.alert                = [model.alert intValue];
    result.drink_method         = model.drink_method;
    result.time_drink_milk      = model.time_drink_milk;
    result.breast_time          = model.breast_time;
    result.bottle_milk_volume   = model.bottle_milk_volume;
    result.kcal                 = model.calories;
    result.milk_type            = model.milk_type;
    result.note                 = model.note;
    
    return result;
}
   
@end
