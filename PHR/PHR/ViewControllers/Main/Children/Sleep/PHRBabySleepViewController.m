//
//  PHRBabySleepViewController.m
//  PHR
//
//  Created by Luong Le Hoang on 10/10/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "PHRBabySleepViewController.h"
#import "AccordionView.h"
#import "BabySleepTableViewCell.h"
#import "PHRMedicineTitleTableViewCell.h"
#import "ALCustomColoredAccessory.h"

#define PHR_IS_SHOW_YES                      @"YES"
#define PHR_IS_SHOW_NO                       @"NO"

static NSString *CellBabySleep            = @"CellBabySleep";
static NSString *CellBabySleepTitle       = @"CellBabySleepTitle";

@interface PHRBabySleepViewController (){
    __block int index;
    __block int numberOfExecution;
    NSURLSessionDataTask *taskGetTimeLine;
    BOOL isShowDialog;
}
@property (nonatomic,strong) NSMutableArray* arrayNotProcessing;
@property (nonatomic,strong) NSMutableArray* arrayToDelete;
@property (nonatomic) BOOL isShowed;
@property (nonatomic) NSInteger numberToDelete;

@end

@implementation PHRBabySleepViewController


- (void)viewDidLoad {
    [super viewDidLoad];
    self.view.backgroundColor = [UIColor clearColor];
    if (!self.expandedSections) {
        self.expandedSections = [[NSMutableIndexSet alloc] init];
        _listBabySleep = [NSMutableArray new];
        _listDateTime = [NSMutableArray new];
    }
    
    self.arrayNotProcessing = [NSMutableArray new];
    
    self.refreshControl = [[UIRefreshControl alloc] init];
    [self.refreshControl addTarget:self action:@selector(pullToRefreshData) forControlEvents:UIControlEventValueChanged];
    [self.tableViewSleep addSubview:self.refreshControl];
    
    [self.tableViewSleep addPullToRefreshWithActionHandler:^{
        [self getListbabySleepFromServer];
    } position:SVPullToRefreshPositionBottom];
    
    [self initializeFirstRun];
    
    //    [self setupNavigationBarTitle:kLocalizedString(kBabyTitleSleep) iconLeft:@"Icon_Person" iconRight:@"Icon_Family" iconMiddle:@"icon_sleep" isDismissView:false colorLeft:PHR_COLOR_BABY_SLEEP_LIGHT_ALPHA colorRight:PHR_COLOR_BABY_SLEEP_OVERLAY];
    [self resetDataTableView];
    
    //[self getListbabySleepFromServer];
    
    self.viewSave.backgroundColor = [UIColor colorWithRed:206.0/255.0 green:120.0/255.0 blue:1.0 alpha:1.0];
    self.labelSave.text = kLocalizedString(kSave);
    [self checkProfileToShowView];
    // Check editable
    self.btnRunTime.enabled = [PHRAppStatus checkCurrentBabyActive];
  
 [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(setUpTime) name:@"setUpTime" object:nil];

    [self setUpTime];
}

- (void)viewWillDisappear:(BOOL)animated{
  [super viewWillDisappear:animated];
  [[NSNotificationCenter defaultCenter] removeObserver:self];
}

- (void)handleProfileActiveChanged:(NSNotification*)notification{
    self.btnRunTime.enabled = [PHRAppStatus checkCurrentBabyActive];
    [self pressStopTime];
    [self resetDataTableView];
    [self checkProfileToShowView];
    [self setUpTime];
    [self updateTimerWithTotalSeconds:currentTimeInSeconds];
    [self getListbabySleepFromServer];
}

- (void)checkProfileToShowView {
    if (![PHRAppStatus checkCurrentBabyActive]) {
        [self.viewSave setHidden:YES];
         self.constraintTableAndAdd.constant = 0 - self.viewSave.bounds.size.height;
    } else {
        [self.viewSave setHidden:NO];
        self.constraintTableAndAdd.constant = 0;
    }
}

- (void)refreshAllView {
    self.btnRunTime.enabled = [PHRAppStatus checkCurrentBabyActive];
    [self pressStopTime];
    [self resetDataTableView];
    [self checkProfileToShowView];
    [self setUpTime];
    [self updateTimerWithTotalSeconds:currentTimeInSeconds];
    [self getListbabySleepFromServer];
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyProfileBabyActiveChanged object:nil];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleProfileActiveChanged:) name:kNotifyProfileBabyActiveChanged object:nil];
}

- (void)removeObserve {
    [[NSNotificationCenter defaultCenter] removeObserver:self];
}

- (void)setUpTime {
    NSString *sleepTime = [NSUtils valueForKey:[@(PHRBabyGroupTypeSleep) stringValue]];
    NSArray *arrayTime = [sleepTime componentsSeparatedByString:@"ProfileID"];
    
    if(sleepTime != nil && [arrayTime[1] isEqualToString:PHRAppStatus.currentBaby.profileId]){
        NSDate *startDate  = [self dateTimeFromString:arrayTime[0]];
        NSDate *currenDate = [NSDate date];
        DLog(@"StartTime:%@",arrayTime[0]);
        NSInteger seconds = [currenDate timeIntervalSinceDate:startDate];
        DLog(@"second:%ld",seconds)
        currentTimeInSeconds = (int)seconds;
      //  myTimer = [self createTimer];
        [self updateTimerWithTotalSeconds:(int)seconds];
        isRunTime = YES;
        [self.btnRunTime setImage:[UIImage imageNamed:@"Button_Play_active"] forState:UIControlStateNormal];
        
        //yyyy-MM-dd'T'HH:mm:ss'Z'
        
        myCurrentDate = [self dateTimeFromString:arrayTime[0]];
        [self pressRunTime];
    }
    else{
        currentTimeInSeconds = 0;
        isRunTime = NO;
        [self.btnSave setEnabled:YES];
         [self.btnRunTime setImage:[UIImage imageNamed:@"Button_Play"] forState:UIControlStateNormal];
    }
}

- (void)resetRemider{
    NSString *sleepTime = [NSUtils valueForKey:[@(PHRBabyGroupTypeSleep) stringValue]];
    if(sleepTime != nil){
        [NSUtils removeObjectForKey:[@(PHRBabyGroupTypeSleep) stringValue]];
    }
}

- (NSDate *)dateTimeFromString :(NSString *)stringDate {
    return [UIUtils dateFromString:stringDate withFormat:@"hh:mm:ss a yyyy/MM/dd"];
}


- (void)callBackToPopView {
    [self.navigationController popViewControllerAnimated:YES];
}

- (void)pullToRefreshData {
    [self resetDataTableView];
    [self getListbabySleepFromServer];
}

- (NSMutableArray*)getArrayDateBabySleep:(NSMutableArray*)input {
    NSMutableArray* newArray = [[NSMutableArray alloc] init];
    for (int i = 0; i < input.count; i++) {
        BabySleepModel *objbabySleep = (BabySleepModel*) [input objectAtIndex:i];
        
        NSDate *dateTime   = [UIUtils dateFromServerTimeString:objbabySleep.time_start_sleep];
        objbabySleep.dateTime = [UIUtils formatDateOppositeStyle:dateTime];
        
        if (newArray.count > 0) {
            BOOL isAdd = YES;
            for (NSString *objDate in newArray) {
                if ([objDate isEqualToString:[UIUtils formatDateOppositeStyle:dateTime]]) {
                    isAdd = NO;
                }
            }
            if (isAdd) {
                [newArray addObject:[UIUtils formatDateOppositeStyle:dateTime]];
            }
        }
        else {
            [newArray addObject:[UIUtils formatDateOppositeStyle:dateTime]];
        }
    }
    [_listDateTime sortUsingComparator:^NSComparisonResult(NSString *obj1, NSString *obj2){
        NSDate *date1 = [UIUtils dateFromString:obj1 withFormat:PHR_SERVER_DATE_TIME_FORMAT];
        NSDate *date2 = [UIUtils dateFromString:obj2 withFormat:PHR_SERVER_DATE_TIME_FORMAT];
        return [date2 compare:date1];
    }];
    return newArray;
}

- (void)showOrHideLoading:(BOOL)isShowed {
    if (!isShowed) {
        [self.refreshControl endRefreshing];
    }
}

#pragma mark - Server Methods

- (void)getListbabySleepFromServer {
    if (!PHRAppStatus.currentBaby) {
      return;
    }
    __weak __typeof__(self) weafSelf = self;
    //[PHRAppDelegate showLoading];
    [self showOrHideLoading:YES];
    if (taskGetTimeLine) {
        [taskGetTimeLine cancel];
    }
    taskGetTimeLine = [[PHRClient instance] requestGetListBabySleepWithId:PHRAppStatus.currentBaby.profileId andNumberPage:numberPage completed:^(MFRession *responseObject) {
        id parsedThing = responseObject.content;
        if (parsedThing == nil) {
            // error
        }
        else if ([parsedThing isKindOfClass:[NSArray class]]) {
            NSMutableArray *newArr = [NSMutableArray new];
            // handle array, parsedThing can be cast as an NSArray safely
            NSArray *listBaby = (NSArray *)parsedThing;
            
            for (int i = 0; i < listBaby.count; i++) {
                NSDictionary *dict = [listBaby objectAtIndex:i];
                BabySleepModel *objbabySleep = [[BabySleepModel alloc] initWithDictionary:dict error:nil];
                
                NSDate *dateTime   = [UIUtils dateFromServerTimeString:objbabySleep.time_start_sleep];
                objbabySleep.dateTime = [UIUtils formatDateOppositeStyle:dateTime];
                
                [newArr addObject:objbabySleep];
                weafSelf.arrayNotProcessing = newArr;
                
                if (_listDateTime.count > 0) {
                    BOOL isAdd = YES;
                    for (NSString *objDate in _listDateTime) {
                        if ([objDate isEqualToString:[UIUtils formatDateOppositeStyle:dateTime]]) {
                            isAdd = NO;
                        }
                    }
                    if (isAdd) {
                        [_listDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
                    }
                }
                else {
                    [_listDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
                }
            }
            
            if (_listDateTime.count > 0) {
                NSMutableArray *arrAdd = [weafSelf grossArrayBabySleep:newArr];
                for (BabySleepModel *obj in arrAdd) {
                    [_listBabySleep addObject:obj];
                }
                [_listDateTime sortUsingComparator:^NSComparisonResult(NSString *obj1, NSString *obj2){
                    NSDate *date1 = [UIUtils dateFromString:obj1 withFormat:PHR_SERVER_DATE_TIME_FORMAT];
                    NSDate *date2 = [UIUtils dateFromString:obj2 withFormat:PHR_SERVER_DATE_TIME_FORMAT];
                    return [date2 compare:date1];
                }];
            }
        }
        [weafSelf showOrHideLoading:NO];
        numberPage += 1;
        [weafSelf.tableViewSleep reloadData];
    } error:^(NSString *error) {
        [self showOrHideLoading:NO];
        if (isShowDialog) {
            [NSUtils showAlertWithTitle:[NSString stringWithFormat:@"%@", error.description] message:kLocalizedString(kTitleAlertError)];
        }
        
    }];
    [weafSelf.tableViewSleep.pullToRefreshView stopAnimating];
}

- (NSMutableArray *)grossArrayBabySleep:(NSMutableArray *)array {
    NSMutableArray *grossArray = [NSMutableArray new];
    for (NSString *dateTime in _listDateTime) {
        BabySleepModel *dateBabySleep = [[BabySleepModel alloc] init];
        int morning = 0;
        int afternoon = 0;
        int night = 0;
        for (BabySleepModel *obj in array) {
            if ([obj.dateTime isEqualToString:dateTime]) {
                if (![obj.morning_time_sleep isKindOfClass:[NSNull class]]) {
                    morning += [obj.morning_time_sleep intValue];
                }
                if (![obj.afternoon_time_sleep isKindOfClass:[NSNull class]]) {
                    afternoon += [obj.afternoon_time_sleep intValue];
                }
                if (![obj.night_time_sleep isKindOfClass:[NSNull class]]) {
                    night += [obj.night_time_sleep intValue];
                }
            }
        }
        dateBabySleep.morning_time_sleep = [NSString stringWithFormat:@"%d", morning];
        dateBabySleep.afternoon_time_sleep = [NSString stringWithFormat:@"%d", afternoon];
        dateBabySleep.night_time_sleep = [NSString stringWithFormat:@"%d", night];
        
        [grossArray addObject:dateBabySleep];
    }
    return grossArray;
}

- (NSMutableArray*) timeSortedBegins:(NSMutableArray *)array {
    NSMutableArray* begins = array;
    NSSortDescriptor *sort = [[NSSortDescriptor alloc] initWithKey:@"time_start_sleep" ascending:YES];
    [begins sortUsingDescriptors: @[sort]];
    return begins;
}

#pragma mark - UI

- (void)initializeFirstRun {
//    [self.viewDownNavigation setStyleRegularToViewWithAlpha:0.2];
//    [self.viewHours setStyleRegularToViewWithAlpha:0.2];
//    [self.viewSeconds setStyleRegularToViewWithAlpha:0.2];
    
    self.tableViewSleep.delegate = self;
    self.tableViewSleep.dataSource = self;
    
    [self.tableViewSleep setBackgroundColor:[UIColor clearColor]];
    [self.tableViewSleep setSeparatorStyle:UITableViewCellSeparatorStyleNone];
    
    [self.tableViewSleep registerNib:[UINib nibWithNibName:NSStringFromClass([PHRMedicineTitleTableViewCell class]) bundle:nil] forCellReuseIdentifier:CellBabySleepTitle];
    [self.tableViewSleep registerNib:[UINib nibWithNibName:NSStringFromClass([BabySleepTableViewCell class]) bundle:nil] forCellReuseIdentifier:CellBabySleep];
    
    [self.labelTextHours setText:kLocalizedString(kHour)];
    [self.labelTextMinutes setText:kLocalizedString(kMinute)];
    [self.labelTextSeconds setText:kLocalizedString(kSecond)];
    
    self.labelTextHours.textAlignment = NSTextAlignmentCenter;
    self.labelTextMinutes.textAlignment = NSTextAlignmentCenter;
    self.labelTextSeconds.textAlignment = NSTextAlignmentCenter;
}

- (void)resetDataTableView {
    if (_listDateTime.count > 0) {
        [_listDateTime removeAllObjects];
    }
    if (_listBabySleep.count > 0) {
        [_listBabySleep removeAllObjects];
    }
    if (_arrayNotProcessing.count > 0){
        [_arrayNotProcessing removeAllObjects];
    }
    [self.tableViewSleep reloadData];
    numberPage = 1;
}

#pragma mark - Clock
- (IBAction)actionToRunTime:(id)sender {
    if (isRunTime) {
        [self.btnSave setEnabled:YES];
        isRunTime = NO;
        [self pressStopTime];
        [self.btnRunTime setImage:[UIImage imageNamed:@"Button_Play"] forState:UIControlStateNormal];
        [self resetRemider];
    }
    else {
        [self.btnSave setEnabled:NO];
        myCurrentDate = [NSDate date];
        isRunTime = YES;
        [self pressRunTime];
        [self.btnRunTime setImage:[UIImage imageNamed:@"Button_Play_active"] forState:UIControlStateNormal];
        NSString *saveSleepTime = [UIUtils stringDate:myCurrentDate withFormat:@"hh:mm:ss a yyyy/MM/dd"];
        [NSUtils setValue:[NSString stringWithFormat:@"%@ProfileID%@",saveSleepTime,PHRAppStatus.currentBaby.profileId] forKey:[@(PHRBabyGroupTypeSleep) stringValue]];
    }
}

- (void)pressRunTime {
    if (!currentTimeInSeconds) {
        currentTimeInSeconds = 0;
    }
    if (!myTimer) {
        myTimer = [self createTimer];
    }
}

- (NSTimer *)createTimer {
    return [NSTimer scheduledTimerWithTimeInterval:1.0
                                            target:self
                                          selector:@selector(timerTickedBaby:)
                                          userInfo:nil
                                           repeats:YES];
}

- (void)timerTickedBaby:(NSTimer *)timer {
    currentTimeInSeconds++;
    [self updateTimerWithTotalSeconds:currentTimeInSeconds];
}

- (void)pressStopTime {
    [myTimer invalidate];
    myTimer = nil;
}

- (void)updateTimerWithTotalSeconds:(int)totalSeconds {
    int seconds = totalSeconds % 60;
    int minutes = (totalSeconds / 60) % 60;
    int hours = totalSeconds / 3600;
    
    self.lbHour.text = [NSString stringWithFormat:@"%02d", hours];
    self.lbMinutes.text = [NSString stringWithFormat:@"%02d", minutes];
    self.lbSeconds.text = [NSString stringWithFormat:@"%02d", seconds];
}

-(void)batchDeleteByDate:(NSString*)date{
    self.arrayToDelete = [[NSMutableArray alloc]init];
    
    for (BabySleepModel* obj in self.arrayNotProcessing) {
        if ([obj.dateTime isEqualToString:date]) {
            [self.arrayToDelete addObject:obj];
        }
    }
    self.numberToDelete = self.arrayToDelete.count;
    index = 0;
    numberOfExecution = 1;
    NSLog(@"self.numberToDelete %ld",(long)self.numberToDelete);
    [self deleteByDate];
}

- (void)deleteByDate{
    NSLog(@"BEGIN DELETE WITH INDEX: %d",index);
    BabySleepModel* obj = [[BabySleepModel alloc]init];
    if (index < self.arrayToDelete.count) {
        obj = [self.arrayToDelete objectAtIndex:index];
    }
    [[PHRClient instance] requestDeleteObject:PHRAppStatus.currentBaby.profileId and:obj.id andMethod:API_DeleteBabySleep completion:^(MFResponse *response) {
        if (response && [[response valueForKeyPath:KEY_Status] isEqualToString:KEY_SUCCESS]) {
            [self.arrayNotProcessing removeObject:obj];
            NSLog(@"COMPLETE DELETE WITH INDEX: %d",index);
            if (numberOfExecution < self.numberToDelete) {
                index++;
                numberOfExecution++;
                [self deleteByDate];
            } else {
                index = 0;
                numberOfExecution = 0;
                _listDateTime = [self getArrayDateBabySleep:self.arrayNotProcessing];
                _listBabySleep = [self grossArrayBabySleep:self.arrayNotProcessing];
                [self.tableViewSleep reloadData];
            }
        } else {
            if (isShowDialog) {
                [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
            }
        }
    }];
    
}

#pragma mark - Tableview delegate + data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    if (_listBabySleep.count > 0) {
        return _listBabySleep.count;
    }
    return 0.0;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    if (_listBabySleep.count > 0) {
        BabySleepModel *obj = [_listBabySleep objectAtIndex:section];
        if ([obj.isShow isEqualToString:PHR_IS_SHOW_YES]) {
            return 2.0;
        }
        return 1.0;
    }
    return 1.0;
}

- (CGFloat)tableView:(UITableView *)tableView heightForHeaderInSection:(NSInteger)section {
    return 0.0;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    if(indexPath.row == 1) {
        return 120.0;
    }
    return 40.0;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    if (indexPath.row == 0) {
        PHRMedicineTitleTableViewCell *cellTitle = [tableView dequeueReusableCellWithIdentifier:CellBabySleepTitle];
        if (!cellTitle) {
            cellTitle = [[PHRMedicineTitleTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellBabySleepTitle];
        }
        
        if ([self.expandedSections containsIndex:indexPath.section]) {
            cellTitle.accessoryView = [ALCustomColoredAccessory accessoryWithColor:[UIColor blackColor] type:ALCustomColoredAccessoryTypeRight];
        } else {
            cellTitle.accessoryView = [ALCustomColoredAccessory accessoryWithColor:[UIColor blackColor] type:ALCustomColoredAccessoryTypeDown];
        }
        [cellTitle setRightUtilityButtons:[self rightButtons] WithButtonWidth:80];
        cellTitle.delegate = self;
        [cellTitle setSelectionStyle:UITableViewCellSelectionStyleNone];
        NSDate *date = [NSDate date];
        if (_listDateTime.count > 0) {
            NSString *dateTime = [_listDateTime objectAtIndex:indexPath.section];
            if ([dateTime isEqualToString:[UIUtils formatDateOppositeStyle:date]]) {
                [cellTitle setStyleToHeaderTableViewWithTitle:kLocalizedString(kToday) andDate:kLocalizedString(kTitleTimeSleep)];
            } else {
                [cellTitle setStyleToHeaderTableViewWithTitle:dateTime andDate:kLocalizedString(kTitleTimeSleep)];
            }
        }
        return cellTitle;
    }
    
    BabySleepTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellBabySleep];
    if (!cell) {
        cell = [[BabySleepTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellBabySleep];
    }
    
    [cell setSelectionStyle:UITableViewCellSelectionStyleNone];
    
    if (_listBabySleep.count > 0) {
        BabySleepModel *objSleep = [_listBabySleep objectAtIndex:indexPath.section];
        
        int timeMorning     = [objSleep.morning_time_sleep intValue];
        int timeAfternoon   = [objSleep.afternoon_time_sleep intValue];
        int timeNight       = [objSleep.night_time_sleep intValue];
        
        cell.lbMorningSleep.text    = [NSString stringWithFormat:@"%@",[self analyzeTimeToHourAndMinute:timeMorning]];
        cell.lbAfternoonSleep.text  = [NSString stringWithFormat:@"%@",[self analyzeTimeToHourAndMinute:timeAfternoon]];
        cell.lbNightSleep.text      = [NSString stringWithFormat:@"%@",[self analyzeTimeToHourAndMinute:timeNight]];
    }
    
    return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    if (indexPath.row == 0) {
        NSInteger section = indexPath.section;
        BOOL currentlyExpanded = [_expandedSections containsIndex:section];
        if (currentlyExpanded) {
            [_expandedSections removeIndex:section];
        }
        else {
            [_expandedSections addIndex:section];
        }
        
        PHRMedicineTitleTableViewCell *cell = (PHRMedicineTitleTableViewCell *)[tableView cellForRowAtIndexPath:indexPath];
        BabySleepModel *babySleep = [_listBabySleep objectAtIndex:indexPath.section];
        NSIndexPath *detailIndexPath = [NSIndexPath indexPathForRow:1 inSection:indexPath.section];
        
        cell.backgroundView.backgroundColor = [UIColor clearColor];
        
        if ([babySleep.isShow isEqualToString:PHR_IS_SHOW_YES]) {
            babySleep.isShow = PHR_IS_SHOW_NO;
            
            [tableView deleteRowsAtIndexPaths:@[detailIndexPath] withRowAnimation:UITableViewRowAnimationAutomatic];
            [tableView deselectRowAtIndexPath:indexPath animated:YES];
            cell.accessoryView = [ALCustomColoredAccessory accessoryWithColor:[UIColor blackColor] type:ALCustomColoredAccessoryTypeDown];
        }
        else{
            babySleep.isShow = PHR_IS_SHOW_YES;
            
            [tableView insertRowsAtIndexPaths:@[detailIndexPath] withRowAnimation:UITableViewRowAnimationMiddle];
            [self scrollToVisibleRectIfNeddedForIndexPath:detailIndexPath];
            cell.accessoryView = [ALCustomColoredAccessory accessoryWithColor:[UIColor blackColor] type:ALCustomColoredAccessoryTypeRight];
        }
    }
}

//- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath {
//    if (editingStyle == UITableViewCellEditingStyleDelete) {
//       
//    }
//}

//- (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath {
//    if (indexPath.row == 0) {
//        return YES;
//    }
//    return NO;
//}

- (void)scrollToVisibleRectIfNeddedForIndexPath:(NSIndexPath *)indexPath {
    [self.tableViewSleep scrollToRowAtIndexPath:indexPath atScrollPosition:UITableViewScrollPositionMiddle animated:YES];
}

- (NSString *)analyzeTimeToHourAndMinute:(int)TotalTime {
    int hour = TotalTime / 60;
    int minutes = TotalTime - 60 * hour;
    
    NSString *timeAfterAnalyze = [NSString stringWithFormat:@"%d:%d'", hour, minutes];
    return timeAfterAnalyze;
}

- (IBAction)onTapBtnSave:(id)sender {
    if (!isRunTime && currentTimeInSeconds > 0) {
        [self resetRemider];

        BabySleepModel *babySleep = [[BabySleepModel alloc] init];
        
        NSDate *date = [NSDate date];
        NSString *dateAmOrPm = [UIUtils formatTimeGetAmOrPm:date];
        
        babySleep.time_start_sleep = [UIUtils stringUTCFromDateTime:myCurrentDate];
        babySleep.time_wake_up = [UIUtils stringUTCFromDateTime:date];
        
        int timeHour = [[UIUtils formatTimeGetHours:date] intValue];
        if ([dateAmOrPm isEqualToString:PHR_DATE_AM]) {
            if (timeHour > 11) {
                babySleep.afternoon_time_sleep = [NSString stringWithFormat:@"%d",currentTimeInSeconds];
                babySleep.morning_time_sleep = PHR_STR_NULL;
            }
            else {
                babySleep.morning_time_sleep = [NSString stringWithFormat:@"%d",currentTimeInSeconds];
                babySleep.afternoon_time_sleep = PHR_STR_NULL;
            }
            
            babySleep.night_time_sleep = PHR_STR_NULL;
        }
        else {
            if (timeHour > 5) {
                babySleep.night_time_sleep = [NSString stringWithFormat:@"%d",currentTimeInSeconds];
                babySleep.afternoon_time_sleep = PHR_STR_NULL;
            }
            else {
                babySleep.afternoon_time_sleep = [NSString stringWithFormat:@"%d",currentTimeInSeconds];
                babySleep.night_time_sleep = PHR_STR_NULL;
            }
            
            babySleep.morning_time_sleep = PHR_STR_NULL;
        }
        
        [[PHRClient instance] requestAddNewBabySleep:babySleep andCompleted:^(id params) {
            NSDictionary *dict = [[NSDictionary dictionaryWithDictionary:params] valueForKey:KEY_Content];
            BabySleepModel *model = [[BabySleepModel alloc] initWithDictionary:dict error:nil];
            [self.arrayNotProcessing addObject:model];
            _listDateTime = [self getArrayDateBabySleep:self.arrayNotProcessing];
            _listBabySleep = [self grossArrayBabySleep:self.arrayNotProcessing];
            [self.tableViewSleep reloadData];
            currentTimeInSeconds = 0;
            [self updateTimerWithTotalSeconds:currentTimeInSeconds];
        } error:^(NSString *error) {
            if (isShowDialog) {
                [NSUtils showAlertWithTitle:[NSString stringWithFormat:@"%@", error.description] message:kLocalizedString(kTitleAlertError)];
            }
        }];
    }
}

- (void)setIsShowDialog:(BOOL)isShow {
    isShowDialog = isShow;
}

- (void)dealloc {
    [[NSNotificationCenter defaultCenter] removeObserver:self];
}

- (NSArray *)rightButtons {
    NSMutableArray *rightUtilityButtons = [NSMutableArray new];
    [rightUtilityButtons sw_addUtilityButtonWithColor:
     [UIColor redColor] icon:[UIImage imageNamed:@"icon-trash-white"]];
    
    return rightUtilityButtons;
}

- (void)swipeableTableViewCell:(SWTableViewCell *)cell didTriggerRightUtilityButtonWithIndex:(NSInteger)index {
    NSIndexPath *indexPath = [self.tableViewSleep indexPathForCell:cell];
   [self batchDeleteByDate:[_listDateTime objectAtIndex:indexPath.section]];  
}

- (BOOL)swipeableTableViewCell:(SWTableViewCell *)cell canSwipeToState:(SWCellState)state {
    if (_listDateTime.count == 0){
        return NO;
    }
    NSIndexPath *indexPath = [self.tableViewSleep indexPathForCell:cell];

    switch (state) {
        case kCellStateLeft:
            return NO;
        case kCellStateRight:
            if ([PHRAppStatus checkCurrentBabyActive] && indexPath.row == 0) {
                return NO;
            }
            return NO;
        default:
            break;
    }
    return NO;
}

@end
