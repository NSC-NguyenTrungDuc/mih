//
//  AddRemiderTableViewCell.m
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddRemiderTableViewCell.h"

@implementation AddRemiderTableViewCell

- (void)awakeFromNib {
    [super awakeFromNib];
    [self setRightUtilityButtons:[self rightButtons] WithButtonWidth:49.0f];
    self.backgroundColor = [UIColor colorWithRed:255.0/255.0 green:255.0/255.0 blue:255.0/255.0 alpha:1.0];
    self.lblTime.font = [FontUtils aileronRegularWithSize:15.0];
    // Initialization code
    self.delegate = self;
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

- (NSArray *)rightButtons{
    NSMutableArray *rightUtilityButtons = [NSMutableArray new];
    
    [rightUtilityButtons sw_addUtilityButtonWithColor:
     [UIColor redColor]
                                                 icon:[UIImage imageNamed:@"Icon_gray_dustbin"]];

    return rightUtilityButtons;
}

- (void)swipeableTableViewCell:(SWTableViewCell *)cell didTriggerRightUtilityButtonWithIndex:(NSInteger)index {
    if (self.onRemoveRemider) {
        self.onRemoveRemider();
    }
}


@end
