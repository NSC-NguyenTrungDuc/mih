//
//  BabyBaseItem.h
//  PHR
//
//  Created by Luong Le Hoang on 10/16/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface BabyBaseItem : NSObject {
    
}
@property (nonatomic, assign) PHRBabyGroupType type;

+ (BabyBaseItem*)itemWithType:(PHRBabyGroupType)type;

@end
