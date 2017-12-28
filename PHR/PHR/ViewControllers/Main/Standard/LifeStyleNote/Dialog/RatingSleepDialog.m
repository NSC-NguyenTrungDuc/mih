//
//  RatingSleepDialog.m
//  PHR
//
//  Created by BillyMobile on 5/31/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "RatingSleepDialog.h"

#define RATING_BAR_WIDTH 200
#define RATING_BAR_HEIGHT 50

@implementation RatingSleepDialog

+ (RatingSleepDialog*)createView{
    RatingSleepDialog *screen = [[[NSBundle mainBundle] loadNibNamed:NSStringFromClass([RatingSleepDialog class]) owner:self options:nil] objectAtIndex:0];
    
    return screen;
}

-(void) awakeFromNib{
    self.viewContent.layer.cornerRadius = 8;
    self.backgroundColor = [UIColor colorWithRed:1/255.0 green:1/255.0 blue:1.0/255.0 alpha:0.6];
    
    self.lblYouHadJustWoken.font = [FontUtils aileronRegularWithSize:13.0];
    self.lblYouHadJustWoken.text = kLocalizedString(@"You have just woken!");
    
    self.lblHowWasYourSleep.font = [FontUtils aileronRegularWithSize:17.0];
    self.lblHowWasYourSleep.text = kLocalizedString(@"How was your sleep?");
    
    self.lblNumberStar.font = [FontUtils aileronRegularWithSize:12.0];
    
    self.btnRatingSleep.titleLabel.font = [FontUtils aileronRegularWithSize:11.0];
    self.btnRatingSleep.titleLabel.text = kLocalizedString(@"Rating your sleep");
//    self.btnRatingSleep.layer.borderWidth = 1.0;
//    self.btnRatingSleep.layer.cornerRadius = 3;
//    self.btnRatingSleep.layer.borderColor = [UIColor lightGrayColor].CGColor;
    // add rating bar
    
    // add rating bar
    if(IS_IPHONE_6){
        self.ratingStar = [[RatingBar alloc] initWithFrame:CGRectMake((10+(self.viewRatingBar.frame.size.width - RATING_BAR_WIDTH))/2,0, RATING_BAR_WIDTH, RATING_BAR_HEIGHT)];
    }else{
        self.ratingStar = [[RatingBar alloc] initWithFrame:CGRectMake(0,0, RATING_BAR_WIDTH, RATING_BAR_HEIGHT)];
    }
    
    [self.viewRatingBar addSubview:self.ratingStar];
    self.ratingStar.center = self.ratingStar.center;
    self.ratingStar.delegate = self;
}

- (void)showInView:(UIView*)parentView{
    self.ratingStar.starNumber = 0;
    
    self.frame = CGRectMake(0, 0, parentView.bounds.size.width, parentView.bounds.size.height);
    [parentView addSubview:self];
    __block CGRect frame = self.viewContent.frame;
    frame.origin.y = parentView.bounds.size.height;
    self.viewContent.frame = frame;
    [UIView animateWithDuration:0.25 animations:^{
        frame.origin.y = parentView.bounds.size.height - frame.size.height;
        self.viewContent.frame = frame;
    }];
    
}

- (void)hiddenInView{
    __block CGRect frame = self.viewContent.frame;
    [UIView animateWithDuration:0.25 animations:^{
        frame.origin.y = self.frame.size.height;
        self.viewContent.frame = frame;
    } completion:^(BOOL finished){
        [self removeFromSuperview];
        //[self performSelectorOnMainThread:@selector(removeFromSuperview) withObject:nil waitUntilDone:NO];
    }];
}

- (IBAction)actionRatingSleep:(id)sender {
    [self hiddenInView];
    DLog(@"Start Time:%@",self.startSleepTime);
    LifeStyleNoteModel *objLifeStyle = [[LifeStyleNoteModel alloc] init];
    
    objLifeStyle.time_start_sleep = [UIUtils stringUTCDate:[self dateTimeFromString:self.startSleepTime] withFormat:PHR_SERVER_DATE_TIME_FORMAT];
    myCurrentDate = [NSDate date];
    
    objLifeStyle.time_wake_up = [UIUtils stringUTCDate:myCurrentDate withFormat:PHR_SERVER_DATE_TIME_FORMAT];
    
    [self calculateTimeSleeping:[self dateTimeFromString:self.startSleepTime] andTimeWalkingUp:myCurrentDate];
    
    objLifeStyle.total_hour_sleep = _totalTimeSleep;
    objLifeStyle.rating_sleep     = (int)self.ratingStar.starNumber;
    objLifeStyle.note             = PHR_STR_NULL;
    objLifeStyle.time_awake       = PHR_STR_NULL;
    
    [[PHRClient instance] requestAddNewLifeStyle:objLifeStyle completed:^(id result) {
    } error:^(NSString * error) {
        [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
    }];
}

- (NSString *)stringFromDate:(NSDate *)dateTime {
    return [UIUtils stringDate:dateTime withFormat:@"hh:mm:ss a yyyy/MM/dd"];
}

- (NSDate *)dateTimeFromString :(NSString *)stringDate {
    return [UIUtils dateFromString:stringDate withFormat:@"hh:mm:ss a yyyy/MM/dd"];
}

- (IBAction)actionHidden:(id)sender {
    [self hiddenInView];
}

- (void)calculateTimeSleeping:(NSDate *)timeStart andTimeWalkingUp:(NSDate *)timeWalkingUp{
    
   
    if(timeWalkingUp != nil && timeStart != nil){
         NSInteger seconds = [timeWalkingUp timeIntervalSinceDate:timeStart];
        _totalTimeSleep = [NSString stringWithFormat:@"%ld", (long)seconds];
        DLog(@"Total time: %@",_totalTimeSleep);
    }else{
        _totalTimeSleep = @"00";
    }
    
}

//- (NSDate *)dateTimeFromString :(NSString *)stringDate {
//    NSDateFormatter *dateFormatter = [[NSDateFormatter alloc] init];
//    [dateFormatter setDateFormat:@"hh:mm a yyyy/MM/dd"];
//    [dateFormatter setLocale:[[NSLocale alloc] initWithLocaleIdentifier:PHR_DATETIME_LOCATE]];
//    
//    NSDate *capturedStartDate = [dateFormatter dateFromString:stringDate];
//    return capturedStartDate;
//}

-(void) setRating:(NSInteger)rating isHuman:(BOOL) isHuman{
    self.lblNumberStar.text = [NSString stringWithFormat:@"%ld %@",rating,kLocalizedString(@"Star")];
}

/*
// Only override drawRect: if you perform custom drawing.
// An empty implementation adversely affects performance during animation.
- (void)drawRect:(CGRect)rect {
    // Drawing code
}
*/

@end
