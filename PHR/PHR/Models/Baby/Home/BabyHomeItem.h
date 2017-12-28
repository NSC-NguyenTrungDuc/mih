//
//  BabyHomeItem.h
//  PHR
//
//  Created by Luong Le Hoang on 10/16/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "BabyBaseItem.h"

@interface BabyHomeItem : NSObject {
    
}
@property (nonatomic, assign) PHRBabyGroupType type;
@property (nonatomic, strong) NSMutableArray *arrayItems;

+ (BabyHomeItem*)itemWithType:(PHRBabyGroupType)type;

@end
