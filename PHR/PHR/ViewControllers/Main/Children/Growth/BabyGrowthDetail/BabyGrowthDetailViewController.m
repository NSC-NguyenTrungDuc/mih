//
//  BabyGrowthDetailViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BabyGrowthDetailViewController.h"
#import "TriangleView.h"
#import "ChildrenDashboardViewController.h"

@interface BabyGrowthDetailViewController () {
    ButtonTimeIntervalClick durationType;
    BOOL isDataLoaded;
    int numberPage;
    NSArray *palleteColor;
    MasterDataModel *masterDataModel;
    NSURLSessionDataTask *taskGetTimeLine;
    NSURLSessionDataTask *taskGetChartData;
    BOOL isShowDialog;
}

@end

@implementation BabyGrowthDetailViewController
 static NSString *CellIdentifier = @"TableViewCellIdentifier";
- (void)viewDidLoad {
    [super viewDidLoad];
    [self initData];
    [self initView];
//    [self.tabbarType setScrollPage:self.typeIndex];
//    [self requestGetChartData];
//    [self requestGetTimeLine];
    
}

#pragma mark - Handle notify data Healthkit/bluetooth
- (void)handleBluetoothData:(NSNotification*)notification{
    PHRSample *sample = [(PHRSample*)notification.object copy];
    if (sample && [sample.type isEqualToString:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:PHRBabyGroupTypeGrowth]]) {
        [self.chartView showIndicator];
        [self addNewSample:sample isLoadData:NO];
    }
}

- (void)addNewSample:(PHRSample*)sample isLoadData:(BOOL)isLoadData{
    [PHRChartUtils calculateAverage:self.arrayChartData andSample:sample duration:durationType];
    if (isLoadData) {
        [self loadChartWithSorted];
    }
    // add to list
    BabyGrowth *item = [[BabyGrowth alloc] initFromSample:sample];
    [self.arrayTableViewData insertObject:item atIndex:0];
    [self.tableView reloadData];
    [self calculateSummary];
}

- (void)initData {
    numberPage = 1;
    self.arrayChartData = [[NSMutableArray alloc] init];
    self.arrayTableViewData = [[NSMutableArray alloc] init];
    masterDataModel = [[MasterDataModel alloc] init];
    palleteColor = @[[PHR_COLOR_BABY_GROWTH_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_BABY_GROWTH_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_BABY_GROWTH_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_BABY_GROWTH_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_BABY_GROWTH_MAIN_COLOR colorWithAlphaComponent:1]];
}

- (void)initView {
    [self.view setBackgroundColor:[UIColor clearColor]];
//    [self setupNavigationBarTitle:kLocalizedString(kBabyTitleGrowth) iconLeft:@"Icon_Person" iconRight:@"Icon_Family" iconMiddle:@"Icon_Baby_Growth" isDismissView:false colorLeft:[PHR_COLOR_BABY_GROWTH_LIGHT_ALPHA colorWithAlphaComponent:0.5] colorRight:[PHR_COLOR_BABY_GROWTH_OVERLAY colorWithAlphaComponent:0.5]];
    [self checkProfileToShowView];
    [self initTabbarDuration];
    [self initChart];
    [self initTriangleView];
    [self initTabbarType];
    [self calculateSummary];
    [self initTableView];
    [self.viewAdd setBackgroundColor:PHR_COLOR_BABY_GROWTH_MAIN_COLOR];
    self.labelAdd.text = kLocalizedString(kAdd);
}


- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
     //[self setImageToBackgroundBaby:self.imageBackground];
    
     [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyProfileBabyActiveChanged object:nil];
     [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyBluetoothData object:nil];
     [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyBlueDisconnectDevice object:nil];
    
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleProfileActiveChanged:) name:kNotifyProfileBabyActiveChanged object:nil];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleBluetoothData:) name:kNotifyBluetoothData object:nil];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(loadChartWithSorted) name:kNotifyBlueDisconnectDevice object:nil];
    
    //Master Data
    if (self.typeIndex == BodyMeasurementTypeHeight || self.typeIndex == BodyMeasurementTypeWeight) {
        CGPoint meanAndSD = [NSUtils getMeanAndSdValue:YES masterDataType:[PHRChartUtils getChartType:StandardHomeTypeBodyMeasurement andIndex:self.typeIndex]];
        masterDataModel.mean = meanAndSD.x;
        masterDataModel.sd = meanAndSD.y;
    }
}

- (void)viewWillDisappear:(BOOL)animated {
    [super viewWillDisappear:animated];
//    NSArray *viewControllers = self.navigationController.viewControllers;
//    if ([viewControllers indexOfObject:self] == NSNotFound) {
//        [[NSNotificationCenter defaultCenter] removeObserver:self];
//    }
}

- (void)removeObserve {
    [[NSNotificationCenter defaultCenter] removeObserver:self];
}

- (void)initTabbarDuration {
    self.tabbarDuration.delegate = self;
    [self.tabbarDuration initContentWhiteTransperent:nil colorSelected:[UIColor whiteColor] andUnselectedColor:[[UIColor whiteColor] colorWithAlphaComponent:0.6] textFont:[FontUtils aileronRegularWithSize:12.0] selectedFont:[FontUtils aileronRegularWithSize:12.0]];
    durationType = ButtonTimeIntervalWeekly;
    self.tabbarDuration.selectedIndex = durationType;
}

- (void)initTabbarType {
    NSDictionary *typeHeight = @{PHR_TYPE_IDENTIFIER : kLocalizedString(kHeightUppercase) };
    NSDictionary *typeWeight = @{ PHR_TYPE_IDENTIFIER : kLocalizedString(kWeightUppercase)};
    NSArray* arr = @[typeHeight,typeWeight];
    self.tabbarType.topMenuDelegate = self;
    self.tabbarType.backgroundColor = PHR_COLOR_BABY_GROWTH_OVERLAY;
    [self.tabbarType calcurateWidth:arr];
}

- (void)initTriangleView {
    float triangleWidth = 12;
    float triangleHeight = 8;
    TriangleView *triangle = [[TriangleView alloc] initWithFrame:CGRectMake([UIScreen mainScreen].bounds.size.width / 2 - triangleWidth / 2 , 0, triangleWidth, triangleHeight)];
    [triangle setBackgroundColor:[UIColor clearColor]];
    triangle.arrayRGB = [NSArray arrayWithObjects:@"88",@"115", @"91", nil];
    [self.viewTriangle addSubview:triangle];
}

- (void)initChart{
    [self.chartView initializeChart:self];
    [self.chartView setShowAvarage:YES];
    [self.chartView setIsShowGradient:YES andIsDetailChart:YES];
    [self.chartView setLineChartColor:[UIColor whiteColor] andFillBallColor:[[UIColor blackColor] colorWithAlphaComponent:0.5]];
    [self.chartView setChartBackgroundColor:[UIColor clearColor]];
    self.chartView.chartType = [PHRChartUtils getChartType:PHRBabyGroupTypeGrowth andIndex:self.typeIndex];
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
        if (self.typeIndex == 0) {
            [self.navigationController popViewControllerAnimated:YES];
        }  else if (self.typeIndex > 0) {
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
    if (self.typeIndex == BabyGrowthHeight) {
        for (BabyGrowth *model in self.arrayTableViewData) {
            value += [model.height doubleValue];
        }
        if (self.arrayTableViewData.count > 0) {
            value /= self.arrayTableViewData.count;
        }
        [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.1f",value] withUnit:kLocalizedString(kUnitCm) andColor:PHR_COLOR_BABY_GROWTH_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
    } else if (self.typeIndex == BabyGrowthWeight) {
        for (BabyGrowth *model in self.arrayTableViewData) {
            value += [model.weight doubleValue];
        }
        if (self.arrayTableViewData.count > 0) {
            value /= self.arrayTableViewData.count;
        }
        [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.2f",value] withUnit:kLocalizedString(kUnitKg) andColor:PHR_COLOR_BABY_GROWTH_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
    }
    [self.labelSummary setText:kLocalizedString(kTitleAverage)];
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
    if (tabBar.tag == MDTabBarTagTypeFourButtonNoBorder) {
        durationType = selectedIndex;
        [self.chartView setDuration:durationType];
        [self requestGetChartData];
    }
}


- (void)requestGetChartData {
    
    NSString* duration = [NSString stringWithFormat:@"%ld",durationType + 1];
    [self.arrayChartData removeAllObjects];
    [self loadDataChart];
    if (!PHRAppStatus.currentBaby) {
      return;
    }
    if (taskGetChartData){
        [taskGetChartData cancel];
    }
  [self.viewIndicatorChart setHidden:NO];
    taskGetChartData = [[PHRClient instance] requestGetListBabyGrowthWithDuration:duration growthType:self.typeIndex andProfileID:PHRAppStatus.currentBaby.profileId completed:^(id response){
        if (response) {
            NSArray *arrayResult = nil;
            
            if(self.typeIndex == BabyGrowthHeight){
                arrayResult = [response[KEY_Content] objectForKey:KEY_Height_Info];
            } else if (self.typeIndex == BabyGrowthWeight) {
                arrayResult = [response[KEY_Content] objectForKey:KEY_Weight_Info];
            }
            
            if (arrayResult != nil && arrayResult != (id)[NSNull null] && [arrayResult count] > 0) {
                for (int i = 0; i < arrayResult.count; i++) {

                    PHRSample *sample = [BabyGrowth sampleFromDict:arrayResult[i] type:(BabyGrowthType)self.typeIndex];
                    [self.arrayChartData addObject:sample];
                }
            }
        }
        [self mergeDataLocalWithServer];
        [self loadChartWithSorted];
      [self.viewIndicatorChart setHidden:YES];
    }error:^(NSString *error){
        [self mergeDataLocalWithServer];
        [self loadChartWithSorted];
        if (isShowDialog) {
            [NSUtils showMessage:kLocalizedString(error) withTitle:APP_NAME];
        }
      [self.viewIndicatorChart setHidden:YES];
    }];
    
}

- (void)mergeDataLocalWithServer {
    NSArray* arrFromDatabase = [[StorageManager instance] getSamplesUnsyncForType:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:PHRBabyGroupTypeGrowth] profileId:PHRAppStatus.currentBaby.profileId];
    
    for (int i = 0; i < arrFromDatabase.count; i++) {
        PHRSample *sample = [[arrFromDatabase objectAtIndex:i] copy];
        [PHRChartUtils calculateAverage:self.arrayChartData andSample:sample duration:durationType];
    }
}

- (void)requestGetTimeLine {
    if (!PHRAppStatus.currentBaby) {
      return;
    }
    // storage
    if (!isDataLoaded) {
        isDataLoaded = YES;
        NSArray *samples = [[StorageManager instance] getSamplesUnsyncForType:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:PHRBabyGroupTypeGrowth] profileId:PHRAppStatus.currentBaby.profileId];
        for (PHRSample *sample in samples) {
            BabyGrowth *item = [[BabyGrowth alloc] initFromSample:sample];
            [self.arrayTableViewData addObject:item];
        }
    }
    if (taskGetTimeLine){
        [taskGetTimeLine cancel];
    }
    [self.viewIndicatorTable setHidden:NO];
    taskGetTimeLine = [[PHRClient instance] requestGetTimeLineBabyGrowth:PHRAppStatus.currentBaby.profileId withBabyGrowthType:self.typeIndex andPageNumber:[NSString stringWithFormat:@"%d",numberPage] completed:^(id response){
        if (response) {
            NSArray *arrayResult = [response[KEY_Content] objectForKey:KEY_Growth_Info];
            if (arrayResult != nil && arrayResult != (id)[NSNull null] && [arrayResult count] > 0) {
                for (int i = 0; i < arrayResult.count; i++) {
                    NSDictionary *dict = [arrayResult objectAtIndex:i];
                    BabyGrowth *babyGrowth = [BabyGrowth initBabyGrowthWithObj:dict];
                    [self.arrayTableViewData addObject:babyGrowth];
                }
                
                
                numberPage += 1;
            }
        }
        [self.arrayTableViewData sortUsingComparator:^NSComparisonResult(BabyGrowth *obj1, BabyGrowth *obj2){
            NSDate *date1 = [UIUtils dateFromString:obj1.dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT];
            NSDate *date2 = [UIUtils dateFromString:obj2.dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT];
            return [date2 compare:date1];
        }];
        [self.tableView reloadData];
        [self calculateSummary];
        [self.refreshControl endRefreshing];
      [self.viewIndicatorTable setHidden:YES];
    } error:^(NSString *error){
        [self calculateSummary];
        [self.refreshControl endRefreshing];
        if (isShowDialog) {
            [NSUtils showMessage:kLocalizedString(error) withTitle:APP_NAME];
        }
      [self.viewIndicatorTable setHidden:YES];
    }];
    
    [self.tableView.pullToRefreshView stopAnimating];
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
    [cell setupUIBabyGrowth:self.arrayTableViewData[indexPath.row] type:self.typeIndex color:color masterModel:masterDataModel];
    cell.selectionStyle = UITableViewCellSelectionStyleNone;
    return cell;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    return PHR_TABLE_VIEW_ITEM_HEIGHT;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    BabyGrowth *model;
    model = [self.arrayTableViewData objectAtIndex:indexPath.row];
    [self openDetail:model];
}

- (void) openDetail:(BabyGrowth*) growthItem {
    BabyGrowthAddViewController *viewController = [[BabyGrowthAddViewController alloc] initWithNibName:NSStringFromClass([BabyGrowthAddViewController class]) bundle:nil];
    viewController.addContentType = self.typeIndex;
    if (growthItem.growthId && growthItem.growthId != [NSNull class] ) {
        viewController.modelID = growthItem.growthId;
    } else {
        viewController.model = growthItem;
    }
    [viewController setAddCallBack:^(BabyGrowthType selectedType) {
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
    BabyGrowth *model = [self.arrayTableViewData objectAtIndex:cellIndexPath.row];
    NSString *babyGrowthID = model.growthId;
    
    [PHRAppDelegate showLoading];
    [[PHRClient instance] requestDeleteBabyGrowth:babyGrowthID babyGrowthType:[NSString stringWithFormat:@"0%ld",self.typeIndex + 1] andCompleted:^(id response){
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

- (BOOL)swipeableTableViewCell:(SWTableViewCell *)cell canSwipeToState:(SWCellState)state{
    NSIndexPath *cellIndexPath = [self.tableView indexPathForCell:cell];
    if (self.arrayTableViewData.count == 0){
        return NO;
    }
    BabyGrowth *model = [self.arrayTableViewData objectAtIndex:cellIndexPath.row];
    NSString *growthID = model.growthId;
    switch (state) {
        case kCellStateLeft:
            return NO;
        case kCellStateRight:
            if ([PHRAppStatus checkCurrentBabyActive] && growthID && growthID != [NSNull class]) {
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


- (void)selectTopMenu:(NSInteger)tagId{
    isDataLoaded = NO;
    self.typeIndex = tagId;
    self.chartView.chartType = [PHRChartUtils getChartType:PHRBabyGroupTypeGrowth andIndex:self.typeIndex];
    [self.chartView doCustomize];
    [self.chartView setBackgroundColor:[UIColor clearColor]];
    [self refreshAllView];
}

- (void)loadChartWithSorted{
    [self.chartView hideIndicator];
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
    BabyGrowthAddViewController *controller = [[BabyGrowthAddViewController alloc] initWithNibName:NSStringFromClass([BabyGrowthAddViewController class]) bundle:nil];
    controller.addContentType = (BabyGrowthType)self.typeIndex;
    controller.modalTransitionStyle =  UIModalTransitionStyleCoverVertical;
    
    if (self.arrayTableViewData.count > 0){
        if (self.typeIndex == BabyGrowthHeight) {
            controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].height floatValue];
        } else if (self.typeIndex == BabyGrowthWeight) {
            controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].weight floatValue];
        }
    } else {
        controller.defaultValue = [NSUtils getStandardValue:YES masterDataType:[PHRChartUtils getChartType:PHRBabyGroupTypeGrowth andIndex:self.typeIndex]];
    }
    
    [controller setAddCallBack:^(BabyGrowthType selectedType){
        [self.tabbarType setScrollPage:selectedType];
        //[self refreshAllView];
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
    [self requestGetChartData];
    [self requestGetTimeLine];
}

- (void)setIsShowDialog:(BOOL)isShow {
    isShowDialog = isShow;
}

@end
