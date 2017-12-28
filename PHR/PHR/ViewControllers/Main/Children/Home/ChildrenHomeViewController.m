//
//  ChildrenHomeViewController.m
//  PHR
//
//  Created by Luong Le Hoang on 9/29/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "ChildrenHomeViewController.h"
#import "ListDiapersViewController.h"
#import "BabyMilkViewController.h"
#import "BabyHomeCell.h"
#import "BabyHomeItem.h"
#import "PHRBabySleepViewController.h"
#import "LocalStorageImage.h"
#import "ChildrenMedicinesViewController.h"
#import "BabyFoodDetailViewController.h"
#import "BabyGrowthDetailViewController.h"
#import "FamilyListViewController.h"
#import "ChildrenDashboardViewController.h"

static const CGFloat kStandLineX = 75.f;
static const int kPageSize = 10;
static const NSString *KEY_TYPE_WEIGHT = @"weight";
static const NSString *KEY_TYPE_HEIGHT = @"height";
@interface ChildrenHomeViewController () {
  NSMutableArray *_arrayDateTime;
  int _limit;
  BOOL isDialogShown;
  BOOL isShowDialog;
}
@property (strong, nonatomic) NSMutableArray *arrayItems;
@property (assign, nonatomic) BOOL isFiltering;
@property (assign, nonatomic) BOOL isShow;
@end

@implementation ChildrenHomeViewController {
  
}

- (void)viewDidLoad {
  [super viewDidLoad];
  self.view.backgroundColor = [UIColor clearColor];
  //[self setupHomeNavigationBar:PHRGroupTypeBaby];
  self.refreshControl = [[UIRefreshControl alloc] init];
  [self.refreshControl setTintColor:[UIColor whiteColor]];
  [self.refreshControl addTarget:self action:@selector(requestGetListBabyTimeLine) forControlEvents:UIControlEventValueChanged];
  [self.tableHome addSubview:self.refreshControl];
  isShowDialog = YES;
  
  [self.tableHome addPullToRefreshWithActionHandler:^{
    [self loadMoreDataFromServer];
  } position:SVPullToRefreshPositionBottom];
  [self.tableHome.pullToRefreshView setArrowColor:[UIColor whiteColor]];
  [self.tableHome.pullToRefreshView setTextColor:[UIColor whiteColor]];
  
  
  // Setup home timeline item
  self.arrayItems = [[NSMutableArray alloc] init];
  _arrayDateTime = [NSMutableArray new];
  
  [self.view bringSubviewToFront:self.viewContent];
  [self.view bringSubviewToFront:self.btnModeStandard];
  
  // Register cell
  [self.tableHome registerNib:[UINib nibWithNibName:NSStringFromClass([BabyHomeCell class]) bundle:nil] forCellReuseIdentifier:NSStringFromClass([BabyHomeCell class])];
  
  [self resetDatainView];
  
  if (PHRAppStatus.arrayBabyProfile || PHRAppStatus.arrayBabyProfile.count > 0) {
    [self loadMoreDataFromServer];
  }
  
  // Add notification change active profile
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleActivedProfileChanged) name:kNotifyProfileBabyActiveChanged object:nil];
}

- (void)refreshAllView {
  [self resetDatainView];
  [self loadMoreDataFromServer];
}

- (void)handleActivedProfileChanged{
  [self resetDatainView];
  [self loadMoreDataFromServer];
}

- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
  // Dispose of any resources that can be recreated.
}

- (void)viewDidLayoutSubviews {
  [super viewDidLayoutSubviews];
}


- (void)viewWillAppear:(BOOL)animated{
  [super viewWillAppear:animated];
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleActivedProfileChanged) name:kNotifyProfileBabyActiveChanged object:nil];
  [self.tableHome reloadData];
}

- (void)removeObserve {
  [[NSNotificationCenter defaultCenter] removeObserver:self];
}

- (void)showOrHideLoading:(BOOL)isShowed{
  if (isShowed){
    [PHRAppDelegate showLoadingInView:self.viewLoading];
  } else {
    [PHRAppDelegate hideLoadingInView:self.viewLoading];
  }
}

#pragma mark - Connect Server
- (void)requestGetListBabyTimeLine {
  [self resetDatainView];
  if (PHRAppStatus.currentBaby && PHRAppStatus.currentBaby.profileId) {
    __weak __typeof(self) weakSelf = self;
    [[PHRClient instance] requestGetListBabytimeLineWithId:PHRAppStatus.currentBaby.profileId andNumberLimit:kPageSize completed:^(MFRession *responseObject) {
      [self.refreshControl endRefreshing];
      BabyTimeLineResponse *BBResponse = [[BabyTimeLineResponse alloc] initWithDictionary:responseObject.content error:nil];
      self.arrayItems = [NSMutableArray arrayWithArray:BBResponse.baby_timeline_dates];
      [weakSelf parseDataTimeLine:BBResponse.baby_timeline_dates];
    } error:^(NSString *error) {
      [self.refreshControl endRefreshing];
      if (isShowDialog) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
      }
    }];
  }
}

- (void)loadMoreDataFromServer {
  if (PHRAppStatus.currentBaby && PHRAppStatus.currentBaby && PHRAppStatus.currentBaby.profileId) {
    [self showOrHideLoading:YES];
    __weak __typeof(self) weakSelf = self;
    [[PHRClient instance] requestGetListBabytimeLineWithId:PHRAppStatus.currentBaby.profileId andNumberLimit:_limit completed:^(MFRession *responseObject) {
      BabyTimeLineResponse *BBResponse = [[BabyTimeLineResponse alloc] initWithDictionary:responseObject.content error:nil];
      self.arrayItems = [NSMutableArray arrayWithArray:BBResponse.baby_timeline_dates];
      [weakSelf parseDataTimeLine:BBResponse.baby_timeline_dates];
      _limit += kPageSize;
      [self showOrHideLoading:NO];
    } error:^(NSString *error) {
      [self showOrHideLoading:NO];
      if (isShowDialog) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
      }
    }];
  }
}

- (void)findAndProcessBabyGrowthInTimeLineArray:(BabyGrowthModel *)editedObj {
  for (BabyTimeLineModel *objBabyTimeLine in self.arrayItems) {
    [self handleEditBabyGrowthType:[editedObj.type integerValue]
                      babyTimeLine:objBabyTimeLine
                         editedObj:editedObj];
  }
}

- (void)handleEditBabyGrowthType:(BabyGrowthType)type
                    babyTimeLine:(BabyTimeLineModel *)objBabyTimeLine
                       editedObj:(BabyGrowthModel *)editedObj {
  for (int i = 0; i < objBabyTimeLine.list_baby_growth_height.count; i++) {
    BabyGrowthModel *model = (BabyGrowthModel*)[objBabyTimeLine.list_baby_growth_height objectAtIndex:i];
    if([[NSString stringWithFormat:@"%@",editedObj.growth_id] isEqualToString:[NSString stringWithFormat:@"%@",model.growth_id]]) {
      // remove old object
      if (type == BabyGrowthHeight) {
        [objBabyTimeLine.list_baby_growth_height removeObjectAtIndex:i];
      } else {
        [objBabyTimeLine.list_baby_growth_weight removeObjectAtIndex:i];
      }
      break;
    }
  }
  // add new object to destination section
  for (BabyTimeLineModel *objBabyTimeLine in self.arrayItems) {
    if ([objBabyTimeLine.date isEqualToString:[editedObj.time_measure substringToIndex:10]]) {
      if (type == BabyGrowthHeight) {
        if (![objBabyTimeLine.list_baby_growth_height containsObject:editedObj]) {
          [objBabyTimeLine.list_baby_growth_height addObject:editedObj];
        }
      } else {
        if (![objBabyTimeLine.list_baby_growth_weight containsObject:editedObj]) {
          [objBabyTimeLine.list_baby_growth_weight addObject:editedObj];
        }
      }
    }
    break;
  }
}

- (void)handleEditBabyFood:(BabyTimeLineModel *)objBabyTimeLine
                 editedObj:(BabyGrowthModel *)editedObj {
  for (int i = 0; i < objBabyTimeLine.list_baby_food.count; i++) {
    BabyGrowthModel *model = (BabyGrowthModel*)[objBabyTimeLine.list_baby_food objectAtIndex:i];
    if([[NSString stringWithFormat:@"%@",editedObj.growth_id] isEqualToString:[NSString stringWithFormat:@"%@",model.growth_id]]) {
      // remove old object
      [objBabyTimeLine.list_baby_food removeObjectAtIndex:i];
      break;
    }
  }
  // add new object to destination section
  for (BabyTimeLineModel *objBabyTimeLine in self.arrayItems) {
    if ([objBabyTimeLine.date isEqualToString:[editedObj.time_measure substringToIndex:10]]) {
      if (![objBabyTimeLine.list_baby_food containsObject:editedObj]) {
        [objBabyTimeLine.list_baby_food addObject:editedObj];
      }
    }
    break;
  }
}

- (void)handleEditDiaper:(BabyTimeLineModel *)objBabyTimeLine
               editedObj:(BabyDiaperModel *)editedObj {
  for (int i = 0; i < objBabyTimeLine.list_baby_food.count; i++) {
    BabyDiaperModel *model = (BabyDiaperModel*)[objBabyTimeLine.list_baby_food objectAtIndex:i];
    if([[NSString stringWithFormat:@"%@",editedObj.id] isEqualToString:[NSString stringWithFormat:@"%@",model.id]]) {
      // remove old object
      [objBabyTimeLine.list_baby_diaper removeObjectAtIndex:i];
      break;
    }
  }
  // add new object to destination section
  for (BabyTimeLineModel *objBabyTimeLine in self.arrayItems) {
    if ([objBabyTimeLine.date isEqualToString:[editedObj.time_pee_poo substringToIndex:10]]) {
      if (![objBabyTimeLine.list_baby_diaper containsObject:editedObj]) {
        [objBabyTimeLine.list_baby_diaper addObject:editedObj];
      }
    }
    break;
  }
}

- (void)removeRecordToView:(NSNotification *)notification {
  id objectRecord = notification.object;
  BabyTimeLineModel *objBabyTimeLine = [self.arrayItems firstObject];
  
  if ([objectRecord isKindOfClass:[BabyMedicineModel class]]) {
    BabyMedicineModel *model = (BabyMedicineModel*)objectRecord;
    [objBabyTimeLine.list_medicine insertObject:model atIndex:0];
    [self.tableHome reloadData];
  }
  
  if ([objectRecord isKindOfClass:[BabyMilkModel class]]) {
    BabyMilkModel *model = (BabyMilkModel*)objectRecord;
    
    [objBabyTimeLine.list_baby_milk insertObject:model atIndex:0];
    [self.tableHome reloadData];
  }
  
  if ([objectRecord isKindOfClass:[BabyFoodModel class]]) {
    BabyFoodModel *edited = (BabyFoodModel*)objectRecord;
    for (int i = 0;i < objBabyTimeLine.list_baby_food.count; i++) {
      BabyFoodModel *model = (BabyFoodModel*)[objBabyTimeLine.list_baby_food objectAtIndex:i];
      if([[NSString stringWithFormat:@"%@",edited.food_id] isEqualToString:[NSString stringWithFormat:@"%@",model.food_id]]) {
        [objBabyTimeLine.list_baby_food removeObjectAtIndex:i];
        break;
      }
    }
    //[objBabyTimeLine.list_baby_food insertObject:model atIndex:0];
    [self.tableHome reloadData];
  }
  
  if ([objectRecord isKindOfClass:[BabyGrowthModel class]]) {
    BabyGrowthModel *editedObj = (BabyGrowthModel*)objectRecord;
    if([editedObj.type intValue] == BabyGrowthHeight){ //0 is type height
      for (int i = 0;i < objBabyTimeLine.list_baby_growth_height.count; i++) {
        BabyGrowthModel *model = (BabyGrowthModel*)[objBabyTimeLine.list_baby_growth_height objectAtIndex:i];
        if([[NSString stringWithFormat:@"%@",editedObj.growth_id] isEqualToString:[NSString stringWithFormat:@"%@",model.growth_id]]) {
          [objBabyTimeLine.list_baby_growth_height replaceObjectAtIndex:i withObject:editedObj];
          break;
        }
      }
      
    } else {
      for (int i = 0;i < objBabyTimeLine.list_baby_growth_weight.count; i++) {
        BabyGrowthModel *model = (BabyGrowthModel*)[objBabyTimeLine.list_baby_growth_weight objectAtIndex:i];
        if([[NSString stringWithFormat:@"%@",editedObj.growth_id] isEqualToString:[NSString stringWithFormat:@"%@",model.growth_id]]) {
          [objBabyTimeLine.list_baby_growth_weight replaceObjectAtIndex:i withObject:editedObj];
          break;
        }
      }
      
    }
    
    [self.tableHome reloadData];
  }
  
  
  if ([objectRecord isKindOfClass:[BabySleepModel class]]) {
    BabySleepModel *model = (BabySleepModel*)objectRecord;
    [objBabyTimeLine.list_baby_sleep insertObject:model atIndex:0];
    [self.tableHome reloadData];
  }
  
  if ([objectRecord isKindOfClass:[Diaper class]]) {
    Diaper *edited = (Diaper*)objectRecord;
    BabyDiaperModel *modelEdited = [[BabyDiaperModel alloc] init];
    
    modelEdited.id = edited.diaperID;
    modelEdited.alert = edited.alert;
    modelEdited.color = edited.color;
    modelEdited.method = edited.method;
    modelEdited.note = edited.note;
    modelEdited.state = edited.state;
    modelEdited.time_pee_poo = edited.time_pee_poo;
    for (int i = 0;i < objBabyTimeLine.list_baby_diaper.count; i++) {
      BabyDiaperModel *model = (BabyDiaperModel*)[objBabyTimeLine.list_baby_diaper objectAtIndex:i];
      if([[NSString stringWithFormat:@"%@",modelEdited.id] isEqualToString:[NSString stringWithFormat:@"%@",model.id]]) {
        [objBabyTimeLine.list_baby_diaper replaceObjectAtIndex:i withObject:modelEdited];
        break;
      }
    }
    //[objBabyTimeLine.list_baby_food insertObject:model atIndex:0];
    [self.tableHome reloadData];
    
  }
}

#pragma mark - Parse Data

- (NSMutableArray *)parseDateFromBabyTimeLineModel:(BabyTimeLineModel *)model {
  NSMutableArray *array = [NSMutableArray new];
  
  NSArray *milks      = model.list_baby_milk;
  NSArray *foods      = model.list_baby_food;
  NSArray *diapers    = model.list_baby_diaper;
  NSArray *medicines  = model.list_medicine;
  NSArray *growths    = model.list_baby_growth_height;
  NSArray *growthsWeight    = model.list_baby_growth_weight;
  NSArray *sleeps     = model.list_baby_sleep;
  
  if (milks.count > 0) {
    [array addObjectsFromArray:milks];
  }
  if (foods.count > 0) {
    [array addObjectsFromArray:foods];
  }
  if (diapers.count > 0) {
    [array addObjectsFromArray:diapers];
  }
  if (medicines.count > 0) {
    [array addObjectsFromArray:medicines];
  }
  for (int i = 0; i < model.list_baby_growth_height.count; i++){
    BabyGrowthModel *babyGrowthModel = [model.list_baby_growth_height objectAtIndex:i];
    babyGrowthModel.type = [NSNumber numberWithInt:BabyGrowthHeight];
  }
  if (growths.count > 0) {
    [array addObjectsFromArray:growths];
  }
  for (int i = 0; i < model.list_baby_growth_weight.count; i++){
    BabyGrowthModel *babyGrowthModel = [model.list_baby_growth_weight objectAtIndex:i];
    babyGrowthModel.type = [NSNumber numberWithInt:BabyGrowthWeight];
  }
  if (growthsWeight.count > 0) {
    [array addObjectsFromArray:growthsWeight];
  }
  if (sleeps.count > 0) {
    [array addObjectsFromArray:sleeps];
  }
  return array;
}

- (void)parseDataTimeLine:(NSArray *)arrayTimeLine {
  for (BabyTimeLineModel *objModel in arrayTimeLine) {
    NSString *dateTime = objModel.date;
    if (_arrayDateTime.count > 0) {
      BOOL isAdd = YES;
      for (NSString *objDateTime in _arrayDateTime) {
        if ([objDateTime isEqualToString:dateTime]) {
          isAdd = NO;
        }
      }
      if (isAdd) {
        [_arrayDateTime addObject:dateTime];
      }
    }
    else {
      [_arrayDateTime addObject:dateTime];
    }
  }
  
  [self.tableHome reloadData];
  [self.tableHome.pullToRefreshView stopAnimating];
}

- (void)resetDatainView {
  _limit = kPageSize;
  if (_arrayDateTime.count > 0) {
    [_arrayDateTime removeAllObjects];
  }
  [self.tableHome reloadData];
  //[self setImageToBackgroundBaby];
}

#pragma mark - Public Methods

- (IBAction)actionChangeToStandardMode:(id)sender {
  [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyDashboardChangeTabbarIndex object:@(0)];
}


#pragma mark - Tableview delegate

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
  return _arrayDateTime.count;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
  return 7.0;
}

- (CGFloat)tableView:(UITableView *)tableView heightForHeaderInSection:(NSInteger)section {
  return 40;
}

- (UIView *)tableView:(UITableView *)tableView viewForHeaderInSection:(NSInteger)section {
  // Header will display date time
  NSString *dateTime = [_arrayDateTime objectAtIndex:section];
  
  UIView *header = [[UIView alloc] initWithFrame:CGRectMake(0, 0, SCREEN_WIDTH, 40)];
  UILabel *labelTitle = [[UILabel alloc] initWithFrame:CGRectMake(20, 0, kStandLineX * 3, header.frame.size.height)];
  labelTitle.textColor = [UIColor whiteColor];
  labelTitle.textAlignment = NSTextAlignmentLeft;
  [labelTitle setFont:[FontUtils aileronRegularWithSize:18]];
  NSDate *dateOfSection = [UIUtils dateFromString:dateTime withFormat:@"yyyy/MM/dd"];
  
  NSDateFormatter *dateFormatter = [[NSDateFormatter alloc] init];
  [dateFormatter setDateFormat:@"yyyy-MM-dd"];
  NSDate *currentDate = [NSDate date];
  NSString *currentDateString = [dateFormatter stringFromDate:currentDate];
  
  if ([dateTime isEqualToString:currentDateString]) {
    [labelTitle setText:kLocalizedString(kTitleToday)];
  }
  else {
    labelTitle.text = [UIUtils stringDate:dateOfSection withFormat:PHR_SERVER_DATE_TIME_FORMAT_MMMM];;
  }
  [header addSubview:labelTitle];
  [header setClipsToBounds:YES];
  return header;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
  if (indexPath.section >= self.arrayItems.count) {
    return 0;
  }
  BabyTimeLineModel *item = self.arrayItems[indexPath.section];
  
  NSArray *milks      = item.list_baby_milk;
  NSArray *foods      = item.list_baby_food;
  NSArray *diapers    = item.list_baby_diaper;
  NSArray *medicines  = item.list_medicine;
  NSArray *growths    = item.list_baby_growth_height;
  NSArray *growthsWeight    = item.list_baby_growth_weight;
  NSArray *sleeps     = item.list_baby_sleep;
  
  if (indexPath.row == 0) {
    int extraSpace = 0;
    if (milks.count >0 ){
      extraSpace = 5;
    }
    return 75 * milks.count + extraSpace;
  }
  if (indexPath.row == 1 ){
    int extraSpace = 0;
    if (foods.count >0 ){
      extraSpace = 20;
    }
    return 70 * foods.count + extraSpace ;
  }
  if (indexPath.row == 2) {
    int extraSpace = 0;
    if (diapers.count >0 ){
      extraSpace = 5;
    }
    return 70 * diapers.count + extraSpace;
  }
  if (indexPath.row == 3) {
    int extraSpace = 0;
    if (medicines.count >0 ){
      extraSpace = 5;
    }
    return 80 * medicines.count + extraSpace;
  }
  if (indexPath.row == 4) {
    int extraSpace = 0;
    if (growths.count >0 ){
      extraSpace = 15;
    }
    return 65 * growths.count + extraSpace;
  }
  if (indexPath.row == 5) {
    int extraSpace = 0;
    if (growthsWeight.count >0 ){
      extraSpace = 15;
    }
    return 65 * growthsWeight.count + extraSpace;
  }
  if (indexPath.row == 6) {
    int extraSpace = 0;
    if (sleeps.count > 0 ){
      extraSpace = 5 + (int)sleeps.count * 5;
    }
    return 80 * sleeps.count + extraSpace;
  }
  return 0;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
  BabyHomeCell *cell = (BabyHomeCell*)[tableView dequeueReusableCellWithIdentifier:NSStringFromClass([BabyHomeCell class])];
  BabyTimeLineModel *objBabyTimeLine = [self.arrayItems objectAtIndex:indexPath.section];
  
  NSString *dateTime = objBabyTimeLine.date;
  [cell.labelHour setText:[UIUtils formatTimeGetHours:[UIUtils dateFromServerTimeString:dateTime]]];
  [cell.labelAMPM setText:[UIUtils formatTimeGetAmOrPm:[UIUtils dateFromServerTimeString:dateTime]]];
  
  
  if (indexPath.row == 0) {
    [cell setupViewContentWithType:PHRBabyGroupTypeMilk andModel:objBabyTimeLine.list_baby_milk andShowSymbol:NO];
  }
  if (indexPath.row == 1 ){
    [cell setupViewContentWithType:PHRBabyGroupTypeFood andModel:objBabyTimeLine.list_baby_food andShowSymbol:NO];
  }
  if (indexPath.row == 2) {
    [cell setupViewContentWithType:PHRBabyGroupTypeDiaper andModel:objBabyTimeLine.list_baby_diaper andShowSymbol:NO];
  }
  if (indexPath.row == 3) {
    [cell setupViewContentWithType:PHRBabyGroupTypeMedicine andModel:objBabyTimeLine.list_medicine andShowSymbol:NO];
  }
  if (indexPath.row == 4) {
    [cell setupViewContentWithType:PHRBabyGroupTypeGrowth andModel:objBabyTimeLine.list_baby_growth_height andShowSymbol:NO];
  }
  if (indexPath.row == 5) {
    [cell setupViewContentWithType:PHRBabyGroupTypeGrowth andModel:objBabyTimeLine.list_baby_growth_weight andShowSymbol:NO];
  }
  if (indexPath.row == 6) {
    [cell setupViewContentWithType:PHRBabyGroupTypeSleep andModel:objBabyTimeLine.list_baby_sleep andShowSymbol:NO];
  }
  
  return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {

  if ([self.delegate respondsToSelector:@selector(openViewControllerAtIndex:)]) {
    switch (indexPath.row) {
      case 0:
        [self.delegate openViewControllerAtIndex:PHRBabyGroupTypeMilk];
        break;
      case 1:
        [self.delegate openViewControllerAtIndex:PHRBabyGroupTypeFood];
        break;
      case 2:
        [self.delegate openViewControllerAtIndex:PHRBabyGroupTypeDiaper];
        break;
      case 3:
        [self.delegate openViewControllerAtIndex:PHRBabyGroupTypeMedicine];
        break;
      case 4:
        [self.delegate openViewControllerAtIndex:PHRBabyGroupTypeGrowth];
        break;
      case 5:
        [self.delegate openViewControllerAtIndex:PHRBabyGroupTypeGrowth];
        break;
      case 6:
        [self.delegate openViewControllerAtIndex:PHRBabyGroupTypeSleep];
        break;
      default:
        break;
    }
  }
}


- (void)setIsShowDialog:(BOOL)isShow {
  isShowDialog = isShow;
}

- (void)dealloc {
  [[NSNotificationCenter defaultCenter] removeObserver:self];
}

@end
