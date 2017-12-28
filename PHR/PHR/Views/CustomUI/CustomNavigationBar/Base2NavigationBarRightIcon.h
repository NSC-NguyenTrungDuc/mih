//
//  Base2NavigationBarRightIcon.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

typedef void(^NavBar2Action)();

@interface Base2NavigationBarRightIcon : UIView

@property (nonatomic, copy) NavBar2Action actionRight;
@property (nonatomic, copy) NavBar2Action actionBack;

@property (weak, nonatomic) IBOutlet UIImageView *imageLeft;
@property (weak, nonatomic) IBOutlet UIImageView *imageIcon;
@property (weak, nonatomic) IBOutlet UILabel *labelTitle;
@property (weak, nonatomic) IBOutlet UIImageView *imageRight;
@property (weak, nonatomic) IBOutlet UIView *viewLeft;
- (IBAction)onTapButtonLeft:(id)sender;
- (IBAction)onTapButtonRight:(id)sender;


//@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintIconAlignX;

- (void)setupWithTitle:(NSString*)title iconLeft:(NSString*)iconLeft iconRight:(NSString*)iconRight iconMiddle:(NSString*)iconMiddle colorLeft:(UIColor*)leftColor colorRight:(UIColor*)rightColor;
- (void)setEnableForRightButton:(BOOL) isEnable ;
- (void)initGradient:(UIColor*)leftColor rightColor:(UIColor*)rightColor onVIew:(UIView*)view;

@end
