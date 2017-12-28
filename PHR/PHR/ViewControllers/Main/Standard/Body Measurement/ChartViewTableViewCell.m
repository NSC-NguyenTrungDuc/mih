//
//  ChartViewTableViewCell.m
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "ChartViewTableViewCell.h"

@implementation ChartViewTableViewCell

- (void)awakeFromNib {
    [super awakeFromNib];
    self.viewContainerChart.layer.cornerRadius = 8.0;
    self.viewContainerChart.clipsToBounds = YES;
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
