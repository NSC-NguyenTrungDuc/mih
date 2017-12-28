//
//  AddNewDrugTableViewCell.m
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddNewDrugTableViewCell.h"

@implementation AddNewDrugTableViewCell

- (void)awakeFromNib {
    [super awakeFromNib];
    self.delegate = self;
    [self setRightUtilityButtons:[self RightButtons] WithButtonWidth:49.0f];
//    self.viewContent.layer.borderWidth = 1.0;
//    self.viewContent.layer.borderColor = [UIColor colorWithRed:198.0/255.0 green:198.0/255.0 blue:198.0/255.0 alpha:1.0].CGColor;
    
    self.lblRemider.font = [FontUtils aileronRegularWithSize:11.0];
    self.lblRemider.textColor = [UIColor grayColor];
    self.lblDrugName.font = [FontUtils aileronRegularWithSize:15.0];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

- (NSArray *)RightButtons{
    NSMutableArray *rightUtilityButtons = [NSMutableArray new];
    
    [rightUtilityButtons sw_addUtilityButtonWithColor:
     [UIColor redColor]
                                                 icon:[UIImage imageNamed:@"Icon_gray_dustbin"]];
    return rightUtilityButtons;
}

- (void)swipeableTableViewCell:(SWTableViewCell *)cell didTriggerRightUtilityButtonWithIndex:(NSInteger)index{
    self.deleteCallBack();
}


@end
