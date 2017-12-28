//
//  ChildrenFoodTableViewCell.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "ChildrenFoodTableViewCell.h"

@implementation ChildrenFoodTableViewCell

- (void)awakeFromNib {
    [super awakeFromNib];
    [self.contentView.layer setBorderColor:[UIColor lightGrayColor].CGColor];
    [self.contentView.layer setBorderWidth:0.5];
    [self.labelDate setStyleRegularToLabelWithColor:PHR_COLOR_TEXT_MEDICINES andSize:14.0];
    [self.labelValue setStyleRegularToLabelWithColor:PHR_COLOR_TEXT_DRAK_GRAY andSize:14.0];
    self.labelValue.textAlignment = NSTextAlignmentRight;
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

- (void) setupUI:(ChildrenFoodModel*)model {
    self.labelValue.text = [NSString stringWithFormat:@"%.2f %@",[model.kcal doubleValue],kLocalizedString(kUnitKcal)];
    NSDate  *dateTime = [UIUtils dateFromServerTimeString:model.date];
    [self.labelDate setText:[UIUtils formatDateOppositeStyle:dateTime]];
    
}
@end
