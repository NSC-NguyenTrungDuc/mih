//
//  PresciptionListTableViewCell.m
//  PHR
//
//  Created by BillyMobile on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PresciptionListTableViewCell.h"

@implementation PresciptionListTableViewCell

- (void)awakeFromNib {
    [super awakeFromNib];
    
    self.delegate = self;

    
    [self setRightUtilityButtons:[self RightButtons] WithButtonWidth:58.0f];
    
    self.lblPresciption.font = [FontUtils aileronRegularWithSize:16.0];
    self.lblPresciption.textColor = [UIColor colorWithRed:83.0/255.0 green:83.0/255.0 blue:83.0/255.0 alpha:1.0];
    
    self.lblDateTime.font = [FontUtils aileronRegularWithSize:12.0];
    self.lblDateTime.textColor = [UIColor colorWithRed:163.0/255.0 green:163.0/255.0 blue:163.0/255.0 alpha:1.0];
    
    self.lblComplete.font = [FontUtils aileronRegularWithSize:10.0];
    self.lblComplete.textColor = [UIColor colorWithRed:163.0/255.0 green:163.0/255.0 blue:163.0/255.0 alpha:1.0];
    
    //self.viewSeparator.backgroundColor = [UIColor colorWithRed:210.0/255.0 green:210.0/255.0 blue:210.0/255.0 alpha:1.0];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

- (NSArray *)RightButtons{
    NSMutableArray *rightUtilityButtons = [NSMutableArray new];
    
    [rightUtilityButtons sw_addUtilityButtonWithColor:
     [UIColor redColor] icon:[UIImage imageNamed:@"Icon_gray_dustbin"]];
    return rightUtilityButtons;
}

- (void)swipeableTableViewCell:(SWTableViewCell *)cell scrollingToState:(SWCellState)state{
    if(state == kCellStateLeft) {
        self.viewRight.hidden = YES;
    }
}

- (void)swipeableTableViewCell:(SWTableViewCell *)cell didTriggerRightUtilityButtonWithIndex:(NSInteger)index{
    if (self.deleteCallBack) {
        self.deleteCallBack();
    }
}

- (BOOL)swipeableTableViewCell:(SWTableViewCell *)cell canSwipeToState:(SWCellState)state{
    if (self.deleteCallBack && self.isActive) {
       return YES;
    }
    return NO;
}


@end
