//
//  CustomTextFieldProfile.h
//  PHR
//
//  Created by DEV-MinhNN on 9/30/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface CustomTextFieldProfile : UITextField

- (instancetype)initCusTomTextField;

- (BOOL)regularExpressionForEmail:(NSString *)checkString;
- (void)setFrameY:(float)originY;

@end
