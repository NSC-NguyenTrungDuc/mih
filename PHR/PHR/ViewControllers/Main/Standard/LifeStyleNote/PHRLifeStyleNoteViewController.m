//
//  PHRLifeStyleNoteViewController.m
//  PHR
//
//  Created by DEV-MinhNN on 2/5/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRLifeStyleNoteViewController.h"
#import "LifeStyleNoteTableViewCell.h"
#import "LifeStyleNoteViewController.h"
#import "PHRChartUtils.h"
#import "PHRLifeStyleChart.h"
#import "PHRSample.h"
#import "StorageManager.h"
#import "PHRBabyMilkHeaderView.h"

static NSString *CellLifeStyleIdentifier        = @"CellLifeStyleIdentifier";
static NSString *CellHeaderIdentifier           = @"CellHeaderIdentifier";

#define CHARTVIEW_HEIGHT 200.0
#define CHARTVIEW_INSET 10.0

@interface PHRLifeStyleNoteViewController () <UITableViewDataSource, UITableViewDelegate> {
  NSMutableArray<LifeStyleNoteModel*> *_listLifeStyleNote;
  NSMutableArray *_listDateTime;
  NSMutableArray *arrayChartData;
  int _totalTime;
  int _numberPage;
  BOOL isDataLoaded;
  ButtonTimeIntervalClick timeIntervalIndex;
  NSURLSessionDataTask *taskGetTimeLine;
  NSURLSessionDataTask *taskGetChartData;
}

@property (strong, nonatomic) PHRLifeStyleChart *chartLifeStyle;
@end

@implementation PHRLifeStyleNoteViewController

- (void)viewDidLoad {
  [super viewDidLoad];
  // Do any additional setup after loading the view from its nib.
  [self setupNavigationBarTitle:kLocalizedString(kTitleLifeStyle) iconLeft:@"Icon_Person" iconRight:@"Icon_Family" iconMiddle:@"Life style note" isDismissView:false colorLeft:PHR_COLOR_LIFE_STYLE_LIGHT_ALPHA colorRight:[PHR_COLOR_LIFE_STYLE_MAIN_COLOR colorWithAlphaComponent:0.5]];
  [self initializeLifeStyleView];
  [self setupButtonFourTimeInterval];
  [self setupGraph];
  _numberPage = 1;
  isDataLoaded = NO;
  [self getListLifeStyleFromServer];
  [self requestGetChartData];
  
}

- (void)viewWillAppear:(BOOL)animated {
  [super viewWillAppear:animated];
  [self setImageToBackgroundStandard:self.backgroundImage];
  
  [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyProfileStandardActiveChanged object:nil];
  [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyHealthkitData object:nil];
  
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleProfileActiveChanged:) name:kNotifyProfileStandardActiveChanged object:nil];
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleStorageData:) name:kNotifyHealthkitData object:nil];
}

- (void)viewWillDisappear:(BOOL)animated {
  [super viewWillDisappear:animated];
  NSArray *viewControllers = self.navigationController.viewControllers;
  if ([viewControllers indexOfObject:self] == NSNotFound) {
    [[NSNotificationCenter defaultCenter] removeObserver:self];
  }
}

- (void)handleStorageData:(NSNotification*)notification{
  PHRSample *sample = (PHRSample*)notification.object;
  if (sample && [sample.type isEqualToString:[PHRSample healthkitTypeFromType:0 fromScreen:StandardHomeTypeLifeStyle]]) {
    [PHRChartUtils calculateSum:arrayChartData andSample:sample duration:timeIntervalIndex];
    [self loadChartWithSort];
    // add to list
    LifeStyleNoteModel *item = [[LifeStyleNoteModel alloc] initFromSample:sample];
    [_listLifeStyleNote insertObject:item atIndex:0];
    [self getListDateTime];
    [self.tableViewLifeStyleNote reloadData];
  }
}

- (void)getListDateTime {
  [_listDateTime removeAllObjects];
  
  for (int i = 0; i < _listLifeStyleNote.count; i++) {
    LifeStyleNoteModel *model = [_listLifeStyleNote objectAtIndex:i];
    NSDate *dateTime = [UIUtils dateFromServerTimeString:model.time_start_sleep];
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
  
  
  [_listDateTime sortUsingComparator:^NSComparisonResult(NSString *obj1, NSString *obj2){
    NSDate *date1 = [UIUtils dateFromString:obj1 withFormat:PHR_BIRTHDAY_SERVER_FORMAT];
    NSDate *date2 = [UIUtils dateFromString:obj2 withFormat:PHR_BIRTHDAY_SERVER_FORMAT];
    return [date2 compare:date1];
  }];
  
}

- (void)handleProfileActiveChanged:(NSNotification*)notification{
  [self checkProfileToShowView];
  [self refreshAllView];
}

- (void)checkProfileToShowView {
  if (![PHRAppStatus checkCurrentStandardActive]) {
    [self.viewAdd setHidden:YES];
    self.constraintTableAndAdd.constant = 0;
  } else {
    [self.viewAdd setHidden:NO];
    self.constraintTableAndAdd.constant = self.viewAdd.bounds.size.height;
  }
}

- (void)refreshAllView {
  [self requestGetChartData];
  [self resetTableData];
  [self getListLifeStyleFromServer];
}

- (void)loadChartWithSort{
  // SORT DATA
  [arrayChartData sortUsingComparator:^NSComparisonResult(PHRSample *obj1, PHRSample *obj2){
    return [obj1.record_date compare:obj2.record_date];
  }];
  [self loadDataChart];
}

- (void)initializeLifeStyleView {
  //[self setImageToBackgroundStandard:self.backgroundImage];
  _listLifeStyleNote = [NSMutableArray new];
  _listDateTime = [NSMutableArray new];
  arrayChartData = [NSMutableArray new];
  
  self.lblAddData.text = kLocalizedString(kAdd);
  self.btnAddData.backgroundColor = PHR_COLOR_LIFE_STYLE_MAIN_COLOR;
  
  self.tableViewLifeStyleNote.delegate = self;
  self.tableViewLifeStyleNote.dataSource = self;
  
  self.tableViewLifeStyleNote.showsVerticalScrollIndicator = NO;
  self.tableViewLifeStyleNote.showsHorizontalScrollIndicator = NO;
  
  //    [self.tableViewLifeStyleNote setAlpha:0.9];
  [self.tableViewLifeStyleNote setBackgroundColor:[UIColor whiteColor]];
  [self.tableViewLifeStyleNote setSeparatorStyle:UITableViewCellSeparatorStyleNone];
  
  [self checkProfileToShowView];
  
  [self.tableViewLifeStyleNote registerNib:[UINib nibWithNibName:NSStringFromClass([LifeStyleNoteTableViewCell class]) bundle:nil] forCellReuseIdentifier:CellLifeStyleIdentifier];
  
  self.refreshControl = [[UIRefreshControl alloc] init];
  [self.refreshControl addTarget:self action:@selector(pullToRefreshData) forControlEvents:UIControlEventValueChanged];
  [self.tableViewLifeStyleNote addSubview:self.refreshControl];
  
  [self.tableViewLifeStyleNote addPullToRefreshWithActionHandler:^{
    [self getListLifeStyleFromServer];
  } position:SVPullToRefreshPositionBottom];
  
}

- (void)setupGraph {
  
  [self.chartLifeStyleDetail initializeChart:self];
  [self.chartLifeStyleDetail setShowAvarage:YES];
  [self.chartLifeStyleDetail setIsShowGradient:YES andIsDetailChart:YES];
  [self.chartLifeStyleDetail setLineChartColor:[UIColor whiteColor] andFillBallColor:[[UIColor blackColor] colorWithAlphaComponent:0.3]];
  [self.chartLifeStyleDetail setChartBackgroundColor:[UIColor clearColor]];
  self.chartLifeStyleDetail.chartType = [PHRChartUtils getChartType:StandardHomeTypeLifeStyle andIndex:0];
  
  [self.chartLifeStyleDetail doCustomize];
  
  
  [self.chartLifeStyleDetail setData:arrayChartData];
  [self.chartLifeStyleDetail updateChartData];
}

- (void)loadDataChart{
  [self.chartLifeStyleDetail setData:arrayChartData];
  [self.chartLifeStyleDetail updateChartData];
}


- (void) pullToRefreshData{
  [self resetTableData];
  [self getListLifeStyleFromServer];
}

-(void)calculateAvarageLifeStyle {
  float averageLifeStyle = 0;
  float totalHourSleep = 0;
  float totalLife = _listLifeStyleNote.count;
  if (totalLife == 0) {
    averageLifeStyle = 0;
  } else {
    for (int i = 0; i < _listLifeStyleNote.count; i++) {
      LifeStyleNoteModel* obj = (LifeStyleNoteModel*) [_listLifeStyleNote objectAtIndex:i];
      if (obj.total_hour_sleep && ![obj.total_hour_sleep isEmpty] ) {
        float hour_sleep = [obj.total_hour_sleep floatValue];
        hour_sleep = hour_sleep / 3600;
        totalHourSleep = totalHourSleep + hour_sleep;
      }
    }
    averageLifeStyle = totalHourSleep / totalLife;
  }
}

#pragma mark - Override Menu Method

- (void)actionNavigationBarItemRight {
  if (self.type == PHRGroupTypeLifeStyleNote) {
    [self addNewLifeStyleNoteRecord];
  }
}


#pragma mark - Method API
- (void)getListLifeStyleFromServer {
  __weak __typeof(self) weakSelf = self;
  
  if (!isDataLoaded) {
    isDataLoaded = YES;
    NSArray *samples = [[StorageManager instance] getSamplesUnsyncForType:[PHRSample healthkitTypeFromType:0 fromScreen: StandardHomeTypeLifeStyle] profileId:PHRAppStatus.currentStandard.profileId];
    for (PHRSample *sample in samples) {
      LifeStyleNoteModel *item = [[LifeStyleNoteModel alloc] initFromSample:sample];
      [_listLifeStyleNote addObject:item];
      
    }
  }
  
  [self showOrHideLoading:YES];
  if (taskGetTimeLine){
    [taskGetTimeLine cancel];
  }
  [self.viewIndicatorTable setHidden:NO];
  taskGetTimeLine = [[PHRClient instance] requestGetListData:PHRAppStatus.currentStandard.profileId andNumberPage:_numberPage andMethod:API_GetListLifeStyleNote completion:^(MFRession *response) {
    if (response != nil) {
      id content = response.content;
      if ([content isKindOfClass:[NSArray class]]) {
        NSArray *result = (NSArray *)content;
        // _listDateTime = [[DataManager sharedManager] getArrayDateForLifeStyleNote:_listDateTime and:result];
        _listLifeStyleNote = [[DataManager sharedManager] getArrayLifeStyleNote:_listLifeStyleNote and:result];
      }
      
      [self calculateAvarageLifeStyle];
      
      if (_listLifeStyleNote.count > 0){
        _numberPage += 1;
        // SORT DATA
        [_listLifeStyleNote sortUsingComparator:^NSComparisonResult(LifeStyleNoteModel *obj1, LifeStyleNoteModel *obj2){
          NSDate *date1 = [UIUtils dateFromString:obj1.time_start_sleep withFormat:PHR_SERVER_DATE_SHORT_FORMAT];
          NSDate *date2 = [UIUtils dateFromString:obj2.time_start_sleep withFormat:PHR_SERVER_DATE_SHORT_FORMAT];
          return [date2 compare:date1];
        }];
      }
      
      [self showOrHideLoading:NO];
      [self.viewIndicatorTable setHidden:YES];
    }
    else {
      [self showOrHideLoading:NO];
      [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
      [self.viewIndicatorTable setHidden:YES];
    }
    
    [self getListDateTime];
    [weakSelf.tableViewLifeStyleNote reloadData];
  }];
  [self.refreshControl endRefreshing];
  [weakSelf.tableViewLifeStyleNote.pullToRefreshView stopAnimating];
}

- (void)showOrHideLoading:(BOOL)isShowed{
  if (isShowed) {
  } else {
    [self.refreshControl endRefreshing];
  }
}

- (void)addNewLifeStyleNoteRecord {
  LifeStyleNoteViewController *controller = [[LifeStyleNoteViewController alloc] initWithNibName:NSStringFromClass([LifeStyleNoteViewController class]) bundle:nil];
  [controller setAddLifeStyleCallBack:^(LifeStyleNoteModel *type) {
    [self resetTableData];
    [self getListLifeStyleFromServer];
    [self requestGetChartData];
    
  }];
  controller.isAddingMode = YES;
  [self.navigationController pushViewController:controller animated:YES];
}

- (void)reDrawChartLifeStyleAfterAdd {
  _listLifeStyleNote = [self timeSortedBeginsLifeStyle:_listLifeStyleNote];
  NSMutableArray *jsonArray = [self generateMutableArrayContainDataLikeJSONForLifeStyle:_listLifeStyleNote];
  _listDateTime = [self getArrayDateForLifeStyleNote:jsonArray];
  [self calculateAvarageLifeStyle];
  [self.tableViewLifeStyleNote reloadData];
}

- (NSMutableArray *)getArrayDateForLifeStyleNote:(NSArray *)list {
  NSMutableArray *arrayDateTime = [[NSMutableArray alloc] init];
  
  for (int i = 0; i < list.count; i++) {
    NSDictionary *dict = [list objectAtIndex:i];
    NSDate *dateTime = [UIUtils dateFromServerTimeString:[dict valueForKeyPath:KEY_LifeStyleNote_Time_Sleep]];
    
    if (arrayDateTime.count > 0) {
      BOOL isAdd = YES;
      for (NSString *objDate in arrayDateTime) {
        if ([objDate isEqualToString:[UIUtils formatDateOppositeStyle:dateTime]]) {
          isAdd = NO;
        }
      }
      if (isAdd) {
        [arrayDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
      }
    }
    else {
      [arrayDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
    }
  }
  return arrayDateTime;
}


- (NSMutableArray *) timeSortedBeginsLifeStyle:(NSMutableArray *)array {
  NSMutableArray* begins = array;
  NSSortDescriptor *sort = [[NSSortDescriptor alloc] initWithKey:@"time_start_sleep" ascending:NO];
  [begins sortUsingDescriptors: @[sort]];
  return begins;
}

#pragma mark - TableView Data Source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
  return _listDateTime.count;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
  NSMutableArray *array = [NSMutableArray new];
  if (self.type == PHRGroupTypeLifeStyleNote) {
    NSString *dateTime = [_listDateTime objectAtIndex:section];
    array = [self getArrayLifeStyleFollowDate:dateTime];
  }
  
  return array.count;
}

- (NSMutableArray *)getArrayLifeStyleFollowDate:(NSString *)dateTime {
  NSMutableArray *result = [NSMutableArray new];
  for (LifeStyleNoteModel *model in _listLifeStyleNote) {
    NSString *currentDate = [UIUtils formatDateOppositeStyle:[UIUtils dateFromServerTimeString:model.time_start_sleep]];
    if ([currentDate isEqualToString:dateTime]) {
      [result addObject:model];
    }
  }
  return result;
}

- (UIView *)tableView:(UITableView *)tableView viewForHeaderInSection:(NSInteger)section {
  PHRBabyMilkHeaderView *headerView = [[[NSBundle mainBundle] loadNibNamed:@"PHRBabyMilkHeaderView" owner:self options:nil] objectAtIndex:0];
  NSString *currentDate = [_listDateTime objectAtIndex:section];
  if ([currentDate isEqualToString:[UIUtils formatDateOppositeStyle:[NSDate date]]]) {
    [headerView.lbDateTime setText:kLocalizedString(kToday)];
  }
  else {
    [headerView.lbDateTime setText:currentDate];
  }
  if (self.type == PHRGroupTypeLifeStyleNote) {
    [headerView.lbTimeOrMl setText:[self getTotalTimeForHeader:currentDate]];
  }
  [headerView.lbNumberKcal setText:PHR_STR_NULL];
  return headerView;
}

- (NSString *)getTotalTimeForHeader:(NSString *)dateTime {
  _totalTime = 0;
  if (self.type == PHRGroupTypeLifeStyleNote) {
    NSMutableArray *array = [self getArrayLifeStyleFollowDate:dateTime];
    for (LifeStyleNoteModel *model in array) {
      int value = [model.total_hour_sleep intValue];
      _totalTime += value;
    }
    
    int hours = _totalTime / 3600;
    int minutes = (_totalTime - 3600 * hours) / 60;
    
    NSString *strTime = [NSString stringWithFormat:@"%dh%.2d'", hours, minutes];
    return strTime;
  }
  return nil;
}

- (NSMutableArray*)generateMutableArrayContainDataLikeJSONForLifeStyle:(NSMutableArray*)inputArray{
  NSMutableArray* result = [[NSMutableArray alloc]init];
  for (id object in inputArray) {
    if ([object isKindOfClass:[LifeStyleNoteModel class]]) {
      LifeStyleNoteModel* lifeStyleItemObj = (LifeStyleNoteModel*) object;
      NSDictionary *lifeStyleItemDictionary =[NSDictionary dictionaryWithObjectsAndKeys:
                                              lifeStyleItemObj.time_start_sleep,KEY_LifeStyleNote_Time_Sleep,
                                              lifeStyleItemObj.time_wake_up    ,KEY_LifeStyleNote_Time_WakeUp,
                                              lifeStyleItemObj.total_hour_sleep,KEY_LifeStyleNote_Total_time,
                                              nil];
      [result addObject:lifeStyleItemDictionary];
    }
  }
  return result;
}


- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
  return 70.0;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
  LifeStyleNoteTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellLifeStyleIdentifier];
  
  if (!cell) {
    cell = [[LifeStyleNoteTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellLifeStyleIdentifier];
  }
  
  [cell setRightUtilityButtons:[self rightButtons] WithButtonWidth:80];
  cell.delegate = self;
  
  [cell setBackgroundColor:[UIColor clearColor]];
  [cell setSelectionStyle:UITableViewCellSelectionStyleNone];
  
  NSString *currentTime = [_listDateTime objectAtIndex:indexPath.section];
  NSMutableArray *array = [self getArrayLifeStyleFollowDate:currentTime];
  
  LifeStyleNoteModel *lifeStyleModel = nil;
  if (array.count > 0 && indexPath.row < array.count) {
    lifeStyleModel = [array objectAtIndex:indexPath.row];
  }
  
  if (lifeStyleModel) {
    [cell fillDataCellAndSetStyle:lifeStyleModel];
  }
  return cell;
  
  
  return nil;
}


#pragma mark - TableView Delegate

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
  
  NSString *currentTime = [_listDateTime objectAtIndex:indexPath.section];
  NSMutableArray *array = [self getArrayLifeStyleFollowDate:currentTime];
  LifeStyleNoteModel *lifeStyleModel = nil;
  if (array.count > 0) {
    lifeStyleModel = [array objectAtIndex:indexPath.row];
  }
  
  LifeStyleNoteViewController *controller = [[LifeStyleNoteViewController alloc] initWithNibName:NSStringFromClass([LifeStyleNoteViewController class]) bundle:nil];
  controller.idLifeStyleNote = [NSString stringWithFormat:@"%d",lifeStyleModel.id];
  controller.type = PHRGroupTypeStandard;
  
  if (lifeStyleModel.id) {
    controller.babySleepID = [NSString stringWithFormat:@"%i", lifeStyleModel.id];
  } else {
    controller.model = lifeStyleModel;
  }
  
  [controller setAddLifeStyleCallBack:^(LifeStyleNoteModel *type) {
    BOOL isUpdated = NO;
    for (int i = 0; i < _listLifeStyleNote.count; i++) {
      LifeStyleNoteModel *obj = (LifeStyleNoteModel*) _listLifeStyleNote[i];
      if (obj.id == type.id) {
        NSLog(@"[UPDATED]: %@",_listLifeStyleNote[i]);
        _listLifeStyleNote[i] = type;
        isUpdated = YES;
        NSLog(@"[UPDATED]: %@",_listLifeStyleNote[i]);
      }
      if (isUpdated) {
        NSLog(@"[BREAK]");
        break;
      }
    }
    [self requestGetChartData];
    [self reDrawChartLifeStyleAfterAdd];
  }];
  [self.navigationController pushViewController:controller animated:YES];
  
}

#pragma mark - MDTabBar Delegate
- (void)tabBar:(MDTabBar *)tabBar didChangeSelectedIndex:(NSUInteger)selectedIndex {
  timeIntervalIndex = selectedIndex;
  [self.chartLifeStyleDetail setDuration:timeIntervalIndex];
  [self requestGetChartData];
}

- (void)setupButtonFourTimeInterval{
  self.tabbarFourButton.delegate = self;
  [self.tabbarFourButton initContentWhiteTransperent:nil colorSelected:[UIColor whiteColor] andUnselectedColor:[[UIColor whiteColor] colorWithAlphaComponent:0.6] textFont:[FontUtils aileronRegularWithSize:12.0] selectedFont:[FontUtils aileronRegularWithSize:12.0]];
  timeIntervalIndex = ButtonTimeIntervalWeekly;
  self.tabbarFourButton.selectedIndex = timeIntervalIndex;
}

- (void)resetTableData{
  _numberPage = 1;
  isDataLoaded = NO;
  if (_listDateTime.count > 0) {
    [_listDateTime removeAllObjects];
  }
  if (_listLifeStyleNote.count > 0) {
    [_listLifeStyleNote removeAllObjects];
  }
  [self.tableViewLifeStyleNote reloadData];
}

- (void)requestGetChartData {
  NSString* duration = [NSString stringWithFormat:@"%d", (int)timeIntervalIndex + 1];
  [arrayChartData removeAllObjects];
  [self loadDataChart];
  
  if (taskGetChartData){
    [taskGetChartData cancel];
  }
  [self.viewIndicatorChart setHidden:NO];
  // server
  taskGetChartData = [[PHRClient instance] requestGetListLifeStyleWithDuration:duration andProfileID:PHRAppStatus.currentStandard.profileId completed:^(id response){
    if (response) {
      NSArray *arrayResult = nil;
      
      arrayResult = response[KEY_Content];
      
      if (arrayResult != nil && arrayResult != (id)[NSNull null] && [arrayResult count] > 0) {
        for (int i = 0; i < arrayResult.count; i++) {
          NSDictionary *dict = [arrayResult objectAtIndex:i];
          LifeStyleNoteModel *model = [[LifeStyleNoteModel alloc] initWithDictionary:dict error:nil];
          PHRSample *sample = [model sampleFromModel:model];
          [arrayChartData addObject:sample];
        }
      }
    }
    [self mergeDataLocalWithServer];
    [self loadChartWithSort];
    [self.viewIndicatorChart setHidden:YES];
  }error:^(NSString *error){
    [self mergeDataLocalWithServer];
    [self loadChartWithSort];
    [NSUtils showMessage:error withTitle:APP_NAME];
    [self.viewIndicatorChart setHidden:YES];
  }];
}

- (void)mergeDataLocalWithServer {
  NSArray* arrFromDatabase = [[StorageManager instance] getSamplesUnsyncForType:[PHRSample healthkitTypeFromType:0 fromScreen:StandardHomeTypeLifeStyle] profileId:PHRAppStatus.currentStandard.profileId];
  
  for (int i = 0; i < arrFromDatabase.count; i++) {
    
    PHRSample *sample = [[arrFromDatabase objectAtIndex:i] copy];
    [PHRChartUtils calculateSum:arrayChartData andSample:sample duration:timeIntervalIndex];
  }
}

- (NSArray *)rightButtons {
  NSMutableArray *rightUtilityButtons = [NSMutableArray new];
  [rightUtilityButtons sw_addUtilityButtonWithColor:
   [UIColor redColor]
                                               icon:[UIImage imageNamed:@"icon-trash-white"]];
  
  return rightUtilityButtons;
}

- (void)swipeableTableViewCell:(SWTableViewCell *)cell didTriggerRightUtilityButtonWithIndex:(NSInteger)index {
  NSIndexPath *indexPath = [self.tableViewLifeStyleNote indexPathForCell:cell];
  __weak __typeof(self) weakSelf = self;
  NSString *currentTime = [_listDateTime objectAtIndex:indexPath.section];
  
  
  NSMutableArray *array = [self getArrayLifeStyleFollowDate:currentTime];
  LifeStyleNoteModel *lifeStyleModel = nil;
  if (array.count > 0) {
    lifeStyleModel = [array objectAtIndex:indexPath.row];
  }
  
  NSString *objectID = [NSString stringWithFormat:@"%d", lifeStyleModel.id];
  //[PHRAppDelegate showLoading];
  [self showOrHideLoading:YES];
  [[PHRClient instance] requestDeleteObject:PHRAppStatus.currentStandard.profileId and:objectID andMethod:API_LifeStyleNote completion:^(MFResponse *reponse) {
    //[PHRAppDelegate hideLoading];
    
    [self showOrHideLoading:NO];
    if (reponse) {
      
      if (array.count == 1){ //Delete section if only 1 item
        [_listDateTime removeObjectAtIndex:indexPath.section];
      }
      [_listLifeStyleNote removeObject:lifeStyleModel];
      [weakSelf.tableViewLifeStyleNote reloadData];
      [self requestGetChartData];
    }
    else {
      [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
    }
  }];
  
  
}

- (BOOL)swipeableTableViewCell:(SWTableViewCell *)cell canSwipeToState:(SWCellState)state {
  if (_listLifeStyleNote.count == 0){
    return NO;
  }
  NSIndexPath *indexPath = [self.tableViewLifeStyleNote indexPathForCell:cell];
  NSString *currentTime = [_listDateTime objectAtIndex:indexPath.section];
  
  
  NSMutableArray *array = [self getArrayLifeStyleFollowDate:currentTime];
  LifeStyleNoteModel *lifeStyleModel = nil;
  if (array.count > 0) {
    lifeStyleModel = [array objectAtIndex:indexPath.row];
  }
  
  NSString *objectID = [NSString stringWithFormat:@"%d", lifeStyleModel.id];
  switch (state) {
    case kCellStateLeft:
      return NO;
    case kCellStateRight:
      if ([PHRAppStatus checkCurrentStandardActive] && objectID && objectID != [NSNull class] && ![objectID isEqualToString:@"0"]) {
        return YES;
      }
      
      return NO;
    default:
      break;
  }
  return YES;
}

- (IBAction)actionAddData:(id)sender{
  [self addNewLifeStyleNoteRecord];
}

@end
