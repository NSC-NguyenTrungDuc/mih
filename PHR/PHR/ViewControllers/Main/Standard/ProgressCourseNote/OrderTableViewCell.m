//
//  OrderTableViewCell.m
//  PHR
//
//  Created by NextopHN on 4/15/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "OrderTableViewCell.h"

@implementation OrderTableViewCell

- (void)awakeFromNib {
    [super awakeFromNib];
    // Initialization code
//    self.contentView.backgroundColor  = [UIColor clearColor];
//    self.viewBorder.layer.borderColor = [UIColor grayColor].CGColor;
//    self.viewBorder.layer.borderWidth = 0.2;
    self.contentView.backgroundColor  = [PHRUIColor colorProgressCourseTableCellWithAlpha:1.0];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
