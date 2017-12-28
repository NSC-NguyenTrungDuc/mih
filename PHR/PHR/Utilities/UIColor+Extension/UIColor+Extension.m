
//
//  UIColor+Extension.m
//  PHR
//
//  Created by NextopHN on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "UIColor+Extension.h"

@implementation PHRUIColor
+(UIColor*)colorFromHex:(NSString*)hexStr alpha:(CGFloat)alpha{
    hexStr = [hexStr stringByReplacingOccurrencesOfString:@"#" withString:@""];
    NSScanner* scanner = [NSScanner scannerWithString:hexStr];
    UInt32 color = 0;
    if ([scanner scanHexInt:&color]) {
        CGFloat red   = ((color & 0xFF0000) >> 16) / 255.0f;
        CGFloat green = ((color & 0x00FF00) >>  8) / 255.0f;
        CGFloat blue  =  (color & 0x0000FF) / 255.0f;
        return [UIColor colorWithRed:red green:green blue:blue alpha:alpha];
    } else {
        return [UIColor whiteColor];
    }
}

+(UIColor*)colorTagTableDarkWithAlpha:(CGFloat)alpha{
    return [self colorFromHex:@"#80c462" alpha:alpha];
}
+(UIColor*)colorTagTableLightWithAlpha:(CGFloat)alpha{
    return [self colorFromHex:@"#9ad480" alpha:alpha];
}

+(UIColor*)colorOrderTableDarkWithAlpha:(CGFloat)alpha{
    return [self colorFromHex:@"#47abc9" alpha:alpha];
}
+(UIColor*)colorOrderTableLightWithAlpha:(CGFloat)alpha{
    return [self colorFromHex:@"#86cde2" alpha:alpha];
}
+(UIColor*)colorProgressCourseTableCellWithAlpha:(CGFloat)alpha{
    return [self colorFromHex:@"#f3f3f3" alpha:alpha];
}
+(UIColor*)colorBodyMeasurementTabbarHeaderBackground:(CGFloat)alpha{
    return [self colorFromHex:@"#36c7d1" alpha:alpha];
}

@end
