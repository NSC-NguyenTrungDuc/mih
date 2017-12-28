//
//  AddSelectionTableViewCell.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddSelectionTableViewCell.h"

@implementation AddSelectionTableViewCell

- (void)awakeFromNib {
    [super awakeFromNib];
    [self.lbName setStyleRegularToLabelWithColor:[UIColor colorWithRed:96./255. green:96./255. blue:96./255. alpha:1] andSize:14.0];
    self.viewBottomSeparator.hidden = true;
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
