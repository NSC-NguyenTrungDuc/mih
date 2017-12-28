//
//  BabyMedicineCell.m
//  PHR
//
//  Created by DEV-MinhNN on 11/19/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "BabyMedicineCell.h"

@implementation BabyMedicineCell

- (void)awakeFromNib {
    // Initialization code
//    [self.viewImage.layer setBorderColor:[UIColor lightTextColor].CGColor];
//    [self.viewImage.layer setBorderWidth:1.0];
    
    [self.lbNameMedicine setStyleRegularToLabelWithColor:[UIColor whiteColor] andSize:14.0];
    [self.lbNumberMedicine setStyleRegularToLabelWithColor:[UIColor whiteColor] andSize:14.0];
    [self.lbTimeDrink setStyleRegularToLabelWithColor:[UIColor whiteColor] andSize:14.0];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
