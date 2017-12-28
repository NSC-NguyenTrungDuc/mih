//
//  BackgroundSettingInfo.m
//  PHR
//
//  Created by NextopHN on 3/24/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BackgroundSettingInfo.h"

@implementation BackgroundSettingInfo

// Specify default values for properties

+ (NSDictionary *)defaultPropertyValues
{
    return @{};
}

// Specify properties to ignore (Realm won't persist these)

+ (NSArray *)ignoredProperties
{
    return @[];
}

//+ (NSString *)primaryKey {
//    return @"Id";
//}
@end
