//
//  TodayDrugTableViewCell.m
//  PHR
//
//  Created by BillyMobile on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "TodayDrugTableViewCell.h"

@implementation TodayDrugTableViewCell

- (void)awakeFromNib {
//    [super awakeFromNib];
//    UISwipeGestureRecognizer *swipeLeft = [[UISwipeGestureRecognizer alloc] initWithTarget:self action:@selector(handleSwipe:)];
//    UISwipeGestureRecognizer *swipeRight = [[UISwipeGestureRecognizer alloc] initWithTarget:self action:@selector(handleSwipe:)];
//    
//     //Setting the swipe direction.
//    [swipeLeft setDirection:UISwipeGestureRecognizerDirectionLeft];
//    [swipeRight setDirection:UISwipeGestureRecognizerDirectionRight];
//    
//     //Adding the swipe gesture on image view
//    [self.viewContent addGestureRecognizer:swipeLeft];
//    [self.viewContent addGestureRecognizer:swipeRight];
    
    self.btnCheck.backgroundColor = [UIColor colorWithRed:169.0/255.0 green:208.0/255.0 blue:93.0/255.0 alpha:1.0];
    self.btnRemove.backgroundColor = [UIColor colorWithRed:232.0/255.0 green:146.0/255.0 blue:89.0/255.0 alpha:1.0];
    
    
    [self setRightUtilityButtons:[self RightButtons] WithButtonWidth:58.0f];
    
    self.viewSeparator.backgroundColor = [UIColor colorWithRed:210.0/255.0 green:210.0/255.0 blue:210.0/255.0 alpha:1.0];
    self.lblTime.font = [FontUtils aileronRegularWithSize:15.0];
    self.lblTime.textColor = [UIColor colorWithRed:163.0/255.0 green:163.0/255.0 blue:163.0/255.0 alpha:1.0];
    
    self.lblContent.font = [FontUtils aileronRegularWithSize:15.0];
    self.lblContent.textColor = [UIColor colorWithRed:101.0/255.0 green:101.0/255.0 blue:101.0/255.0 alpha:1.0];
    
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

- (void)handleSwipe:(UISwipeGestureRecognizer *)swipe {

    if (swipe.direction == UISwipeGestureRecognizerDirectionLeft) {
        
        [UIView animateWithDuration:0.05 animations:^{
            self.viewContent.frame = CGRectMake(0, 0, self.bounds.size.width - 110, self.bounds.size.height);
        }];
    }

    if (swipe.direction == UISwipeGestureRecognizerDirectionRight) {
        
        [UIView animateWithDuration:0.05 animations:^{
            self.viewContent.frame = CGRectMake(0, 0, self.bounds.size.width, self.bounds.size.height);
        }];
    }
}

- (NSArray *)RightButtons{
    NSMutableArray *rightUtilityButtons = [NSMutableArray new];
    
    [rightUtilityButtons sw_addUtilityButtonWithColor:
    [UIColor colorWithRed:169.0/255.0 green:208.0/255.0 blue:93.0/255.0 alpha:1.0]
                                                icon:[UIImage imageNamed:@"Icon_white_check"]];
    [rightUtilityButtons sw_addUtilityButtonWithColor:
     [UIColor colorWithRed:232.0/255.0 green:146.0/255.0 blue:89.0/255.0 alpha:1.0]
                                                icon:[UIImage imageNamed:@"Icon_white_minus"]];
    
    return rightUtilityButtons;
}

@end
