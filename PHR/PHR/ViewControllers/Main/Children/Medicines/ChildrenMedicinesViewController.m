//
//  ChildrenMedicinesViewController.m
//  PHR
//
//  Created by BillyMobile on 6/16/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "ChildrenMedicinesViewController.h"
#import "PresciptionListTableViewCell.h"
#import "AddBabyPrescriptionViewController.h"

#define PRESCRIPTION_LIST 65

@interface ChildrenMedicinesViewController (){
  int pageNumber;
  BOOL isFirstCome;
  BOOL _isShow;
  BOOL isShowDialog;
  NSURLSessionDataTask *taskGetTimeLine;
}

@end

static NSString *MedicinePresciptionIdentifier     = @"presciption_list_cell";

@implementation ChildrenMedicinesViewController

- (void)viewDidLoad {
  [super viewDidLoad];
  
  _viewEmpty.hidden = YES;
  
  [self initializeMedicinesView];
  self.arrayPrescription = [[NSMutableArray alloc] init];
  isFirstCome = YES;
  pageNumber = 1;
  _isShow = YES;
  
  // NSString *apiId = PHRAppStatus.currentBaby.profileId;
  // [self requestGetListPresciptionWithProfileId:apiId];
  
  self.refreshControl = [[UIRefreshControl alloc] init];
  [self.refreshControl addTarget:self action:@selector(pullToRefreshData) forControlEvents:UIControlEventValueChanged];
  
  [self.medicineTableView addSubview:self.refreshControl];
  
  [self.medicineTableView addPullToRefreshWithActionHandler:^{
    NSString *apiId = PHRAppStatus.currentBaby.profileId;
    [self requestGetListPresciptionWithProfileId:apiId];
  } position:SVPullToRefreshPositionBottom];
}

- (void)didReceiveMemoryWarning {
  [super didReceiveMemoryWarning];
  // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated {
  [super viewWillAppear:animated];
  //[self setImageToBackgroundBaby:self.imageBackground];
  [[NSNotificationCenter defaultCenter] removeObserver:self name:kNotifyProfileBabyActiveChanged object:nil];
  [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(handleProfileActiveChanged:) name:kNotifyProfileBabyActiveChanged object:nil];
}

- (void)showOrHideLoading:(BOOL)isShowed {
  if (isShowed) {
    [self.viewIndicator setHidden:NO];
  } else {
    [self.viewIndicator setHidden:YES];
  }
}

- (void)removeObserve {
  [[NSNotificationCenter defaultCenter] removeObserver:self];
}

- (void)initializeMedicinesView {
  [self.medicineTableView registerNib:[UINib nibWithNibName:NSStringFromClass([PresciptionListTableViewCell class]) bundle:nil] forCellReuseIdentifier:MedicinePresciptionIdentifier];
  
  [self checkProfileToShowView];
  
  self.lblPrescriptionList.font = [FontUtils aileronRegularWithSize:15.0];
  self.lblPrescriptionList.text = kLocalizedString(kPrescriptionList);
  //    self.viewTabbar.backgroundColor = [[UIColor colorWithRed:51.0/255.0 green:52.0/255.0 blue:62.0/255.0 alpha:1.0] colorWithAlphaComponent:0.3];
  self.lblAddData.text = kLocalizedString(kAdd);
  self.medicineTableView.showsHorizontalScrollIndicator = NO;
  self.medicineTableView.showsVerticalScrollIndicator = NO;
  
  self.viewAdd.backgroundColor = [UIColor colorWithRed:238.0/255.0 green:145.0/255.0 blue:128.0/255.0 alpha:1.0];
  
  [self.medicineTableView setDelegate:self];
  [self.medicineTableView setDataSource:self];
}

- (void)handleProfileActiveChanged:(NSNotification*)notification{
  [self checkProfileToShowView];
  [self pullToRefreshData];
}

- (void)refreshAllView {
  [self checkProfileToShowView];
  [self pullToRefreshData];
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

- (void)pullToRefreshData {
  pageNumber = 1;
  [self.arrayPrescription removeAllObjects];
  [self.medicineTableView reloadData];
  NSString *apiId = PHRAppStatus.currentBaby.profileId;
  [self requestGetListPresciptionWithProfileId:apiId];
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
  return 1.0;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
  return self.arrayPrescription.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
  
  PresciptionListTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:MedicinePresciptionIdentifier forIndexPath:indexPath];
  if (!cell) {
    cell = [[PresciptionListTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:MedicinePresciptionIdentifier];
  }
  cell.selectionStyle = UITableViewCellSelectionStyleNone;
  
  PresciptionObject *objPres = ([self.arrayPrescription objectAtIndex:indexPath.row]);
  
  cell.lblPresciption.text = objPres.prescription_name;
  cell.lblDateTime.text = [UIUtils stringDate:[UIUtils dateFromString:objPres.datetime_record withFormat:PHR_SERVER_DATE_TIME_FORMAT] withFormat:PHR_CLIENT_TIME_FORMAT_FULL];
  if (![PHRAppStatus checkCurrentBabyActive]) {
    cell.isActive = NO;
  } else {
    cell.isActive = YES;
  }
  [cell setDeleteCallBack:^(){
    [self requestDeletePrescription:objPres.prescription_id];
  }];
  
  return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath{
  AddBabyPrescriptionViewController *controller = [[AddBabyPrescriptionViewController alloc] initWithNibName:NSStringFromClass([AddBabyPrescriptionViewController class]) bundle:nil];
  controller.type = self.type;
  controller.isUpdate = YES;
  controller.prescriptionItem = [self.arrayPrescription objectAtIndex:indexPath.row];
  [controller setAddPrescriptionCallBack:^(){
    [self pullToRefreshData];
  }];
  if ([self.delegate respondsToSelector:@selector(takeScreenShot)]) {
    controller.imageBG = [self.delegate takeScreenShot];
  }
  if ([self.delegate respondsToSelector:@selector(presentViewControllerOnDashboard:)]) {
    [self.delegate presentViewControllerOnDashboard:controller];
  }
}

- (void)requestGetListPresciptionWithProfileId:(NSString *)profileId {
  if (!PHRAppStatus.currentBaby || !profileId || profileId.isEmpty) {
    return;
  }
  [self showOrHideLoading:YES];
  __weak __typeof__(self) weafSelf = self;
  if (taskGetTimeLine){
    [taskGetTimeLine cancel];
  }
  //[PHRAppDelegate showLoading];
  taskGetTimeLine = [[PHRClient instance] requestMedicinesWithApiID:profileId andNumberPage:pageNumber andCompleted:^(id params) {
    id response = [params objectForKey:KEY_Content];
    if ([response isKindOfClass:[NSArray class]]) {
      NSArray *resulPrescriptions = (NSArray *)response;
      for (int i = 0; i < resulPrescriptions.count; i++) {
        pageNumber += 1;
        NSDictionary *dict = [resulPrescriptions objectAtIndex:i];
        PresciptionObject *objNote = [PresciptionObject initializeMedicinFrom:dict];
        [weafSelf.arrayPrescription addObject:objNote];
      }
    }
    if (weafSelf.arrayPrescription.count == 0) {
      //   if (isShowDialog) {
      //     [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kMedicineListEmpty)];
      _viewEmpty.hidden = NO;
      //   }
    }else{
      _viewEmpty.hidden = YES;
    }
    
    [weafSelf.medicineTableView reloadData];
    [weafSelf.refreshControl endRefreshing];
    [weafSelf.medicineTableView.pullToRefreshView stopAnimating];
    [self showOrHideLoading:NO];
  } error:^(NSString *error) {
    [self showOrHideLoading:NO];
    if (isShowDialog) {
      [NSUtils showAlertWithTitle:APP_NAME message:kLocalizedString(kErrorConectToHost)];
    }
    [weafSelf.refreshControl endRefreshing];
    [weafSelf.medicineTableView.pullToRefreshView stopAnimating];
  }];
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
  
  return PRESCRIPTION_LIST;
}

- (void)requestDeletePrescription:(NSString*) prescriptionID{
  [[PHRClient instance] requestDeletePrescription:prescriptionID completed:^(id response){
    [PHRAppDelegate hideLoading];
    if (response) {
      BOOL status = [PHRClient getStatusFromResponse:response];
      if(status){
        NSDictionary *newDict = [[NSDictionary dictionaryWithDictionary:response] valueForKeyPath:@"content"];
        
        NSLog(@"%@",newDict);
        [self pullToRefreshData];
        
        [self.medicineTableView reloadData];
        
      } else {
        NSString* message = [PHRClient getMessageFromResponse:response];
        [NSUtils showMessage:kLocalizedString(message) withTitle:APP_NAME];
      }
    }
    
  } error:^(NSString *error){
    [PHRAppDelegate hideLoading];
    [NSUtils showMessage:error withTitle:APP_NAME];
  }];
  
}

- (IBAction)actionAddData:(id)sender {
  AddBabyPrescriptionViewController *controller = [[AddBabyPrescriptionViewController alloc] initWithNibName:NSStringFromClass([AddBabyPrescriptionViewController class]) bundle:nil];
  controller.isUpdate = NO;
  [controller setAddPrescriptionCallBack:^(){
    [self pullToRefreshData];
  }];
  if ([self.delegate respondsToSelector:@selector(takeScreenShot)]) {
    controller.imageBG = [self.delegate takeScreenShot];
  }
  if ([self.delegate respondsToSelector:@selector(presentViewControllerOnDashboard:)]) {
    [self.delegate presentViewControllerOnDashboard:controller];
  }
}

- (void)setIsShowDialog:(BOOL)isShow {
  isShowDialog = isShow;
}
@end
