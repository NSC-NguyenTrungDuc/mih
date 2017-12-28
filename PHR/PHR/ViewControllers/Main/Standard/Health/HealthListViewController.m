//
//  HealthListViewController.m
//  PHR
//
//  Created by NextopHN on 2/3/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "HealthListViewController.h"
#import "RCSwitchOnOff.h"
#import "HealthViewController.h"
#import "HealthViewCell.h"
#import "JSChartView.h"

@interface HealthListViewController (){
    int numberPage;
    float BMI;
    NSMutableArray *listHealths;
    //    NSMutableArray *_listDateTime;
    //    NSMutableIndexSet *_expandedSections;
    BOOL _isShow;
}

@property (strong, nonatomic) NSArray *xdata;
@property (strong, nonatomic) NSArray *ydata;
@property (strong, nonatomic) JSChartView *jsHealthChart;
@end
static NSString *healthTableViewCell = @"healthTableViewCell";
static float BMIStageFontSize = 9.0;
static float averageFontSize = 14.0;
static float timeLineFontSize = 14.0;
static float healthFontSize = 17.0;
static NSInteger numberOfLine= 2;
static float spaceBetweenLabelAndView = 5;
static float offSet = 5;
static float offSetBMIStageView = 20;

@implementation HealthListViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view from its nib.
    
    listHealths = [[NSMutableArray alloc] init];
    __weak __typeof(self) weakSelf = self;
    
    //    _listDateTime = [NSMutableArray new];
    //    _expandedSections = [NSMutableIndexSet new];
    
    self.refreshControl = [[UIRefreshControl alloc] init];
    [self.refreshControl addTarget:self action:@selector(pullToRefreshData) forControlEvents:UIControlEventValueChanged];
    [self.tableViewHealthList addSubview:self.refreshControl];
    
    [self.tableViewHealthList addPullToRefreshWithActionHandler:^{
        [weakSelf requestgetListHealth];
    } position:SVPullToRefreshPositionBottom];
    
    [self initializeHealthView];
    [self.viewChart.subviews makeObjectsPerformSelector: @selector(removeFromSuperview)];
    [self setupGraph];
    [self resetDataInView];
    [self requestgetListHealth];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    [self setImageToBackgroundStandard:self.imageBackground];
}

- (void)viewDidAppear:(BOOL)animated {
    [super viewDidAppear:animated];
    [self alignViewBMIStage];
}

- (void)resetDataInView {
    numberPage = 1;
    if (listHealths.count > 0) {
        [listHealths removeAllObjects];
    }
}

/*
 #pragma mark - Navigation
 
 // In a storyboard-based application, you will often want to do a little preparation before navigation
 - (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
 // Get the new view controller using [segue destinationViewController].
 // Pass the selected object to the new view controller.
 }
 */

- (void)pullToRefreshData {
    [self resetDataInView];
    [self requestgetListHealth];
}

- (void)setupGraph {
    
    self.jsHealthChart = [JSChartView createStandardViewWithType:PHRStandardChartTypeHealth];
    [self.viewChart addSubview:self.jsHealthChart];
    [self.jsHealthChart autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0];
    [self.jsHealthChart autoPinEdgeToSuperviewEdge:ALEdgeBottom withInset:0];
    [self.jsHealthChart autoPinEdgeToSuperviewEdge:ALEdgeLeading withInset:0];
    [self.jsHealthChart autoPinEdgeToSuperviewEdge:ALEdgeTrailing withInset:0];
    
}

- (void)requestgetListHealth {
    __weak __typeof__(self) weakSelf = self;
//    [PHRAppDelegate showLoading];
    [self showOrHideLoading:YES];
    [[PHRClient instance] requestGetListStandardHealthWithId:PHRAppStatus.activeStandard.profileId andNumberPage:numberPage completed:^(id params) {
        NSArray *resultHealth = [params objectForKey:KEY_Content];
        if (resultHealth) {
            if (resultHealth.count > 0)
            {
                [weakSelf.jsHealthChart drawGraph:params];
            }
            for (int i = 0; i < resultHealth.count; i++) {
                NSDictionary *dict = [resultHealth objectAtIndex:i];
                HealthItem *objHealth = [HealthItem initHealthWithObj:dict];
                [listHealths addObject:objHealth];
            }
            //[PHRAppDelegate hideLoading];
            if (listHealths.count == 0) {
                [self.labelAverage setText:[NSString stringWithFormat:@"%@ %0.2f",kLocalizedString(kTitleAverage),0.0]];
                [self performSelector:@selector(openAddNewHealthRecord) withObject:nil afterDelay:1.0];
            }
            else {
                [self calculateBMI];
                numberPage += 1;
                [weakSelf.tableViewHealthList reloadData];
            }
        }
        [self showOrHideLoading:NO];
    } error:^(NSString *error) {
        //[PHRAppDelegate hideLoading];
        [self showOrHideLoading:NO];
        [NSUtils showAlertWithTitle:[NSString stringWithFormat:@"%@", error.description] message:kLocalizedString(kTitleAlertError)];
    }];
    
    [weakSelf.tableViewHealthList.pullToRefreshView stopAnimating];
}

- (void)showOrHideLoading:(BOOL)isShowed{
    if (isShowed) {
//        [PHRAppDelegate showLoadingInView:self.tableViewHealthList];
//        [PHRAppDelegate showLoadingInView:self.viewChart];
        [self.jsHealthChart showOrHideLoading:isShowed];
    } else {
        [self.refreshControl endRefreshing];
//        [PHRAppDelegate hideLoadingInView:self.tableViewHealthList];
//        [PHRAppDelegate hideLoadingInView:self.viewChart];
        [self.jsHealthChart showOrHideLoading:isShowed];
    }
}

- (NSMutableArray *) timeSortedBegins:(NSMutableArray *)array {
    NSMutableArray* begins = array;
    NSSortDescriptor *sort = [[NSSortDescriptor alloc] initWithKey:@"dateRecord" ascending:NO];
    [begins sortUsingDescriptors: @[sort]];
    return begins;
}

- (NSDictionary *) convertFromNSMutableArray{
    NSDictionary *dict =nil;
    dict = [NSDictionary dictionaryWithObjects:listHealths forKeys:[NSArray arrayWithObjects:@"content",nil]];
    return dict;
}

-(void) calculateBMI{
    float averageBMI = 0;
    float totalBMI = 0;
    float totalHealth = listHealths.count;
    for (int i = 0; i < listHealths.count; i++) {
        HealthItem* obj = (HealthItem*) [listHealths objectAtIndex:i];
        if (obj.height && obj.weight && ![obj.height isEmpty] && ![obj.weight isEmpty]) {
            float height = [obj.height floatValue];
            float weight = [obj.weight floatValue];
            height = height / 100;
            height = height * height;
            float param = weight / height;
            totalBMI = totalBMI + param;
        }
    }
    averageBMI = totalBMI / totalHealth;
    [self.labelAverage setText:[NSString stringWithFormat:@"%@ %0.2f",kLocalizedString(kTitleAverage),averageBMI]];
}

- (void)openAddNewHealthRecord {
    HealthViewController *newHealth = [[HealthViewController alloc] initWithNibName:NSStringFromClass([HealthViewController class]) bundle:nil];
    [newHealth setAddHealthCallBack:^(HealthItem *type) {
        [listHealths addObject:type];
        listHealths = [self timeSortedBegins:listHealths];
        [self drawChart];
        [self.tableViewHealthList reloadData];
    }];
    [self.navigationController pushViewController:newHealth animated:YES];
}

#pragma mark - Override method

- (void)actionNavigationBarItemRight {
    [self openAddNewHealthRecord];
}

#pragma mark - Initialize View In First Run

- (void)initializeHealthView {
    self.tableViewHealthList.delegate = self;
    self.tableViewHealthList.dataSource = self;
    [self.tableViewHealthList setAllowsMultipleSelection:YES];
    
    [self.tableViewHealthList setBackgroundColor:[UIColor clearColor]];
    [self.tableViewHealthList setSeparatorStyle:UITableViewCellSeparatorStyleNone];
    [self.tableViewHealthList registerNib:[UINib nibWithNibName:NSStringFromClass([HealthViewCell class]) bundle:nil] forCellReuseIdentifier:healthTableViewCell];
    
    [self.viewSeparateHealthList setHidden:YES];
    [self.viewBottomHealthList setBackgroundColor:[UIColor clearColor]];
    
    self.labelUnderWeight.numberOfLines = numberOfLine;
    self.labelNormal.numberOfLines = numberOfLine;
    self.labelOverWeight.numberOfLines = numberOfLine;
    self.labelObesity.numberOfLines = numberOfLine;
    self.labelExtremeObesity.numberOfLines = numberOfLine;
    
    [self.labelHealth setText:kLocalizedString(kHealthBMIChart)];
    [self.labelHealth setStyleRegularToLabelWithColor:[UIColor whiteColor] andSize:healthFontSize];
    [self.labelAverage setStyleRegularToLabelWithColor:[UIColor whiteColor] andSize:averageFontSize];
    
    [self.labelUnderWeight setText:kLocalizedString(kBMIUnderWeight)];
    [self.labelNormal setText:kLocalizedString(kBMINormal)];
    [self.labelOverWeight setText:kLocalizedString(kBMIOverWeight)];
    [self.labelObesity setText:kLocalizedString(kBMIObesity)];
    [self.labelExtremeObesity setText:kLocalizedString(kBMIExtremeObesity)];
    
    [self.labelUnderWeight setStyleRegularToLabelWithColor:PHR_COLOR_BMI_UNDERWEIGHT andSize:BMIStageFontSize];
    [self.labelNormal setStyleRegularToLabelWithColor:PHR_COLOR_BMI_NORMAL andSize:BMIStageFontSize];
    [self.labelOverWeight setStyleRegularToLabelWithColor:PHR_COLOR_BMI_OVERWEIGHT andSize:BMIStageFontSize];
    [self.labelObesity setStyleRegularToLabelWithColor:PHR_COLOR_BMI_OBESITY andSize:BMIStageFontSize];
    [self.labelExtremeObesity setStyleRegularToLabelWithColor:PHR_COLOR_BMI_EXTREMEOBESITY andSize:BMIStageFontSize];
    
    [self.viewColorUnderWeight setBackgroundColor:PHR_COLOR_BMI_UNDERWEIGHT];
    [self.viewColorNormal setBackgroundColor:PHR_COLOR_BMI_NORMAL];
    [self.viewColorOverWeight setBackgroundColor:PHR_COLOR_BMI_OVERWEIGHT];
    [self.viewColorObesity setBackgroundColor:PHR_COLOR_BMI_OBESITY];
    [self.viewColorExtremeObesity setBackgroundColor:PHR_COLOR_BMI_EXTREMEOBESITY];
    
    [self.labelTimeLine setText:kLocalizedString(kHealthTimeLine)];
    [self.labelTimeLine setStyleRegularToLabelWithColor:[UIColor blackColor] andSize:timeLineFontSize];
    
    [self.viewBottomHealthList setBackgroundColor:[UIColor whiteColor]];
    
    [self.viewTimeLine setBackgroundColor:[UIColor lightGrayColor]];
    [self.viewTimeLine setAlpha:0.5];
    
    [self.imageBackgroundBottom setBackgroundColor:[UIColor blackColor]];
    [self.imageBackgroundBottom setAlpha:0.5];
    
    [self setupNavigationBarTitle:kLocalizedString(kTitleHealth) titleIcon:@"Health" rightItem:kLocalizedString(kAdd)];
}

-(void) alignViewBMIStage{
    
    CGRect frameBMIView = self.viewBMIStage.frame;
    CGFloat heightBMIView = frameBMIView.size.height;
    CGFloat centerHeight = heightBMIView / 2;
    CGFloat widthBMIView = frameBMIView.size.width;
    widthBMIView = widthBMIView - 2 * offSetBMIStageView;
    // View Color
    CGPoint underWeightPoint    = CGPointMake(0.0 * widthBMIView + offSet + offSetBMIStageView, centerHeight - self.viewColorUnderWeight.frame.size.height / 2);
    CGPoint normalPoint         = CGPointMake(0.2 * widthBMIView + offSet + offSetBMIStageView, centerHeight - self.viewColorNormal.frame.size.height / 2);
    CGPoint overWeightPoint     = CGPointMake(0.4 * widthBMIView + offSet + offSetBMIStageView, centerHeight - self.viewColorOverWeight.frame.size.height / 2);
    CGPoint obesityPoint        = CGPointMake(0.6 * widthBMIView + offSet + offSetBMIStageView, centerHeight - self.viewColorObesity.frame.size.height / 2);
    CGPoint extremeObesityPoint = CGPointMake(0.8 * widthBMIView + offSet + offSetBMIStageView, centerHeight - self.viewColorExtremeObesity.frame.size.height / 2);
    // Label BMI stage
    CGPoint underWeightLabelPoint    = CGPointMake(underWeightPoint.x + self.viewColorUnderWeight.frame.size.width + spaceBetweenLabelAndView,
                                                   centerHeight - self.labelUnderWeight.frame.size.height / 2);
    CGPoint normalLabelPoint         = CGPointMake(normalPoint.x + self.viewColorNormal.frame.size.width + spaceBetweenLabelAndView,
                                                   centerHeight - self.labelNormal.frame.size.height / 2);
    CGPoint overWeightLabelPoint     = CGPointMake(overWeightPoint.x + self.viewColorOverWeight.frame.size.width + spaceBetweenLabelAndView,
                                                   centerHeight - self.labelOverWeight.frame.size.height / 2);
    CGPoint obesityLabelPoint        = CGPointMake(obesityPoint.x + self.viewColorObesity.frame.size.width + spaceBetweenLabelAndView,
                                                   centerHeight - self.labelObesity.frame.size.height / 2);
    CGPoint extremeObesityLabelPoint = CGPointMake(extremeObesityPoint.x + self.viewColorExtremeObesity.frame.size.width + spaceBetweenLabelAndView,
                                                   centerHeight - self.labelExtremeObesity.frame.size.height / 2);
    // -------- VIEW --------- //
    // Align 1 - Under Weight
    CGRect frameUIView1 = self.viewColorUnderWeight.frame;
    frameUIView1.origin = underWeightPoint;
    self.viewColorUnderWeight.frame = frameUIView1;
    // Align 2 - Normal
    CGRect frameUIView2 = self.viewColorNormal.frame;
    frameUIView2.origin = normalPoint;
    self.viewColorNormal.frame = frameUIView2;
    // Align 3 - OverWeight
    CGRect frameUIView3 = self.viewColorOverWeight.frame;
    frameUIView3.origin = overWeightPoint;
    self.viewColorOverWeight.frame = frameUIView3;
    // Align 4 - Obesity
    CGRect frameUIView4 = self.viewColorObesity.frame;
    frameUIView4.origin = obesityPoint;
    self.viewColorObesity.frame = frameUIView4;
    // Align 5 - Extreme Obesity
    CGRect frameUIView5 = self.viewColorExtremeObesity.frame;
    frameUIView5.origin = extremeObesityPoint;
    self.viewColorExtremeObesity.frame = frameUIView5;
    
    // -------- LABEL --------- //
    // Align 1 - Under Weight
    CGRect frameLabel1 = self.labelUnderWeight.frame;
    frameLabel1.origin = underWeightLabelPoint;
    self.labelUnderWeight.frame = frameLabel1;
    // Align 2 - Normal
    CGRect frameLabel2 = self.labelNormal.frame;
    frameLabel2.origin = normalLabelPoint;
    self.labelNormal.frame = frameLabel2;
    // Align 3 - OverWeight
    CGRect frameLabel3 = self.labelOverWeight.frame;
    frameLabel3.origin = overWeightLabelPoint;
    self.labelOverWeight.frame = frameLabel3;
    // Align 4 - Obesity
    CGRect frameLabel4 = self.labelObesity.frame;
    frameLabel4.origin = obesityLabelPoint;
    self.labelObesity.frame = frameLabel4;
    // Align 5 - Extreme Obesity
    CGRect frameLabel5 = self.labelExtremeObesity.frame;
    frameLabel5.origin = extremeObesityLabelPoint;
    self.labelExtremeObesity.frame = frameLabel5;
    
}

#pragma mark - TableView Data Source - Delegate

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    // Return the number of sections.
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    // Return the number of rows in the section.
    return listHealths.count;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    return 80.0;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    HealthViewCell *cell = [tableView dequeueReusableCellWithIdentifier:healthTableViewCell];
    
    if (!cell) {
        cell = [[HealthViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:healthTableViewCell];
    }
    
    [cell setBackgroundColor:[UIColor clearColor]];
    [cell setSelectionStyle:UITableViewCellSelectionStyleNone];
    
    if (listHealths.count > 0) {
        HealthItem *objHealth = [listHealths objectAtIndex:indexPath.row];
        [cell setDataTotableViewCell:objHealth];
    }
    return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    HealthItem *healthItem = [listHealths objectAtIndex:indexPath.row];
    [self openDetailOfOneStandardHealth:healthItem];
}

- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath {
//    __weak __typeof(self) weakSelf = self;
//    
//    if (editingStyle == UITableViewCellEditingStyleDelete) {
//        HealthItem *healthItem = [listHealths objectAtIndex:indexPath.row];
//        [self showOrHideLoading:YES];
//        [[PHRClient instance] requestDeleteStandardHealth:healthItem.healthId andCompleted:^(id params) {
//            [self showOrHideLoading:NO];
//            [listHealths removeObjectAtIndex:indexPath.row];
//            [weakSelf.tableViewHealthList reloadData];
//            [self drawChart];
//        } error:^(NSString *error) {
//            [NSUtils showAlertWithTitle:[NSString stringWithFormat:@"%@", error.description] message:kLocalizedString(kTitleAlertError)];
//        }];
//    }
}

- (void)drawChart{
    // generate data looklike JSON
    NSMutableArray* bArray = [self generateMutableArrayContainDataLikeJSON:listHealths];
    // generate Data
    NSDictionary* bDictionary = [NSDictionary dictionaryWithObject:bArray forKey:KEY_Content];
    [self.jsHealthChart drawGraph:bDictionary];
}
#pragma mark -

- (void)openDetailOfOneStandardHealth:(HealthItem *)healthItem {
    HealthViewController *detailView = [[HealthViewController alloc] initWithNibName:NSStringFromClass([HealthViewController class]) bundle:nil];
    detailView.standardHealthId = healthItem.healthId;
    [detailView setAddHealthCallBack:^(HealthItem *type) {
        BOOL isUpdated = NO;
        for (int i = 0; i < listHealths.count; i++) {
            HealthItem *obj = (HealthItem*) listHealths[i];
            if (obj.healthId == type.healthId) {
                listHealths[i] = type;
                isUpdated = YES;
                NSLog(@"[UPDATED]");
            }
            if (isUpdated) {
                NSLog(@"[BREAK]");
                break;
            }
        }
        listHealths = [self timeSortedBegins:listHealths];
        [self drawChart];
        [self.tableViewHealthList reloadData];
    }];
    [self.navigationController pushViewController:detailView animated:YES];
}

- (NSMutableArray*)generateMutableArrayContainDataLikeJSON:(NSMutableArray*)inputArray{
    NSMutableArray* result = [[NSMutableArray alloc]init];
    for (id object in inputArray) {
        if ([object isKindOfClass:[HealthItem class]]) {
            HealthItem* healthItemObj = (HealthItem*) object;
            NSDictionary *healthItemCoreData =[NSDictionary dictionaryWithObjectsAndKeys:
                                               healthItemObj.weight,KEY_Weight,
                                               healthItemObj.height,KEY_Height,
                                               healthItemObj.dateRecord,KEY_DateRecord,
                                               nil];
            [result addObject:healthItemCoreData];
        }
    }
    return result;
}

@end
