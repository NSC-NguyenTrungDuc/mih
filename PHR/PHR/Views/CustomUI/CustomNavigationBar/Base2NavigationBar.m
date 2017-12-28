//
//  Base2NavigationBar.m
//  PHR
//
//  Created by Luong Le Hoang on 10/8/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "Base2NavigationBar.h"

@interface Base2NavigationBar ()

@end

@implementation Base2NavigationBar

- (void)awakeFromNib{
    
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

- (void)setupWithTitle:(NSString*)title icon:(NSString*)icon rightItem:(NSString*)right{
    [self.imageIcon setImage:[UIImage imageNamed:icon]];
    [self.labelTitle setText:title];
    if (right && ![right isEqualToString:@""]) {
        [self.buttonRight setTitle:right forState:UIControlStateNormal];
    }
    else{
        self.buttonRight.hidden = YES;
        self.imgPortraitLine.hidden = YES;
    }
    [self.buttonBack setImage:[UIImage imageNamed:@"backMenuBar"] forState:UIControlStateNormal];
    CGSize size = [UIUtils sizeForString:title andFont:self.labelTitle.font];
    self.constraintIconAlignX.constant = size.width/2 + 10;
}

- (void)setupForSiginWithTitle:(NSString*)title{
    [self.labelTitle setText:title];
    self.labelTitle.textColor = [UIColor blackColor];
    
    UIImage * landscapeImage = [UIImage imageNamed:@"Icon_Arrow_Left"];
    
    [self.buttonBack setImage:landscapeImage forState:UIControlStateNormal];
    self.imgPortraitLine.hidden = YES;
    self.imageStatusBar.hidden = YES;
    self.buttonRight.hidden = YES;
    self.imageLandscape.hidden = YES;
    CGSize size = [UIUtils sizeForString:title andFont:self.labelTitle.font];
    self.constraintIconAlignX.constant = size.width/2 + 10;
}

- (void)setEnableForRightButton:(BOOL) isEnable {
    [self.buttonRight setEnabled:isEnable];
}

- (IBAction)actionBack:(id)sender {
    if (self.actionBack) {
        self.actionBack();
    }
}

- (IBAction)actionRight:(id)sender {
    if (self.actionRight) {
        self.actionRight();
    }
}
@end
