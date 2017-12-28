//
//  LocalStorageImage.m
//  PHR
//
//  Created by NextopHN on 4/1/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "LocalStorageImage.h"

@implementation LocalStorageImage

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
