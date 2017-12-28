//
//  PHRMedicineTitleTableViewCell.m
//  PHR
//
//  Created by DEV-MinhNN on 10/28/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "PHRMedicineTitleTableViewCell.h"

@implementation PHRMedicineTitleTableViewCell

- (void)awakeFromNib {
    // Initialization code
    [self.lbKcal setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
    [self.lbDate setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

#pragma mark - UI

- (void)setStyleToHeaderTableViewWithTitle:(NSString *)titleBtn andDate:(NSString *)dateTime {
    [self setBackgroundColor:[UIColor clearColor]];
    if (!imgBG) {
        imgBG = [[UIImageView alloc] initWithFrame:CGRectMake(0.0, 0.0, SCREEN_WIDTH, 40.0)];
    }
    imgBG.contentMode = UIViewContentModeScaleAspectFill;
    imgBG.image = [UIImage imageNamed:@"BGHeader"];
    [self.contentView addSubview:imgBG];

    imgBG.layer.zPosition = 1;
    self.lbDate.layer.zPosition = 2;
    self.lbKcal.layer.zPosition = 3;
    
    [self.lbKcal setText:dateTime];
    [self.lbDate setText:titleBtn];
}

@end
