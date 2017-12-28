//
//  FoodChildrenTableViewCell.m
//  PHR
//
//  Created by NextopHN on 3/23/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "FoodChildrenTableViewCell.h"

@implementation FoodChildrenTableViewCell

- (void)awakeFromNib {
    // Initialization code
    
    [self.viewContent.layer setCornerRadius:10.0];
    [self.viewContent.layer setBorderColor:[UIColor lightGrayColor].CGColor];
    [self.viewContent.layer setBorderWidth:1.0];
    [self.viewContent setBackgroundColor:[[UIColor whiteColor] colorWithAlphaComponent:0.5]];
    [self.contentView setBackgroundColor:[UIColor clearColor]];
    [self setBackgroundColor:[UIColor clearColor]];
    [self.labelTime setStyleRegularToLabelWithColor:PHR_COLOR_GRAY andSize:14.0];
    [self.labelKcal setStyleRegularToLabelWithColor:PHR_COLOR_GRAY_DARK_TEMPERATURE andSize:14.0];
    
    [self.viewLeft setBackgroundColor:[UIColor clearColor]];
    self.viewLeft.layer.borderColor = [[UIColor grayColor] CGColor];
    self.viewLeft.layer.borderWidth = 1.0;
    //self.viewKcal.layer.cornerRadius = 4;
    self.viewLeft.layer.shadowOpacity = 1;
    self.viewLeft.layer.shadowColor = [[UIColor grayColor] CGColor];
    self.viewLeft.layer.shadowOffset = CGSizeZero;
    
    [self.viewRight setBackgroundColor:[UIColor clearColor]];
    self.viewRight.layer.borderColor = [[UIColor grayColor] CGColor];
    self.viewRight.layer.borderWidth = 1.0;
    //self.viewKcal.layer.cornerRadius = 4;
    self.viewRight.layer.shadowOpacity = 1;
    self.viewRight.layer.shadowColor = [[UIColor grayColor] CGColor];
    self.viewRight.layer.shadowOffset = CGSizeZero;
    
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];
    
    // Configure the view for the selected state
}

- (void)fillDataToFoodCell:(BabyFoodModel *)model {
    [self.labelKcal setText:[NSString stringWithFormat:@"%@ Kcal", model.kcal]];
    [self.labelTime setText:[self getTimeStyle:[UIUtils dateFromServerTimeString:model.eating_time]]];
    
    //NSDate *dateTime = [UIUtils dateFromServerTimeString:model.eating_time];
    //int hour = [[UIUtils formatTimeGetHours:dateTime] intValue];

}

- (NSString *)getTimeStyle:(NSDate *)dateTime {
    NSDateFormatter *dateFormat = [[NSDateFormatter alloc] init];
    [dateFormat setDateFormat:@"hh:mm a"];
    [dateFormat setLocale:[[NSLocale alloc] initWithLocaleIdentifier:PHR_DATETIME_LOCATE]];
    NSCalendar *calendar = [NSCalendar calendarWithIdentifier:NSCalendarIdentifierGregorian];
    [dateFormat setCalendar:calendar];
    
    NSString *theDate = [dateFormat stringFromDate:dateTime];
    return theDate;
}
@end
