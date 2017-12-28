//
//  PHRChildrenFoodViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRChildrenFoodViewController.h"

@interface PHRChildrenFoodViewController () {
    ButtonTimeIntervalClick durationType;
    int numberPage;
}

@end

static NSString *cellIdentifier = @"foodDetailCell";

@implementation PHRChildrenFoodViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self initData];
    [self initView];
    [self requestGetChartData];
    [self requestGetTimeLine];
}

- (void)initData {
    numberPage = 1;
    self.arrayChartData = [[NSMutableArray alloc] init];
    self.arrayTableViewData = [[NSMutableArray alloc] init];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    [self setImageToBackgroundBaby:self.backgroundImage];
}

- (void)viewDidAppear:(BOOL)animated {
    [super viewDidAppear:animated];

}

- (void)initView {
    [self setupNavigationBarTitle:kLocalizedString(kTitleFood) titleIcon:@"Icon_Baby_Food" rightItem:[self itemRightBabyKey:kAdd]];
    self.labelTableHeader.text = kLocalizedString(@"BabyFoodTimeLine");
    [self initTabbarDuration];
    [self initChart];
    [self initTableView];
}

- (void)initTabbarDuration {
    self.tabbarDuration.delegate = self;
    [self.tabbarDuration initContent4ButtonWhiteTransperent];
    durationType = ButtonTimeIntervalWeekly;
    self.tabbarDuration.selectedIndex = durationType;
}

- (void)initChart{
    [self.chartFoodDetail initializeChart:self];
    [self.chartFoodDetail setShowAvarage:YES];
    [self.chartFoodDetail setIsBabyProfile:YES];
    [self.chartFoodDetail setIsShowGradient:NO andIsDetailChart:YES];
    [self.chartFoodDetail setLineChartColor:[PHRUIColor colorFromHex:@"#ffc602" alpha:1.0] andFillBallColor:[[UIColor whiteColor] colorWithAlphaComponent:0.3]];
    [self.chartFoodDetail setChartBackgroundColor:[UIColor clearColor]];
    self.chartFoodDetail.chartType = [PHRChartUtils getChartType:PHRBabyGroupTypeFood andIndex:0];
    [self.chartFoodDetail doCustomize];
    [self.chartFoodDetail setBackgroundColor:[UIColor clearColor]];
    
    [self loadDataChart];
}

- (void)initTableView {
    self.tableViewContent.delegate = self;
    self.tableViewContent.dataSource = self;
    [self.tableViewContent registerNib:[UINib nibWithNibName:NSStringFromClass([ChildrenFoodTableViewCell class]) bundle:nil] forCellReuseIdentifier:cellIdentifier];
    [self.tableViewContent setSeparatorStyle:UITableViewCellSeparatorStyleNone];
    
    __weak __typeof(self) weakSelf = self;
    self.refreshControl = [[UIRefreshControl alloc] init];
    [self.refreshControl addTarget:self action:@selector(pullToRefreshData) forControlEvents:UIControlEventValueChanged];
    [self.tableViewContent addSubview:self.refreshControl];
    [self.tableViewContent addPullToRefreshWithActionHandler:^{
        [weakSelf requestGetTimeLine];
    } position:SVPullToRefreshPositionBottom];
}

- (void)loadDataChart {
    [self.chartFoodDetail setData:self.arrayChartData];
    [self.chartFoodDetail updateChartData];
}

#pragma mark - MDTABBAR delegate
- (void)tabBar:(MDTabBar *)tabBar didChangeSelectedIndex:(NSUInteger)selectedIndex {
    if (tabBar.tag == MDTabBarTagTypeFourButton) {
        durationType = selectedIndex;
        [self requestGetChartData];
    }
}

- (void)requestGetChartData {
    NSString* duration = [NSString stringWithFormat:@"%ld",durationType + 1];
    [self.arrayChartData removeAllObjects];
    [self loadDataChart];
    
    [[PHRClient instance] requestGetListBabyFoodWithDuration:duration andProfileID:PHRAppStatus.currentBaby.profileId completed:^(id response){
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
    }error:^(NSString *error){
        [NSUtils showMessage:error withTitle:APP_NAME];
    }];
}

- (void)requestGetTimeLine {
    __weak __typeof__(self) weakSelf = self;
    
    [[PHRClient instance] requestGetListBabyFoods:PHRAppStatus.currentBaby.profileId andNumberPage:numberPage completed:^(id response){
        if (response) {
            NSArray *arrayResult = response[KEY_Content];
            if (arrayResult != nil && arrayResult != (id)[NSNull null] && [arrayResult count] > 0) {
                for (int i = 0; i < arrayResult.count; i++) {
                    NSDictionary *dict = [arrayResult objectAtIndex:i];
                    ChildrenFoodModel *childrenFoodModel = [ChildrenFoodModel initWithObj:dict];
                    [self.arrayTableViewData addObject:childrenFoodModel];
                }
                
                [self.tableViewContent reloadData];
                numberPage += 1;
            }
        }
    } error:^(NSString *error){
        [PHRAppDelegate hideLoading];
        [NSUtils showMessage:error withTitle:APP_NAME];
    }];
    [self.refreshControl endRefreshing];
    [weakSelf.tableViewContent.pullToRefreshView stopAnimating];
}

- (void)actionNavigationBarItemRight {
    FoodChildrenViewController * controller = [[FoodChildrenViewController alloc] initWithNibName:NSStringFromClass([FoodChildrenViewController class]) bundle:nil];
    [controller setAddFoodChildrenCallBack:^(ChildrenFoodModel *type) {
        [self requestGetChartData];
        [self resetTableData];
        [self requestGetTimeLine];
        
    }];
    [self.navigationController pushViewController:controller animated:YES];
}

#pragma mark - UITableView Delegate
- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section{
    return self.arrayTableViewData.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    ChildrenFoodTableViewCell *cell = [self.tableViewContent dequeueReusableCellWithIdentifier:cellIdentifier];
    if (!cell) {
        cell = [[ChildrenFoodTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:cellIdentifier];
    }
    [cell setRightUtilityButtons:[self rightButtons] WithButtonWidth:50];
    cell.delegate = self;
    
    cell.selectionStyle = UITableViewCellSelectionStyleNone;
    [cell setupUI:self.arrayTableViewData[indexPath.row]];
    
    
    return  cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    ChildrenFoodModel *model;
    model = [self.arrayTableViewData objectAtIndex:indexPath.row];
    [self openDetailBabyFood:model];
}


- (void) openDetailBabyFood:(ChildrenFoodModel*) foodItem {
    FoodChildrenViewController *detailView = [[FoodChildrenViewController alloc] initWithNibName:NSStringFromClass([FoodChildrenViewController class]) bundle:nil];
    detailView.idBabyFood = foodItem.childrenFoodID;
    [detailView setAddFoodChildrenCallBack:^(ChildrenFoodModel *type) {
        [self requestGetChartData];
        [self resetTableData];
        [self requestGetTimeLine];
        
    }];
    [self.navigationController pushViewController:detailView animated:YES];
}

- (void)pullToRefreshData {
    [self resetTableData];
    [self requestGetTimeLine];
}

- (void)resetTableData{
    numberPage = 1;
    if (self.arrayTableViewData.count > 0) {
        [self.arrayTableViewData removeAllObjects];
    }
    [self.tableViewContent reloadData];
}

- (NSArray *)rightButtons {
    NSMutableArray *rightUtilityButtons = [NSMutableArray new];
    [rightUtilityButtons sw_addUtilityButtonWithColor:
     [UIColor redColor]
                                                 icon:[UIImage imageNamed:@"icon-trash-white"]];
    
    return rightUtilityButtons;
}

- (void)swipeableTableViewCell:(SWTableViewCell *)cell didTriggerRightUtilityButtonWithIndex:(NSInteger)index {
    __weak __typeof(self) weakSelf = self;
    NSIndexPath *cellIndexPath = [self.tableViewContent indexPathForCell:cell];
    ChildrenFoodModel *model = [self.arrayTableViewData objectAtIndex:cellIndexPath.row];
        
    [PHRAppDelegate showLoading];
    [[PHRClient instance] requestDeleteObject:PHRAppStatus.currentBaby.profileId and:model.childrenFoodID andMethod:API_GetDetailBabyFood completion:^(MFResponse *response) {
        [PHRAppDelegate hideLoading];
        if (response) {
            [self.arrayTableViewData removeObjectAtIndex:cellIndexPath.row];
            [weakSelf.tableViewContent reloadData];
            [self requestGetChartData];
        } else {
            [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
            [PHRAppDelegate hideLoading];
        }
    }];
    
}


@end
