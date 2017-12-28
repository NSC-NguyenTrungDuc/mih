//
//  AddNewDrugHeader.m
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddNewDrugHeader.h"

@implementation AddNewDrugHeader

- (void)awakeFromNib {
    [super awakeFromNib];
    self.backgroundColor = [UIColor colorWithRed:253.0/255.0 green:243.0/255.0 blue:241.0/255.0 alpha:1.0];
    self.lblDrugList.textColor = [UIColor colorWithRed:238.0/255.0 green:145.0/255.0 blue:128.0/255.0 alpha:1.0];
    self.lblDrugList.font = [FontUtils aileronRegularWithSize:13.0];
    self.lblDrugList.text = kLocalizedString(kDrugList);
    
    NSMutableAttributedString *titleString = [[NSMutableAttributedString alloc] initWithString:kLocalizedString(kAddNewDrug)];
    [self.btnAddDrug setAttributedTitle:titleString forState:UIControlStateNormal];
    
    self.btnAddDrug.titleLabel.font = self.lblDrugList.font = [FontUtils aileronRegularWithSize:14.0];
    self.btnAddDrug.titleLabel.textColor = [UIColor blackColor];
    if(!self.isShowAdd){
        self.btnAddDrug.hidden = YES;
    }else{
        self.btnAddDrug.hidden = NO;
    }
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

- (IBAction)actionAddNewDrug:(id)sender {
    self.addDrugCallBack();
}
@end
