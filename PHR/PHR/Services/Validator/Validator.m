//
//  Validator.m
//  PHR
//
//  Created by DEV-CongHT on 10/10/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "Validator.h"

@implementation Validator

+ (NSInteger)getSafeInt:(id)obj {
    
    if (obj == nil || [obj isKindOfClass:[NSNull class]]) {
        return 0;
    }
    if ([obj isKindOfClass:[NSNumber class]]) {
        return [obj integerValue];
    }
    if ([obj length] == 0) {
        return 0;
    }
    if ([obj isKindOfClass:[NSDictionary class]]) {
        return 0;
    }
    return [obj intValue];
}

+ (CGFloat)getSafeFloat:(id)obj {
    
    if (obj == nil || [obj isKindOfClass:[NSNull class]]) {
        return 0.0;
    }
    if ([obj isKindOfClass:[NSNumber class]]) {
        return [obj floatValue];
    }
    if ([obj length] == 0) {
        return 0.0;
    }
    if ([obj isKindOfClass:[NSDictionary class]]) {
        return 0.0;
    }
    return [obj floatValue];
}

+ (BOOL)getSafeBool:(id)obj {
    if (obj == nil || [obj isKindOfClass:[NSNull class]]) {
        return NO;
    }
    if ([obj isKindOfClass:[NSNumber class]]) {
        return [obj boolValue];
    }
    if ([obj length] == 0) {
        return NO;
    }
    if ([obj isKindOfClass:[NSDictionary class]]) {
        return NO;
    }
    return [obj boolValue];
}

+ (NSString *)getSafeString:(id)obj {
    if (obj == nil || [obj isKindOfClass:[NSNull class]]) {
        return @"";
    }
    if ([obj isKindOfClass:[NSString class]]) {
        return obj;
    }
    if ([obj isKindOfClass:[NSDictionary class]]) {
        return @"";
    }
    return [obj stringValue];
}



#pragma mark Checking functions

+ (BOOL)isNullOrNilObject:(id)object {
    if ([object isKindOfClass:[NSNull class]]) {
        return YES;
    }
    if (object == nil) {
        return YES;
    }
    if ([object isKindOfClass:[NSString class]]) {
        if ([object isEqualToString:@"nil"]) {
            return YES;
        }
    }
    return NO;
}

+ (BOOL)isValidObject:(id)object {
    return ![Validator isNullOrNilObject:object];
}

@end
