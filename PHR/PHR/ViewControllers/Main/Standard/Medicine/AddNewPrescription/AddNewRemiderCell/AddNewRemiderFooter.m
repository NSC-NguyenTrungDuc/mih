//
//  AddNewRemiderFooter.m
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddNewRemiderFooter.h"

@implementation AddNewRemiderFooter

- (void)awakeFromNib {
    [super awakeFromNib];
    self.backgroundColor = [UIColor colorWithRed:246.0/255.0 green:246.0/255.0 blue:246.0/255.0 alpha:1.0];
    self.btnAddNewDrug.titleLabel.font = [FontUtils aileronRegularWithSize:15.0];
    self.btnAddNewDrug.titleLabel.textColor = [UIColor colorWithRed:79.0/255.0 green:185.0/255.0 blue:194.0/255.0 alpha:1.0];
    self.btnAddNewDrug.titleLabel.text = kLocalizedString(kAddNewAlarm);
    [self.btnAddNewDrug setTitle:kLocalizedString(kAddNewAlarm) forState:UIControlStateNormal];
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

- (IBAction)actionAddNewRemider:(id)sender {
    [[NSNotificationCenter defaultCenter] postNotificationName:@"actionAddNewRemider" object:nil];
    self.addRemiderCallBack();
}
@end
