//
//  PHRBabyMilkHeaderView.m
//  PHR
//
//  Created by DEV-MinhNN on 12/1/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "PHRBabyMilkHeaderView.h"

@implementation PHRBabyMilkHeaderView

- (void)awakeFromNib {
    [self.lbDateTime setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:12.0];
    [self.lbTimeOrMl setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:12.0];
    [self.lbNumberKcal setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:12.0];
    [self.viewBackground setBackgroundColor:PHR_COLOR_LIFE_STYLE_LIGHT_ALPHA];
}

/*
// Only override drawRect: if you perform custom drawing.
// An empty implementation adversely affects performance during animation.
- (void)drawRect:(CGRect)rect {
    // Drawing code
}
*/

@end
