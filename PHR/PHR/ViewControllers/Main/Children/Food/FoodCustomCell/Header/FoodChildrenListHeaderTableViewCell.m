//
//  FoodChildrenListHeaderTableViewCell.m
//  PHR
//
//  Created by NextopHN on 3/23/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "FoodChildrenListHeaderTableViewCell.h"

@interface FoodChildrenListHeaderTableViewCell()
{
    CGFloat fontSize1;
    CGFloat fontSize2;
    float totalKcalMorning;
    float totalKcalNoon;
    float totalKcalNight;
}

@end

@implementation FoodChildrenListHeaderTableViewCell

- (void)awakeFromNib {
    [self setupUI];
    // Initialization code
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];
    
    // Configure the view for the selected state
}

- (void)setupUI {
    fontSize1 = 13.0;
    fontSize2 = 12.0;
    [self.labelToday    setStyleRegularToLabelWithColor:PHR_COLOR_TEXT_DRAK_GRAY andSize:fontSize1];
    [self.labelNotToday setStyleRegularToLabelWithColor:PHR_COLOR_TEXT_DRAK_GRAY andSize:fontSize1];
    
    [self.labelMorning setStyleRegularToLabelWithColor:PHR_COLOR_TEXT_DRAK_GRAY andSize:fontSize2];
    [self.labelNoon    setStyleRegularToLabelWithColor:PHR_COLOR_TEXT_DRAK_GRAY andSize:fontSize2];
    [self.labelNight   setStyleRegularToLabelWithColor:PHR_COLOR_TEXT_DRAK_GRAY andSize:fontSize2];
    
    totalKcalMorning = 0;
    totalKcalNoon = 0;
    totalKcalNight = 0;
    
    [self.labelToday   setText:kLocalizedString(kToday)];
    [self.labelMorning  setText:[NSString stringWithFormat:@"%@: %0.0f",kLocalizedString(kMorning),totalKcalMorning]];
    [self.labelNoon     setText:[NSString stringWithFormat:@"%@: %0.0f",kLocalizedString(kNoon),totalKcalNoon]];
    [self.labelNight    setText:[NSString stringWithFormat:@"%@: %0.0f",kLocalizedString(kNight),totalKcalNight]];
    
    //    [self.contentView setBackgroundColor:[[UIColor yellowColor] colorWithAlphaComponent:0.3]];
    [self.viewTodayHighlight setBackgroundColor:[UIColor clearColor]];
    [self.contentView setBackgroundColor:[[UIColor whiteColor] colorWithAlphaComponent:0.5]];
    [self setBackgroundColor:[UIColor clearColor]];
    [self.viewMNE setBackgroundColor:[UIColor clearColor]];
    [self.viewRoundEdge setBackgroundColor:[UIColor clearColor]];
    self.viewRoundEdge.layer.borderColor = [[UIColor grayColor] CGColor];
    self.viewRoundEdge.layer.borderWidth = 1.0;
    //self.viewRoundEdge.layer.cornerRadius = 4;
    self.viewRoundEdge.layer.shadowOpacity = 1;
    self.viewRoundEdge.layer.shadowColor = [[UIColor grayColor] CGColor];
    self.viewRoundEdge.layer.shadowOffset = CGSizeZero;
}

- (void)setStyleToHeaderTableViewWithTitle:(NSString *)titleBtn withData:(NSMutableArray*)foodArray {
    [self setBackgroundColor:[UIColor clearColor]];
    totalKcalMorning = 0;
    totalKcalNoon = 0;
    totalKcalNight = 0;
    if (foodArray && foodArray.count > 0) {
        for (BabyFoodModel *obj in foodArray) {
            NSDate *dateTime = [UIUtils dateFromServerTimeString:obj.eating_time];
            int hour = [[UIUtils formatTimeGet24Hours:dateTime] intValue];
            if (hour >= 0 && hour < 11 ) {
                totalKcalMorning += [obj.kcal floatValue];
            } else if (hour >= 11 && hour < 17 ) {
                totalKcalNoon += [obj.kcal floatValue];
            } else {
                totalKcalNight += [obj.kcal floatValue];
            }
        }
    }
    if ( [titleBtn isEqualToString:kLocalizedString(kToday)]) {
        [self.labelToday    setStyleRegularToLabelWithColor:PHR_COLOR_TEXT_DRAK_GRAY andSize:15.0];
        //        [self.labelMorning setStyleRegularToLabelWithColor:PHR_COLOR_TEXT_GRAY andSize:13.0];
        //        [self.labelNoon    setStyleRegularToLabelWithColor:PHR_COLOR_TEXT_GRAY andSize:13.0];
        //        [self.labelNight   setStyleRegularToLabelWithColor:PHR_COLOR_TEXT_GRAY andSize:13.0];
        //        [self.labelToday setHidden:NO];
        
    } else {
        [self.labelToday    setStyleRegularToLabelWithColor:PHR_COLOR_TEXT_DRAK_GRAY andSize:12.0];
    }
    self.labelToday.layer.borderColor = [[UIColor grayColor] CGColor];
    self.labelToday.layer.borderWidth = 1.0;
    //self.labelToday.layer.cornerRadius = 4;
    self.labelToday.layer.shadowOpacity = 1;
    self.labelToday.layer.shadowColor = [[UIColor grayColor] CGColor];
    self.labelToday.layer.shadowOffset = CGSizeZero;
    [self.labelNotToday setHidden:YES];
    [self.labelToday    setText:titleBtn];
    [self.labelMorning  setText:[NSString stringWithFormat:@"%@: %0.0f",kLocalizedString(kMorning),totalKcalMorning]];
    [self.labelNoon     setText:[NSString stringWithFormat:@"%@: %0.0f",kLocalizedString(kNoon),totalKcalNoon]];
    [self.labelNight    setText:[NSString stringWithFormat:@"%@: %0.0f",kLocalizedString(kNight),totalKcalNight]];
}

@end
