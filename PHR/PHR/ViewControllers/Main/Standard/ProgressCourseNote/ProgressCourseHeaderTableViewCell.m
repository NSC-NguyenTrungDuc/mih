//
//  ProgressCourseHeaderTableViewCell.m
//  PHR
//
//  Created by NextopHN on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "ProgressCourseHeaderTableViewCell.h"

@implementation ProgressCourseHeaderTableViewCell

- (void)awakeFromNib {
    [super awakeFromNib];
    // Initialization code
    [self setupUI];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];
    
    // Configure the view for the selected state
}

- (void)setupUI{
    //[self.imageViewCalendar setImage:[UIImage imageNamed:@"ArrowDown"]];
    [self.labelDateTime     setText:@""];
    [self.labelType     setText:@""];
    //[self.imageArrowDown    setImage:[UIImage imageNamed:@"ArrowDown"]];
    //[self.imageArrowDown setHidden:YES];
    self.contentView.layer.borderColor = [UIColor colorWithRed:1.0 green:1.0 blue:1.0 alpha:0.3f].CGColor;
    self.contentView.layer.borderWidth = 0.8;
}

@end
