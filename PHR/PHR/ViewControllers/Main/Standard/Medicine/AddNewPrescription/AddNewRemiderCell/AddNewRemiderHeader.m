//
//  AddNewRemiderHeader.m
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddNewRemiderHeader.h"

@implementation AddNewRemiderHeader

- (void)awakeFromNib {
    [super awakeFromNib];
    self.backgroundColor = [UIColor colorWithRed:253.0/255.0 green:243.0/255.0 blue:241.0/255.0 alpha:1.0];
    self.lblRemider.font = [FontUtils aileronRegularWithSize:13.0];
    self.lblRemider.textColor = [UIColor colorWithRed:238.0/255.0 green:145.0/255.0 blue:128.0/255.0 alpha:1.0];
    self.lblRemider.text = kLocalizedString(kRemider);
    
    NSMutableAttributedString *titleString = [[NSMutableAttributedString alloc] initWithString:kLocalizedString(kAddNewAlarm)];
    [self.btnAddAlarm setAttributedTitle:titleString forState:UIControlStateNormal];
    self.btnAddAlarm.titleLabel.textColor = [UIColor blackColor];
    self.btnAddAlarm.titleLabel.font = [FontUtils aileronRegularWithSize:14.0];
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

- (IBAction)actionAddNewAlarm:(id)sender {
    self.addRemiderCallBack();
}

//- (IBAction)actionExpant:(id)sender {
//    [[NSNotificationCenter defaultCenter] postNotificationName:@"actionExpant" object:nil];
//}
@end
