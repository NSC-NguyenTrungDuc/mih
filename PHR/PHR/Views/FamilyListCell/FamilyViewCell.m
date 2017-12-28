//
//  FamilyViewCell.m
//  PHR
//
//  Created by SonNV1368 on 9/29/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "FamilyViewCell.h"

@implementation FamilyViewCell

- (void)layoutSubviews{
    [super layoutSubviews];
    
    // (2)
    [self.contentView updateConstraintsIfNeeded];
    [self.contentView layoutIfNeeded];
    
    self.avatarFamilyMember.layer.cornerRadius = self.avatarFamilyMember.bounds.size.width/2;
    self.avatarFamilyMember.layer.masksToBounds = YES;
//    self.avatarFamilyMember.layer.borderColor = [UIColor whiteColor].CGColor;
//    self.avatarFamilyMember.layer.borderWidth = 2;
    
    self.viewChoosen.layer.cornerRadius = self.avatarFamilyMember.bounds.size.width/2;
    self.viewChoosen.layer.masksToBounds = YES;

    [self.avatarFamilyMember setContentMode:UIViewContentModeScaleAspectFill];
}

- (void)awakeFromNib {
    // Initialization code

}

@end
