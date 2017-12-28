//
//  ListDiapersViewController.m
//  PHR
//
//  Created by DEV-MinhNN on 10/9/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "ListDiapersViewController.h"
#import "PHRMedicineNoteTableViewCell.h"
#import "PHRMedicineTitleTableViewCell.h"
#import "AddDiapersViewController.h"


static NSString *CellDiaperIdentifier       = @"CellDiaperIdentifier";
static NSString *CellDiaperTitleIdentifier  = @"CellDiaperTitleIdentifier";

@interface ListDiapersViewController ()<UITableViewDataSource, UITableViewDelegate> {
    int _numberPageDiaper;
    NSMutableArray *_listDateTime;
    NSMutableIndexSet *_expandedSections;
    BOOL _isShow;
    NSURLSessionDataTask *taskGetTimeLine;
    BOOL isShowDialog;
}

@property (strong, nonatomic) NSArray *xdata;
@property (strong, nonatomic) NSArray *ydata;

@end

@implementation ListDiapersViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    __weak __typeof(self) weakSelf = self;
    _isShow = YES;
    weakSelf.listDiapers = [NSMutableArray new];
    weakSelf.listDiapersChart = [NSMutableArray new];
    
    _listDateTime = [NSMutableArray new];
    _expandedSections = [NSMutableIndexSet new];
    
    self.viewAdd.backgroundColor = PHR_COLOR_BABY_DIAPER_MAIN_COLOR;
    self.refreshControl = [[UIRefreshControl alloc] init];
    [self.refreshControl addTarget:self action:@selector(pullToRefreshData) forControlEvents:UIControlEventValueChanged];
    [weakSelf.tableViewListDiapers addSubview:self.refreshControl];
    
    [weakSelf.tableViewListDiapers addPullToRefreshWithActionHandler:^{
        [weakSelf getListDiaperFromServer];
    } position:SVPullToRefreshPositionBottom];
    
    [weakSelf initializeListDiapersView];

    [self resetDataInView];
    //[self getListDiaperFromServer];
    [self checkProfileToShowView];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)refreshAllView {
    [self checkProfileToShowView];
    [self resetDataInView];
    [self getListDiaperFromServer];
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    //[self setImageToBackgroundBaby];
   // [self setImageToBackgroundBaby:self.mainBackground];
    [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyProfileBabyActiveChanged object:nil];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleProfileActiveChanged:) name:kNotifyProfileBabyActiveChanged object:nil];
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

- (void)handleProfileActiveChanged:(NSNotification*)notification{
    [self checkProfileToShowView];
    [self resetDataInView];
     [self getListDiaperFromServer];
}

- (void)checkProfileToShowView {
    if (![PHRAppStatus checkCurrentBabyActive]) {
        [self.viewAdd setHidden:YES];
        self.constraintTableAndAdd.constant = 0 - self.viewAdd.bounds.size.height;
    } else {
        [self.viewAdd setHidden:NO];
        self.constraintTableAndAdd.constant = 0;
    }
}

#pragma mark - Public Methods

- (void)pullToRefreshData {
    [self resetDataInView];
    [self getListDiaperFromServer];
}

- (void)resetDataInView {
    _numberPageDiaper = 1;
    if (self.listDiapers.count > 0) {
        [self.listDiapers removeAllObjects];
    }
    if(self.listDiapersChart > 0){
        [self.listDiapersChart removeAllObjects];
    }
    if (_listDateTime.count > 0) {
        [_listDateTime removeAllObjects];
    }
    [self.tableViewListDiapers reloadData];
}

- (void)getListDiaperFromServer {
    [self loadDataChart];
    if (!PHRAppStatus.currentBaby) {
      return;
    }
    [self showOrHideLoading:YES];
    __weak __typeof(self) weakSelf = self;
    
    if (taskGetTimeLine){
        [taskGetTimeLine cancel];
    }
  [self.viewIndicatorTable setHidden:NO];
    taskGetTimeLine = [[PHRClient instance] requestGetListBabyDiapersWithId:PHRAppStatus.currentBaby.profileId andNumberPage:_numberPageDiaper completed:^(id params) {
        NSArray *diapers = [params objectForKey:KEY_Content];
        if (diapers.count > 0) {
            //[weakSelf.jsListDiapersChart drawGraph:params];
            for (int i = 0; i < diapers.count; i++) {
                NSDictionary *dict = [diapers objectAtIndex:i];
                Diaper *objDiaper = [Diaper initializeDiaperFrom:dict];
                NSDate *dayDiaper = [UIUtils dateFromServerTimeString:objDiaper.time_pee_poo];
                
                [weakSelf.listDiapers addObject:objDiaper];
                
                if (_listDateTime.count > 0) {
                    BOOL isAdd = YES;
                    for (int j = 0; j < [_listDateTime count]; j++) {
                        NSString *dateTime = [_listDateTime objectAtIndex:j];
                        if ([dateTime isEqualToString:[UIUtils formatDateOppositeStyle:dayDiaper]]) {
                            PHRSample *sample = [self.listDiapersChart objectAtIndex:j];
                            if([objDiaper.method isEqualToString:@"Poo"]){
                                sample.value ++;
                            }else{
                                sample.value2 ++;
                            }
                            isAdd = NO;
                        }
                    }
                    if (isAdd) {
                        [_listDateTime addObject:[UIUtils formatDateOppositeStyle:dayDiaper]];
                        DiaperChartData *chartData = [[DiaperChartData alloc] init];
                        chartData.time_pee_poo = objDiaper.time_pee_poo;
                        if([objDiaper.method isEqualToString:@"Poo"]){
                            chartData.numberOfPoo = 1;
                            chartData.numberOfPee = 0;
                        }else{
                            chartData.numberOfPoo = 0;
                            chartData.numberOfPee = 1;
                        }
                        
                        [self.listDiapersChart addObject:[chartData sampleFromDiaperChartData]];
                    }
                }
                else {
                    [_listDateTime addObject:[UIUtils formatDateOppositeStyle:dayDiaper]];
                    DiaperChartData *chartData = [[DiaperChartData alloc] init];
                    chartData.time_pee_poo = objDiaper.time_pee_poo;
                    if([objDiaper.method isEqualToString:@"Poo"]){
                        chartData.numberOfPoo = 1;
                        chartData.numberOfPee = 0;
                    }else{
                        chartData.numberOfPoo = 0;
                        chartData.numberOfPee = 1;
                    }
                    [self.listDiapersChart addObject:[chartData sampleFromDiaperChartData]];
                }
            }
            
            if (weakSelf.listDiapers.count > 0) {
                weakSelf.listDiapers = [weakSelf timeSortedBegins:weakSelf.listDiapers];
            }
            _numberPageDiaper += 1;
            [weakSelf.tableViewListDiapers reloadData];
            if (_isShow) {
                NSIndexPath *indexPath = [NSIndexPath indexPathForRow:0.0 inSection:0.0];
                [weakSelf tableView:weakSelf.tableViewListDiapers didSelectRowAtIndexPath:indexPath];
            }
        }
        [self loadDataChart];
        [self showOrHideLoading:NO];
      [self.viewIndicatorTable setHidden:YES];
    } error:^(NSString *error) {
      [self.viewIndicatorTable setHidden:YES];
        [self showOrHideLoading:NO];
        if (isShowDialog) {
             [NSUtils showAlertWithTitle:kLocalizedString(kTitleAlertError) message:[NSString stringWithFormat:@"%@", error.description]];
        }
       
    }];
    
    [weakSelf.tableViewListDiapers.pullToRefreshView stopAnimating];
}

- (NSMutableArray*)timeSortedBegins:(NSMutableArray *)array {
    NSMutableArray* begins = array;
    NSSortDescriptor *sort = [[NSSortDescriptor alloc] initWithKey:@"time_pee_poo" ascending:NO];
    [begins sortUsingDescriptors: @[sort]];
    return begins;
}

- (void)showOrHideLoading:(BOOL)isShowed{
    if (isShowed) {
        //        [PHRAppDelegate showLoadingInView:self.tableViewHealthList];
        //        [PHRAppDelegate showLoadingInView:self.viewChart];
    } else {
        [self.refreshControl endRefreshing];
        //        [PHRAppDelegate hideLoadingInView:self.tableViewHealthList];
        //        [PHRAppDelegate hideLoadingInView:self.viewChart];
    }
}

#pragma mark - Initialize View In First Run

- (void)initializeListDiapersView {
    self.tableViewListDiapers.delegate = self;
    self.tableViewListDiapers.dataSource = self;
    
    [self setupGraph];
    
    [self.tableViewListDiapers setBackgroundColor:[UIColor whiteColor]];
    [self.tableViewListDiapers setSeparatorStyle:UITableViewCellSeparatorStyleNone];
    
    [self.tableViewListDiapers registerNib:[UINib nibWithNibName:NSStringFromClass([PHRMedicineNoteTableViewCell class]) bundle:nil] forCellReuseIdentifier:CellDiaperIdentifier];
    [self.tableViewListDiapers registerNib:[UINib nibWithNibName:NSStringFromClass([PHRMedicineTitleTableViewCell class]) bundle:nil] forCellReuseIdentifier:CellDiaperTitleIdentifier];
    
    [self.viewDownListDiapers setBackgroundColor:[UIColor clearColor]];
    
    self.lblAddData.text = kLocalizedString(kAdd);
    
//    [self setupNavigationBarTitle:kLocalizedString(kBabyTitleDiaper) iconLeft:@"Icon_Person" iconRight:@"Icon_Family" iconMiddle:@"Icon_Timeline_Diapper" isDismissView:false colorLeft:PHR_COLOR_BABY_DIAPER_LIGHT_ALPHA colorRight:PHR_COLOR_BABY_DIAPER_OVERLAY];
}

#pragma mark - Override navigation bar function
//
//- (void)actionNavigationBarItemRight {
//    NewDiapersViewController *controller = [[NewDiapersViewController alloc] initWithNibName:NSStringFromClass([NewDiapersViewController class]) bundle:nil];
//    [controller setAddDiaperCallback:^(Diaper *type) {
//        NSLog(@"[REDRAW AFTER INSERT] COMPLETELY");
//        [self.listDiapers addObject:type];
//        [self reDrawChart];
//        [self loadDataChart];
//    }];
//    [self.navigationController pushViewController:controller animated:YES];
//}

#pragma mark - TableView Data Source - Delegate

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    // Return the number of sections.
    if (_listDateTime.count > 0) {
        return _listDateTime.count;
    }
    return 0.0;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    // Return the number of rows in the section.
    if (self.listDiapers.count > 0) {
        NSString *dateTime = [_listDateTime objectAtIndex:section];
        NSMutableArray *diapers = [NSMutableArray new];
        
        for (Diaper *obj in self.listDiapers) {
            if ([obj.dateTime isEqualToString:dateTime]) {
                [diapers addObject:obj];
            }
        }
        
        if ([_expandedSections containsIndex:section]) {
            return diapers.count + 1;
        }
        return 1;
    }
    return 0.0;
}

- (void)setupGraph {
    
    [self.chartView initializeChart:self];
    
    [self.chartView setShowAvarage:YES];
    [self.chartView setIsShowGradient:YES andIsDetailChart:YES];
    [self.chartView setLineChartColor:[UIColor whiteColor] andFillBallColor:[[UIColor blackColor] colorWithAlphaComponent:0.5]];
    [self.chartView setChartBackgroundColor:[UIColor clearColor]];
    self.chartView.chartType = [PHRChartUtils getChartType:PHRBabyGroupTypeDiaper andIndex:0];
    [self.chartView doCustomize];
    
    [self loadDataChart];
}

- (void)loadDataChart {
    [self.listDiapersChart sortUsingComparator:^NSComparisonResult(PHRSample *obj1, PHRSample *obj2){
        return [obj1.record_date compare:obj2.record_date];
    }];
    [self.chartView setData:self.listDiapersChart];
    [self.chartView updateChartData];
}


- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    if(!indexPath.row) {
        return 40.0;
    }
    return 64.0;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    if (!indexPath.row) {
        PHRMedicineTitleTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellDiaperTitleIdentifier];
        if (cell == nil) {
            cell = [[PHRMedicineTitleTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellDiaperTitleIdentifier];
        }
        [cell setRightUtilityButtons:[self rightButtons] WithButtonWidth:PHR_TABLE_VIEW_DELETE_BUTTON_HEIGHT];
        
        cell.delegate = self;
        
        // first row
        if (_listDateTime.count > 0) {
            NSString *objDate = [_listDateTime objectAtIndex:indexPath.section];
            NSDate *today = [NSDate date];
            if ([[UIUtils formatDateOppositeStyle:today] isEqualToString:objDate]) {
                [cell setStyleToHeaderTableViewWithTitle:kLocalizedString(kToday) andDate:objDate];
            }
            else {
                [cell setStyleToHeaderTableViewWithTitle:objDate andDate:nil];
            }
        }
        
        return cell;
    }
    else {
        PHRMedicineNoteTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellDiaperIdentifier];
        [cell setSelectionStyle:UITableViewCellSelectionStyleNone];
        
        if (!cell) {
            cell = [[PHRMedicineNoteTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellDiaperIdentifier];
        }
        [cell setRightUtilityButtons:[self rightButtons] WithButtonWidth:PHR_TABLE_VIEW_DELETE_BUTTON_HEIGHT];
        
        cell.delegate = self;
        
        [cell setBackgroundColor:[UIColor clearColor]];
        cell.userInteractionEnabled = YES;
        
        NSString *objDate = [_listDateTime objectAtIndex:indexPath.section];
        NSMutableArray *array = [NSMutableArray new];
        
        if (self.listDiapers.count > 0) {
            for (Diaper *obj in self.listDiapers) {
                if ([obj.dateTime isEqualToString:objDate]) {
                    [array addObject:obj];
                }
            }
        }
        
        if (array.count >0) {
            Diaper *objDiaper = [array objectAtIndex:(indexPath.row - 1)];
            [cell setDataDiaperToCell:objDiaper];
        }
        
        return cell;
    }
    return nil;
}

- (NSArray *)rightButtons {
    NSMutableArray *rightUtilityButtons = [NSMutableArray new];
    [rightUtilityButtons sw_addUtilityButtonWithColor:
     [UIColor redColor] icon:[UIImage imageNamed:@"icon-trash-white"]];
    
    return rightUtilityButtons;
}


- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    if (!indexPath.row) {
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
            NSIndexPath *tmpIndexPath = [NSIndexPath indexPathForRow:i
                                                           inSection:section];
            [tmpArray addObject:tmpIndexPath];
        }
        
        if (currentlyExpanded) {
            _isShow = YES;
            [tableView deleteRowsAtIndexPaths:tmpArray
                             withRowAnimation:UITableViewRowAnimationTop];
            
        }
        else {
            _isShow = NO;
            [tableView insertRowsAtIndexPaths:tmpArray
                             withRowAnimation:UITableViewRowAnimationTop];
        }
    }
    else {
        NSString *objDate = [_listDateTime objectAtIndex:indexPath.section];
        NSMutableArray *array = [NSMutableArray new];
        
        if (self.listDiapers.count > 0) {
            for (Diaper *obj in self.listDiapers) {
                if ([obj.dateTime isEqualToString:objDate]) {
                    [array addObject:obj];
                }
            }
        }
        Diaper *objDiaper = nil;
        if (array.count > 0) {
            objDiaper = [array objectAtIndex:(indexPath.row - 1)];
        }
        
        if (objDiaper) {
            [self getDatailObjDiaper:objDiaper];
        }
    }
}
- (void)swipeableTableViewCell:(SWTableViewCell *)cell didTriggerRightUtilityButtonWithIndex:(NSInteger)index {
    
    if (_listDateTime.count == 0) {
        return;
    }
    NSIndexPath *cellIndexPath = [self.tableViewListDiapers indexPathForCell:cell];
    NSString *objDate = [_listDateTime objectAtIndex:cellIndexPath.section];
    
   // __weak __typeof(self) weakSelf = self;
//    NSString *objDate = [_listDateTime objectAtIndex:indexPath.section];
    NSMutableArray *array = [NSMutableArray new];
    
    if (self.listDiapers.count > 0) {
        for (Diaper *obj in self.listDiapers) {
            if ([obj.dateTime isEqualToString:objDate]) {
                [array addObject:obj];
            }
        }
    }
    Diaper *objDiaper = nil;
    if (array.count > 0) {
        objDiaper = [array objectAtIndex:(cellIndexPath.row - 1)];
    }
    
    if (objDiaper) {
        [[PHRClient instance] requestDeleteObject:PHRAppStatus.currentBaby.profileId and:objDiaper.diaperID andMethod:API_GetDetailBabyDiaper completion:^(MFResponse *result) {
            if (result) {
                [self resetDataInView];
                [self getListDiaperFromServer];

//                [weakSelf.listDiapers removeObject:objDiaper];
//                [array removeObject:objDiaper];
//                if (array.count == 0){
//                    [_listDateTime removeObjectAtIndex:cellIndexPath.section];
//                }
//                [weakSelf reDrawChart];
//                [self loadDataChart];
                
            }
            else {
                if (isShowDialog) {
                    [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
                }
            }
        }];
    }
}


- (BOOL)swipeableTableViewCell:(SWTableViewCell *)cell canSwipeToState:(SWCellState)state{
    switch (state) {
        case kCellStateLeft:
            return NO;
        case kCellStateRight:
            
            if ([PHRAppStatus checkCurrentBabyActive] ) {
                NSIndexPath *cellIndexPath = [self.tableViewListDiapers indexPathForCell:cell];
                if (cellIndexPath.row != 0) {
                     return YES;
                }
                return NO;
            }
            return NO;
        default:
            break;
    }
    return YES;
}


- (void)reDrawChart{
    _listDiapers = [self timeSortedBegins:_listDiapers];
    [self getListDateTime:_listDiapers];
    
    // generate data looklike JSON
//    NSMutableArray* bArray = [self generateMutableArrayContainDataLikeJSON:_listDiapers];
    // generate Data
//    NSDictionary* bDictionary = [NSDictionary dictionaryWithObject:bArray forKey:KEY_Content];
//    DLog(@"DiapersData: %@",bDictionary);
    [self loadDataChart];
    [self.tableViewListDiapers reloadData];
    
}

- (void)getListDateTime:(NSMutableArray*)input{
    for (int i = 0; i < input.count; i++) {
        Diaper *objDiaper = (Diaper*) [input objectAtIndex:i];
        NSDate *dayDiaper = [UIUtils dateFromServerTimeString:objDiaper.time_pee_poo];
        
        if (_listDateTime.count > 0) {
            BOOL isAdd = YES;
            for (NSString *dateTime in _listDateTime) {
                if ([dateTime isEqualToString:[UIUtils formatDateOppositeStyle:dayDiaper]]) {
                    isAdd = NO;
                }
            }
            if (isAdd) {
                [_listDateTime addObject:[UIUtils formatDateOppositeStyle:dayDiaper]];
            }
        }
        else {
            [_listDateTime addObject:[UIUtils formatDateOppositeStyle:dayDiaper]];
        }
    }
}
- (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath {
    if (!indexPath.row) {
        return NO;
    }
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

#pragma mark - Get Datail Diaper

- (void)getDatailObjDiaper:(Diaper *)objDiaper {
    AddDiapersViewController *viewController = [[AddDiapersViewController alloc] initWithNibName:NSStringFromClass([AddDiapersViewController class]) bundle:nil];
    viewController.babyDiaperID = objDiaper.diaperID;
    viewController.model = objDiaper;
    [viewController setAddDiaperCallback:^(Diaper *type) {
//        [self reDrawChart];
//        [self loadDataChart];
        [self pullToRefreshData];
    }];
    
    if ([self.delegate respondsToSelector:@selector(takeScreenShot)]) {
        viewController.imageBackground = [self.delegate takeScreenShot];
    }
    
    if ([self.delegate respondsToSelector:@selector(presentViewControllerOnDashboard:)]) {
        [self.delegate presentViewControllerOnDashboard:viewController];
    }
}

- (NSMutableArray*)generateMutableArrayContainDataLikeJSON:(NSMutableArray*)inputArray{
    NSMutableArray* result = [[NSMutableArray alloc]init];
    for (id object in inputArray) {
        if ([object isKindOfClass:[Diaper class]]) {
            Diaper* diaperItemObj = (Diaper*) object;
            NSDictionary *healthItemCoreData =[NSDictionary dictionaryWithObjectsAndKeys:
                                               diaperItemObj.method,KEY_MedicineNote_Method,
                                               diaperItemObj.time_pee_poo,KEY_BabyDiaper_Time,
                                               nil];
            [result addObject:healthItemCoreData];
        }
    }
    return result;
}
- (IBAction)actionAddData:(id)sender {
    AddDiapersViewController *controller = [[AddDiapersViewController alloc] initWithNibName:NSStringFromClass([AddDiapersViewController class]) bundle:nil];
    
    
    [controller setAddDiaperCallback:^(Diaper *type) {
//        [self reDrawChart];
//        [self loadDataChart];
        [self pullToRefreshData];
    }];

    if ([self.delegate respondsToSelector:@selector(takeScreenShot)]) {
        controller.imageBackground = [self.delegate takeScreenShot];
    }
    
    if ([self.delegate respondsToSelector:@selector(presentViewControllerOnDashboard:)]) {
        [self.delegate presentViewControllerOnDashboard:controller];
    }

}

- (void)setIsShowDialog:(BOOL)isShow {
    isShowDialog = isShow;
}

- (void)dealloc {
    [[NSNotificationCenter defaultCenter] removeObserver:self];
}

@end
