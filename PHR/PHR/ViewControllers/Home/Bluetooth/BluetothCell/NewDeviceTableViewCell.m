//
//  NewDeviceTableViewCell.m
//  PHR
//
//  Created by BillyMobile on 6/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "NewDeviceTableViewCell.h"

@implementation NewDeviceTableViewCell

- (void)awakeFromNib {
    [super awakeFromNib];
    self.lblDeviceName.font = [FontUtils aileronRegularWithSize:16.0];
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
