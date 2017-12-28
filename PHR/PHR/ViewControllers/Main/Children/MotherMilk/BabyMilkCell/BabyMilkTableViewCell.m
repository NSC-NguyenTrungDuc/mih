//
//  BabyMilkTableViewCell.m
//  PHR
//
//  Created by DEV-MinhNN on 11/6/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "BabyMilkTableViewCell.h"

@implementation BabyMilkTableViewCell

- (void)awakeFromNib {
    // Initialization code
    [self setUpViewCell];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];
    
    // Configure the view for the selected state
}

- (void)setUpViewCell {
//    [self.lbTime setFrame:CGRectMake(self.imgNoteClock.frame.size.width / 2 - 6.0, 7.0, 15.0, 21.0)];
//    [self.lbAmOrPm setFrame:CGRectMake(self.imgNoteClock.frame.size.width / 2 - 7.0, 0.0, 15.0, 21.0)];
    
    [self.txtVolumeOrTime setKeyboardType:UIKeyboardTypeNumberPad];
    
    [self.lbTime setFont:[FontUtils aileronRegularWithSize:8.0]];
    [self.lbAmOrPm setFont:[FontUtils aileronRegularWithSize:8.0]];
    
    [self.txtVolumeOrTime setFont:[FontUtils aileronRegularWithSize:PHR_SIZE_TEXT_TWENTY]];
    [self.txtMilkType setFont:[FontUtils aileronRegularWithSize:PHR_SIZE_TEXT_TWENTY]];
    [self.txtKcal setFont:[FontUtils aileronRegularWithSize:PHR_SIZE_TEXT_TWENTY]];
    
    [self.txtVolumeOrTime setAutocorrectionType:UITextAutocorrectionTypeNo];
    [self.txtMilkType setAutocorrectionType:UITextAutocorrectionTypeNo];
    [self.txtKcal setAutocorrectionType:UITextAutocorrectionTypeNo];
    
    [self.viewContain setBackgroundColor:[UIColor whiteColor]];
    [self.viewContain.layer setCornerRadius:10.0];
    [self.viewContain.layer setBorderColor:PHR_COLOR_LINE_GRAY.CGColor];
    [self.viewContain.layer setBorderWidth:1.0];
}
@end
