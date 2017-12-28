//
//  LifeStyleNoteTableViewCell.m
//  PHR
//
//  Created by DEV-MinhNN on 1/29/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "LifeStyleNoteTableViewCell.h"

@implementation LifeStyleNoteTableViewCell

- (void)awakeFromNib {
    // Initialization code
        
    [self.viewContaint.layer setCornerRadius:10.0];
    [self.viewContaint.layer setBorderWidth:1.0];
    [self.viewContaint.layer setBorderColor:[UIColor lightGrayColor].CGColor];
    
    [self.lbTimeLifeStyleNote setEnabled:NO];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

- (void)fillDataCellAndSetStyle:(LifeStyleNoteModel *)modelLifeStyle {
    NSDate *dateTime = [UIUtils dateFromServerTimeString:modelLifeStyle.time_start_sleep];
    int timeNote = [[UIUtils formatTimeGetHours:dateTime] intValue];
    
    DLog(@"xxxxxxx %@",[UIUtils formatTimeGetAmOrPm:dateTime]);
    
    if ([[UIUtils formatTimeGetAmOrPm:dateTime] caseInsensitiveCompare:PHR_DATE_AM] == NSOrderedSame) {
        if (timeNote > 11) {
            [self.imgTimeNote setImage:[UIImage imageNamed:PHR_IMG_NOTE_AFTERNOON]];
        }
        else {
            [self.imgTimeNote setImage:[UIImage imageNamed:PHR_IMG_NOTE_MORNING]];
        }
        [self.lbAmOrPm setText:PHR_DATE_AM];
        [self.lbAmOrPm setTextColor:PHR_COLOR_DATE_TIME];
    }
    else {
        if (timeNote > 5) {
            [self.imgTimeNote setImage:[UIImage imageNamed:PHR_IMG_NOTE_NIGHT]];
        }
        else {
            [self.imgTimeNote setImage:[UIImage imageNamed:PHR_IMG_NOTE_AFTERNOON]];
        }
        [self.lbTime setTextColor:[UIColor whiteColor]];
        [self.lbAmOrPm setTextColor:[UIColor whiteColor]];
        [self.lbAmOrPm setText:PHR_DATE_PM];
    }
    
    self.lbTime.text = [UIUtils formatTimeGetHoursMinutes:dateTime];
    DLog(@"Time Note: %d",timeNote);
    
    int totalSleepping = [modelLifeStyle.total_hour_sleep intValue];
    int hours = totalSleepping / 3600;
    int minutes = (totalSleepping - 3600 * hours) / 60;
    
    if (hours > 0) {
        [self.lbTimeLifeStyleNote setText:[NSString stringWithFormat:@"%dh%.2d'", hours, minutes]];
    }
    else  {
        [self.lbTimeLifeStyleNote setText:[NSString stringWithFormat:@"%.2d'", minutes]];
    }
    
    int rating = modelLifeStyle.rating_sleep;
    int number = rating;
    [self resetStar];
    
    switch (number) {
        case 1: {
            [self.imgStart1 setImage:[UIImage imageNamed:@"icon_star"]];
        }
            break;
            
        case 2: {
            [self.imgStart1 setImage:[UIImage imageNamed:@"icon_star"]];
            [self.imgStart2 setImage:[UIImage imageNamed:@"icon_star"]];
        }
            break;
            
        case 3: {
            [self.imgStart1 setImage:[UIImage imageNamed:@"icon_star"]];
            [self.imgStart2 setImage:[UIImage imageNamed:@"icon_star"]];
            [self.imgStart3 setImage:[UIImage imageNamed:@"icon_star"]];
        }
            break;
            
        case 4: {
            [self.imgStart1 setImage:[UIImage imageNamed:@"icon_star"]];
            [self.imgStart2 setImage:[UIImage imageNamed:@"icon_star"]];
            [self.imgStart3 setImage:[UIImage imageNamed:@"icon_star"]];
            [self.imgStart4 setImage:[UIImage imageNamed:@"icon_star"]];
        }
            break;
            
        case 5: {
            [self.imgStart1 setImage:[UIImage imageNamed:@"icon_star"]];
            [self.imgStart2 setImage:[UIImage imageNamed:@"icon_star"]];
            [self.imgStart3 setImage:[UIImage imageNamed:@"icon_star"]];
            [self.imgStart4 setImage:[UIImage imageNamed:@"icon_star"]];
            [self.imgStart5 setImage:[UIImage imageNamed:@"icon_star"]];
        }
            break;
        default:
            break;
    }
}

-(void) resetStar{
    [self.imgStart1 setImage:[UIImage imageNamed:@"icon_star_empty"]];
    [self.imgStart2 setImage:[UIImage imageNamed:@"icon_star_empty"]];
    [self.imgStart3 setImage:[UIImage imageNamed:@"icon_star_empty"]];
    [self.imgStart4 setImage:[UIImage imageNamed:@"icon_star_empty"]];
    [self.imgStart5 setImage:[UIImage imageNamed:@"icon_star_empty"]];

}

@end
