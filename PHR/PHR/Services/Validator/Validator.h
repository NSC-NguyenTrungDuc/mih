//
//  Validator.h
//  PHR
//
//  Created by DEV-CongHT on 10/10/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Validator : NSObject

+ (NSInteger)getSafeInt:(id)obj;
+ (CGFloat)getSafeFloat:(id)obj;
+ (BOOL)getSafeBool:(id)obj;
+ (NSString *)getSafeString:(id)obj;
+ (BOOL)isNullOrNilObject:(id)object;
+ (BOOL)isValidObject:(id)object;

@end
