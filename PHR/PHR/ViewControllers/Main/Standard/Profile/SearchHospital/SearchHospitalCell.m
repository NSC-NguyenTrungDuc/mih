//
//  SearchHospitalCell.m
//  PHR
//
//  Created by Luong Le Hoang on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "SearchHospitalCell.h"

@implementation SearchHospitalCell

- (void)awakeFromNib {
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

- (void)fillInfoName:(NSString*)name address:(NSString*)address tel:(NSString*)tel{
    self.labelName.text = name;
    self.labelAddress.text = address;
    self.labelTel.text = tel;
}

@end
