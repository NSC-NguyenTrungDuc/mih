//
//  BabySleepTableViewCell.m
//  PHR
//
//  Created by DEV-MinhNN on 11/4/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "BabySleepTableViewCell.h"

@implementation BabySleepTableViewCell

- (void)awakeFromNib {
    // Initialization code
    [self setStyleToCell];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];
    
    // Configure the view for the selected state
}

- (void)setStyleToCell {
    [self.lbMorningSleep setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
    [self.lbAfternoonSleep setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
    [self.lbNightSleep setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
    
    [self.lbMorning setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
    [self.lbAfternoon setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
    [self.lbNight setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
    
    [self.lbMorning setText:kLocalizedString(kMorning)];
    [self.lbAfternoon setText:kLocalizedString(kAfternoon)];
    [self.lbNight setText:kLocalizedString(kNight)];
}

@end
