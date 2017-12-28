//
//  StandardHomeItem.h
//  PHR
//
//  Created by Luong Le Hoang on 10/3/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MasterDataManager.h"


@interface StandardHomeItem : NSObject{
    
}
@property (nonatomic, assign) StandardHomeType type;
@property (nonatomic, strong) NSString *name;
@property (nonatomic, strong) NSString *subUnit;
@property (nonatomic, assign, readonly) float progress;
@property (nonatomic, assign) BOOL isPercent;
@property (nonatomic, strong) NSString *contentDisplay;
@property (nonatomic, assign) float value;
@property (nonatomic, assign) MasterDataRate situation;
@property (nonatomic, assign) BOOL isDisplay;

+ (id)initWithType:(StandardHomeType)type name:(NSString*)name subUnit:(NSString*)subUnit value:(float)value isPercent:(BOOL)isPercent;
//+ (id)initWithType:(StandardHomeType)type name:(NSString*)name content:(NSString*)content subUnit:(NSString*)subUnit situation:(MasterDataRate)situation;

@end
