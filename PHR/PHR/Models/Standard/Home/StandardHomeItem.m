//
//  StandardHomeItem.m
//  PHR
//
//  Created by Luong Le Hoang on 10/3/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "StandardHomeItem.h"
#import "NumberUtils.h"

@implementation StandardHomeItem{
    
}

- (instancetype)init{
    if (self = [super init]) {
        self.isDisplay = YES;
    }
    return self;
}

+ (id)initWithType:(StandardHomeType)type name:(NSString*)name subUnit:(NSString*)subUnit value:(float)value isPercent:(BOOL)isPercent{
    StandardHomeItem *item = [[StandardHomeItem alloc] init];
    item.type = type;
    item.name = name;
    item.subUnit = subUnit;
    item.value = value;
    item.isPercent = isPercent;
    
    item.isDisplay = NO;
    
    if (type == StandardHomeTypeLifeStyle) {
        int hour = value/3600;
        int minute = (value - hour * 3600)/60;
        item.contentDisplay = [NSString stringWithFormat:@"%02d:%02d", hour, minute];
    }
    else if (value > 0){
        item.contentDisplay = [NumberUtils stringFromFloat:value maxFraction:2];
    }
    else{
        item.contentDisplay = nil;
    }
    [item calculateProgress];
    return item;
}

+ (id)initWithType:(StandardHomeType)type name:(NSString*)name content:(NSString*)content subUnit:(NSString*)subUnit situation:(MasterDataRate)situation{
    StandardHomeItem *item = [[StandardHomeItem alloc] init];
    item.type = type;
    item.name = name;
    item.subUnit = subUnit;
    item.contentDisplay = content;
    item.situation = situation;
    return item;
}

- (void)calculateProgress{
    switch (self.type) {
        case StandardHomeTypeLifeStyle:
            _progress = self.value/((float)8 * 3600 /* 8 hours */);
            break;
        default:
            _progress = self.value/100.;
            break;
    }
}

@end
