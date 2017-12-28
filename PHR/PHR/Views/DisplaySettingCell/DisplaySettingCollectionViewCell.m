//
//  DisplaySettingCollectionViewCell.m
//  PHR
//
//  Created by SonNV1368 on 10/15/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "DisplaySettingCollectionViewCell.h"

@implementation DisplaySettingCollectionViewCell



- (void)layoutSubviews{
    [super layoutSubviews];
    
    // (2)
    [self.contentView updateConstraintsIfNeeded];
    [self.contentView layoutIfNeeded];
    
    self.viewCell.layer.cornerRadius = 5;
    self.viewCell.layer.masksToBounds = YES;

}

- (void)awakeFromNib {
    // Initialization code
}
- (IBAction)touchButtonPreview:(id)sender {
}

@end
