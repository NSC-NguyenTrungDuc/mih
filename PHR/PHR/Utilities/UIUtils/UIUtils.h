//
//  UIUtils.h
//  PHR
//
//  Created by DEV-MinhNN on 9/29/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface UIUtils : NSObject {
    
}

+ (NSString *)stringUTCFromDateTime:(NSDate *)dateTime;
// Create UIImage from Color and Size
+ (UIImage *)imageFromColor:(UIColor *)color forSize:(CGSize)size withCornerRadius:(CGFloat)radius;
// Calculate text size
+ (CGSize)sizeForString:(NSString*)text andFont:(UIFont*)font;

// Date formatter
+ (NSString *)stringyyyyMMddFromDate:(NSDate *)dateTime;
+ (NSString *)formatDateMonthStyle:(NSDate *)dateTime;
+ (NSString *)formatDateJapaneseStyle:(NSDate *)dateTime;
+ (NSString *)formatTimeStyle:(NSDate *)dateTime;
+ (NSString *)formatTimeGetHours:(NSDate *)dateTime;
+ (NSString *)formatTimeGet24Hours:(NSDate *)dateTime;
+ (NSString *)formatTimeGetAmOrPm:(NSDate *)dateTime;
+ (NSString *)formatDateAnd24TimeStyle:(NSDate *)dateTime;
+ (NSString *)remiderTimeStringFromDate:(NSDate *)dateTime;
+ (NSString*)stringDate:(NSDate*)date withFormat:(NSString*)format;
+ (NSString*)stringUTCDate:(NSDate*)date withFormat:(NSString*)format;
+ (NSDate*)dateFromString:(NSString*)date withFormat:(NSString *)format;
+ (NSDate *)dateUTCFromString:(NSString *)inputString withFormat:(NSString*)format;
+ (NSDate*)convertDateUTCDate:(NSDate*)date withFormat:(NSString*)format;
+ (NSDateFormatter*)localDateFormatter;
+ (NSDate *)dateFromServerTimeString:(NSString *)inputString;
+ (NSDate *)dateFromServerShortTimeString:(NSString *)inputString;
+ (NSString *)stringFromColor:(UIColor *)color;
+ (NSString *)formatDateOppositeStyle:(NSDate *)dateTime;
+ (NSString *)formatTimeGetHoursMinutes:(NSDate *)dateTime;
+ (BOOL)isNullOrEmpty:(NSString *)inString;
+ (UIColor *)colorFromHexString:(NSString *)hexString;

+ (UIImage *) screenshot:(UIView*)view ;
+ (void)setGradientColorWithLeft:(UIColor *)leftColor andRight:(UIColor *)rightColor forView:(UIView *)view;
+ (void)setCornerRadiusToCirle:(UIView *)view;
@end
