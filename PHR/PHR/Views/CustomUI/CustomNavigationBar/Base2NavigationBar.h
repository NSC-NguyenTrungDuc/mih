//
//  Base2NavigationBar.h
//  PHR
//
//  Created by Luong Le Hoang on 10/8/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

typedef void(^NavBar2Action)();

@interface Base2NavigationBar : UIView{
    
}
@property (nonatomic, copy) NavBar2Action actionRight;
@property (nonatomic, copy) NavBar2Action actionBack;

@property (weak, nonatomic) IBOutlet UIImageView *imageIcon;
@property (weak, nonatomic) IBOutlet UILabel *labelTitle;
@property (weak, nonatomic) IBOutlet UIButton *buttonRight;
@property (weak, nonatomic) IBOutlet UIImageView *imageStatusBar;

@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintIconAlignX;
@property (weak, nonatomic) IBOutlet UIImageView *imgPortraitLine;
@property (weak, nonatomic) IBOutlet UIButton *buttonBack;
@property (weak, nonatomic) IBOutlet UIImageView *imageLandscape;

- (IBAction)actionBack:(id)sender;
- (IBAction)actionRight:(id)sender;
- (void)setupWithTitle:(NSString*)title icon:(NSString*)icon rightItem:(NSString*)right;
- (void)setupForSiginWithTitle:(NSString*)title;
- (void)setEnableForRightButton:(BOOL) isEnable;
@end
