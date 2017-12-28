//
//  UILabel+Extension.h
//  PHR
//
//  Created by DEV-MinhNN on 10/3/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface UILabel (Extension)

@property (nonatomic, assign) CGFloat frameWidth;

- (void)setStyleRegularToLabelWithSize:(float)size;
- (void)setStyleLightToLabelWithSize:(float)size;
- (void)setStyleRegularToLabelWithColor:(UIColor *)color andSize:(float)size;
- (void)setStyleLightToLabelWithSize:(UIColor *)color size:(float)size;
- (void)alignTextTopLeft;
- (void)alignTextTopRight;

@end
