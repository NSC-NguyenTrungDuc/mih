//
//  UILabel+Extension.m
//  PHR
//
//  Created by DEV-MinhNN on 10/3/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "UILabel+Extension.h"

@implementation UILabel (Extension)

- (void)setFrameWidth:(CGFloat)frameWidth {
    self.frame = CGRectMake(self.frame.origin.x, self.frame.origin.y, frameWidth, self.frame.size.height);
}

- (CGFloat)frameWidth {
    return self.frameWidth;
}

- (void)setStyleRegularToLabelWithSize:(float)size {
    [self setFont:[FontUtils aileronRegularWithSize:size]];
    [self setTextColor:PHR_COLOR_GRAY];
}

- (void)setStyleRegularToLabelWithColor:(UIColor *)color andSize:(float)size {
    [self setFont:[FontUtils aileronRegularWithSize:size]];
    [self setTextColor:color];
}

- (void)setStyleLightToLabelWithSize:(float)size {
    [self setFont:[FontUtils aileronLightWithSize:size]];
}

- (void)setStyleLightToLabelWithSize:(UIColor *)color size:(float)size {
    [self setFont:[FontUtils aileronLightWithSize:size]];
    [self setTextColor:color];
}

- (void)alignTextTopLeft {
  UIEdgeInsets insetsTopLeft = UIEdgeInsetsMake(5, 5, 0, 0);
  [self drawTextInRect:UIEdgeInsetsInsetRect(self.frame, insetsTopLeft)];
  [self sizeToFit];
}

- (void)alignTextTopRight {
  UIEdgeInsets insetsTopRight = UIEdgeInsetsMake(5, 0, 0, 5);
  [self drawTextInRect:UIEdgeInsetsInsetRect(self.frame, insetsTopRight)];
  [self sizeToFit];
}
@end
