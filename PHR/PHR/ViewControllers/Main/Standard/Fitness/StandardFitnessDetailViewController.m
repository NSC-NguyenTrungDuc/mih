//
//  StandardFitnessDetailViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "StandardFitnessDetailViewController.h"
#import "TriangleView.h"

@interface StandardFitnessDetailViewController () {
    ButtonTimeIntervalClick durationType;
    BOOL isDataLoaded;
    int numberPage;
    NSArray *palleteColor;
    MasterDataModel *masterDataModel;
    NSURLSessionDataTask *taskGetTimeLine;
    NSURLSessionDataTask *taskGetChartData;
}

@end

@implementation StandardFitnessDetailViewController
static NSString *CellIdentifier = @"TableViewCellIdentifier";
- (void)viewDidLoad {
    [super viewDidLoad];
    [self initData];
    [self initView];
    [self requestGetChartData];
    [self requestGetTimeLine];
    
}

- (void)initData {
    numberPage = 1;
    self.arrayChartFitnessData = [[NSMutableArray alloc] init];
    self.arrayTableViewData = [[NSMutableArray alloc] init];
    masterDataModel = [[MasterDataModel alloc] init];
    palleteColor = @[[PHR_COLOR_FITNESS_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_FITNESS_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_FITNESS_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_FITNESS_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_FITNESS_MAIN_COLOR colorWithAlphaComponent:1]];
}

- (void)initView {
    [self.view setBackgroundColor:[UIColor whiteColor]];
    [self.viewAdd setBackgroundColor:PHR_COLOR_FITNESS_MAIN_COLOR];
    [self setupNavigationBarTitle:kLocalizedString(kTitleFitness) iconLeft:@"Icon_Person" iconRight:@"Icon_Family" iconMiddle:@"Icon_Feet" isDismissView:false colorLeft:PHR_COLOR_NAV_LEFT colorRight:PHR_COLOR_NAV_RIGHT];
    [self.labelAdd setText:kLocalizedString(kAdd)];
    [self checkProfileToShowView];
    [self initTabbarDuration];
    [self initChart];
    [self initTriangleView];
    [self initTabbarType];
    [self calculateSummary];
    [self initTableView];
}


- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    [self setImageToBackgroundStandard:self.imageBackground];
    [self getMasterDataModel];
    
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

- (void)getMasterDataModel {
    if (self.typeIndex == ChartFitnessTypeSteps) {
        CGPoint meanAndSD = [NSUtils getMeanAndSdValue:NO masterDataType:[PHRChartUtils getChartType:StandardHomeTypeFitness andIndex:self.typeIndex]];
        masterDataModel.mean = meanAndSD.x;
        masterDataModel.sd = meanAndSD.y;
    }
}

- (void)initTabbarDuration {
    self.tabbarDuration.delegate = self;
    [self.tabbarDuration initContentWhiteTransperent:nil colorSelected:[UIColor whiteColor] andUnselectedColor:[[UIColor whiteColor] colorWithAlphaComponent:0.6] textFont:[FontUtils aileronRegularWithSize:12.0] selectedFont:[FontUtils aileronRegularWithSize:12.0]];
    durationType = ButtonTimeIntervalWeekly;
    self.tabbarDuration.selectedIndex = durationType;
}

- (void)initTabbarType {
    NSDictionary *typeStepCount = @{PHR_TYPE_IDENTIFIER : kLocalizedString(kChartStepCountLowCase) };
    NSDictionary *typeWalkingRunningDistance = @{ PHR_TYPE_IDENTIFIER : kLocalizedString(kChartWalkingRunDistanceLowCase)};
    NSArray* arr = @[typeStepCount,typeWalkingRunningDistance];
    self.tabbarType.topMenuDelegate = self;
    self.tabbarType.backgroundColor = PHR_COLOR_BODY_MEASUREMENT_TABBAR_TYPE;
    [self.tabbarType calcurateWidth:arr];
}

- (void)initTriangleView {
    float triangleWidth = 12;
    float triangleHeight = 8;
    TriangleView *triangle = [[TriangleView alloc] initWithFrame:CGRectMake([UIScreen mainScreen].bounds.size.width / 2 - triangleWidth / 2 , 0, triangleWidth, triangleHeight)];
    [triangle setBackgroundColor:[UIColor clearColor]];
    triangle.arrayRGB = [NSArray arrayWithObjects:@"119",@"76", @"88", nil];
    [self.viewTriangle addSubview:triangle];
}

- (void)initChart{
    [self.chartView initializeChart:self];
    [self.chartView setShowAvarage:YES];
    [self.chartView setIsShowGradient:YES andIsDetailChart:YES];
    [self.chartView setLineChartColor:[UIColor whiteColor] andFillBallColor:[[UIColor blackColor] colorWithAlphaComponent:0.5]];
    
    [self.chartView setChartBackgroundColor:[UIColor clearColor]];
    self.chartView.chartType = [PHRChartUtils getChartType:StandardHomeTypeFitness andIndex:self.typeIndex];
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
    if (self.typeIndex == ChartFitnessTypeSteps) {
        for (FitnessModel *model in self.arrayTableViewData) {
            value += [model.step doubleValue];
        }
        [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.0f",value] withUnit:kLocalizedString(kSteps) andColor:PHR_COLOR_FITNESS_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
    } else if (self.typeIndex == ChartFitnessTypeWalkRun) {
        for (FitnessModel *model in self.arrayTableViewData) {
            value += [model.walkrun doubleValue];
        }
        [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.2f",value] withUnit:kLocalizedString(kUnitKm) andColor:PHR_COLOR_FITNESS_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
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
    [self.chartView setData:self.arrayChartFitnessData];
    [self.chartView updateChartData];
}

- (void)handleProfileActiveChanged:(NSNotification*)notification{
    [self checkProfileToShowView];
    [self refreshAllView];
}

- (void)checkProfileToShowView {
    if (![PHRAppStatus checkCurrentStandardActive]) {
        [self.viewAdd setHidden:YES];
        self.constraintTableAndAdd.constant = 0 - self.viewAdd.bounds.size.height;
    } else {
        [self.viewAdd setHidden:NO];
        self.constraintTableAndAdd.constant = 0;
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
    [self.arrayChartFitnessData removeAllObjects];
    [self loadDataChart];
    
    if (taskGetChartData){
        [taskGetChartData cancel];
    }
  [self.viewIndicatorChart setHidden:NO];
    // server data
    taskGetChartData = [[PHRClient instance] requestGetListFitnessWithDuration:duration fitnessType:self.typeIndex andProfileID:PHRAppStatus.currentStandard.profileId completed:^(id response){
        if (response) {
            NSArray *arrayResult = nil;
            
            if(self.typeIndex == ChartFitnessTypeSteps){
                arrayResult = [response[KEY_Content] objectForKey:KEY_Step_Info];
            } else if (self.typeIndex == ChartFitnessTypeWalkRun) {
                arrayResult = [response[KEY_Content] objectForKey:KEY_WalkRun_Info];
            }
            
            if (arrayResult != nil && arrayResult != (id)[NSNull null] && [arrayResult count] > 0) {
                for (int i = 0; i < arrayResult.count; i++) {
                    PHRSample *sample = [FitnessModel sampleFromDict:arrayResult[i] type:self.typeIndex];
                    [self.arrayChartFitnessData addObject:sample];
                }
            }
        }
        
        [self mergeDataLocalWithServer];
        [self loadChartWithSorted];
      [self.viewIndicatorChart setHidden:YES];
    }error:^(NSString *error){
        [self mergeDataLocalWithServer];
        [self loadChartWithSorted];
        [self.viewIndicatorChart setHidden:YES];
        [NSUtils showMessage:error withTitle:APP_NAME];
    }];
    
}

- (void)mergeDataLocalWithServer {
    NSArray* arrFromDatabase = [[StorageManager instance] getSamplesUnsyncForType:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeFitness] profileId:PHRAppStatus.currentStandard.profileId];
    
    for (int i = 0; i < arrFromDatabase.count; i++) {
        PHRSample *sample = [[arrFromDatabase objectAtIndex:i] copy];
        [PHRChartUtils calculateSum:self.arrayChartFitnessData andSample:sample duration:durationType];
    }
}

- (void)requestGetTimeLine {

    __weak __typeof__(self) weakSelf = self;
    
    // storage
    if (!isDataLoaded) {
        isDataLoaded = YES;
        NSArray *samples = [[StorageManager instance] getSamplesUnsyncForType:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeFitness] profileId:PHRAppStatus.currentStandard.profileId];
        for (PHRSample *sample in samples) {
            FitnessModel *item = [[FitnessModel alloc] initFromSample:sample];
            [self.arrayTableViewData addObject:item];
        }
    }
    
    if (taskGetTimeLine){
        [taskGetTimeLine cancel];
    }

    [self.viewIndicatorTable setHidden:NO];
    taskGetTimeLine = [[PHRClient instance] requestGetTimeLineFitness:PHRAppStatus.currentStandard.profileId withFitnessType:self.typeIndex andPageNumber:[NSString stringWithFormat:@"%d",numberPage] completed:^(id response){
        if (response) {
            NSArray *arrayResult = [response[KEY_Content] objectForKey:KEY_Fitness_Data];
            if (arrayResult && arrayResult != (id)[NSNull null] && [arrayResult count] > 0) {
                for (int i = 0; i < arrayResult.count; i++) {
                    NSDictionary *dict = [arrayResult objectAtIndex:i];
                    FitnessModel *fitnessModel = [FitnessModel initWithObj:dict];
                    [self.arrayTableViewData addObject:fitnessModel];
                }
                numberPage += 1;
            }
        }
        // SORT BY DATETIME
         NSSortDescriptor *descriptor = [NSSortDescriptor sortDescriptorWithKey:@"date"
                                                                     ascending:NO];
        [self.arrayTableViewData sortUsingDescriptors:[NSArray arrayWithObject:descriptor]];
      
//        [self.arrayTableViewData sortUsingComparator:^NSComparisonResult(BodyMeasurementModel *obj1, BodyMeasurementModel *obj2){
//            NSDate *date1 = [UIUtils dateFromString:obj1.date withFormat:PHR_SERVER_DATE_TIME_FORMAT];
//            NSDate *date2 = [UIUtils dateFromString:obj2.date withFormat:PHR_SERVER_DATE_TIME_FORMAT];
//            return [date2 compare:date1];
//        }];
      
        [self.tableView reloadData];
        [self.refreshControl endRefreshing];
        [self calculateSummary];
      [self.viewIndicatorTable setHidden:YES];
    } error:^(NSString *error){
        [self.refreshControl endRefreshing];
        [NSUtils showMessage:error withTitle:APP_NAME];
      [self.viewIndicatorTable setHidden:YES];
    }];
                   // });
    [weakSelf.tableView.pullToRefreshView stopAnimating];
}

- (void)handleBluetoothData:(NSNotification*)notification{
    PHRSample *sample = [(PHRSample*)notification.object copy];
    if (sample && [sample.type isEqualToString:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeFitness]]) {
        [self addNewSample:sample isLoadData:NO];
    }
}

- (void)handleHealthKitData:(NSNotification*)notification{
    PHRSample *sample = [(PHRSample*)notification.object copy];
    if (sample && [sample.type isEqualToString:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeFitness]]) {
        [self addNewSample:sample isLoadData:YES];
    }
}

- (void)addNewSample:(PHRSample*)sample isLoadData:(BOOL)isLoadData{
    // Chart
    [PHRChartUtils calculateSum:self.arrayChartFitnessData andSample:sample duration:durationType];
    if (isLoadData) {
        [self loadChartWithSorted];
    }
    
    // add to list
    FitnessModel *item = [[FitnessModel alloc] initFromSample:sample];
    [self.arrayTableViewData insertObject:item atIndex:0];
    [self.tableView reloadData];
    [self calculateSummary];
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
    [cell setupUIFitness:self.arrayTableViewData[indexPath.row] type:self.typeIndex color:color masterModel:masterDataModel];
    cell.selectionStyle = UITableViewCellSelectionStyleNone;
    return cell;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    return PHR_TABLE_VIEW_ITEM_HEIGHT;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    FitnessModel *model;
    model = [self.arrayTableViewData objectAtIndex:indexPath.row];
    [self openDetail:model];
}

- (void) openDetail:(FitnessModel*) fitnessModel {
    StandardFitnessAddViewController *viewController = [[StandardFitnessAddViewController alloc] initWithNibName:NSStringFromClass([StandardFitnessAddViewController class]) bundle:nil];
    viewController.addContentType = self.typeIndex;
    if (fitnessModel.fitnessID && fitnessModel.fitnessID != [NSNull class] ) {
        viewController.modelID = fitnessModel.fitnessID;
    } else {
        viewController.model = fitnessModel;
    }
    [viewController setAddCallBack:^(ChartFitnessType selectedType) {
        [self.tabbarType setScrollPage:selectedType ];
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
    FitnessModel *model = [self.arrayTableViewData objectAtIndex:cellIndexPath.row];
    NSString *fitnessID = model.fitnessID;
    
    [PHRAppDelegate showLoading];
    [[PHRClient instance] requestDeleteStandardFitness:fitnessID fitnessType:[NSString stringWithFormat:@"0%d",(int)self.typeIndex + 1] andCompleted:^(id response){
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
    FitnessModel *model = [self.arrayTableViewData objectAtIndex:cellIndexPath.row];
    NSString *fitnessID = model.fitnessID;
    switch (state) {
        case kCellStateLeft:
            return NO;
        case kCellStateRight:
            if ([PHRAppStatus checkCurrentStandardActive] && fitnessID && fitnessID != [NSNull class]) {
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
    self.chartView.chartType = [PHRChartUtils getChartType:StandardHomeTypeFitness andIndex:self.typeIndex];
    [self.chartView setDuration:durationType];
    [self.chartView doCustomize];
    [self.chartView setBackgroundColor:[UIColor clearColor]];
    [self getMasterDataModel];
    [self refreshAllView];
}

- (void)loadChartWithSorted{
    // SORT DATA
    [self.arrayChartFitnessData sortUsingComparator:^NSComparisonResult(PHRSample *obj1, PHRSample *obj2){
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
    StandardFitnessAddViewController *controller = [[StandardFitnessAddViewController alloc] initWithNibName:NSStringFromClass([StandardFitnessAddViewController class]) bundle:nil];
    controller.addContentType = (ChartFitnessType)self.typeIndex;
    controller.modalTransitionStyle =  UIModalTransitionStyleCoverVertical;
    controller.imageBackground = [UIUtils screenshot:self.view ];
    
    if (self.arrayTableViewData.count > 0){
        if (self.typeIndex == ChartFitnessTypeSteps) {
            controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].step floatValue];
        } else if (self.typeIndex == ChartFitnessTypeWalkRun) {
            controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].walkrun floatValue];
        }
    } else {
        controller.defaultValue = [NSUtils getStandardValue:NO masterDataType:[PHRChartUtils getChartType:StandardHomeTypeFitness andIndex:self.typeIndex]];
    }
    
    [controller setAddCallBack:^(ChartFitnessType selectedType){
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
