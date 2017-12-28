//
//  FontUtils.m
//  PHR
//
//  Created by DEV-MinhNN on 9/29/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "FontUtils.h"

@implementation FontUtils

+ (void)printFonts {
    NSArray *fontFamilies = [UIFont familyNames];
    for (int i = 0; i < [fontFamilies count]; i++) {
        NSString *fontFamily = [fontFamilies objectAtIndex:i];
        NSArray *fontNames = [UIFont fontNamesForFamilyName:[fontFamilies objectAtIndex:i]];
        NSLog(@"%@: %@", fontFamily, fontNames);
    }
}

+ (UIFont *)aileronBlackWithSize:(CGFloat)fontSize {
    UIFont *font = [UIFont fontWithName:@"Aileron-Black" size:fontSize];
    return font;
}

+ (UIFont *)aileronBlackItalicWithSize:(CGFloat)fontSize {
    UIFont *font = [UIFont fontWithName:@"Aileron-BlackItalic" size:fontSize];
    return font;
}

+ (UIFont *)aileronBoldWithSize:(CGFloat)fontSize {
    UIFont *font = [UIFont fontWithName:@"Aileron-Bold" size:fontSize];
    return font;
}

+ (UIFont *)aileronBoldItalicFontWithSize:(CGFloat)fontSize {
    return [UIFont fontWithName:@"Aileron-BoldItalic" size:fontSize];
}

+ (UIFont *)aileronHeavyWithSize:(CGFloat)fontSize {
    return [UIFont fontWithName:@"Aileron-Heavy" size:fontSize];
}

+ (UIFont *)aileronItalicWithSize:(CGFloat)fontSize {
    return [UIFont fontWithName:@"Aileron-Italic" size:fontSize];
}

+ (UIFont *)aileronLightWithSize:(CGFloat)fontSize {
    return [UIFont fontWithName:@"Aileron-Light" size:fontSize];
}

+ (UIFont *)aileronLightItalicWithSize:(CGFloat)fontSize {
    return [UIFont fontWithName:@"Aileron-LightItalic" size:fontSize];
}

+ (UIFont *)aileronRegularWithSize:(CGFloat)fontSize {
    return [UIFont fontWithName:@"Aileron-Regular" size:fontSize];
}

+ (UIFont *)aileronSemiBoldWithSize:(CGFloat)fontSize {
    return [UIFont fontWithName:@"Aileron-SemiBold" size:fontSize];
}

+ (UIFont *)aileronSemiBoldItalicWithSize:(CGFloat)fontSize {
    return [UIFont fontWithName:@"Aileron-SemiBoldItalic" size:fontSize];
}

+ (UIFont *)aileronThinWithSize:(CGFloat)fontSize {
    return [UIFont fontWithName:@"Aileron-Thin" size:fontSize];
}

+ (UIFont *)aileronThinItalicWithSize:(CGFloat)fontSize {
    return [UIFont fontWithName:@"Aileron-ThinItalic" size:fontSize];
}

+ (UIFont *)aileronUltraLightWithSize:(CGFloat)fontSize {
    return [UIFont fontWithName:@"Aileron-UltraLight" size:fontSize];
}

+ (UIFont *)aileronUltraLightItalicWithSize:(CGFloat)fontSize {
    return [UIFont fontWithName:@"Aileron-UltraLightItalic" size:fontSize];
}








@end
