//
//  StandardHomeDateCell.m
//  PHR
//
//  Created by Luong Le Hoang on 10/2/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "StandardHomeDateCell.h"

@implementation StandardHomeDateCell

- (void)awakeFromNib {
    // Initialization code
//    [self.labelToday setFont:[FontUtils aileronRegularWithSize:12]];
//    [self.labelDay setFont:[FontUtils montserratSemiBoldWithSize:70]];
//    [self.labelDaySuffix setFont:[FontUtils aileronLightWithSize:9]];
//    [self.labelMonth setFont:[FontUtils montserratSemiBoldWithSize:9]];
    
    // Calculate today
    NSDate *today = [NSDate date];
    [self.labelToday setText:kLocalizedString(kToday)];
    NSDateComponents *components = [[NSCalendar currentCalendar] components:NSCalendarUnitDay | NSCalendarUnitMonth fromDate:today];
    [self.labelDay setText:[NSString stringWithFormat:@"%.2d", (int)components.day]];
    [self.labelDay sizeToFit];
    switch (components.day %10) {
        case 1:
            [self.labelDaySuffix setText:kLocalizedString(kDaySuffixST)];
            break;
        case 2:
            [self.labelDaySuffix setText:kLocalizedString(kDaySuffixND)];
            break;
        case 3:
            [self.labelDaySuffix setText:kLocalizedString(kDaySuffixRD)];
            break;
        default:
            [self.labelDaySuffix setText:kLocalizedString(kDaySuffixTH)];
            break;
    }
    NSDateFormatter *dateFormatter = [[NSDateFormatter alloc] init];
    [dateFormatter setDateFormat:@"MMM"];
    [self.labelMonth setText:[[dateFormatter stringFromDate:today] uppercaseString]
     ];
  _labelMonth.adjustsFontSizeToFitWidth = YES;
  _labelDay.adjustsFontSizeToFitWidth = YES;
}

@end
