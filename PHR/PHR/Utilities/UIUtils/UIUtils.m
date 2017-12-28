//
//  UIUtils.m
//  PHR
//
//  Created by DEV-MinhNN on 9/29/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "UIUtils.h"

@implementation UIUtils

// ---- Create UIImage from UIColor and Size
+ (UIImage *)imageFromColor:(UIColor *)color forSize:(CGSize)size withCornerRadius:(CGFloat)radius
{
    CGRect rect = CGRectMake(0, 0, size.width, size.height);
    UIGraphicsBeginImageContext(rect.size);
    CGContextRef context = UIGraphicsGetCurrentContext();
    CGContextSetFillColorWithColor(context, [color CGColor]);
    CGContextFillRect(context, rect);
    UIImage *image = UIGraphicsGetImageFromCurrentImageContext();
    UIGraphicsEndImageContext();
    
    // Begin a new image that will be the new image with the rounded corners
    // (here with the size of an UIImageView)
    UIGraphicsBeginImageContext(size);
    
    // Add a clip before drawing anything, in the shape of an rounded rect
    [[UIBezierPath bezierPathWithRoundedRect:rect cornerRadius:radius] addClip];
    // Draw your image
    [image drawInRect:rect];
    
    // Get the image, here setting the UIImageView image
    image = UIGraphicsGetImageFromCurrentImageContext();
    
    // Lets forget about that we were drawing
    UIGraphicsEndImageContext();
    return image;
}

//Format Date Style

//+ (NSDateFormatter*)dateFormatter{
//    static NSDateFormatter *dateFormat = nil;
//    static dispatch_once_t onceToken;
//    dispatch_once(&onceToken, ^{
//        dateFormat = [[NSDateFormatter alloc] init];
//        if (IOS_VERSION >= 8) {
//            dateFormat.calendar = [NSCalendar calendarWithIdentifier:NSCalendarIdentifierGregorian];
//        }
//        else{
//            NSCalendar *calendar = [[NSCalendar alloc] initWithCalendarIdentifier:NSCalendarIdentifierGregorian];
//            dateFormat.calendar = calendar;
//        }
//        [dateFormat setTimeZone:[NSTimeZone timeZoneWithName:@"JST"]];
//    });
//    return dateFormat;
//}

+ (NSDateFormatter*)serverDateFormatter{
    static NSDateFormatter *dateFormat = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        dateFormat = [[NSDateFormatter alloc] init];
        if (IOS_VERSION >= 8) {
            dateFormat.calendar = [NSCalendar calendarWithIdentifier:NSCalendarIdentifierGregorian];
        }
        else{
            NSCalendar *calendar = [[NSCalendar alloc] initWithCalendarIdentifier:NSCalendarIdentifierGregorian];
            dateFormat.calendar = calendar;
        }
        [dateFormat setTimeZone:[NSTimeZone timeZoneWithName:@"UTC"]];
    });
    return dateFormat;
}

+ (NSDateFormatter*)localDateFormatter {
    static NSDateFormatter *dateFormat = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        dateFormat = [[NSDateFormatter alloc] init];
        if (IOS_VERSION >= 8) {
            dateFormat.calendar = [NSCalendar calendarWithIdentifier:NSCalendarIdentifierGregorian];
        }
        else{
            NSCalendar *calendar = [[NSCalendar alloc] initWithCalendarIdentifier:NSCalendarIdentifierGregorian];
            dateFormat.calendar = calendar;
        }
        [dateFormat setTimeZone:[NSTimeZone localTimeZone]];
    });
    return dateFormat;
}

+ (NSString *)stringUTCFromDateTime:(NSDate *)dateTime {
    NSDateFormatter *dateFormat = [self serverDateFormatter];
    [dateFormat setDateFormat:PHR_SERVER_DATE_TIME_FORMAT];
    return [dateFormat stringFromDate:dateTime];
}

+ (NSString *)stringyyyyMMddFromDate:(NSDate *)dateTime {
    NSDateFormatter *dateFormat = [self localDateFormatter];
    [dateFormat setDateFormat:@"yyyy/MM/dd"];
    return [dateFormat stringFromDate:dateTime];
}

+ (NSString *)formatDateMonthStyle:(NSDate *)dateTime {
    NSDateFormatter *dateFormat = [self localDateFormatter];
    [dateFormat setDateFormat:@"MM-dd"];
    return [dateFormat stringFromDate:dateTime];
}

+ (NSString *)formatDateJapaneseStyle:(NSDate *)dateTime {
    NSDateFormatter *dateFormat = [self localDateFormatter];
    [dateFormat setDateFormat:@"yyyy年MM月dd日"];
    return [dateFormat stringFromDate:dateTime];
}

+ (NSString *)formatDateAnd24TimeStyle:(NSDate *)dateTime {
    NSDateFormatter *dateFormat = [self localDateFormatter];
    [dateFormat setDateFormat:@"HH:mm yyyy/MM/dd"];
    return [dateFormat stringFromDate:dateTime];
}

+ (NSString *)formatDateOppositeStyle:(NSDate *)dateTime {
    NSDateFormatter *dateFormat = [self localDateFormatter];
    [dateFormat setDateFormat:@"yyyy/MM/dd"];
    return [dateFormat stringFromDate:dateTime];
}


+ (NSString *)formatTimeStyle:(NSDate *)dateTime {
    NSDateFormatter *dateFormat = [self localDateFormatter];
    [dateFormat setDateFormat:@"hh:mm a"];
    return [dateFormat stringFromDate:dateTime];
}

+ (NSString *)formatTimeGetHours:(NSDate *)dateTime {
    NSDateFormatter *dateFormat = [self localDateFormatter];
    [dateFormat setDateFormat:@"hh"];
    return [dateFormat stringFromDate:dateTime];
}

+ (NSString *)formatTimeGet24Hours:(NSDate *)dateTime {
    NSDateFormatter *dateFormat = [self localDateFormatter];
    [dateFormat setDateFormat:@"HH"];
    return [dateFormat stringFromDate:dateTime];
}

+ (NSString *)formatTimeGetHoursMinutes:(NSDate *)dateTime {
    NSDateFormatter *dateFormat = [self localDateFormatter];
    [dateFormat setDateFormat:@"hh:mm"];
    return [dateFormat stringFromDate:dateTime];
}

+ (NSString *)formatTimeGetAmOrPm:(NSDate *)dateTime {
    NSDateFormatter *dateFormat = [self localDateFormatter];
    [dateFormat setDateFormat:@"a"];
    return [dateFormat stringFromDate:dateTime];
}

+ (NSDate *)dateFromServerTimeString:(NSString *)inputString {
    NSDateFormatter *inputDateFormatter = [self serverDateFormatter]; // time from server UTC+0
    [inputDateFormatter setDateFormat:PHR_SERVER_DATE_TIME_FORMAT];
    return [inputDateFormatter dateFromString:inputString];
}

+ (NSDate *)dateUTCFromString:(NSString *)inputString withFormat:(NSString*)format{
    NSDateFormatter *inputDateFormatter = [self serverDateFormatter]; // time from server UTC+0
    [inputDateFormatter setDateFormat:format];
    return [inputDateFormatter dateFromString:inputString];
}

+ (NSDate *)dateFromServerShortTimeString:(NSString *)inputString{
    NSDateFormatter *inputDateFormatter = [self localDateFormatter];
    [inputDateFormatter setDateFormat:PHR_SERVER_DATE_SHORT_FORMAT];
    return [inputDateFormatter dateFromString:inputString];
}

+ (NSString *)remiderTimeStringFromDate:(NSDate *)dateTime {
    NSDateFormatter *dateFormat = [self localDateFormatter];
    [dateFormat setDateFormat:@"hh:mm a"];
    return [dateFormat stringFromDate:dateTime];
}

+ (NSString*)stringDate:(NSDate*)date withFormat:(NSString*)format{
    NSDateFormatter *dateFormat = [self localDateFormatter];
    [dateFormat setDateFormat:format];
    return [dateFormat stringFromDate:date];
}

+ (NSString*)stringUTCDate:(NSDate*)date withFormat:(NSString*)format{
    NSDateFormatter *dateFormat = [self serverDateFormatter];
    [dateFormat setDateFormat:format];
    return [dateFormat stringFromDate:date];
}

+ (NSDate*)convertDateUTCDate:(NSDate*)date withFormat:(NSString*)format {
    NSDateFormatter *dateFormat = [self serverDateFormatter];
    [dateFormat setDateFormat:format];
    return [dateFormat dateFromString:[dateFormat stringFromDate:date]];
}

+ (NSDate*)dateFromString:(NSString*)date withFormat:(NSString *)format{
    NSDateFormatter *dateFormat = [self localDateFormatter];
    [dateFormat setDateFormat:format];
    return [dateFormat dateFromString:date];
}

// Calculate size for text
+ (CGSize)sizeForString:(NSString*)text andFont:(UIFont*)font {
    CGSize size = [text sizeWithAttributes:@{NSFontAttributeName:font}];
    return size;
}


+ (NSString *)stringFromColor:(UIColor *)color {
    const size_t totalComponents = CGColorGetNumberOfComponents(color.CGColor);
    const CGFloat * components = CGColorGetComponents(color.CGColor);
    return [NSString stringWithFormat:@"#%02X%02X%02X",
            (int)(255 * components[MIN(0,totalComponents-2)]),
            (int)(255 * components[MIN(1,totalComponents-2)]),
            (int)(255 * components[MIN(2,totalComponents-2)])];
}

+ (BOOL)isNullOrEmpty:(NSString *)inString {
    BOOL retVal = YES;
    if( inString != nil ) {
        if( [inString isKindOfClass:[NSString class]]) {
            retVal = inString.length == 0;
        }
        else {
            DLog(@"isNullOrEmpty, value not a string");
        }
    }
    return retVal;
}

+ (UIColor *)colorFromHexString:(NSString *)hexString {
    unsigned rgbValue = 0;
    NSScanner *scanner = [NSScanner scannerWithString:hexString];
    [scanner setScanLocation:[hexString rangeOfString:@"#"].location+1];
    [scanner scanHexInt:&rgbValue];
    return [UIColor colorWithRed:((rgbValue & 0xFF0000) >> 16)/255.0 green:((rgbValue & 0xFF00) >> 8)/255.0 blue:(rgbValue & 0xFF)/255.0 alpha:1.0];
}

+ (UIImage *) screenshot:(UIView*)view {
    
    UIGraphicsBeginImageContextWithOptions(view.bounds.size, NO, [UIScreen mainScreen].scale);
    
    [view drawViewHierarchyInRect:view.bounds afterScreenUpdates:YES];
    
    UIImage *image = UIGraphicsGetImageFromCurrentImageContext();
    UIGraphicsEndImageContext();
    return image;
    return image;
}

+ (void)setGradientColorWithLeft:(UIColor *)leftColor andRight:(UIColor *)rightColor forView:(UIView *)view {
    CAGradientLayer *gradient = [CAGradientLayer layer];
    gradient.frame            = view.bounds;
    gradient.colors           = [NSArray arrayWithObjects:(id)[leftColor CGColor], (id)[rightColor CGColor], nil];
    [view.layer insertSublayer:gradient atIndex:0];
}

+ (void)setCornerRadiusToCirle:(UIView *)view {
    [view.layer setCornerRadius:view.frame.size.width/2];
    [view.layer setMasksToBounds:YES];
}

@end
