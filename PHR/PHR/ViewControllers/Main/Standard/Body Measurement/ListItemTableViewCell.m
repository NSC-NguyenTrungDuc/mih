//
//  ListItemTableViewCell.m
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "ListItemTableViewCell.h"

@implementation ListItemTableViewCell

- (void)awakeFromNib {
    [super awakeFromNib];
    self.contentView.layer.borderColor = [UIColor lightGrayColor].CGColor;
    self.contentView.layer.borderWidth = 0.5;
    [self.labelContent setStyleRegularToLabelWithColor:[UIColor colorWithRed:96./255. green:96./255. blue:96./255. alpha:1] andSize:14.0];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];
}

- (void)setupContentWithType:(TableItemModel*)type {
    if(!type.imagePath.length) {
        self.constraintLeaderLabelContent.constant = 0;
        [self addConstraint:[NSLayoutConstraint constraintWithItem:self.imageViewIcon attribute:NSLayoutAttributeWidth relatedBy:NSLayoutRelationEqual toItem:nil attribute:NSLayoutAttributeNotAnAttribute multiplier:1.0 constant:0]];
    }
    self.imageViewIcon.image = [UIImage imageNamed:type.imagePath];
    self.labelContent .text = kLocalizedString(type.title);
}
@end
