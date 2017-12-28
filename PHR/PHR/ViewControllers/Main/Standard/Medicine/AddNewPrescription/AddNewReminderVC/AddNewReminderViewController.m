//
//  AddNewReminderViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/4/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddNewReminderViewController.h"

@interface AddNewReminderViewController ()


@end

@implementation AddNewReminderViewController {
  int numberOfDay;
  NSDate *remindDate;
  NSCalendar *calendar;
}

- (void)viewDidLoad {
  [super viewDidLoad];
  [self initView];
  [self.dateSlider initialize:self];
}

- (void)initView {
  [self setupNavigationBarTitle:kLocalizedString(kTitleAddReminder) iconLeft:@"Icon_Person" iconRight:nil iconMiddle:nil isDismissView:true colorLeft:[PHR_COLOR_MEDICINE_OVERLAY colorWithAlphaComponent:0.6]colorRight:[PHR_COLOR_MEDICINE_MAIN_COLOR colorWithAlphaComponent:0.6]];
  self.labelDate.text = kLocalizedString(kExpireAfter);
  self.labelTime.text = kLocalizedString(kTime);
  self.labelTime.textColor = PHR_COLOR_GRAY;
  self.labelDate.textColor = PHR_COLOR_GRAY;
  self.labelTime.backgroundColor = [UIColor colorWithRed:238./255. green:238./255. blue:238./255. alpha:1];
  self.labelDate.backgroundColor = [UIColor colorWithRed:238./255. green:238./255. blue:238./255. alpha:1];
  [self.labelTime alignTextTopLeft];
  [self.labelDate alignTextTopLeft];
  [self.labelSave setText:kLocalizedString(kSave)];
  calendar = [[NSCalendar alloc] initWithCalendarIdentifier: NSCalendarIdentifierGregorian];
  [calendar setTimeZone:[NSTimeZone localTimeZone]];
  
}

- (void)viewWillAppear:(BOOL)animated {
  [super viewWillAppear:animated];
  [self setImageToBackgroundStandard:self.backgroundImage];
}

- (void)viewDidLayoutSubviews {
  [super viewDidLayoutSubviews];
  [self.timeSlider initialize:self];
}

- (void)scrollViewDateDidScroll:(int)date {
  numberOfDay = date;
}

- (void)scrollViewTimeDidScroll:(int)hour andMinute:(int)minute {
  remindDate = [calendar dateBySettingHour:hour minute:minute second:0 ofDate:[NSDate date] options:0];
}

- (IBAction)onTapButtonSave:(id)sender {
  
  self.SaveCallBack(remindDate, numberOfDay);
  [self dismissViewControllerAnimated:YES completion:nil];
}
@end
