//
//  CustomTextFieldProfile.h
//  PHR
//
//  Created by DEV-MinhNN on 9/30/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface PHRTextField : UITextField

- (instancetype)initCusTomTextField;
- (instancetype)initCusTomTextFieldWithTextSize: (CGFloat) textSize andTextColor: (UIColor*) color;
- (void)setFrameY:(float)originY;

@end
