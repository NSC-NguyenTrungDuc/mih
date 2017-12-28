//
//  UIColor+Extension.h
//  PHR
//
//  Created by NextopHN on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface PHRUIColor : NSObject{
    
}
+(UIColor*)colorFromHex:(NSString*)hexStr alpha:(CGFloat)alpha;
+(UIColor*)colorTagTableDarkWithAlpha:(CGFloat)alpha;
+(UIColor*)colorTagTableLightWithAlpha:(CGFloat)alpha;

+(UIColor*)colorOrderTableDarkWithAlpha:(CGFloat)alpha;
+(UIColor*)colorOrderTableLightWithAlpha:(CGFloat)alpha;
+(UIColor*)colorProgressCourseTableCellWithAlpha:(CGFloat)alpha;
+(UIColor*)colorBodyMeasurementTabbarHeaderBackground:(CGFloat)alpha;
@end
