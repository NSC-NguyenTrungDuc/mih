//
//  StandardFoodDetailViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "StandardFoodDetailViewController.h"
#import "TriangleView.h"

@interface StandardFoodDetailViewController () {
  ButtonTimeIntervalClick durationType;
  BOOL isDataLoaded;
  int numberPage;
  NSArray *palleteColor;
  NSURLSessionDataTask *taskGetTimeLine;
  NSURLSessionDataTask *taskGetChartData;
}

@end

@implementation StandardFoodDetailViewController
static NSString *CellIdentifier = @"TableViewCellIdentifier";
- (void)viewDidLoad {
  [super viewDidLoad];
  [self initData];
  [self initView];
  [self requestGetChartData];
  [self requestGetTimeLine];
  
}

#pragma mark - Handle notify data Healthkit/bluetooth
- (void)handleBluetoothData:(NSNotification*)notification{
  PHRSample *sample = [(PHRSample*)notification.object copy];
  if (sample && [sample.type isEqualToString:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeFood]]) {
    [self addNewSample:sample isLoadData:NO];
  }
}

- (void)handleHealthKitData:(NSNotification*)notification{
  PHRSample *sample = [(PHRSample*)notification.object copy];
  if (sample && [sample.type isEqualToString:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeFood]]) {
    [self addNewSample:sample isLoadData:YES];
  }
}

- (void)addNewSample:(PHRSample*)sample isLoadData:(BOOL)isLoadData{
  [PHRChartUtils calculateSum:self.arrayChartData andSample:sample duration:durationType];
  if(isLoadData) {
    [self loadChartWithSorted];
  }
  
  // add to list
  FoodItem *item = [[FoodItem alloc] initFromSample:sample];
  [self.arrayTableViewData insertObject:item atIndex:0];
  [self.tableView reloadData];
  [self calculateSummary];
}

- (void)initData {
  numberPage = 1;
  self.arrayChartData = [[NSMutableArray alloc] init];
  self.arrayTableViewData = [[NSMutableArray alloc] init];
  palleteColor = @[[PHR_COLOR_FOOD_MAIN_COLOR colorWithAlphaComponent:1],
                   [PHR_COLOR_FOOD_MAIN_COLOR colorWithAlphaComponent:1],
                   [PHR_COLOR_FOOD_MAIN_COLOR colorWithAlphaComponent:1],
                   [PHR_COLOR_FOOD_MAIN_COLOR colorWithAlphaComponent:1],
                   [PHR_COLOR_FOOD_MAIN_COLOR colorWithAlphaComponent:1]];
}

- (void)initView {
  [self.view setBackgroundColor:[UIColor whiteColor]];
  [self setupNavigationBarTitle:kLocalizedString(kTitleFood) iconLeft:@"Icon_Person" iconRight:@"Icon_Family" iconMiddle:@"Icon_Standand_Food" isDismissView:false colorLeft:[PHR_COLOR_FOOD_NAV_LEFT colorWithAlphaComponent:0.5] colorRight:[PHR_COLOR_FOOD_NAV_RIGHT colorWithAlphaComponent:0.5]];
  [self checkProfileToShowView];
  [self initTabbarDuration];
  [self initChart];
  [self initTriangleView];
  [self initTabbarType];
  [self calculateSummary];
  [self initTableView];
  [self.viewAdd setBackgroundColor:PHR_COLOR_FOOD_MAIN_COLOR];
  [self.labelAdd setText:kLocalizedString(kAdd)];
}


- (void)viewWillAppear:(BOOL)animated {
  [super viewWillAppear:animated];
  [self setImageToBackgroundStandard:self.imageBackground];
  
  [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyProfileStandardActiveChanged object:nil];
  [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyBluetoothData object:nil];
  [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyHealthkitData object:nil];
  [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyBlueDisconnectDevice object:nil];
  
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleProfileActiveChanged:) name:kNotifyProfileStandardActiveChanged object:nil];
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleBluetoothData:) name:kNotifyBluetoothData object:nil];
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleHealthKitData:) name:kNotifyHealthkitData object:nil];
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(loadChartWithSorted) name:kNotifyBlueDisconnectDevice object:nil];
}

- (void)viewWillDisappear:(BOOL)animated {
  [super viewWillDisappear:animated];
  NSArray *viewControllers = self.navigationController.viewControllers;
  if ([viewControllers indexOfObject:self] == NSNotFound) {
    [[NSNotificationCenter defaultCenter] removeObserver:self];
  }
}

- (void)initTabbarDuration {
  self.tabbarDuration.delegate = self;
  [self.tabbarDuration initContentWhiteTransperent:nil colorSelected:[UIColor whiteColor] andUnselectedColor:[[UIColor whiteColor] colorWithAlphaComponent:0.6] textFont:[FontUtils aileronRegularWithSize:12.0] selectedFont:[FontUtils aileronRegularWithSize:12.0]];
  durationType = ButtonTimeIntervalWeekly;
  self.tabbarDuration.selectedIndex = durationType;
}

- (void)initTabbarType {
  NSDictionary *typeCalories = @{PHR_TYPE_IDENTIFIER : kLocalizedString(kCalories) };
  NSDictionary *typeCarbohydrates = @{ PHR_TYPE_IDENTIFIER : kLocalizedString(kCarbohydrate)};
  NSDictionary *typeTotalFat = @{ PHR_TYPE_IDENTIFIER : kLocalizedString(kTotalFat)};
  NSArray* arr = @[typeCalories,typeCarbohydrates,typeTotalFat];
  self.tabbarType.topMenuDelegate = self;
  self.tabbarType.backgroundColor = PHR_COLOR_FOOD_TABBAR_TYPE;
  [self.tabbarType calcurateWidth:arr];
}

- (void)initTriangleView {
  float triangleWidth = 12;
  float triangleHeight = 8;
  TriangleView *triangle = [[TriangleView alloc] initWithFrame:CGRectMake([UIScreen mainScreen].bounds.size.width / 2 - triangleWidth / 2 , 0, triangleWidth, triangleHeight)];
  [triangle setBackgroundColor:[UIColor clearColor]];
  triangle.arrayRGB = [NSArray arrayWithObjects:@"91",@"82", @"132", nil];
  [self.viewTriangle addSubview:triangle];
}

- (void)initChart{
  [self.chartView initializeChart:self];
  [self.chartView setShowAvarage:YES];
  [self.chartView setIsShowGradient:YES andIsDetailChart:YES];
  [self.chartView setLineChartColor:[UIColor whiteColor] andFillBallColor:[[UIColor blackColor] colorWithAlphaComponent:0.5]];
  [self.chartView setChartBackgroundColor:[UIColor clearColor]];
  self.chartView.chartType = [PHRChartUtils getChartType:StandardHomeTypeFood andIndex:self.typeIndex];
  [self.chartView doCustomize];
  
  [self loadDataChart];
  
  //Swipe
  UISwipeGestureRecognizer *recognizerRight = [[UISwipeGestureRecognizer alloc] initWithTarget:self action:@selector(swipeRecognizer:)];
  recognizerRight.direction = UISwipeGestureRecognizerDirectionRight;
  
  UISwipeGestureRecognizer *recognizerLeft = [[UISwipeGestureRecognizer alloc] initWithTarget:self action:@selector(swipeRecognizer:)];
  recognizerLeft.direction = UISwipeGestureRecognizerDirectionLeft;
  recognizerRight.delegate = self;
  recognizerLeft.delegate = self;
  [self.chartView addGestureRecognizer:recognizerRight];
  [self.chartView addGestureRecognizer:recognizerLeft];
  
}

- (void)swipeRecognizer:(UISwipeGestureRecognizer *)sender {
  if (sender.direction == UISwipeGestureRecognizerDirectionRight) {
    if (self.typeIndex == 0) {
      [self.navigationController popViewControllerAnimated:YES];
    }
    if (self.typeIndex > 0) {
      [self.tabbarType setScrollPage:self.typeIndex - 1];
    }
  }
  if (sender.direction == UISwipeGestureRecognizerDirectionLeft){
    if (self.typeIndex < [self.tabbarType numberOfPages] - 1) {
      [self.tabbarType setScrollPage:self.typeIndex + 1];
    }
  }
}

- (void)calculateSummary{
  double value = 0;
  if (self.typeIndex == FoodTypeCalories) {
    for (FoodItem *model in self.arrayTableViewData) {
      value += floor([model.calories doubleValue]);
    }
    [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.0f",value] withUnit:kLocalizedString(kUnitCal) andColor:PHR_COLOR_FOOD_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
  } else if (self.typeIndex == FoodTypeCarbohydrates) {
    for (FoodItem *model in self.arrayTableViewData) {
      value += floor([model.carbohydrates doubleValue]);
    }
    [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.0f",value] withUnit:kLocalizedString(kUnitG) andColor:PHR_COLOR_FOOD_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
  } else if (self.typeIndex == FoodTypeTotalFat) {
    for (FoodItem *model in self.arrayTableViewData) {
      value += floor([model.totalFat doubleValue]);
    }
    [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.0f",value] withUnit:kLocalizedString(kUnitG) andColor:PHR_COLOR_FOOD_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
  }
  [self.labelSummary setText:kLocalizedString(kTotal)];
}

- (void)initTableView {
  self.tableView.delegate = self;
  self.tableView.dataSource = self;
  self.tableView.separatorStyle = UITableViewCellSeparatorStyleNone;
  self.tableView.showsVerticalScrollIndicator = false;
  UINib *cell = [UINib nibWithNibName:@"StandardDetailTableViewCell" bundle:nil];
  [self.tableView registerNib:cell forCellReuseIdentifier:CellIdentifier];
  
  self.refreshControl = [[UIRefreshControl alloc] init];
  [self.refreshControl addTarget:self action:@selector(pullToRefreshData) forControlEvents:UIControlEventValueChanged];
  [self.tableView addSubview:self.refreshControl];
  [self.tableView addPullToRefreshWithActionHandler:^{
    [self requestGetTimeLine];
  } position:SVPullToRefreshPositionBottom];
}

- (void)loadDataChart {
  [self.chartView setData:self.arrayChartData];
  [self.chartView updateChartData];
}

- (void)handleProfileActiveChanged:(NSNotification*)notification{
  [self checkProfileToShowView];
  [self refreshAllView];
}

- (void)checkProfileToShowView {
  if (![PHRAppStatus checkCurrentStandardActive]) {
    [self.viewAdd setHidden:YES];
    self.constraintTblAndSave.constant = 0 - self.viewAdd.bounds.size.height;
  } else {
    [self.viewAdd setHidden:NO];
    self.constraintTblAndSave.constant = 0;
  }
}

#pragma mark - MDTABBAR delegate
- (void)tabBar:(MDTabBar *)tabBar didChangeSelectedIndex:(NSUInteger)selectedIndex {
  if (tabBar.tag == MDTabBarTagTypeFourButtonNoBorder) {
    durationType = selectedIndex;
    [self.chartView setDuration:durationType];
    [self requestGetChartData];
  }
}


- (void)requestGetChartData {
  NSString* duration = [NSString stringWithFormat:@"%d", (int)durationType + 1];
  [self.arrayChartData removeAllObjects];
  [self loadDataChart];
  if (taskGetChartData) {
    [taskGetChartData cancel];
  }
  [self.viewIndicatorChart setHidden:NO];
  // server
  taskGetChartData = [[PHRClient instance] requestGetListFoodWithDuration:duration FoodType:self.typeIndex andProfileID:PHRAppStatus.currentStandard.profileId completed:^(id response){
    if (response) {
      NSArray *arrayResult = nil;
      
      if(self.typeIndex == ChartFoodTypeCalories){
        arrayResult = [response[KEY_Content] objectForKey:KEY_Calories_Info];
      } else if (self.typeIndex == ChartFoodTypeCarbohydrates) {
        arrayResult = [response[KEY_Content] objectForKey:KEY_Carbodydrate_Info];
      } else if (self.typeIndex == ChartFoodTypeTotalFat) {
        arrayResult = [response[KEY_Content] objectForKey:KEY_Total_Fat_Info];
      }
      
      if (arrayResult != nil && arrayResult != (id)[NSNull null] && [arrayResult count] > 0) {
        for (int i = 0; i < arrayResult.count; i++) {
          PHRSample *sample = [FoodItem sampleFromDict:arrayResult[i] type:(FoodType)self.typeIndex];
          [self.arrayChartData addObject:sample];
        }
      }
    }
    // reload chart ofter sorted by date
    [self mergeDataLocalWithServer];
    [self loadChartWithSorted];
    [self.viewIndicatorChart setHidden:YES];
  }error:^(NSString *error){
    [self mergeDataLocalWithServer];
    [self loadChartWithSorted];
    [NSUtils showMessage:error withTitle:APP_NAME];
    [self.viewIndicatorChart setHidden:YES];
  }];
  
}

- (void)mergeDataLocalWithServer {
  NSArray* arrFromDatabase = [[StorageManager instance] getSamplesUnsyncForType:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeFood] profileId:PHRAppStatus.currentStandard.profileId];
  
  for (int i = 0; i < arrFromDatabase.count; i++) {
    PHRSample *sample = [[arrFromDatabase objectAtIndex:i] copy];
    [PHRChartUtils calculateSum:self.arrayChartData andSample:sample duration:durationType];
  }
}

- (void)requestGetTimeLine {
  __weak __typeof__(self) weakSelf = self;
  // storage
  if (!isDataLoaded) {
    isDataLoaded = YES;
    NSArray *samples = [[StorageManager instance] getSamplesUnsyncForType:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeFood] profileId:PHRAppStatus.currentStandard.profileId];
    for (PHRSample *sample in samples) {
      FoodItem *item = [[FoodItem alloc] initFromSample:sample];
      [self.arrayTableViewData addObject:item];
    }
  }
  
  if (taskGetTimeLine){
    [taskGetTimeLine cancel];
  }
  [self.viewIndicatorTable setHidden:NO];
  taskGetTimeLine = [[PHRClient instance] requestGetTimeLineFood:PHRAppStatus.currentStandard.profileId withFoodType:self.typeIndex andPageNumber:[NSString stringWithFormat:@"%d",numberPage] completed:^(id response){
    if (response) {
      NSArray *arrayResult = [response[KEY_Content] objectForKey:KEY_Food_Data];
      if (arrayResult != nil && arrayResult != (id)[NSNull null] && [arrayResult count] > 0) {
        for (int i = 0; i < arrayResult.count; i++) {
          NSDictionary *dict = [arrayResult objectAtIndex:i];
          FoodItem *foodItem = [FoodItem initWithObj:dict];
          [self.arrayTableViewData addObject:foodItem];
        }
        
        
        numberPage += 1;
      }
    }
    // SORT BY DATETIME
//    [self.arrayTableViewData sortUsingComparator:^NSComparisonResult(BodyMeasurementModel *obj1, BodyMeasurementModel *obj2){
//      NSDate *date1 = [UIUtils dateFromString:obj1.date withFormat:PHR_SERVER_DATE_TIME_FORMAT];
//      NSDate *date2 = [UIUtils dateFromString:obj2.date withFormat:PHR_SERVER_DATE_TIME_FORMAT];
//      return [date2 compare:date1];
//    }];
    
    NSSortDescriptor *descriptor = [NSSortDescriptor sortDescriptorWithKey:@"date"
                                                                 ascending:NO];
    [self.arrayTableViewData sortUsingDescriptors:[NSArray arrayWithObject:descriptor]];
    
    [self.tableView reloadData];
    [self calculateSummary];
    [self.refreshControl endRefreshing];
    [self.viewIndicatorTable setHidden:YES];
  } error:^(NSString *error){
    [self.refreshControl endRefreshing];
    [NSUtils showMessage:error withTitle:APP_NAME];
    [self.viewIndicatorTable setHidden:YES];
  }];
  
  [weakSelf.tableView.pullToRefreshView stopAnimating];
}

#pragma mark - UITableViewDelegate Methods
- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
  return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
  return self.arrayTableViewData.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
  StandardDetailTableViewCell *cell = (StandardDetailTableViewCell *)[tableView dequeueReusableCellWithIdentifier:CellIdentifier];
  if (!cell) {
    cell = [[StandardDetailTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
  }
  [cell setRightUtilityButtons:[self rightButtons] WithButtonWidth:PHR_TABLE_VIEW_DELETE_BUTTON_HEIGHT];
  cell.delegate = self;
  
  UIColor *color;
  if (indexPath.row >= palleteColor.count) {
    color = [palleteColor lastObject];
  } else {
    color = [palleteColor objectAtIndex:indexPath.row];
  }
  [cell setupUIFood:self.arrayTableViewData[indexPath.row] type:self.typeIndex color:color];
  cell.selectionStyle = UITableViewCellSelectionStyleNone;
  return cell;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
  return PHR_TABLE_VIEW_ITEM_HEIGHT;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
  FoodItem *model;
  model = [self.arrayTableViewData objectAtIndex:indexPath.row];
  [self openDetail:model];
}

- (void) openDetail:(FoodItem*) foodItem {
  StandardFoodAddViewController *viewController = [[StandardFoodAddViewController alloc] initWithNibName:NSStringFromClass([StandardFoodAddViewController class]) bundle:nil];
  viewController.addContentType = self.typeIndex;
  if (foodItem.foodID && foodItem.foodID != [NSNull class] ) {
    viewController.modelID = foodItem.foodID;
  } else {
    viewController.foodItem = foodItem;
  }
  [viewController setAddCallBack:^(FoodType selectedType) {
    [self refreshAllView];
  }];
  viewController.modalTransitionStyle =  UIModalTransitionStyleCoverVertical;
  viewController.imageBackground = [UIUtils screenshot:self.view ];
  
  [self.navigationController presentViewController:viewController animated:YES completion:nil];
}

- (NSArray *)rightButtons {
  NSMutableArray *rightUtilityButtons = [NSMutableArray new];
  [rightUtilityButtons sw_addUtilityButtonWithColor:
   [UIColor redColor] icon:[UIImage imageNamed:@"icon-trash-white"]];
  
  return rightUtilityButtons;
}

- (void)swipeableTableViewCell:(SWTableViewCell *)cell didTriggerRightUtilityButtonWithIndex:(NSInteger)index {
  
  NSIndexPath *cellIndexPath = [self.tableView indexPathForCell:cell];
  FoodItem *model = [self.arrayTableViewData objectAtIndex:cellIndexPath.row];
  NSString *foodID = model.foodID;
  
  [PHRAppDelegate showLoading];
  [[PHRClient instance] requestDeleteStandardFood:foodID foodType:[NSString stringWithFormat:@"0%d", (int)self.typeIndex + 1] andCompleted:^(id response){
    [PHRAppDelegate hideLoading];
    if (response) {
      [self.arrayTableViewData removeObjectAtIndex:cellIndexPath.row];
      [self.tableView reloadData];
      [self requestGetChartData];
      [self calculateSummary];
    }
  } error:^(NSString *error){
    [PHRAppDelegate hideLoading];
    [NSUtils showAlertWithTitle:[NSString stringWithFormat:@"%@", error.description] message:kLocalizedString(kTitleAlertError)];
  }];
  
}

- (BOOL)swipeableTableViewCell:(SWTableViewCell *)cell canSwipeToState:(SWCellState)state {
  if (self.arrayTableViewData.count == 0){
    return NO;
  }
  NSIndexPath *cellIndexPath = [self.tableView indexPathForCell:cell];
  FoodItem *model = [self.arrayTableViewData objectAtIndex:cellIndexPath.row];
  NSString *foodID = model.foodID;
  switch (state) {
    case kCellStateLeft:
      return NO;
    case kCellStateRight:
      if ([PHRAppStatus checkCurrentStandardActive] && foodID && foodID != [NSNull class]) {
        return YES;
      }
      return NO;
    default:
      break;
  }
  return YES;
}

#pragma mark - TopMenuDelegate
- (void)scrollViewDidEndDecelerating:(UIScrollView *)scrollView{
  
  //    NSInteger page = f_OffsetX/self.view.frame.size.width;
  //    [self.TopMenuView setScrollPage:page];
}


-(void)selectTopMenu:(NSInteger)tagId{
  isDataLoaded = NO;
  self.typeIndex = tagId;
  self.chartView.chartType = [PHRChartUtils getChartType:StandardHomeTypeFood andIndex:self.typeIndex];
  [self.chartView doCustomize];
  [self.chartView setBackgroundColor:[UIColor clearColor]];
  [self refreshAllView];
}

- (void)loadChartWithSorted{
  // SORT DATA
  [self.arrayChartData sortUsingComparator:^NSComparisonResult(PHRSample *obj1, PHRSample *obj2){
    return [obj1.record_date compare:obj2.record_date];
  }];
  [self loadDataChart];
}

- (void)pullToRefreshData {
  [self resetTableData];
  [self requestGetTimeLine];
}

- (void)resetTableData{
  isDataLoaded = NO;
  numberPage = 1;
  if (self.arrayTableViewData.count > 0) {
    [self.arrayTableViewData removeAllObjects];
  }
  [self.tableView reloadData];
}

- (IBAction)onBtnAddClicked:(id)sender {
  if (PHRAppDelegate.isReadingHealthKit == YES) {
    [NSUtils showMessage:kLocalizedString(kAlertSysHealthKit) withTitle:kLocalizedString(kAlert)];
  }else{
    StandardFoodAddViewController *controller = [[StandardFoodAddViewController alloc] initWithNibName:NSStringFromClass([StandardFoodAddViewController class]) bundle:nil];
    controller.addContentType = (FoodType)self.typeIndex;
    controller.modalTransitionStyle =  UIModalTransitionStyleCoverVertical;
    controller.imageBackground = [UIUtils screenshot:self.view ];
  
    if (self.arrayTableViewData.count > 0){
      if (self.typeIndex == FoodTypeCalories) {
        controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].calories floatValue];
      } else if (self.typeIndex == FoodTypeCarbohydrates) {
        controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].carbohydrates floatValue];
      } else if (self.typeIndex == FoodTypeTotalFat) {
        controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].totalFat floatValue];
      }
    } else {
      controller.defaultValue = [NSUtils getStandardValue:NO masterDataType:[PHRChartUtils getChartType:StandardHomeTypeFood andIndex:self.typeIndex]];
  }
  
  [controller setAddCallBack:^(FoodType selectedType){
    [self.tabbarType setScrollPage:selectedType];
    //[self refreshAllView];
  }];
  [self.navigationController presentViewController:controller animated:YES completion:nil];
  }
}

- (NSMutableAttributedString*)setColorAverageLabel:(NSString*)value withUnit:(NSString*)unit andColor:(UIColor*)color font:(UIFont*)font {
  NSMutableAttributedString *coloredText = [[NSMutableAttributedString alloc] initWithString:[NSString stringWithFormat:@"%@ %@",value, unit]];
  [coloredText addAttribute: NSForegroundColorAttributeName value:color range:NSMakeRange(0, value.length)];
  [coloredText addAttribute: NSFontAttributeName value:font range:NSMakeRange(0, value.length)];
  return coloredText;
}

- (void)refreshAllView {
  [self requestGetChartData];
  [self resetTableData];
  [self requestGetTimeLine];
}

@end
