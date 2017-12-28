

//
//  PHRLSNViewController.m
//  PHR
//
//  Created by DEV-MinhNN on 1/29/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRLSNViewController.h"
#import "TemperatureViewController.h"
#import "FoodViewController.h"
#import "PHRTemperatureTableViewCell.h"
#import "JSChartView.h"

static NSString *CellTemperatureIdentifier     = @"CellTemperatureIdentifier";

@interface PHRLSNViewController ()<UITableViewDataSource, UITableViewDelegate> {
    int _numberPage;
    BOOL _isShow, _isFirstCome;
    NSMutableArray *_listTemperatures;
}
@property (strong, nonatomic) JSChartView *jsTemperatureChart;
@end

@implementation PHRLSNViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view from its nib.
    [self initializeTableView];
    [self.viewChart.subviews makeObjectsPerformSelector: @selector(removeFromSuperview)];
    [self setupGraph];
    [self resetDataInView];
    [self callServicesApiMethod];
    
    __weak __typeof(self) weakSelf = self;
    [weakSelf.tableViewList addPullToRefreshWithActionHandler:^{
        [weakSelf callServicesApiMethod];
    } position:SVPullToRefreshPositionBottom];
    self.refreshControl = [[UIRefreshControl alloc] init];
    [self.refreshControl addTarget:self action:@selector(pullToRefreshData) forControlEvents:UIControlEventValueChanged];
    [self.tableViewList addSubview:self.refreshControl];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)pullToRefreshData{
    [self resetDataInView];
    [self getListTemperatureFromServer];
}
- (void)resetDataInView {
    _numberPage = 1;
    if (_listTemperatures.count > 0) {
        [_listTemperatures removeAllObjects];
    }
}

- (void)initializeTableView {
    _isShow = _isFirstCome = YES;
    _listTemperatures = [NSMutableArray new];
    
    self.tableViewList.delegate = self;
    self.tableViewList.dataSource = self;
    
    [self.tableViewList setAlpha:0.9];
    [self.tableViewList setBackgroundColor:[UIColor whiteColor]];
    [self.tableViewList setSeparatorStyle:UITableViewCellSeparatorStyleNone];
    
    [self.tableViewList registerNib:[UINib nibWithNibName:NSStringFromClass([PHRTemperatureTableViewCell class]) bundle:nil] forCellReuseIdentifier:CellTemperatureIdentifier];
    
    [self.lbtextDailyAverageLD setStyleRegularToLabelWithColor:[UIColor whiteColor] andSize:13.5];
    [self.lbTextAlert setStyleRegularToLabelWithColor:[UIColor blackColor] andSize:14.0];
    
    [self.viewWhite setAlpha:0.9];
    
    [self.viewSeparator setHidden:YES];
    [self.lbTextAlert setText:kLocalizedString(kBabyTitleTimeline)];
    
    if (self.type == PHRGroupTypeTemperature) {
        [self.lbtextDailyAverageLD setText:kLocalizedString(KTitleTemperature)];
        [self setupNavigationBarTitle:kLocalizedString(KTitleTemperature) titleIcon:@"Title_Icon_Temp" rightItem:kLocalizedString(kAdd)];
    }
}

- (void)setupGraph {
    self.jsTemperatureChart = [JSChartView createStandardViewWithType:PHRStandardChartTypeTemperature];
    [self.viewChart addSubview:self.jsTemperatureChart];
    [self.jsTemperatureChart autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0];
    [self.jsTemperatureChart autoPinEdgeToSuperviewEdge:ALEdgeBottom withInset:0];
    [self.jsTemperatureChart autoPinEdgeToSuperviewEdge:ALEdgeLeading withInset:0];
    [self.jsTemperatureChart autoPinEdgeToSuperviewEdge:ALEdgeTrailing withInset:0];
    
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    [self setImageToBackgroundStandard:self.backgroundStandard];
}

- (void)viewDidAppear:(BOOL)animated {
    [super viewDidAppear:animated];
}


#pragma mark -
#pragma mark - Method API

- (void)callServicesApiMethod {
    if (self.type == PHRGroupTypeTemperature) {
        [self getListTemperatureFromServer];
    }
}

- (void)getListTemperatureFromServer {
    __weak __typeof(self) weakSelf = self;
    //[PHRAppDelegate showLoading];
    [self showOrHideLoading:YES];
    [[PHRClient instance] requestGetListData:PHRAppStatus.activeStandard.profileId andNumberPage:_numberPage andMethod:API_GetListTemperature completion:^(MFRession *response) {
        if (response != nil) {
            id content = response.content;
            
            if ([content isKindOfClass:[NSArray class]]) {
                NSArray *result = (NSArray *)content;
                if (result.count > 0){
                    [weakSelf.jsTemperatureChart drawGraph:content];
                }
                _listTemperatures = [[DataManager sharedManager] getArrayTemperature:result];
            }
            if (_listTemperatures.count == 0 && _isFirstCome) {
                _isFirstCome = NO;
                [weakSelf performSelector:@selector(addNewTemperatureRecord) withObject:nil afterDelay:1.0];
            }
            else {
                _numberPage += 1;
                [weakSelf.tableViewList reloadData];
            }
            [self showOrHideLoading:NO];
            //[PHRAppDelegate hideLoading];
        }
        else {
            [self showOrHideLoading:NO];
            //[PHRAppDelegate hideLoading];
            [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
        }
    }];
    
    [weakSelf.tableViewList.pullToRefreshView stopAnimating];
}

- (void)showOrHideLoading:(BOOL)isShowed{
    if (isShowed) {
        //        [PHRAppDelegate showLoadingInView:self.tableViewHealthList];
        //        [PHRAppDelegate showLoadingInView:self.viewChart];
        [self.jsTemperatureChart showOrHideLoading:isShowed];
    } else {
        [self.refreshControl endRefreshing];
        //        [PHRAppDelegate hideLoadingInView:self.tableViewHealthList];
        //        [PHRAppDelegate hideLoadingInView:self.viewChart];
        [self.jsTemperatureChart showOrHideLoading:isShowed];
    }
}

- (NSMutableArray*)generateMutableArrayContainDataLikeJSON:(NSMutableArray*)inputArray{
    NSMutableArray* result = [[NSMutableArray alloc]init];
    for (id object in inputArray) {
        if ([object isKindOfClass:[TemperatureModel class]]) {
            TemperatureModel* temperatureItemObj = (TemperatureModel*) object;
            NSDictionary *temperatureItemDictionary =[NSDictionary dictionaryWithObjectsAndKeys:
                                                      temperatureItemObj.unit        ,KEY_Unit,
                                                      temperatureItemObj.temperature ,KEY_Tempeture_Tempeture,
                                                      temperatureItemObj.date_measure,KEY_Tempeture_Date,
                                                      nil];
            [result addObject:temperatureItemDictionary];
        }
    }
    return result;
}
#pragma mark - Override NavigationBar Method

- (void)actionNavigationBarItemRight {
    if (self.type == PHRGroupTypeTemperature) {
        [self addNewTemperatureRecord];
    }
}

- (void)addNewTemperatureRecord {
    TemperatureViewController *controller = [[TemperatureViewController alloc] initWithNibName:NSStringFromClass([TemperatureViewController class]) bundle:nil];
//    [controller setAddTemperatureCallBack:^(TemperatureModel * type) {
//        [_listTemperatures addObject:type];
//        _listTemperatures = [self timeSortedBegins:_listTemperatures];
//        [self.tableViewList reloadData];
//        [self drawChart];
//    }];
    [self.navigationController pushViewController:controller animated:YES];
}

- (NSMutableArray *) timeSortedBegins:(NSMutableArray *)array {
    NSMutableArray* begins = array;
    NSSortDescriptor *sort = [[NSSortDescriptor alloc] initWithKey:@"date_measure" ascending:NO];
    [begins sortUsingDescriptors: @[sort]];
    return begins;
}

- (void)drawChart{
    // generate data looklike JSON
    NSMutableArray* bArray = [self generateMutableArrayContainDataLikeJSON:_listTemperatures];
    [self.jsTemperatureChart drawGraph:bArray];
}

#pragma mark - TableView Data Source - Delegate

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    // Return the number of sections.
    if (self.type == PHRGroupTypeTemperature) {
        return _listTemperatures.count;
    }
    return 0.0;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return 1.0;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    return 70.0;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    if (self.type == PHRGroupTypeTemperature) {
        PHRTemperatureTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellTemperatureIdentifier];
        if (!cell) {
            cell = [[PHRTemperatureTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellTemperatureIdentifier];
        }
        
        TemperatureModel *model = [_listTemperatures objectAtIndex:indexPath.row];
        [cell fillDataToCell:model];
        
        [cell setSelectionStyle:UITableViewCellSelectionStyleNone];
        [cell setBackgroundColor:[UIColor clearColor]];
        cell.userInteractionEnabled = YES;
        
        return cell;
    }
    return nil;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    if (self.type == PHRGroupTypeTemperature) {
        TemperatureModel *model = [_listTemperatures objectAtIndex:indexPath.section];
        TemperatureViewController *controller = [[TemperatureViewController alloc] initWithNibName:NSStringFromClass([TemperatureViewController class]) bundle:nil];
        controller.idTemperature = model.id;
//        [controller setAddTemperatureCallBack:^(TemperatureModel * type) {
//            BOOL isUpdated = NO;
//            for (int i = 0; i < _listTemperatures.count; i++) {
//                TemperatureModel *obj = (TemperatureModel*) _listTemperatures[i];
//                if (obj.id == type.id) {
//                    _listTemperatures[i] = type;
//                    isUpdated = YES;
//                    NSLog(@"[UPDATED]");
//                }
//                if (isUpdated) {
//                    NSLog(@"[BREAK]");
//                    break;
//                }
//            }
//            [self drawChart];
//            [self.tableViewList reloadData];
//        }];
        [self.navigationController pushViewController:controller animated:YES];
    }
}

- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath {
    if (editingStyle == UITableViewCellEditingStyleDelete) {
        __weak __typeof(self) weakSelf = self;
        TemperatureModel *model = [_listTemperatures objectAtIndex:indexPath.section];
        if (model) {
            [self showOrHideLoading:YES];
            [[PHRClient instance] requestDeleteObject:PHRAppStatus.activeStandard.profileId and:model.id andMethod:API_Tempeture completion:^(MFResponse *response) {
                if (response) {
                    [self showOrHideLoading:NO];
                    [_listTemperatures removeObject:model];
                    [weakSelf.tableViewList reloadData];
                    [weakSelf drawChart];
                }
                else {
                    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
                }
            }];
        }
        
    }
}

- (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath {
    return YES;
}

- (CGFloat)tableView:(UITableView *)tableView heightForHeaderInSection:(NSInteger)section {
    return 0.0;
}

- (CGFloat)tableView:(UITableView *)tableView heightForFooterInSection:(NSInteger)section {
    return 0.0;
}

- (UIView *)tableView:(UITableView *)tableView viewForHeaderInSection:(NSInteger)section {
    return [UIView new];
}

- (UIView *)tableView:(UITableView *)tableView viewForFooterInSection:(NSInteger)section {
    return [UIView new];
}

@end
