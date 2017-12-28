//
//  BookingHistoryTableViewCell.m
//  PHR
//
//  Created by Dao Xuan Tu on 11/12/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BookingHistoryTableViewCell.h"


@implementation BookingHistoryTableViewCell


- (void)awakeFromNib {
    [super awakeFromNib];
//    UIView *bgColorView = [[UIView alloc] init];
//    bgColorView.backgroundColor = [UIColor colorWithRed:227./255. green:242./255. blue: 252./255. alpha:1];
//    [self setSelectedBackgroundView:bgColorView];
    self.lblDay.font = [FontUtils aileronRegularWithSize:16.0];
    self.lblLength.font = [FontUtils aileronRegularWithSize:16.0];
 }

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

  
}

@end
