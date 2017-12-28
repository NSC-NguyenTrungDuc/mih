//
//  BabyHomeItem.m
//  PHR
//
//  Created by Luong Le Hoang on 10/16/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "BabyHomeItem.h"

@implementation BabyHomeItem {
    
}

+ (BabyHomeItem*)itemWithType:(PHRBabyGroupType)type{
    BabyHomeItem *item = [[BabyHomeItem alloc] init];
    item.type = type;
    return item;
}

@end
