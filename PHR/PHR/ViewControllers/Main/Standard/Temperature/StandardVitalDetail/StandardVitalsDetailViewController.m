//
//  StandardVitalsDetailViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "StandardVitalsDetailViewController.h"
#import "TriangleView.h"

@interface StandardVitalsDetailViewController () {
    ButtonTimeIntervalClick durationType;
    BOOL isDataLoaded;
    int numberPage;
    NSArray *palleteColor;
    MasterDataModel *masterDataModel;
    NSURLSessionDataTask *taskGetTimeLine;
    NSURLSessionDataTask *taskGetChartData;
}

@end

@implementation StandardVitalsDetailViewController
 static NSString *CellIdentifier = @"TableViewCellIdentifier";
- (void)viewDidLoad {
    [super viewDidLoad];
    [self initData];
    [self initView];
    [self requestGetChartData];
    [self requestGetTimeLine];
    
}

- (void)handleBluetoothData:(NSNotification*)notification{
    PHRSample *sample = (PHRSample*)notification.object;
    if (sample && [sample.type isEqualToString:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeTemprature]]) {
        [self addNewSample:sample isLoadData:NO];
    }
}

- (void)handleHealthKitData:(NSNotification*)notification{
    PHRSample *sample = (PHRSample*)notification.object;
    if (sample && [sample.type isEqualToString:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeTemprature]]) {
        [self.chartView showIndicator];
        [self addNewSample:sample isLoadData:YES];
    }
}

- (void)addNewSample:(PHRSample*)sample isLoadData:(BOOL)isLoadData{
    // Chart
    if (self.typeIndex == PHRChartTemperature || self.typeIndex == PHRChartPrespiratory) {
        [PHRChartUtils calculateAverage:self.arrayChartData andSample:sample duration:durationType];
    } else {
        [PHRChartUtils calculateMinMax:self.arrayChartData andSample:sample duration:durationType];
    }
    if (isLoadData) {
        [self loadChartWithSorted];
    }
    
    // add to list
    TemperaturePhysiologyModel *item = [[TemperaturePhysiologyModel alloc] initFromSample:sample];
    [self.arrayTableViewData insertObject:item atIndex:0];
    [self.tableView reloadData];
    [self calculateSummary];
}

- (void)initData {
    numberPage = 1;
    self.arrayChartData = [[NSMutableArray alloc] init];
    self.arrayTableViewData = [[NSMutableArray alloc] init];
    masterDataModel = [[MasterDataModel alloc] init];
    palleteColor = @[[PHR_COLOR_VITALS_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_VITALS_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_VITALS_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_VITALS_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_VITALS_MAIN_COLOR colorWithAlphaComponent:1]];
}

- (void)initView {
    [self.view setBackgroundColor:[UIColor whiteColor]];
    [self setupNavigationBarTitle:kLocalizedString(KTitleTemperature) iconLeft:@"Icon_Person" iconRight:@"Icon_Family" iconMiddle:@"Icon_Standand_Vitals" isDismissView:false colorLeft:[PHR_COLOR_VITALS_NAV_LEFT colorWithAlphaComponent:0.5] colorRight:[PHR_COLOR_VITALS_MAIN_COLOR colorWithAlphaComponent:0.5]];
    [self.viewAdd setBackgroundColor:PHR_COLOR_VITALS_MAIN_COLOR];
    [self checkProfileToShowView];
    [self initTabbarDuration];
    [self initChart];
    [self initTriangleView];
    [self initTabbarType];
    [self calculateSummary];
    [self initTableView];
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
    if (self.typeIndex == PHRChartTemperature) {
        NSArray* array = [NSUtils getMeanDataForTemperature];
        masterDataModel.highMin = [[array objectAtIndex:0] floatValue];
        masterDataModel.normalMin = [[array objectAtIndex:1] floatValue];
        masterDataModel.normalMax = [[array objectAtIndex:2] floatValue];
        masterDataModel.highMax = [[array objectAtIndex:3] floatValue];
        masterDataModel.mean = (masterDataModel.normalMax + masterDataModel.normalMin) / 2;
    } else if (self.typeIndex == PHRChartHeartRate) {
        CGPoint meanAndSD = [NSUtils getMeanAndSdValue:NO masterDataType:[PHRChartUtils getChartType:StandardHomeTypeTemprature andIndex:self.typeIndex]];
        masterDataModel.mean = meanAndSD.x;
        masterDataModel.sd = meanAndSD.y;
    } else if (self.typeIndex == PHRChartBloodPressure) {
        NSArray* array = [NSUtils getMeanDataForBloodPressure];
        masterDataModel.mean = [[array objectAtIndex:0] floatValue];
        masterDataModel.sd = [[array objectAtIndex:1] floatValue];
        masterDataModel.lowBPMean = [[array objectAtIndex:2] floatValue];
        masterDataModel.lowBPSD = [[array objectAtIndex:3] floatValue];
    }
}

- (void)initTabbarDuration {
    self.tabbarDuration.delegate = self;
    [self.tabbarDuration initContentWhiteTransperent:nil colorSelected:[UIColor whiteColor] andUnselectedColor:[[UIColor whiteColor] colorWithAlphaComponent:0.8]  textFont:[FontUtils aileronRegularWithSize:12.0] selectedFont:[FontUtils aileronRegularWithSize:12.0]];
    durationType = ButtonTimeIntervalWeekly;
    self.tabbarDuration.selectedIndex = durationType;
}

- (void)initTabbarType {
    NSDictionary *typeTemperature = @{PHR_TYPE_IDENTIFIER : kLocalizedString(KTemperature) };
    NSDictionary *typeBloodPressure = @{ PHR_TYPE_IDENTIFIER : kLocalizedString(KBloodPressure)};
    NSDictionary *typeHeartRate = @{ PHR_TYPE_IDENTIFIER : kLocalizedString(KHeartRate)};
    NSDictionary *typeRespiratory = @{ PHR_TYPE_IDENTIFIER : kLocalizedString(KPrespiratory)};
    NSArray* arr = @[typeTemperature,typeBloodPressure,typeHeartRate,typeRespiratory];
    self.tabbarType.topMenuDelegate = self;
    self.tabbarType.backgroundColor = PHR_COLOR_VITALS_LIGHT_ALPHA;
    [self.tabbarType calcurateWidth:arr];
}

- (void)initTriangleView {
    float triangleWidth = 12;
    float triangleHeight = 8;
    TriangleView *triangle = [[TriangleView alloc] initWithFrame:CGRectMake([UIScreen mainScreen].bounds.size.width / 2 - triangleWidth / 2 , 0, triangleWidth, triangleHeight)];
    [triangle setBackgroundColor:[UIColor clearColor]];
    triangle.arrayRGB = [NSArray arrayWithObjects:@"144",@"183", @"232",@"0.4", nil];
    [self.viewTriangle addSubview:triangle];
}

- (void)initChart{
    [self.chartView initializeChart:self];
    [self.chartView setShowAvarage:YES];
    [self.chartView setIsShowGradient:YES andIsDetailChart:YES];
    [self.chartView setLineChartColor:[UIColor whiteColor] andFillBallColor:[[UIColor blackColor] colorWithAlphaComponent:0.5]];
    [self.chartView setChartBackgroundColor:[UIColor clearColor]];
    self.chartView.chartType = [PHRChartUtils getChartType:StandardHomeTypeTemprature andIndex:self.typeIndex];
    [self.chartView doCustomize];

    //Scatter Chart
    [self.scatterChartView initializeChart:self];
    [self.scatterChartView setShowAvarage:YES];
    [self.scatterChartView setIsShowGradient:YES andIsDetailChart:YES];
    [self.scatterChartView setLineChartColor:[UIColor whiteColor] andFillBallColor:[[UIColor blackColor] colorWithAlphaComponent:0.5]];
    [self.scatterChartView setChartBackgroundColor:[UIColor clearColor]];
    self.scatterChartView.chartType = [PHRChartUtils getChartType:StandardHomeTypeTemprature andIndex:self.typeIndex];
    [self.scatterChartView doCustomize];
    [self.scatterChartView setHidden:YES];
    
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
    [self.scatterChartView addGestureRecognizer:recognizerRight];
    [self.scatterChartView addGestureRecognizer:recognizerLeft];
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

- (void)calculateSummary {
    double value = 0;
    double valueMax = 0;
    if (self.typeIndex == PHRChartTemperature) {
        for (TemperaturePhysiologyModel *model in self.arrayTableViewData) {
            value += [model.temperature doubleValue];
        }
        if (self.arrayTableViewData.count > 0) {
            value /= self.arrayTableViewData.count;
        }
        [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.1f",value] withUnit:kLocalizedString(kUnitCelsius) andColor:PHR_COLOR_VITALS_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
        [self.labelSummary setText:kLocalizedString(kTitleAverage)];
    } else if (self.typeIndex == PHRChartHeartRate) {
        int i = 0;
        for (TemperaturePhysiologyModel *model in self.arrayTableViewData) {
            if (i == 0){
                value = [model.heartRate doubleValue];
            }
            if (value > [model.heartRate doubleValue]){
                value = [model.heartRate doubleValue];
            }
            if (valueMax < [model.heartRate doubleValue]) {
                valueMax = [model.heartRate doubleValue];
            }
            i++;
        }
        [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.0f - %.0f",valueMax,value] withUnit:kLocalizedString(kUnitBpm) andColor:PHR_COLOR_VITALS_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
        [self.labelSummary setText:[NSString stringWithFormat:@"%@ - %@:",kLocalizedString(kMax),kLocalizedString(kMin)]];
    } else if (self.typeIndex == PHRChartPrespiratory) {
        for (TemperaturePhysiologyModel *model in self.arrayTableViewData) {
            value += [model.respiratory doubleValue];
        }
        if (self.arrayTableViewData.count > 0) {
             value /= self.arrayTableViewData.count;
        }
        [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.0f",value] withUnit:kLocalizedString(kUnitBreathMin) andColor:PHR_COLOR_VITALS_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
        [self.labelSummary setText:kLocalizedString(kTitleAverage)];
    } else if (self.typeIndex == PHRChartBloodPressure) {
        int i = 0;
        for (TemperaturePhysiologyModel *model in self.arrayTableViewData) {
            if (i == 0){
                value = [model.lowBloodPressure doubleValue];
            }
            if(value > [model.lowBloodPressure doubleValue]) {
                value = [model.lowBloodPressure doubleValue];
            }
            if(valueMax < [model.highBloodPressure doubleValue]){
                valueMax = [model.highBloodPressure doubleValue];
            }
            i++;
        }
        [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.0f - %.0f",valueMax,value] withUnit:kLocalizedString(kUnitMmHG) andColor:PHR_COLOR_VITALS_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
        
        [self.labelSummary setText:[NSString stringWithFormat:@"%@ - %@:",kLocalizedString(kMax),kLocalizedString(kMin)]];
    }
    
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
    if (self.typeIndex == PHRChartBloodPressure || self.typeIndex == PHRChartHeartRate) {
        [self.scatterChartView setData:self.arrayChartData];
        [self.scatterChartView updateChartData];
    }
    else {
        [self.chartView setData:self.arrayChartData];
        [self.chartView updateChartData];
    }
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
        [self.scatterChartView setDuration:durationType];
        [self requestGetChartData];
    }
}

- (void)requestGetChartData {
    NSString* duration = [NSString stringWithFormat:@"%d", (int)durationType + 1];
    [self.arrayChartData removeAllObjects];
    [self loadDataChart];
    if (taskGetChartData){
        [taskGetChartData cancel];
    }
  [self.viewIndicatorChart setHidden:NO];
    // server
    taskGetChartData = [[PHRClient instance] requestGetListTemperaturePhysiologyWithTypeAndDuration:PHRAppStatus.currentStandard.profileId withTemperatureType:self.typeIndex andDuration:duration completed:^(id response){
        if (response) {
            NSArray *arrayResult = nil;
            if(self.typeIndex == PHRChartTemperature){
                arrayResult = [response[KEY_Content] objectForKey:KEY_Temperature_Info];
            } else if (self.typeIndex == PHRChartHeartRate) {
                arrayResult = [response[KEY_Content] objectForKey:KEY_HeartRate_Info];
            } else if (self.typeIndex == PHRChartPrespiratory) {
                arrayResult = [response[KEY_Content] objectForKey:KEY_Respiratory_Info];
            }else{
                arrayResult = [response[KEY_Content] objectForKey:KEY_Blood_Pressure_Info];
            }
            
            if (arrayResult != nil && (id)arrayResult != [NSNull null] && [arrayResult count] > 0) {
                for (int i = 0; i < arrayResult.count; i++) {
                    PHRSample *sample = [TemperaturePhysiologyModel sampleFromDict:arrayResult[i] type:self.typeIndex];
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
        [NSUtils showMessage:error withTitle:APP_NAME];
      [self.viewIndicatorChart setHidden:YES];
    }];
    
}

- (void)mergeDataLocalWithServer {
    NSArray* arrFromDatabase = [[StorageManager instance] getSamplesUnsyncForType:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeTemprature] profileId:PHRAppStatus.currentStandard.profileId];
    
    for (int i = 0; i < arrFromDatabase.count; i++) {
        PHRSample *sample = [[arrFromDatabase objectAtIndex:i] copy];
         if (self.typeIndex == PHRChartTemperature || self.typeIndex == PHRChartPrespiratory) {
             [PHRChartUtils calculateAverage:self.arrayChartData andSample:sample duration:durationType];
         } else {
            [PHRChartUtils calculateMinMax:self.arrayChartData andSample:sample duration:durationType];
         }
    }
}

- (void)requestGetTimeLine {
    __weak __typeof__(self) weakSelf = self;
    
    if (!isDataLoaded) {
        isDataLoaded = YES;
        NSArray *samples = [[StorageManager instance] getSamplesUnsyncForType:[PHRSample healthkitTypeFromType:self.typeIndex fromScreen:StandardHomeTypeTemprature] profileId:PHRAppStatus.currentStandard.profileId];
        for (PHRSample *sample in samples) {
            TemperaturePhysiologyModel *item = [[TemperaturePhysiologyModel alloc] initFromSample:sample];
            [self.arrayTableViewData addObject:item];
        }
    }
    if (taskGetTimeLine){
        [taskGetTimeLine cancel];
    }
  [self.viewIndicatorTable setHidden:NO];
    // get from server
    taskGetTimeLine = [[PHRClient instance] requestGetTimeLineTemperature:PHRAppStatus.currentStandard.profileId withTemperatureType:self.typeIndex andPageNumber:[NSString stringWithFormat:@"%d",numberPage] completed:^(id response){
        if (response) {
            NSArray *arrayResult = [response[KEY_Content] objectForKey:KEY_Temperature_Info];
            if (arrayResult != nil && arrayResult != (id)[NSNull null] && [arrayResult count] > 0) {
                for (int i = 0; i < arrayResult.count; i++) {
                    NSDictionary *dict = [arrayResult objectAtIndex:i];
                    TemperaturePhysiologyModel *item = [TemperaturePhysiologyModel initWithObj:dict];
                    [self.arrayTableViewData addObject:item];
                }
                numberPage += 1;
            }
        }
        // SORT DATA
//        [self.arrayTableViewData sortUsingComparator:^NSComparisonResult(TemperaturePhysiologyModel *obj1, TemperaturePhysiologyModel *obj2){
//            NSDate *date1 = [UIUtils dateFromString:obj1.date withFormat:PHR_SERVER_DATE_TIME_FORMAT];
//            NSDate *date2 = [UIUtils dateFromString:obj2.date withFormat:PHR_SERVER_DATE_TIME_FORMAT];
//            return [date2 compare:date1];
//        }];
      
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
    [cell setupUIVitals:self.arrayTableViewData[indexPath.row] type:self.typeIndex color:color masterModel:masterDataModel];
    cell.selectionStyle = UITableViewCellSelectionStyleNone;
    return cell;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    return PHR_TABLE_VIEW_ITEM_HEIGHT;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    TemperaturePhysiologyModel *model;
    model = [self.arrayTableViewData objectAtIndex:indexPath.row];
    [self openDetail:model];
}

- (void) openDetail:(TemperaturePhysiologyModel*) temperatureModel {
    StandardVitalsAddViewController *viewController = [[StandardVitalsAddViewController alloc] initWithNibName:NSStringFromClass([StandardVitalsAddViewController class]) bundle:nil];
    viewController.addContentType = self.typeIndex;
    if (temperatureModel.TemperaturePhysiologyID && temperatureModel.TemperaturePhysiologyID != [NSNull class] ) {
        viewController.modelID = temperatureModel.TemperaturePhysiologyID;
    } else {
        viewController.model = temperatureModel;
    }
    [viewController setAddCallBack:^(PHRTemperatureChartType selectedType) {
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
    
    TemperaturePhysiologyModel *model = [self.arrayTableViewData objectAtIndex:cellIndexPath.row];
    NSString *temperatureID = model.TemperaturePhysiologyID;
    if (temperatureID) {
        [PHRAppDelegate showLoading];
        [[PHRClient instance] requestDeleteStandardTemperature:temperatureID temperatureType:[NSString stringWithFormat:@"0%d", (int)self.typeIndex + 1] andCompleted:^(id response){
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
    
    
}

- (BOOL)swipeableTableViewCell:(SWTableViewCell *)cell canSwipeToState:(SWCellState)state{
    NSIndexPath *cellIndexPath = [self.tableView indexPathForCell:cell];
    if (self.arrayTableViewData.count == 0){
        return NO;
    }
    TemperaturePhysiologyModel *model = [self.arrayTableViewData objectAtIndex:cellIndexPath.row];
    NSString *temperatureID = model.TemperaturePhysiologyID;
    
    switch (state) {
        case kCellStateLeft:
            return NO;
        case kCellStateRight:
            if ([PHRAppStatus checkCurrentStandardActive] && temperatureID && temperatureID != [NSNull class]) {
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
    if (self.typeIndex == PHRChartBloodPressure || self.typeIndex == PHRChartHeartRate) {
        self.scatterChartView.chartType = [PHRChartUtils getChartType:StandardHomeTypeTemprature andIndex:self.typeIndex];
        [self.scatterChartView doCustomize];
        [self.scatterChartView setBackgroundColor:[UIColor clearColor]];
        [self.scatterChartView setHidden:NO];
        [self.chartView setHidden:YES];
    }
    else
    {
        self.chartView.chartType = [PHRChartUtils getChartType:StandardHomeTypeTemprature andIndex:self.typeIndex];
        [self.chartView doCustomize];
        [self.chartView setBackgroundColor:[UIColor clearColor]];
        [self.scatterChartView setHidden:YES];
        [self.chartView setHidden:NO];
    }
    [self getMasterDataModel];
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
  if (PHRAppDelegate.isReadingHealthKit == YES) {
    [NSUtils showMessage:kLocalizedString(kAlertSysHealthKit) withTitle:kLocalizedString(kAlert)];
  }else{
    StandardVitalsAddViewController *controller = [[StandardVitalsAddViewController alloc] initWithNibName:NSStringFromClass([StandardVitalsAddViewController class]) bundle:nil];
    controller.addContentType = (PHRTemperatureChartType)self.typeIndex;
    controller.modalTransitionStyle =  UIModalTransitionStyleCoverVertical;
    controller.imageBackground = [UIUtils screenshot:self.view ];
    
    if (self.arrayTableViewData.count > 0){
        if (self.typeIndex == PHRChartTemperature) {
            controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].temperature floatValue];
        } else if (self.typeIndex == PHRChartBloodPressure) {
            controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].lowBloodPressure floatValue];
            controller.defaultValueHigh = [[self.arrayTableViewData objectAtIndex:0].highBloodPressure floatValue];
        } else if (self.typeIndex == PHRChartHeartRate) {
            controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].heartRate floatValue];
        } else if (self.typeIndex == PHRChartPrespiratory) {
            controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].respiratory floatValue];
        }
    } else {
        if (self.typeIndex != PHRChartBloodPressure) {
            controller.defaultValue = [NSUtils getStandardValue:NO masterDataType:[PHRChartUtils getChartType:StandardHomeTypeTemprature andIndex:self.typeIndex]];
        }
        else {
            CGPoint point = [NSUtils getStandardBloodPressureValue:NO masterDataType:[PHRChartUtils getChartType:StandardHomeTypeTemprature andIndex:self.typeIndex]];
            controller.defaultValue = point.y;
            controller.defaultValueHigh = point.x;
        }
    }
    
    [controller setAddCallBack:^(PHRTemperatureChartType selectedType){
        [self.tabbarType setScrollPage:selectedType];
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
