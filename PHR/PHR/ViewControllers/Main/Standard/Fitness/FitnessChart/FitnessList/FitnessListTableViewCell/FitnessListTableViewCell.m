//
//  FitnessListTableViewCell.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "FitnessListTableViewCell.h"

@implementation FitnessListTableViewCell

- (void)awakeFromNib {
    [super awakeFromNib];
    [self.viewSeparatorTop setHidden:true];
    [self.lbTitle setStyleRegularToLabelWithColor:PHR_COLOR_TEXT_MEDICINES andSize:14.0];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
