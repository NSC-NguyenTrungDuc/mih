//
//  ProfileTableViewCell.m
//  PHR
//
//  Created by BillyMobile on 6/11/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "ProfileTableViewCell.h"

@implementation ProfileTableViewCell

- (void)awakeFromNib {
    [super awakeFromNib];
    self.lblUserName.font = [FontUtils aileronRegularWithSize:16.0];
    self.lblUserType.font = [FontUtils aileronRegularWithSize:15.0];
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
