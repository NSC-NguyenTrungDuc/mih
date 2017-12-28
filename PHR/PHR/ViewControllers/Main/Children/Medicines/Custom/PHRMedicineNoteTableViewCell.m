//
//  PHRMedicineNoteTableViewCell.m
//  PHR
//
//  Created by DEV-MinhNN on 10/28/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "PHRMedicineNoteTableViewCell.h"
#import "UILabel+Extension.h"

@implementation PHRMedicineNoteTableViewCell

- (void)awakeFromNib {
    // Initialization code
    [self setStyleToCell];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];
    
    // Configure the view for the selected state
}

- (void)setStyleToCell {
    [self.lbTime setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:10.0];
    [self.lbNameDiaper setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
    [self.lbDiaperState setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
    [self.lbNumberMedicine setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
    [self.lbNameMedicine setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];

    [self.viewContanit setBackgroundColor:[UIColor whiteColor]];
    [self.viewContanit.layer setBorderWidth:0.5];
    [self.viewContanit.layer setBorderColor:PHR_COLOR_GRAY.CGColor];
    [self.viewContanit.layer setCornerRadius:10.0];
    [self.viewContanit setClipsToBounds:YES];
    
    [self.viewCurverBig.layer setCornerRadius:(self.viewCurverBig.frame.size.height / 2)];
    [self.viewCurverBig setBackgroundColor:[UIColor clearColor]];
    [self.viewCurverBig.layer setAnchorPoint:CGPointMake(0.5, 0.5)];
    [self.viewCurverBig.layer setBorderColor:PHR_COLOR_GRAY.CGColor];
    [self.viewCurverBig.layer setBorderWidth:1.0];
    
    [self.viewCurverSmall setBackgroundColor:[UIColor clearColor]];
    [self.viewCurverSmall.layer setAnchorPoint:CGPointMake(0.5, 0.5)];
    [self.viewCurverSmall.layer setBorderWidth:2.5];
    [self.viewCurverSmall.layer setCornerRadius:(self.viewCurverSmall.frame.size.height / 2)];
}

- (void)setDataMedicineToCell:(MedicineNote *)medicine {
    [self.lbNumberMedicine setHidden:NO];
    [self.imgSliderBar setHidden:NO];
    [self.imgMedicine setHidden:NO];
    
    [self.lbNameDiaper setHidden:YES];
    [self.lbDiaperState setHidden:YES];
    [self.viewCurverBig setHidden:YES];
    [self.viewCurverSmall setHidden:YES];
    
    [self.lbNameMedicine setText:[NSString stringWithFormat:@"%@", medicine.name]];
    [self.lbNumberMedicine setText:[NSString stringWithFormat:@"%d", medicine.quantity]];
    [self.lbTime setText:[NSString stringWithFormat:@"%@",medicine.time_take_medicine]];
    
    int methodValue = [medicine.method intValue];
    switch (methodValue) {
        case 0:
            [self.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine"]];
            break;
        case 1:
            [self.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_2"]];
            break;
        case 2:
            [self.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_3"]];
            break;
        case 3:
            [self.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_4"]];
            break;
        case 4:
            [self.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_5"]];
            break;
        case 5:
            [self.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_6"]];
            break;
        case 6:
            [self.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_7"]];
            break;
        default:
            break;
    }
    
    NSString *dateTime = medicine.time_take_medicine;
    int hour = [dateTime intValue];
    
    if ([dateTime rangeOfString:PHR_DATE_PM].location == NSNotFound) {
        if (hour > 11) {
            [self.imgTimeNote setImage:[UIImage imageNamed:@"timeNoteOrange"]];
        }
        else {
            [self.imgTimeNote setImage:[UIImage imageNamed:@"TimeNote"]];
        }
        [self.lbTime setTextColor:PHR_COLOR_DATE_TIME];
        [self.imgClock setImage:[UIImage imageNamed:@"Icon_Clock"]];
    }
    else {
        if (hour > 5) {
            [self.imgTimeNote setImage:[UIImage imageNamed:@"TimeNoteNight"]];
        }
        else {
            [self.imgTimeNote setImage:[UIImage imageNamed:@"timeNoteOrange"]];
        }
        [self.lbTime setTextColor:[UIColor whiteColor]];
        [self.imgClock setImage:[UIImage imageNamed:@"Icon_Clock_White"]];
    }
}

- (void)setDataDiaperToCell:(Diaper *)diaper {
    [self.lbNumberMedicine setHidden:YES];
    [self.imgSliderBar setHidden:YES];
    [self.imgMedicine setHidden:YES];
    [self.lbNameMedicine setHidden:YES];

    if ([diaper.method isEqualToString:kLocalizedString(kPee)]) {
        [self.viewContanit.layer setBorderColor:PHR_COLOR_SKY_BLUE.CGColor];

        [self.viewCurverBig setHidden:YES];
        [self.viewCurverSmall setHidden:YES];
        [self.lbDiaperState setHidden:YES];
    }
    else {
        UIColor *curverColor = [UIUtils colorFromHexString:diaper.color];
        [self.viewCurverSmall.layer setBorderColor:curverColor.CGColor];
        
        [self.viewCurverBig setHidden:NO];
        [self.viewCurverSmall setHidden:NO];
        [self.lbDiaperState setHidden:NO];

        [self.viewContanit.layer setBorderColor:PHR_COLOR_GRAY.CGColor];
        [self.lbDiaperState setText:[NSString stringWithFormat:@"%@", diaper.state]];
    }
    
    [self.lbNameDiaper setText:[NSString stringWithFormat:@"%@", diaper.method]];
    
    NSDate *time = [UIUtils dateFromServerTimeString:diaper.time_pee_poo];
    [self.lbTime setText:[NSString stringWithFormat:@"%@",[UIUtils formatTimeStyle:time]]];

    NSDate *dateTime = [UIUtils dateFromServerTimeString:diaper.time_pee_poo];
    NSString *isAmOPm = [UIUtils formatTimeGetAmOrPm:dateTime];
    int hour = [[UIUtils formatTimeGetHours:dateTime] intValue];

    if ([isAmOPm isEqualToString:PHR_DATE_AM]) {
        if (hour > 11) {
            [self.imgTimeNote setImage:[UIImage imageNamed:@"timeNoteOrange"]];
            [self.lbTime setTextColor:[UIColor whiteColor]];
            [self.imgClock setImage:[UIImage imageNamed:@"Icon_Clock_White"]];
        }
        else {
            [self.imgTimeNote setImage:[UIImage imageNamed:@"TimeNote"]];
            [self.lbTime setTextColor:PHR_COLOR_DATE_TIME];
            [self.imgClock setImage:[UIImage imageNamed:@"Icon_Clock"]];
        }
    }
    else {
        if (hour > 5) {
            [self.imgTimeNote setImage:[UIImage imageNamed:@"TimeNoteNight"]];
        }
        else {
            [self.imgTimeNote setImage:[UIImage imageNamed:@"timeNoteOrange"]];
        }
        [self.lbTime setTextColor:[UIColor whiteColor]];
        [self.imgClock setImage:[UIImage imageNamed:@"Icon_Clock_White"]];
    }
}

@end
