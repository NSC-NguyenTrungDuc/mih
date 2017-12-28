//
//  LifeStyleNoteViewController.h
//  PHR
//
//  Created by DEV-MinhNN on 10/2/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "RatingBar.h"
#import "RatingSleepDialog.h"

@interface LifeStyleNoteViewController : Base2ViewController<UITextViewDelegate,RatingDelegate> {
    BOOL isRunTime;
    NSTimer *myTimer;
    int currentTimeInSeconds;
    NSDate *myCurrentDate;
    int tagButton;
}

@property (weak, nonatomic) IBOutlet UIButton *btnRunTime;
@property (strong, nonatomic) RatingBar *ratingStar;
@property (weak, nonatomic) IBOutlet UIImageView *imgIconEditedWalkingUp;
@property (weak, nonatomic) IBOutlet UIView *ratingBar;

@property (weak, nonatomic) IBOutlet UIView *viewDownNavigation;
@property (weak, nonatomic) IBOutlet UIView *viewHours;
@property (weak, nonatomic) IBOutlet UIView *viewSeconds;

@property (weak, nonatomic) IBOutlet UILabel *lbHours;
@property (weak, nonatomic) IBOutlet UILabel *lbMinutes;
@property (weak, nonatomic) IBOutlet UILabel *lbSeconds;

@property (weak, nonatomic) IBOutlet UILabel *lbStartSleeping;
@property (weak, nonatomic) IBOutlet UILabel *lbWakingUp;
@property (weak, nonatomic) IBOutlet UILabel *lbSleepingTime;
@property (weak, nonatomic) IBOutlet UILabel *lbRatingSleep;

@property (weak, nonatomic) IBOutlet UILabel *lbTimeStartSleeping;
@property (weak, nonatomic) IBOutlet UILabel *lbTimeWalkingUp;
@property (weak, nonatomic) IBOutlet UILabel *lbTimeSleeping;

@property (weak, nonatomic) IBOutlet UIView *viewSeparator1;
@property (weak, nonatomic) IBOutlet UIView *viewSeparator2;
@property (weak, nonatomic) IBOutlet UIView *viewSeparator3;

@property (weak, nonatomic) IBOutlet UIButton *btnStartSleeping;
@property (weak, nonatomic) IBOutlet UIButton *btnWakingUp;
@property (weak, nonatomic) IBOutlet DALinedTextView *lifeStyleNote;

@property (weak, nonatomic) IBOutlet UILabel *hours;
@property (weak, nonatomic) IBOutlet UILabel *minutes;
@property (weak, nonatomic) IBOutlet UILabel *seconds;

@property (weak, nonatomic) IBOutlet UIImageView *backgroundLSN;

@property (strong, nonatomic) IBOutlet UIView *viewDateTime;
@property (weak, nonatomic) IBOutlet UIDatePicker *pickerDateTime;
@property (weak, nonatomic) IBOutlet UINavigationBar *navigationbarDateLife;
@property (weak, nonatomic) IBOutlet UIView *viewPickerSeparator;


@property (weak, nonatomic) NSString *babySleepID;
@property (weak, nonatomic) NSString *idLifeStyleNote;

@property (copy, nonatomic) void (^addLifeStyleCallBack)(LifeStyleNoteModel * type);
@property (weak, nonatomic) IBOutlet UILabel *lblSaveData;
@property (weak, nonatomic) IBOutlet UIButton *btnSaveData;
- (IBAction)actionSaveData:(id)sender;
@property (weak, nonatomic) IBOutlet UIView *viewAdd;

@property (nonatomic, strong) LifeStyleNoteModel *model;
@property (nonatomic, assign) BOOL isAddingMode; // Check viewcontroller is showing in Adding Mode or Normal


@end
