//
//  AddNewReminderViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/4/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "PHRDateSlider.h"
#import "PHRTimeSlider.h"
#import "Base2ViewController.h"

@interface AddNewReminderViewController : Base2ViewController <PHRDateSliderDelegate, PHRTimeSliderDelegate>
@property (weak, nonatomic) IBOutlet PHRTimeSlider *timeSlider;
@property (weak, nonatomic) IBOutlet PHRDateSlider *dateSlider;
@property (weak, nonatomic) IBOutlet UIImageView *backgroundImage;
@property (weak, nonatomic) IBOutlet UILabel *labelTime;
@property (weak, nonatomic) IBOutlet UILabel *labelDate;
@property (weak, nonatomic) IBOutlet UILabel *labelSave;
@property (weak, nonatomic) IBOutlet UIView *viewSave;
@property (nonatomic,copy) void(^SaveCallBack)(NSDate *remindDate, int numberOfDay);

- (IBAction)onTapButtonSave:(id)sender;
@end
