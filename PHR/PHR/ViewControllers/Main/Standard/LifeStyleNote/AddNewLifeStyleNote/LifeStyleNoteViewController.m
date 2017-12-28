//
//  LifeStyleNoteViewController.m
//  PHR
//
//  Created by DEV-MinhNN on 10/2/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#define PHR_TAG_BTN_STARTSLEEPING    1
#define PHR_TAG_BTN_WALKINGUP        2

#define PHR_TIME_ZERO                @"00"
#define PHR_DATE_TIME_ZERO           @"00:00:00"

#define RATING_BAR_WIDTH   250
#define RATING_BAR_HEIGHT  50

#import "LifeStyleNoteViewController.h"
#import "LifeStyleNoteModel.h"
#import "MasterDataManager.h"
#import "PHRSample.h"
#import "StorageManager.h"

@interface LifeStyleNoteViewController () {
    NSString *_totalTimeSleep;
    LifeStyleNoteModel *_currentLifeStyleModel;
}

@end

@implementation LifeStyleNoteViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view from its nib.
    isRunTime = NO;
    [self initializeLifeStyleNote];
    self.ratingScreen = [RatingSleepDialog createView];
    
    // Init datetime picker
    if (IOS_VERSION >= 8) {
        _pickerDateTime.calendar = [NSCalendar calendarWithIdentifier:NSCalendarIdentifierGregorian];
    }
    else{
        NSCalendar *calendar = [[NSCalendar alloc] initWithCalendarIdentifier:NSCalendarIdentifierGregorian];
        _pickerDateTime.calendar = calendar;
    }
    [_pickerDateTime setTimeZone:[NSTimeZone localTimeZone]];
  
  
   [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(setUpTime) name:@"setUpTime" object:nil];
}

- (void)viewWillDisappear:(BOOL)animated{
  [super viewWillDisappear:animated];
  [[NSNotificationCenter defaultCenter] removeObserver:self];
}


- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
  
    [self setUpTime];
}

- (void)setbackground{
    if (self.type == PHRGroupTypeBaby) {
        [self setImageToBackgroundBaby:self.backgroundLSN];
    } else {
        [self setImageToBackgroundStandard:self.backgroundLSN];
    }
}
- (void)actionNavigationBarItemRight {
    if (isRunTime) {
        return;
    }
    if ([self.lbTimeStartSleeping.text isEqualToString:PHR_DATE_TIME_ZERO]) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kEnterTime)];
        return;
    }
    if ([self.lbTimeWalkingUp.text isEqualToString:PHR_DATE_TIME_ZERO]) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kEnterTime)];
        return;
    }
    
        [self resetRemider];
        LifeStyleNoteModel *objLifeStyle = [[LifeStyleNoteModel alloc] init];
        objLifeStyle.time_start_sleep = [UIUtils stringUTCDate:[self dateTimeFromString:self.lbTimeStartSleeping.text] withFormat:PHR_SERVER_DATE_TIME_FORMAT];
        objLifeStyle.time_wake_up     = [UIUtils stringUTCDate:[self dateTimeFromString:self.lbTimeWalkingUp.text] withFormat:PHR_SERVER_DATE_TIME_FORMAT];
        objLifeStyle.total_hour_sleep = _totalTimeSleep;
        objLifeStyle.rating_sleep     = (int)self.ratingStar.starNumber;
        objLifeStyle.note             = PHR_STR_NULL;
        objLifeStyle.time_awake       = PHR_STR_NULL;
        objLifeStyle.id               = [self.idLifeStyleNote intValue];
        _currentLifeStyleModel = objLifeStyle;
        
        __weak __typeof__(self) weakSelf = self;
        if (self.idLifeStyleNote && ![self.idLifeStyleNote isEmpty]) {
            NSDictionary *params = @{
                                     KEY_LifeStyleNote_Time_Sleep   : objLifeStyle.time_start_sleep,
                                     KEY_LifeStyleNote_Time_WakeUp  : objLifeStyle.time_wake_up,
                                     KEY_LifeStyleNote_Total_time   : objLifeStyle.total_hour_sleep,
                                     KEY_LifeStyleNote_Rating_Sleep : [NSString stringWithFormat:@"%d",objLifeStyle.rating_sleep],
                                     KEY_LifeStyleNote_Time_Awake   : objLifeStyle.time_awake,
                                     KEY_Note                       : objLifeStyle.note,
                                     };
            [PHRAppDelegate showLoading];
            [[PHRClient instance]requestUpdateData:API_LifeStyleNote andProdileId:PHRAppStatus.currentStandard.profileId
                                       andObjectId:[NSString stringWithFormat:@"%d",_currentLifeStyleModel.id] withParam:params completion:^(MFRession *result) {
                                           [PHRAppDelegate hideLoading];
                                           if (result) {
                                               self.addLifeStyleCallBack(_currentLifeStyleModel);
                                               [self.navigationController popViewControllerAnimated:YES];
                                           }
                                           else {
                                               [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
                                           }
                                       }];
        }
        else {
            [PHRAppDelegate showLoading];
            [[PHRClient instance] requestAddNewLifeStyle:objLifeStyle completed:^(id result) {
                [PHRAppDelegate hideLoading];
                NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:result] valueForKeyPath:KEY_Content];
                _currentLifeStyleModel = [[LifeStyleNoteModel alloc] initWithDictionary:newDict error:nil];
                self.addLifeStyleCallBack(_currentLifeStyleModel);
                [weakSelf backToPopView];
            } error:^(NSString * error) {
                 [PHRAppDelegate hideLoading];
                [NSUtils showMessage:[NSString stringWithFormat:@"%@", error.description] withTitle:kLocalizedString(kTitleAlertError)];
            }];
            
            if ([PHRAppStatus checkCurrentStandardIsMaster]) {
                double value = [_totalTimeSleep doubleValue];
                [self savePHRSamleValue:value type:0];
            }
        }
    
}

// Save PHRSample to DB
- (void)savePHRSamleValue:(double)value type:(NSInteger)type{
    PHRSample *sample = [[PHRSample alloc] init];
    if (value < 0) {
        value = 0;
    }
    sample.value = value;
    sample.profile_id = PHRAppStatus.masterProfileId;
    sample.type = HKCategoryTypeIdentifierSleepAnalysis;
    sample.record_date = [self dateTimeFromString:self.lbTimeStartSleeping.text];
    sample.source_bundle = [PHRSample bundle];
    sample.synced = 1;
    [[StorageManager instance] savePHRSampleManual:sample];
}

- (void)backToPopView {
    [self.navigationController popViewControllerAnimated:YES];
}

#pragma mark - Initialize Life Style Note View

- (void)initializeLifeStyleNote {
      
    [self.btnStartSleeping setTag:PHR_TAG_BTN_STARTSLEEPING];
    [self.btnWakingUp setTag:PHR_TAG_BTN_WALKINGUP];
    
    [self.btnStartSleeping addTarget:self action:@selector(showDateTimeLife:) forControlEvents:UIControlEventTouchUpInside];
    [self.btnWakingUp addTarget:self action:@selector(showDateTimeLife:) forControlEvents:UIControlEventTouchUpInside];
    
    [self.viewDownNavigation setStyleRegularToViewWithAlpha:0.2];
    [self.viewHours setStyleRegularToViewWithAlpha:0.2];
    [self.viewSeconds setStyleRegularToViewWithAlpha:0.2];
    
    [self.viewSeparator1 setStyleRegularToViewWithAlpha:0.2];
    [self.viewSeparator2 setStyleRegularToViewWithAlpha:0.2];
    [self.viewSeparator3 setStyleRegularToViewWithAlpha:0.2];
    
    [self.navigationbarDateLife setBarTintColor:[UIColor whiteColor]];
    [self.viewPickerSeparator setStyleRegularToViewWithAlpha:0.5];
    
    [self.lbStartSleeping setStyleRegularToLabelWithSize:14.0];
    [self.lbWakingUp setStyleRegularToLabelWithSize:14.0];
    [self.lbSleepingTime setStyleRegularToLabelWithSize:14.0];
    [self.lbTimeStartSleeping setStyleRegularToLabelWithSize:14.0];
    
    [self.lbStartSleeping setText:kLocalizedString(kTitleStartSleeping)];
    [self.lbWakingUp setText:kLocalizedString(kTitleWalkingUp)];
    [self.lbSleepingTime setText:kLocalizedString(kTitleSleepingTime)];
    [self.lbRatingSleep setText:kLocalizedString(kTitleRatingSleep)];
    
    [self.lbTimeWalkingUp setStyleRegularToLabelWithSize:14.0];
    [self.lbTimeSleeping setStyleRegularToLabelWithSize:14.0];
    [self.lbRatingSleep setStyleRegularToLabelWithSize:14.0];
    
    [self.hours setStyleLightToLabelWithSize:14.0];
    [self.minutes setStyleLightToLabelWithSize:14.0];
    [self.seconds setStyleLightToLabelWithSize:14.0];
    
    [self.hours setText:kLocalizedString(kHour)];
    [self.minutes setText:kLocalizedString(kMinute)];
    [self.seconds setText:kLocalizedString(kSecond)];
    
    self.viewAdd.backgroundColor = PHR_COLOR_LIFE_STYLE_MAIN_COLOR;
    self.lblSaveData.text = kLocalizedString(kSave);
    [self checkProfileToShowView];
    
    /* ---------------------------- View Contain Date Time----------------------------- */
    self.viewDateTime.frame = CGRectMake(0, 2500, SCREEN_WIDTH, self.viewDateTime.frame.size.height);
    [self.view addSubview:self.viewDateTime];
    
    /* --------------------------------- Note Style --------------------------------- */
    [self.lifeStyleNote setDelegate:self];
    self.lifeStyleNote.text = kLocalizedString(kNote);
    self.lifeStyleNote.textColor = [UIColor lightGrayColor];
    
    if (self.type == PHRGroupTypeBaby) {
        if (self.babySleepID && ![self.babySleepID isEmpty]) {
            //
        }
        
        [self.lbRatingSleep setHidden:YES];
        [self setupNavigationBarTitle:kLocalizedString(kBabyTitleSleep) titleIcon:@"icon_sleep" rightItem:[self itemRightBabyKey:kSave]];
    }
    else {
        [self.lbRatingSleep setHidden:NO];
        [self setupNavigationBarTitle:kLocalizedString(kTitleLifeStyle) titleIcon:@"Life style note" rightItem:nil];
    }
    
    [self.lbRatingSleep setHidden:NO];
    [self setupNavigationBarTitle:kLocalizedString(kTitleLifeStyle) titleIcon:@"Life style note" rightItem:nil];
    
    
    // add rating bar
    if(IS_IPHONE_6){
        self.ratingStar = [[RatingBar alloc] initWithFrame:CGRectMake((self.ratingBar.frame.size.width - RATING_BAR_WIDTH)/2,0, RATING_BAR_WIDTH, RATING_BAR_HEIGHT)];
    }else{
        self.ratingStar = [[RatingBar alloc] initWithFrame:CGRectMake(0,0, RATING_BAR_WIDTH, RATING_BAR_HEIGHT)];
    }
    
    [self.ratingBar addSubview:self.ratingStar];
}

- (void)fillDataToScreen:(LifeStyleNoteModel *)model {
    [self.lbTimeStartSleeping setText:[self stringFromDate:[UIUtils dateFromServerTimeString:model.time_start_sleep]]];
    [self.lbTimeWalkingUp setText:[self stringFromDate:[UIUtils dateFromServerTimeString:model.time_wake_up]]];
    
    [self.lifeStyleNote setText:model.note];
    //[self.sliderRatingSleeping setValue:(float)model.rating_sleep];
    self.ratingStar.starNumber = model.rating_sleep;
    [self calculateTimeSleeping];
    [self.btnWakingUp setEnabled:YES];
    [self.imgIconEditedWalkingUp setHidden:NO];
}

- (void)checkProfileToShowView {
    if (![PHRAppStatus checkCurrentStandardActive]) {
        [self.viewAdd setHidden:YES];
    } else {
        BOOL isSyncFromHeathKit = _model != nil;
        [self.viewAdd setHidden:isSyncFromHeathKit];
    }
}

- (void)callServerApi {
    if (self.type == PHRGroupTypeStandard) {
        if (self.idLifeStyleNote && ![self.idLifeStyleNote isEmpty]) {
            [self.btnRunTime setEnabled:NO];
            __weak __typeof(self) weakSelf = self;
            [[PHRClient instance] requestGetDetail:PHRAppStatus.currentStandard.profileId and:self.idLifeStyleNote andMethod:API_LifeStyleNote completion:^(MFRession *response) {
                if (response) {
                    _currentLifeStyleModel = [[LifeStyleNoteModel alloc] initWithDictionary:response.content error:nil];
                    [weakSelf fillDataToScreen:_currentLifeStyleModel];
                }
                else {
                    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
                }
            }];
        }
    }
    else {
        [self.btnRunTime setEnabled:YES];
    }
}

#pragma mark - Date Time Format

- (NSString *)stringFromDate:(NSDate *)dateTime {
    return [UIUtils stringDate:dateTime withFormat:@"hh:mm:ss a yyyy/MM/dd"];
}

- (NSDate *)dateTimeFromString :(NSString *)stringDate {
    return [UIUtils dateFromString:stringDate withFormat:@"hh:mm:ss a yyyy/MM/dd"];
}

#pragma mark - Action To Button Run Time

- (IBAction)actionToRunTime:(id)sender {
    if (isRunTime) {
        [self setEnableForRightButton:true];
        NSDate *dateAnyHoursAhead = [myCurrentDate dateByAddingTimeInterval:currentTimeInSeconds];
        self.lbTimeWalkingUp.text = [self stringFromDate:dateAnyHoursAhead];
        
        isRunTime = NO;
        [self.lifeStyleNote setEditable:YES];
        [self pressStopTime];
        
        [self.btnStartSleeping setEnabled:YES];
        [self.btnWakingUp setEnabled:YES];
        [self.ratingStar setEnable:YES];
        [self.btnRunTime setImage:[UIImage imageNamed:@"Button_Play"] forState:UIControlStateNormal];
        [self resetRemider];
       
    }
    else {
        [self setEnableForRightButton:false];
        if ([self.lbTimeStartSleeping.text isEqualToString:PHR_DATE_TIME_ZERO]) {
            myCurrentDate = [NSDate date];
            self.lbTimeStartSleeping.text = [self stringFromDate:myCurrentDate];
        }
        else {
            myCurrentDate = [self dateTimeFromString:self.lbTimeStartSleeping.text];
        }
        self.lbTimeWalkingUp.text = PHR_DATE_TIME_ZERO;
        self.lbTimeSleeping.text = PHR_DATE_TIME_ZERO;
        
        isRunTime = YES;
        [self.lifeStyleNote setEditable:NO];
        [self pressRunTime];
        
        [self.btnStartSleeping setEnabled:NO];
        [self.btnWakingUp setEnabled:NO];
        [self.ratingStar setEnable:NO];
        [self.btnRunTime setImage:[UIImage imageNamed:@"Button_Play_active"] forState:UIControlStateNormal];
        //[NSUtils removeObjectForKey:PHR_SLEEP_TIME];
        NSString *saveSleepTime = [self stringFromDate:myCurrentDate];
        [NSUtils setValue:[NSString stringWithFormat:@"%@ProfileID%@",saveSleepTime,PHRAppStatus.currentStandard.profileId] forKey:[@(StandardHomeTypeLifeStyle) stringValue]];
        [self addRemider];
        
    }
    
    if (!isRunTime) {
        [self calculateTimeSleeping];
    }
}

- (void)pressRunTime {
  
 // [[UIApplication sharedApplication] endBackgroundTask:UIBackgroundTaskInvalid];
  
    if (!currentTimeInSeconds) {
        currentTimeInSeconds = 0;
    }
    if (!myTimer) {
        myTimer = [self createTimer];
//      [[UIApplication sharedApplication] beginBackgroundTaskWithExpirationHandler:^{
//      
//      }];
//      [[NSRunLoop mainRunLoop] addTimer:myTimerCount forMode:NSDefaultRunLoopMode];
    }

  
//  CFRunLoopStop(CFRunLoopGetCurrent());
//  [[NSRunLoop currentRunLoop] cancelPerformSelectorsWithTarget:self];
//  
//  NSDate *nextDate = [NSDate dateWithTimeIntervalSinceNow:1.0];
//  [[NSRunLoop currentRunLoop] runUntilDate:nextDate];
}

- (void)pressStopTime {
    [myTimer invalidate];
    myTimer = nil;
}

- (NSTimer *)createTimer {
    return [NSTimer scheduledTimerWithTimeInterval:1.0
                                            target:self
                                          selector:@selector(timerTicked:)
                                          userInfo:nil
                                           repeats:YES];
}

- (void)timerTicked:(NSTimer *)timer {
    currentTimeInSeconds++;
    [self updateTimerWithTotalSeconds:currentTimeInSeconds];
}

- (void)updateTimerWithTotalSeconds:(int)totalSeconds {
    int seconds = totalSeconds % 60;
    int minutes = (totalSeconds / 60) % 60;
    int hours = totalSeconds / 3600;
    
    self.lbHours.text = [NSString stringWithFormat:@"%02d", hours];
    self.lbMinutes.text = [NSString stringWithFormat:@"%02d", minutes];
    self.lbSeconds.text = [NSString stringWithFormat:@"%02d", seconds];
}

#pragma mark - Date Time Style

- (void)resetTimeClock {
    isRunTime = NO;
    [self.btnWakingUp setEnabled:NO];
    [self.imgIconEditedWalkingUp setHidden:YES];
    
    self.lbHours.text = PHR_TIME_ZERO;
    self.lbMinutes.text = PHR_TIME_ZERO;
    self.lbSeconds.text = PHR_TIME_ZERO;
    _totalTimeSleep = PHR_TIME_ZERO;
    
    self.lbTimeStartSleeping.text = PHR_DATE_TIME_ZERO;
    self.lbTimeWalkingUp.text = PHR_DATE_TIME_ZERO;
    self.lbTimeSleeping.text = PHR_DATE_TIME_ZERO;
}

- (void)addRemider{
    UILocalNotification* localNotification = [[UILocalNotification alloc] init];
    localNotification.fireDate = [myCurrentDate dateByAddingTimeInterval:[MasterDataManager suggestTimeSleepForAge:PHRAppStatus.currentStandard.age isMen:PHRAppStatus.currentStandard.isMen] *3600];
    
    localNotification.alertBody = kLocalizedString(@"Sleep enough, please wake up!");
    localNotification.alertAction = @"Show me the item";
    localNotification.timeZone = [NSTimeZone systemTimeZone];
    localNotification.soundName = UILocalNotificationDefaultSoundName;// @"Sound name";
    
    NSString *keyNotification = @"AlarmNotification";
    
    NSDictionary *userInfo = [NSDictionary dictionaryWithObject:keyNotification forKey:@"ID"];
    localNotification.userInfo = userInfo;
    [[UIApplication sharedApplication] scheduleLocalNotification:localNotification];
}

- (IBAction)showDateTimeLife:(id)sender {
    [self.lifeStyleNote resignFirstResponder];
    
    UIButton *btn = (UIButton *)sender;
    if (btn.tag == PHR_TAG_BTN_STARTSLEEPING) {
        tagButton = PHR_TAG_BTN_STARTSLEEPING;
        
       // NSDateComponents *components = [[NSDateComponents alloc] init];
       // [components setDay:-20];
       // NSDate *before20Days = [[NSCalendar currentCalendar] dateByAddingComponents:components toDate:[NSDate date] options:0];
        //[self.pickerDateTime setMinimumDate:before20Days];
    }
    else {
        tagButton = PHR_TAG_BTN_WALKINGUP;
        
        if (![self.lbTimeStartSleeping.text isEqualToString:PHR_DATE_TIME_ZERO]) {
            self.pickerDateTime.minimumDate = [self dateTimeFromString:self.lbTimeStartSleeping.text];
        }
    }
    
    [UIView beginAnimations:nil context:nil];
    [UIView setAnimationDuration:0.5];
    [self.viewDateTime setFrame:CGRectMake(0, SCREEN_HEIGHT - self.viewDateTime.frame.size.height, SCREEN_WIDTH, self.viewDateTime.frame.size.height)];
    [UIView commitAnimations];
}

- (IBAction)pressDoneDateTime:(id)sender {
    NSDate* time = [self.pickerDateTime date];
    if (tagButton == PHR_TAG_BTN_STARTSLEEPING) {
        self.lbTimeStartSleeping.text = [self stringFromDate:time];
        [self.btnWakingUp setEnabled:YES];
        [self.imgIconEditedWalkingUp setHidden:NO];
        if (![self.lbTimeWalkingUp.text isEqualToString:PHR_DATE_TIME_ZERO]) {
             [self checkDateTimeStartAndWakeUp:time];
        }
    }
    else {
        if (![self.lbTimeStartSleeping.text isEqualToString:PHR_DATE_TIME_ZERO]) {
            [self checkDateTimeStartAndWakeUp:time];
        }
    }
    
    if (![self.lbTimeStartSleeping.text isEqualToString:PHR_DATE_TIME_ZERO] && ![self.lbTimeWalkingUp.text isEqualToString:PHR_DATE_TIME_ZERO]) {
        [self calculateTimeSleeping];
    }
    
    [self hideDatePicker];
}

- (void)checkDateTimeStartAndWakeUp:(NSDate*)time {
    NSDate *timeStart = [self dateTimeFromString:self.lbTimeStartSleeping.text];
    NSInteger seconds = [time timeIntervalSinceDate:timeStart];
    if (seconds < 0) {
        self.lbTimeWalkingUp.text = [self stringFromDate:timeStart];
    } else {
        self.lbTimeWalkingUp.text = [self stringFromDate:time];
    }
}

- (IBAction)pressHideDatePicker:(id)sender {
    [self hideDatePicker];
}

- (void)hideDatePicker {
    [UIView beginAnimations:nil context:nil];
    [UIView setAnimationDuration:0.5];
    [self.viewDateTime setFrame:CGRectMake(0, 2500, SCREEN_WIDTH, self.viewDateTime.frame.size.height)];
    [UIView commitAnimations];
}

- (void)calculateTimeSleeping {
    NSDate *timeStart = [self dateTimeFromString:self.lbTimeStartSleeping.text];
    NSDate *timeWalkingUp = [self dateTimeFromString:self.lbTimeWalkingUp.text];
    
    NSInteger seconds = [timeWalkingUp timeIntervalSinceDate:timeStart];
    
    _totalTimeSleep = [NSString stringWithFormat:@"%ld", (long)seconds];
    
    NSInteger days = (int) (floor(seconds / (3600 * 24)));
    if(days) seconds -= days * 3600 * 24;
    
    NSInteger hours = (int) (floor(seconds / 3600));
    if(hours) seconds -= hours * 3600;
    
    NSInteger minutes = (int) (floor(seconds / 60));
    if(minutes) seconds -= minutes * 60;
    
    if (days > 0) {
        hours += days * 24;
    }
    
    self.lbTimeSleeping.text = [NSString stringWithFormat:@"%02ldh%02ld'%02ld", (long)hours, (long)minutes,(long)seconds];
}

- (void) resetRemider{
    NSString *sleepTime = [NSUtils valueForKey:[@(StandardHomeTypeLifeStyle) stringValue]];
    if(sleepTime != nil){
        NSMutableArray *allNotifications = [NSMutableArray arrayWithArray:[[UIApplication sharedApplication] scheduledLocalNotifications]];
        for (UILocalNotification *noti in allNotifications) {
            NSString *notiID = [noti.userInfo valueForKey:@"ID"];
            
            if(notiID !=nil && [[NSString stringWithFormat:@"%@",notiID] containsString:@"AlarmNotification"]){
                [[UIApplication sharedApplication] cancelLocalNotification:noti];
                break;
            }
        }
        
        [NSUtils removeObjectForKey:[@(StandardHomeTypeLifeStyle) stringValue]];
    }else{
        
    }
}

#pragma mark - UITextView Delegate

- (void)textViewDidBeginEditing:(UITextView *)textView {
    [self animateTextView:YES];
    if ([textView.text isEqualToString:kLocalizedString(kNote)]) {
        textView.text = @"";
        textView.textColor = PHR_COLOR_GRAY;
    }
    [textView becomeFirstResponder];
}

- (void)textViewDidEndEditing:(UITextView *)textView {
    [self animateTextView:NO];
    if ([textView.text isEqualToString:@""]) {
        textView.text = kLocalizedString(kNote);
        textView.textColor = [UIColor lightGrayColor];
    }
    [textView resignFirstResponder];
}

- (void)animateTextView:(BOOL) up {
    if (up) {
        [self hideDatePicker];
    }
    const int movementDistance = 150.0;
    const float movementDuration = 0.3f;
    int movement= movement = (up ? -movementDistance : movementDistance);
    
    [UIView beginAnimations: @"anim" context: nil];
    [UIView setAnimationBeginsFromCurrentState: YES];
    [UIView setAnimationDuration: movementDuration];
    self.view.frame = CGRectOffset(self.view.frame, 0, movement);
    [UIView commitAnimations];
}

-(void) setUpTime{
    NSString *sleepTime = [NSUtils valueForKey:[@(StandardHomeTypeLifeStyle) stringValue]];
    NSArray *arrayTime = [sleepTime componentsSeparatedByString:@"ProfileID"];
    
    if(sleepTime != nil && [arrayTime[1] isEqualToString:PHRAppStatus.currentStandard.profileId] && _isAddingMode){
        NSDate *startDate  = [self dateTimeFromString:arrayTime[0]];
        NSDate *currenDate = [NSDate date];
        //DLog(@"StartTime:%@",arrayTime[0]);
        NSInteger seconds = [currenDate timeIntervalSinceDate:startDate];
        //DLog(@"second:%ld",seconds)
        currentTimeInSeconds = (int)seconds;
      
     //   myTimer = [self createTimer];
       [self updateTimerWithTotalSeconds:(int)seconds];
        isRunTime = YES;
        [self.btnRunTime setImage:[UIImage imageNamed:@"Button_Play_active"] forState:UIControlStateNormal];
        self.lbTimeWalkingUp.text = PHR_DATE_TIME_ZERO;
        self.lbTimeSleeping.text = PHR_DATE_TIME_ZERO;
        
        //yyyy-MM-dd'T'HH:mm:ss'Z'
        
        myCurrentDate = [self dateTimeFromString:arrayTime[0]];
        self.lbTimeStartSleeping.text = arrayTime[0]; //[self stringFromDate:myCurrentDate];
        
        [self pressRunTime];
        
        [self.btnStartSleeping setEnabled:NO];
        [self.btnWakingUp setEnabled:NO];
        [self.ratingStar setEnable:NO];
    }
    else{

        [self resetTimeClock];
        if (_model != nil && [NSNumber numberWithInt:_model.id] != nil) {
            [self fillDataToScreen:_model];
        } else {
            [self callServerApi];
        }
        [self setbackground];
    }
}

- (IBAction)actionSaveData:(id)sender {
    [self actionNavigationBarItemRight];
}

@end
