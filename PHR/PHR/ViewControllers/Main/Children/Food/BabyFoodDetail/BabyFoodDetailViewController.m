//
//  BabyFoodDetailViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BabyFoodDetailViewController.h"
#import "TriangleView.h"

@interface BabyFoodDetailViewController () {
    ButtonTimeIntervalClick durationType;
    BOOL isDataLoaded;
    int numberPage;
    NSArray *palleteColor;
    NSURLSessionDataTask *taskGetTimeLine;
    NSURLSessionDataTask *taskGetChartData;
    BOOL isShowDialog;
}

@end

@implementation BabyFoodDetailViewController
 static NSString *CellIdentifier = @"TableViewCellIdentifier";
- (void)viewDidLoad {
    [super viewDidLoad];
    [self initData];
    [self initView];
    //[self requestGetChartData];
    //[self requestGetTimeLine];
}

- (void)initData {
    numberPage = 1;
    self.arrayChartData = [[NSMutableArray alloc] init];
    self.arrayTableViewData = [[NSMutableArray alloc] init];
    palleteColor = @[[PHR_COLOR_BABY_FOOD_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_BABY_FOOD_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_BABY_FOOD_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_BABY_FOOD_MAIN_COLOR colorWithAlphaComponent:1],
                     [PHR_COLOR_BABY_FOOD_MAIN_COLOR colorWithAlphaComponent:1]];
}

- (void)initView {
    [self.view setBackgroundColor:[UIColor clearColor]];
//    [self setupNavigationBarTitle:kLocalizedString(kTitleFood) iconLeft:@"Icon_Person" iconRight:@"Icon_Family" iconMiddle:@"Icon_Baby_Food_New" isDismissView:false colorLeft:[PHR_COLOR_BABY_FOOD_LIGHT_ALPHA colorWithAlphaComponent:0.5] colorRight:[PHR_COLOR_BABY_FOOD_OVERLAY colorWithAlphaComponent:0.5]];
    [self checkProfileToShowView];
    [self initTabbarDuration];
    [self initChart];
    [self calculateSummary];
    [self initTableView];
    [self.viewAdd setBackgroundColor:PHR_COLOR_BABY_FOOD_MAIN_COLOR];
    self.labelAdd.text = kLocalizedString(kAdd);
}


- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
//    [self setImageToBackgroundBaby:self.imageBackground];
    [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyProfileBabyActiveChanged object:nil];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleProfileActiveChanged:) name:kNotifyProfileBabyActiveChanged object:nil];
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

- (void)initChart{
    [self.chartView initializeChart:self];
    [self.chartView setShowAvarage:YES];
    [self.chartView setIsShowGradient:YES andIsDetailChart:YES];
    [self.chartView setLineChartColor:[UIColor whiteColor] andFillBallColor:[[UIColor blackColor] colorWithAlphaComponent:0.3]];
    [self.chartView setChartBackgroundColor:[UIColor clearColor]];
    self.chartView.chartType = [PHRChartUtils getChartType:PHRBabyGroupTypeFood andIndex:0];
    [self.chartView doCustomize];
    
    [self loadDataChart];
}

- (void)calculateSummary{
    double value = 0;

    for (ChildrenFoodModel *model in self.arrayTableViewData) {
        value += floor([model.kcal doubleValue]);
    }
    [self.labelAverage setAttributedText:[self setColorAverageLabel:[NSString stringWithFormat:@"%.0f",value] withUnit:kLocalizedString(kUnitCal) andColor:PHR_COLOR_BABY_FOOD_MAIN_COLOR font:[FontUtils aileronRegularWithSize:PHR_HEADER_FONT_SIZE]]];
    
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

#pragma mark - Override Menu Method
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
    taskGetChartData = [[PHRClient instance] requestGetListBabyFoodWithDuration:duration andProfileID:PHRAppStatus.currentBaby.profileId completed:^(id response){
        if (response) {
            NSArray *arrayResult = [response[KEY_Content] objectForKey:KEY_Baby_Food_Info];
            
            if (arrayResult != nil && arrayResult != (id)[NSNull null] && [arrayResult count] > 0) {
                for (int i = 0; i < arrayResult.count; i++) {
                    NSDictionary *dict = [arrayResult objectAtIndex:i];
                    ChildrenFoodModel *childrenFoodModel = [ChildrenFoodModel initWithObj:dict];
                    PHRSample *sample = [childrenFoodModel sampleFromModel];
                    [self.arrayChartData addObject:sample];
                }
                [self loadDataChart];
            }
            
        }
      [self.viewIndicatorChart setHidden:YES];
    } error:^(NSString *error){
        if (isShowDialog) {
            [NSUtils showMessage:kLocalizedString(error) withTitle:APP_NAME];
        }
      [self.viewIndicatorChart setHidden:YES];
    }];
}


- (void)requestGetTimeLine {
    if (!PHRAppStatus.currentBaby) {
      return;
    }
    __weak __typeof__(self) weakSelf = self;
    if (taskGetTimeLine){
        [taskGetTimeLine cancel];
    }
    taskGetTimeLine = [[PHRClient instance] requestGetListBabyFoods:PHRAppStatus.currentBaby.profileId andNumberPage:numberPage completed:^(id response){
        if (response) {
            NSArray *arrayResult = response[KEY_Content];
            if (arrayResult != nil && arrayResult != (id)[NSNull null] && [arrayResult count] > 0) {
                for (int i = 0; i < arrayResult.count; i++) {
                    NSDictionary *dict = [arrayResult objectAtIndex:i];
                    ChildrenFoodModel *childrenFoodModel = [ChildrenFoodModel initWithObj:dict];
                    [self.arrayTableViewData addObject:childrenFoodModel];
                }
                
                [self.tableView reloadData];
                numberPage += 1;
            }
        }
        [self calculateSummary];
        [self.refreshControl endRefreshing];
    } error:^(NSString *error){
        [self.refreshControl endRefreshing];
         [self calculateSummary];
        [PHRAppDelegate hideLoading];
        if (isShowDialog) {
            [NSUtils showMessage:kLocalizedString(error) withTitle:APP_NAME];
        }
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
    [cell setupUIBabyFood:self.arrayTableViewData[indexPath.row] color:color];
    cell.selectionStyle = UITableViewCellSelectionStyleNone;
    return cell;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    return PHR_TABLE_VIEW_ITEM_HEIGHT;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    ChildrenFoodModel *model;
    model = [self.arrayTableViewData objectAtIndex:indexPath.row];
    [self openDetail:model];
}

- (void) openDetail:(ChildrenFoodModel*) foodItem {
    BabyFoodAddViewController *viewController = [[BabyFoodAddViewController alloc] initWithNibName:NSStringFromClass([BabyFoodAddViewController class]) bundle:nil];
    if (foodItem.childrenFoodID && foodItem.childrenFoodID != [NSNull class] ) {
        viewController.modelID = foodItem.childrenFoodID;
    } else {
        viewController.foodItem = foodItem;
    }
    [viewController setAddCallBack:^() {
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
    ChildrenFoodModel *model = [self.arrayTableViewData objectAtIndex:cellIndexPath.row];
    
    [PHRAppDelegate showLoading];
    [[PHRClient instance] requestDeleteObject:PHRAppStatus.currentBaby.profileId and:model.childrenFoodID andMethod:API_GetDetailBabyFood completion:^(MFResponse *response) {
        [PHRAppDelegate hideLoading];
        if (response) {
            [self.arrayTableViewData removeObjectAtIndex:cellIndexPath.row];
            [self.tableView reloadData];
            [self requestGetChartData];
            [self calculateSummary];
            [[NSNotificationCenter defaultCenter] postNotificationName:PHRNotificationRemoveData object:[model getBabyFoodModel]];
        } else {
            [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
            [PHRAppDelegate hideLoading];
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
    BabyFoodAddViewController *controller = [[BabyFoodAddViewController alloc] initWithNibName:NSStringFromClass([BabyFoodAddViewController class]) bundle:nil];
    controller.modalTransitionStyle =  UIModalTransitionStyleCoverVertical;
    
    if ([self.delegate respondsToSelector:@selector(takeScreenShot)]) {
        controller.imageBackground = [self.delegate takeScreenShot];
    }
    if (self.arrayTableViewData.count > 0){
        controller.defaultValue = [[self.arrayTableViewData objectAtIndex:0].kcal floatValue];
    } else {
        controller.defaultValue = [NSUtils getStandardValue:YES masterDataType:[PHRChartUtils getChartType:PHRBabyGroupTypeFood andIndex:0]];
    }
    
    [controller setAddCallBack:^(){
        //[self.tabbarType setScrollPage:selectedType];
        [self refreshAllView];
    }];
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
    [self requestGetChartData];
    [self resetTableData];
    [self requestGetTimeLine];
}

- (void)setIsShowDialog:(BOOL)isShow {
    isShowDialog = isShow;
}

@end
