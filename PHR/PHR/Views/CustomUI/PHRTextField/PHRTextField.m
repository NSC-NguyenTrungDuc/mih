//
//  CustomTextFieldProfile.m
//  PHR
//
//  Created by DEV-MinhNN on 9/30/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "PHRTextField.h"

@implementation PHRTextField
int paddingRight;
- (void)awakeFromNib {
    //[self setAutocorrectionType:UITextAutocorrectionTypeNo];
    //[self setTextColor:PHR_COLOR_GRAY];
    //[self setValue:PHR_COLOR_GRAY forKeyPath:@"_placeholderLabel.textColor"];
}

- (instancetype)initCusTomTextField {
    self = [super init];
    if (!self) {
        self = [[PHRTextField alloc] init];
    }
    
    [self setFont:[FontUtils aileronRegularWithSize:14.0]];
    [self setTextColor:RGBCOLOR(137.0, 137.0, 137.0)];
    paddingRight = 0;
    return self;
}

- (instancetype)initCusTomTextFieldWithTextSize: (CGFloat) textSize andTextColor: (UIColor*) color {
    self = [super init];
    if (!self) {
        self = [[PHRTextField alloc] init];
    }
    
    [self setFont:[FontUtils aileronRegularWithSize:textSize]];
    [self setTextColor:color];
    paddingRight = 100;
    return self;
}

- (void)drawRect:(CGRect)rect {
    self.autocorrectionType = UITextAutocorrectionTypeNo;
    self.autocapitalizationType = UITextAutocapitalizationTypeNone;
    self.borderStyle = UITextBorderStyleLine;
    self.background = [UIImage imageNamed:@"GBTextfield"];
    
    CALayer *layer = self.layer;
    layer.backgroundColor = [[UIColor whiteColor] CGColor];
    layer.masksToBounds = YES;
    [layer setShadowColor:[[UIColor blackColor] CGColor]];
    //[layer setShadowOpacity:1];
    [layer setShadowOffset:CGSizeMake(0, 2.0)];
    [layer setShadowRadius:5];
    [self setClipsToBounds:NO];
    [self setContentVerticalAlignment:UIControlContentVerticalAlignmentCenter];
    [self setContentHorizontalAlignment:UIControlContentHorizontalAlignmentLeft];
}

- (CGRect)textRectForBounds:(CGRect)bounds {
    if(paddingRight > 0){
        return CGRectMake(bounds.origin.x  , bounds.origin.y - 5 ,
                      bounds.size.width - paddingRight, bounds.size.height);
    } else {
        return bounds;
    }
}

- (CGRect)editingRectForBounds:(CGRect)bounds {
    return [self textRectForBounds:bounds];
}

- (void)setFrameY:(float)originY {
    [self setFrame:CGRectMake(self.frame.origin.x, self.frame.origin.y + originY, self.frame.size.width, self.frame.size.height)];
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

- (BOOL)canPerformAction:(SEL)action withSender:(id)sender {
    if (action == @selector(copy:) || action == @selector(paste:)) {
        return NO;
    }
    return [super canPerformAction:action withSender:sender];
}

@end
