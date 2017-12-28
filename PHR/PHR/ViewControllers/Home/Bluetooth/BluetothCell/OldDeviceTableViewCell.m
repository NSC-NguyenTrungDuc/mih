//
//  OldDeviceTableViewCell.m
//  PHR
//
//  Created by BillyMobile on 6/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "OldDeviceTableViewCell.h"

@implementation OldDeviceTableViewCell

- (void)awakeFromNib {
    [super awakeFromNib];
    self.delegate = self;
    self.lblUserName.font = [FontUtils aileronRegularWithSize:14.0];
    self.lblStatus.font = [FontUtils aileronRegularWithSize:16.0];
    self.lblDeviceName.font = [FontUtils aileronRegularWithSize:16.0];
    [self setRightUtilityButtons:[self RightButtons] WithButtonWidth:70.0f];
    // Initialization code
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
