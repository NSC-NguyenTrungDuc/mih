//
//  BabyMilkViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BabyMilkViewController.h"
#import "TriangleView.h"
#import "BabyMilkAddViewController.h"

#define BABY_MOTHER_MILK_METHOD     @"0"
#define BABY_BOTTLE_MILK_METHOD     @"1"

@interface BabyMilkViewController () {
  ButtonTimeIntervalClick durationType;
  BOOL isDataLoaded;
  int numberPage;
  NSArray *palleteColor;
  NSURLSessionDataTask *taskGetTimeLine;
  BOOL isShowDialog;
}

@property (strong, nonatomic) NSDictionary *contentMilk;

@end

@implementation BabyMilkViewController
static NSString *CellIdentifier = @"TableViewCellIdentifier";
- (void)viewDidLoad {
  [super viewDidLoad];
  [self initData];
  [self initView];
  // [self getListbabyMilkFromServer];
}

#pragma mark - Handle notify data Healthkit/bluetooth

- (void)initData {
  numberPage = 1;
  self.arrayChartMotherData = [[NSMutableArray alloc] init];
  self.arrayChartBottleData = [[NSMutableArray alloc] init];
  self.arrayMotherData = [[NSMutableArray alloc] init];
  self.arrayBottleData = [[NSMutableArray alloc] init];
  palleteColor = @[[PHR_COLOR_BABY_MILK_MAIN_COLOR colorWithAlphaComponent:1],
                   [PHR_COLOR_BABY_MILK_MAIN_COLOR colorWithAlphaComponent:0.8],
                   [PHR_COLOR_BABY_MILK_MAIN_COLOR colorWithAlphaComponent:0.7],
                   [PHR_COLOR_BABY_MILK_MAIN_COLOR colorWithAlphaComponent:0.6],
                   [PHR_COLOR_BABY_MILK_MAIN_COLOR colorWithAlphaComponent:0.5]];
}

- (void)initView {
  [self.view setBackgroundColor:[UIColor clearColor]];
  //    [self setupNavigationBarTitle:kLocalizedString(kTitleMilk) iconLeft:@"Icon_Person" iconRight:@"Icon_Family" iconMiddle:@"Icon_Baby_Milk_Header" isDismissView:false colorLeft:PHR_COLOR_BABY_MILK_LIGHT_ALPHA colorRight:PHR_COLOR_BABY_MILK_OVERLAY];
  
  [self checkProfileToShowView];
  [self initTabbarDuration];
  [self initChart];
  [self initTriangleView];
  [self initTabbarType];
  [self calculateSummary];
  [self initTableView];
  [self.viewAdd setBackgroundColor:PHR_COLOR_BABY_MILK_MAIN_COLOR];
  [self.labelAdd setText:kLocalizedString(kAdd)];
}

- (void)viewWillAppear:(BOOL)animated {
  [super viewWillAppear:animated];
  //[self setImageToBackgroundBaby:self.imageBackground];
  [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyProfileBabyActiveChanged object:nil];
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleProfileActiveChanged:) name:kNotifyProfileBabyActiveChanged object:nil];
}

- (void)removeObserve {
  [[NSNotificationCenter defaultCenter] removeObserver:self];
}

- (void)initTabbarDuration {
  self.tabbarDuration.delegate = self;
  [self.tabbarDuration initContentWhiteTransperent:nil colorSelected:[UIColor whiteColor] andUnselectedColor:PHR_COLOR_TABBAR_DURATION_UNSELECTED textFont:[FontUtils aileronRegularWithSize:12.0] selectedFont:[FontUtils aileronRegularWithSize:12.0]];
  durationType = ButtonTimeIntervalWeekly;
  self.tabbarDuration.selectedIndex = durationType;
}

- (void)initTabbarType {
  NSDictionary *typeMotherMilk = @{PHR_TYPE_IDENTIFIER : kLocalizedString(kTitleMotherMilk)};
  NSDictionary *typeBottleMilk = @{ PHR_TYPE_IDENTIFIER : kLocalizedString(kTitleBottleMilk)};
  NSArray* arr = @[typeMotherMilk,typeBottleMilk];
  self.tabbarType.topMenuDelegate = self;
  self.tabbarType.backgroundColor = PHR_COLOR_BABY_MILK_OVERLAY;
  [self.tabbarType calcurateWidth:arr];
}

- (void)initTriangleView {
  float triangleWidth = 12;
  float triangleHeight = 8;
  TriangleView *triangle = [[TriangleView alloc] initWithFrame:CGRectMake([UIScreen mainScreen].bounds.size.width / 2 - triangleWidth / 2 , 0, triangleWidth, triangleHeight)];
  [triangle setBackgroundColor:[UIColor clearColor]];
  triangle.arrayRGB = [NSArray arrayWithObjects:@"76",@"117", @"130", nil];
  [self.viewTriangle addSubview:triangle];
}

- (void)initChart{
  [self.chartView initializeChart:self];
  [self.chartView setShowAvarage:YES];
  [self.chartView setIsShowGradient:YES andIsDetailChart:YES];
  [self.chartView setLineChartColor:[UIColor whiteColor] andFillBallColor:[[UIColor blackColor] colorWithAlphaComponent:0.5]];
  [self.chartView setChartBackgroundColor:[UIColor clearColor]];
  self.chartView.chartType = [PHRChartUtils getChartType:PHRBabyGroupTypeMilk andIndex:self.pHRGroupTypeMilk];
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
  if (sender.direction == UISwipeGestureRecognizerDirectionRight){
    if (self.pHRGroupTypeMilk > 0) {
      [self.tabbarType setScrollPage:self.pHRGroupTypeMilk - 1];
    }
  } else if (sender.direction == UISwipeGestureRecognizerDirectionLeft){
    if (self.pHRGroupTypeMilk < [self.tabbarType numberOfPages] - 1) {
      [self.tabbarType setScrollPage:self.pHRGroupTypeMilk + 1];
    }
  }
}

- (void)calculateSummary {
  double value = 0;
  if (self.pHRGroupTypeMilk == ChartBabyMilkTypeMother) {
    for (BabyMilkModel *model in self.arrayMotherData) {
      value += [model.calories doubleValue];
    }
    [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.0f",value] withUnit:kLocalizedString(kUnitCal) andColor:PHR_COLOR_BABY_MILK_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
  } else if (self.pHRGroupTypeMilk == ChartBabyMilkTypeBottle) {
    for (BabyMilkModel *model in self.arrayBottleData) {
      value += [model.calories doubleValue];
    }
    [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.2f",value] withUnit:kLocalizedString(kUnitCal) andColor:PHR_COLOR_BABY_MILK_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
  }
  [self.labelTitleSummary setText:kLocalizedString(kTotal)];
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
    [self getListbabyMilkFromServer];
  } position:SVPullToRefreshPositionBottom];
}

- (void)loadDataChart{
  if (self.pHRGroupTypeMilk == ChartBabyMilkTypeMother) {
    [self.chartView setData:self.arrayChartMotherData];
    
  } else {
    [self.chartView setData:self.arrayChartBottleData];
  }
  [self.chartView updateChartData];
}

- (void)handleProfileActiveChanged:(NSNotification*)notification{
  [self checkProfileToShowView];
  [self refreshAllView];
}

- (void)checkProfileToShowView {
  if (![PHRAppStatus checkCurrentBabyActive]) {
    [self.viewAdd setHidden:YES];
    self.constraintTblAndSave.constant = 0 - self.viewAdd.bounds.size.height;
  } else {
    [self.viewAdd setHidden:NO];
    self.constraintTblAndSave.constant = 0;
  }
}

#pragma mark - MDTABBAR delegate
- (void)tabBar:(MDTabBar *)tabBar didChangeSelectedIndex:(NSUInteger)selectedIndex {
  if ((int)selectedIndex == 0) {
    self.pHRGroupTypeMilk = PHRGroupTypeMotherMilk;
  }
  else {
    self.pHRGroupTypeMilk = PHRGroupTypeBottleMilk;
  }
  self.chartView.chartContentType = selectedIndex;
  
  [self.chartView doCustomize];
  [self.chartView setBackgroundColor:[UIColor clearColor]];
  
  [self loadDataChart];
}

- (void)getListbabyMilkFromServer {
  [self loadDataChart];
  //
  
  if (!PHRAppStatus.currentBaby) {
    return;
  }
  __weak __typeof__(self) weakSelf = self;
  if (taskGetTimeLine){
    [taskGetTimeLine cancel];
  }
  [self.viewIndicatorChart setHidden:NO];
  [self.viewIndicatorTable setHidden:NO];
  taskGetTimeLine = [[PHRClient instance] requestGetListBabyMilkWithId:PHRAppStatus.currentBaby.profileId andNumberPage:numberPage completion:^(MFRession *responseObject) {
    id content = responseObject.content;
    _contentMilk = responseObject.content;
    if ([content isKindOfClass:[NSArray class]]) {
      NSArray *result = (NSArray *)content;
      for (int i = 0; i < result.count; i++) {
        NSDictionary *dict = [result objectAtIndex:i];
        BabyMilkModel *objbabyMilk = [[BabyMilkModel alloc] initWithDictionary:dict error:nil];
        
        if ([objbabyMilk.drink_method isEqualToString:BABY_MOTHER_MILK_METHOD]) {
          [self.arrayMotherData addObject:objbabyMilk];
          [self.arrayChartMotherData addObject:[BabyMilkModel sampleFromBabyMilkModel:objbabyMilk ]];
        }
        else {
          [self.arrayBottleData addObject:objbabyMilk];
          [self.arrayChartBottleData addObject:[BabyMilkModel sampleFromBabyMilkModel:objbabyMilk ]];
        }
      }
      [self loadDataChart];
      numberPage += 1;
    }
    
    [weakSelf.tableView.pullToRefreshView stopAnimating];
    [weakSelf.tableView reloadData];
    [self calculateSummary];
    [self.viewIndicatorChart setHidden:YES];
    [self.viewIndicatorTable setHidden:YES];
  } error:^(NSString * error) {
    [weakSelf.tableView.pullToRefreshView stopAnimating];
    if (isShowDialog) {
      [NSUtils showAlertWithTitle:[NSString stringWithFormat:@"%@", error.description] message:kLocalizedString(kTitleAlertError)];
    }
    [self.viewIndicatorChart setHidden:YES];
    [self.viewIndicatorTable setHidden:YES];
  }];
  
  [self.refreshControl endRefreshing];
  [weakSelf.tableView.pullToRefreshView stopAnimating];
}


#pragma mark - UITableViewDelegate Methods
- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
  return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
  if (self.pHRGroupTypeMilk == PHRGroupTypeMotherMilk) {
    return [self.arrayMotherData count];
  }
  else if (self.pHRGroupTypeMilk == PHRGroupTypeBottleMilk) {
    return [self.arrayBottleData count];
  }
  return 0;
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
  if (self.pHRGroupTypeMilk == PHRGroupTypeMotherMilk) {
    [cell setupUIBabyMilk:self.arrayMotherData[indexPath.row] type:self.pHRGroupTypeMilk color:[palleteColor objectAtIndex:0]];
  }
  else if (self.pHRGroupTypeMilk == PHRGroupTypeBottleMilk) {
    [cell setupUIBabyMilk:self.arrayBottleData[indexPath.row] type:self.pHRGroupTypeMilk color:[palleteColor objectAtIndex:0]];
  }
  
  cell.selectionStyle = UITableViewCellSelectionStyleNone;
  return cell;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
  return PHR_TABLE_VIEW_ITEM_HEIGHT;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
  BabyMilkModel *model;
  if (self.pHRGroupTypeMilk == PHRGroupTypeMotherMilk) {
    model = [self.arrayMotherData objectAtIndex:indexPath.row];
  }
  else if (self.pHRGroupTypeMilk == PHRGroupTypeBottleMilk) {
    model = [self.arrayBottleData objectAtIndex:indexPath.row];
    
  }
  [self openDetail:model];
}

- (void) openDetail:(BabyMilkModel*) milkItem {
  BabyMilkAddViewController *viewController = [[BabyMilkAddViewController alloc] initWithNibName:NSStringFromClass([BabyMilkAddViewController class]) bundle:nil];
  viewController.isEdit = true;
  viewController.addContentType = self.pHRGroupTypeMilk;
  
  viewController.model = milkItem;
  
  [viewController setAddCallBack:^(PHRGroupTypeMilk selectedType) {
    [self refreshAllView];
  }];
  viewController.modalTransitionStyle =  UIModalTransitionStyleCoverVertical;
  
  if ([self.delegate respondsToSelector:@selector(takeScreenShot)]) {
    viewController.imageBackground = [self.delegate takeScreenShot];
  }
  if ([self.delegate respondsToSelector:@selector(presentViewControllerOnDashboard:)]) {
    [self.delegate presentViewControllerOnDashboard:viewController];
  }
}

- (NSArray *)rightButtons {
  NSMutableArray *rightUtilityButtons = [NSMutableArray new];
  [rightUtilityButtons sw_addUtilityButtonWithColor:
   [UIColor redColor] icon:[UIImage imageNamed:@"icon-trash-white"]];
  
  return rightUtilityButtons;
}

- (void)swipeableTableViewCell:(SWTableViewCell *)cell didTriggerRightUtilityButtonWithIndex:(NSInteger)index {
  
  NSIndexPath *cellIndexPath = [self.tableView indexPathForCell:cell];
  
  NSString *milkID;
  if (self.pHRGroupTypeMilk == PHRGroupTypeMotherMilk) {
    BabyMilkModel *model = [self.arrayMotherData objectAtIndex:cellIndexPath.row];
    milkID = model.id;
  } else {
    BabyMilkModel *model = [self.arrayBottleData objectAtIndex:cellIndexPath.row];
    milkID = model.id;
  }
  
  [[PHRClient instance] requestDeleteObject:PHRAppStatus.currentBaby.profileId and:milkID andMethod:API_DeleteBabyMilk completion:^(MFResponse *response) {
    if (response) {
      [self calculateSummary];
      [self refreshAllView];
    } else {
      if (isShowDialog) {
        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
      }
    }
  }];
}

- (BOOL)swipeableTableViewCell:(SWTableViewCell *)cell canSwipeToState:(SWCellState)state{
  switch (state) {
    case kCellStateLeft:
      return NO;
    case kCellStateRight:
      if ([PHRAppStatus checkCurrentBabyActive]) {
        return YES;
      }
      return NO;
    default:
      break;
  }
  return YES;
}

-(void)selectTopMenu:(NSInteger)tagId{
  isDataLoaded = NO;
  if(tagId == 0){
    self.pHRGroupTypeMilk = PHRGroupTypeMotherMilk;
  }else{
    self.pHRGroupTypeMilk = PHRGroupTypeBottleMilk;
  }
  self.chartView.chartType = [PHRChartUtils getChartType:PHRBabyGroupTypeMilk andIndex:self.pHRGroupTypeMilk];
  [self.chartView doCustomize];
  [self.chartView setBackgroundColor:[UIColor clearColor]];
  [self refreshAllView];
}

- (void)pullToRefreshData {
  [self resetTableData];
  [self getListbabyMilkFromServer];
}

- (void)resetTableData{
  isDataLoaded = NO;
  numberPage = 1;
  if (self.arrayMotherData.count > 0) {
    [self.arrayMotherData removeAllObjects];
  }
  
  if (self.arrayBottleData.count > 0) {
    [self.arrayBottleData removeAllObjects];
  }
  
  if(self.arrayChartMotherData.count > 0){
    [self.arrayChartMotherData removeAllObjects];
  }
  
  if(self.arrayChartBottleData.count > 0){
    [self.arrayChartBottleData removeAllObjects];
  }
  [self.tableView reloadData];
}

- (IBAction)onBtnAddClicked:(id)sender {
  BabyMilkAddViewController *controller = [[BabyMilkAddViewController alloc] initWithNibName:NSStringFromClass([BabyMilkAddViewController class]) bundle:nil];
  controller.addContentType = self.pHRGroupTypeMilk;
  controller.modalTransitionStyle =  UIModalTransitionStyleCoverVertical;
  
  if (self.pHRGroupTypeMilk == PHRGroupTypeMotherMilk) {
    if (self.arrayMotherData.count > 0){
      BabyMilkModel *model = [self.arrayMotherData objectAtIndex:0];
      controller.defaultValue = [model.calories floatValue];
      controller.defaultValueTime = [model.breast_time intValue];
    } else {
      controller.defaultValue = [NSUtils getStandardValue:YES masterDataType:[PHRChartUtils getChartType:PHRBabyGroupTypeMilk andIndex:0]];
    }
  } else {
    if (self.arrayBottleData.count > 0){
      BabyMilkModel *model = [self.arrayBottleData objectAtIndex:0];
      controller.defaultValue = [model.calories floatValue];
      controller.defaultValueTime = [model.breast_time intValue];
    } else {
      controller.defaultValue = [NSUtils getStandardValue:YES masterDataType:[PHRChartUtils getChartType:PHRBabyGroupTypeMilk andIndex:0]];
    }
  }
  
  [controller setAddCallBack:^(PHRGroupTypeMilk selectedType){
    [self.tabbarType setScrollPage:selectedType];
    
  }];
  if ([self.delegate respondsToSelector:@selector(takeScreenShot)]) {
    controller.imageBackground = [self.delegate takeScreenShot];
  }
  if ([self.delegate respondsToSelector:@selector(presentViewControllerOnDashboard:)]) {
    [self.delegate presentViewControllerOnDashboard:controller];
  }
}

- (NSMutableAttributedString*)setColorAverageLabel:(NSString*)value withUnit:(NSString*)unit andColor:(UIColor*)color font:(UIFont*)font {
  NSMutableAttributedString *coloredText = [[NSMutableAttributedString alloc] initWithString:[NSString stringWithFormat:@"%@ %@",value, unit]];
  [coloredText addAttribute: NSForegroundColorAttributeName value:color range:NSMakeRange(0, value.length)];
  [coloredText addAttribute: NSFontAttributeName value:font range:NSMakeRange(0, value.length)];
  return coloredText;
}

- (void)refreshAllView {
  [self resetTableData];
  [self getListbabyMilkFromServer];
}

- (void)setIsShowDialog:(BOOL)isShow {
  isShowDialog = isShow;
}

- (void)dealloc {
  [[NSNotificationCenter defaultCenter] removeObserver:self];
}

@end
