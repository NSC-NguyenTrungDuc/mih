//
//  PHRFoodChildrenListViewController.m
//  PHR
//
//  Created by NextopHN on 3/23/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRFoodChildrenListViewController.h"
#import "JSChartView.h"

#import "FoodChildrenListHeaderTableViewCell.h"
#import "PHRBabyMilkHeaderView.h"

#import "FoodChildrenViewController.h"
#import "FoodChildrenTableViewCell.h"

@interface PHRFoodChildrenListViewController (){
    NSMutableArray *_listBabyFood;
    NSMutableArray *_listDateTime;
    NSMutableIndexSet *_expandedSections;
    BOOL _isShow;
    int _totalTime;
    int _numberPage;
    BOOL _isFirstCome;
}
@property (strong, nonatomic) JSChartView *jsFoodBabyChart;
@property (weak, nonatomic) IBOutlet UIImageView *mainBackground;

@end

static NSString *cellIdentifierHeader = @"foodChildrenListHeaderCell";
static NSString *cellIdentifier = @"listFoodChildrenCell";

@implementation PHRFoodChildrenListViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view from its nib.
    [self initializeListFoodView];
    [self.viewChart.subviews makeObjectsPerformSelector: @selector(removeFromSuperview)];
    self.refreshControl = [[UIRefreshControl alloc] init];
    [self.refreshControl addTarget:self action:@selector(pullToRefreshData) forControlEvents:UIControlEventValueChanged];
    [self.tableViewListFood addSubview:self.refreshControl];
    [self.tableViewListFood addPullToRefreshWithActionHandler:^{
        [self callServicesApi];
    } position:SVPullToRefreshPositionBottom];
    [self setupGraph];
    [self resetDataInView];
    [self callServicesApi];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    [self setImageToBackgroundBaby:self.mainBackground];
}

- (void)viewDidAppear:(BOOL)animated {
    [super viewDidAppear:animated];
    //[self drawChart];
}

-(void) pullToRefreshData{
    [self resetDataInView];
    [self callServicesApi];
}
- (void)setImageToBackgroundBaby {
    if (PHRAppStatus.isLocalBaby) {
        if (PHRAppStatus.back && PHRAppStatus.back.imageNameBaby && ![PHRAppStatus.back.imageNameBaby isEmpty]) {
            [self.mainBackground setImage:[UIImage imageNamed:PHRAppStatus.back.imageNameBaby]];
        } else {
            [self.mainBackground setImage:[UIImage imageNamed:PHRAppStatus.babyBackgroundUrl]];
        }
    }
    else {
        [self.mainBackground sd_setImageWithURL:[NSURL URLWithString:PHRAppStatus.babyBackgroundUrl]
                               placeholderImage:[UIImage imageNamed:BG_Baby_Medicine]];
    }
}

- (void)initializeListFoodView {
    _isFirstCome = YES;
    _listBabyFood = [NSMutableArray new];
    _listDateTime = [NSMutableArray new];
    _expandedSections = [NSMutableIndexSet new];
    //    self.tableViewListFood.delegate = self;
    //    self.tableViewListFood.dataSource = self;
    
    //    [self.tableViewLifeStyleNote setAlpha:0.9];
    [self.tableViewListFood setBackgroundColor:[UIColor clearColor]];
    [self.tableViewListFood setSeparatorStyle:UITableViewCellSeparatorStyleNone];
    
    [self.tableViewListFood registerNib:[UINib nibWithNibName:NSStringFromClass([FoodChildrenListHeaderTableViewCell class]) bundle:nil] forCellReuseIdentifier:cellIdentifierHeader];
    [self.tableViewListFood registerNib:[UINib nibWithNibName:NSStringFromClass([FoodChildrenTableViewCell class]) bundle:nil] forCellReuseIdentifier:cellIdentifier];
    
    [self.lbtextDailyAverage setStyleRegularToLabelWithColor:[UIColor whiteColor] andSize:12.0];
    [self.lbTextTitle setStyleRegularToLabelWithColor:[UIColor whiteColor] andSize:15.0];
    [self.lbtextDailyAverage setText:kLocalizedString(kTitleDailyAverage)];
    
    [self.lbTextTitle setText:kLocalizedString(kTitleFood)];
    [self setupNavigationBarTitle:kLocalizedString(kTitleFood) titleIcon:@"Food" rightItem:kLocalizedString(kAdd)];
    
    [self.tableViewListFood setBackgroundColor:[UIColor clearColor]];
    [self.viewBottom setBackgroundColor:[UIColor clearColor]];
    [self.imageViewBottomBackground setImageToBlur:[UIImage imageNamed:@"BGBabyPink"] blurRadius:kLBBlurredImageDefaultBlurRadius completionBlock:^{
        //
    }];
    [self.imageViewBottomBackground setAlpha:0.6];
    
    [self.tableViewListFood addPullToRefreshWithActionHandler:^{
        [self callServicesApi];
    } position:SVPullToRefreshPositionBottom];
    
}

- (void)setupGraph {
    //self.jsFoodBabyChart = [JSChartView createViewWithType:PHRBabyChartTypeFood];
    self.jsFoodBabyChart = [JSChartView createStandardViewWithType:PHRStandardChartTypeFood];
    [self.viewChart addSubview:self.jsFoodBabyChart];
    [self.jsFoodBabyChart autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0];
    [self.jsFoodBabyChart autoPinEdgeToSuperviewEdge:ALEdgeBottom withInset:0];
    [self.jsFoodBabyChart autoPinEdgeToSuperviewEdge:ALEdgeLeading withInset:0];
    [self.jsFoodBabyChart autoPinEdgeToSuperviewEdge:ALEdgeTrailing withInset:0];
}

- (void)resetDataInView {
    _numberPage = 1;
    if (_listBabyFood.count > 0) {
        [_listBabyFood removeAllObjects];
    }
}

-(void)calculateAvarageFood {
    float averageFood= 0;
    float totalKcal = 0;
    float totalLife = _listBabyFood.count;
    if (totalLife == 0) {
        averageFood = 0;
    } else {
        for (int i = 0; i < _listBabyFood.count; i++) {
            BabyFoodModel* obj = (BabyFoodModel*) [_listBabyFood objectAtIndex:i];
            if (obj.kcal && ![obj.kcal isEmpty] ) {
                float kcal = [obj.kcal floatValue];
                totalKcal = totalKcal + kcal;
            }
        }
        averageFood = totalKcal / totalLife;
    }
    [self.lbtextDailyAverage setText:[NSString stringWithFormat:@"%@ %0.2f",kLocalizedString(kTitleDailyAverage),averageFood]];
}
#pragma mark - Override Menu Method

- (void)actionNavigationBarItemRight {
    [self addNewBabyFoodRecord];
}

#pragma mark - Method API

- (void)callServicesApi {
    _isShow = YES;
    [self getListFoodsFromServer];
}

- (void)getListFoodsFromServer {
    __weak __typeof(self) weakSelf = self;
    //[PHRAppDelegate showLoading];
    [self showOrHideLoading:YES];
    [[PHRClient instance] requestGetListData:PHRAppStatus.activeBaby.profileId andNumberPage:_numberPage andMethod:API_GetListBabyFood completion:^(MFRession *response) {
        
        if (response != nil) {
            
            id content = response.content;
            if ([content isKindOfClass:[NSArray class]]) {
                NSArray *result = (NSArray *)content;
                if (result.count > 0){
                    [weakSelf.jsFoodBabyChart drawGraph:response.content];
                }
                _listDateTime = [[DataManager sharedManager] getArrayDateForBabyFood:result];
                _listBabyFood = [[DataManager sharedManager] getArrayBabyFood:result];
            }
            
            [self calculateAvarageFood];
            
            if (_listBabyFood.count == 0 && _isFirstCome) {
                _isFirstCome = NO;
                [weakSelf performSelector:@selector(addNewBabyFoodRecord) withObject:nil afterDelay:1.0];
            }
            else {
                _numberPage += 1;
                [weakSelf.tableViewListFood reloadData];
            }
            
            if (_isShow) {
                NSIndexPath *indexPath = [NSIndexPath indexPathForRow:0.0 inSection:0.0];
                [weakSelf tableView:weakSelf.tableViewListFood didSelectRowAtIndexPath:indexPath];
            }
            
            //[PHRAppDelegate hideLoading];
            [self showOrHideLoading:NO];
        }
        else {
            //[PHRAppDelegate hideLoading];
            [self showOrHideLoading:NO];
            [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
        }
    }];
    
    [weakSelf.tableViewListFood.pullToRefreshView stopAnimating];
}

- (void)addNewBabyFoodRecord {
    FoodChildrenViewController *controller = [[FoodChildrenViewController alloc] initWithNibName:NSStringFromClass([FoodChildrenViewController class]) bundle:nil];
    [controller setAddFoodChildrenCallBack:^(BabyFoodModel *type) {
        [_listBabyFood addObject:type];
        [self reDisplayData];
        
    }];
    [self.navigationController pushViewController:controller animated:YES];
}

- (void)showOrHideLoading:(BOOL)isShowed{
    if (isShowed) {
        //        [PHRAppDelegate showLoadingInView:self.tableViewHealthList];
        //        [PHRAppDelegate showLoadingInView:self.viewChart];
        [self.jsFoodBabyChart showOrHideLoading:isShowed];
    } else {
        [self.refreshControl endRefreshing];
        //        [PHRAppDelegate hideLoadingInView:self.tableViewHealthList];
        //        [PHRAppDelegate hideLoadingInView:self.viewChart];
        [self.jsFoodBabyChart showOrHideLoading:isShowed];
    }
}

#pragma mark - TableView Data Source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    // Return the number of sections.
    return _listDateTime.count;
}

- (NSMutableArray *)getArrayBabyFoodFollowDate:(NSString *)dateTime {
    NSMutableArray *result = [NSMutableArray new];
    for (BabyFoodModel *model in _listBabyFood) {
        NSString *currentDate = [UIUtils formatDateOppositeStyle:[UIUtils dateFromServerTimeString:model.eating_time]];
        if ([currentDate isEqualToString:dateTime]) {
            [result addObject:model];
        }
    }
    return result;
}

- (NSString *)getTotalKcalForHeader:(NSString *)dateTime {
    _totalTime = 0;
    NSMutableArray *array = [self getArrayBabyFoodFollowDate:dateTime];
    for (FoodModel *model in array) {
        int value = [model.kcal intValue];
        _totalTime += value;
    }
    NSString *strTime = [NSString stringWithFormat:@"%d Kcal", _totalTime];
    return strTime;
}

- (NSMutableArray*)generateMutableArrayContainDataLikeJSONForFood:(NSMutableArray*)inputArray{
    NSMutableArray* result = [[NSMutableArray alloc]init];
    for (id object in inputArray) {
        if ([object isKindOfClass:[BabyFoodModel class]]) {
            BabyFoodModel* foodItemObj = (BabyFoodModel*) object;
            NSDictionary *foodItemDictionary =[NSDictionary dictionaryWithObjectsAndKeys:
                                               foodItemObj.kcal,       KEY_Kcal,
                                               foodItemObj.eating_time,KEY_EatingTime,
                                               nil];
            [result addObject:foodItemDictionary];
        }
    }
    return result;
}

- (NSMutableArray *)getArrayDateForBabyFood:(NSMutableArray *)list {
    NSMutableArray *arrayDateTime = [[NSMutableArray alloc] init];
    
    for (int i = 0; i < list.count; i++) {
        BabyFoodModel *model = (BabyFoodModel*) [list objectAtIndex:i];
        NSDate *dateTime = [UIUtils dateFromServerTimeString:model.eating_time];
        
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

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    // Return the number of rows in the section.
    if (_listBabyFood.count > 0) {
        NSMutableArray *array = [NSMutableArray new];
        NSString *dateTime = [_listDateTime objectAtIndex:section];
        
        array = [self getArrayBabyFoodFollowDate:dateTime];
        
        if ([_expandedSections containsIndex:section]) {
            return array.count + 1;
        }
        return 1;
    }
    return 0;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    if (indexPath.row == 0) {
        return 50.0;
    }
    return 60.0;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    if (indexPath.row == 0 ) {
        FoodChildrenListHeaderTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:cellIdentifierHeader];
        if (!cell) {
            cell = [[FoodChildrenListHeaderTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:cellIdentifierHeader];
        }
        NSString *currentTime = [_listDateTime objectAtIndex:indexPath.section];
        NSMutableArray *array = [self getArrayBabyFoodFollowDate:currentTime];
        
        // first row
        if (_listDateTime.count > 0) {
            NSString *objDate = [_listDateTime objectAtIndex:indexPath.section];
            NSDate *today = [NSDate date] ;
            NSDate *yesterDay = [[NSDate date] dateByAddingTimeInterval: -(24*3600)];
            if ([[UIUtils formatDateOppositeStyle:today] isEqualToString:objDate]) {
                [cell setStyleToHeaderTableViewWithTitle:kLocalizedString(kToday) withData:array];
            } else if ([[UIUtils formatDateOppositeStyle:yesterDay] isEqualToString:objDate]){
                [cell setStyleToHeaderTableViewWithTitle:kLocalizedString(kYesterday) withData:array];
            } else {
                [cell setStyleToHeaderTableViewWithTitle:objDate withData:array];
            }
        }
        
        return cell;
    } else {
        FoodChildrenTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:cellIdentifier];
        if (!cell) {
            cell = [[FoodChildrenTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:cellIdentifier];
        }
        
        NSString *currentTime = [_listDateTime objectAtIndex:indexPath.section];
        NSMutableArray *array = [self getArrayBabyFoodFollowDate:currentTime];
        
        BabyFoodModel *model = nil;
        if (array.count > 0) {
            model = [array objectAtIndex:indexPath.row - 1];
        }
        
        if (model) {
            [cell fillDataToFoodCell:model];
        }
        
        [cell setSelectionStyle:UITableViewCellSelectionStyleNone];
        [cell setBackgroundColor:[UIColor clearColor]];
        cell.userInteractionEnabled = YES;
        
        return cell;
    }
}

//- (UIView *)tableView:(UITableView *)tableView viewForHeaderInSection:(NSInteger)section {
//    FoodChildrenListHeaderTableViewCell *headerView = [tableView dequeueReusableCellWithIdentifier:cellIdentifier];
//
//    NSString *currentDate = [_listDateTime objectAtIndex:section];
//    //    if ([currentDate isEqualToString:[UIUtils formatDateOppositeStyle:[NSDate date]]]) {
//    //        [headerView.labelToday setText:kLocalizedString(kToday)];
//    //    }
//    //    else {
//    //        [headerView.labelToday setText:currentDate];
//    //    }
//    return headerView.contentView;
//}

- (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath {
    if (indexPath.row == 0) {
        return NO;
    }
    return YES;
}

- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath {
    if (editingStyle == UITableViewCellEditingStyleDelete) {
        __weak __typeof(self) weakSelf = self;
        NSString *currentTime = [_listDateTime objectAtIndex:indexPath.section];
        
        NSMutableArray *array = [self getArrayBabyFoodFollowDate:currentTime];
        BabyFoodModel *model = nil;
        if (array.count > 0) {
            model = [array objectAtIndex:indexPath.row - 1];
        }
        [PHRAppDelegate showLoading];
        [[PHRClient instance] requestDeleteObject:PHRAppStatus.activeBaby.profileId and:model.id andMethod:API_GetDetailBabyFood completion:^(MFResponse *reponse) {
            [PHRAppDelegate hideLoading];
            if (reponse) {
                [_listBabyFood removeObject:model];
                [weakSelf reDisplayData];
            }
            else {
                [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
                [PHRAppDelegate hideLoading];
            }
        }];
    }
}
- (void)reDisplayData{
    _listBabyFood = [self timeSortedBegins:_listBabyFood ascending:NO];
    [self drawChart];
    //_listBabyFood = [self timeSortedBegins:_listBabyFood ascending:YES];
    _listDateTime = [self getArrayDateForBabyFood:_listBabyFood];
    [self calculateAvarageFood];
    [self.tableViewListFood reloadData];
}
- (void)drawChart{
    // generate data looklike JSON
    NSMutableArray* bArray = [self generateMutableArrayContainDataLikeJSONForFood:_listBabyFood];
    [self.jsFoodBabyChart drawGraph:bArray];
}

- (NSMutableArray*) timeSortedBegins:(NSMutableArray*)input ascending:(BOOL)ascending {
    NSMutableArray* begins = input;
    NSSortDescriptor *sort = [[NSSortDescriptor alloc] initWithKey:@"eating_time" ascending:ascending];
    [begins sortUsingDescriptors: @[sort]];
    return begins;
}
#pragma mark - TableView Delegate

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    if (indexPath.row == 0){
        [tableView deselectRowAtIndexPath:indexPath animated:YES];
        
        NSInteger section = indexPath.section;
        BOOL currentlyExpanded = [_expandedSections containsIndex:section];
        NSInteger rows;
        
        NSMutableArray *tmpArray = [NSMutableArray array];
        
        if (currentlyExpanded) {
            rows = [self tableView:tableView numberOfRowsInSection:section];
            [_expandedSections removeIndex:section];
        }
        else {
            [_expandedSections addIndex:section];
            rows = [self tableView:tableView numberOfRowsInSection:section];
        }
        
        for (int i = 1; i < rows; i++) {
            NSIndexPath *tmpIndexPath = [NSIndexPath indexPathForRow:i inSection:section];
            [tmpArray addObject:tmpIndexPath];
        }
        
        if (currentlyExpanded) {
            _isShow = YES;
            [tableView deleteRowsAtIndexPaths:tmpArray withRowAnimation:UITableViewRowAnimationTop];
        }
        else {
            _isShow = NO;
            [tableView insertRowsAtIndexPaths:tmpArray withRowAnimation:UITableViewRowAnimationTop];
        }
    } else {
        NSString *currentTime = [_listDateTime objectAtIndex:indexPath.section];
        NSMutableArray *array = [self getArrayBabyFoodFollowDate:currentTime];
        BabyFoodModel *model = nil;
        if (array.count > 0) {
            model = [array objectAtIndex:indexPath.row - 1];
        }
        FoodChildrenViewController *controller = [[FoodChildrenViewController alloc] initWithNibName:NSStringFromClass([FoodChildrenViewController class]) bundle:nil];
        controller.idBabyFood = model.id;
        [controller setAddFoodChildrenCallBack:^(BabyFoodModel *type) {
            BOOL isUpdated = NO;
            for (int i = 0; i < _listBabyFood.count; i++) {
                BabyFoodModel *obj = (BabyFoodModel*) _listBabyFood[i];
                if (obj.id == type.id) {
                    _listBabyFood[i] = type;
                    isUpdated = YES;
                    NSLog(@"[UPDATED]");
                }
                if (isUpdated) {
                    NSLog(@"[BREAK]");
                    break;
                }
            }
            [self reDisplayData];
        }];
        [self.navigationController pushViewController:controller animated:YES];
    }
}


@end
