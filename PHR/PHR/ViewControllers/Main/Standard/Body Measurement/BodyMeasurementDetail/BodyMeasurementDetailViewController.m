//
//  BodyMeasurementDetailViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/15/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BodyMeasurementDetailViewController.h"

@interface BodyMeasurementDetailViewController () {
    ButtonTimeIntervalClick durationType;
    BOOL isDataLoaded;
    int numberPage;
    NSArray *palleteColor;
    MasterDataModel *masterDataModel;
    NSURLSessionDataTask *taskGetTimeLine;
    NSURLSessionDataTask *taskGetChartData;
}

@end

@implementation BodyMeasurementDetailViewController
static NSString *CellIdentifier = @"TableViewCellIdentifier";
- (void)viewDidLoad {
    [super viewDidLoad];
    [self initData];
    [self initView];
    [self requestGetChartData];
    [self requestGetTimeLine];
  
//    [self enableButton];
//  
//  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handelReadHealthkitFinish) name:@"isReadingHealthKit" object:nil];
  
}

//- (void)handelReadHealthkitFinish{
//  [self enableButton];
//}

//- (void)enableButton{
//  if (PHRAppDelegate.isReadingHealthKit == YES) {
//    [_btnAddData setEnabled:NO];
//    [self.viewAdd setBackgroundColor:PHR_COLOR_BODY_MEASUREMENT_OVERLAY];
//  }else{
//    [_btnAddData setEnabled:YES];
//    [self.viewAdd setBackgroundColor:PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR];
//  }
//}

- (void)handleBluetoothData:(NSNotification*)notification{
    PHRSample *sample = [(PHRSample*)notification.object copy];
    if (sample && [sample.type isEqualToString:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeBodyMeasurement]]) {
        [self.chartView showIndicator];
        [self addNewSample:sample isLoadData:NO];
    }
}

- (void)handleHealthKitData:(NSNotification*)notification{
    PHRSample *sample = [(PHRSample*)notification.object copy];
    if (sample && [sample.type isEqualToString:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeBodyMeasurement]]) {
        [self addNewSample:sample isLoadData:YES];
    }
}

- (void)addNewSample:(PHRSample*)sample isLoadData:(BOOL)isLoadData{
    // Chart
    [PHRChartUtils calculateAverage:self.arrayChartData andSample:sample duration:durationType];
    if (isLoadData) {
        [self loadChartWithSorted];
    }
    
    // add to list
    BodyMeasurementModel *item = [[BodyMeasurementModel alloc] initFromSample:sample];
    [self.arrayTableViewData insertObject:item atIndex:0];
    [self.tableView reloadData];
    [self calculateSummary];
}

- (void)initData {
    numberPage = 1;
    self.arrayChartData = [[NSMutableArray alloc] init];
    self.arrayTableViewData = [[NSMutableArray alloc] init];
    masterDataModel = [[MasterDataModel alloc] init];
    palleteColor = @[[PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR colorWithAlphaComponent:1]];
}

- (void)initView {
    [self.view setBackgroundColor:[UIColor whiteColor]];
    [self setupNavigationBarTitle:kLocalizedString(kTitleBodyMeasurement) iconLeft:@"Icon_Person" iconRight:@"Icon_Family" iconMiddle:@"Icon_Standand_Body" isDismissView:false colorLeft:PHR_COLOR_BODY_MEASUREMENT_NAV_LEFT colorRight:[PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR colorWithAlphaComponent:0.5]];
    [self checkProfileToShowView];
    [self initTabbarDuration];
    [self initChart];
    [self initTriangleView];
    [self initTabbarType];
    [self calculateSummary];
    [self initTableView];
    [self.viewAdd setBackgroundColor:PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR];
    [self.labelAdd setText:kLocalizedString(kAdd)];
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
    if (self.typeIndex == BodyMeasurementTypeHeight) {
        CGPoint meanAndSD = [NSUtils getMeanAndSdValue:NO masterDataType:[PHRChartUtils getChartType:StandardHomeTypeBodyMeasurement andIndex:self.typeIndex]];
        masterDataModel.mean = meanAndSD.x;
        masterDataModel.sd = meanAndSD.y;
    } else if (self.typeIndex == BodyMeasurementTypeWeight) {
        NSArray* array = [NSUtils getMeanDataForBMIAndWeight:NO masterDataType:HKQuantityTypeIdentifierBodyMass];
        masterDataModel.mean = [[array objectAtIndex:0] floatValue];
        masterDataModel.sd = [[array objectAtIndex:1] floatValue];
        masterDataModel.obesity = [[array objectAtIndex:2] floatValue];
    } else if (self.typeIndex == BodyMeasurementTypeBMI) {
        NSArray* array = [NSUtils getMeanDataForBMIAndWeight:NO masterDataType:HKQuantityTypeIdentifierBodyMassIndex];
        masterDataModel.mean = [[array objectAtIndex:0] floatValue];
        masterDataModel.sd = [[array objectAtIndex:1] floatValue];
        masterDataModel.obesity = [[array objectAtIndex:2] floatValue];
    } else {
        NSArray* array = [NSUtils getMeanDataForBodyFat:NO];
        masterDataModel.highMin = [[array objectAtIndex:0] floatValue];
        masterDataModel.normalMin = [[array objectAtIndex:1] floatValue];
        masterDataModel.normalMax = [[array objectAtIndex:2] floatValue];
        masterDataModel.highMax = [[array objectAtIndex:3] floatValue];
    }
}

- (void)initTabbarDuration {
    self.tabbarDuration.delegate = self;
    [self.tabbarDuration initContentWhiteTransperent:nil colorSelected:[UIColor whiteColor] andUnselectedColor:[[UIColor whiteColor] colorWithAlphaComponent:0.6] textFont:[FontUtils aileronRegularWithSize:12.0] selectedFont:[FontUtils aileronRegularWithSize:12.0]];
    durationType = ButtonTimeIntervalWeekly;
    self.tabbarDuration.selectedIndex = durationType;
}

- (void)initTabbarType {
    NSDictionary *typeHeight = @{PHR_TYPE_IDENTIFIER : kLocalizedString(kPHHeight)};
    NSDictionary *typeWeight = @{PHR_TYPE_IDENTIFIER : kLocalizedString(kPHWeight)};
    NSDictionary *typeBodyFat = @{PHR_TYPE_IDENTIFIER : kLocalizedString(kBodyFatPercentage)};
    NSDictionary *typeBodyMassIndex = @{PHR_TYPE_IDENTIFIER : kLocalizedString(kBodyMassIndex)};
    
    NSArray* arr = @[typeHeight,typeWeight, typeBodyFat, typeBodyMassIndex];
    self.tabbarType.topMenuDelegate = self;
    self.tabbarType.backgroundColor = PHR_COLOR_BODY_MEASUREMENT_LIGHT_ALPHA;
    [self.tabbarType calcurateWidth:arr];
}

- (void)initTriangleView {
    float triangleWidth = 12;
    float triangleHeight = 8;
    TriangleView *triangle = [[TriangleView alloc] initWithFrame:CGRectMake([UIScreen mainScreen].bounds.size.width / 2 - triangleWidth / 2 , 0, triangleWidth, triangleHeight)];
    [triangle setBackgroundColor:[UIColor clearColor]];
    triangle.arrayRGB = [NSArray arrayWithObjects:@"238",@"159", @"48",@"0.4", nil];
    [self.viewTriangle addSubview:triangle];
}

- (void)initChart{
    [self.chartView initializeChart:self];
    [self.chartView setShowAvarage:YES];
    [self.chartView setIsShowGradient:YES andIsDetailChart:YES];
    [self.chartView setLineChartColor:[UIColor whiteColor] andFillBallColor:[[UIColor blackColor] colorWithAlphaComponent:0.5]];
    [self.chartView setChartBackgroundColor:[UIColor clearColor]];
    self.chartView.chartType = [PHRChartUtils getChartType:StandardHomeTypeBodyMeasurement andIndex:self.typeIndex];
    [self.chartView doCustomize];
    
    [self loadDataChart];
    
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
        }
        else if (self.typeIndex > 0) {
            [self.tabbarType setScrollPage:self.typeIndex - 1];
        }
    }
    if (sender.direction == UISwipeGestureRecognizerDirectionLeft){
        if (self.typeIndex < [self.tabbarType numberOfPages] - 1) {
            [self.tabbarType setScrollPage:self.typeIndex + 1];
        }
    }
}

- (void)calculateSummary {
    double value = 0;
    if (self.typeIndex == BodyMeasurementTypeHeight) {
        for (BodyMeasurementModel *model in self.arrayTableViewData) {
            value += [model.height doubleValue];
        }
        if (self.arrayTableViewData.count > 0) {
            value /= self.arrayTableViewData.count;
        }
        [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.1f",value] withUnit:kLocalizedString(kUnitCm) andColor:PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
    } else if (self.typeIndex == BodyMeasurementTypeWeight) {
        for (BodyMeasurementModel *model in self.arrayTableViewData) {
            value += [model.weight doubleValue];
        }
        if (self.arrayTableViewData.count > 0) {
            value /= self.arrayTableViewData.count;
        }
        [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.1f",value] withUnit:kLocalizedString(kUnitKg) andColor:PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
    } else if (self.typeIndex == BodyMeasurementTypeBodyFat) {
        for (BodyMeasurementModel *model in self.arrayTableViewData) {
            value += [model.percentFat doubleValue];
        }
        if (self.arrayTableViewData.count > 0) {
            value /= self.arrayTableViewData.count;
        }
        [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.2f",value] withUnit:kLocalizedString(kUnitPercent) andColor:PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
    } else if (self.typeIndex == BodyMeasurementTypeBMI) {
        for (BodyMeasurementModel *model in self.arrayTableViewData) {
            value += [model.bmi doubleValue];
        }
        if (self.arrayTableViewData.count > 0) {
            value /= self.arrayTableViewData.count;
        }
        [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.2f",value] withUnit:kLocalizedString(kUnitKgM) andColor:PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
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
    // request data
    taskGetChartData = [[PHRClient instance] requestGetListStandardHealthWithTypeAndDuration:PHRAppStatus.currentStandard.profileId withHealthType:self.typeIndex andDuration:duration completed:^(id response){
        if (response) {
            BOOL status = [PHRClient getStatusFromResponse:response];
            if (status) {
                NSArray *arrayResult = nil;
                if(self.typeIndex == BodyMeasurementTypeHeight){
                    arrayResult = [response[KEY_Content] objectForKey:KEY_Height_Info];
                } else if (self.typeIndex == BodyMeasurementTypeWeight) {
                    arrayResult = [response[KEY_Content] objectForKey:KEY_Weight_Info];
                } else if (self.typeIndex == BodyMeasurementTypeBodyFat) {
                    arrayResult = [response[KEY_Content] objectForKey:KEY_Percent_Fat_Info];
                } else if (self.typeIndex == BodyMeasurementTypeBMI) {
                    arrayResult = [response[KEY_Content] objectForKey:KEY_Bmi_Info];
                }
                if (arrayResult != nil && arrayResult != (id)[NSNull null] && [arrayResult count] > 0) {
                    for (int i = 0; i < arrayResult.count; i++) {
                        PHRSample *sample = [BodyMeasurementModel sampleFromDict:arrayResult[i] type:(BodyMeasurementType)self.typeIndex];
                        [self.arrayChartData addObject:sample];
                    }
                }
            }
        }
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
    NSArray* arrFromDatabase = [[StorageManager instance] getSamplesUnsyncForType:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeBodyMeasurement] profileId:PHRAppStatus.currentStandard.profileId];
    
    for (int i = 0; i < arrFromDatabase.count; i++) {
        PHRSample *sample = [[arrFromDatabase objectAtIndex:i] copy];
        [PHRChartUtils calculateAverage:self.arrayChartData andSample:sample duration:durationType];
    }
}

- (void)requestGetTimeLine {
    __weak __typeof__(self) weakSelf = self;
    // storage
    if (!isDataLoaded) {
        isDataLoaded = YES;
        NSArray *samples = [[StorageManager instance] getSamplesUnsyncForType:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeBodyMeasurement] profileId:PHRAppStatus.currentStandard.profileId];
        for (PHRSample *sample in samples) {
            BodyMeasurementModel *item = [[BodyMeasurementModel alloc] initFromSample:sample];
            [self.arrayTableViewData addObject:item];
        }
    }
    if (taskGetTimeLine){
        [taskGetTimeLine cancel];
    }
  [self.viewIndicatorTable setHidden:NO];
    // server
    taskGetTimeLine = [[PHRClient instance] requestGetTimeLineBodyMeasurement:PHRAppStatus.currentStandard.profileId withHealthType:self.typeIndex andPageNumber:[NSString stringWithFormat:@"%d",numberPage] completed:^(id response){
        if (response) {
            NSArray *arrayResult = [response[KEY_Content] objectForKey:KEY_Health_Info];
            if (arrayResult != nil && arrayResult != (id)[NSNull null] && [arrayResult count] > 0) {
                for (int i = 0; i < arrayResult.count; i++) {
                    
                    NSDictionary *dict = [arrayResult objectAtIndex:i];
                    BodyMeasurementModel *bodyMeasurement = [BodyMeasurementModel initWithObj:dict];
                    [self.arrayTableViewData addObject:bodyMeasurement];
                }
                numberPage += 1;
            }
        }
      
      NSSortDescriptor *descriptor = [NSSortDescriptor sortDescriptorWithKey:@"date"
                                                                   ascending:NO];
      [self.arrayTableViewData sortUsingDescriptors:[NSArray arrayWithObject:descriptor]];
      
//        [self.arrayTableViewData sortUsingComparator:^NSComparisonResult(BodyMeasurementModel *obj1, BodyMeasurementModel *obj2){
//            NSDate *date1 = [UIUtils dateFromString:obj1.date withFormat:PHR_SERVER_DATE_TIME_FORMAT];
//            NSDate *date2 = [UIUtils dateFromString:obj2.date withFormat:PHR_SERVER_DATE_TIME_FORMAT];
//            return [date2 compare:date1];
//        }];
        [self.tableView reloadData];
        [self calculateSummary];
        [self.refreshControl endRefreshing];
      [self.viewIndicatorTable setHidden:YES];
    } error:^(NSString *error){
        [self.refreshControl endRefreshing];
        [self.viewIndicatorTable setHidden:YES];
        [NSUtils showMessage:error withTitle:APP_NAME];
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
    [cell setupUIBodyMeasurement:self.arrayTableViewData[indexPath.row] type:self.typeIndex color:color masterModel:masterDataModel];
    cell.selectionStyle = UITableViewCellSelectionStyleNone;
    return cell;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    return PHR_TABLE_VIEW_ITEM_HEIGHT;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    BodyMeasurementModel *model = [self.arrayTableViewData objectAtIndex:indexPath.row];
    [self openDetail:model];
}

- (void) openDetail:(BodyMeasurementModel*) bodyMeasurementModel {
    StandardBodyMeasurementAddViewController *viewController = [[StandardBodyMeasurementAddViewController alloc] initWithNibName:NSStringFromClass([StandardBodyMeasurementAddViewController class]) bundle:nil];
    viewController.addContentType = self.typeIndex;
    if (bodyMeasurementModel.bodyMeasurementID && bodyMeasurementModel.bodyMeasurementID != [NSNull class] ) {
        viewController.modelID = bodyMeasurementModel.bodyMeasurementID;
    } else {
        viewController.model = bodyMeasurementModel;
    }
    [viewController setAddCallBack:^(BodyMeasurementType type) {
        [self.tabbarType setScrollPage:type];
        //[self refreshAllView];
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
    BodyMeasurementModel *model = [self.arrayTableViewData objectAtIndex:cellIndexPath.row];
    NSString *healthID = model.bodyMeasurementID;
    
    NSString *healthType;
    if(self.typeIndex == BodyMeasurementTypeBodyFat) {
        healthType = [NSString stringWithFormat:@"0%d",(int)BodyMeasurementTypeBMI + 1];
    } else if (self.typeIndex == BodyMeasurementTypeBMI) {
        healthType = [NSString stringWithFormat:@"0%d",(int)BodyMeasurementTypeBodyFat + 1];
    } else {
        healthType = [NSString stringWithFormat:@"0%d",(int)self.typeIndex + 1];
    }
    
    [PHRAppDelegate showLoading];
    [[PHRClient instance] requestDeleteStandardHealth:healthID healthType:healthType andCompleted:^(id response){
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
    if (self.arrayTableViewData.count == 0){
        return NO;
    }
    NSIndexPath *cellIndexPath = [self.tableView indexPathForCell:cell];
    BodyMeasurementModel *model = [self.arrayTableViewData objectAtIndex:cellIndexPath.row];
    NSString *healthID = model.bodyMeasurementID;
    
    switch (state) {
        case kCellStateLeft:
            return NO;
        case kCellStateRight:
            if ([PHRAppStatus checkCurrentStandardActive] && healthID && healthID != [NSNull class]) {
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
  
}


-(void)selectTopMenu:(NSInteger)tagId{
    isDataLoaded = NO;
    self.typeIndex = tagId;
    self.chartView.chartType = [PHRChartUtils getChartType:StandardHomeTypeBodyMeasurement andIndex:self.typeIndex];
    [self.chartView doCustomize];
    [self.chartView setBackgroundColor:[UIColor clearColor]];
    [self getMasterDataModel];
    [self requestGetChartData];
    [self resetTableData];
    [self requestGetTimeLine];
    
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
  
  if (PHRAppDelegate.isReadingHealthKit == YES) {
    [NSUtils showMessage:kLocalizedString(kAlertSysHealthKit) withTitle:kLocalizedString(kAlert)];
  }else{
    StandardBodyMeasurementAddViewController *controller = [[StandardBodyMeasurementAddViewController alloc] initWithNibName:NSStringFromClass([StandardBodyMeasurementAddViewController class]) bundle:nil];
    controller.addContentType = (BodyMeasurementType)self.typeIndex;
    controller.modalTransitionStyle =  UIModalTransitionStyleCoverVertical;
    controller.imageBackground = [UIUtils screenshot:self.view];
    if (self.arrayTableViewData.count > 0){
        if (self.typeIndex == BodyMeasurementTypeHeight) {
            controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].height floatValue];
        } else if (self.typeIndex == BodyMeasurementTypeWeight) {
            controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].weight floatValue];
        } else if (self.typeIndex == BodyMeasurementTypeBodyFat) {
            controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].percentFat floatValue];
        } else if (self.typeIndex == BodyMeasurementTypeBMI) {
            controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].bmi floatValue];
        }
    } else {
        controller.defaultValue = [NSUtils getStandardValue:NO masterDataType:[PHRChartUtils getChartType:StandardHomeTypeBodyMeasurement andIndex:self.typeIndex]];
    }
    [controller setAddCallBack:^(BodyMeasurementType type) {
        
        [self.tabbarType setScrollPage:type];
        
        
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

- (void)handleProfileActiveChanged:(NSNotification*)notification {
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


@end
