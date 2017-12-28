//
//  BabyHomeDiaperCell.m
//  PHR
//
//  Created by Luong Le Hoang on 10/9/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "BabyHomeDiaperCell.h"

@implementation BabyHomeDiaperCell

- (void)awakeFromNib {
    // Initialization code
    self.imageDiaperColor.layer.cornerRadius = self.imageDiaperColor.frame.size.width/2;
    self.imageDiaperColor.layer.borderWidth = 2;
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
