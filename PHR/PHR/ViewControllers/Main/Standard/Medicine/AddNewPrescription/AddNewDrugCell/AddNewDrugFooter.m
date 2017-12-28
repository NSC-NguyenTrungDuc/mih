//
//  AddNewDrugFooter.m
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddNewDrugFooter.h"

@implementation AddNewDrugFooter

- (void)awakeFromNib {
    [super awakeFromNib];
    self.btnAddNewDrug.titleLabel.text = kLocalizedString(kAddNewDrug);
    self.btnAddNewDrug.titleLabel.font = [FontUtils aileronRegularWithSize:15.0];
    self.btnAddNewDrug.titleLabel.textColor = [UIColor colorWithRed:79.0/255.0 green:185.0/255.0 blue:194.0/255.0 alpha:1.0];
    self.contentView.layer.borderWidth = 1.0;
    self.contentView.layer.borderColor = [UIColor colorWithRed:198.0/255.0 green:198.0/255.0 blue:198.0/255.0 alpha:1.0].CGColor;
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

- (IBAction)actionAddNewDrug:(id)sender {
    [[NSNotificationCenter defaultCenter] postNotificationName:@"actionAddNewDrug" object:nil];
    self.addDrugCallBack();
}
@end
