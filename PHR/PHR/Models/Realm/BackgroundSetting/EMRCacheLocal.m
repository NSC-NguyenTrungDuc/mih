//
//  EMRCacheLocal.m
//  PHR
//
//  Created by NextopHN on 5/23/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "EMRCacheLocal.h"

@implementation EMRCacheLocal
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
@end
