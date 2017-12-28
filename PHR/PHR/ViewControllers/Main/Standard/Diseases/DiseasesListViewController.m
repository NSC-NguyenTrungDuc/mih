//
//  DiseasesListViewController.m
//  PHR
//
//  Created by Luong Le Hoang on 5/31/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "DiseasesListViewController.h"

#import "DiseaseTableViewCell.h"

@interface DiseasesListViewController (){
  int pageNumber;
}
@property (strong, nonatomic) NSArray *menu;

@end

@implementation DiseasesListViewController

static NSString *cellIdentification = @"diseaseTableViewCell";

- (void)viewDidLoad {
  [super viewDidLoad];
  pageNumber = 1;
  
  [self.tableDiseases registerNib:[UINib nibWithNibName:NSStringFromClass([DiseaseTableViewCell class]) bundle:nil] forCellReuseIdentifier:cellIdentification];
  
  // Add refresh control
  //    self.refreshControl = [[UIRefreshControl alloc] init];
  //    [self.refreshControl addTarget:self action:@selector(pullToRefreshData) forControlEvents:UIControlEventValueChanged];
  //    [self.tableDiseases addSubview:self.refreshControl];
  //    [self.tableDiseases addPullToRefreshWithActionHandler:^{
  //        [self getDiseasesData];
  //    } position:SVPullToRefreshPositionBottom];
  
  // Table data
  self.arrayDiseaes = [[NSMutableArray alloc] init];
  //    [self resetDataInView];
  //    [self getDiseasesData];
} 

- (void)setListDiseases:(NSArray*)diseasesList {
  [self.arrayDiseaes addObjectsFromArray:diseasesList];
  
  if (_arrayDiseaes.count == 0) {
    _viewEmpty.hidden = NO;
  }else{
    _viewEmpty.hidden = YES;
  }
  
  [self.tableDiseases reloadData];
}

- (void)reloadTableData {
  [self.arrayDiseaes removeAllObjects];
  [self.tableDiseases reloadData];
}

- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
  // Dispose of any resources that can be recreated.
}

//- (void)resetDataInView{
//    pageNumber = 1;
//    [self.arrayDiseaes removeAllObjects];
//    [self.tableDiseases reloadData];
//}

- (void)showOrHideLoading:(BOOL)isShowed{
  if (!isShowed){
    [self.refreshControl endRefreshing];
  }
}

//- (void)pullToRefreshData {
//    [self resetDataInView];
//    [self getDiseasesData];
//}

//- (void)getDiseasesData {
//    [self showOrHideLoading:YES];
//    [self requestGetListDiseaesWithProfileId:PHRAppStatus.currentStandard.profileId];
//}
//
//- (void)requestGetListDiseaesWithProfileId:(NSString *)profileId {
//    __weak __typeof__(self) weakSelf = self;
//    [PHRAppDelegate showLoading];
//    [[PHRClient instance] requestGetListDiseases:[NSString stringWithFormat:@"%d",pageNumber] completed:^(id responseObj) {
//        if (responseObj != nil) {
//            NSLog(@"%@",responseObj);
//            //NSArray *arrayRawData = [NSArray arrayWithArray:[responseObj valueForKeyPath:KEY_Content]];
//            if ([[responseObj valueForKeyPath:KEY_Content] isKindOfClass:[NSArray class]]) {
//                NSArray *result = (NSArray *)[responseObj valueForKeyPath:KEY_Content];
//
//                weakSelf.arrayDiseaes = [[DataManager sharedManager] getArrayDieases:result withArray:self.arrayDiseaes];
//
//                if (weakSelf.arrayDiseaes.count > 0) {
//                    pageNumber += 1;
//                    [weakSelf.tableDiseases reloadData];
//                }
//            }
//        }
//        [PHRAppDelegate hideLoading];
//        [self.refreshControl endRefreshing];
//    } error:^(NSString * error) {
//        [PHRAppDelegate hideLoading];
//        [self.refreshControl endRefreshing];
//        [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
//    }];
//    [weakSelf.tableDiseases.pullToRefreshView stopAnimating];
//}
//
//- (NSMutableArray *)getArrayDateForDieases:(NSMutableArray *)list {
//    NSMutableArray *arrayDateTime = [[NSMutableArray alloc] init];
//
//    for (int i = 0; i < list.count; i++) {
//        DiseasesModel *dict = (DiseasesModel*) [list objectAtIndex:i];
//        NSDate *dateTime = [UIUtils dateFromServerTimeString:dict.datetime_record];
//
//        if (arrayDateTime.count > 0) {
//            BOOL isAdd = YES;
//            for (NSString *objDate in arrayDateTime) {
//                if ([objDate isEqualToString:[UIUtils formatDateOppositeStyle:dateTime]]) {
//                    isAdd = NO;
//                }
//            }
//            if (isAdd) {
//                [arrayDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
//            }
//        }
//        else {
//            [arrayDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
//        }
//    }
//    return arrayDateTime;
//}

#pragma mark - Override method

//- (void)actionNavigationBarItemRight {
//    // [self addNewDiseaes:nil];
//}


#pragma mark - TableView Data Source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
  // Return the number of sections.
  if([self.arrayDiseaes count] > 0){
    return 1;
  }else{
    return 0;
  }
  
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
  // Return the number of rows in the section.
  return [self.arrayDiseaes count];
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
  
  DiseaseTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:cellIdentification];
  if (cell == nil) {
    cell = [[DiseaseTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:cellIdentification];
  }
  
  DiseasesModel *model = [self.arrayDiseaes objectAtIndex:indexPath.row];
  cell.lblDiseasesName.text = model.disease_name;
  cell.lblHospiatalName.text = model.hospital;
  //    cell.lblDateTime.text = model.datetime_record;
  //    NSDate  *dateTime = [UIUtils dateFromServerTimeString:model.datetime_record];
  //    if([NSUtils checkDateIsToday:dateTime]) {
  //        [cell.lblDateTime setText:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday), [UIUtils remiderTimeStringFromDate:dateTime]]];
  //    } else {
  //        [cell.lblDateTime setText:[UIUtils stringDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT_FOR_MEDICINE]];
  //    }
  cell.lblDateTime.text = model.datetime_record;
  cell.selectionStyle = UITableViewCellSelectionStyleNone;
  
  if(indexPath.row % 2 != 0){
    cell.backgroundColor = [UIColor colorWithRed:240.0/255.0 green:240.0/255.0 blue:240.0/255.0 alpha:1.0];
  }
  
  return cell;
}


#pragma mark - TableView Delegate

- (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath {
  if (indexPath.row == 0) {
    return NO;
  }
  return NO;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
  
  DLog(@"Selected Section is %ld and subrow is %ld ",(long)indexPath.section,(long)indexPath.row);
  if (self.arrayDiseaes.count > 0) {
    DiseasesModel *model = [self.arrayDiseaes objectAtIndex:(indexPath.row )];
    
    DiseasesViewController *controller = [[DiseasesViewController alloc] initWithNibName:NSStringFromClass([DiseasesViewController class]) bundle:nil];
    controller.id_diseases = model.disease_id;
    controller.type = self.type;
    controller.model = model;
    
    //[self.navigationController pushViewController:controller animated:YES];
    self.openDiseasesViewController(controller);
  }
  
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
  return 50.0f;
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

#pragma mark - Get Array From Date
//- (void)reDisplayDataForDieases {
//    [self.tableDiseases reloadData];
//}
//
//- (NSMutableArray *)getArrayDieasesWithDateTime:(NSString *)dateTime {
//    NSMutableArray *diseaess = [NSMutableArray new];
//    for (int i = 0; i < self.arrayDiseaes.count; i++) {
//        DiseasesModel *model = [self.arrayDiseaes objectAtIndex:i];
//        if ([[UIUtils formatDateOppositeStyle:[UIUtils dateFromServerTimeString:model.datetime_record]] isEqualToString:dateTime]) {
//            [diseaess addObject:model];
//        }
//    }
//    return diseaess;
//}
//
//- (NSMutableArray*)generateDataLikeJSONForMedicine:(NSMutableArray*)inputArray{
//    NSMutableArray* result = [[NSMutableArray alloc]init];
//    for (id object in inputArray) {
//        if ([object isKindOfClass:[MedicineNote class]]) {
//            MedicineNote* medicineObj = (MedicineNote*) object;
//            NSDictionary *medicineDict =[NSDictionary dictionaryWithObjectsAndKeys:
//                                         medicineObj.time_take_medicine,KEY_MedicineNote_Time,
//                                         nil];
//            [result addObject:medicineDict];
//        }
//    }
//    return result;
//}
//
//- (NSMutableArray*)generateDataLikeJSONForDieases:(NSMutableArray*)inputArray{
//    NSMutableArray* result = [[NSMutableArray alloc]init];
//    for (id object in inputArray) {
//        if ([object isKindOfClass:[DiseasesModel class]]) {
//            DiseasesModel* diseasesObj = (DiseasesModel*) object;
//            NSDictionary *diseases =[NSDictionary dictionaryWithObjectsAndKeys:
//                                     diseasesObj.disease_name,KEY_disease_name,
//                                     diseasesObj.datetime_record,KEY_datetime_record,
//                                     nil];
//            [result addObject:diseases];
//        }
//    }
//    return result;
//}

@end
