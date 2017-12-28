//
//  Base2NavigationBarRightIcon.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2NavigationBarRightIcon.h"

@implementation Base2NavigationBarRightIcon

- (void)awakeFromNib{

}


- (void)setupWithTitle:(NSString*)title iconLeft:(NSString*)iconLeft iconRight:(NSString*)iconRight iconMiddle:(NSString*)iconMiddle colorLeft:(UIColor*)leftColor colorRight:(UIColor*)rightColor {
    if (leftColor && rightColor) {
        [self initGradient:leftColor rightColor:rightColor];
    }
    if (iconMiddle) {
        [self.imageIcon setImage:[UIImage imageNamed:iconMiddle]];
    }
    else{
        self.imageIcon.hidden = YES;
    }
    
    if (iconRight && ![iconRight isEqualToString:@""]) {
        [self.imageRight setImage:[UIImage imageNamed:iconRight]];
    }
    else{
        self.imageRight.hidden = YES;
    }
    if (iconLeft && ![iconLeft isEqualToString:@""]) {
        [self.imageLeft setImage:[UIImage imageNamed:iconLeft]];
    }
    else{
        //self.imageLeft.hidden = YES;
    }
    [self.labelTitle setText:title];
    //CGSize size = [UIUtils sizeForString:title andFont:self.labelTitle.font];
    //self.constraintIconAlignX.constant = size.width/2 + 10;
}

- (void)initGradient:(UIColor*)leftColor rightColor:(UIColor*)rightColor {
    UIColor *colorOne = leftColor;
    UIColor *colorTwo = rightColor;
    NSArray *colors = [NSArray arrayWithObjects:(id)colorOne.CGColor, colorTwo.CGColor, nil];
    NSNumber *stopOne = [NSNumber numberWithFloat:0.0];
    NSNumber *stopTwo = [NSNumber numberWithFloat:1.0];
    NSArray *locations = [NSArray arrayWithObjects:stopOne, stopTwo, nil];
    
    CAGradientLayer *gradientLayer = [CAGradientLayer layer];
    gradientLayer.frame = CGRectMake(self.viewLeft.bounds.origin.x, self.viewLeft.bounds.origin.y, [UIScreen mainScreen].bounds.size.width, self.viewLeft.bounds.size.height);
    [gradientLayer setStartPoint:CGPointMake(0, 0.5)];
    [gradientLayer setEndPoint:CGPointMake(1, 0.5)];
    gradientLayer.colors = colors;
    gradientLayer.locations = locations;
    if ([self.viewLeft.layer sublayers].count > 0) {
        [self.viewLeft.layer replaceSublayer:[self.viewLeft.layer sublayers][0] with:gradientLayer];
    }
    else{
        [self.viewLeft.layer insertSublayer:gradientLayer atIndex:0];
    }
}

- (void)initGradient:(UIColor*)leftColor rightColor:(UIColor*)rightColor onVIew:(UIView*)view{
    UIColor *colorOne = leftColor;
    UIColor *colorTwo = rightColor;
    NSArray *colors = [NSArray arrayWithObjects:(id)colorOne.CGColor, colorTwo.CGColor, nil];
    NSNumber *stopOne = [NSNumber numberWithFloat:0.0];
    NSNumber *stopTwo = [NSNumber numberWithFloat:1.0];
    NSArray *locations = [NSArray arrayWithObjects:stopOne, stopTwo, nil];
    
    CAGradientLayer *gradientLayer = [CAGradientLayer layer];
    gradientLayer.frame = CGRectMake(view.bounds.origin.x, view.bounds.origin.y, [UIScreen mainScreen].bounds.size.width, view.bounds.size.height);
    [gradientLayer setStartPoint:CGPointMake(0, 0.5)];
    [gradientLayer setEndPoint:CGPointMake(1, 0.5)];
    gradientLayer.colors = colors;
    gradientLayer.locations = locations;
    if ([view.layer sublayers].count > 0) {
        [view.layer replaceSublayer:[view.layer sublayers][0] with:gradientLayer];
    }
    else{
        [view.layer insertSublayer:gradientLayer atIndex:0];
    }
}


- (void)setEnableForRightButton:(BOOL) isEnable {
    [self.imageRight setHidden:isEnable];
}

- (IBAction)onTapButtonLeft:(id)sender {
    if (self.actionBack) {
        self.actionBack();
    }
}

- (IBAction)onTapButtonRight:(id)sender {
    if (self.actionRight) {
        self.actionRight();
    }
}
@end
