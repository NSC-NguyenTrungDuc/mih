//
//  HomeMilkCell.m
//  PHR
//
//  Created by Luong Le Hoang on 10/9/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "HomeMilkCell.h"

@implementation HomeMilkCell

- (void)awakeFromNib {
    // Initialization code
    [self setUpStyleToCell];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

- (void)setUpStyleToCell {
    [self.label1 setStyleRegularToLabelWithColor:[UIColor whiteColor] andSize:10.0];
    [self.label2 setStyleRegularToLabelWithColor:[UIColor whiteColor] andSize:10.0];
    [self.label3 setStyleRegularToLabelWithColor:[UIColor whiteColor] andSize:10.0];

    [self.labelText1 setStyleRegularToLabelWithColor:[UIColor whiteColor] andSize:12.0];
    [self.labeltext2 setStyleRegularToLabelWithColor:[UIColor whiteColor] andSize:12.0];
    [self.labeltext3 setStyleRegularToLabelWithColor:[UIColor whiteColor] andSize:12.0];

}

@end
