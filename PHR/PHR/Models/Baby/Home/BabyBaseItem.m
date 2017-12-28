//
//  BabyBaseItem.m
//  PHR
//
//  Created by Luong Le Hoang on 10/16/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "BabyBaseItem.h"

@implementation BabyBaseItem {
    
}

+ (BabyBaseItem*)itemWithType:(PHRBabyGroupType)type{
    BabyBaseItem *item = [[BabyBaseItem alloc] init];
    item.type = type;
    return item;
}

@end
