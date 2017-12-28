//
//  NumberUtils.m
//  PHR
//
//  Created by Luong Le Hoang on 6/6/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "NumberUtils.h"

@implementation NumberUtils

+ (NSNumberFormatter*)formatter{
    static NSNumberFormatter *formatter = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        formatter = [[NSNumberFormatter alloc] init];
    });
    return formatter;
}

+ (NSString*)stringFromFloat:(float)value maxFraction:(int)max{
    NSNumberFormatter *formatter = [self formatter];
    formatter.maximumFractionDigits = 2;
    return [formatter stringFromNumber:[NSNumber numberWithFloat:value]];
}

@end
