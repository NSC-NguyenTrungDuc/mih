//
//  CustomTextFieldProfile.m
//  PHR
//
//  Created by DEV-MinhNN on 9/30/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "CustomTextFieldProfile.h"

@implementation CustomTextFieldProfile

- (instancetype)initCusTomTextField {
    self = [super init];
    if (!self) {
        self = [[CustomTextFieldProfile alloc] init];
    }
    
    [self setFont:[FontUtils aileronRegularWithSize:14.0]];
    [self setTextColor:RGBCOLOR(137.0, 137.0, 137.0)];
    return self;
}

- (void)drawRect:(CGRect)rect {
    self.autocorrectionType = UITextAutocorrectionTypeNo;
    self.autocapitalizationType = UITextAutocapitalizationTypeNone;
//    [self setValue:[UIColor whiteColor]forKeyPath:@"_placeholderLabel.textColor"];
    self.borderStyle = UITextBorderStyleLine;
    self.background = [UIImage imageNamed:@"GBTextfield"];
    
    CALayer *layer = self.layer;
    layer.backgroundColor = [[UIColor whiteColor] CGColor];
//    layer.cornerRadius = 15.0;
    layer.masksToBounds = YES;
    //    layer.borderWidth = 1.0;
    //    layer.borderColor = [[UIColor colorWithRed:0 green:0 blue:0 alpha:1] CGColor];
    [layer setShadowColor:[[UIColor blackColor] CGColor]];
    //[layer setShadowOpacity:1];
    [layer setShadowOffset:CGSizeMake(0, 2.0)];
    [layer setShadowRadius:5];
    [self setClipsToBounds:NO];
    [self setContentVerticalAlignment:UIControlContentVerticalAlignmentCenter];
    [self setContentHorizontalAlignment:UIControlContentHorizontalAlignmentLeft];
    
    [self setFont:[FontUtils aileronRegularWithSize:14.0]];
//    [self setTextColor:RGBCOLOR(137.0, 137.0, 137.0)];
}

- (BOOL)regularExpressionForEmail:(NSString *)checkString {
    BOOL stricterFilter = NO;
    NSString *stricterFilterString = @"^[_A-Za-z0-9-+]+(\\.[_A-Za-z0-9-+]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9-]+)*(\\.[A-Za-z‌​]{2,4})$";
    NSString *laxString = @".+@([A-Za-z0-9-]+\\.)+[A-Za-z]{2}[A-Za-z]*";
    NSString *emailRegex = stricterFilter ? stricterFilterString : laxString;
    NSPredicate *emailTest = [NSPredicate predicateWithFormat:@"SELF MATCHES %@", emailRegex];
    return [emailTest evaluateWithObject:checkString];
}

- (void)setFrameY:(float)originY {
    [self setFrame:CGRectMake(self.frame.origin.x, self.frame.origin.y + originY , self.frame.size.width, self.frame.size.height)];
}

- (BOOL)becomeFirstResponder {
    BOOL outcome = [super becomeFirstResponder];
    if (outcome) {
        self.background = [UIImage imageNamed:@"TextField_focus"];
    }
    return outcome;
}

- (BOOL)resignFirstResponder {
    BOOL outcome = [super resignFirstResponder];
    if (outcome) {
        self.background = [UIImage imageNamed:@"GBTextfield"];
    }
    return outcome;
}

@end
