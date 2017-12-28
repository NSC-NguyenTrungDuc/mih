//
//  StandardFitnessTableViewCell.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "StandardFitnessTableViewCell.h"

@implementation StandardFitnessTableViewCell

- (void)awakeFromNib {
    [super awakeFromNib];
    self.viewValue.layer.cornerRadius = 15;
    self.viewValue.layer.masksToBounds = YES;
    
    [self.labelDateTime setTextColor:PHR_COLOR_TEXT_BLACK];
    [self.labelRanking setTextColor:PHR_COLOR_TEXT_ORANGE_BOLD];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];


}

- (void) setupUI:(FitnessModel*)model type:(ChartFitnessType)type color:(UIColor*)color {
    [self.viewValue setBackgroundColor:color];
    if(type == ChartFitnessTypeSteps){
        self.labelValue.text = model.step;
    } else if (type == ChartFitnessTypeWalkRun){
        self.labelValue.text = model.walkrun;
    }
    NSDate  *dateTime = [UIUtils dateFromServerTimeString:model.date];
    [self.labelDateTime setText:[UIUtils stringDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT_MMMM]];
    [self.labelRanking setText:@"Best"];
}

@end
