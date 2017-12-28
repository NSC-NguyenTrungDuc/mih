//
//  PHRTwoTabButton.h
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@class PHRTwoTabButton;
@protocol PHRTwoTabButtonDelegate <NSObject>
- (void)selectedIndex:(NSInteger)index ofTwoTabButton:(PHRTwoTabButton*) twoTabButton;
@end

@interface PHRTwoTabButton : UIView
@property (weak, nonatomic) IBOutlet UIView *viewLeftTab;
@property (weak, nonatomic) IBOutlet UIView *viewRightTab;

@property (weak, nonatomic) IBOutlet UILabel *labelTitleModeNoImageLeft;
@property (weak, nonatomic) IBOutlet UILabel *labelTitleModeNoImageRight;

@property (weak, nonatomic) IBOutlet UIImageView *imageViewLeft;
@property (weak, nonatomic) IBOutlet UIImageView *imageViewRight;

@property (weak, nonatomic) IBOutlet UILabel *labelTitleLeft;
@property (weak, nonatomic) IBOutlet UILabel *labelTitleRight;
@property (nonatomic, weak) id<PHRTwoTabButtonDelegate> delegate;
@property (nonatomic) NSInteger selectedIndex;

- (void) setFont:(CGFloat)fontSize;
- (void)inititializeContent;
- (void)addToView:(UIView*)superView delegate:(id)delegate;
@end
